using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using CrystalDecisions.Shared;
using PhongKham.Baocao;


namespace GUI.BaoCao
{
    public partial class frmReportMain : Form
    {

        #region "Khai bao bien"
        private CrystalReportViewer rptView;
        private int _indexSelectReport;
        private string[] _paramName;
        private object[] _paramValue;
        private DataSet _dataSet;
        private DataTable _dataTable1;
        private DataTable _dataTable2;
        private DataTable _dataTable;
        private DateTime _from;
        private DateTime _to;
        private string _name;
        #endregion

        #region "Contructor"
        public frmReportMain()
        {
            InitializeComponent();
        }

        public frmReportMain(int IndexSelectReport, DateTime From, DateTime To)
        {
            _from = From;
            _to = To;
            _indexSelectReport = IndexSelectReport;
            InitializeComponent();
        }
        public frmReportMain(int IndexSelectReport, DataTable DT, string name)
        {
            _name = name;
            _dataTable = DT;
            _indexSelectReport = IndexSelectReport;
            InitializeComponent();
        }
        public frmReportMain(int IndexSelectReport, string[] ParamName, object[] ParamValue)
        {
            _indexSelectReport = IndexSelectReport;
            _paramName = ParamName;
            _paramValue = ParamValue;

            InitializeComponent();
        }
        public frmReportMain(int IndexSelectReport, DataTable DT, string[] ParamName, object[] ParamValue, string name)
        {
            _name = name;
            _dataTable = DT;
            _indexSelectReport = IndexSelectReport;
            _paramName = ParamName;
            _paramValue = ParamValue;

            InitializeComponent();
        }
        public frmReportMain(int IndexSelectReport, DataSet DS)
        {
            _dataSet = DS;
            _indexSelectReport = IndexSelectReport;
            InitializeComponent();
        }

        public frmReportMain(int IndexSelectReport, DataTable DT)
        {
            _dataTable = DT;
            _indexSelectReport = IndexSelectReport;
            InitializeComponent();
        }
        public frmReportMain(int IndexSelectReport, DataSet DS, string[] ParamName, object[] ParamValue)
        {
            _dataSet = DS;
            _indexSelectReport = IndexSelectReport;
            _paramName = ParamName;
            _paramValue = ParamValue;
            InitializeComponent();
        }
        public frmReportMain(int IndexSelectReport, DataTable DT, DataTable DT1, string[] ParamName, object[] ParamValue)
        {
            _dataTable = DT;
            _dataTable1 = DT1;
            _indexSelectReport = IndexSelectReport;
            _paramName = ParamName;
            _paramValue = ParamValue;
            InitializeComponent();
        }
        public frmReportMain(int IndexSelectReport, DataTable DT, DataTable DT1, DataTable DT2, string[] ParamName, object[] ParamValue)
        {
            _dataTable = DT;
            _dataTable1 = DT1;
            _dataTable2 = DT2;
            _indexSelectReport = IndexSelectReport;
            _paramName = ParamName;
            _paramValue = ParamValue;
            InitializeComponent();
        }



        public frmReportMain(int IndexSelectReport, DataTable DT, string[] ParamName, object[] ParamValue)
        {
            _dataTable = DT;
            _indexSelectReport = IndexSelectReport;
            _paramName = ParamName;
            _paramValue = ParamValue;
            InitializeComponent();
        }
        #endregion

