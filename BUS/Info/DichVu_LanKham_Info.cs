using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Util;
using System.Configuration;

namespace BUS
{

    public class DichVu_LanKham_Info
    {
        #region Attribute
        private System.Int32 _DichVu_LanKhamID;
        private System.Int32 _DichVuID;
        private System.String _MaLanKham;
        private System.Int32 _BacSiGuiID;
        private System.Int32 _SoLuong;
        private System.Decimal _DonGia;
        private System.Int32 _SoLuongHuy;
        private System.DateTime _NgayKe;
        private System.DateTime _NgayThucHien;
        private System.Int32 _TrangThai;
        private System.String _Ma;

        #endregion

        #region Contructor
        public DichVu_LanKham_Info()
        {
            _DichVu_LanKhamID = 0;
            _DichVuID = 0;
            _MaLanKham = String.Empty;
            _BacSiGuiID = 0;
            _SoLuong = 0;
            _DonGia = 0;
            _SoLuongHuy = 0;
            _NgayKe = DateTime.MinValue;
            _NgayThucHien = DateTime.MinValue;
            _TrangThai = 0;
            _Ma = String.Empty;
        }

        public DichVu_LanKham_Info(System.Int32 _DichVu_LanKhamID, System.Int32 _DichVuID, System.String _MaLanKham, System.Int32 _BacSiGuiID, System.Int32 _SoLuong, System.Decimal _DonGia, System.Int32 _SoLuongHuy, System.DateTime _NgayKe, System.DateTime _NgayThucHien, System.Int32 _TrangThai)
        {
            this._DichVu_LanKhamID = _DichVu_LanKhamID;
            this._DichVuID = _DichVuID;
            this._MaLanKham = _MaLanKham;
            this._BacSiGuiID = _BacSiGuiID;
            this._SoLuong = _SoLuong;
            this._DonGia = _DonGia;
            this._SoLuongHuy = _SoLuongHuy;
            this._NgayKe = _NgayKe;
            this._NgayThucHien = _NgayThucHien;
            this._TrangThai = _TrangThai;
        }
        #endregion

        #region propertiese
        public System.Int32 DichVu_LanKhamID
        {
            get { return _DichVu_LanKhamID; }
            set
            {
                _DichVu_LanKhamID = value;

            }
        }
        public System.Int32 DichVuID
        {
            get { return _DichVuID; }
            set
            {
                _DichVuID = value;

            }
        }
        public System.String MaLanKham
        {
            get { return _MaLanKham; }
            set
            {
                _MaLanKham = value;

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
        public System.Int32 BacSiGuiID
        {
            get { return _BacSiGuiID; }
            set
            {
                _BacSiGuiID = value;

            }
        }
        public System.Int32 SoLuong
        {
            get { return _SoLuong; }
            set
            {
                _SoLuong = value;

            }
        }
        public System.Decimal DonGia
        {
            get { return _DonGia; }
            set
            {
                _DonGia = value;

            }
        }
        public System.Int32 SoLuongHuy
        {
            get { return _SoLuongHuy; }
            set
            {
                _SoLuongHuy = value;

            }
        }
        public System.DateTime NgayKe
        {
            get { return _NgayKe; }
            set
            {
                _NgayKe = value;

            }
        }
        public System.DateTime NgayThucHien
        {
            get { return _NgayThucHien; }
            set
            {
                _NgayThucHien = value;

            }
        }
        public System.Int32 TrangThai
        {
            get { return _TrangThai; }
            set
            {
                _TrangThai = value;

            }
        }
        #endregion

        #region Method public
        public bool Insert()
        {
            object[] arrvalue = new object[] {
               
                "@DichVuID",_DichVuID,
                "@MaLanKham",_MaLanKham,
                "@BacSiGuiID",_BacSiGuiID,
                "@SoLuong",_SoLuong,
                "@DonGia",_DonGia,
                "@SoLuongHuy",_SoLuongHuy,
                "@NgayKe",_NgayKe,
                "@NgayThucHien",_NgayThucHien,
                "@TrangThai",_TrangThai,
                "@MaBV",ConfigurationSettings.AppSettings["MaBV"]};
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCNONE2("DichVu_LanKham_Insert", "@Ma", System.Data.SqlDbType.NVarChar, ref output1, arrvalue);
            Ma = Convert.ToString(output1);
            return k;
        }
        public bool Update()
        {
            object[] arrvalue = new object[20] {
                "@DichVu_LanKhamID",_DichVu_LanKhamID,
                "@DichVuID",_DichVuID,
                "@MaLanKham",_MaLanKham,
                "@BacSiGuiID",_BacSiGuiID,
                "@SoLuong",_SoLuong,
                "@DonGia",_DonGia,
                "@SoLuongHuy",_SoLuongHuy,
                "@NgayKe",_NgayKe,
                "@NgayThucHien",_NgayThucHien,
                "@TrangThai",_TrangThai};
            bool k = DB_SQL.EXECUTE_PROCE("DichVu_LanKham_Update", arrvalue);
            return k;
        }
        public bool Delete()
        {
            object[] arrvalue = new object[2] { "@DichVu_LanKhamID", _DichVu_LanKhamID };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCE("DichVu_LanKham_Delete", arrvalue);
            return k;
        }
        public static List<DichVu_LanKham_Info> SelectAllList()
        {
            List<DichVu_LanKham_Info> lstDonVi = new List<DichVu_LanKham_Info>();
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from DichVu_LanKham");
            foreach (DataRow r in b.Rows)
            {
                lstDonVi.Add((DichVu_LanKham_Info)Util.FormHandler.GetAs(r, typeof(DichVu_LanKham_Info)));
            }
            return lstDonVi;
        }
        public static DataTable SelectAllTable()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from DichVu_LanKham");
            return b;
        }
        #endregion
    }
}