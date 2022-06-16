namespace RFSystem
{
    partial class 本地数据库查询
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
            this.nudCopy = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPatchPrint = new System.Windows.Forms.Button();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.ColumnFACT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPATCH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStoreManDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSUPPLIER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVerpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMenge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrintCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YWTM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PZH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RKRQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSupplier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOrderNo = new System.Windows.Forms.TextBox();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSubPlant = new System.Windows.Forms.TextBox();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudCopy
            // 
            this.nudCopy.Location = new System.Drawing.Point(12, 324);
            this.nudCopy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopy.Name = "nudCopy";
            this.nudCopy.Size = new System.Drawing.Size(120, 26);
            this.nudCopy.TabIndex = 1109;
            this.nudCopy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 301);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1106;
            this.label10.Text = "打印份数：";
            // 
            // cmbLabelType
            // 
            this.cmbLabelType.FormattingEnabled = true;
            this.cmbLabelType.Items.AddRange(new object[] {
            "普通标签",
            "RFID标签"});
            this.cmbLabelType.Location = new System.Drawing.Point(12, 270);
            this.cmbLabelType.Name = "cmbLabelType";
            this.cmbLabelType.Size = new System.Drawing.Size(120, 28);
            this.cmbLabelType.TabIndex = 1111;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 1112;
            this.label2.Text = "打印类型：";
            // 
            // btnPatchPrint
            // 
            this.btnPatchPrint.Enabled = false;
            this.btnPatchPrint.Location = new System.Drawing.Point(12, 412);
            this.btnPatchPrint.Name = "btnPatchPrint";
            this.btnPatchPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPatchPrint.TabIndex = 1108;
            this.btnPatchPrint.Text = "批量打印";
            this.btnPatchPrint.UseVisualStyleBackColor = true;
            this.btnPatchPrint.Click += new System.EventHandler(this.btnPatchPrint_Click);
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(12, 218);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(120, 26);
            this.txtPrinter.TabIndex = 1105;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(12, 356);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPrint.TabIndex = 1107;
            this.btnPrint.Text = "单个打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 1104;
            this.label11.Text = "打印机：";
            // 
            // dataGridViewPrinterList
            // 
            this.dataGridViewPrinterList.AllowUserToAddRows = false;
            this.dataGridViewPrinterList.AllowUserToResizeRows = false;
            this.dataGridViewPrinterList.ColumnHeadersHeight = 30;
            this.dataGridViewPrinterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPrinterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.columnPAddress,
            this.columnSocket});
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(120, 180);
            this.dataGridViewPrinterList.TabIndex = 1110;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrinterName";
            this.dataGridViewTextBoxColumn1.HeaderText = "打印机";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // columnPAddress
            // 
            this.columnPAddress.DataPropertyName = "PrinterAddress";
            this.columnPAddress.HeaderText = "IP地址";
            this.columnPAddress.Name = "columnPAddress";
            this.columnPAddress.ReadOnly = true;
            this.columnPAddress.Visible = false;
            // 
            // columnSocket
            // 
            this.columnSocket.DataPropertyName = "PrinterSocket";
            this.columnSocket.HeaderText = "端口号";
            this.columnSocket.Name = "columnSocket";
            this.columnSocket.ReadOnly = true;
            this.columnSocket.Visible = false;
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.AllowUserToAddRows = false;
            this.dataGridViewStock.AllowUserToResizeRows = false;
            this.dataGridViewStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStock.ColumnHeadersHeight = 30;
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFACT_NO,
            this.ColumnPRODUCT_NO,
            this.ColumnPATCH_NO,
            this.ColumnSLocation,
            this.ColumnPRODUCT_NAME,
            this.ColumnUNIT,
            this.ColumnBIN,
            this.ColumnBct1,
            this.ColumnBct60,
            this.ColumnBct61,
            this.ColumnBct70,
            this.ColumnBct71,
            this.ColumnStoreManDetail,
            this.ColumnSUPPLIER_NO,
            this.ColumnBillNo,
            this.ColumnPName,
            this.ColumnWeight,
            this.ColumnVerpr,
            this.ColumnMenge,
            this.ColumnPrintCount,
            this.YWTM,
            this.PZH,
            this.RKRQ});
            this.dataGridViewStock.Location = new System.Drawing.Point(138, 148);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.RowHeadersVisible = false;
            this.dataGridViewStock.RowTemplate.Height = 23;
            this.dataGridViewStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStock.Size = new System.Drawing.Size(878, 413);
            this.dataGridViewStock.TabIndex = 1113;
            this.dataGridViewStock.SelectionChanged += new System.EventHandler(this.dataGridViewStock_SelectionChanged);
            // 
            // ColumnFACT_NO
            // 
            this.ColumnFACT_NO.DataPropertyName = "gch";
            this.ColumnFACT_NO.HeaderText = "公司号";
            this.ColumnFACT_NO.Name = "ColumnFACT_NO";
            this.ColumnFACT_NO.ReadOnly = true;
            this.ColumnFACT_NO.Width = 76;
            // 
            // ColumnPRODUCT_NO
            // 
            this.ColumnPRODUCT_NO.DataPropertyName = "product_no";
            this.ColumnPRODUCT_NO.HeaderText = "物料号";
            this.ColumnPRODUCT_NO.Name = "ColumnPRODUCT_NO";
            this.ColumnPRODUCT_NO.ReadOnly = true;
            this.ColumnPRODUCT_NO.Width = 76;
            // 
            // ColumnPATCH_NO
            // 
            this.ColumnPATCH_NO.DataPropertyName = "patch";
            this.ColumnPATCH_NO.HeaderText = "批次号";
            this.ColumnPATCH_NO.Name = "ColumnPATCH_NO";
            this.ColumnPATCH_NO.ReadOnly = true;
            this.ColumnPATCH_NO.Width = 76;
            // 
            // ColumnSLocation
            // 
            this.ColumnSLocation.DataPropertyName = "SL";
            this.ColumnSLocation.HeaderText = "库存地点";
            this.ColumnSLocation.Name = "ColumnSLocation";
            this.ColumnSLocation.ReadOnly = true;
            this.ColumnSLocation.Width = 90;
            // 
            // ColumnPRODUCT_NAME
            // 
            this.ColumnPRODUCT_NAME.DataPropertyName = "product_desc";
            this.ColumnPRODUCT_NAME.HeaderText = "物品名称";
            this.ColumnPRODUCT_NAME.Name = "ColumnPRODUCT_NAME";
            this.ColumnPRODUCT_NAME.ReadOnly = true;
            this.ColumnPRODUCT_NAME.Width = 90;
            // 
            // ColumnUNIT
            // 
            this.ColumnUNIT.DataPropertyName = "unit";
            this.ColumnUNIT.HeaderText = "单位";
            this.ColumnUNIT.Name = "ColumnUNIT";
            this.ColumnUNIT.ReadOnly = true;
            this.ColumnUNIT.Width = 62;
            // 
            // ColumnBIN
            // 
            this.ColumnBIN.DataPropertyName = "bin1";
            this.ColumnBIN.HeaderText = "货位1";
            this.ColumnBIN.Name = "ColumnBIN";
            this.ColumnBIN.ReadOnly = true;
            this.ColumnBIN.Width = 70;
            // 
            // ColumnBct1
            // 
            this.ColumnBct1.DataPropertyName = "bin1_qty";
            this.ColumnBct1.HeaderText = "货位1数量";
            this.ColumnBct1.Name = "ColumnBct1";
            this.ColumnBct1.ReadOnly = true;
            this.ColumnBct1.Width = 98;
            // 
            // ColumnBct60
            // 
            this.ColumnBct60.DataPropertyName = "bin2";
            this.ColumnBct60.HeaderText = "货位2";
            this.ColumnBct60.Name = "ColumnBct60";
            this.ColumnBct60.ReadOnly = true;
            this.ColumnBct60.Width = 70;
            // 
            // ColumnBct61
            // 
            this.ColumnBct61.DataPropertyName = "bin2_qty";
            this.ColumnBct61.HeaderText = "货位2数量";
            this.ColumnBct61.Name = "ColumnBct61";
            this.ColumnBct61.ReadOnly = true;
            this.ColumnBct61.Width = 98;
            // 
            // ColumnBct70
            // 
            this.ColumnBct70.DataPropertyName = "bin3";
            this.ColumnBct70.HeaderText = "货位3";
            this.ColumnBct70.Name = "ColumnBct70";
            this.ColumnBct70.ReadOnly = true;
            this.ColumnBct70.Width = 70;
            // 
            // ColumnBct71
            // 
            this.ColumnBct71.DataPropertyName = "bin3_qty";
            this.ColumnBct71.HeaderText = "货位3数量";
            this.ColumnBct71.Name = "ColumnBct71";
            this.ColumnBct71.ReadOnly = true;
            this.ColumnBct71.Width = 98;
            // 
            // ColumnStoreManDetail
            // 
            this.ColumnStoreManDetail.DataPropertyName = "storeman";
            this.ColumnStoreManDetail.HeaderText = "保管员";
            this.ColumnStoreManDetail.Name = "ColumnStoreManDetail";
            this.ColumnStoreManDetail.ReadOnly = true;
            this.ColumnStoreManDetail.Width = 76;
            // 
            // ColumnSUPPLIER_NO
            // 
            this.ColumnSUPPLIER_NO.DataPropertyName = "ejc";
            this.ColumnSUPPLIER_NO.HeaderText = "二级厂码";
            this.ColumnSUPPLIER_NO.Name = "ColumnSUPPLIER_NO";
            this.ColumnSUPPLIER_NO.ReadOnly = true;
            this.ColumnSUPPLIER_NO.Width = 90;
            // 
            // ColumnBillNo
            // 
            this.ColumnBillNo.DataPropertyName = "order_no";
            this.ColumnBillNo.HeaderText = "订单号";
            this.ColumnBillNo.Name = "ColumnBillNo";
            this.ColumnBillNo.ReadOnly = true;
            this.ColumnBillNo.ToolTipText = "Ebeln";
            this.ColumnBillNo.Width = 76;
            // 
            // ColumnPName
            // 
            this.ColumnPName.DataPropertyName = "supplier";
            this.ColumnPName.HeaderText = "供应商";
            this.ColumnPName.Name = "ColumnPName";
            this.ColumnPName.ReadOnly = true;
            this.ColumnPName.ToolTipText = "Name1";
            this.ColumnPName.Width = 76;
            // 
            // ColumnWeight
            // 
            this.ColumnWeight.DataPropertyName = "weight";
            this.ColumnWeight.HeaderText = "重量";
            this.ColumnWeight.Name = "ColumnWeight";
            this.ColumnWeight.ReadOnly = true;
            this.ColumnWeight.Width = 62;
            // 
            // ColumnVerpr
            // 
            this.ColumnVerpr.DataPropertyName = "amount";
            this.ColumnVerpr.HeaderText = "金额";
            this.ColumnVerpr.Name = "ColumnVerpr";
            this.ColumnVerpr.ReadOnly = true;
            this.ColumnVerpr.Width = 62;
            // 
            // ColumnMenge
            // 
            this.ColumnMenge.DataPropertyName = "stock_qty";
            this.ColumnMenge.HeaderText = "库存数量";
            this.ColumnMenge.Name = "ColumnMenge";
            this.ColumnMenge.ReadOnly = true;
            this.ColumnMenge.Width = 90;
            // 
            // ColumnPrintCount
            // 
            this.ColumnPrintCount.DataPropertyName = "PrintCount";
            this.ColumnPrintCount.HeaderText = "打印份数";
            this.ColumnPrintCount.Name = "ColumnPrintCount";
            this.ColumnPrintCount.ReadOnly = true;
            this.ColumnPrintCount.Width = 90;
            // 
            // YWTM
            // 
            this.YWTM.DataPropertyName = "ywtm";
            this.YWTM.HeaderText = "一维条码";
            this.YWTM.Name = "YWTM";
            this.YWTM.ReadOnly = true;
            this.YWTM.Width = 90;
            // 
            // PZH
            // 
            this.PZH.DataPropertyName = "pzh";
            this.PZH.HeaderText = "凭证号";
            this.PZH.Name = "PZH";
            this.PZH.ReadOnly = true;
            this.PZH.Width = 76;
            // 
            // RKRQ
            // 
            this.RKRQ.DataPropertyName = "rkrq";
            this.RKRQ.HeaderText = "入库日期";
            this.RKRQ.Name = "RKRQ";
            this.RKRQ.ReadOnly = true;
            this.RKRQ.Width = 90;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxSupplier);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxOrderNo);
            this.groupBox1.Controls.Add(this.textBoxBin);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxDes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxStoreMan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxSubPlant);
            this.groupBox1.Controls.Add(this.textBoxBarcode);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBoxPlant);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxSLocation);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(138, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(878, 130);
            this.groupBox1.TabIndex = 1114;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地数据库查询";
            // 
            // textBoxSupplier
            // 
            this.textBoxSupplier.Location = new System.Drawing.Point(306, 91);
            this.textBoxSupplier.Name = "textBoxSupplier";
            this.textBoxSupplier.Size = new System.Drawing.Size(120, 26);
            this.textBoxSupplier.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 87;
            this.label5.Text = "供应商：";
            // 
            // textBoxOrderNo
            // 
            this.textBoxOrderNo.Location = new System.Drawing.Point(511, 59);
            this.textBoxOrderNo.Name = "textBoxOrderNo";
            this.textBoxOrderNo.Size = new System.Drawing.Size(120, 26);
            this.textBoxOrderNo.TabIndex = 60;
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(306, 59);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(120, 26);
            this.textBoxBin.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "货位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "订单号：";
            // 
            // textBoxDes
            // 
            this.textBoxDes.Location = new System.Drawing.Point(95, 59);
            this.textBoxDes.Name = "textBoxDes";
            this.textBoxDes.Size = new System.Drawing.Size(120, 26);
            this.textBoxDes.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 83;
            this.label1.Text = "物品名称：";
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.Location = new System.Drawing.Point(511, 91);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.ReadOnly = true;
            this.textBoxStoreMan.Size = new System.Drawing.Size(120, 26);
            this.textBoxStoreMan.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 81;
            this.label3.Text = "保管员：";
            // 
            // textBoxSubPlant
            // 
            this.textBoxSubPlant.Location = new System.Drawing.Point(95, 91);
            this.textBoxSubPlant.Name = "textBoxSubPlant";
            this.textBoxSubPlant.Size = new System.Drawing.Size(120, 26);
            this.textBoxSubPlant.TabIndex = 70;
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Location = new System.Drawing.Point(511, 25);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(120, 26);
            this.textBoxBarcode.TabIndex = 30;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(752, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 50);
            this.btnSelect.TabIndex = 100;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "条码号：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(95, 25);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(120, 28);
            this.comboBoxPlant.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "公司：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(306, 25);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(120, 28);
            this.comboBoxSLocation.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "库存地点：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "二级厂：";
            // 
            // 本地数据库查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 573);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewStock);
            this.Controls.Add(this.nudCopy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbLabelType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPatchPrint);
            this.Controls.Add(this.txtPrinter);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridViewPrinterList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "本地数据库查询";
            this.Text = "本地数据库查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.本地数据库查询_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudCopy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbLabelType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPatchPrint;
        private System.Windows.Forms.TextBox txtPrinter;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewPrinterList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSocket;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFACT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPRODUCT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPATCH_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBct1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBct60;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBct61;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBct70;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBct71;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStoreManDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSUPPLIER_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVerpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMenge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrintCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn YWTM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PZH;
        private System.Windows.Forms.DataGridViewTextBoxColumn RKRQ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSupplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOrderNo;
        private System.Windows.Forms.TextBox textBoxBin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStoreMan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSubPlant;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxPlant;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxSLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
    }
}