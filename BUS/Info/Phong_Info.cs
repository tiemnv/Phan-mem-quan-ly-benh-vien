using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Util;

namespace BUS
{

    public class Phong_Info
    {
        #region Attribute
        private System.Int32 _PhongID;
        private System.String _TenPhong;
        private System.String _DiaChi;
        #endregion

        #region Contructor
        public Phong_Info()
        {
            _PhongID = 0;
            _TenPhong = String.Empty;
            _DiaChi = String.Empty;
        }

        public Phong_Info(System.Int32 _PhongID, System.String _TenPhong, System.String _DiaChi)
        {
            this._PhongID = _PhongID;
            this._TenPhong = _TenPhong;
            this._DiaChi = _DiaChi;
        }
        #endregion

        #region propertiese
        public System.Int32 PhongID
        {
            get { return _PhongID; }
            set
            {
                _PhongID = value;

            }
        }
        public System.String TenPhong
        {
            get { return _TenPhong; }
            set
            {
                _TenPhong = value;

            }
        }
        public System.String DiaChi
        {
            get { return _DiaChi; }
            set
            {
                _DiaChi = value;

            }
        }
        #endregion

        #region Method public
        public bool Insert()
        {
            object[] arrvalue = new object[4] {
                
                "@TenPhong",_TenPhong,
                "@DiaChi",_DiaChi};
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCNONE2("Phong_Insert", "@PhongID", System.Data.SqlDbType.Int, ref output1, arrvalue);
            PhongID = Convert.ToInt32(output1);
            return k;
        }
        public bool Update()
        {
            object[] arrvalue = new object[6] {
                "@PhongID",_PhongID,
                "@TenPhong",_TenPhong,
                "@DiaChi",_DiaChi};
            bool k = DB_SQL.EXECUTE_PROCE("Phong_Update", arrvalue);
            return k;
        }
        public bool Delete()
        {
            object[] arrvalue = new object[2] { "@PhongID", _PhongID };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCE("Phong_Delete", arrvalue);
            return k;
        }
        public static List<Phong_Info> SelectAllList()
        {
            List<Phong_Info> lstDonVi = new List<Phong_Info>();
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from Phong");
            foreach (DataRow r in b.Rows)
            {
                lstDonVi.Add((Phong_Info)Util.FormHandler.GetAs(r, typeof(Phong_Info)));
            }
            return lstDonVi;
        }
        public static DataTable SelectAllTable()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from Phong");
            return b;
        }
        #endregion
    }
}