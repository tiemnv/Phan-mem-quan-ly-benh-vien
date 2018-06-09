using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace PhongKham
{
    public partial class ImportFileImage : Form
    {
        public ImportFileImage()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //Read Image Bytes into a byte array
                byte[] imageData = ReadFile(txtImagePath.Text);
                
                //Initialize SQL Server Connection
                SqlConnection CN = new SqlConnection(txtConnectionString.Text);

                //Set insert query
                string qry = "insert into ImagesStore (OriginalPath,ImageData) values(@OriginalPath, @ImageData)";

                //Initialize SqlCommand object for insert.
                SqlCommand SqlCom = new SqlCommand(qry, CN);

                //We are passing Original Image Path and Image byte data as sql parameters.
                SqlCom.Parameters.Add(new SqlParameter("@OriginalPath", (object)txtImagePath.Text));
                SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)imageData));

                //Open connection and execute insert query.
                CN.Open();
                SqlCom.ExecuteNonQuery();
                CN.Close();

                //Close form and return to list or images.
                this.Close();
           

        }
        //Open file in to a filestream and read data in a byte array.
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        void GetImagesFromDatabase()
        {
            try
            {
                //Initialize SQL Server connection.
                SqlConnection CN = new SqlConnection(txtConnectionString.Text);

                //Initialize SQL adapter.
                SqlDataAdapter ADAP = new SqlDataAdapter("Select * from ImagesStore", CN);

                //Initialize Dataset.
                DataSet DS = new DataSet();

                //Fill dataset with ImagesStore table.
                ADAP.Fill(DS, "ImagesStore");

                //Fill Grid with dataset.
                dataGridView1.DataSource = DS.Tables["ImagesStore"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Get image data from gridview column.
                byte[] imageData = (byte[])dataGridView1.Rows[e.RowIndex].Cells["ImageData"].Value;

                //Initialize image variable
                Image newImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }

                //set picture
                pictureBox1.Image = newImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btn_saveLocal_Click(object sender, EventArgs e)
        {
            //Store image to a local file.
            pictureBox1.Image.Save("c:\test_picture.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }



    }
}