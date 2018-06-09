using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Util;


namespace BUS
{

    public class DoiTuong_Info
    {
        #region Attribute
        private System.Int32 _DoiTuongID;
        private System.String _TenDoiTuong;
        #endregion

        #region Contructor
        public DoiTuong_Info()
        {
            _DoiTuongID = 0;
            _TenDoiTuong = String.Empty;
        }

        public DoiTuong_Info(System.Int32 _DoiTuongID, System.String _TenDoiTuong)
        {
            this._DoiTuongID = _DoiTuongID;
            this._TenDoiTuong = _TenDoiTuong;
        }
        #endregion

        #region propertiese
        public System.Int32 DoiTuongID
        {
            get { return _DoiTuongID; }
            set
            {
                _DoiTuongID = value;

            }
        }
        public System.String TenDoiTuong
        {
            get { return _TenDoiTuong; }
            set
            {
                _TenDoiTuong = value;

            }
        }
        #endregion

        #region Method public
        public bool Insert()
        {
            object[] arrvalue = new object[4] {
                "@DoiTuongID",_DoiTuongID,
                "@TenDoiTuong",_TenDoiTuong};
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCNONE2("DoiTuong_Insert", "@DoiTuongID", System.Data.SqlDbType.Int, ref output1, arrvalue);
            DoiTuongID = Convert.ToInt32(output1);
            return k;
        }
        public bool Update()
        {
            object[] arrvalue = new object[4] {
                "@DoiTuongID",_DoiTuongID,
                "@TenDoiTuong",_TenDoiTuong};
            bool k = DB_SQL.EXECUTE_PROCE("DoiTuong_Update", arrvalue);
            return k;
        }
        public bool Delete()
        {
            object[] arrvalue = new object[2] { "@DoiTuongID", _DoiTuongID };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCE("DoiTuong_Delete", arrvalue);
            return k;
        }
        public static List<DoiTuong_Info> SelectAllList()
        {
            List<DoiTuong_Info> lstDonVi = new List<DoiTuong_Info>();
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from DoiTuong");
            foreach (DataRow r in b.Rows)
            {
                lstDonVi.Add((DoiTuong_Info)Util.FormHandler.GetAs(r, typeof(DoiTuong_Info)));
            }
            return lstDonVi;
        }
        public static DataTable SelectAllTable()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from DoiTuong");
            return b;
        }
        #endregion
    }
}