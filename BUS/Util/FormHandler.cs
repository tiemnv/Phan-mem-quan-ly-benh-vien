using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

using System.IO;
using System.Security.AccessControl;
using System.Collections;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using System.Data.SqlClient;
using System.Reflection;

namespace Util
{
    public class FormHandler
    {

        public static bool CheckValueIsNumeric(ArrayList clt, ErrorProvider error)
        {
            try
            {

                for (int i = 0; i < clt.Count; i++)
                {
                    Control txt = (Control)clt[i];
                    switch (txt.GetType().Name)
                    {
                        case "UltraTextEditor":
                            {
                                UltraTextEditor Ultratxt = txt as UltraTextEditor;
                                if (!isNumeric(Ultratxt.Text)&& Ultratxt.Text.Length>0)
                                {
                                    error.SetError(Ultratxt, "loi");
                                    Ultratxt.SelectAll();
                                    return false;

                                }
                                else error.Clear();
                                break;
                            }
                       
                        case "TextBox":
                            {
                                TextBox textboxtxt = txt as TextBox;
                                if (!isNumeric(textboxtxt.Text)&& textboxtxt.Text.Length>0)
                                {
                                    error.SetError(textboxtxt, "loi");
                                    textboxtxt.Focus();
                                    return false;

                                }
                                else error.Clear();
                                break;
                            }
                       
                    }
                }
            }
            catch (Exception)
            {
                return false;

            }
            return true;
        }