        private void frmReportMain_Load(object sender, EventArgs e)
        {
            try
            {
                switch (_indexSelectReport)
                {
                    case 1:
                        {

                             rpt_BacSiGui rpt= new rpt_BacSiGui();
                            DataTable dt = _dataTable;
                            rpt.SetDataSource(dt);
                            setParam(_paramName, _paramValue);
                            crystalReportViewer1.ReportSource = rpt;
                            break;
                        }
                    case 2:
                        {

                            rpt_ThongKeTheoPhong rpt = new rpt_ThongKeTheoPhong();
                            DataTable dt = _dataTable;
                           rpt.SetDataSource(dt);
                            setParam(_paramName, _paramValue);
                            crystalReportViewer1.ReportSource = rpt;
                            break;
                        }
                    case 3:
                        {

                            rpt_TongDoanhThuTheoDT rpt = new rpt_TongDoanhThuTheoDT();
                            DataTable dt = _dataTable;
                            rpt.SetDataSource(dt);
                            setParam(_paramName, _paramValue);
                            crystalReportViewer1.ReportSource = rpt;
                            break;
                        }
                    case 4:
                        {

                            rpt_BacSiGuiChiTiet rpt = new rpt_BacSiGuiChiTiet();
                            DataTable dt = _dataTable;
                            rpt.SetDataSource(dt);
                            setParam(_paramName, _paramValue);
                            crystalReportViewer1.ReportSource = rpt;
                            break;
                        }
                    case 10:
                        {

                            rpt_BienLaiThuTien rpt = new rpt_BienLaiThuTien();
                            DataTable dt = _dataTable;
                            rpt.SetDataSource(dt);
                            setParam(_paramName, _paramValue);
                            crystalReportViewer1.ReportSource = rpt;
                            break;
                        }
                    case 11:
                        {

                            rpt_BienLai rpt = new rpt_BienLai();
                            DataTable dt = _dataTable;
                            rpt.SetDataSource(dt);
                            setParam(_paramName, _paramValue);
                            crystalReportViewer1.ReportSource = rpt;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Báo cáo không thể hiển thị, xin kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region "Set login"
        private bool setParam(string[] paramName, object[] paramValue)
        {
            if (paramValue.Length == paramName.Length)
            {
                ParameterFields paramFields = new ParameterFields();
                for (int i = 0; i < paramValue.Length; i++)
                {
                    ParameterField prmter = new ParameterField();
                    prmter.Name = paramName[i];
                    ParameterDiscreteValue disParam = new ParameterDiscreteValue();
                    disParam.Value = paramValue[i];
                    prmter.CurrentValues.Add(disParam);
                    paramFields.Add(prmter);
                }
                crystalReportViewer1.ParameterFieldInfo = paramFields;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetDatabaseLogon(ReportDocument rd)
        {
            string connectionString = "server=tungnk;database=atula_database;uid=sa;pwd=sa;";
            string user = "sa";
            string password = "sa";
            string server = "tungnk";
            string database = "atula_database";

            connectionString = ConfigurationSettings.AppSettings["connec"].ToString();

            if (null != connectionString && connectionString.Length > 0)
            {
                string[] item = connectionString.Split(';');
                foreach (string s in item)
                {
                    string[] nameValue = s.Split('=');
                    if (nameValue.Length == 2)
                    {
                        string name = nameValue[0].ToLower();
                        string value = nameValue[1];
                        switch (name)
                        {
                            case "server":
                            case "data source":
                                server = value;
                                break;
                            case "database":
                            case "initial catalog":
                                database = value;
                                break;
                            case "uid":
                            case "user id":
                                user = value;
                                break;
                            case "pwd":
                                password = value;
                                break;
                            case "password":
                                password = value;
                                break;
                        }
                    }
                }
            }
            rd.SetDatabaseLogon(user, password, server, database);
            LogOn(rd, server, database, user, password);
        }

        private void LogOn(ReportDocument crReportDocument, string server, string database, string user, string password)
        {
            Database crDatabase;
            Tables crTables;
            Table crTable;
            TableLogOnInfo crTableLogOnInfo;
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            crConnectionInfo.ServerName = server;
            crConnectionInfo.DatabaseName = database;
            crConnectionInfo.UserID = user;
            crConnectionInfo.Password = password;

            // This code works for both user tables and stored
            //procedures

            //Get the table information from the report
            crDatabase = crReportDocument.Database;
            crTables = crDatabase.Tables;

            //Loop through all tables in the report and apply the
            //connection information for each table.
            for (int i = 0; i < crTables.Count; i++)
            {
                crTable = crTables[i];
                crTableLogOnInfo = crTable.LogOnInfo;
                crTableLogOnInfo.ConnectionInfo =
                    crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogOnInfo);
            }
        }

        private void frmReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.P))
            {
                PrintDialog frm = new PrintDialog();
                frm.ShowDialog();
            }
        }
        #endregion

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
