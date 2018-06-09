using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Util;
using System.Configuration;

namespace BUS
{

    public class BenhNhan_Info
    {
        #region Attribute
        private System.Int32 _BenhNhanID;
        private System.String _HoTen;
        private System.String _Ma;
        private System.String _DiaChi;
        private System.String _DienThoai;
        private System.Int32 _Tuoi;
        private System.DateTime _NgaySinh;
        private System.Boolean _GioiTinh;
        #endregion

        #region Contructor
        public BenhNhan_Info()
        {
            _BenhNhanID = 0;
            _HoTen = String.Empty;
            _DiaChi = String.Empty;
            _DienThoai = String.Empty;
            _Tuoi = 0;
            _NgaySinh = DateTime.MinValue;
            _GioiTinh = false;
        }

        public BenhNhan_Info(System.Int32 _BenhNhanID, System.String _HoTen, System.String _DiaChi, System.String _DienThoai, System.Int32 _Tuoi, System.DateTime _NgaySinh, System.Boolean _GioiTinh)
        {
            this._BenhNhanID = _BenhNhanID;
            this._HoTen = _HoTen;
            this._DiaChi = _DiaChi;
            this._DienThoai = _DienThoai;
            this._Tuoi = _Tuoi;
            this._NgaySinh = _NgaySinh;
            this._GioiTinh = _GioiTinh;
        }
        #endregion

        #region propertiese
        public System.Int32 BenhNhanID
        {
            get { return _BenhNhanID; }
            set
            {
                _BenhNhanID = value;

            }
        }
        public System.String Ma
        {
            get { return _Ma; }
            set
            {
                _Ma = value;

            }
        }
        public System.String HoTen
        {
            get { return _HoTen; }
            set
            {
                _HoTen = value;

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
        public System.String DienThoai
        {
            get { return _DienThoai; }
            set
            {
                _DienThoai = value;

            }
        }
        public System.Int32 Tuoi
        {
            get { return _Tuoi; }
            set
            {
                _Tuoi = value;

            }
        }
        public System.DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set
            {
                _NgaySinh = value;

            }
        }
        public System.Boolean GioiTinh
        {
            get { return _GioiTinh; }
            set
            {
                _GioiTinh = value;

            }
        }
        #endregion

        #region Method public
        public bool Insert()
        {
            object[] arrvalue = new object[] {
                
                "@HoTen",_HoTen,
                "@DiaChi",_DiaChi,
                "@DienThoai",_DienThoai,
                "@Tuoi",_Tuoi,
                "@NgaySinh",_NgaySinh,
                "@GioiTinh",_GioiTinh,
                "@MaBV",ConfigurationSettings.AppSettings["MaBV"]};
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCNONE2("BenhNhan_Insert", "@Ma", System.Data.SqlDbType.NVarChar, ref output1, arrvalue);
            Ma = Convert.ToString(output1);
            return k;
        }
        public bool Update()
        {
            object[] arrvalue = new object[14] {
                "@BenhNhanID",_BenhNhanID,
                "@HoTen",_HoTen,
                "@DiaChi",_DiaChi,
                "@DienThoai",_DienThoai,
                "@Tuoi",_Tuoi,
                "@NgaySinh",_NgaySinh,
                "@GioiTinh",_GioiTinh};
            bool k = DB_SQL.EXECUTE_PROCE("BenhNhan_Update", arrvalue);
            return k;
        }
        public bool Delete()
        {
            object[] arrvalue = new object[2] { "@BenhNhanID", _BenhNhanID };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCE("BenhNhan_Delete", arrvalue);
            return k;
        }
        public static List<BenhNhan_Info> SelectAllList()
        {
            List<BenhNhan_Info> lstDonVi = new List<BenhNhan_Info>();
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from BenhNhan");
            foreach (DataRow r in b.Rows)
            {
                lstDonVi.Add((BenhNhan_Info)Util.FormHandler.GetAs(r, typeof(BenhNhan_Info)));
            }
            return lstDonVi;
        }
        public static DataTable SelectAllTable()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from BenhNhan");
            return b;
        }
        #endregion
    }
}