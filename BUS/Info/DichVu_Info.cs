using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Util;

namespace BUS
{

    public class DichVu_Info
    {
        #region Attribute
        private System.Int32 _DichVuID;
        private System.String _MaDichVu;
        private System.String _TenDichVu;
        private System.String _DonViTinh;
        private System.Decimal _DonGia;
        private System.Int32 _PhongID;
        #endregion

        #region Contructor
        public DichVu_Info()
        {
            _DichVuID = 0;
            _MaDichVu = String.Empty;
            _TenDichVu = String.Empty;
            _DonViTinh = String.Empty;
            _DonGia = 0;
            _PhongID = 0;
        }

        public DichVu_Info(System.Int32 _DichVuID, System.String _MaDichVu, System.String _TenDichVu, System.String _DonViTinh, System.Decimal _DonGia, System.Int32 _PhongID)
        {
            this._DichVuID = _DichVuID;
            this._MaDichVu = _MaDichVu;
            this._TenDichVu = _TenDichVu;
            this._DonViTinh = _DonViTinh;
            this._DonGia = _DonGia;
            this._PhongID = _PhongID;
        }
        #endregion

        #region propertiese
        public System.Int32 DichVuID
        {
            get { return _DichVuID; }
            set
            {
                _DichVuID = value;

            }
        }
        public System.String MaDichVu
        {
            get { return _MaDichVu; }
            set
            {
                _MaDichVu = value;

            }
        }
        public System.String TenDichVu
        {
            get { return _TenDichVu; }
            set
            {
                _TenDichVu = value;

            }
        }
        public System.String DonViTinh
        {
            get { return _DonViTinh; }
            set
            {
                _DonViTinh = value;

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
        public System.Int32 PhongID
        {
            get { return _PhongID; }
            set
            {
                _PhongID = value;

            }
        }
        #endregion

        #region Method public
        public bool Insert()
        {
            object[] arrvalue = new object[10] {
               
                "@MaDichVu",_MaDichVu,
                "@TenDichVu",_TenDichVu,
                "@DonViTinh",_DonViTinh,
                "@DonGia",_DonGia,
                "@PhongID",_PhongID};
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCNONE2("DichVu_Insert", "@DichVuID", System.Data.SqlDbType.Int, ref output1, arrvalue);
            DichVuID = Convert.ToInt32(output1);
            return k;
        }
        public bool Update()
        {
            object[] arrvalue = new object[12] {
                "@DichVuID",_DichVuID,
                "@MaDichVu",_MaDichVu,
                "@TenDichVu",_TenDichVu,
                "@DonViTinh",_DonViTinh,
                "@DonGia",_DonGia,
                "@PhongID",_PhongID};
            bool k = DB_SQL.EXECUTE_PROCE("DichVu_Update", arrvalue);
            return k;
        }
        public bool Delete()
        {
            object[] arrvalue = new object[2] { "@DichVuID", _DichVuID };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCE("DichVu_Delete", arrvalue);
            return k;
        }
        public static List<DichVu_Info> SelectAllList()
        {
            List<DichVu_Info> lstDonVi = new List<DichVu_Info>();
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from DichVu order by TenDichVu ");
            foreach (DataRow r in b.Rows)
            {
                lstDonVi.Add((DichVu_Info)Util.FormHandler.GetAs(r, typeof(DichVu_Info)));
            }
            return lstDonVi;
        }
        public static DataTable SelectAllTable()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL(@"Select DichVu.*,0 as SoLuong,0 as SoLuongHuy,phong.TenPhong ,0 as BacSiGuiID from DichVu inner join
                                                    Phong on phong.phongid=dichvu.phongid order by TenDichVu ");
            return b;
        }
        #endregion
    }
}