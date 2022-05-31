using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RFSystem.Properties;
using System.Net.Sockets;
using RFSystem.AnSteel;

namespace RFSystem.LabelPrint
{
    public class ProductLabel : Form
    {
        private UserInfo userItem;

        #region system
        private Button btnPatchPrint;
        private Button btnPrint;
        private Button btnPrintCountMod;
        private Button btnSelect;
        private Button button1;
        private ComboBox cmbLabelType;
        private DataGridViewTextBoxColumn columnPAddress;
        private DataGridViewTextBoxColumn columnPName;
        private DataGridViewTextBoxColumn columnSocket;
        private DataGridView dataGridViewPrinterList;
        private DataGridView dataGridViewProductList;
        private DataSet dsWl;
        private DataTable dtPrinterList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxKeeperID;
        private TextBox txtFactoryNo;
        private TextBox txtPatch;
        private DataGridViewTextBoxColumn columnPNo;
        private DataGridViewTextBoxColumn columnPatch;
        private DataGridViewTextBoxColumn columnFactory;
        private DataGridViewTextBoxColumn columnSL;
        private DataGridViewTextBoxColumn columnProduct;
        private DataGridViewTextBoxColumn ColumnPro;
        private DataGridViewTextBoxColumn columnUnit;
        private DataGridViewTextBoxColumn ColumnNtgew;
        private DataGridViewTextBoxColumn columnAmount;
        private DataGridViewTextBoxColumn columnQty;
        private DataGridViewTextBoxColumn columnDate;
        private DataGridViewTextBoxColumn columnSupplier;
        private DataGridViewTextBoxColumn ColumnPrintCount;
        private DataGridViewTextBoxColumn ColumnXAUTO;
        private DataGridViewTextBoxColumn C_Bct10;
        private DataGridViewTextBoxColumn C_N_ywtm;
        private DataGridViewTextBoxColumn C_N_pch;
        private DataGridViewTextBoxColumn C_N_pzh;
        private DataGridViewTextBoxColumn C_N_rkrq;
        private DataGridViewTextBoxColumn C_N_ghdw;
        private DataGridViewTextBoxColumn C_N_storeman;
        private NumericUpDown nudCopy;
        private TextBox txtPrinter;

        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxKeeperID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPatch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFactoryNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dataGridViewProductList = new System.Windows.Forms.DataGridView();
            this.columnPNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFactory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNtgew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrintCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnXAUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Bct10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_N_ywtm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_N_pch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_N_pzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_N_rkrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_N_ghdw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_N_storeman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            this.btnPrintCountMod = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPatchPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.columnPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudCopy = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxKeeperID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPatch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFactoryNo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.dataGridViewProductList);
            this.groupBox2.Location = new System.Drawing.Point(12, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 293);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "物料选择";
            // 
            // textBoxKeeperID
            // 
            this.textBoxKeeperID.Location = new System.Drawing.Point(524, 32);
            this.textBoxKeeperID.Name = "textBoxKeeperID";
            this.textBoxKeeperID.Size = new System.Drawing.Size(100, 26);
            this.textBoxKeeperID.TabIndex = 30;
            this.textBoxKeeperID.Visible = false;
            this.textBoxKeeperID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            this.textBoxKeeperID.Leave += new System.EventHandler(this.textBoxKeeperID_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "保管员：";
            this.label4.Visible = false;
            // 
            // txtPatch
            // 
            this.txtPatch.Location = new System.Drawing.Point(296, 32);
            this.txtPatch.Name = "txtPatch";
            this.txtPatch.Size = new System.Drawing.Size(151, 26);
            this.txtPatch.TabIndex = 20;
            this.txtPatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "物料凭证号：";
            // 
            // txtFactoryNo
            // 
            this.txtFactoryNo.Location = new System.Drawing.Point(91, 32);
            this.txtFactoryNo.Name = "txtFactoryNo";
            this.txtFactoryNo.Size = new System.Drawing.Size(100, 26);
            this.txtFactoryNo.TabIndex = 10;
            this.txtFactoryNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "凭证年度：";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(694, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 40;
            this.btnSelect.Text = "查找";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dataGridViewProductList
            // 
            this.dataGridViewProductList.AllowUserToAddRows = false;
            this.dataGridViewProductList.AllowUserToResizeRows = false;
            this.dataGridViewProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewProductList.ColumnHeadersHeight = 30;
            this.dataGridViewProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPNo,
            this.columnPatch,
            this.columnFactory,
            this.columnSL,
            this.columnProduct,
            this.ColumnPro,
            this.columnUnit,
            this.ColumnNtgew,
            this.columnAmount,
            this.columnQty,
            this.columnDate,
            this.columnSupplier,
            this.ColumnPrintCount,
            this.ColumnXAUTO,
            this.C_Bct10,
            this.C_N_ywtm,
            this.C_N_pch,
            this.C_N_pzh,
            this.C_N_rkrq,
            this.C_N_ghdw,
            this.C_N_storeman});
            this.dataGridViewProductList.Location = new System.Drawing.Point(10, 71);
            this.dataGridViewProductList.MultiSelect = false;
            this.dataGridViewProductList.Name = "dataGridViewProductList";
            this.dataGridViewProductList.ReadOnly = true;
            this.dataGridViewProductList.RowHeadersVisible = false;
            this.dataGridViewProductList.RowTemplate.Height = 23;
            this.dataGridViewProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProductList.Size = new System.Drawing.Size(784, 216);
            this.dataGridViewProductList.TabIndex = 100;
            this.dataGridViewProductList.SelectionChanged += new System.EventHandler(this.dataGridViewLocationList_SelectionChanged);
            this.dataGridViewProductList.Sorted += new System.EventHandler(this.dataGridViewProductList_Sorted);
            // 
            // columnPNo
            // 
            this.columnPNo.DataPropertyName = "Matnr";
            this.columnPNo.HeaderText = "物料号";
            this.columnPNo.Name = "columnPNo";
            this.columnPNo.ReadOnly = true;
            this.columnPNo.Width = 76;
            // 
            // columnPatch
            // 
            this.columnPatch.DataPropertyName = "Charg";
            this.columnPatch.HeaderText = "批次号";
            this.columnPatch.Name = "columnPatch";
            this.columnPatch.ReadOnly = true;
            this.columnPatch.Width = 76;
            // 
            // columnFactory
            // 
            this.columnFactory.DataPropertyName = "Werks";
            this.columnFactory.HeaderText = "工厂号";
            this.columnFactory.Name = "columnFactory";
            this.columnFactory.ReadOnly = true;
            this.columnFactory.Width = 76;
            // 
            // columnSL
            // 
            this.columnSL.DataPropertyName = "Lgort";
            this.columnSL.HeaderText = "库存地点";
            this.columnSL.Name = "columnSL";
            this.columnSL.ReadOnly = true;
            this.columnSL.Width = 90;
            // 
            // columnProduct
            // 
            this.columnProduct.DataPropertyName = "Maktx";
            this.columnProduct.HeaderText = "物料名称";
            this.columnProduct.Name = "columnProduct";
            this.columnProduct.ReadOnly = true;
            this.columnProduct.Width = 90;
            // 
            // ColumnPro
            // 
            this.ColumnPro.DataPropertyName = "Name1";
            this.ColumnPro.HeaderText = "供货单位";
            this.ColumnPro.Name = "ColumnPro";
            this.ColumnPro.ReadOnly = true;
            this.ColumnPro.Width = 90;
            // 
            // columnUnit
            // 
            this.columnUnit.DataPropertyName = "Meins";
            this.columnUnit.HeaderText = "单位";
            this.columnUnit.Name = "columnUnit";
            this.columnUnit.ReadOnly = true;
            this.columnUnit.Width = 62;
            // 
            // ColumnNtgew
            // 
            this.ColumnNtgew.DataPropertyName = "Ntgew";
            this.ColumnNtgew.HeaderText = "单重";
            this.ColumnNtgew.Name = "ColumnNtgew";
            this.ColumnNtgew.ReadOnly = true;
            this.ColumnNtgew.Width = 62;
            // 
            // columnAmount
            // 
            this.columnAmount.DataPropertyName = "Dmbtr";
            this.columnAmount.HeaderText = "金额";
            this.columnAmount.Name = "columnAmount";
            this.columnAmount.ReadOnly = true;
            this.columnAmount.Width = 62;
            // 
            // columnQty
            // 
            this.columnQty.DataPropertyName = "Menge";
            this.columnQty.HeaderText = "数量";
            this.columnQty.Name = "columnQty";
            this.columnQty.ReadOnly = true;
            this.columnQty.Width = 62;
            // 
            // columnDate
            // 
            this.columnDate.DataPropertyName = "Budat";
            this.columnDate.HeaderText = "入库日期";
            this.columnDate.Name = "columnDate";
            this.columnDate.ReadOnly = true;
            this.columnDate.Width = 90;
            // 
            // columnSupplier
            // 
            this.columnSupplier.DataPropertyName = "Bct20";
            this.columnSupplier.HeaderText = "生产厂编号";
            this.columnSupplier.Name = "columnSupplier";
            this.columnSupplier.ReadOnly = true;
            this.columnSupplier.Width = 104;
            // 
            // ColumnPrintCount
            // 
            this.ColumnPrintCount.HeaderText = "打印份数";
            this.ColumnPrintCount.Name = "ColumnPrintCount";
            this.ColumnPrintCount.ReadOnly = true;
            this.ColumnPrintCount.Width = 90;
            // 
            // ColumnXAUTO
            // 
            this.ColumnXAUTO.DataPropertyName = "Xauto";
            this.ColumnXAUTO.HeaderText = "XAUTO";
            this.ColumnXAUTO.Name = "ColumnXAUTO";
            this.ColumnXAUTO.ReadOnly = true;
            this.ColumnXAUTO.Width = 82;
            // 
            // C_Bct10
            // 
            this.C_Bct10.DataPropertyName = "Bct10";
            this.C_Bct10.HeaderText = "C_Bct10";
            this.C_Bct10.Name = "C_Bct10";
            this.C_Bct10.ReadOnly = true;
            this.C_Bct10.Width = 86;
            // 
            // C_N_ywtm
            // 
            this.C_N_ywtm.DataPropertyName = "N_ywtm";
            this.C_N_ywtm.HeaderText = "C_N_ywtm";
            this.C_N_ywtm.Name = "C_N_ywtm";
            this.C_N_ywtm.ReadOnly = true;
            this.C_N_ywtm.Width = 102;
            // 
            // C_N_pch
            // 
            this.C_N_pch.DataPropertyName = "N_pch";
            this.C_N_pch.HeaderText = "C_N_pch";
            this.C_N_pch.Name = "C_N_pch";
            this.C_N_pch.ReadOnly = true;
            this.C_N_pch.Width = 91;
            // 
            // C_N_pzh
            // 
            this.C_N_pzh.DataPropertyName = "N_pzh";
            this.C_N_pzh.HeaderText = "C_N_pzh";
            this.C_N_pzh.Name = "C_N_pzh";
            this.C_N_pzh.ReadOnly = true;
            this.C_N_pzh.Width = 91;
            // 
            // C_N_rkrq
            // 
            this.C_N_rkrq.DataPropertyName = "N_rkrq";
            this.C_N_rkrq.HeaderText = "C_N_rkrq";
            this.C_N_rkrq.Name = "C_N_rkrq";
            this.C_N_rkrq.ReadOnly = true;
            this.C_N_rkrq.Width = 93;
            // 
            // C_N_ghdw
            // 
            this.C_N_ghdw.DataPropertyName = "N_ghdw";
            this.C_N_ghdw.HeaderText = "C_N_ghdw";
            this.C_N_ghdw.Name = "C_N_ghdw";
            this.C_N_ghdw.ReadOnly = true;
            this.C_N_ghdw.Width = 104;
            // 
            // C_N_storeman
            // 
            this.C_N_storeman.DataPropertyName = "N_storeman";
            this.C_N_storeman.HeaderText = "C_N_storeman";
            this.C_N_storeman.Name = "C_N_storeman";
            this.C_N_storeman.ReadOnly = true;
            this.C_N_storeman.Width = 129;
            // 
            // cmbLabelType
            // 
            this.cmbLabelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbLabelType.FormattingEnabled = true;
            this.cmbLabelType.Items.AddRange(new object[] {
            "普通标签",
            "RFID标签"});
            this.cmbLabelType.Location = new System.Drawing.Point(278, 509);
            this.cmbLabelType.Name = "cmbLabelType";
            this.cmbLabelType.Size = new System.Drawing.Size(121, 28);
            this.cmbLabelType.TabIndex = 101;
            // 
            // btnPrintCountMod
            // 
            this.btnPrintCountMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintCountMod.Enabled = false;
            this.btnPrintCountMod.Location = new System.Drawing.Point(172, 502);
            this.btnPrintCountMod.Name = "btnPrintCountMod";
            this.btnPrintCountMod.Size = new System.Drawing.Size(100, 40);
            this.btnPrintCountMod.TabIndex = 60;
            this.btnPrintCountMod.Text = "修改";
            this.btnPrintCountMod.UseVisualStyleBackColor = true;
            this.btnPrintCountMod.Click += new System.EventHandler(this.btnPrintCountMod_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "打印份数：";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(405, 502);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 70;
            this.btnPrint.Text = "单个打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPatchPrint
            // 
            this.btnPatchPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPatchPrint.Enabled = false;
            this.btnPatchPrint.Location = new System.Drawing.Point(511, 502);
            this.btnPatchPrint.Name = "btnPatchPrint";
            this.btnPatchPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPatchPrint.TabIndex = 80;
            this.btnPatchPrint.Text = "批量打印";
            this.btnPatchPrint.UseVisualStyleBackColor = true;
            this.btnPatchPrint.Click += new System.EventHandler(this.btnPatchPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtPrinter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dataGridViewPrinterList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 185);
            this.groupBox1.TabIndex = 1000;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印机选择";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(694, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 101;
            this.button1.Text = "查找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPrinter
            // 
            this.txtPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrinter.Location = new System.Drawing.Point(598, 32);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(90, 26);
            this.txtPrinter.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(527, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 101;
            this.label5.Text = "打印机：";
            // 
            // dataGridViewPrinterList
            // 
            this.dataGridViewPrinterList.AllowUserToAddRows = false;
            this.dataGridViewPrinterList.AllowUserToResizeRows = false;
            this.dataGridViewPrinterList.ColumnHeadersHeight = 30;
            this.dataGridViewPrinterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPrinterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPName,
            this.columnPAddress,
            this.columnSocket});
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(10, 25);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(414, 154);
            this.dataGridViewPrinterList.TabIndex = 1100;
            this.dataGridViewPrinterList.SelectionChanged += new System.EventHandler(this.dataGridViewPrinterList_SelectionChanged);
            // 
            // columnPName
            // 
            this.columnPName.DataPropertyName = "PrinterName";
            this.columnPName.HeaderText = "打印机";
            this.columnPName.Name = "columnPName";
            this.columnPName.ReadOnly = true;
            // 
            // columnPAddress
            // 
            this.columnPAddress.DataPropertyName = "PrinterAddress";
            this.columnPAddress.HeaderText = "IP地址";
            this.columnPAddress.Name = "columnPAddress";
            this.columnPAddress.ReadOnly = true;
            // 
            // columnSocket
            // 
            this.columnSocket.DataPropertyName = "PrinterSocket";
            this.columnSocket.HeaderText = "端口号";
            this.columnSocket.Name = "columnSocket";
            this.columnSocket.ReadOnly = true;
            // 
            // nudCopy
            // 
            this.nudCopy.Location = new System.Drawing.Point(102, 510);
            this.nudCopy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopy.Name = "nudCopy";
            this.nudCopy.Size = new System.Drawing.Size(63, 26);
            this.nudCopy.TabIndex = 1001;
            this.nudCopy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ProductLabel
            // 
            this.ClientSize = new System.Drawing.Size(824, 554);
            this.ControlBox = false;
            this.Controls.Add(this.nudCopy);
            this.Controls.Add(this.cmbLabelType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrintCountMod);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnPatchPrint);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductLabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物料标签打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProductLabel_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        public ProductLabel(UserInfo userItem)
        {
            dtPrinterList = null;
            this.userItem = null;
            InitializeComponent();
            dtPrinterList = DBOperate.GetPrinterList("''", "''");
            dataGridViewPrinterList.DataSource = dtPrinterList;
            dataGridViewProductList.AutoGenerateColumns = false;
            this.userItem = userItem;
            textBoxKeeperID.Text = userItem.userID;
            txtFactoryNo.Text = DateTime.Now.Year.ToString();
            dsWl = new DataSet();
            cmbLabelType.Text = "普通标签";
        }

        private void btnPatchPrint_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool ifPrintNull = true;

            foreach (DataGridViewRow row in dataGridViewProductList.Rows)
            {
                if (row.Cells["ColumnXAUTO"].Value.Equals("X"))
                {
                    flag = true;
                }
            }

            if (flag && CommonFunction.Sys_MsgYN("是否打印原货位物料信息？"))
            {
                ifPrintNull = false;
            }

            PrintProductLabelNew_Patch(dataGridViewProductList.Rows, ifPrintNull);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintProductLabelNew_Patch(dataGridViewProductList.SelectedRows);
        }

        private void btnPrintCountMod_Click(object sender, EventArgs e)
        {
            dataGridViewProductList.SelectedRows[0].Cells["ColumnPrintCount"].Value = nudCopy.Value;
            dataGridViewLocationList_SelectionChanged(null, null);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                decimal num = 0M;

                try
                {
                    num = Convert.ToDecimal(txtFactoryNo.Text.Trim());
                }
                catch
                {
                    CommonFunction.Sys_MsgBox("年度输入格式不正确，请输入0--3000内的数字");

                    if (CommonFunction.IfHasData((DataTable)dataGridViewProductList.DataSource))
                    {
                        ((DataTable)dataGridViewProductList.DataSource).Rows.Clear();
                    }

                    return;
                }

                if ((num <= 0M) || (num >= 3000M))
                {
                    CommonFunction.Sys_MsgBox("年度输入格式不正确，请输入0--3000内的数字");

                    if (CommonFunction.IfHasData((DataTable)dataGridViewProductList.DataSource))
                    {
                        ((DataTable)dataGridViewProductList.DataSource).Rows.Clear();
                    }
                }
                else if ((txtFactoryNo.Text.Trim().Equals(string.Empty) || txtPatch.Text.Trim().Equals(string.Empty)) || textBoxKeeperID.Text.Trim().Equals(string.Empty))
                {
                    CommonFunction.Sys_MsgBox("凭证年度,物料凭证号及保管员为必输入项目，请完整填写");

                    if (CommonFunction.IfHasData((DataTable)dataGridViewProductList.DataSource))
                    {
                        ((DataTable)dataGridViewProductList.DataSource).Rows.Clear();
                    }
                }
                else
                {
                    MessagePack pack = Utility.getSerive().GetWLPZInfo(textBoxKeeperID.Text.Trim(), txtFactoryNo.Text.Trim(), txtPatch.Text.Trim(), out dsWl);

                    if (pack.Code == -1)
                    {
                        CommonFunction.Sys_MsgBox(pack.Message);

                        if (CommonFunction.IfHasData((DataTable)dataGridViewProductList.DataSource))
                        {
                            ((DataTable)dataGridViewProductList.DataSource).Rows.Clear();
                        }
                    }
                    else
                    {
                        getbcxx();

                        dataGridViewProductList.DataSource = dsWl.Tables[0];

                        foreach (DataGridViewRow row in dataGridViewProductList.Rows)
                        {
                            row.Cells["ColumnPrintCount"].Value = row.Cells["columnQty"].Value;
                        }

                        dataGridViewLocationList_SelectionChanged(null, null);
                    }
                }
            }
            catch
            {
                CommonFunction.Sys_MsgBox("由于网络等原因，数据取得失败");

                if (CommonFunction.IfHasData((DataTable)dataGridViewProductList.DataSource))
                {
                    ((DataTable)dataGridViewProductList.DataSource).Rows.Clear();
                }
            }
        }

        //新增补充信息
        private void getbcxx()
        {

            #region m_poDs增加一维条码列
            int _len = dsWl.Tables[0].Rows.Count;
            string wltms = "";
            //给m_poDs增加列
            dsWl.Tables[0].Columns.Add("N_ywtm");
            dsWl.Tables[0].Columns.Add("N_pch");
            dsWl.Tables[0].Columns.Add("N_storeman");
            dsWl.Tables[0].Columns.Add("N_rkrq");
            dsWl.Tables[0].Columns.Add("N_pzh");
            dsWl.Tables[0].Columns.Add("N_pznd");
            dsWl.Tables[0].Columns.Add("N_ghdw");
            string proNo;
            string patch;
            string wareNo;
            for (int i = 0; i < _len; i++)
            {
                DataRow row = dsWl.Tables[0].Rows[i];
                proNo = row["Matnr"].ToString().Trim();
                patch = row["Charg"].ToString().Trim();
                wareNo = row["Werks"].ToString().Trim();
                wltms += "'" + wareNo + patch + proNo + "',";
                dsWl.Tables[0].Rows[i]["N_ywtm"] = "";
                dsWl.Tables[0].Rows[i]["N_pch"] = "";
                dsWl.Tables[0].Rows[i]["N_storeman"] = "";
                dsWl.Tables[0].Rows[i]["N_rkrq"] = "";
                dsWl.Tables[0].Rows[i]["N_pzh"] = "";
                dsWl.Tables[0].Rows[i]["N_pznd"] = "";
                dsWl.Tables[0].Rows[i]["N_ghdw"] = "";
            }

            wltms = wltms.Substring(0, wltms.Length - 1);
            wltms = "(" + wltms + ")";

            DataSet ds = new DataSet();
            ClsCommon cls = new ClsCommon();
            MessagePack pak = cls.queryYwtms(wltms, out ds);

            if (pak.Code != 0)
            {
                CommonFunction.Sys_MsgBox(pak.Message);
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < _len; i++)
                {
                    DataRow row = dsWl.Tables[0].Rows[i];
                    proNo = row["Matnr"].ToString().Trim();
                    patch = row["Charg"].ToString().Trim();
                    wareNo = row["Werks"].ToString().Trim();
                    string wltm = wareNo + patch + proNo;

                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        if (wltm == ds.Tables[0].Rows[j]["product_barcode"].ToString().Trim())
                        {
                            dsWl.Tables[0].Rows[i]["N_ywtm"] = ds.Tables[0].Rows[j]["ywtm"].ToString().Trim();
                            dsWl.Tables[0].Rows[i]["N_pch"] = ds.Tables[0].Rows[j]["pch"].ToString().Trim();
                            dsWl.Tables[0].Rows[i]["N_storeman"] = ds.Tables[0].Rows[j]["storeman"].ToString().Trim();
                            dsWl.Tables[0].Rows[i]["N_rkrq"] = ds.Tables[0].Rows[j]["rkrq"].ToString().Trim();
                            dsWl.Tables[0].Rows[i]["N_pzh"] = ds.Tables[0].Rows[j]["pzh"].ToString().Trim();
                            dsWl.Tables[0].Rows[i]["N_pznd"] = ds.Tables[0].Rows[j]["pznd"].ToString().Trim();
                            dsWl.Tables[0].Rows[i]["N_ghdw"] = ds.Tables[0].Rows[j]["ghdw"].ToString().Trim();
                            break;
                        }
                    }
                }
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtPrinterList = DBOperate.GetPrinterList("%" + txtPrinter.Text + "%", "%");
            dataGridViewPrinterList.DataSource = dtPrinterList;
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

        private void dataGridViewLocationList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewProductList.Rows != null) && (dataGridViewProductList.SelectedRows.Count != 0))
            {
                if (dataGridViewProductList.SelectedRows[0].Cells["ColumnPrintCount"].Value != null)
                {
                    nudCopy.Value = Convert.ToDecimal(dataGridViewProductList.SelectedRows[0].Cells["ColumnPrintCount"].Value);
                    btnPrintCountMod.Enabled = true;
                }

                btnPrint.Enabled = true;
                btnPatchPrint.Enabled = true;
            }
            else
            {
                nudCopy.Value = 0;
                btnPrintCountMod.Enabled = false;
                btnPrint.Enabled = false;
                btnPatchPrint.Enabled = false;
            }
        }

        private void dataGridViewPrinterList_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewProductList_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewProductList.Rows)
            {
                row.Cells["ColumnPrintCount"].Value = row.Cells["columnQty"].Value;
            }
        }
  
        private void PrintProductLabelNew_Patch(DataGridViewSelectedRowCollection dgvr)
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
                    string f = dgvr[i].Cells["columnSupplier"].Value.ToString();
                    string proName = dgvr[i].Cells["columnProduct"].Value.ToString();
                    string proNo = dgvr[i].Cells["columnPNo"].Value.ToString();
                    ////string patch = dgvr[i].Cells["columnPatch"].Value.ToString();
                    string wareNo = dgvr[i].Cells["columnFactory"].Value.ToString();
                    ////string deNo = this.txtPatch.Text.Trim();
                    ////string ckDate = dgvr[i].Cells["columnDate"].Value.ToString();
                    string manu = "";
                    string pC = "";
                    string cert = "";
                    string pL = "";
                    ////string supp = dgvr[i].Cells["ColumnPro"].Value.ToString();
                    string loca = "";
                    string q = "";
                    string r = "";
                    string u = dgvr[i].Cells["columnUnit"].Value.ToString();
                    string w = dgvr[i].Cells["ColumnNtgew"].Value.ToString();
                    string p = dgvr[i].Cells["columnAmount"].Value.ToString();
                    string cop = Math.Truncate(Convert.ToDecimal(dgvr[i].Cells["ColumnPrintCount"].Value)).ToString();

                    string ywtm = dgvr[i].Cells["C_N_ywtm"].Value.ToString().Trim();
                    string patch = dgvr[i].Cells["columnPatch"] == null || dgvr[i].Cells["columnPatch"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_pch"].Value.ToString().Trim() : dgvr[i].Cells["columnPatch"].Value.ToString().Trim();
                    string deNo = txtPatch.Text.Trim() == "" ? dgvr[i].Cells["C_N_pzh"].Value.ToString() : txtPatch.Text.Trim();
                    string ckDate = dgvr[i].Cells["columnDate"] == null || dgvr[i].Cells["columnDate"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_rkrq"].Value.ToString().Trim() : dgvr[i].Cells["columnDate"].Value.ToString().Trim();
                    string supp = dgvr[i].Cells["ColumnPro"] == null || dgvr[i].Cells["ColumnPro"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_ghdw"].Value.ToString().Trim() : dgvr[i].Cells["ColumnPro"].Value.ToString().Trim();
                    string baoguanyuan = dgvr[i].Cells["C_Bct10"] == null || dgvr[i].Cells["C_Bct10"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_storeman"].Value.ToString().Trim() : dgvr[i].Cells["C_Bct10"].Value.ToString().Trim();
                    s = ClsCommon.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, this.cmbLabelType.Text);

                    //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
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

        private void PrintProductLabelNew_Patch(DataGridViewRowCollection dgvr, bool ifPrintNull)
        {
            TcpClient client = new TcpClient();
            string hostname = dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            int port = int.Parse(dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

            try
            {
                client.Connect(hostname, port);

                for (int i = 0; i < dgvr.Count; i++)
                {
                    if (ifPrintNull || dgvr[i].Cells["ColumnXAUTO"].Value.ToString().Equals("X"))
                    {
                        string s = string.Empty;
                        string f = dgvr[i].Cells["columnSupplier"].Value.ToString();
                        string proName = dgvr[i].Cells["columnProduct"].Value.ToString();
                        string proNo = dgvr[i].Cells["columnPNo"].Value.ToString();
                        ////string patch = dgvr[i].Cells["columnPatch"].Value.ToString();
                        string wareNo = dgvr[i].Cells["columnFactory"].Value.ToString();
                        ////string deNo = this.txtPatch.Text.Trim();
                        ////string ckDate = dgvr[i].Cells["columnDate"].Value.ToString();
                        string manu = "";
                        string pC = "";
                        string cert = "";
                        string pL = "";
                        ////string supp = dgvr[i].Cells["ColumnPro"].Value.ToString();
                        string loca = "";
                        string q = "";
                        string r = "";
                        string u = dgvr[i].Cells["columnUnit"].Value.ToString();
                        string w = dgvr[i].Cells["ColumnNtgew"].Value.ToString();
                        string p = dgvr[i].Cells["columnAmount"].Value.ToString();
                        string cop = Math.Truncate(Convert.ToDecimal(dgvr[i].Cells["ColumnPrintCount"].Value)).ToString();

                        string ywtm = dgvr[i].Cells["C_N_ywtm"].Value.ToString().Trim();
                        string patch = dgvr[i].Cells["columnPatch"] == null || dgvr[i].Cells["columnPatch"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_pch"].Value.ToString().Trim() : dgvr[i].Cells["columnPatch"].Value.ToString().Trim();
                        string deNo = this.txtPatch.Text.Trim() == "" ? dgvr[i].Cells["C_N_pzh"].Value.ToString() : this.txtPatch.Text.Trim();
                        string ckDate = dgvr[i].Cells["columnDate"] == null || dgvr[i].Cells["columnDate"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_rkrq"].Value.ToString().Trim() : dgvr[i].Cells["columnDate"].Value.ToString().Trim();
                        string supp = dgvr[i].Cells["ColumnPro"] == null || dgvr[i].Cells["ColumnPro"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_ghdw"].Value.ToString().Trim() : dgvr[i].Cells["ColumnPro"].Value.ToString().Trim();
                        string baoguanyuan = dgvr[i].Cells["C_Bct10"] == null || dgvr[i].Cells["C_Bct10"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_storeman"].Value.ToString().Trim() : dgvr[i].Cells["C_Bct10"].Value.ToString().Trim();
                        s = ClsCommon.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, this.cmbLabelType.Text);
                       
                        //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                        client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                        client.GetStream().Flush();
                    }
                }

                client.Close();
            }
            catch (Exception exception)
            {
                CommonFunction.Sys_MsgBox(exception.Message);
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetNextControl(ActiveControl, true).Focus();
            }
        }

        private void textBoxKeeperID_Leave(object sender, EventArgs e)
        {
            if (!textBoxKeeperID.Text.Equals(string.Empty) && !CommonFunction.IfHasData(DBOperate.GetUserIDName(textBoxKeeperID.Text)))
            {
                CommonFunction.Sys_MsgBox("找不到相应人员，请确认输入");
                textBoxKeeperID.Focus();
            }
        }

        private void ProductLabel_Load(object sender, EventArgs e)
        {

        }
    }
}