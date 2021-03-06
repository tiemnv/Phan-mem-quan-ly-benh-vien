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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        public DoiMatKhau(BacSi_Info nv)
        {
            this.nv = nv;
            InitializeComponent();
        }
        BacSi_Info nv = new BacSi_Info();
        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = nv.TenDangNhap;
        }
       
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                nv.MatKhau = Util.ResetControl.Get_MD5(txtNewPass.Text);
                nv.DoiMatKhau();
                MessageBox.Show("Cập nhật thành công", "thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thành công", "thông báo", MessageBoxButtons.OK);

            }
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = nv.TenDangNhap;
            txtNewPass.Text = "";
            txtConfirmPass.Text = "";
        }
    }
}