using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using Util;
using GUI.BaoCao;

namespace PhongKham
{
    public partial class frmKhamThem : Form
    {
        public frmKhamThem()
        {
            InitializeComponent();
        }
        BenhNhan_Info bn;
        LanKham_Info lk;
        DoiTuong_Info dt;
        BacSi_Info bs;
        public frmKhamThem(BenhNhan_Info bn,LanKham_Info lk,DoiTuong_Info dt,BacSi_Info bs)
        {
            this.bn = bn;
            this.lk = lk;
            this.dt = dt;
            this.bs = bs;
            InitializeComponent();
        }
        DataTable dsDichVuKe;
        private void load()
        {
            gridDSDichVu.DataSource = DichVu_Info.SelectAllTable();
            dsDichVuKe = DichVu_Info.SelectAllTable();
            gridDSDichVuKe.DataSource = dsDichVuKe;
            dsDichVuKe.Rows.Clear();
        }
        private DataTable load_bs()
        {
            DataTable ds_bs = BacSi_Info.SelectAllTableCustemer();
            DataRow r = ds_bs.NewRow();
            r["BacSiID"] = 0;
            r["HoTen"] = "Tự đến";

            ds_bs.Rows.Add(r);
            DataView v = ds_bs.DefaultView;
            v.Sort = "BacSiID";
            return v.ToTable();
        }
        private void frmDonTiep_Load(object sender, EventArgs e)
        {
            load();
            
            
            cbx_BacSiGui.DataSource = load_bs();
            cbx_BacSiGui.ValueMember = "BacSiID";
            cbx_BacSiGui.DisplayMember = "HoTen";
            cbx_GioiTinh.DataSource = Util.ResetControl.getTable_forCombo(new string[] { "ID", "Name" }, new string[] { "True", "False" }, new string[] { "Nam", "Nữ" });
            cbx_GioiTinh.DisplayMember = "ID";
            cbx_GioiTinh.ValueMember = "Name";
            cbx_MaDoiTuong.DataSource = DoiTuong_Info.SelectAllTable();
            cbx_MaDoiTuong.ValueMember = "TenDoiTuong";
            cbx_MaDoiTuong.DisplayMember = "DoiTuongID";
            Util.FormHandler.SetEnterKeyForAllControlsLevel(txtDiaChi.GetType(), this.Controls);
            Util.FormHandler.SetEnterKeyForAllControlsLevel(txtNamSinh.GetType(), this.Controls);
            Util.FormHandler.SetEnterKeyForAllControlsLevel(txt_Ngay_Gio_vaovien.GetType(), this.Controls);
            Util.ResetControl.SetEnterForUltraComboUltraTextBox(new UltraCombo[] { cbx_GioiTinh, cbx_MaDoiTuong }, new TextBox[] { txtGioiTinh, txtTenDoiTuong });
            Util.ResetControl.SetSourceForGridCustomCollumns(gridDSDichVu, new string[] { "MaDichVu", "TenDichVu", "DonGia" }, new string[] { "Mã dịch vụ", "Tên dịch vụ", "Đơn giá" });
            Util.ResetControl.SetSourceForGridCustomCollumns(gridDSDichVuKe, new string[] { "MaDichVu", "TenDichVu", "SoLuong", "DonGia" }, new string[] { "Mã dịch vụ", "Tên dịch vụ", "Số lượng", "Đơn giá" });
            // load text
            txtChuanDoan.Text = lk.ChuanDoan;
            txtDiaChi.Text = bn.DiaChi;
            txtGioiTinh.Text = bn.GioiTinh == true ? "Nam" : "Nữ";
            txtHoTenBenhNhan.Text = bn.HoTen;
            txtMaTheBHYT.Text = lk.SoBH;
            txtNamSinh.Value = bn.Tuoi;
            txtSoDienThoai.Text = bn.DienThoai;
            txtSoKham.Text = lk.SoKham.ToString();
            txtTenDoiTuong.Text = dt.TenDoiTuong;
            txt_Ngay_Gio_vaovien.Value = lk.NgayKham;
            cbx_BacSiGui.Text = lk.BacSiGuiID.ToString();
            cbx_GioiTinh.Text = bn.GioiTinh.ToString();
            cbx_MaDoiTuong.Text = lk.DoiTuongID.ToString();
            txtBacSiID.Text = bs.BacSiID.ToString();
            txtMaDichVu.Focus();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            bool flag = gridDSDichVu.ActiveRow == null;
            if (!flag)
            {
                DataRow dataRow = dsDichVuKe.NewRow();
                dataRow["DichVuID"] = gridDSDichVu.ActiveRow.Cells["DichVuID"].Value.ToString();
                dataRow["MaDichVu"] = gridDSDichVu.ActiveRow.Cells["MaDichVu"].Value.ToString();
                dataRow["TenDichVu"] = gridDSDichVu.ActiveRow.Cells["TenDichVu"].Value.ToString();
                dataRow["Tenphong"] = gridDSDichVu.ActiveRow.Cells["TenPhong"].Value.ToString();
                dataRow["DonGia"] = txtDonGia.Value.ToString();
                dataRow["SoLuong"] = txtSoLuong.Value.ToString();
                dataRow["SoLuongHuy"] = 0;
                dataRow["BacSiGuiID"] = Convert.ToInt32(cbx_BacSiGui.Value);
                dsDichVuKe.Rows.Add(dataRow);
                txtTongChiPhi.Value = Convert.ToDecimal(txtTongChiPhi.Value) + Convert.ToDecimal(txtDonGia.Value);
                txtMaDichVu.Text = "";
                txtTenDichVu.Text = "";
                DataView dataView = ((DataTable)gridDSDichVu.DataSource).DefaultView;
                dataView.RowFilter = "MaDichVu like '%%'";
                txtMaDichVu.Focus();
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            txtDonViTinh.Text = "";
            txtPhanTramGiam.Value = null;
            txtSoLuong.Value = null;
            txtDonGia.Value = null;
            txtMaDichVu.Text = "";
            txtMaDichVu_KeyPress(txtMaDichVu, new KeyPressEventArgs('\r'));
            txtMaDichVu.Focus();
        }
        public bool CheckValue()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(txtSoKham);
            arrayList.Add(txtHoTenBenhNhan);
            arrayList.Add(cbx_GioiTinh);
            arrayList.Add(cbx_MaDoiTuong);
            arrayList.Add(txt_Ngay_Gio_vaovien);
            return ResetControl.CheckValue(arrayList, errorProvider1);
        }

