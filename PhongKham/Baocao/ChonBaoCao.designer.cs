namespace GUI.BaoCao
{
    partial class ChonBaoCao
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
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChonBaoCao));
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn5 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("MaKho");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn6 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("TenKho");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn7 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("MaLoaiThuoc");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn8 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("TenLoaiThuoc");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Báo cáo bác sĩ gửi");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Thống kê doanh thu theo phòng");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Doanh thu theo đối tượng khám");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Bác sĩ gửi chi tiết");
            this.dt_denngay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBaocao = new Infragistics.Win.Misc.UltraButton();
            this.btnThoat = new Infragistics.Win.Misc.UltraButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbx_MaDoiTuong = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_tungay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lbl_tile_benhvien = new Infragistics.Win.Misc.UltraLabel();
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource();
            this.ultraDataSource2 = new Infragistics.Win.UltraWinDataSource.UltraDataSource();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dt_denngay)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_MaDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_tungay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_denngay
            // 
            this.dt_denngay.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.dt_denngay.FormatProvider = new System.Globalization.CultureInfo("vi-VN");
            this.dt_denngay.Location = new System.Drawing.Point(344, 67);
            this.dt_denngay.Name = "dt_denngay";
            this.dt_denngay.Size = new System.Drawing.Size(114, 21);
            this.dt_denngay.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Đến ngày:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Từ ngày:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBaocao
            // 
            appearance17.Image = ((object)(resources.GetObject("appearance17.Image")));
            this.btnBaocao.Appearance = appearance17;
            this.btnBaocao.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBaocao.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button;
            this.btnBaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaocao.ImageSize = new System.Drawing.Size(20, 20);
            this.btnBaocao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBaocao.Location = new System.Drawing.Point(497, 171);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(88, 32);
            this.btnBaocao.TabIndex = 9;
            this.btnBaocao.Text = "&Báo cáo";
            this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
            // 
            // btnThoat
            // 
            appearance18.Image = ((object)(resources.GetObject("appearance18.Image")));
            this.btnThoat.Appearance = appearance18;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ImageSize = new System.Drawing.Size(23, 23);
            this.btnThoat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnThoat.Location = new System.Drawing.Point(591, 171);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(88, 32);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbx_MaDoiTuong);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dt_denngay);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dt_tungay);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(334, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 107);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin bảng kê";
            // 
            // cbx_MaDoiTuong
            // 
            appearance19.BackColorDisabled = System.Drawing.Color.White;
            this.cbx_MaDoiTuong.Appearance = appearance19;
            this.cbx_MaDoiTuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            appearance20.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbx_MaDoiTuong.DisplayLayout.Appearance = appearance20;
            this.cbx_MaDoiTuong.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cbx_MaDoiTuong.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance21.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.cbx_MaDoiTuong.DisplayLayout.GroupByBox.Appearance = appearance21;
            appearance22.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbx_MaDoiTuong.DisplayLayout.GroupByBox.BandLabelAppearance = appearance22;
            this.cbx_MaDoiTuong.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance23.BackColor2 = System.Drawing.SystemColors.Control;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance23.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbx_MaDoiTuong.DisplayLayout.GroupByBox.PromptAppearance = appearance23;
            this.cbx_MaDoiTuong.DisplayLayout.MaxColScrollRegions = 1;
            this.cbx_MaDoiTuong.DisplayLayout.MaxRowScrollRegions = 1;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            appearance24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbx_MaDoiTuong.DisplayLayout.Override.ActiveCellAppearance = appearance24;
            appearance25.BackColor = System.Drawing.SystemColors.Highlight;
            appearance25.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbx_MaDoiTuong.DisplayLayout.Override.ActiveRowAppearance = appearance25;
            this.cbx_MaDoiTuong.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cbx_MaDoiTuong.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            this.cbx_MaDoiTuong.DisplayLayout.Override.CardAreaAppearance = appearance26;
            appearance27.BorderColor = System.Drawing.Color.Silver;
            appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cbx_MaDoiTuong.DisplayLayout.Override.CellAppearance = appearance27;
            this.cbx_MaDoiTuong.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cbx_MaDoiTuong.DisplayLayout.Override.CellPadding = 0;
            appearance28.BackColor = System.Drawing.SystemColors.Control;
            appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance28.BorderColor = System.Drawing.SystemColors.Window;
            this.cbx_MaDoiTuong.DisplayLayout.Override.GroupByRowAppearance = appearance28;
            appearance29.TextHAlign = Infragistics.Win.HAlign.Left;
            this.cbx_MaDoiTuong.DisplayLayout.Override.HeaderAppearance = appearance29;
            this.cbx_MaDoiTuong.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cbx_MaDoiTuong.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance30.BackColor = System.Drawing.SystemColors.Window;
            appearance30.BorderColor = System.Drawing.Color.Silver;
            this.cbx_MaDoiTuong.DisplayLayout.Override.RowAppearance = appearance30;
            this.cbx_MaDoiTuong.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance31.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbx_MaDoiTuong.DisplayLayout.Override.TemplateAddRowAppearance = appearance31;
            this.cbx_MaDoiTuong.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cbx_MaDoiTuong.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cbx_MaDoiTuong.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cbx_MaDoiTuong.DisplayMember = "";
            this.cbx_MaDoiTuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_MaDoiTuong.Location = new System.Drawing.Point(132, 29);
            this.cbx_MaDoiTuong.Name = "cbx_MaDoiTuong";
            this.cbx_MaDoiTuong.Size = new System.Drawing.Size(125, 22);
            this.cbx_MaDoiTuong.TabIndex = 35;
            this.cbx_MaDoiTuong.ValueMember = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Đối tượng";
            // 
            // dt_tungay
            // 
            this.dt_tungay.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.dt_tungay.FormatProvider = new System.Globalization.CultureInfo("vi-VN");
            this.dt_tungay.Location = new System.Drawing.Point(132, 67);
            this.dt_tungay.Name = "dt_tungay";
            this.dt_tungay.Size = new System.Drawing.Size(125, 21);
            this.dt_tungay.TabIndex = 1;
            // 
            // lbl_tile_benhvien
            // 
            this.lbl_tile_benhvien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance32.BackColor2 = System.Drawing.Color.White;
            appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance32.FontData.BoldAsString = "True";
            appearance32.FontData.SizeInPoints = 16F;
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance32.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.lbl_tile_benhvien.Appearance = appearance32;
            this.lbl_tile_benhvien.BackColor = System.Drawing.Color.Tan;
            this.lbl_tile_benhvien.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lbl_tile_benhvien.Location = new System.Drawing.Point(0, 0);
            this.lbl_tile_benhvien.Name = "lbl_tile_benhvien";
            this.lbl_tile_benhvien.Size = new System.Drawing.Size(840, 35);
            this.lbl_tile_benhvien.TabIndex = 11;
            this.lbl_tile_benhvien.Text = "Danh Mục Báo Cáo";
            // 
            // ultraDataSource1
            // 
            this.ultraDataSource1.Band.Columns.AddRange(new object[] {
            ultraDataColumn5,
            ultraDataColumn6});
            // 
            // ultraDataSource2
            // 
            this.ultraDataSource2.Band.Columns.AddRange(new object[] {
            ultraDataColumn7,
            ultraDataColumn8});
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.imageList2;
            this.treeView1.ItemHeight = 22;
            this.treeView1.Location = new System.Drawing.Point(0, 40);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "1";
            treeNode5.Text = "Báo cáo bác sĩ gửi";
            treeNode6.Name = "2";
            treeNode6.Text = "Thống kê doanh thu theo phòng";
            treeNode7.Name = "3";
            treeNode7.Text = "Doanh thu theo đối tượng khám";
            treeNode8.Name = "4";
            treeNode8.Text = "Bác sĩ gửi chi tiết";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.Size = new System.Drawing.Size(328, 307);
            this.treeView1.TabIndex = 13;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Caddo Girl.ICO");
            this.imageList2.Images.SetKeyName(1, "Potteryf.ICO");
            this.imageList2.Images.SetKeyName(2, "Rosette2.ICO");
            this.imageList2.Images.SetKeyName(3, "Seal of Osage Nation.ICO");
            this.imageList2.Images.SetKeyName(4, "Southern Straight.ICO");
            this.imageList2.Images.SetKeyName(5, "Tipi Mail.ICO");
            this.imageList2.Images.SetKeyName(6, "Water Bird.ICO");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ChonBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 349);
            this.Controls.Add(this.btnBaocao);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbl_tile_benhvien);
            this.Controls.Add(this.treeView1);
            this.Name = "ChonBaoCao";
            this.Text = "Chọn báo cáo";
            this.Load += new System.EventHandler(this.ChonBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_denngay)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_MaDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_tungay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dt_denngay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraButton btnBaocao;
        private Infragistics.Win.Misc.UltraButton btnThoat;
        private System.Windows.Forms.GroupBox groupBox2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dt_tungay;
        private Infragistics.Win.Misc.UltraLabel lbl_tile_benhvien;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbx_MaDoiTuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}