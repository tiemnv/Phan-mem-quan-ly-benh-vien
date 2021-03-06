using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Util;
using BUS;
using Infragistics.Win.UltraWinGrid;

namespace PhongKham
{
    public partial class frmBacSiGui : Form
    {
        public frmBacSiGui()
        {
            InitializeComponent();
        }
        
        void load()
        {

           gridDanhSach.DataSource = DB_SQL.EXECUTE_SQL(@"Select * from BacSi where TrangThai=2");
            
            Util.ResetControl.ReadOnly_Control(this);
            txtSearch.ReadOnly = false;
        }
        private void QuanTri_Load(object sender, EventArgs e)
        {
            load();
            
       
            Util.FormHandler.SetEnterKeyForAllControlsLevel(txtDiaChi.GetType(), this.Controls);
            Util.FormHandler.SetEnterKeyForAllControlsLevel(txtNgaySinh.GetType(), this.Controls);
            
            cbx_Sex.DataSource = ResetControl.getTable_forCombo(new string[] { "ID", "Name" }, new string[] { "True", "False" }, new string[] { "Nam", "Nữ" });
            cbx_Sex.ValueMember = "Name";
            cbx_Sex.DisplayMember = "ID";
            Util.ResetControl.SetEnterForUltraComboUltraTextBox(new UltraCombo[]{cbx_Sex},new TextBox[]{txtGioiTinh});
            Util.ResetControl.SetSourceForGridCustomCollumns(gridDanhSach, new string[] { "HoTen", "DiaChi" }, new string[] { "Họ tên", "Địa chỉ" });
        }
        private bool check()
        {
            ArrayList list = new ArrayList();
            list.Add(txtHoTen);
           
            
            list.Add(cbx_Sex);
           
            return Util.ResetControl.CheckValue(list, error);
        }
        private bool checkSua()
        {
            ArrayList list = new ArrayList();
            list.Add(txtHoTen);
        
            list.Add(cbx_Sex);
           
            return Util.ResetControl.CheckValue(list, error);
        }
        BacSiGui_Info nv = new BacSiGui_Info();
        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            if (check()|| checkSua() )
            {
                if (them == 1 && check())
                {

                    BacSiGui_Info nv = new BacSiGui_Info(1, txtHoTen.Text, txtNgaySinh.DateTime, Convert.ToBoolean(cbx_Sex.Text), txtDienThoai.Text
                               , txtDiaChi.Text, -1, 2,"");
                    if (nv.Insert())
                    {
                        Util.MESSAGE.MSG("Cập nhật thành công!");
                        Util.ResetControl.ReserAll(this);
                        them = 0;
                        load();
                    }
                    else
                    {
                        Util.MESSAGE.WARNING("Cập nhật không thành công!");
                    }
                }
                else if (them == 2&& checkSua())
                {
                    BacSiGui_Info nv = new BacSiGui_Info(1, txtHoTen.Text, txtNgaySinh.DateTime, Convert.ToBoolean(cbx_Sex.Text), txtDienThoai.Text
                              , txtDiaChi.Text,
                              -1, 2,"");
                    nv.BacSiID = Convert.ToInt32(gridDanhSach.ActiveRow.Cells["BacSiID"].Value.ToString());
                    if (nv.Update())
                    {
                        Util.MESSAGE.MSG("Cập nhật thành công!");
                        Util.ResetControl.ReserAll(this);
                        them = 0;
                        load();
                    }
                    else
                    {
                        Util.MESSAGE.WARNING("Cập nhật không thành công!");
                    }
                }

            }
        }
        int them = 0;
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            them = 1;
            Util.ResetControl.ReserAll(this);
            Util.ResetControl.Enable_Control(this);
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SuaMenuItem_Click(object sender, EventArgs e)
        {
            if (gridDanhSach.ActiveRow != null)
            {
                them = 2;
                Util.ResetControl.Enable_Control(this);
               
                txtHoTen.Focus();
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridDanhSach.ActiveRow != null)
            {
                if (Util.MESSAGE.QUESTION("Bạn có thật sự muốn xóa không?") == DialogResult.Yes)
                {
                    nv.BacSiID = Convert.ToInt32(gridDanhSach.ActiveRow.Cells["BacSiID"].Value.ToString());
                    nv.Delete();
                    load();
                }
            }
        }
       

        private void gridDanhSach_AfterRowActivate(object sender, EventArgs e)
        {
            txtDiaChi.Text = gridDanhSach.ActiveRow.Cells["DiaChi"].Value.ToString();
            txtDienThoai.Text = gridDanhSach.ActiveRow.Cells["DienThoai"].Value.ToString();
            
            txtHoTen.Text = gridDanhSach.ActiveRow.Cells["HoTen"].Value.ToString();
            txtNgaySinh.Text = gridDanhSach.ActiveRow.Cells["NgaySinh"].Value.ToString();           
            cbx_Sex.Text = gridDanhSach.ActiveRow.Cells["GioiTinh"].Value.ToString();
           
           
            nv.BacSiID = Convert.ToInt32(gridDanhSach.ActiveRow.Cells["BacSiID"].Value.ToString());

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();            
        }

        private void txtNgaySinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNgaySinh.SelectAll();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView ds = ((DataTable)gridDanhSach.DataSource).DefaultView;
            ds.RowFilter = "HoTen like '%" + txtSearch.Text + "%'";
          
        }


        
    }
}