namespace PhongKham
{
    partial class frmDichVu
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            this.txtDonGia = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblQueQuan = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_Phong = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.lblSoCMT = new System.Windows.Forms.Label();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblNamSinh = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu_Edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridDanhSach = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_moi = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_ghi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_Phong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.contextMenu_Edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSach)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(131, 42);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.PromptChar = ' ';
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(100, 21);
            this.txtDonGia.TabIndex = 2;
            this.txtDonGia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDonGia_KeyUp);
            // 
            // lblQueQuan
            // 
            this.lblQueQuan.AutoSize = true;
            this.lblQueQuan.Location = new System.Drawing.Point(19, 100);
            this.lblQueQuan.Name = "lblQueQuan";
            this.lblQueQuan.Size = new System.Drawing.Size(38, 13);
            this.lblQueQuan.TabIndex = 16;
            this.lblQueQuan.Text = "Phòng";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cbx_Phong);
            this.groupBox1.Controls.Add(this.txtPhong);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.lblQueQuan);
            this.groupBox1.Controls.Add(this.txtTenDV);
            this.groupBox1.Controls.Add(this.lblSoCMT);
            this.groupBox1.Controls.Add(this.txtMaDV);
            this.groupBox1.Controls.Add(this.lblHoTen);
            this.groupBox1.Controls.Add(this.lblNamSinh);
            this.groupBox1.Controls.Add(this.txtDVT);
            this.groupBox1.Controls.Add(this.lblDiaChi);
            this.groupBox1.Location = new System.Drawing.Point(13, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 173);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // cbx_Phong
            // 
            appearance20.BackColorDisabled = System.Drawing.Color.White;
            this.cbx_Phong.Appearance = appearance20;
            this.cbx_Phong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbx_Phong.DisplayLayout.Appearance = appearance21;
            this.cbx_Phong.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cbx_Phong.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance22.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.BorderColor = System.Drawing.SystemColors.Window;
            this.cbx_Phong.DisplayLayout.GroupByBox.Appearance = appearance22;
            appearance23.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbx_Phong.DisplayLayout.GroupByBox.BandLabelAppearance = appearance23;
            this.cbx_Phong.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance24.BackColor2 = System.Drawing.SystemColors.Control;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbx_Phong.DisplayLayout.GroupByBox.PromptAppearance = appearance24;
            this.cbx_Phong.DisplayLayout.MaxColScrollRegions = 1;
            this.cbx_Phong.DisplayLayout.MaxRowScrollRegions = 1;
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            appearance25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbx_Phong.DisplayLayout.Override.ActiveCellAppearance = appearance25;
            appearance26.BackColor = System.Drawing.SystemColors.Highlight;
            appearance26.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbx_Phong.DisplayLayout.Override.ActiveRowAppearance = appearance26;
            this.cbx_Phong.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cbx_Phong.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance27.BackColor = System.Drawing.SystemColors.Window;
            this.cbx_Phong.DisplayLayout.Override.CardAreaAppearance = appearance27;
            appearance28.BorderColor = System.Drawing.Color.Silver;
            appearance28.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cbx_Phong.DisplayLayout.Override.CellAppearance = appearance28;
            this.cbx_Phong.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cbx_Phong.DisplayLayout.Override.CellPadding = 0;
            appearance29.BackColor = System.Drawing.SystemColors.Control;
            appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance29.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance29.BorderColor = System.Drawing.SystemColors.Window;
            this.cbx_Phong.DisplayLayout.Override.GroupByRowAppearance = appearance29;
            appearance30.TextHAlign = Infragistics.Win.HAlign.Left;
            this.cbx_Phong.DisplayLayout.Override.HeaderAppearance = appearance30;
            this.cbx_Phong.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cbx_Phong.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance31.BackColor = System.Drawing.SystemColors.Window;
            appearance31.BorderColor = System.Drawing.Color.Silver;
            this.cbx_Phong.DisplayLayout.Override.RowAppearance = appearance31;
            this.cbx_Phong.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance32.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbx_Phong.DisplayLayout.Override.TemplateAddRowAppearance = appearance32;
            this.cbx_Phong.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cbx_Phong.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cbx_Phong.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cbx_Phong.DisplayMember = "";
            this.cbx_Phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Phong.Location = new System.Drawing.Point(131, 100);
            this.cbx_Phong.Name = "cbx_Phong";
            this.cbx_Phong.ReadOnly = true;
            this.cbx_Phong.Size = new System.Drawing.Size(100, 22);
            this.cbx_Phong.TabIndex = 24;
            this.cbx_Phong.ValueMember = "";
            // 
            // txtPhong
            // 
            this.txtPhong.BackColor = System.Drawing.SystemColors.Window;
            this.txtPhong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhong.Location = new System.Drawing.Point(240, 100);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.ReadOnly = true;
            this.txtPhong.Size = new System.Drawing.Size(318, 21);
            this.txtPhong.TabIndex = 25;
            // 
            // txtTenDV
            // 
            this.txtTenDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDV.Location = new System.Drawing.Point(307, 16);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.ReadOnly = true;
            this.txtTenDV.Size = new System.Drawing.Size(251, 20);
            this.txtTenDV.TabIndex = 1;
            // 
            // lblSoCMT
            // 
            this.lblSoCMT.AutoSize = true;
            this.lblSoCMT.Location = new System.Drawing.Point(237, 18);
            this.lblSoCMT.Name = "lblSoCMT";
            this.lblSoCMT.Size = new System.Drawing.Size(64, 13);
            this.lblSoCMT.TabIndex = 8;
            this.lblSoCMT.Text = "Tên dịch vụ";
            // 
            // txtMaDV
            // 
            this.txtMaDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaDV.Location = new System.Drawing.Point(131, 16);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.ReadOnly = true;
            this.txtMaDV.Size = new System.Drawing.Size(100, 20);
            this.txtMaDV.TabIndex = 0;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(18, 18);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(60, 13);
            this.lblHoTen.TabIndex = 10;
            this.lblHoTen.Text = "Mã dịch vụ";
            // 
            // lblNamSinh
            // 
            this.lblNamSinh.AutoSize = true;
            this.lblNamSinh.Location = new System.Drawing.Point(18, 48);
            this.lblNamSinh.Name = "lblNamSinh";
            this.lblNamSinh.Size = new System.Drawing.Size(44, 13);
            this.lblNamSinh.TabIndex = 12;
            this.lblNamSinh.Text = "Đơn giá";
            // 
            // txtDVT
            // 
            this.txtDVT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDVT.Location = new System.Drawing.Point(131, 72);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.ReadOnly = true;
            this.txtDVT.Size = new System.Drawing.Size(100, 20);
            this.txtDVT.TabIndex = 3;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(18, 71);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(29, 13);
            this.lblDiaChi.TabIndex = 13;
            this.lblDiaChi.Text = "ĐVT";
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sửaToolStripMenuItem.Text = "Sửa";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // contextMenu_Edit
            // 
            this.contextMenu_Edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửaToolStripMenuItem,
            this.xóaToolStripMenuItem});
            this.contextMenu_Edit.Name = "contextMenu_Edit";
            this.contextMenu_Edit.Size = new System.Drawing.Size(105, 48);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // gridDanhSach
            // 
            this.gridDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDanhSach.ContextMenuStrip = this.contextMenu_Edit;
            appearance33.BackColor = System.Drawing.Color.White;
            this.gridDanhSach.DisplayLayout.Appearance = appearance33;
            this.gridDanhSach.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn2.Header.Caption = "Chọn";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn2});
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            ultraGridBand2.Header.Appearance = appearance34;
            this.gridDanhSach.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.gridDanhSach.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridDanhSach.DisplayLayout.GroupByBox.Hidden = true;
            appearance35.BackColor = System.Drawing.Color.Transparent;
            this.gridDanhSach.DisplayLayout.Override.CardAreaAppearance = appearance35;
            this.gridDanhSach.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance36.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance36.FontData.BoldAsString = "True";
            appearance36.FontData.Name = "Arial";
            appearance36.FontData.SizeInPoints = 10F;
            appearance36.ForeColor = System.Drawing.Color.White;
            appearance36.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gridDanhSach.DisplayLayout.Override.HeaderAppearance = appearance36;
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance37.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridDanhSach.DisplayLayout.Override.RowSelectorAppearance = appearance37;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance38.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridDanhSach.DisplayLayout.Override.SelectedRowAppearance = appearance38;
            this.gridDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDanhSach.Location = new System.Drawing.Point(6, 19);
            this.gridDanhSach.Name = "gridDanhSach";
            this.gridDanhSach.Size = new System.Drawing.Size(782, 206);
            this.gridDanhSach.TabIndex = 0;
            this.gridDanhSach.Text = "ultraGrid1";
            this.gridDanhSach.AfterRowActivate += new System.EventHandler(this.gridDanhSach_AfterRowActivate);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridDanhSach);
            this.groupBox2.Location = new System.Drawing.Point(9, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(795, 240);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_moi);
            this.groupBox3.Controls.Add(this.btn_thoat);
            this.groupBox3.Controls.Add(this.btn_ghi);
            this.groupBox3.Location = new System.Drawing.Point(9, 427);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(795, 57);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // btn_moi
            // 
            this.btn_moi.Location = new System.Drawing.Point(517, 19);
            this.btn_moi.Name = "btn_moi";
            this.btn_moi.Size = new System.Drawing.Size(75, 23);
            this.btn_moi.TabIndex = 1;
            this.btn_moi.Text = "&Mới";
            this.btn_moi.UseVisualStyleBackColor = true;
            this.btn_moi.Click += new System.EventHandler(this.btn_moi_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(713, 19);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_thoat.TabIndex = 3;
            this.btn_thoat.Text = "&Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_ghi
            // 
            this.btn_ghi.Location = new System.Drawing.Point(619, 19);
            this.btn_ghi.Name = "btn_ghi";
            this.btn_ghi.Size = new System.Drawing.Size(69, 23);
            this.btn_ghi.TabIndex = 0;
            this.btn_ghi.Text = "&Lưu";
            this.btn_ghi.UseVisualStyleBackColor = true;
            this.btn_ghi.Click += new System.EventHandler(this.btn_ghi_Click);
            // 
            // frmDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmDichVu";
            this.Text = "Danh sách dịch vụ";
            this.Load += new System.EventHandler(this.frmDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_Phong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.contextMenu_Edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSach)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDonGia;
        private System.Windows.Forms.Label lblQueQuan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label lblSoCMT;
        private System.Windows.Forms.TextBox txtMaDV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNamSinh;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.GroupBox groupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridDanhSach;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Edit;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_moi;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_ghi;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbx_Phong;
        private System.Windows.Forms.TextBox txtPhong;
    }
}