using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
namespace Util
{
    /// <summary>
    /// Project : Framework xử lý các dữ liệu trong C#
    /// Author	: Mguyen Van Tiem - Email(maiantiem0511@gmail.com)
    /// Date	: 9-6-2008
    /// </summary>
    #region "Lớp kết nối và thực hiện các thao tác với CSDL SQL Server
    public class DB_SQL
    {
        //Khai báo chuỗi kết nối
        private static string STR_CN = ConfigurationSettings.AppSettings["ConnectionString"];
        //Khai báo biến tĩnh kết nối 
        public static SqlConnection CONNECT = new SqlConnection(STR_CN);
        //Thuộc tính lấy và gán chuỗi kết nối
        public static string STR_CONNECT
        {
            get { return STR_CN; }
            set { STR_CN = value; }
        }
        //Tạo phương thức tĩnh lấy biến kết nối với sql
        public static SqlConnection GET_CONNECT()
        {
            try
            {
                CONNECT = new SqlConnection();
                CONNECT.ConnectionString = STR_CONNECT;
                CONNECT.Open();

                return CONNECT;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }
        //Tạo phương thức tĩnh đóng kết nối
        public static void CLOSE_CONNECT()
        {
            CONNECT.Close();
        }
        //Tạo phương thức tĩnh thực thi câu sql và trả về 1 giá trị duy nhất
        public static object EXECUTE_SCALAR(string str_sql)
        {
            object result = null;
            try
            {
                SqlCommand cmd = new SqlCommand(str_sql, GET_CONNECT());
                cmd.CommandTimeout = 90000;
                result = cmd.ExecuteScalar();
                cmd.Dispose();
                CONNECT.Close();
                return result;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }
        public static object EXECUTE_SCALAR(string str_sql, SqlConnection conn)
        {
            object result = null;
            try
            {
                SqlCommand cmd = new SqlCommand(str_sql, conn);
                cmd.CommandTimeout = 90000;
                result = cmd.ExecuteScalar();
                cmd.Dispose();
                return result;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }
        public static object EXECUTE_SCALAR1(string str_sql, SqlConnection conn)
        {
            object result = null;
            try
            {
                SqlCommand cmd = new SqlCommand(str_sql, conn);
                cmd.CommandTimeout = 90000;
                result = cmd.ExecuteScalar();
                return result;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }
        //Tạo phương thức thực thi một thủ tục không tham số trong sql và trả về một datatable
        public static DataTable EXECUTE_PROC(string name_proc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = GET_CONNECT();
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_proc;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Dispose();
                CONNECT.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }

        public static DataTable EXECUTE_PROC(string name_proc, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_proc;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                cmd.Dispose();
                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }

        //Tạo phương thức thực thi một cau lenh sql không tham số trong sql và trả về một datatable
        public static DataTable EXECUTE_SQL(string name_sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = GET_CONNECT();
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_sql;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Dispose();
                CONNECT.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                //MESSAGE.ERR(ex.Message);
                return null;
            }
        }

        public static DataTable EXECUTE_SQL(string name_sql, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = name_sql;
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();

                return ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }
        public static bool EXECUTE_SQL_BOOL(string name_sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = GET_CONNECT();
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return false;
            }
        }
        public static DataTable EXECUTE_SQL1(string name_sql, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = name_sql;
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();
                conn.Close();
                return ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }
        //Tạo phương thức thực thi một cau lenh sql không tham số trong sql và trả về một dataset
        public static DataSet EXECUTEDATASET_SQL(string name_sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = GET_CONNECT();
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_sql;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();
                CONNECT.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }

        public static DataSet EXECUTEDATASET_SQL(string name_sql, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_sql;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();

                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }
        //Tạo phương thức thực thi một store không tham số trong sql và trả về một dataset
        public static DataSet EXECUTEDATASET_PROC(string name_store)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = GET_CONNECT();
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_store;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();
                CONNECT.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }

        public static DataSet EXECUTEDATASET_PROC(string name_store, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_store;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();

                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }
        //Tạo phương thức thực thi một store co tham số trong sql và trả về một dataset
        public static DataSet EXECUTEDATASET_PROC(string name_store, params object[] pars)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = GET_CONNECT();
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_store;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();
                CONNECT.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }

