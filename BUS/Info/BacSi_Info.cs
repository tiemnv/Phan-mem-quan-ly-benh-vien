using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Util;

namespace BUS
{

    public class BacSi_Info
    {
        #region Attribute
        private System.Int32 _BacSiID;
        private System.String _HoTen;
        private System.DateTime _NgaySinh;
        private System.Boolean _GioiTinh;
        private System.String _DienThoai;
        private System.String _DiaChi;
        private System.String _TenDangNhap;
        private byte[] _MatKhau;
        private System.Int32 _QuyenHan;
        private System.Int32 _TrangThai;
        private System.String _GhiChu;
        #endregion

        #region Contructor
        public BacSi_Info()
        {
            _BacSiID = 0;
            _HoTen = String.Empty;
            _NgaySinh = DateTime.MinValue;
            _GioiTinh = false;
            _DienThoai = String.Empty;
            _DiaChi = String.Empty;
            _TenDangNhap = String.Empty;
            
            _QuyenHan = 0;
            _TrangThai = 0;
            _GhiChu = String.Empty;
        }

        public BacSi_Info(System.Int32 _BacSiID, System.String _HoTen, System.DateTime _NgaySinh, System.Boolean _GioiTinh, System.String _DienThoai, System.String _DiaChi, System.String _TenDangNhap, byte[] _MatKhau, System.Int32 _QuyenHan, System.Int32 _TrangThai, System.String _GhiChu)
        {
            this._BacSiID = _BacSiID;
            this._HoTen = _HoTen;
            this._NgaySinh = _NgaySinh;
            this._GioiTinh = _GioiTinh;
            this._DienThoai = _DienThoai;
            this._DiaChi = _DiaChi;
            this._TenDangNhap = _TenDangNhap;
            this._MatKhau = _MatKhau;
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
        public System.String TenDangNhap
        {
            get { return _TenDangNhap; }
            set
            {
                _TenDangNhap = value;

            }
        }
        public byte[] MatKhau
        {
            get { return _MatKhau; }
            set
            {
                _MatKhau = value;

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
            object[] arrvalue = new object[20] {
                
                "@HoTen",_HoTen,
                "@NgaySinh",_NgaySinh,
                "@GioiTinh",_GioiTinh,
                "@DienThoai",_DienThoai,
                "@DiaChi",_DiaChi,
                "@TenDangNhap",_TenDangNhap,
                "@MatKhau",_MatKhau,
                "@QuyenHan",_QuyenHan,
                "@TrangThai",_TrangThai,
                "@GhiChu",_GhiChu};
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCNONE2("BacSi_Insert", "@BacSiID", System.Data.SqlDbType.Int, ref output1, arrvalue);
            BacSiID = Convert.ToInt32(output1);
            return k;
        }
        public bool Update()
        {
            object[] arrvalue = new object[22] {
                "@BacSiID",_BacSiID,
                "@HoTen",_HoTen,
                "@NgaySinh",_NgaySinh,
                "@GioiTinh",_GioiTinh,
                "@DienThoai",_DienThoai,
                "@DiaChi",_DiaChi,
                "@TenDangNhap",_TenDangNhap,
                "@MatKhau",_MatKhau,
                "@QuyenHan",_QuyenHan,
                "@TrangThai",_TrangThai,
                "@GhiChu",_GhiChu};
            bool k = DB_SQL.EXECUTE_PROCE("BacSi_Update", arrvalue);
            return k;
        }
        public bool Delete()
        {
            object[] arrvalue = new object[2] { "@BacSiID", _BacSiID };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCE("BacSi_Delete", arrvalue);
            return k;
        }
        public static List<BacSi_Info> SelectAllList()
        {
            List<BacSi_Info> lstDonVi = new List<BacSi_Info>();
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from BacSi order by HoTen ");
            foreach (DataRow r in b.Rows)
            {
                lstDonVi.Add((BacSi_Info)Util.FormHandler.GetAs(r, typeof(BacSi_Info)));
            }
            return lstDonVi;
        }
        public static DataTable SelectAllTable()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from BacSi Where TrangThai=1 order by HoTen ");
            return b;
        }
        public static DataTable SelectAllTable2()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from BacSi Where TrangThai=2 order by HoTen ");
            return b;
        }
        public static DataTable SelectAllTableCustemer()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select BacSiID,HoTen,DiaChi from BacSi Where TrangThai=2 order by HoTen ");
            return b;
        }
        public bool DoiMatKhau()
        {
            object[] arrvalue = new object[4] {
            
            "@BacSiID",_BacSiID ,
           "@MatKhau",_MatKhau 
           };

            bool k = DB_SQL.EXECUTE_PROCE("BacSi_DoiMatKhau", arrvalue);
            return k;

        }
        #endregion
    }
}