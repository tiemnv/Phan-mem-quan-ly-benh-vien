using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Util;

namespace BUS
{

    public class TienNop_LanKham_Info
    {
        #region Attribute
        private System.Int32 _TienNop_LanKhamID;
        private System.Int32 _LanKhamID;
        private System.Decimal _ThucThu;
        private System.String _LyDoThu;
        #endregion

        #region Contructor
        public TienNop_LanKham_Info()
        {
            _TienNop_LanKhamID = 0;
            _LanKhamID = 0;
            _ThucThu = 0;
            _LyDoThu = String.Empty;
        }

        public TienNop_LanKham_Info(System.Int32 _TienNop_LanKhamID, System.Int32 _LanKhamID, System.Decimal _ThucThu, System.String _LyDoThu)
        {
            this._TienNop_LanKhamID = _TienNop_LanKhamID;
            this._LanKhamID = _LanKhamID;
            this._ThucThu = _ThucThu;
            this._LyDoThu = _LyDoThu;
        }
        #endregion

        #region propertiese
        public System.Int32 TienNop_LanKhamID
        {
            get { return _TienNop_LanKhamID; }
            set
            {
                _TienNop_LanKhamID = value;

            }
        }
        public System.Int32 LanKhamID
        {
            get { return _LanKhamID; }
            set
            {
                _LanKhamID = value;

            }
        }
        public System.Decimal ThucThu
        {
            get { return _ThucThu; }
            set
            {
                _ThucThu = value;

            }
        }
        public System.String LyDoThu
        {
            get { return _LyDoThu; }
            set
            {
                _LyDoThu = value;

            }
        }
        #endregion

        #region Method public
        public bool Insert()
        {
            object[] arrvalue = new object[6] {
                
                "@LanKhamID",_LanKhamID,
                "@ThucThu",_ThucThu,
                "@LyDoThu",_LyDoThu};
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCNONE2("TienNop_LanKham_Insert", "@TienNop_LanKhamID", System.Data.SqlDbType.Int, ref output1, arrvalue);
            TienNop_LanKhamID = Convert.ToInt32(output1);
            return k;
        }
        public bool Update()
        {
            object[] arrvalue = new object[8] {
                "@TienNop_LanKhamID",_TienNop_LanKhamID,
                "@LanKhamID",_LanKhamID,
                "@ThucThu",_ThucThu,
                "@LyDoThu",_LyDoThu};
            bool k = DB_SQL.EXECUTE_PROCE("TienNop_LanKham_Update", arrvalue);
            return k;
        }
        public bool Delete()
        {
            object[] arrvalue = new object[2] { "@TienNop_LanKhamID", _TienNop_LanKhamID };
            object output1 = null;
            bool k = DB_SQL.EXECUTE_PROCE("TienNop_LanKham_Delete", arrvalue);
            return k;
        }
        public static List<TienNop_LanKham_Info> SelectAllList()
        {
            List<TienNop_LanKham_Info> lstDonVi = new List<TienNop_LanKham_Info>();
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from TienNop_LanKham");
            foreach (DataRow r in b.Rows)
            {
                lstDonVi.Add((TienNop_LanKham_Info)Util.FormHandler.GetAs(r, typeof(TienNop_LanKham_Info)));
            }
            return lstDonVi;
        }
        public static DataTable SelectAllTable()
        {
            DataTable b = Util.DB_SQL.EXECUTE_SQL("Select * from TienNop_LanKham");
            return b;
        }
        #endregion
    }
}