        private void clear()
        {
            txtBacSiID.Text = "";
            txtChuanDoan.Text = "";
            txtDiaChi.Text = "";
            txtGioiTinh.Text = "";
            txtHoTenBenhNhan.Text = "";

            txtMaTheBHYT.Text = "";
            txtNamSinh.Value = 1;
            cbx_BacSiGui.Text = "";
            cbx_GioiTinh.Text = "";
            cbx_MaDoiTuong.Text = "";
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            bool flag = CheckValue();
            if (flag)
            {

                foreach (DataRow dataRow in ((DataTable)gridDSDichVuKe.DataSource).Rows)
                {

                    DichVu_LanKham_Info dichVu_LanKham_Info = new DichVu_LanKham_Info(0, Convert.ToInt32(dataRow["DichVuID"].ToString()), lk.Ma, Convert.ToInt32(dataRow["BacSiGuiID"].ToString()), Convert.ToInt32(dataRow["SoLuong"].ToString()), Convert.ToDecimal(dataRow["DonGia"].ToString()), 0, Convert.ToDateTime(txt_Ngay_Gio_vaovien.Value), DateTime.Now, 0);
                    dichVu_LanKham_Info.Insert();

                }

                TienNop_LanKham_Info tn = new TienNop_LanKham_Info(0, lk.LanKhamID, Convert.ToDecimal(txtTongChiPhi.Value), "");
                tn.Insert();               
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                txtSoKham.Focus();
                // In biên lai

                DataTable ds = dsDichVuKe;
                foreach (DataRow r in ds.Rows)
                {
                    DataView v = ds.DefaultView;
                    v.RowFilter = "DichVuID=" + r["DichVuID"].ToString();
                    decimal t = Convert.ToDecimal(r["SoLuong"].ToString()) * Convert.ToDecimal(r["DonGia"].ToString());
                    string[] ParamName = { "@NgayThu", "@HoVaTen", "@Tuoi", "@DiaChi", "@TenDoiTuong", "@SoTien", "@BangChu","@SoKham","@Phong" };
                    object[] ParamValue ={DateTime.Now, txtHoTenBenhNhan.Text,txtNamSinh.Value.ToString()
                ,txtDiaChi.Text,txtTenDoiTuong.Text,t,
                Util.FormHandler.txtVND(Convert.ToDecimal(t)),txtSoKham.Text,r["TenPhong"].ToString() };
                    frmReportMain report = new frmReportMain(11, v.ToTable(), ParamName, ParamValue);
                    report.Show();

                }
                dsDichVuKe.Rows.Clear();
                this.Close();

            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = gridDSDichVuKe.ActiveRow == null;
            if (!flag)
            {
                flag = MessageBox.Show("Bạn có thật sự muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK;
                if (!flag)
                {
                    txtTongChiPhi.Value = Convert.ToDecimal(txtTongChiPhi.Value) - Convert.ToDecimal(gridDSDichVuKe.ActiveRow.Cells["DonGia"].Value);
                    ((DataTable)gridDSDichVuKe.DataSource).Rows.RemoveAt(gridDSDichVuKe.ActiveRow.Index);
                }
            }
        }

        private void gridDSDichVu_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            bool flag = gridDSDichVu.ActiveRow == null;
            if (!flag)
            {
                txtMaDichVu.Text = gridDSDichVu.ActiveRow.Cells["MaDichVu"].Value.ToString();
                txtTenDichVu.Text = gridDSDichVu.ActiveRow.Cells["TenDichVu"].Value.ToString();
                txtDonViTinh.Text = gridDSDichVu.ActiveRow.Cells["DonViTinh"].Value.ToString();
                txtDonGia.Value = gridDSDichVu.ActiveRow.Cells["DonGia"].Value;
                txtSoLuong.Value = 1;
            }
        }

        private void gridDSDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool flag = e.KeyChar != '\r';
            if (!flag)
            {
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                gridDSDichVu_AfterSelectChange(sender, null);
            }

        }

