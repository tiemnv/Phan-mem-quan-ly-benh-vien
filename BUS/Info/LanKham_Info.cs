using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Util;
using System.Configuration;

namespace BUS
{

    public class LanKham_Info
    {
        #region Attribute
        private System.Int32 _LanKhamID;
        private System.String _MaBenhNhan;
        private System.Int32 _BacSiGuiID;
        private System.Int32 _DoiTuongID;
        private System.String _SoBH;
        private System.String _ChuanDoan;
        private System.DateTime _NgayKham;
        private System.String _GioKham;
        private System.Int32 _SoKham;
        private System.String _Ma;
        #endregion

        #region Contructor
        public LanKham_Info()
        {
            _LanKhamID = 0;
            _MaBenhNhan = String.Empty; ;
            _BacSiGuiID = 0;
            _DoiTuongID = 0;
            _SoBH = String.Empty;
            _ChuanDoan = String.Empty;
            _NgayKham = DateTime.MinValue;
            _GioKham = String.Empty;
            _SoKham = 0;
            _Ma = String.Empty;
        }

        public LanKham_Info(System.Int32 _LanKhamID, System.String _MaBenhNhan, System.Int32 _BacSiGuiID, System.Int32 _DoiTuongID, System.String _SoBH, System.String _ChuanDoan, System.DateTime _NgayKham, System.String _GioKham, System.Int32 _SoKham)
        {
           
            this._LanKhamID = _LanKhamID;
            this._MaBenhNhan = _MaBenhNhan;
            this._BacSiGuiID = _BacSiGuiID;
            this._DoiTuongID = _DoiTuongID;
            this._SoBH = _SoBH;
            this._ChuanDoan = _ChuanDoan;
            this._NgayKham = _NgayKham;
            this._GioKham = _GioKham;
            this._SoKham = _SoKham;
           
        }
        #endregion

        #region propertiese
        public System.String Ma
        {
            get { return _Ma; }
            set
            {
                _Ma = value;

            }
        }
        public System.Int32 LanKhamID
        {
            get { return _LanKhamID; }
            set
            {
                _LanKhamID= value;

            }
        }
        public System.String MaBenhNhan
        {
            get { return _MaBenhNhan; }
            set
            {
                _MaBenhNhan = value;

            }
        }
        public System.Int32 BacSiGuiID
        {
            get { return _BacSiGuiID; }
            set
            {
                _BacSiGuiID = value;

            }
        }
        public System.Int32 DoiTuongID
        {
            get { return _DoiTuongID; }
            set
            {
                _DoiTuongID = value;

            }
        }
        public System.String SoBH
        {
            get { return _SoBH; }
            set
            {
                _SoBH = value;

            }
        }
        public System.String ChuanDoan
        {
            get { return _ChuanDoan; }
            set
            {
                _ChuanDoan = value;

            }
        }
        public System.DateTime NgayKham
        {
            get { return _NgayKham; }
            set
            {
                _NgayKham = value;

            }
        }
        public System.String GioKham
        {
            get { return _GioKham; }
            set
            {
                _GioKham = value;

            }
        }
        public System.Int32 SoKham
        {
            get { return _SoKham; }
            set
            {
                _SoKham = value;

            }
        }
        #endregion

        #region Method public
        public bool Insert()
        {
            object[] arrvalue = new object[] {
               
                "@MaBenhNhan",_MaBenhNhan,
                "@BacSiGuiID",_BacSiGuiID,
                "@DoiTuongID",_DoiTuongID,
                "@SoBH",_SoBH,
                "@ChuanDoan",_ChuanDoan,
                "@NgayKham",_NgayKham,
                "@GioKham",_GioKham,
                "@SoKham",_SoKham,
                "@MaBV",ConfigurationSettings.AppSettings["MaBV"]
                
            };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCNONE2("LanKham_Insert", "@Ma", System.Data.SqlDbType.NVarChar, ref output1, arrvalue);
            Ma = Convert.ToString(output1);
            return k;
        }
        public bool Update()
        {
            object[] arrvalue = new object[18] {
                "@LanKhamID",_LanKhamID,
                "@MaBenhNhan",_MaBenhNhan,
                "@BacSiGuiID",_BacSiGuiID,
                "@DoiTuongID",_DoiTuongID,
                "@SoBH",_SoBH,
                "@ChuanDoan",_ChuanDoan,
                "@NgayKham",_NgayKham,
                "@GioKham",_GioKham,
                "@SoKham",_SoKham};
            bool k = DB_SQL.EXECUTE_PROCE("LanKham_Update", arrvalue);
            return k;
        }
        public bool Delete()
        {
            object[] arrvalue = new object[2] { "@LanKhamID", _LanKhamID };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCE("LanKham_Delete", arrvalue);
            return k;
        }
        public static List<LanKham_Info> SelectAllList()
        {
            List<LanKham_Info> lstDonVi = new List<LanKham_Info>();
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from LanKham");
            foreach (DataRow r in b.Rows)
            {
                lstDonVi.Add((LanKham_Info)Util.FormHandler.GetAs(r, typeof(LanKham_Info)));
            }
            return lstDonVi;
        }
        public static DataTable SelectAllTable()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from LanKham");
            return b;
        }
        #endregion
    }
}