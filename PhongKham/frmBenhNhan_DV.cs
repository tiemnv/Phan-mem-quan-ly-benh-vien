using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using GUI.BaoCao;

namespace PhongKham
{
    public partial class frmBenhNhan_DV : Form
    {
        public frmBenhNhan_DV()
        {
            InitializeComponent();
        }
        DataTable tb = new DataTable();
        List<DichVu_LanKham_Info> dv_lk_list = new List<DichVu_LanKham_Info>();
        private void load()
        {
            tb = Util.DB_SQL.EXECUTE_SQL(@"SELECT  ROW_NUMBER() OVER(ORDER BY LanKhamID DESC) AS STT, dbo.BenhNhan.*,LanKham.Ma as LanKhamID, dbo.LanKham.SoBH, 
dbo.LanKham.ChuanDoan, dbo.LanKham.NgayKham, dbo.LanKham.GioKham, dbo.LanKham.SoKham, 
LanKham.BacSiGuiID,BacSi.HoTen as HoTenBacSi,
                      dbo.DoiTuong.TenDoiTuong
                      FROM    dbo.BenhNhan INNER JOIN
                      dbo.LanKham ON dbo.BenhNhan.Ma = dbo.LanKham.MaBenhNhan INNER JOIN
                      dbo.DoiTuong ON dbo.LanKham.DoiTuongID = dbo.DoiTuong.DoiTuongID
                      left JOIN
                      dbo.BacSi ON dbo.LanKham.BacSiGuiID = dbo.BacSi.BacSiID
");
            GridBenhNhan.DataSource = tb;
            dv_lk_list = DichVu_LanKham_Info.SelectAllList();
            label_TongBN.Text = string.Format("{0:00} Người", tb.Rows.Count);  

        }
        private void frmBenhNhan_DV_Load(object sender, EventArgs e)
        {
            load();
            
            
            Util.ResetControl.SetSourceForGridCustomCollumns(GridBenhNhan, new string[] {"STT", "HoTen", "NgayKham" }, new string[] { "STT","Họ tên", "Ngày khám" });

        }

        private void txtseachHoTen_TextChanged(object sender, EventArgs e)
        {
            DataView dv = ((DataTable)GridBenhNhan.DataSource).DefaultView;
            
                dv.RowFilter = "HoTen like '%" + txtseachHoTen.Text + "%'";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private DataTable LoadDV(string MaLanKham)
        {
            DataTable b = Util.DB_SQL.EXECUTE_PROC("DichVu_LanKham_Dis", new object[] { "@MaLanKham", MaLanKham });
            decimal tcp = 0;
            foreach (DataRow r in b.Rows)
            {
                tcp += (Convert.ToInt32(r["SoLuongCon"])) * Convert.ToDecimal(r["DonGia"]);
            }
            txtTongChiPhi.Value = tcp;
            return b;
        }
        private void GridBenhNhan_AfterRowActivate(object sender, EventArgs e)
        {
            txtDiaChi.Text = GridBenhNhan.ActiveRow.Cells["DiaChi"].Value.ToString();
            txtDienThoai.Text = GridBenhNhan.ActiveRow.Cells["DienThoai"].Value.ToString();
            txtDoiTuong.Text = GridBenhNhan.ActiveRow.Cells["TenDoiTuong"].Value.ToString();
            txtGT.Text = Convert.ToBoolean(GridBenhNhan.ActiveRow.Cells["GioiTinh"].Value) == true ? "Nam" : "Nữ";
            txtHoTen.Text = GridBenhNhan.ActiveRow.Cells["HoTen"].Value.ToString();
            txtMaTheBHYT.Text = GridBenhNhan.ActiveRow.Cells["SoBH"].Value.ToString();
            txtNgayKham.Text = GridBenhNhan.ActiveRow.Cells["NgayKham"].Value.ToString();
            txtTuoi.Text = GridBenhNhan.ActiveRow.Cells["Tuoi"].Value.ToString();
            txtMaBenhAn.Text =GridBenhNhan.ActiveRow.Cells["SoKham"].Value.ToString();
            grid_DV.DataSource = LoadDV(GridBenhNhan.ActiveRow.Cells["LanKhamID"].Value.ToString());
            Util.ResetControl.SetSourceForGridCustomCollumns(grid_DV, new string[] {"STT", "TenDichVu", "SoLuong","SoLuongHuy","DonGia" }, new string[] {"STT", "Dịch vụ", "Số lượng","Số lượng hủy","Đơn giá"});
        }

        private void btn_napLai_Click(object sender, EventArgs e)
        {
            load();
        }

      

        private void SuaThongTinBN_Click(object sender, EventArgs e)
        {
            if (grid_DV.ActiveRow != null)
            {
                DichVu_LanKham_Info dv_lk = new DichVu_LanKham_Info();

                dv_lk = (DichVu_LanKham_Info)Util.FormHandler.GetAs(((DataTable)grid_DV.DataSource).Rows[grid_DV.ActiveRow.Index], typeof(DichVu_LanKham_Info));
              
                DichVu_Info dv = new DichVu_Info();
                dv.TenDichVu = grid_DV.ActiveRow.Cells["TenDichVu"].Value.ToString();
                frmHuyDichVu frm = new frmHuyDichVu(dv, dv_lk);
                frm.ShowDialog();
               grid_DV.DataSource= LoadDV(dv_lk.MaLanKham.ToString());
            }
        }

        private void btn_KhamThem_Click(object sender, EventArgs e)
        {
            if (GridBenhNhan.ActiveRow != null)
            {
                BenhNhan_Info bn = new BenhNhan_Info();
                bn.DiaChi = txtDiaChi.Text;
                bn.DienThoai = txtDienThoai.Text;
                bn.GioiTinh = txtGT.Text == "Nam" ? true : false;
                bn.HoTen = txtHoTen.Text;
                bn.Tuoi = Convert.ToInt32(txtTuoi.Text);
                LanKham_Info lk = new LanKham_Info();
                lk.NgayKham = Convert.ToDateTime(txtNgayKham.Text);
                lk.SoBH = txtMaTheBHYT.Text;
                lk.SoKham = Convert.ToInt32(txtMaBenhAn.Text);
                lk.LanKhamID = Convert.ToInt32(GridBenhNhan.ActiveRow.Cells["LanKhamID"].Value);
                if (GridBenhNhan.ActiveRow.Cells["BacSiGuiID"].Value.ToString() == "")
                    lk.BacSiGuiID = 0;
                else
                    lk.BacSiGuiID = Convert.ToInt32(GridBenhNhan.ActiveRow.Cells["BacSiGuiID"].Value);
                DoiTuong_Info dt = new DoiTuong_Info();
                dt.TenDoiTuong = txtDoiTuong.Text;
                BacSi_Info bs = new BacSi_Info();
                bs.HoTen = GridBenhNhan.ActiveRow.Cells["HoTenBacSi"].Value.ToString();


                frmKhamThem f = new frmKhamThem(bn, lk, dt, bs);
                f.ShowDialog();
                grid_DV.DataSource = LoadDV(lk.LanKhamID.ToString());
            }
            
            else MessageBox.Show("Chọn bệnh nhân để khám thêm");

        }

      

        private void khámThêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            // In biên lai
            if (grid_DV.ActiveRow != null)
            {
                DataView v =((DataTable) grid_DV.DataSource).DefaultView;
                v.RowFilter = "DichVu_LanKhamID=" + grid_DV.ActiveRow.Cells["DichVu_LanKhamID"].Value.ToString();
                decimal t = ((Convert.ToDecimal(grid_DV.ActiveRow.Cells["SoLuong"].Value) - Convert.ToDecimal(grid_DV.ActiveRow.Cells["SoLuongHuy"].Value)) * Convert.ToDecimal(grid_DV.ActiveRow.Cells["DonGia"].Value));

                DataTable ds = (DataTable)grid_DV.DataSource;
                string[] ParamName = { "@NgayThu", "@HoVaTen", "@Tuoi", "@DiaChi", "@TenDoiTuong", "@SoTien", "@BangChu","@SoKham","@Phong" };
                object[] ParamValue ={Convert.ToDateTime(txtNgayKham.Value), txtHoTen.Text,txtTuoi.Value.ToString()
                ,txtDiaChi.Text,txtDoiTuong.Text,t,
                Util.FormHandler.txtVND(t),txtMaBenhAn.Text,grid_DV.ActiveRow.Cells["TenPhong"].Value.ToString() };
                frmReportMain report = new frmReportMain(11, v.ToTable(), ParamName, ParamValue);
                report.Show();
                grid_DV.DataSource = LoadDV(grid_DV.ActiveRow.Cells["LanKhamID"].Value.ToString());
            }
        }

        private void txtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            DataView dv = ((DataTable)GridBenhNhan.DataSource).DefaultView;
            if (ckb_TimTheoNgay.Checked && txtTuNgay.Value != null && txtDenNgay.Value != null)
            {
                DateTime TuNgay = new DateTime(txtTuNgay.DateTime.Year, txtTuNgay.DateTime.Month, txtTuNgay.DateTime.Day, 1, 00, 00);
                DateTime DenNgay = new DateTime(txtDenNgay.DateTime.Year, txtDenNgay.DateTime.Month, txtDenNgay.DateTime.Day, 23, 00, 00);

                dv.RowFilter = "NgayKham >= '" + TuNgay.ToString() + "' and NgayKham<='" + DenNgay.ToString() + "'";
                label_TongBN.Text = string.Format("{0:00} Người", GridBenhNhan.Rows.Count);
            }
        }

        private void txtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            DataView dv = ((DataTable)GridBenhNhan.DataSource).DefaultView;
            if (ckb_TimTheoNgay.Checked && txtTuNgay.Value != null && txtDenNgay.Value != null)
            {
                DateTime TuNgay = new DateTime(txtTuNgay.DateTime.Year, txtTuNgay.DateTime.Month, txtTuNgay.DateTime.Day, 1, 00, 00);
                DateTime DenNgay = new DateTime(txtDenNgay.DateTime.Year, txtDenNgay.DateTime.Month, txtDenNgay.DateTime.Day, 23, 00, 00);

                dv.RowFilter = "NgayKham >= '" + TuNgay.ToString() + "' and NgayKham<='" + DenNgay.ToString() + "'";
                label_TongBN.Text = string.Format("{0:00} Người", GridBenhNhan.Rows.Count);
            }
        }

    

        
    }
}