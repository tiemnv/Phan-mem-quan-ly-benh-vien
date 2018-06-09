using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using System.Security.Cryptography;
namespace Util
{
    public class ResetControl
    {
        public static byte[] Get_MD5(string str)
        {
            byte[] pass = System.Text.UTF8Encoding.Unicode.GetBytes(str);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] mk = md5.ComputeHash(pass);
            return mk;
        }
        public static bool CheckValue(ArrayList clt, ErrorProvider error)
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
                                if (Ultratxt.Text == "")
                                {
                                    error.SetError(Ultratxt, "loi");
                                    Ultratxt.Focus();
                                    return false;

                                }
                                else error.Clear();
                                break;
                            }
                        case "ComboBox":
                            {
                                ComboBox Ultratxt = txt as ComboBox;
                                if (Ultratxt.Text == "")
                                {
                                    error.SetError(Ultratxt, "loi");
                                    Ultratxt.Focus();
                                    return false;

                                }
                                else error.Clear();
                                break;
                            }
                        case "TextBox":
                            {
                                TextBox textboxtxt = txt as TextBox;
                                if (textboxtxt.Text == "")
                                {
                                    error.SetError(textboxtxt, "loi");
                                    textboxtxt.Focus();
                                    return false;

                                }
                                else error.Clear();
                                break;
                            }
                        case "UltraCombo":
                            {
                                UltraCombo textboxtxt = txt as UltraCombo;
                                if (textboxtxt.Text == "")
                                {
                                    error.SetError(textboxtxt, "loi");
                                    textboxtxt.Focus();
                                    return false;

                                }
                                else error.Clear();
                                break;
                            }
                        case "UltraComboEditor":
                            {
                                UltraComboEditor textboxtxt = txt as UltraComboEditor;
                                if (textboxtxt.Text == "")
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

        public static void ReserAll(Control ctr)
        {
            try
            {

                foreach (Control txt in ctr.Controls)
                {
                  
                    ReserAll(txt);
                    switch (txt.GetType().Name)
                    {
                        case "UltraTextEditor":
                            {
                                UltraTextEditor Ultratxt = txt as UltraTextEditor;
                                Ultratxt.Text = string.Empty;
                                break;
                            }
                        case "TextBox":
                            {
                                TextBox textboxtxt = txt as TextBox;
                                textboxtxt.Text = string.Empty;
                                break;
                            }
                        case "UltraCombo":
                            {
                                UltraCombo textboxtxt = txt as UltraCombo;
                                textboxtxt.Text = string.Empty;
                                break;
                            }
                        case "UltraComboEditor":
                            {
                                UltraComboEditor textboxtxt = txt as UltraComboEditor;
                                textboxtxt.Text = string.Empty;
                                break;
                            }
                        case "UltraNumericEditor":
                            {
                                UltraNumericEditor textboxtxt = txt as UltraNumericEditor;
                                textboxtxt.Value = 0;
                                break;
                            }
                    }
                }
            }
            catch (Exception)
            {


            }
        }
        public static void Enable_Control(Control ctr)
        {
            try
            {

                foreach (Control txt in ctr.Controls)
                {
                    Enable_Control(txt);
                    switch (txt.GetType().Name)
                    {
                        case "UltraTextEditor":
                            {
                                UltraTextEditor Ultratxt = txt as UltraTextEditor;
                                Ultratxt.ReadOnly = false;
                                break;
                            }
                        case "TextBox":
                            {
                                TextBox textboxtxt = txt as TextBox;
                                textboxtxt.ReadOnly = false;
                                break;
                            }
                        case "UltraCombo":
                            {
                                UltraCombo textboxtxt = txt as UltraCombo;
                                textboxtxt.ReadOnly = false;
                                break;
                            }
                        case "UltraComboEditor":
                            {
                                UltraComboEditor textboxtxt = txt as UltraComboEditor;
                                textboxtxt.ReadOnly = false;
                                break;
                            }
                        case "UltraDateTimeEditor":
                            {
                                UltraDateTimeEditor textboxtxt = txt as UltraDateTimeEditor;
                                textboxtxt.ReadOnly = false;
                                break;
                            }
                        case "UltraNumericEditor":
                            {
                                UltraNumericEditor textboxtxt = txt as UltraNumericEditor;
                                textboxtxt.ReadOnly = false;
                                break;
                            }
                    }
                }
            }
            catch (Exception)
            {


            }
        }


        public static void ReadOnly_Control(Control ctr)
        {
            try
            {

                foreach (Control txt in ctr.Controls)
                {
                    ReadOnly_Control(txt);
                    switch (txt.GetType().Name)
                    {
                        case "UltraTextEditor":
                            {
                                UltraTextEditor Ultratxt = txt as UltraTextEditor;
                                Ultratxt.ReadOnly = true;
                                break;
                            }
                        case "TextBox":
                            {
                                TextBox textboxtxt = txt as TextBox;
                                textboxtxt.ReadOnly = true;
                                break;
                            }
                        case "UltraCombo":
                            {
                                UltraCombo textboxtxt = txt as UltraCombo;
                                textboxtxt.ReadOnly = true;
                                break;
                            }
                        case "UltraComboEditor":
                            {
                                UltraComboEditor textboxtxt = txt as UltraComboEditor;
                                textboxtxt.ReadOnly = true;
                                break;
                            }
                        case "UltraDateTimeEditor":
                            {
                                UltraDateTimeEditor textboxtxt = txt as UltraDateTimeEditor;
                                textboxtxt.ReadOnly = true;
                                break;
                            }
                        case "UltraNumericEditor":
                            {
                                UltraNumericEditor textboxtxt = txt as UltraNumericEditor;
                                textboxtxt.ReadOnly = true;
                                break;
                            }
                    }
                }
            }
            catch (Exception)
            {


            }
        }
        static void combo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (((UltraCombo)sender).Value == null || ((UltraCombo)sender).Value.ToString() == "")
                {
                      ((UltraCombo)sender).PerformAction(UltraComboAction.Dropdown);
                     
                }
                else
                {
                    if (((UltraCombo)sender).Parent.Parent != null)
                    {
                        ((UltraCombo)sender).Parent.Parent.SelectNextControl(((UltraCombo)sender), true, true, true, true);
                    }
                    else
                    {
                        ((UltraCombo)sender).Parent.SelectNextControl(((UltraCombo)sender), true, true, true, true);
                    }
                }
            }
        }
        static void FormHandler_RowSelected(object sender, RowSelectedEventArgs e)
        {
            if (((UltraCombo)sender).ActiveRow != null)
            {
                ((TextBox)dsComboTextBox[sender]).Text = ((UltraCombo)sender).Value.ToString();
            }
        }
        static void FormHandler_Disposed(object sender, EventArgs e)
        {
            dsComboSource.Remove(((UltraCombo)sender));
        }
        static Hashtable dsComboSource = new Hashtable();
        static Hashtable dsComboTextBox = new Hashtable();
        public static void SetEnterForUltraComboUltraTextBox(UltraCombo[] combos, TextBox[] textBoxs)
        {
            for (int i = 0; i < combos.Length; i++)
            {
                if (!dsComboSource.Contains(combos[i]))
                {
                   
                    dsComboTextBox.Add(combos[i], textBoxs[i]);
                }
                combos[i].KeyPress += new KeyPressEventHandler(combo_KeyPress);
                combos[i].RowSelected += new RowSelectedEventHandler(FormHandler_RowSelected);
                combos[i].Disposed += new EventHandler(FormHandler_Disposed);
                if(((UltraCombo)combos[i]).DataSource!=null)
                for (int j = 0; j < ((DataTable)((UltraCombo)combos[i]).DataSource).Columns.Count; j++)
                {
                    if (combos[i].DisplayLayout.Bands[0].Columns[j].Key != combos[i].DisplayMember &&
                        combos[i].DisplayLayout.Bands[0].Columns[j].Key != combos[i].ValueMember)
                    {
                        combos[i].DisplayLayout.Bands[0].Columns[j].Hidden = true;
                    }
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
        public static void SetSourceForGridCustomCollumns(UltraGrid gridname, string[] collumnsID, string[] collumnsNAME)
        {
            
            for (int j = 0; j < ((DataTable)(gridname.DataSource)).Columns.Count; j++)
            {
                int k=CheckSTR(collumnsID, gridname.DisplayLayout.Bands[0].Columns[j].Key);
                if ( k== -1)
                {
                    gridname.DisplayLayout.Bands[0].Columns[j].Hidden = true;
                }
                else
                {
                    gridname.DisplayLayout.Bands[0].Columns[j].Header.Caption = collumnsNAME[k].ToString();
                }
            }
        }
        public static void SetSourceForGridCustomCollumns2(UltraGrid gridname, string[] collumnsID, string[] collumnsNAME)
        {

            for (int j = 0; j < ((DataTable)(((BindingSource)gridname.DataSource).DataSource)).Columns.Count; j++)
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
        public static DataTable getTable_forCombo(string[] columm, string[] valuekey, string[] valueName)
        {
            DataTable b = new DataTable();
            b.Columns.Add(columm[0].ToString());
            b.Columns.Add(columm[1].ToString());
            for (int i = 0; i < valuekey.Length; i++)
            {
                DataRow r = b.NewRow();
                r[0] = valuekey[i].ToString();
                r[1] = valueName[i].ToString();
                b.Rows.Add(r);
            }
            return b;
        }
    }

}
