namespace RFSystem
{
    partial class 保管员物料查询
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
            this.btnPatchPrint = new System.Windows.Forms.Button();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSubPlant = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlant = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.deliveryLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invBin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodLineDeptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodLineDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiveId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legacyItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemUom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invLogicCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invBillTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invQualifiedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invOrQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invPhysicCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invResponserUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invResponserDeptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custodianJobId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inspectorJobId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invTransactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invTotPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            this.SuspendLayout();
            // 
            // nudCopy
            // 
            this.nudCopy.Location = new System.Drawing.Point(12, 484);
            this.nudCopy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopy.Name = "nudCopy";
            this.nudCopy.Size = new System.Drawing.Size(120, 26);
            this.nudCopy.TabIndex = 1125;
            this.nudCopy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 461);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1122;
            this.label10.Text = "打印份数：";
            // 
            // btnPatchPrint
            // 
            this.btnPatchPrint.Enabled = false;
            this.btnPatchPrint.Location = new System.Drawing.Point(12, 572);
            this.btnPatchPrint.Name = "btnPatchPrint";
            this.btnPatchPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPatchPrint.TabIndex = 1124;
            this.btnPatchPrint.Text = "批量打印";
            this.btnPatchPrint.UseVisualStyleBackColor = true;
            this.btnPatchPrint.Click += new System.EventHandler(this.btnPatchPrint_Click);
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(12, 378);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(120, 26);
            this.txtPrinter.TabIndex = 1121;
            this.txtPrinter.TextChanged += new System.EventHandler(this.txtPrinter_TextChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(12, 516);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPrint.TabIndex = 1123;
            this.btnPrint.Text = "单个打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 1120;
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
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(12, 172);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(120, 180);
            this.dataGridViewPrinterList.TabIndex = 1126;
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtSubPlant);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPlant);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMaterial);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(138, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(826, 90);
            this.groupBox2.TabIndex = 1127;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "过滤信息";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(700, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 50);
            this.button2.TabIndex = 50;
            this.button2.Text = "过滤";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSubPlant
            // 
            this.txtSubPlant.Location = new System.Drawing.Point(548, 37);
            this.txtSubPlant.Name = "txtSubPlant";
            this.txtSubPlant.Size = new System.Drawing.Size(120, 26);
            this.txtSubPlant.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "产线部门代码：";
            // 
            // txtPlant
            // 
            this.txtPlant.Location = new System.Drawing.Point(309, 37);
            this.txtPlant.Name = "txtPlant";
            this.txtPlant.Size = new System.Drawing.Size(120, 26);
            this.txtPlant.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "供货商：";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(112, 37);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(120, 26);
            this.txtMaterial.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "物料代码：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 64);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 50);
            this.btnSelect.TabIndex = 30007;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxStoreMan.Location = new System.Drawing.Point(12, 32);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.Size = new System.Drawing.Size(120, 26);
            this.textBoxStoreMan.TabIndex = 30009;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 30008;
            this.label1.Text = "保管员岗位号：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(120, 26);
            this.textBox1.TabIndex = 30024;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 30023;
            this.label6.Text = "查询数据：";
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.AllowUserToAddRows = false;
            this.dataGridViewStock.AllowUserToResizeRows = false;
            this.dataGridViewStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStock.ColumnHeadersHeight = 30;
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deliveryLineId,
            this.batchId,
            this.invBin,
            this.itemId,
            this.itemName,
            this.itemDesc,
            this.supplierId,
            this.supplierName,
            this.prodLineDeptId,
            this.prodLineDeptName,
            this.receiveId,
            this.legacyItemCode,
            this.itemUom,
            this.invLogicCode,
            this.invBillTo,
            this.invQualifiedQty,
            this.invOrQty,
            this.invQty,
            this.invPhysicCode,
            this.invResponserUserId,
            this.invResponserDeptId,
            this.accountTime,
            this.accountUserId,
            this.orderLineId,
            this.custodianJobId,
            this.inspectorJobId,
            this.transactionId,
            this.invTransactionId,
            this.invPrice,
            this.invTotPrice,
            this.depositType,
            this.depositQty,
            this.depositAmt,
            this.depositDate,
            this.productionLine,
            this.unitWeight});
            this.dataGridViewStock.Location = new System.Drawing.Point(138, 108);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.RowHeadersVisible = false;
            this.dataGridViewStock.RowTemplate.Height = 23;
            this.dataGridViewStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewStock.Size = new System.Drawing.Size(826, 476);
            this.dataGridViewStock.TabIndex = 30025;
            // 
            // deliveryLineId
            // 
            this.deliveryLineId.DataPropertyName = "deliveryLineId";
            this.deliveryLineId.HeaderText = "送货单号";
            this.deliveryLineId.Name = "deliveryLineId";
            this.deliveryLineId.ReadOnly = true;
            this.deliveryLineId.Width = 90;
            // 
            // batchId
            // 
            this.batchId.DataPropertyName = "batchId";
            this.batchId.HeaderText = "批次号";
            this.batchId.Name = "batchId";
            this.batchId.ReadOnly = true;
            this.batchId.Width = 76;
            // 
            // invBin
            // 
            this.invBin.DataPropertyName = "invBin";
            this.invBin.HeaderText = "储位";
            this.invBin.Name = "invBin";
            this.invBin.ReadOnly = true;
            this.invBin.Width = 62;
            // 
            // itemId
            // 
            this.itemId.DataPropertyName = "itemId";
            this.itemId.HeaderText = "物料代码";
            this.itemId.Name = "itemId";
            this.itemId.ReadOnly = true;
            this.itemId.Width = 90;
            // 
            // itemName
            // 
            this.itemName.DataPropertyName = "itemName";
            this.itemName.HeaderText = "物料名称";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 90;
            // 
            // itemDesc
            // 
            this.itemDesc.DataPropertyName = "itemDesc";
            this.itemDesc.HeaderText = "物料短描述";
            this.itemDesc.Name = "itemDesc";
            this.itemDesc.ReadOnly = true;
            this.itemDesc.Width = 104;
            // 
            // supplierId
            // 
            this.supplierId.DataPropertyName = "supplierId";
            this.supplierId.HeaderText = "供货商代码";
            this.supplierId.Name = "supplierId";
            this.supplierId.ReadOnly = true;
            this.supplierId.Width = 104;
            // 
            // supplierName
            // 
            this.supplierName.DataPropertyName = "supplierName";
            this.supplierName.HeaderText = "供货商名称";
            this.supplierName.Name = "supplierName";
            this.supplierName.ReadOnly = true;
            this.supplierName.Width = 104;
            // 
            // prodLineDeptId
            // 
            this.prodLineDeptId.DataPropertyName = "prodLineDeptId";
            this.prodLineDeptId.HeaderText = "产线部门代码";
            this.prodLineDeptId.Name = "prodLineDeptId";
            this.prodLineDeptId.ReadOnly = true;
            this.prodLineDeptId.Width = 118;
            // 
            // prodLineDeptName
            // 
            this.prodLineDeptName.DataPropertyName = "prodLineDeptName";
            this.prodLineDeptName.HeaderText = "产线部门名称";
            this.prodLineDeptName.Name = "prodLineDeptName";
            this.prodLineDeptName.ReadOnly = true;
            this.prodLineDeptName.Width = 118;
            // 
            // receiveId
            // 
            this.receiveId.DataPropertyName = "receiveId";
            this.receiveId.HeaderText = "收货单号";
            this.receiveId.Name = "receiveId";
            this.receiveId.ReadOnly = true;
            this.receiveId.Width = 90;
            // 
            // legacyItemCode
            // 
            this.legacyItemCode.DataPropertyName = "legacyItemCode";
            this.legacyItemCode.HeaderText = "老系统物料代码";
            this.legacyItemCode.Name = "legacyItemCode";
            this.legacyItemCode.ReadOnly = true;
            this.legacyItemCode.Width = 132;
            // 
            // itemUom
            // 
            this.itemUom.DataPropertyName = "itemUom";
            this.itemUom.HeaderText = "计量单位";
            this.itemUom.Name = "itemUom";
            this.itemUom.ReadOnly = true;
            this.itemUom.Width = 90;
            // 
            // invLogicCode
            // 
            this.invLogicCode.DataPropertyName = "invLogicCode";
            this.invLogicCode.HeaderText = "逻辑库区";
            this.invLogicCode.Name = "invLogicCode";
            this.invLogicCode.ReadOnly = true;
            this.invLogicCode.Width = 90;
            // 
            // invBillTo
            // 
            this.invBillTo.DataPropertyName = "invBillTo";
            this.invBillTo.HeaderText = "库存账套";
            this.invBillTo.Name = "invBillTo";
            this.invBillTo.ReadOnly = true;
            this.invBillTo.Width = 90;
            // 
            // invQualifiedQty
            // 
            this.invQualifiedQty.DataPropertyName = "invQualifiedQty";
            this.invQualifiedQty.HeaderText = "送货合格数量";
            this.invQualifiedQty.Name = "invQualifiedQty";
            this.invQualifiedQty.ReadOnly = true;
            this.invQualifiedQty.Width = 118;
            // 
            // invOrQty
            // 
            this.invOrQty.DataPropertyName = "invOrQty";
            this.invOrQty.HeaderText = "库存预约量";
            this.invOrQty.Name = "invOrQty";
            this.invOrQty.ReadOnly = true;
            this.invOrQty.Width = 104;
            // 
            // invQty
            // 
            this.invQty.DataPropertyName = "invQty";
            this.invQty.HeaderText = "库存数量";
            this.invQty.Name = "invQty";
            this.invQty.ReadOnly = true;
            this.invQty.Width = 90;
            // 
            // invPhysicCode
            // 
            this.invPhysicCode.DataPropertyName = "invPhysicCode";
            this.invPhysicCode.HeaderText = "物理库区";
            this.invPhysicCode.Name = "invPhysicCode";
            this.invPhysicCode.ReadOnly = true;
            this.invPhysicCode.Width = 90;
            // 
            // invResponserUserId
            // 
            this.invResponserUserId.DataPropertyName = "invResponserUserId";
            this.invResponserUserId.HeaderText = "库存责任人";
            this.invResponserUserId.Name = "invResponserUserId";
            this.invResponserUserId.ReadOnly = true;
            this.invResponserUserId.Width = 104;
            // 
            // invResponserDeptId
            // 
            this.invResponserDeptId.DataPropertyName = "invResponserDeptId";
            this.invResponserDeptId.HeaderText = "责任人部门";
            this.invResponserDeptId.Name = "invResponserDeptId";
            this.invResponserDeptId.ReadOnly = true;
            this.invResponserDeptId.Width = 104;
            // 
            // accountTime
            // 
            this.accountTime.DataPropertyName = "accountTime";
            this.accountTime.HeaderText = "收货日期";
            this.accountTime.Name = "accountTime";
            this.accountTime.ReadOnly = true;
            this.accountTime.Width = 90;
            // 
            // accountUserId
            // 
            this.accountUserId.DataPropertyName = "accountUserId";
            this.accountUserId.HeaderText = "收货人";
            this.accountUserId.Name = "accountUserId";
            this.accountUserId.ReadOnly = true;
            this.accountUserId.Width = 76;
            // 
            // orderLineId
            // 
            this.orderLineId.DataPropertyName = "orderLineId";
            this.orderLineId.HeaderText = "订单行号";
            this.orderLineId.Name = "orderLineId";
            this.orderLineId.ReadOnly = true;
            this.orderLineId.Width = 90;
            // 
            // custodianJobId
            // 
            this.custodianJobId.DataPropertyName = "custodianJobId";
            this.custodianJobId.HeaderText = "保管员";
            this.custodianJobId.Name = "custodianJobId";
            this.custodianJobId.ReadOnly = true;
            this.custodianJobId.Width = 76;
            // 
            // inspectorJobId
            // 
            this.inspectorJobId.DataPropertyName = "inspectorJobId";
            this.inspectorJobId.HeaderText = "验收员";
            this.inspectorJobId.Name = "inspectorJobId";
            this.inspectorJobId.ReadOnly = true;
            this.inspectorJobId.Width = 76;
            // 
            // transactionId
            // 
            this.transactionId.DataPropertyName = "transactionId";
            this.transactionId.HeaderText = "库存明细交易号";
            this.transactionId.Name = "transactionId";
            this.transactionId.ReadOnly = true;
            this.transactionId.Width = 132;
            // 
            // invTransactionId
            // 
            this.invTransactionId.DataPropertyName = "invTransactionId";
            this.invTransactionId.HeaderText = "库存主表交易号";
            this.invTransactionId.Name = "invTransactionId";
            this.invTransactionId.ReadOnly = true;
            this.invTransactionId.Width = 132;
            // 
            // invPrice
            // 
            this.invPrice.DataPropertyName = "invPrice";
            this.invPrice.HeaderText = "库存单价";
            this.invPrice.Name = "invPrice";
            this.invPrice.ReadOnly = true;
            this.invPrice.Width = 90;
            // 
            // invTotPrice
            // 
            this.invTotPrice.DataPropertyName = "invTotPrice";
            this.invTotPrice.HeaderText = "库存总价";
            this.invTotPrice.Name = "invTotPrice";
            this.invTotPrice.ReadOnly = true;
            this.invTotPrice.Width = 90;
            // 
            // depositType
            // 
            this.depositType.DataPropertyName = "depositType";
            this.depositType.HeaderText = "入库性质";
            this.depositType.Name = "depositType";
            this.depositType.ReadOnly = true;
            this.depositType.Width = 90;
            // 
            // depositQty
            // 
            this.depositQty.DataPropertyName = "depositQty";
            this.depositQty.HeaderText = "入库数量";
            this.depositQty.Name = "depositQty";
            this.depositQty.ReadOnly = true;
            this.depositQty.Width = 90;
            // 
            // depositAmt
            // 
            this.depositAmt.DataPropertyName = "depositAmt";
            this.depositAmt.HeaderText = "入库金额";
            this.depositAmt.Name = "depositAmt";
            this.depositAmt.ReadOnly = true;
            this.depositAmt.Width = 90;
            // 
            // depositDate
            // 
            this.depositDate.DataPropertyName = "depositDate";
            this.depositDate.HeaderText = "入库日期";
            this.depositDate.Name = "depositDate";
            this.depositDate.ReadOnly = true;
            this.depositDate.Width = 90;
            // 
            // productionLine
            // 
            this.productionLine.DataPropertyName = "productionLine";
            this.productionLine.HeaderText = "产线";
            this.productionLine.Name = "productionLine";
            this.productionLine.ReadOnly = true;
            this.productionLine.Width = 62;
            // 
            // unitWeight
            // 
            this.unitWeight.DataPropertyName = "unitWeight";
            this.unitWeight.HeaderText = "单重";
            this.unitWeight.Name = "unitWeight";
            this.unitWeight.ReadOnly = true;
            this.unitWeight.Width = 62;
            // 
            // cmbLabelType
            // 
            this.cmbLabelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelType.FormattingEnabled = true;
            this.cmbLabelType.Items.AddRange(new object[] {
            "普通标签",
            "RFID标签"});
            this.cmbLabelType.Location = new System.Drawing.Point(12, 430);
            this.cmbLabelType.Name = "cmbLabelType";
            this.cmbLabelType.Size = new System.Drawing.Size(120, 28);
            this.cmbLabelType.TabIndex = 30026;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 30027;
            this.label3.Text = "打印类型：";
            // 
            // 保管员物料查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 596);
            this.Controls.Add(this.cmbLabelType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewStock);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.textBoxStoreMan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nudCopy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPatchPrint);
            this.Controls.Add(this.txtPrinter);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridViewPrinterList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "保管员物料查询";
            this.Text = "保管员物料查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.保管员物料查询_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudCopy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPatchPrint;
        private System.Windows.Forms.TextBox txtPrinter;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewPrinterList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSocket;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSubPlant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox textBoxStoreMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchId;
        private System.Windows.Forms.DataGridViewTextBoxColumn invBin;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodLineDeptId;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodLineDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiveId;
        private System.Windows.Forms.DataGridViewTextBoxColumn legacyItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemUom;
        private System.Windows.Forms.DataGridViewTextBoxColumn invLogicCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn invBillTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn invQualifiedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn invOrQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn invQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn invPhysicCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn invResponserUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn invResponserDeptId;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn custodianJobId;
        private System.Windows.Forms.DataGridViewTextBoxColumn inspectorJobId;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn invTransactionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn invPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn invTotPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn depositType;
        private System.Windows.Forms.DataGridViewTextBoxColumn depositQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn depositAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn depositDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitWeight;
        private System.Windows.Forms.ComboBox cmbLabelType;
        private System.Windows.Forms.Label label3;
    }
}