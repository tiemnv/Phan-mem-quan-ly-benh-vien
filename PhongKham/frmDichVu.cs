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

namespace PhongKham
{
    public partial class frmDichVu : Form
    {
        public frmDichVu()
        {
            InitializeComponent();
        }
        private void load()
        {
            gridDanhSach.DataSource = DichVu_Info.SelectAllTable();
           
            Util.FormHandler.SetSourceForGridCustomCollumns(gridDanhSach, new string[] {"MaDichVu","TenDichVu","DonViTinh","DonGia"}, new string[] {"Mã dịch vụ","Tên dịch vụ","Đơn vị tính","Đơn giá"  });
            Util.ResetControl.ReadOnly_Control(this);
            isInsert = 0;
        }
        int isInsert = 0;
        private void btn_moi_Click(object sender, EventArgs e)
        {
            Util.FormHandler.ResetTextAllControlsLevel(new Type[] { txtMaDV.GetType() }, this.Controls);
            Util.FormHandler.ResetTextAllControlsLevel(new Type[] { cbx_Phong.GetType() }, this.Controls);
            Util.ResetControl.Enable_Control(this);
            isInsert = 1;
            txtMaDV.Focus();
        }
        private bool check2()
        {
            if (isInsert==1)
            {
                DataTable b = DichVu_Info.SelectAllTable();
                foreach (DataRow r in b.Rows)
                {
                    if (r["MaDichVu"].ToString() == txtMaDV.Text)
                    {
                        error.SetError(txtMaDV, "Trùng mã");
                        txtMaDV.Select();
                        return false;
                    }
                } 
            }
            ArrayList list = new ArrayList();
            list.Add(txtMaDV);
            list.Add(cbx_Phong);
            list.Add(txtTenDV);
            list.Add(txtDonGia);
            return Util.ResetControl.CheckValue(list, error);
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            load();
            cbx_Phong.DataSource = Phong_Info.SelectAllTable();
            cbx_Phong.ValueMember = "TenPhong";
            cbx_Phong.DisplayMember = "PhongID";
            Util.FormHandler.SetEnterKeyForAllControlsLevel(txtMaDV.GetType(), this.Controls);
            Util.FormHandler.SetEnterKeyForAllControlsLevel(txtDonGia.GetType(), this.Controls);
            Util.ResetControl.SetEnterForUltraComboUltraTextBox(new UltraCombo[]{cbx_Phong},new TextBox[]{txtPhong});
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridDanhSach.ActiveRow != null)
            {
                isInsert = 2;
                Util.ResetControl.Enable_Control(this);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridDanhSach.ActiveRow != null)
            {
                if (MessageBox.Show("Bạn có muốn thực hiện thao tác này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DichVu_Info dv = new DichVu_Info();
                    dv.DichVuID = Convert.ToInt32(gridDanhSach.ActiveRow.Cells["DichVuID"].Value);
                    if (dv.Delete())
                    {
                        Util.MESSAGE.MSG("Thực hiện thao tác thành công!");
                        load();
                    }
                    else Util.MESSAGE.MSG("Thực hiện thao tác không thành công!");
                }
            }
        }

        private void btn_ghi_Click(object sender, EventArgs e)
        {
            if (check2())
            {
                if (isInsert == 1)
                {
                    DichVu_Info dv = new DichVu_Info(0, txtMaDV.Text, txtTenDV.Text, txtDVT.Text, Convert.ToDecimal(txtDonGia.Value), Convert.ToInt32(cbx_Phong.Text));
                    if (dv.Insert())
                    {
                        Util.MESSAGE.MSG("Thực hiện thao tác thành công!");
                        load();
                    }
                    else Util.MESSAGE.MSG("Thực hiện thao tác không thành công!");

                }
                else if (isInsert == 2)
                {
                    DichVu_Info dv = new DichVu_Info(Convert.ToInt32(gridDanhSach.ActiveRow.Cells["DichVuID"].Value), txtMaDV.Text, txtTenDV.Text, txtDVT.Text, Convert.ToDecimal(txtDonGia.Value), Convert.ToInt32(cbx_Phong.Text));
                    if (dv.Update())
                    {
                        Util.MESSAGE.MSG("Thực hiện thao tác thành công!");
                        load();
                    }
                    else Util.MESSAGE.MSG("Thực hiện thao tác không thành công!");
                }
                load();
            }
        }

        private void txtDonGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDonGia.Select();
            }
        }

        private void gridDanhSach_AfterRowActivate(object sender, EventArgs e)
        {
            txtDonGia.Value = gridDanhSach.ActiveRow.Cells["DonGia"].Value.ToString();
            txtDVT.Text = gridDanhSach.ActiveRow.Cells["DonViTinh"].Value.ToString();
            txtMaDV.Text = gridDanhSach.ActiveRow.Cells["MaDichVu"].Value.ToString();
            
            txtTenDV.Text = gridDanhSach.ActiveRow.Cells["TenDichVu"].Value.ToString();
            cbx_Phong.Text = gridDanhSach.ActiveRow.Cells["PhongID"].Value.ToString();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}