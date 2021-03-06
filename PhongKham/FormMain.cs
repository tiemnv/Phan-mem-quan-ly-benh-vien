using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GUI.BaoCao;

namespace PhongKham
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private int Flag = 0;
        public FormMain(int _Flag)
        {
            this.Flag = _Flag;
            InitializeComponent();

        }
        public void active(string key, Form f1)
        {
            if (ultraTabbedMdiManager1.TabFromKey(key) != null)
            {
                ultraTabbedMdiManager1.TabFromKey(key).Activate();
                return;
            }
            f1.MdiParent = this;
            f1.Show();
            int index = ultraTabbedMdiManager1.TabGroups[0].Tabs.Count;
            ultraTabbedMdiManager1.TabGroups[0].Tabs[index - 1].Key = key;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        string keyoks;
        private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            keyoks = e.Item.Key;
            switch (e.Item.Key)
            {
                case "dontiep": frmDonTiep f1 = new frmDonTiep(); active("dontiep", f1); break;

                case "quantri": QuanTri f2 = new QuanTri(); active("quantri", f2); break;
                case "benhnhandv": frmBenhNhan_DV f3 = new frmBenhNhan_DV(); active("benhnhandv", f3); break;
                case "danhsachbn": frmDanhSachBN f4 = new frmDanhSachBN(); active("danhsachbn", f4); break;
                case "baocao": ChonBaoCao f5 = new ChonBaoCao(); active("baocao", f5); break;
                case "dichvu": frmDichVu f6 = new frmDichVu(); active("dichvu", f6); break;
                case "phong": frmPhong f7 = new frmPhong(); active("phong", f7); break;
                case "bacsi": frmBacSiGui f8 = new frmBacSiGui(); active("bacsi", f8); break;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            QuanTri f11 = new QuanTri(); active("quantri", f11);
        }

        private void đăngNhậpLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {

           CTGlobal._Login.Show();
            this.Dispose();

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ultraDockManager1.DockAreas[0].ShowChildPanes();
        }

        private void đónTiếpBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonTiep f1 = new frmDonTiep(); active("dontiep", f1);
        }

        private void danhSáchBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachBN f4 = new frmDanhSachBN(); active("danhsachbn", f4);
        }

        private void danhSáchDịchVụCủaBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBenhNhan_DV f3 = new frmBenhNhan_DV(); active("benhnhandv", f3);
        }

        private void chọnBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChonBaoCao f5 = new ChonBaoCao(); active("baocao", f5);
        }

        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanTri f2 = new QuanTri(); active("quantri", f2);
        }

        private void danhMụcDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDichVu f6 = new frmDichVu(); active("dichvu", f6);
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhong f7 = new frmPhong(); active("phong", f7);
        }




    }
}