        public static DataSet EXECUTEDATASET_PROC(string name_store, SqlConnection conn, params object[] pars)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 90000;
                cmd.CommandText = name_store;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();

                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }
        public static DataSet EXECUTEDATASET_PROC(string name_store, SqlConnection conn, SqlTransaction trans, params object[] pars)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 90000;
                cmd.Transaction = trans;
                cmd.CommandText = name_store;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();

                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }
        }
        //Tạo phương thức thực thi một thủ tục có n tham số và trả về một datatable
        public static DataSet EXECUTE_SQL(string str_sql, params object[] pars)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(str_sql, GET_CONNECT());
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.Text;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();
                CONNECT.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }

        public static DataSet EXECUTE_SQL(string str_sql, SqlConnection conn, params object[] pars)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(str_sql, conn);
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.Text;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();

                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }
        //Tạo phương thức thực thi một thủ tục có n tham số và trả về một datatable
        public static DataTable EXECUTE_PROC(string name_proc, params object[] pars)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(name_proc, GET_CONNECT());
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();
                CONNECT.Close();
                return ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }

        public static DataTable EXECUTE_PROC(string name_proc, SqlTransaction tran, params object[] pars)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(name_proc, tran.Connection, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 90000;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();
                //CONNECT.Close();
                return ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }

        public static DataTable EXECUTE_PROC1(string name_proc, params object[] pars)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(name_proc, GET_CONNECT());
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                cmd.Dispose();
                CONNECT.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }
        public static bool EXECUTE_PROCE(string name_proc, params object[] pars)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(name_proc, GET_CONNECT());
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                CONNECT.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return false;
            }
            return true;

        }

        public static DataTable EXECUTE_PROC(string name_proc, SqlConnection conn, params object[] pars)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(name_proc, conn);
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Dispose();

                return ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }
        public static DataTable EXECUTE_PROCPhuong(string name_proc, params object[] pars)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(name_proc, GET_CONNECT());
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                cmd.Dispose();
                CONNECT.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }

        public static bool EXECUTE_PROC_TIEM(string name_proc, SqlConnection cn, SqlTransaction trans, string pars_output, SqlDbType SQLDbType_output, ref object out_put, params object[] pars)
        {
            if (pars_output != "")
            {
                SqlCommand cmd = new SqlCommand(name_proc, cn, trans);
                cmd.CommandTimeout = 90000;
                object result1;
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter par1 = new SqlParameter(pars_output, SQLDbType_output);
                    cmd.Parameters.Add(par1);
                    cmd.Parameters[pars_output].Direction = ParameterDirection.Output;

                    for (int i = 0; i < pars.Length; i += 2)
                    {
                        SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                        cmd.Parameters.Add(par);
                    }
                    cmd.ExecuteNonQuery();
                    result1 = cmd.Parameters[pars_output].Value;
                    out_put = result1;
                }
                catch (SqlException ex)
                {
                    MESSAGE.ERR(ex.Message);
                    return false;
                }
                finally
                {

                    cmd.Dispose();
                } return true;
            }
            else
            {
                SqlCommand cmd = new SqlCommand(name_proc, cn, trans);
                cmd.CommandTimeout = 90000;

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < pars.Length; i += 2)
                    {
                        SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                        cmd.Parameters.Add(par);
                    }
                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    MESSAGE.ERR(ex.Message);
                    return false;
                }
                finally
                {

                    cmd.Dispose();
                } return true;
            }


        }
        public static bool EXECUTE_PROC_TIEM2(string name_proc, SqlConnection cn, params object[] pars)
        {

            SqlCommand cmd = new SqlCommand(name_proc, cn);
            cmd.CommandTimeout = 90000;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {

                cmd.Dispose();
            } return true;
        }
        public static bool EXECUTE_PROCNONE(string name_proc, params object[] pars)
        {

            SqlCommand cmd = new SqlCommand(name_proc, GET_CONNECT());
            cmd.CommandTimeout = 90000;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {

                cmd.Dispose();
            } return true;
        }
        public static bool EXECUTE_PROCNONE2(string name_proc, string pars_output, SqlDbType SQLDbType_output, ref object out_put, params object[] pars)
        {

            SqlCommand cmd = new SqlCommand(name_proc, GET_CONNECT());
            cmd.CommandTimeout = 90000;
            object result1;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter(pars_output, SQLDbType_output,50);
                cmd.Parameters.Add(par1);
                cmd.Parameters[pars_output].Direction = ParameterDirection.Output;

                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par);
                }
                cmd.ExecuteNonQuery();
                result1 = cmd.Parameters[pars_output].Value;
                out_put = result1;
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return false;
            }
            finally
            {

                cmd.Dispose();
            }
            return true;



        }
        //Tạo phương thức thực thi một câu không trả về gì cả
        public static void EXECUTE_NONE(string STR_SQL)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(STR_SQL, GET_CONNECT());
                cmd.CommandTimeout = 90000;
                cmd.ExecuteNonQuery();
                DB_SQL.CLOSE_CONNECT();
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);

            }

        }

        public static void EXECUTE_NONE(string STR_SQL, SqlConnection conn)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(STR_SQL, conn);
                cmd.CommandTimeout = 90000;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);

            }

        }
        //Tạo phương thức thực thi một proc không trả về gì cả
        public static void EXECUTE_PROCNONE(string proc_name)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(proc_name, GET_CONNECT());
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                DB_SQL.CLOSE_CONNECT();
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
            }
        }

        public static void EXECUTE_PROCNONE(string proc_name, SqlConnection conn)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(proc_name, conn);
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
            }
        }
        //Tạo phương thức thực thi một thủ tục có n tham số đầu vào và 1 đầu ra
        public static object EXECUTE_PROC_OUTPUT_INPUT(string name_proc, string pars_output, SqlDbType SQLDbType_output, int size_para_output, params object[] pars)
        {
            object result;
            try
            {
                SqlCommand cmd = new SqlCommand(name_proc, GET_CONNECT());
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter(pars_output, SQLDbType_output, size_para_output);
                cmd.Parameters.Add(par);
                cmd.Parameters[pars_output].Direction = ParameterDirection.Output;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par1 = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par1);
                }
                cmd.ExecuteNonQuery();
                result = cmd.Parameters[pars_output].Value;
                cmd.Dispose();
                CONNECT.Close();
                return result;

            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }

        public static object EXECUTE_PROC_OUTPUT_INPUT(string name_proc, string pars_output, SqlDbType SQLDbType_output, int size_para_output, SqlConnection conn, params object[] pars)
        {
            object result;
            try
            {
                SqlCommand cmd = new SqlCommand(name_proc, conn);
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter(pars_output, SQLDbType_output, size_para_output);
                cmd.Parameters.Add(par);
                cmd.Parameters[pars_output].Direction = ParameterDirection.Output;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par1 = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par1);
                }
                cmd.ExecuteNonQuery();
                result = cmd.Parameters[pars_output].Value;
                cmd.Dispose();

                return result;

            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return null;
            }

        }
        //Tạo phương thức thực thi một thủ tục có n tham số đầu vào 
        public static void EXECUTE_PROC_INPUT(string name_proc, params object[] pars)
        {

            try
            {
                SqlCommand cmd = new SqlCommand(name_proc, GET_CONNECT());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 90000;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par1 = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par1);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                CONNECT.Close();
            }
            catch (SqlException ex)
            {
                //MESSAGE.ERR(ex.Message);               
            }

        }


        public static void EXECUTE_PROC_INPUT(string name_proc, SqlTransaction tran, params object[] pars)
        {

            try
            {
                SqlCommand cmd = new SqlCommand(name_proc, tran.Connection, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 90000;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par1 = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par1);
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //CONNECT.Close();
            }
            catch (SqlException ex)
            {
                //MESSAGE.ERR(ex.Message);               
            }

        }

        public static void EXECUTE_PROC_INPUT(string name_proc, SqlConnection conn, params object[] pars)
        {

            try
            {
                SqlCommand cmd = new SqlCommand(name_proc, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 90000;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par1 = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    cmd.Parameters.Add(par1);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

            }
            catch (SqlException ex)
            {
                //MESSAGE.ERR(ex.Message);               
            }

        }
        //Phương thức lấy giá trị của một trường trong bảng
        public static object GET_VALUE_FIELD(string field_name, string table_name, params object[] condition)
        {
            string STR_SQL;
            object result = null;
            STR_SQL = "select " + field_name + " from " + table_name + (condition.Length > 0 ? " where " + condition[0].ToString() : "");
            SqlCommand cmd = new SqlCommand(STR_SQL, GET_CONNECT());
            cmd.CommandTimeout = 90000;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = dr.GetValue(0);
                    break;
                }
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return result;
            }
            return result;
        }


        public static object GET_VALUE_FIELD(string field_name, string table_name, SqlConnection conn, params object[] condition)
        {
            string STR_SQL;
            object result = null;
            STR_SQL = "select " + field_name + " from " + table_name + (condition.Length > 0 ? " where " + condition[0].ToString() : "");
            SqlCommand cmd = new SqlCommand(STR_SQL, conn);
            cmd.CommandTimeout = 90000;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = dr.GetValue(0);
                    break;
                }
            }
            catch (SqlException ex)
            {
                MESSAGE.ERR(ex.Message);
                return result;
            }
            return result;
        }




    }
    #endregion
    #region "Lớp gắn kết dữ liệu lên các điều khiển
    public class DB_UTILITY
    {
        //Phương thức gắn kết dữ liệu vào combox thường
        public static void BIND_DATA_CBO_LIST(string STR_SQL, ComboBox cbo)
        {
            SqlCommand cmd = new SqlCommand(STR_SQL, DB_SQL.GET_CONNECT());
            cmd.CommandTimeout = 90000;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                cbo.Items.Clear();
                while (dr.Read())
                {
                    cbo.Items.Add(dr.GetValue(0).ToString());
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MESSAGE.ERR(ex.Message);
                cmd.Dispose();
            }
        }
        //Phương thức gắn kết dữ liệu vào combox thường
        public static void BIND_DATA_CBO_LIST(string STR_SQL, ListBox cbo)
        {
            SqlCommand cmd = new SqlCommand(STR_SQL, DB_SQL.GET_CONNECT());
            cmd.CommandTimeout = 90000;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                cbo.Items.Clear();
                while (dr.Read())
                {
                    cbo.Items.Add(dr.GetValue(0).ToString());
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MESSAGE.ERR(ex.Message);
                cmd.Dispose();
            }
        }
        //Phương thức gắn kết dữ liệu trong bảng vào một combobox
        public static void BIND_DATA_CBO_LIST(string STR_SQL, ComboBox cbo, string field_text, string field_value)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(STR_SQL, DB_SQL.STR_CONNECT);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cbo.DataSource = ds.Tables[0];
                cbo.ValueMember = ds.Tables[0].Columns[field_value].ColumnName;
                cbo.DisplayMember = ds.Tables[0].Columns[field_text].ColumnName;
                da.Dispose();
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MESSAGE.ERR(ex.Message);
            }
        }

        //Phương thức gắn kết dữ liệu trong thủ tục vào một listbox
        public static void BIND_DATA_CBO_LIST(string STR_SQL, ListBox lst, string field_text, string field_value)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(STR_SQL, DB_SQL.STR_CONNECT);
                DataSet ds = new DataSet();
                da.Fill(ds);
                lst.DataSource = ds.Tables[0];
                lst.ValueMember = ds.Tables[0].Columns[field_value].ColumnName;
                lst.DisplayMember = ds.Tables[0].Columns[field_text].ColumnName;
                da.Dispose();
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MESSAGE.ERR(ex.Message);
            }
        }
        //Phương thức gắn kết dữ liệu trong bảng vào một listbox
        public static void BIND_DATA_CBO_LIST(object name_proc, ListBox lst, string field_text, string field_value)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DB_SQL.GET_CONNECT();
                cmd.CommandTimeout = 90000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = name_proc.ToString();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp");
                lst.DataSource = ds.Tables["temp"];
                lst.ValueMember = "temp." + field_value;
                lst.DisplayMember = "temp." + field_text;
                cmd.Dispose();
                da.Dispose();
                ds.Dispose();
                DB_SQL.CLOSE_CONNECT();

            }
            catch (Exception ex)
            {
                MESSAGE.ERR(ex.Message);
            }
        }


        //Phương thức gắn kết dữ liệu trong thủ tục vào một datagrid
        public static void BIND_DATA_GRID(string STR_SQL, DataGrid dg)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(STR_SQL, DB_SQL.STR_CONNECT);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp");
                dg.DataSource = ds.Tables["temp"];
                da.Dispose();
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MESSAGE.ERR(ex.Message);
            }
        }
        //Phương thức gắn kết dữ liệu trong thủ tục có tham số vào một datagrid 
        public static void BIND_DATA_GRID(string name_proc, DataGrid dg, params object[] pars)
        {
            try
            {
                DataTable bang = DB_SQL.EXECUTE_PROC(name_proc.ToString(), pars);
                dg.DataSource = bang;
                bang.Dispose();
            }
            catch (Exception ex)
            {
                MESSAGE.ERR(ex.Message);
            }
        }
        //Phương thức gắn kết dữ liệu trong thủ tục vào một datagridview
        public static void BIND_DATA_GRID(string name_proc, DataGridView dg, params object[] pars)
        {
            try
            {
                DataTable bang = DB_SQL.EXECUTE_PROC(name_proc, pars);
                dg.DataSource = bang;
                bang.Dispose();
            }
            catch (Exception ex)
            {
                MESSAGE.ERR(ex.Message);
            }
        }
        //Phương thức gắn kết dữ liệu trong thủ tục có tham số vào một datagridview
        public static void BIND_DATA_GRID(string STR_SQL, DataGridView dg)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(STR_SQL, DB_SQL.STR_CONNECT);
                DataSet ds = new DataSet();
                da.Fill(ds, "temp");
                dg.DataSource = ds.Tables["temp"];
                da.Dispose();
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MESSAGE.ERR(ex.Message);
            }
        }
    }
    #endregion
    #region "Lớp xử lý thông báo lỗi
    public class MESSAGE
    {
        //Phương thức hiển thị thông báo lỗi
        public static void ERR(string msg)
        {
            MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Phương thức hiển thị cảnh báo
        public static void WARNING(string msg)
        {
            MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //Phương thức hiển thị hỏi đáp
        public static DialogResult QUESTION(string msg)
        {
            return MessageBox.Show(msg, "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        //Phương thức hiển thị hỏi đáp
        public static void MSG(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    #endregion
    #region"Lớp xử lý mã hóa dữ liệu - Mã nguồn tham khảo trên mạng
    public sealed class Cryption
    {
        //
        //members of the Cryption
        //algorithm type in my case it’s RijndaelManaged
        private RijndaelManaged Algorithm;
        //memory stream
        private MemoryStream memStream;
        //ICryptoTransform interface
        private ICryptoTransform EncryptorDecryptor;
        //CryptoStream
        private CryptoStream crStream;
        //Stream writer and Stream reader
        private StreamWriter strWriter;
        private StreamReader strReader;
        //internal members
        private string m_key;
        private string m_iv;
        //the Key and the Inicialization Vector
        private byte[] key;
        private byte[] iv;
        //password view
        private string pwd_str;
        private byte[] pwd_byte;
        //Constructor
        public Cryption(string key_val, string iv_val)
        {
            key = new byte[32];
            iv = new byte[32];

            int i;
            m_key = key_val;
            m_iv = iv_val;
            //key calculation, depends on first constructor parameter
            for (i = 0; i < m_key.Length; i++)
            {
                key[i] = Convert.ToByte(m_key[i]);
            }
            //IV calculation, depends on second constructor parameter
            for (i = 0; i < m_iv.Length; i++)
            {
                iv[i] = Convert.ToByte(m_iv[i]);
            }

        }
        //Encrypt method implementation
        public string Encrypt(string s)
        {
            //new instance of algorithm creation
            Algorithm = new RijndaelManaged();

            //setting algorithm bit size
            Algorithm.BlockSize = 256;
            Algorithm.KeySize = 256;

            //creating new instance of Memory stream
            memStream = new MemoryStream();

            //creating new instance of the Encryptor
            EncryptorDecryptor = Algorithm.CreateEncryptor(key, iv);

            //creating new instance of CryptoStream
            crStream = new CryptoStream(memStream, EncryptorDecryptor,
                CryptoStreamMode.Write);

            //creating new instance of Stream Writer
            strWriter = new StreamWriter(crStream);

            //cipher input string
            strWriter.Write(s);

            //clearing buffer for currnet writer and writing any 
            //buffered data to //the underlying device
            strWriter.Flush();
            crStream.FlushFinalBlock();

            //storing cipher string as byte array 
            pwd_byte = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(pwd_byte, 0, (int)pwd_byte.Length);

            //storing cipher string as Unicode string
            pwd_str = new UnicodeEncoding().GetString(pwd_byte);

            return pwd_str;
        }

        //Decrypt method implementation 
        public string Decrypt(string s)
        {
            //new instance of algorithm creation
            Algorithm = new RijndaelManaged();

            //setting algorithm bit size
            Algorithm.BlockSize = 256;
            Algorithm.KeySize = 256;

            //creating new Memory stream as stream for input string      
            MemoryStream memStream = new MemoryStream(
                new UnicodeEncoding().GetBytes(s));

            //Decryptor creating 
            ICryptoTransform EncryptorDecryptor =
                Algorithm.CreateDecryptor(key, iv);

            //setting memory stream position
            memStream.Position = 0;

            //creating new instance of Crupto stream
            CryptoStream crStream = new CryptoStream(
                memStream, EncryptorDecryptor, CryptoStreamMode.Read);

            //reading stream
            strReader = new StreamReader(crStream);

            //returnig decrypted string
            return strReader.ReadToEnd();
        }
    }
    #endregion
    #region "Lớp xử lý ngày tháng
    public class DATE_TIME
    {
        //Phương thức kiểm tra 1 chuỗi có đúng kiểu ngày tháng không
        public static bool CHECK_DATETIME(string datetime)
        {
            try
            {
                Convert.ToDateTime(datetime);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Phương thức chuyen 1 chuỗi dang dd/MM/yyyy hh:mm thành kiểu ngày tháng
        public static DateTime ConvertStringToDateTime(string datetime)
        {
            DateTime dt = new DateTime(Convert.ToInt32(datetime.Substring(6, 4)), Convert.ToInt32(datetime.Substring(3, 2)),
                Convert.ToInt32(datetime.Substring(0, 2)), Convert.ToInt32(datetime.Substring(11, 2)),
                Convert.ToInt32(datetime.Substring(14, 2)), 0);
            return dt;
        }
    }
    #endregion
    #region "Lớp xử lý chuỗi
    public class STRING
    {
        // size: độ dài của chuỗi ngẫu nhiên
        // lowerCase: nếu là true thì chuỗi ngẫu nhiên sẽ in hoa hết, ngược lại thì như bình thường
        public static string RAMDOM_STRING(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder();
            char ch;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(rand.Next(65, 97)));
                sb.Append(ch);
            }
            if (lowerCase)
                return sb.ToString().ToLower();
            return sb.ToString();
        }
        //Chuẩn hóa chuỗi họ tên
        public static string STANDARD_FULLNAME(string Str)
        {
            try
            {
                string strname, result = "";
                string strspecial = @"@/\}]{[_=+-.,;':""><)(*&^%$#!~`?|";
                if (Str == null)//nếu rỗng thì trả về null
                    return null;
                foreach (char ch in strspecial)
                {
                    Str = Str.Replace(ch, ' ');
                }
                strname = Str.Trim();//cắt khoảng trắng trái phải
                strname = strname.ToLower();//biến chuỗi về chữ thường
                //biến ký tự đầu tiên thành chữ hoa
                strname = strname[0].ToString().ToUpper() + strname.Substring(1);
                //xử lý phần còn lại
                for (int i = 0; i < strname.Length; i++)
                {
                    //cắt các khoảng trống thừa trong chuỗi
                    if ((strname[i] == ' ' && strname[i + 1] == ' '))
                        continue;
                    else
                    {
                        //Nếu là ký tự đầu của một từ thì biến ký tự đó thành chữ hóa
                        if (i > 0)
                            if (strname[i] != ' ' && strname[i - 1] == ' ')
                                result += strname[i].ToString().ToUpper();
                            else
                                result += strname[i].ToString();
                        else
                            result += strname[i].ToString();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return "Lỗi chuẩn hóa họ tên: " + ex.Message;
            }
        }
        public static string STANDARD_ADDRESS(string Str)
        {
            try
            {
                string strname, result = "";
                string strspecial = @"@\}]{[_=+.,;':""><*&^%$#!~`?|";
                if (Str == null)//nếu rỗng thì trả về null
                    return null;

                foreach (char ch in strspecial)
                {
                    Str = Str.Replace(ch, ' ');
                }
                strname = Str.Trim();//cắt khoảng trắng trái phải
                strname = strname.ToLower();//biến chuỗi về chữ thường
                //biến ký tự đầu tiên thành chữ hoa
                strname = strname[0].ToString().ToUpper() + strname.Substring(1);
                //xử lý phần còn lại
                for (int i = 0; i < strname.Length; i++)
                {
                    //cắt các khoảng trống thừa trong chuỗi
                    if ((strname[i] == ' ' && strname[i + 1] == ' ') || (strname[i] == '-' && strname[i + 1] == '-') || (strname[i] == ')' && strname[i + 1] == ')') || (strname[i] == '(' && strname[i + 1] == '(') || (strname[i] == '/' && strname[i + 1] == '/'))
                        continue;
                    else
                    {
                        //Nếu là ký tự đầu của một từ thì biến ký tự đó thành chữ hóa
                        if (i > 0)
                            if (strname[i] != ' ' && (strname[i - 1] == ' ' || strname[i - 1] == '-'))
                                result += strname[i].ToString().ToUpper();
                            else
                                result += strname[i].ToString();
                        else
                            result += strname[i].ToString();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return "Lỗi chuẩn hóa địa chỉ: " + ex.Message;
            }
        }
    }
    #endregion
    #region "Lớp xử lý số
    public class CHECK_VALUE
    {

        //Phương thức lấy ngẫu nhiên một số trong đoạn [start,finish]
        public static int RANDOM(int start, int finish)
        {
            Random rand = new Random();
            return rand.Next(start, finish);
        }
        //Phương thức lấy ngẫu nhiên
        public static int RANDOM()
        {
            Random rand = new Random();
            return rand.Next();
        }
        //Phương thức lấy ngẫu nhiên lớn nhất là maxvalue
        public static int RANDOM(int maxvalue)
        {
            Random rand = new Random();
            return rand.Next(maxvalue);
        }
        //Kiểm tra kiểu double
        public static bool IsNumericDouble1(object ValueToCheck)
        {
            double Dummy = 0;
            return !double.TryParse(ValueToCheck.ToString(), System.Globalization.NumberStyles.Any, null, out Dummy);
        }
        public static bool IsNumericDouble(object ValueToCheck)
        {
            try
            {
                Convert.ToDouble(ValueToCheck);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Kiểm tra kiểu int
        public static bool IsNumericInt(object ValueToCheck)
        {
            int Dummy = 0;
            return !int.TryParse(ValueToCheck.ToString(), System.Globalization.NumberStyles.Any, null, out Dummy);
        }
        public static bool IsNumericInt32(object ValueToCheck)
        {
            try
            {
                Convert.ToInt32(ValueToCheck);
                return true;
            }
            catch
            {
                return false;
            }

        }
        //Kiểm tra kiểu mail
        public static bool IsEmail(object ValueToCheck)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(ValueToCheck.ToString(), @"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$");
        }
        //Kiểm tra kiểu date
        public static bool IsDate(object ValueToCheck)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(ValueToCheck.ToString(), @"^[0-2]?[1-9](/|-|.)[0-3]?[0-9](/|-|.)[1-2][0-9][0-9][0-9]$");

        }

    }
    #endregion
    #region "Lớp binding dữ liệu lên các điều khiển
    public class COMMON
    {
        //Phương thức gắn kết dữ liệu trong ds lên các điều khiển
        public static void CONTROL_BIND(DataSet ds, Form frm, string table, string type)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "1")
                    if (ctrl is TextBox)
                        ctrl.DataBindings.Add(new Binding("Text", ds, table + "." + ctrl.Name.Substring(3)));
                    else if ((ctrl is ComboBox || ctrl is ListBox))
                        ctrl.DataBindings.Add(new Binding(type, ds, table + "." + ctrl.Name.Substring(3)));
            }
        }
        //Phương thức ẩn hiện các điều khiển trên form
        public static void HIDE_SHOW(Form frm, bool status, string tag)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.Tag != null)
                {
                    if (ctrl.Tag.ToString() == "-" + tag || ctrl.Tag.ToString() == "1")
                        ctrl.Enabled = status;
                    else if (ctrl.Tag.ToString() == tag)
                        ctrl.Enabled = !status;
                }
            }
        }
        //Phương thức ẩn hiện các điều khiển trên tab
        public static void HIDE_SHOW(TabPage tab, bool status, string tag)
        {
            foreach (Control ctrl in tab.Controls)
            {
                if (ctrl.Tag != null)
                {
                    if (ctrl.Tag.ToString() == "-" + tag || ctrl.Tag.ToString() == "1")
                        ctrl.Enabled = status;
                    else if (ctrl.Tag.ToString() == tag)
                        ctrl.Enabled = !status;
                }
            }
        }
        //Phương thức ẩn hiện các điều khiển trên group
        public static void HIDE_SHOW(GroupBox grb, bool status, string tag)
        {
            foreach (Control ctrl in grb.Controls)
            {
                if (ctrl.Tag != null)
                {
                    if (ctrl.Tag.ToString() == "-" + tag || ctrl.Tag.ToString() == "1")
                        ctrl.Enabled = status;
                    else if (ctrl.Tag.ToString() == tag)
                        ctrl.Enabled = !status;
                }
            }
        }
        //Phương thức báo lỗi rỗng
        public static bool IS_EMPTY(Control ctrl, ErrorProvider err)
        {
            bool status = false;
            if (ctrl.Text.Trim() == "")
            {
                err.SetError(ctrl, "Hãy nhập dữ liệu");
                status = true;
            }
            else
            {
                err.SetError(ctrl, null);
            }
            return status;
        }
        //phương thức xóa lỗi
        public static void CLEAR_ERR(Form frm, ErrorProvider err)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "1")
                    err.SetError(ctrl, null);
            }
        }
        //kiểm tra lỗi toàn bộ
        public static bool ANY_EMPTY(Form frm, ErrorProvider err)
        {
            bool status = false;
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "1")
                    if (err.GetError(ctrl) != "")
                    {
                        status = true;
                        break;
                    }
            }
            return status;
        }

    }
    #endregion
    #region "Lớp tạo mã tự động
    public class AUTOCODE
    {
        public static string AUTO_CODE(string current_code, string str_start)
        {
            try
            {
                string str, result = ""; int number;
                str = current_code.Substring(str_start.Length);
                number = Convert.ToInt32(str) + 1;
                for (int i = 0; i < str.Length - number.ToString().Length; i++)
                    result += "0";
                result = str_start + result + number.ToString();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
    #endregion
   

}