        private void neDonGia_KeyUp(object sender, KeyEventArgs e)
        {

            bool flag = e.KeyCode != Keys.Enter;
            if (!flag)
                txtDonGia.SelectAll();
        }

        private void neSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            bool flag = e.KeyCode != Keys.Enter;
            if (!flag)
                txtSoLuong.SelectAll();
        }

        private void txtMaDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool flag = e.KeyChar != '\r';
            if (!flag)
            {
                string s = txtTenDichVu.Text.Trim();
                txtTenDichVu_KeyPress(txtTenDichVu, e);
                txtTenDichVu.Focus();
                txtTenDichVu.Text = s;
                txtTenDichVu.SelectAll();
            }
        }

        private void txtTenDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool flag = e.KeyChar != '\r';
            if (!flag)
            {
                DataView dataView = ((DataTable)gridDSDichVu.DataSource).DefaultView;
                dataView.RowFilter = "MaDichVu like '%" + txtMaDichVu.Text.Trim() + "%' and TenDichVu like '%" + txtTenDichVu.Text.Trim() + "%'";
                gridDSDichVu.Focus();
            }
        }

        private void cdt_Ngayvaovien_KeyDown(object sender, KeyEventArgs e)
        {
            bool flag = e.KeyData != Keys.Enter;
            if (!flag)
            {
                flag = txt_Ngay_Gio_vaovien.Value.ToString() != "";
                if (!flag)
                {
                    txt_Ngay_Gio_vaovien.InputMask = "dd/mm/yyyy hh:mm tt";
                    txt_Ngay_Gio_vaovien.Value = DateTime.Now;
                }
                else
                {
                    DateTime dateTime1 = Convert.ToDateTime(txt_Ngay_Gio_vaovien.Value);
                    DateTime dateTime3 = DateTime.Now;
                    dateTime3 = dateTime3 = DateTime.Now;
                    DateTime dateTime2 = Convert.ToDateTime(new DateTime(dateTime3.Year - Convert.ToInt32(txtNamSinh.Value), dateTime3.Month, dateTime3.Day, 1, 0, 0));
                    flag = dateTime1 >= dateTime2;
                    if (!flag)
                        errorProvider1.SetError(txt_Ngay_Gio_vaovien, "Ng\u00E0y v\u00E0o vi\u1EC7n ph\u1EA3i l\u1EDBn h\u01A1n ng\u00E0y sinh!");
                    else
                        errorProvider1.Clear();
                }
            }
        }

        private void btn_ThemBacSiGui_Click(object sender, EventArgs e)
        {
            frmBacSiGui f = new frmBacSiGui();
            f.ShowDialog();
            cbx_BacSiGui.DataSource = BacSi_Info.SelectAllTable2();
            cbx_BacSiGui.ValueMember = "HoTen";
            cbx_BacSiGui.DisplayMember = "BacSiID";
            cbx_BacSiGui.Select();
        }

        private void btn_ThemDV_Click(object sender, EventArgs e)
        {
            frmDichVu f = new frmDichVu();
            f.ShowDialog();
            gridDSDichVu.DataSource = DichVu_Info.SelectAllTable();
            txtMaDichVu.Select();
        }

        private void txtBacSiGui_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMaDichVu.Focus();
            }
        }

        private void cbx_MaDoiTuong_TextChanged(object sender, EventArgs e)
        {
            if (cbx_MaDoiTuong.Value != null && cbx_MaDoiTuong.Value.ToString() != "Dịch vụ")
            {
                txtMaTheBHYT.ReadOnly = false;
            }
            else txtMaTheBHYT.ReadOnly = true;
        }

        private void btn_ThemBacSiGui_Click_1(object sender, EventArgs e)
        {
            frmBacSiGui f = new frmBacSiGui();
            f.ShowDialog();

            cbx_BacSiGui.DataSource = load_bs();

            cbx_BacSiGui.ValueMember = "BacSiID";
            cbx_BacSiGui.DisplayMember = "HoTen";
        }

        private void cbx_BacSiGui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cbx_BacSiGui.Value == null || cbx_BacSiGui.Value.ToString() == "")
                {
                    DataView dv = load_bs().DefaultView;
                    dv.RowFilter = "HoTen like '%" + cbx_BacSiGui.Text.Trim() + "%'";
                    cbx_BacSiGui.DataSource = dv.ToTable();
                    if (dv.Count > 0)
                        cbx_BacSiGui.PerformAction(UltraComboAction.Dropdown);
                    else
                    {
                        txtBacSiID.Text = "";
                        txtMaDichVu.Focus();
                    }
                }
                else
                {
                    txtMaDichVu.Focus();
                }

            }
        }

        private void txtBacSiID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtBacSiID.Text.Trim() != "")
                {
                    DataView dv = load_bs().DefaultView;
                    dv.RowFilter = "BacSiID =" + txtBacSiID.Text.Trim();
                    cbx_BacSiGui.DataSource = dv.ToTable();
                    cbx_BacSiGui.PerformAction(UltraComboAction.Dropdown);
                }
                else
                {
                    DataView dv = load_bs().DefaultView;

                    cbx_BacSiGui.DataSource = dv.ToTable();
                    cbx_BacSiGui.PerformAction(UltraComboAction.Dropdown);
                }
            }
        }

        private void cbx_BacSiGui_TextChanged(object sender, EventArgs e)
        {
            if (cbx_BacSiGui.ActiveRow != null)
            {
                txtBacSiID.Text = cbx_BacSiGui.ActiveRow.Cells["BacSiID"].Value.ToString();
            }
        }
    }
}