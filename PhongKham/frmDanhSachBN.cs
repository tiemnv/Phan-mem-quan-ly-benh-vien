using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhongKham
{
    public partial class frmDanhSachBN : Form
    {
        public frmDanhSachBN()
        {
            InitializeComponent();
        }
        DataTable tb = new DataTable();
        BindingSource binding;
        private void load()
        {
            tb = Util.DB_SQL.EXECUTE_SQL(@"SELECT ROW_NUMBER() OVER(ORDER BY LanKham.LanKhamID DESC) AS STT, 
dbo.BenhNhan.Ma as BenhNhanID,Hoten,diachi,
dienthoai,tuoi,ngaysinh,gioitinh, 
                      dbo.LanKham.SoBH, dbo.LanKham.ChuanDoan, dbo.LanKham.NgayKham, dbo.LanKham.GioKham, dbo.LanKham.SoKham, 
                      dbo.DoiTuong.TenDoiTuong
                      FROM    dbo.BenhNhan INNER JOIN
                      dbo.LanKham ON dbo.BenhNhan.Ma = dbo.LanKham.MaBenhNhan INNER JOIN
                      dbo.DoiTuong ON dbo.LanKham.DoiTuongID = dbo.DoiTuong.DoiTuongID");
            binding = new BindingSource();
            binding.DataSource = tb;
            GridBenhNhan.DataSource = binding;
            label_TongBN.Text = string.Format("{0:00} Người", binding.Count);
        }
        private void frmDanhSachBN_Load(object sender, EventArgs e)
        {
            load();


            //Util.ResetControl.SetSourceForGridCustomCollumns2(GridBenhNhan, new string[] { "STT", "HoTen", "DiaChi", "NgaySinh", "SoKham", "TenDoiTuong", "NgayKham" }, new string[] { "STT", "Họ tên", "Địa chỉ", "Ngày sinh", "Số khám", "Đối tượng", "Ngày khám" });
        }

        private void txtseachHoTen_TextChanged(object sender, EventArgs e)
        {
            DataView dv = ((DataTable)binding.DataSource).DefaultView;
            dv.RowFilter = "HoTen like '%" + txtseachHoTen.Text + "%'";
        }

        private void btn_napLai_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            DataView dv = ((DataTable)binding.DataSource).DefaultView;
            if (ckb_TimTheoNgay.Checked && txtTuNgay.Value != null && txtDenNgay.Value != null)
            {
                DateTime TuNgay = new DateTime(txtTuNgay.DateTime.Year, txtTuNgay.DateTime.Month, txtTuNgay.DateTime.Day, 1, 00, 00);
                DateTime DenNgay = new DateTime(txtDenNgay.DateTime.Year, txtDenNgay.DateTime.Month, txtDenNgay.DateTime.Day, 23, 00, 00);

                dv.RowFilter = "NgayKham >= '" + TuNgay.ToString() + "' and NgayKham<='" + DenNgay.ToString() + "'";
                label_TongBN.Text = string.Format("{0:00} Người", binding.Count);
            }
        }

        private void txtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            DataView dv = ((DataTable)binding.DataSource).DefaultView;
            if (ckb_TimTheoNgay.Checked && txtTuNgay.Value != null && txtDenNgay.Value != null)
            {
                DateTime TuNgay = new DateTime(txtTuNgay.DateTime.Year, txtTuNgay.DateTime.Month, txtTuNgay.DateTime.Day, 1, 00, 00);
                DateTime DenNgay = new DateTime(txtDenNgay.DateTime.Year, txtDenNgay.DateTime.Month, txtDenNgay.DateTime.Day, 23, 00, 00);

                dv.RowFilter = "NgayKham >= '" + TuNgay.ToString() + "' and NgayKham<='" + DenNgay.ToString() + "'";
                label_TongBN.Text = string.Format("{0:00} Người", binding.Count);
            }
        }
    }
}