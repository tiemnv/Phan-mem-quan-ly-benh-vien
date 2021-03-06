using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using System.Collections;

namespace PhongKham
{
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        private void load()
        {
            gridDanhSach.DataSource = Phong_Info.SelectAllTable();

            Util.FormHandler.SetSourceForGridCustomCollumns(gridDanhSach, new string[] { "TenPhong","DiaChi" }, new string[] {"Tên phòng","Địa chỉ"});
            Util.ResetControl.ReadOnly_Control(this);
            isInsert = 0;
        }
        int isInsert = 0;
        private void frmPhong_Load(object sender, EventArgs e)
        {
            load();
           
            Util.FormHandler.SetEnterKeyForAllControlsLevel(txtTenPhong.GetType(), this.Controls);
        }
        private bool check2()
        {
            ArrayList list = new ArrayList();
            list.Add(txtTenPhong);
         
            return Util.ResetControl.CheckValue(list, error);
        }
        private void btn_moi_Click(object sender, EventArgs e)
        {
            Util.FormHandler.ResetTextAllControlsLevel(new Type[] { txtTenPhong.GetType() }, this.Controls);

            Util.ResetControl.Enable_Control(this);
            isInsert = 1;
            txtTenPhong.Focus();
        }

        private void btn_ghi_Click(object sender, EventArgs e)
        {
            if (check2())
            {
                if (isInsert == 1)
                {
                    Phong_Info dv = new Phong_Info(0,txtTenPhong.Text,txtDiaChi.Text);
                    if (dv.Insert())
                    {
                        Util.MESSAGE.MSG("Thực hiện thao tác thành công!");
                        load();
                    }
                    else Util.MESSAGE.MSG("Thực hiện thao tác không thành công!");

                }
                else if (isInsert == 2)
                {
                    Phong_Info dv = new Phong_Info(Convert.ToInt32(gridDanhSach.ActiveRow.Cells["PhongID"].Value),txtTenPhong.Text,txtDiaChi.Text);
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

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    Phong_Info dv = new Phong_Info();
                    dv.PhongID = Convert.ToInt32(gridDanhSach.ActiveRow.Cells["PhongID"].Value);
                    if (dv.Delete())
                    {
                        Util.MESSAGE.MSG("Thực hiện thao tác thành công!");
                        load();
                    }
                    else Util.MESSAGE.MSG("Thực hiện thao tác không thành công!");
                }
            }
        }

        private void gridDanhSach_AfterRowActivate(object sender, EventArgs e)
        {
            txtDiaChi.Text = gridDanhSach.ActiveRow.Cells["DiaChi"].Value.ToString();
            txtTenPhong.Text = gridDanhSach.ActiveRow.Cells["TenPhong"].Value.ToString();
        }
    }
}