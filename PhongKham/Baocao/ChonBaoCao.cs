using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Util;
using BUS;
using System.Collections;

namespace GUI.BaoCao
{
    public partial class ChonBaoCao : Form
    {
        public ChonBaoCao()
        {
            InitializeComponent();
        }
        public static SqlConnection cn = DB_SQL.GET_CONNECT();
        private bool checkvalue(Control[] ct)
        {
            ArrayList ar = new ArrayList();
            for (int i = 0; i < ct.Length; i++)
            {
                ar.Add(ct[i]);
            }
            return Util.ResetControl.CheckValue(ar, errorProvider1);
        }
        private void btnBaocao_Click(object sender, EventArgs e)
        {
            DateTime TuNgay = new DateTime(dt_tungay.DateTime.Year, dt_tungay.DateTime.Month, dt_tungay.DateTime.Day, 1, 00, 00);
            DateTime DenNgay = new DateTime(dt_denngay.DateTime.Year, dt_denngay.DateTime.Month, dt_denngay.DateTime.Day, 23, 00, 00);
            switch (strChon)
            {

                case "1":
                    {
                        if (checkvalue(new Control[] { dt_tungay, dt_denngay }))
                        {
                            object[] para = new object[4] { "@TuNgay", TuNgay, "@DenNgay", DenNgay };
                            DataTable ds = DB_SQL.EXECUTE_PROC("rpt_BacSiGui", cn, para);
                            string[] ParamName = { "@TuNgay", "@DenNgay" };
                            object[] ParamValue ={ TuNgay, DenNgay };
                            frmReportMain report = new frmReportMain(1, ds, ParamName, ParamValue);
                            report.Show();
                        }
                            break;
                        
                    }
                case "2":
                    {
                        if (checkvalue(new Control[] { dt_tungay, dt_denngay }))
                        {
                            object[] para = new object[4] { "@TuNgay", TuNgay, "@DenNgay", DenNgay };
                            DataTable ds = DB_SQL.EXECUTE_PROC("rpt_ThongKeTheoPhong", cn, para);
                            string[] ParamName = { "@TuNgay", "@DenNgay" };
                            object[] ParamValue ={ TuNgay, DenNgay };
                            frmReportMain report = new frmReportMain(2, ds, ParamName, ParamValue);
                            report.Show();
                        }
                        break;
                    }
                case "3":
                    {
                        if (checkvalue(new Control[] {cbx_MaDoiTuong, dt_tungay, dt_denngay }))
                        {
                            object[] para = new object[6] { "@TuNgay", TuNgay, "@DenNgay", DenNgay, "@DoiTuongID", cbx_MaDoiTuong.Value.ToString() };
                            DataTable ds = DB_SQL.EXECUTE_PROC("rpt_TongDoanhThuTheoDoiTuong", cn, para);
                            string[] ParamName = { "@TuNgay", "@DenNgay", "@TenDoiTuong" };
                            object[] ParamValue ={ TuNgay, DenNgay, cbx_MaDoiTuong.Text };
                            frmReportMain report = new frmReportMain(3, ds, ParamName, ParamValue);
                            report.Show();
                        }
                        break;
                    }
                case "4":
                    {
                        if (checkvalue(new Control[] { dt_tungay, dt_denngay }))
                        {
                            object[] para = new object[4] { "@TuNgay", TuNgay, "@DenNgay", DenNgay };
                            DataTable ds = DB_SQL.EXECUTE_PROC("rpt_BacSiGuiChiTiet", cn, para);
                            string[] ParamName = { "@TuNgay", "@DenNgay" };
                            object[] ParamValue ={ TuNgay, DenNgay };
                            frmReportMain report = new frmReportMain(4, ds, ParamName, ParamValue);
                            report.Show();
                        }
                        break;
                    }
            }



            //dt_tungay.Value = DateTime.Now;
            //dt_denngay.Value = DateTime.Now;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string strChon = "";
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strChon = e.Node.Name.Trim();

        }

        private void ChonBaoCao_Load(object sender, EventArgs e)
        {
            cbx_MaDoiTuong.DataSource = DoiTuong_Info.SelectAllTable();
            cbx_MaDoiTuong.ValueMember = "DoiTuongID";
            cbx_MaDoiTuong.DisplayMember = "TenDoiTuong";
        }
    }
}