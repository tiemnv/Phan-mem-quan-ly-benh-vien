using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Util;

namespace BUS
{

    public class BacSiGui_Info
    {
        #region Attribute
        private System.Int32 _BacSiID;
        private System.String _HoTen;
        private System.DateTime _NgaySinh;
        private System.Boolean _GioiTinh;
        private System.String _DienThoai;
        private System.String _DiaChi;
       
        private System.Int32 _QuyenHan;
        private System.Int32 _TrangThai;
        private System.String _GhiChu;
        #endregion

        #region Contructor
        public BacSiGui_Info()
        {
            _BacSiID = 0;
            _HoTen = String.Empty;
            _NgaySinh = DateTime.MinValue;
            _GioiTinh = false;
            _DienThoai = String.Empty;
            _DiaChi = String.Empty;
            
            
            _QuyenHan = 0;
            _TrangThai = 0;
            _GhiChu = String.Empty;
        }

        public BacSiGui_Info(System.Int32 _BacSiID, System.String _HoTen, System.DateTime _NgaySinh, System.Boolean _GioiTinh, System.String _DienThoai, System.String _DiaChi, System.Int32 _QuyenHan, System.Int32 _TrangThai, System.String _GhiChu)
        {
            this._BacSiID = _BacSiID;
            this._HoTen = _HoTen;
            this._NgaySinh = _NgaySinh;
            this._GioiTinh = _GioiTinh;
            this._DienThoai = _DienThoai;
            this._DiaChi = _DiaChi;
           
            this._QuyenHan = _QuyenHan;
            this._TrangThai = _TrangThai;
            this._GhiChu = _GhiChu;
        }
        #endregion

        #region propertiese
        public System.Int32 BacSiID
        {
            get { return _BacSiID; }
            set
            {
                _BacSiID = value;

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
        public System.String DienThoai
        {
            get { return _DienThoai; }
            set
            {
                _DienThoai = value;

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
       
        public System.Int32 QuyenHan
        {
            get { return _QuyenHan; }
            set
            {
                _QuyenHan = value;

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
        public System.String GhiChu
        {
            get { return _GhiChu; }
            set
            {
                _GhiChu = value;

            }
        }
        #endregion

        #region Method public
        public bool Insert()
        {
            object[] arrvalue = new object[16] {
                
                "@HoTen",_HoTen,
                "@NgaySinh",_NgaySinh,
                "@GioiTinh",_GioiTinh,
                "@DienThoai",_DienThoai,
                "@DiaChi",_DiaChi,
               
                "@QuyenHan",_QuyenHan,
                "@TrangThai",_TrangThai,
                "@GhiChu",_GhiChu};
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCNONE2("BacSi_Insert2", "@BacSiID", System.Data.SqlDbType.Int, ref output1, arrvalue);
            BacSiID = Convert.ToInt32(output1);
            return k;
        }
        public bool Update()
        {
            object[] arrvalue = new object[18] {
                "@BacSiID",_BacSiID,
                "@HoTen",_HoTen,
                "@NgaySinh",_NgaySinh,
                "@GioiTinh",_GioiTinh,
                "@DienThoai",_DienThoai,
                "@DiaChi",_DiaChi,
               
                "@QuyenHan",_QuyenHan,
                "@TrangThai",_TrangThai,
                "@GhiChu",_GhiChu};
            bool k = DB_SQL.EXECUTE_PROCE("BacSi_Update2", arrvalue);
            return k;
        }
        public bool Delete()
        {
            object[] arrvalue = new object[2] { "@BacSiID", _BacSiID };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCE("BacSi_Delete", arrvalue);
            return k;
        }
        public static List<BacSiGui_Info> SelectAllList()
        {
            List<BacSiGui_Info> lstDonVi = new List<BacSiGui_Info>();
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from BacSi order by HoTen ");
            foreach (DataRow r in b.Rows)
            {
                lstDonVi.Add((BacSiGui_Info)Util.FormHandler.GetAs(r, typeof(BacSiGui_Info)));
            }
            return lstDonVi;
        }
        public static DataTable SelectAllTable()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from BacSi order by HoTen ");
            return b;
        }
        
        #endregion
    }
}