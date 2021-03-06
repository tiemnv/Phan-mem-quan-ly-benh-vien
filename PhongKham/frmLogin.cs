using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using BUS;

namespace PhongKham
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim() == "")
            {
                txtTenDangNhap.Focus();
                errorProvider1.SetError(txtTenDangNhap, "loi");
                return;
            }
            else errorProvider1.Clear();
            if (txtMatKhau.Text.Trim() == "")
            {
                txtMatKhau.Focus();
                errorProvider1.SetError(txtMatKhau, "loi");
                return;
            }
            else errorProvider1.Clear();
            DataTable b = new DataTable();
            
            
            
            BacSi_Info _nv = new BacSi_Info();
            try
            {

                string TenDangNhap = txtTenDangNhap.Text.Trim();
                string MatKhau = txtMatKhau.Text.Trim();
                object[] arrvalue = new object[4] {"@TenDangNhap",TenDangNhap ,"@MatKhau", Util.ResetControl.Get_MD5(MatKhau)};

                b = DB_SQL.EXECUTE_PROC("BacSi_SelectByUser", arrvalue);
               
              
                
            }
            catch (Exception ae)
            {

                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai. Xin vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Select();
                return;
            }
            if (b == null) return;
            if (b.Rows.Count <= 0)
            {
                
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai. Xin vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Select();
                return;
            }
            else
            {
                _nv.TenDangNhap = b.Rows[0]["TenDangNhap"].ToString();
                _nv.BacSiID =Convert.ToInt32(b.Rows[0]["BacSiID"].ToString());
                _nv.QuyenHan = Convert.ToInt16(b.Rows[0]["QuyenHan"].ToString());
                _nv.HoTen = Convert.ToString(b.Rows[0]["HoTen"].ToString());
                _nv.NgaySinh = Convert.ToDateTime(b.Rows[0]["NgaySinh"].ToString());
                _nv.GioiTinh = Convert.ToBoolean(b.Rows[0]["GioiTinh"].ToString());
                _nv.DiaChi = Convert.ToString(b.Rows[0]["DiaChi"].ToString());
                _nv.DienThoai = Convert.ToString(b.Rows[0]["DienThoai"].ToString());
                CTGlobal.nv = _nv;
                
                FormMain frm = new FormMain(0);
                frm.Show();
                CTGlobal._Login = this;
                this.Hide();


            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenDangNhap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMatKhau_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnDangNhap.Focus();
            }
        }
    }
}