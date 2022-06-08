using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RFSystem.Properties;
using System.Threading;
using System.Collections;
using System.Net.Sockets;

namespace RFSystem
{
    public class 数据库查询 : Form
    {
        private Button btnPatchPrint;
        private Button btnPrint;
        private Button btnSelect;
        private ComboBox cmbLabelType;
        private IContainer components;
        private DataGridView dataGridViewPrinterList;
        private DataGridView dataGridViewStock;
        private DataTable dtPlantList;
        private DataTable dtPrinterList;
        private DataTable dtResult;
        private DataTable dtStoreLocusList;
        private Label label10;
        private Label label11;
        private Thread thread;
        private TextBox txtPrinter;
        private UserInfo userItem;
        private TextBox textBoxStoreMan;
        private Label label1;
        private DataGridViewTextBoxColumn deliveryLineId;
        private DataGridViewTextBoxColumn batchId;
        private DataGridViewTextBoxColumn itemId;
        private DataGridViewTextBoxColumn itemName;
        private DataGridViewTextBoxColumn itemDesc;
        private DataGridViewTextBoxColumn supplierId;
        private DataGridViewTextBoxColumn supplierName;
        private DataGridViewTextBoxColumn prodLineDeptId;
        private DataGridViewTextBoxColumn prodLineDeptName;
        private DataGridViewTextBoxColumn receiveId;
        private DataGridViewTextBoxColumn legacyItemCode;
        private DataGridViewTextBoxColumn itemUom;
        private DataGridViewTextBoxColumn invLogicCode;
        private DataGridViewTextBoxColumn invBillTo;
        private DataGridViewTextBoxColumn invQualifiedQty;
        private DataGridViewTextBoxColumn invOrQty;
        private DataGridViewTextBoxColumn invQty;
        private DataGridViewTextBoxColumn invPhysicCode;
        private DataGridViewTextBoxColumn invResponserUserId;
        private DataGridViewTextBoxColumn invResponserDeptId;
        private DataGridViewTextBoxColumn accountTime;
        private DataGridViewTextBoxColumn accountUserId;
        private DataGridViewTextBoxColumn orderLineId;
        private DataGridViewTextBoxColumn custodianJobId;
        private DataGridViewTextBoxColumn inspectorJobId;
        private DataGridViewTextBoxColumn transactionId;
        private DataGridViewTextBoxColumn invTransactionId;
        private DataGridViewTextBoxColumn invPrice;
        private DataGridViewTextBoxColumn invTotPrice;
        private DataGridViewTextBoxColumn depositType;
        private DataGridViewTextBoxColumn depositQty;
        private DataGridViewTextBoxColumn depositAmt;
        private DataGridViewTextBoxColumn depositDate;
        private DataGridViewTextBoxColumn productionLine;
        private DataGridViewTextBoxColumn invBin;
        private DataGridViewTextBoxColumn unitWeight;
        private Label label2;
        private NumericUpDown nudCopy;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn columnPAddress;
        private DataGridViewTextBoxColumn columnSocket;
        private ArrayList userRoles;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.deliveryLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.invBin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPatchPrint = new System.Windows.Forms.Button();
            this.nudCopy = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxStoreMan.Location = new System.Drawing.Point(12, 32);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.Size = new System.Drawing.Size(120, 26);
            this.textBoxStoreMan.TabIndex = 30006;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 30005;
            this.label1.Text = "保管员岗位号：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 64);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 50);
            this.btnSelect.TabIndex = 100;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            this.btnSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
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
            this.deliveryLineId,
            this.batchId,
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
            this.invBin,
            this.unitWeight});
            this.dataGridViewStock.Location = new System.Drawing.Point(138, 12);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.RowHeadersVisible = false;
            this.dataGridViewStock.RowTemplate.Height = 23;
            this.dataGridViewStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStock.Size = new System.Drawing.Size(861, 605);
            this.dataGridViewStock.TabIndex = 110;
            this.dataGridViewStock.SelectionChanged += new System.EventHandler(this.dataGridViewStock_SelectionChanged);
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
            // invBin
            // 
            this.invBin.DataPropertyName = "invBin";
            this.invBin.HeaderText = "储位";
            this.invBin.Name = "invBin";
            this.invBin.ReadOnly = true;
            this.invBin.Width = 62;
            // 
            // unitWeight
            // 
            this.unitWeight.DataPropertyName = "unitWeight";
            this.unitWeight.HeaderText = "单重";
            this.unitWeight.Name = "unitWeight";
            this.unitWeight.ReadOnly = true;
            this.unitWeight.Width = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 409);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1001;
            this.label10.Text = "打印份数：";
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(12, 464);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPrint.TabIndex = 1004;
            this.btnPrint.Text = "单个打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPatchPrint
            // 
            this.btnPatchPrint.Enabled = false;
            this.btnPatchPrint.Location = new System.Drawing.Point(12, 520);
            this.btnPatchPrint.Name = "btnPatchPrint";
            this.btnPatchPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPatchPrint.TabIndex = 1005;
            this.btnPatchPrint.Text = "批量打印";
            this.btnPatchPrint.UseVisualStyleBackColor = true;
            this.btnPatchPrint.Click += new System.EventHandler(this.btnPatchPrint_Click);
            // 
            // nudCopy
            // 
            this.nudCopy.Location = new System.Drawing.Point(12, 432);
            this.nudCopy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopy.Name = "nudCopy";
            this.nudCopy.Size = new System.Drawing.Size(120, 26);
            this.nudCopy.TabIndex = 1006;
            this.nudCopy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 1103;
            this.label2.Text = "打印类型：";
            // 
            // cmbLabelType
            // 
            this.cmbLabelType.FormattingEnabled = true;
            this.cmbLabelType.Items.AddRange(new object[] {
            "普通标签",
            "RFID标签"});
            this.cmbLabelType.Location = new System.Drawing.Point(12, 378);
            this.cmbLabelType.Name = "cmbLabelType";
            this.cmbLabelType.Size = new System.Drawing.Size(120, 28);
            this.cmbLabelType.TabIndex = 1102;
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(12, 326);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(120, 26);
            this.txtPrinter.TabIndex = 102;
            this.txtPrinter.TextChanged += new System.EventHandler(this.txtPrinter_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 101;
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
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(12, 120);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(120, 180);
            this.dataGridViewPrinterList.TabIndex = 1100;
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
            // 数据库查询
            // 
            this.ClientSize = new System.Drawing.Size(1011, 629);
            this.ControlBox = false;
            this.Controls.Add(this.nudCopy);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxStoreMan);
            this.Controls.Add(this.cmbLabelType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPatchPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrinter);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridViewPrinterList);
            this.Controls.Add(this.dataGridViewStock);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "数据库查询";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "本地数据库查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.数据库查询_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 数据库查询(UserInfo userItem, ArrayList userRoles)
        {
            components = null;
            this.userItem = null;
            this.userRoles = null;
            dtPlantList = null;
            dtStoreLocusList = null;
            dtPrinterList = null;
            thread = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;

            if (userItem.isAdmin)
            {
                textBoxStoreMan.ReadOnly = false;
            }

            //this.textBoxStoreMan.Text = this.userItem.userID;
            dtPlantList = DBOperate.GetPlantList(string.Empty);
            dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, string.Empty);

            dataGridViewStock.AutoGenerateColumns = false;
            dtPrinterList = DBOperate.GetPrinterList("''", "''");
            dataGridViewPrinterList.DataSource = dtPrinterList;
            cmbLabelType.Text = "普通标签";
        }

        private void btnPatchPrint_Click(object sender, EventArgs e)
        {
            PrintProductLabelNew_Patch(dataGridViewStock.Rows);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintProductLabelNew_Patch(dataGridViewStock.SelectedRows);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(ShowWaitingMsg));
            thread.Start();
        }

        public string Data_Hex(string old)
        {
            string str = "";

            try
            {
                int num = 0;
                string str2 = "";

                foreach (char ch in old)
                {
                    num = ch;
                    string str3 = string.Format("{0:x2}", Convert.ToUInt32(num.ToString()));
                    str2 += str3;
                }

                str = str2;
            }
            catch (Exception exception)
            {
                CommonFunction.Sys_MsgBox("Failed to convert!!! Please check your input format!" + exception.Message);
            }
            return str;
        }

        private void dataGridViewStock_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewStock.Rows.Count > 0 ) && (dataGridViewStock.SelectedRows.Count > 0))
            {
                //this.txtCopy.Text = this.dataGridViewStock.SelectedRows[0].Cells["ColumnPrintCount"].Value.ToString();
                nudCopy.Text = "1";

                btnPrint.Enabled = true;
                btnPatchPrint.Enabled = true;
            }
            else
            {
                nudCopy.Text = "0";
                btnPrint.Enabled = false;
                btnPatchPrint.Enabled = false;
            }
        }

        private Control GetNextSelectControl(Control activeControl)
        {
            Control nextControl = GetNextControl(activeControl, true);

            if ((!nextControl.Enabled || !nextControl.TabStop) || (nextControl.TabStop && !nextControl.CanSelect))
            {
                nextControl = GetNextSelectControl(nextControl);
            }

            return nextControl;
        }

        private void PrintProductLabelNew_Patch(DataGridViewRowCollection dgvr)
        {
            if (dataGridViewPrinterList.RowCount < 1)
            {
                CommonFunction.Sys_MsgBox("请指定打印机!");
            }
            else
            {
                TcpClient client = new TcpClient();
                string hostname = dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
                int port = int.Parse(dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

                try
                {
                    client.Connect(hostname, port);

                    for (int i = 0; i < dgvr.Count; i++)
                    {
                        string s = string.Empty;

                        string manu = string.Empty;
                        string cert = string.Empty;

                        if (dgvr[i].Cells["deliveryLineId"].Value.ToString().Trim().Length != 0)
                        {
                            DataSet ds17 = GetData.Get_17(dgvr[i].Cells["deliveryLineId"].Value.ToString());

                            if (ds17 != null && ds17.Tables[0].Rows.Count > 0)
                            {
                                manu = ds17.Tables[0].Rows[0]["instructions"].ToString();//说明书
                                cert = ds17.Tables[0].Rows[0]["qualifiedCertificate"].ToString();//合格证
                            }
                        }

                        string f = dgvr[i].Cells["prodLineDeptName"].Value.ToString();//产线部门
                        string proName = dgvr[i].Cells["itemDesc"].Value.ToString();//物料描述
                        string proNo = dgvr[i].Cells["itemId"].Value.ToString();//物料号
                        string patch = dgvr[i].Cells["itemName"].Value.ToString();//物料名称
                        string deNo = dgvr[i].Cells["transactionId"].Value.ToString();//凭证号
                        string ckDate = dgvr[i].Cells["depositDate"].Value.ToString();//入库日期

                        string pC = dgvr[i].Cells["deliveryLineId"].Value.ToString();//送货单号

                        string baoguanyuan = dgvr[i].Cells["custodianJobId"].Value.ToString();//保管员岗位号
                        string supp = dgvr[i].Cells["supplierName"].Value.ToString();//供货单位名称
                        string loca = dgvr[i].Cells["invBin"].Value.ToString();//储位
                        string q = dgvr[i].Cells["invQty"].Value.ToString();//储位数量
                        string u = dgvr[i].Cells["itemUom"].Value.ToString();//单位
                        string w = dgvr[i].Cells["unitWeight"].Value.ToString();//单重
                        string r = dgvr[i].Cells["batchId"].Value.ToString();//批次号
                        string p = dgvr[i].Cells["invPrice"].Value.ToString();//单价
                        string cop = nudCopy.Text;

                        string ywtm = deNo + "-" + proNo;

                        s = ClsCommon.dealData(f, proName, proNo, patch, deNo, ckDate, manu, pC, cert, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, cmbLabelType.Text);
                        client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                        client.GetStream().Flush();
                    }

                    client.Close();
                }
                catch (Exception exception)
                {
                    CommonFunction.Sys_MsgBox(exception.Message);
                }
            }
        }

        private void PrintProductLabelNew_Patch(DataGridViewSelectedRowCollection dgvr)
        {
            if (dataGridViewPrinterList.RowCount < 1)
            {
                CommonFunction.Sys_MsgBox("请指定打印机!");
            }
            else
            {
                TcpClient client = new TcpClient();

                string hostname = dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
                int port = int.Parse(dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

                try
                {
                    client.Connect(hostname, port);

                    for (int i = 0; i < dgvr.Count; i++)
                    {
                        string s = string.Empty;

                        string manu = string.Empty;
                        string cert = string.Empty;

                        if (dgvr[i].Cells["deliveryLineId"].Value.ToString().Trim().Length != 0)
                        {
                            DataSet ds17 = GetData.Get_17(dgvr[i].Cells["deliveryLineId"].Value.ToString());

                            if (ds17 != null && ds17.Tables[0].Rows.Count > 0)
                            {
                                manu = ds17.Tables[0].Rows[0]["instructions"].ToString();//说明书
                                cert = ds17.Tables[0].Rows[0]["qualifiedCertificate"].ToString();//合格证
                            }
                        }

                        string f = dgvr[i].Cells["prodLineDeptName"].Value.ToString();//产线部门
                        string proName = dgvr[i].Cells["itemDesc"].Value.ToString();//物料描述
                        string proNo = dgvr[i].Cells["itemId"].Value.ToString();//物料号
                        string patch = dgvr[i].Cells["itemName"].Value.ToString();//物料名称
                        string deNo = dgvr[i].Cells["transactionId"].Value.ToString();//凭证号
                        string ckDate = dgvr[i].Cells["depositDate"].Value.ToString();//入库日期

                        string pC = dgvr[i].Cells["deliveryLineId"].Value.ToString();//送货单号

                        string baoguanyuan = dgvr[i].Cells["custodianJobId"].Value.ToString();//保管员岗位号
                        string supp = dgvr[i].Cells["supplierName"].Value.ToString();//供货单位名称
                        string loca = dgvr[i].Cells["invBin"].Value.ToString();//储位
                        string q = dgvr[i].Cells["invQty"].Value.ToString();//储位数量
                        string u = dgvr[i].Cells["itemUom"].Value.ToString();//单位
                        string w = dgvr[i].Cells["unitWeight"].Value.ToString();//单重
                        string r = dgvr[i].Cells["batchId"].Value.ToString();//批次号
                        string p = dgvr[i].Cells["invPrice"].Value.ToString();//单价
                        string cop = nudCopy.Text;
                        
                        string ywtm = deNo + "-" + proNo;

                        s = ClsCommon.dealData(f, proName, proNo, patch, deNo, ckDate, manu, pC, cert, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, cmbLabelType.Text);
                        client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                        client.GetStream().Flush();
                    }

                    client.Close();
                }
                catch (Exception exception)
                {
                    CommonFunction.Sys_MsgBox(exception.Message);
                }
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetNextSelectControl(ActiveControl).Focus();
            }
        }

        private void ShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ArrayList alParams = new ArrayList();

                alParams.Add(textBoxStoreMan.Text.Trim());
                //this.dtResult = DBOperate.LocalStockGetList_New(alParams);

                dtResult = ClsCommon.LocalStockGetList(alParams);

                if (CommonFunction.IfHasData(dtResult))
                {
                    dataGridViewStock.DataSource = dtResult;
                }
                else
                {
                    dataGridViewStock.DataSource = dtResult;
                    CommonFunction.Sys_MsgBox("没有检索到任何数据，请重新检索");
                }

                dataGridViewStock_SelectionChanged(null, null);
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ShowWaitingMsg()
        {
            Invoke(new EventHandler(ShowMsg));
        }

        private void 数据库查询_Load(object sender, EventArgs e)
        {
            txtPrinter_TextChanged(null, e);
        }

        private void txtPrinter_TextChanged(object sender, EventArgs e)
        {
            dtPrinterList = DBOperate.GetPrinterList("%" + txtPrinter.Text + "%", "%");
            dataGridViewPrinterList.DataSource = dtPrinterList;
        }
    }
}