        public static void SetSourceForGridCustomCollumns(UltraGrid gridname, string[] collumnsID, string[] collumnsNAME)
        {

            for (int j = 0; j < gridname.DisplayLayout.Bands[0].Columns.Count; j++)
            {
                int k = CheckSTR(collumnsID, gridname.DisplayLayout.Bands[0].Columns[j].Key);
                if (k == -1)
                {
                    gridname.DisplayLayout.Bands[0].Columns[j].Hidden = true;
                }
                else
                {
                    gridname.DisplayLayout.Bands[0].Columns[j].Header.Caption = collumnsNAME[k].ToString();
                }
            }
        }
        public static int CheckSTR(string[] arr, string str)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (str == arr[i].ToString()) return i;
            }
            return -1;
        }
        /// <summary>
        /// Reset text = "" của các control có thuộc tính Text trong ControlCollection
        /// 
        /// </summary>
        /// <param name="controlType"></param>
        /// <param name="controlCollection"></param>
        public static void ResetTextAllControlsLevel(Type controlType, Control.ControlCollection controlCollection)
        {
            for (int i = 0; i < controlCollection.Count; i++)
            {
                if (controlCollection[i].GetType() == controlType)
                {
                    controlCollection[i].Text = "";
                }
                else if (controlCollection[i].Controls.Count != 0)
                {
                    ResetTextAllControlsLevel(controlType, controlCollection[i].Controls);
                }

            }
        }
        public static void ResetTextAllControlsLevel(Type[] controlTypes, Control.ControlCollection controlCollection)
        {
            for (int i = 0; i < controlCollection.Count; i++)
            {
                if (ExistObject(controlCollection[i].GetType(), controlTypes))
                {
                    controlCollection[i].Text = "";
                }
                else if (controlCollection[i].Controls.Count != 0)
                {
                    ResetTextAllControlsLevel(controlTypes, controlCollection[i].Controls);
                }

            }
        }

        /// <summary>
        /// Bắt sự kiện bàn phím nếu là phím enter thì di chuyển con trỏ tới control có tabindex tiếp theo
        /// áp dụng cho ControlCollection nhiều tầng
        /// </summary>
        /// <param name="controlType"></param>
        /// <param name="controlCollection"></param>
        public static void SetEnterKeyForAllControlsLevel(Type controlType, Control.ControlCollection controlCollection)
        {
            for (int i = 0; i < controlCollection.Count; i++)
            {
                SetEnterForControlInCollection(controlType, controlCollection[i]);
            }
        }
        static void SetEnterForControlInCollection(Type controlType, Control control)
        {
            if (control.GetType() == controlType)
            {
                control.KeyPress += new KeyPressEventHandler(control_KeyPress);
            }
            else if (control.Controls.Count != 0)
            {
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    SetEnterForControlInCollection(controlType, control.Controls[i]);
                }
            }
        }

        public static void SetEnterKeyForAllControlsLevel(Type[] controlTypes, Control.ControlCollection controlCollection)
        {
            for (int i = 0; i < controlCollection.Count; i++)
            {
                SetEnterForControlInCollection(controlTypes, controlCollection[i]);
            }
        }

        /// <summary>
        /// Kiểm tra một object có trong một mảng Objects không
        /// trả về true nếu tồn tại
        /// false nếu không
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static bool ExistObject(Object obj, Object[] objs)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                if (obj == objs.GetValue(i))
                {
                    return true;
                }
            }
            return false;

        }

        static void SetEnterForControlInCollection(Type[] controlTypes, Control control)
        {
            if (ExistObject(control.GetType(), controlTypes))
            {
                control.KeyPress += new KeyPressEventHandler(control_KeyPress);
            }
            else if (control.Controls.Count != 0)
            {
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    SetEnterForControlInCollection(controlTypes, control.Controls[i]);
                }
            }
        }
        static void control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                if (((Control)sender).Parent.Parent != null)
                    ((Control)sender).Parent.Parent.SelectNextControl((Control)sender, true, true, true, true);
                else if (((Control)sender).Parent != null)
                {
                    ((Control)sender).Parent.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        public static byte[] Get_MD5(string str)
        {
            byte[] pass = System.Text.UTF8Encoding.Unicode.GetBytes(str);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] mk = md5.ComputeHash(pass);
            return mk;
        }
        public static bool isNumeric(string str)
        {

            Regex re = new Regex("^[0-9]+$");
            return re.IsMatch(str);
        }
        /// <summary>
        /// 
        /// kiểm tra một xâu nhập vào có phải số nằm trong khoảng từ beginnumber tới EndNumber
        /// </summary>
        /// <param name="StringInput"></param>
        /// <param name="BeginNumber"></param>
        /// <param name="Offset"></param>
        /// <returns></returns>
        public static bool isNumberInRange(string StringInput, int BeginNumber, int EndNumber)
        {
            if (Regex.IsMatch(StringInput, @"^[0-9]+$") == false)
            {
                return false;
            }
            else
            {
                int number;

                if (StringInput.Length > 1 && StringInput.Substring(StringInput.Length - 2, 1) == ".")
                {
                    float b = float.Parse(StringInput);
                    number = (Int32)b;
                }
                else
                    number = Int32.Parse(StringInput);
                if (number >= BeginNumber && number <= EndNumber)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 
        /// kiểm tra xâu nhập có phải là email không
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isMail(string str)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^(\w)+@(\w)+(.(\w)+)+$");
        }
        public static bool isNullString(string str)
        {
            if (str.Trim().Length == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// kiểm tra xâu nhập vào có phải là số thực không
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isReal(string str)
        {

            if (str.Length <= 1 || str.Substring(str.Length - 2, 1) != ".")
            {
                str = str + ".0";
            }
            return Regex.IsMatch(str, @"([0-9]+)(\.){0,1}([0-9]+)$");
        }
        public static bool isRealInRange(string str, float Begin, float End)
        {
            if (!isReal(str))
            {
                return false;
            }
            float temp = float.Parse(str.ToString());
            if (temp >= Begin && temp <= End)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// trả về kiểu int hiệu số ngày giữa hai DateTime
        /// </summary>
        /// <param name="Ngay1"></param>
        /// <param name="Ngay2"></param>
        /// <returns></returns>
        public static int SubDay(DateTime Ngay1, DateTime Ngay2)
        {
            DateTime date1 = DateTime.Parse(Ngay1.ToShortDateString());
            DateTime date2 = DateTime.Parse(Ngay2.ToShortDateString());
            int g = date1.CompareTo(date2);
            if (g < 0)
            {
                throw new InvalidOperationException("Invalid operation Exception");
            }
            if (g == 0)
            {
                return 0;
            }
            int res = 0;
            DateTime d = date2;
            int h;
            do
            {
                res++;
                d = date2.AddDays(res);
                h = date1.CompareTo(d);
            }
            while (h >= 0);
            return res;
        }
        /// <summary>
        /// Kiểm tra textbox có giá trị text là số hoặc null không
        /// nếu không thì focus textbox đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static byte[] GetMD5Byte(string str)
        {
            byte[] pass = System.Text.UTF8Encoding.Unicode.GetBytes(str);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] mk = md5.ComputeHash(pass);
            return mk;
        }
        public static string txtVND(Decimal BaoNhieu)
        {
            string KetQua = "", SoTien, Nhom, Chu, Dich, S1, S2, S3;
            int S;
            int I, J, Vitri;
            if (BaoNhieu == 0)
            {
                KetQua = "Không đồng";
            }
            else
            {
                SoTien = Math.Abs(BaoNhieu).ToString("##############0.00");
                SoTien = "               " + SoTien;
                SoTien = SoTien.Substring(SoTien.Length - 18, 18);
                string[] Hang;
                Hang = new string[] { "None", "trăm", "mươi", "gì đó" };
                string[] Doc;
                Doc = new string[] { "None", "ngàn tỷ", "tỷ", "triệu", "ngàn", "đồng" };
                string[] Dem;
                Dem = new string[] { "None", "một", "hai", "ba", "bốn", "năm", "sáu", "bẩy", "tám", "chín" };

                for (I = 1; I <= 5; I++)
                {
                    Nhom = SoTien.Substring(I * 3 - 3, 3);
                    if (Nhom != "   ")
                    {
                        switch (Nhom)
                        {
                            case "000":
                                {
                                    if (I == 5)
                                        Chu = "đồng" + " ";
                                    else
                                        Chu = "";
                                    break;

                                }
                            case ".00":
                                {
                                    Chu = "chẵn";
                                    break;
                                }
                            default:
                                {
                                    S1 = Nhom.Substring(0, 1);
                                    S2 = Nhom.Substring(1, 1);
                                    S3 = Nhom.Substring(Nhom.Length - 1, 1);
                                    Chu = "";
                                    Hang[3] = Doc[I];
                                    for (J = 1; J <= 3; J++)
                                    {
                                        Dich = "";
                                        try
                                        {
                                            S = Convert.ToInt32(Nhom.Substring(J - 1, 1));
                                            if (S > 0)
                                            {
                                                Dich = Dem[S] + " " + Hang[J] + " ";
                                            }
                                            switch (J)
                                            {
                                                case 2:
                                                    {
                                                        if (S == 1) Dich = "mười" + " ";
                                                        if ((S == 0) && (S3 != "0"))
                                                        {
                                                            if ((Convert.ToInt32(S1) >= 1 && Convert.ToInt32(S1) <= 9) || (S1 == "0" && I == 4))
                                                                Dich = "lẻ" + " ";
                                                        }
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        if ((S == 0) && (Nhom != " " + "0"))
                                                            Dich = Hang[J] + " ";

                                                        if ((S == 5) && (S2 != "") && (S2 != "0"))
                                                            Dich = "l" + Dich.Substring(1);
                                                        break;
                                                    }
                                            }
                                            Chu = Chu + Dich;
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }

                                    break;
                                }
                        }
                        //Vitri = Chu.IndexOf("mươi một", 1);
                        KetQua = KetQua + Chu;
                        string d = KetQua[0].ToString().ToUpper();

                        string d1 = KetQua.Remove(0, 1);
                        string k = d1.Insert(0, d);
                        KetQua = k;
                    }
                }
            }
            return KetQua;
        }
        public static Object GetAs(DataRow reader, Type objectToReturnType)
        {
            // Create a new Object
            Object newObjectToReturn = Activator.CreateInstance(objectToReturnType);
            // Get all the properties in our Object
            PropertyInfo[] props = objectToReturnType.GetProperties();
            // For each property get the data from the reader to the object
            for (int i = 0; i < props.Length; i++)
            {
                if (ColumnExists(reader, props[i].Name) && reader[props[i].Name] != DBNull.Value)
                    objectToReturnType.InvokeMember(props[i].Name, BindingFlags.SetProperty, null, newObjectToReturn, new Object[] { reader[props[i].Name] });
            }
            return newObjectToReturn;
        }
        public static bool ColumnExists(DataRow reader, string columnName)
        {
            return reader.Table.Columns.Contains(columnName);
            
        }
    }
}
