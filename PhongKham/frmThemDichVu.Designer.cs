namespace PhongKham
{
    partial class frmThemDichVu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.ultraGroupBox37 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btn_CapNhat = new Infragistics.Win.Misc.UltraButton();
            this.lblSoNgayConLai = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.txtSoLuongHuy = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox37)).BeginInit();
            this.ultraGroupBox37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongHuy)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox37
            // 
            this.ultraGroupBox37.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox37.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D;
            this.ultraGroupBox37.Controls.Add(this.txtSoLuongHuy);
            this.ultraGroupBox37.Controls.Add(this.btn_CapNhat);
            this.ultraGroupBox37.Controls.Add(this.lblSoNgayConLai);
            this.ultraGroupBox37.Controls.Add(this.txtTenDV);
            this.ultraGroupBox37.Controls.Add(this.txtSoLuong);
            this.ultraGroupBox37.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox37.Controls.Add(this.ultraLabel22);
            this.ultraGroupBox37.Controls.Add(this.txtDonGia);
            this.ultraGroupBox37.Controls.Add(this.ultraLabel23);
            this.ultraGroupBox37.Controls.Add(this.ultraLabel25);
            this.ultraGroupBox37.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGroupBox37.Location = new System.Drawing.Point(12, 12);
            this.ultraGroupBox37.Name = "ultraGroupBox37";
            this.ultraGroupBox37.Size = new System.Drawing.Size(372, 161);
            this.ultraGroupBox37.SupportThemes = false;
            this.ultraGroupBox37.TabIndex = 66;
            this.ultraGroupBox37.Text = "Hủy dịch vụ";
            // 
            // btn_CapNhat
            // 
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance1.Image = global::PhongKham.Resource1.save_as2;
            this.btn_CapNhat.Appearance = appearance1;
            this.btn_CapNhat.Location = new System.Drawing.Point(130, 129);
            this.btn_CapNhat.Name = "btn_CapNhat";
            this.btn_CapNhat.Size = new System.Drawing.Size(86, 26);
            this.btn_CapNhat.TabIndex = 45;
            this.btn_CapNhat.Text = "Cập nhật";
            this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
            // 
            // lblSoNgayConLai
            // 
            this.lblSoNgayConLai.AutoSize = true;
            this.lblSoNgayConLai.Location = new System.Drawing.Point(186, 164);
            this.lblSoNgayConLai.Name = "lblSoNgayConLai";
            this.lblSoNgayConLai.Size = new System.Drawing.Size(0, 14);
            this.lblSoNgayConLai.TabIndex = 46;
            // 
            // txtTenDV
            // 
            this.txtTenDV.BackColor = System.Drawing.Color.White;
            this.txtTenDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDV.Location = new System.Drawing.Point(77, 21);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.ReadOnly = true;
            this.txtTenDV.Size = new System.Drawing.Size(241, 22);
            this.txtTenDV.TabIndex = 1;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.BackColor = System.Drawing.Color.White;
            this.txtSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoLuong.Location = new System.Drawing.Point(77, 86);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ReadOnly = true;
            this.txtSoLuong.Size = new System.Drawing.Size(47, 22);
            this.txtSoLuong.TabIndex = 43;
            // 
            // ultraLabel22
            // 
            this.ultraLabel22.Location = new System.Drawing.Point(7, 88);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(69, 16);
            this.ultraLabel22.TabIndex = 42;
            this.ultraLabel22.Text = "Số lượng";
            // 
            // txtDonGia
            // 
            this.txtDonGia.BackColor = System.Drawing.Color.White;
            this.txtDonGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDonGia.Location = new System.Drawing.Point(77, 54);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(107, 22);
            this.txtDonGia.TabIndex = 41;
            // 
            // ultraLabel23
            // 
            this.ultraLabel23.Location = new System.Drawing.Point(7, 56);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(69, 16);
            this.ultraLabel23.TabIndex = 40;
            this.ultraLabel23.Text = "Đơn giá";
            // 
            // ultraLabel25
            // 
            this.ultraLabel25.Location = new System.Drawing.Point(7, 24);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(69, 16);
            this.ultraLabel25.TabIndex = 36;
            this.ultraLabel25.Text = "Tên dịch vụ";
            // 
            // txtSoLuongHuy
            // 
            this.txtSoLuongHuy.Location = new System.Drawing.Point(228, 85);
            this.txtSoLuongHuy.Name = "txtSoLuongHuy";
            this.txtSoLuongHuy.Size = new System.Drawing.Size(90, 23);
            this.txtSoLuongHuy.TabIndex = 47;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(130, 88);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(92, 20);
            this.ultraLabel1.TabIndex = 42;
            this.ultraLabel1.Text = "Số lượng hủy";
            // 
            // frmHuyDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 180);
            this.Controls.Add(this.ultraGroupBox37);
            this.Name = "frmHuyDichVu";
            this.Text = "Hủy dịch vụ";
            this.Load += new System.EventHandler(this.frmHuyDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox37)).EndInit();
            this.ultraGroupBox37.ResumeLayout(false);
            this.ultraGroupBox37.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongHuy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox37;
        private Infragistics.Win.Misc.UltraButton btn_CapNhat;
        private System.Windows.Forms.Label lblSoNgayConLai;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.TextBox txtSoLuong;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private System.Windows.Forms.TextBox txtDonGia;
        private Infragistics.Win.Misc.UltraLabel ultraLabel23;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtSoLuongHuy;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;

    }
}