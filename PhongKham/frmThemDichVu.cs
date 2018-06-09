using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;

namespace PhongKham
{
    public partial class frmThemDichVu : Form
    {
        public frmThemDichVu()
        {
            InitializeComponent();
        }
        DichVu_Info dv = new DichVu_Info();
        DichVu_LanKham_Info dv_lk = new DichVu_LanKham_Info();
        public frmThemDichVu(DichVu_Info dv, DichVu_LanKham_Info dv_lk)
        {
            this.dv = dv;
            this.dv_lk = dv_lk;
            InitializeComponent();
        }
        private void frmHuyDichVu_Load(object sender, EventArgs e)
        {
            txtTenDV.Text = dv.TenDichVu;
            txtDonGia.Text = dv_lk.DonGia.ToString();
            txtSoLuong.Text = dv_lk.SoLuong.ToString();
            txtSoLuongHuy.MaxValue = dv_lk.SoLuong;
            txtSoLuongHuy.MinValue = 0;
            txtSoLuongHuy.Select();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            dv_lk.SoLuongHuy = Convert.ToInt32(txtSoLuongHuy.Value);
            dv_lk.Update();
            this.Close();
        }
    }
}