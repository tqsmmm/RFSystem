using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BL;
using RFSystem.Properties;
using RFSystem.CommonClass;
using System.Net.Sockets;
using System.Collections;
using RFSystem.AnSteel;

namespace RFSystem.LabelPrint
{
    public class ProductLabel : Form
    {
        private UserInfo userItem;

        #region system
        // Fields
        private Button btnExit;
        private Button btnPatchPrint;
        private Button btnPrint;
        private Button btnPrintCountMod;
        private Button btnSelect;
        private Button button1;
        private Button button2;
        private ComboBox cmbLabelType;
        private DataGridViewTextBoxColumn columnPAddress;
        private DataGridViewTextBoxColumn columnPName;
        private DataGridViewTextBoxColumn columnSocket;
        private IContainer components;
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
        private TextBox txtCopy;
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
        private Button button3;
        private TextBox txtPrinter;

        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            this.textBoxKeeperID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrintCountMod = new System.Windows.Forms.Button();
            this.txtCopy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFactoryNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPatchPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.columnPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
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
            // txtCopy
            // 
            this.txtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCopy.Location = new System.Drawing.Point(102, 509);
            this.txtCopy.Name = "txtCopy";
            this.txtCopy.Size = new System.Drawing.Size(64, 26);
            this.txtCopy.TabIndex = 50;
            this.txtCopy.Text = "0";
            this.txtCopy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
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
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(712, 502);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 90;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
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
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(588, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 40);
            this.button3.TabIndex = 102;
            this.button3.Text = "模拟打印";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(694, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 1101;
            this.button2.Text = "默认打印机";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // ProductLabel
            // 
            this.ClientSize = new System.Drawing.Size(824, 554);
            this.ControlBox = false;
            this.Controls.Add(this.cmbLabelType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCopy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrintCountMod);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPatchPrint);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductLabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物料标签打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        public ProductLabel(UserInfo userItem)
        {
            this.components = null;
            this.dtPrinterList = null;
            this.userItem = null;
            this.InitializeComponent();
            this.dtPrinterList = DBOperate.GetPrinterList("%", "%" + Settings.Default.DefaultPrinterIP.ToString() + "%");
            this.dataGridViewPrinterList.DataSource = this.dtPrinterList;
            this.dataGridViewProductList.AutoGenerateColumns = false;
            this.userItem = userItem;
            this.textBoxKeeperID.Text = userItem.userID;
            this.txtFactoryNo.Text = DateTime.Now.Year.ToString();
            this.dsWl = new DataSet();
            this.cmbLabelType.Text = "普通标签";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPatchPrint_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool ifPrintNull = true;

            foreach (DataGridViewRow row in (IEnumerable)this.dataGridViewProductList.Rows)
            {
                if (row.Cells["ColumnXAUTO"].Value.Equals("X"))
                {
                    flag = true;
                }
            }

            if (flag && (CommonFunction.AskMBox("是否打印原货位物料信息", "是否打印", true, true) == DialogResult.No))
            {
                ifPrintNull = false;
            }

            this.PrintProductLabelNew_Patch(this.dataGridViewProductList.Rows, ifPrintNull);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.PrintProductLabelNew_Patch(this.dataGridViewProductList.SelectedRows);
        }

        private void btnPrintCountMod_Click(object sender, EventArgs e)
        {
            this.dataGridViewProductList.SelectedRows[0].Cells["ColumnPrintCount"].Value = this.txtCopy.Text;
            this.dataGridViewLocationList_SelectionChanged(null, null);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                decimal num = 0M;

                try
                {
                    num = Convert.ToDecimal(this.txtFactoryNo.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("年度输入格式不正确，请输入0--3000内的数字");

                    if (CommonFunction.IfHasData((DataTable)this.dataGridViewProductList.DataSource))
                    {
                        ((DataTable)this.dataGridViewProductList.DataSource).Rows.Clear();
                    }

                    return;
                }

                if ((num <= 0M) || (num >= 3000M))
                {
                    MessageBox.Show("年度输入格式不正确，请输入0--3000内的数字");

                    if (CommonFunction.IfHasData((DataTable)this.dataGridViewProductList.DataSource))
                    {
                        ((DataTable)this.dataGridViewProductList.DataSource).Rows.Clear();
                    }
                }
                else if ((this.txtFactoryNo.Text.Trim().Equals(string.Empty) || this.txtPatch.Text.Trim().Equals(string.Empty)) || this.textBoxKeeperID.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("凭证年度,物料凭证号及保管员为必输入项目，请完整填写");

                    if (CommonFunction.IfHasData((DataTable)this.dataGridViewProductList.DataSource))
                    {
                        ((DataTable)this.dataGridViewProductList.DataSource).Rows.Clear();
                    }
                }
                else
                {
                    MessagePack pack = Utility.getSerive().GetWLPZInfo(this.textBoxKeeperID.Text.Trim(), this.txtFactoryNo.Text.Trim(), this.txtPatch.Text.Trim(), out this.dsWl);

                    if (pack.Code == -1)
                    {
                        MessageBox.Show(pack.Message);

                        if (CommonFunction.IfHasData((DataTable)this.dataGridViewProductList.DataSource))
                        {
                            ((DataTable)this.dataGridViewProductList.DataSource).Rows.Clear();
                        }
                    }
                    else
                    {
                        getbcxx();

                        this.dataGridViewProductList.DataSource = this.dsWl.Tables[0];

                        foreach (DataGridViewRow row in (IEnumerable)this.dataGridViewProductList.Rows)
                        {
                            row.Cells["ColumnPrintCount"].Value = row.Cells["columnQty"].Value;
                        }

                        this.dataGridViewLocationList_SelectionChanged(null, null);
                    }
                }
            }
            catch
            {
                MessageBox.Show("由于网络等原因，数据取得失败");

                if (CommonFunction.IfHasData((DataTable)this.dataGridViewProductList.DataSource))
                {
                    ((DataTable)this.dataGridViewProductList.DataSource).Rows.Clear();
                }
            }
        }

        //新增补充信息
        private void getbcxx()
        {
            #region test
            ////TEST..................................................
            //System.Data.DataTable Detail = new DataTable();
            //Detail.Columns.Add(new DataColumn("Bct10"));
            //Detail.Columns.Add(new DataColumn("Bct20"));
            //Detail.Columns.Add(new DataColumn("Bct50"));
            //Detail.Columns.Add(new DataColumn("Bct51"));
            //Detail.Columns.Add(new DataColumn("Bct60"));
            //Detail.Columns.Add(new DataColumn("Bct61"));
            //Detail.Columns.Add(new DataColumn("Bct70"));
            //Detail.Columns.Add(new DataColumn("Bct71"));
            //Detail.Columns.Add(new DataColumn("Budat"));
            //Detail.Columns.Add(new DataColumn("Charg"));
            //Detail.Columns.Add(new DataColumn("Dmbtr"));
            //Detail.Columns.Add(new DataColumn("Lgort"));
            //Detail.Columns.Add(new DataColumn("Maktx"));
            //Detail.Columns.Add(new DataColumn("Matnr"));
            //Detail.Columns.Add(new DataColumn("Meins"));
            //Detail.Columns.Add(new DataColumn("Menge"));
            //Detail.Columns.Add(new DataColumn("Name1"));
            //Detail.Columns.Add(new DataColumn("Ntgew"));
            //Detail.Columns.Add(new DataColumn("Sgtxt"));
            //Detail.Columns.Add(new DataColumn("Werks"));
            //Detail.Columns.Add(new DataColumn("Zeile"));
            //Detail.Columns.Add(new DataColumn("Ebeln"));
            //Detail.Columns.Add(new DataColumn("Xauto"));
            //for (int i = 0; i < 5; i++)
            //{
            //    System.Data.DataRow dr = Detail.NewRow();
            //    dr["Bct10"] = "BGY" + (i + 1).ToString();
            //    dr["Bct20"] = "Bct20" + (i + 1).ToString();
            //    dr["Bct50"] = "Bct50" + (i + 1).ToString();
            //    dr["Bct51"] = "Bct51" + (i + 1).ToString();
            //    dr["Bct60"] = "Bct60" + (i + 1).ToString();
            //    dr["Bct61"] = "Bct61" + (i + 1).ToString();
            //    dr["Bct70"] = "Bct70" + (i + 1).ToString();
            //    dr["Bct71"] = "Bct71" + (i + 1).ToString();
            //    dr["Budat"] = "Budat" + (i + 1).ToString();
            //    dr["Charg"] = "Charg" + (i + 1).ToString();
            //    dr["Dmbtr"] = "Dmbtr" + (i + 1).ToString();
            //    dr["Lgort"] = "Lgort" + (i + 1).ToString();
            //    dr["Maktx"] = "Maktx" + (i + 1).ToString();
            //    dr["Matnr"] = "Matnr" + (i + 1).ToString();
            //    dr["Meins"] = "Meins" + (i + 1).ToString();
            //    dr["Menge"] = "Menge" + (i + 1).ToString();
            //    dr["Name1"] = "Name1" + (i + 1).ToString();
            //    dr["Ntgew"] = "Ntgew" + (i + 1).ToString();
            //    dr["Sgtxt"] = "Sgtxt" + (i + 1).ToString();
            //    dr["Werks"] = "Werks" + (i + 1).ToString();
            //    dr["Zeile"] = "Zeile" + (i + 1).ToString();
            //    dr["Ebeln"] = "Ebeln" + (i + 1).ToString();
            //    dr["Xauto"] = "Xauto" + (i + 1).ToString();
            //    Detail.Rows.Add(dr);
            //}
            //dsWl.Tables.Add(Detail);
            ////ENDTEST..................................................
            #endregion



            #region m_poDs增加一维条码列
            string proNo = "", patch = "", wareNo = "";
            int _len = this.dsWl.Tables[0].Rows.Count;
            string wltms = "";
            //给m_poDs增加列
            this.dsWl.Tables[0].Columns.Add("N_ywtm");
            this.dsWl.Tables[0].Columns.Add("N_pch");
            this.dsWl.Tables[0].Columns.Add("N_storeman");
            this.dsWl.Tables[0].Columns.Add("N_rkrq");
            this.dsWl.Tables[0].Columns.Add("N_pzh");
            this.dsWl.Tables[0].Columns.Add("N_pznd");
            this.dsWl.Tables[0].Columns.Add("N_ghdw");

            for (int i = 0; i < _len; i++)
            {
                DataRow row = this.dsWl.Tables[0].Rows[i];
                proNo = row["Matnr"].ToString().Trim();
                patch = row["Charg"].ToString().Trim();
                wareNo = row["Werks"].ToString().Trim();
                wltms += "'" +wareNo+ patch +proNo+ "',";
                this.dsWl.Tables[0].Rows[i]["N_ywtm"] = "";
                this.dsWl.Tables[0].Rows[i]["N_pch"] = "";
                this.dsWl.Tables[0].Rows[i]["N_storeman"] = "";
                this.dsWl.Tables[0].Rows[i]["N_rkrq"] = "";
                this.dsWl.Tables[0].Rows[i]["N_pzh"] = "";
                this.dsWl.Tables[0].Rows[i]["N_pznd"] = "";
                this.dsWl.Tables[0].Rows[i]["N_ghdw"] = "";
            }

            wltms = wltms.Substring(0, wltms.Length - 1);
            wltms = "(" + wltms + ")";

            DataSet ds = new DataSet();
            ClsCommon cls = new ClsCommon();
            AnSteel.MessagePack pak = cls.queryYwtms(wltms, out ds);

            if (pak.Code != 0)
            {
                MessageBox.Show(pak.Message);
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < _len; i++)
                {
                    DataRow row = this.dsWl.Tables[0].Rows[i];
                    proNo = row["Matnr"].ToString().Trim();
                    patch = row["Charg"].ToString().Trim();
                    wareNo = row["Werks"].ToString().Trim();
                    string wltm = wareNo + patch + proNo;

                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        if (wltm == ds.Tables[0].Rows[j]["product_barcode"].ToString().Trim())
                        {
                            this.dsWl.Tables[0].Rows[i]["N_ywtm"] = ds.Tables[0].Rows[j]["ywtm"].ToString().Trim();
                            this.dsWl.Tables[0].Rows[i]["N_pch"] = ds.Tables[0].Rows[j]["pch"].ToString().Trim();
                            this.dsWl.Tables[0].Rows[i]["N_storeman"] = ds.Tables[0].Rows[j]["storeman"].ToString().Trim();
                            this.dsWl.Tables[0].Rows[i]["N_rkrq"] = ds.Tables[0].Rows[j]["rkrq"].ToString().Trim();
                            this.dsWl.Tables[0].Rows[i]["N_pzh"] = ds.Tables[0].Rows[j]["pzh"].ToString().Trim();
                            this.dsWl.Tables[0].Rows[i]["N_pznd"] = ds.Tables[0].Rows[j]["pznd"].ToString().Trim();
                            this.dsWl.Tables[0].Rows[i]["N_ghdw"] = ds.Tables[0].Rows[j]["ghdw"].ToString().Trim();
                            break;
                        }
                    }
                }
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dtPrinterList = DBOperate.GetPrinterList("%" + this.txtPrinter.Text + "%", "%");
            this.dataGridViewPrinterList.DataSource = this.dtPrinterList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = this.dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            Settings.Default.DefaultPrinterIP = str;
            Settings.Default.Save();
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
                    str2 = str2 + str3;
                }

                str = str2;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed to convert!!! Please check your input format!" + exception.Message);
            }

            return str;
        }

        private void dataGridViewLocationList_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewProductList.Rows != null) && (this.dataGridViewProductList.SelectedRows.Count != 0))
            {
                if (this.dataGridViewProductList.SelectedRows[0].Cells["ColumnPrintCount"].Value != null)
                {
                    this.txtCopy.Text = this.dataGridViewProductList.SelectedRows[0].Cells["ColumnPrintCount"].Value.ToString();
                    this.btnPrintCountMod.Enabled = true;
                }

                this.btnPrint.Enabled = true;
                this.btnPatchPrint.Enabled = true;
            }
            else
            {
                this.txtCopy.Text = "0";
                this.btnPrintCountMod.Enabled = false;
                this.btnPrint.Enabled = false;
                this.btnPatchPrint.Enabled = false;
            }
        }

        private void dataGridViewPrinterList_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewPrinterList.Rows != null) && (this.dataGridViewPrinterList.SelectedRows.Count != 0))
            {
                this.button2.Enabled = true;
            }
            else
            {
                this.button2.Enabled = false;
            }
        }

        private void dataGridViewProductList_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in (IEnumerable)this.dataGridViewProductList.Rows)
            {
                row.Cells["ColumnPrintCount"].Value = row.Cells["columnQty"].Value;
            }
        }
  
        private void PrintProductLabelNew_Patch(DataGridViewSelectedRowCollection dgvr)
        {
            TcpClient client = new TcpClient();
            string hostname = this.dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            int port = int.Parse(this.dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

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
                    string deNo = this.txtPatch.Text.Trim() == "" ? dgvr[i].Cells["C_N_pzh"].Value.ToString() : this.txtPatch.Text.Trim();
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
                MessageBox.Show(exception.Message);
            }
        }

        private void PrintProductLabelNew_Patch(DataGridViewRowCollection dgvr, bool ifPrintNull)
        {
            TcpClient client = new TcpClient();
            string hostname = this.dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            int port = int.Parse(this.dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

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
                MessageBox.Show(exception.Message);
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.GetNextControl(base.ActiveControl, true).Focus();
            }
        }

        private void textBoxKeeperID_Leave(object sender, EventArgs e)
        {
            if (!this.textBoxKeeperID.Text.Equals(string.Empty) && !CommonFunction.IfHasData(DBOperate.GetUserIDName(this.textBoxKeeperID.Text)))
            {
                MessageBox.Show("找不到相应人员，请确认输入", "数据不存在", MessageBoxButtons.OK);
                this.textBoxKeeperID.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();
            string hostname = this.dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            int port = int.Parse(this.dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

            try
            {
                client.Connect(hostname, port);

                string s = string.Empty;
                s = ClsCommon.dealData("", "(升级测试)电磁阀-Q23XD-2 24V", "20003612110280", "", "", "", "", "", "", "", "", "", "", "", "PC", "303.0000", "", "3000.00", "1", "R20004500005310002020003612110280300", "", this.cmbLabelType.Text);

                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                client.GetStream().Flush();
                s = ClsCommon.dealData("", "(升级测试)电磁阀-Q23XD-2 24V", "20003612110280", "", "", "", "", "", "", "", "", "", "", "", "PC", "303.0000", "", "3000.00", "1", "R20004500005310002020003612110280301", "", this.cmbLabelType.Text);

                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                client.GetStream().Flush();
                s = ClsCommon.dealData("", "(升级测试)电磁阀-Q23XD-2 24V", "20003612110280", "", "", "", "", "", "", "", "", "", "", "", "PC", "303.0000", "", "3000.00", "1", "R20004500005310002020003612110280302", "", this.cmbLabelType.Text);

                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                client.GetStream().Flush();
                s = ClsCommon.dealData("", "(升级测试)电磁阀-Q23XD-2 24V", "20003612110280", "", "", "", "", "", "", "", "", "", "", "", "PC", "303.0000", "", "3000.00", "1", "R20004500005310002020003612110280303", "", this.cmbLabelType.Text);

                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                client.GetStream().Flush();
                s = ClsCommon.dealData("", "(升级测试)电磁阀-Q23XD-2 24V", "20003612110280", "", "", "", "", "", "", "", "", "", "", "", "PC", "303.0000", "", "3000.00", "1", "R20004500005310002020003612110280304", "", this.cmbLabelType.Text);

                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                client.GetStream().Flush();
                s = ClsCommon.dealData("", "(升级测试)电磁阀-Q23XD-2 24V", "20003612110280", "", "", "", "", "", "", "", "", "", "", "", "PC", "303.0000", "", "3000.00", "1", "R20004500005310002020003612110280305", "", this.cmbLabelType.Text);

                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                client.GetStream().Flush();
                s = ClsCommon.dealData("", "(升级测试)电磁阀-Q23XD-2 24V", "20003612110280", "", "", "", "", "", "", "", "", "", "", "", "PC", "303.0000", "", "3000.00", "1", "R20004500005310002020003612110280306", "", this.cmbLabelType.Text);

                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                client.GetStream().Flush();

                client.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}

        //private string dealData(string f, string proName, string proNo, string Patch, string wareNo, string deNo, string ckDate, string manu, string pC, string cert, string pL, string supp, string loca, string q, string u, string w, string r, string p, string cop, string ywtm, string baoguanyuan)
        //{
        //    string str = "";
        //    string str2 = f;
        //    string str3 = proName;
        //    string str4 = proNo;
        //    string str5 = Patch;
        //    string str6 = wareNo;
        //    string str7 = deNo;
        //    string str8 = ckDate;
        //    string str9 = manu;
        //    string str10 = pC;
        //    string str11 = cert;
        //    string str12 = baoguanyuan;// pL;
        //    string str13 = supp;
        //    string str14 = loca;
        //    string str15 = q;
        //    string str16 = u;
        //    string str17 = w;
        //    string str18 = r;
        //    string str19 = p;
        //    string str20 = cop;
        //    if (str3.Length > 20)
        //    {
        //        str3 = str3.Substring(0, 20);
        //    }
        //    str = ((((((((((((((((((str + "@NORMAL\r\n") + "@PAPER;WIDTH 50;LENGTH 99;SPEED IPS 2;INTENSITY 0;LANDSCAPE\r\n" + "@CREATE;ANSTEELLAB\r\n") + "SCALE;DOT;300;300\r\n" + "LOGO\r\n") + "43;380;ANGANG;DISK\r\n" + "STOP\r\n") + "BOX\r\n" + "12;20;22;1100;1740\r\n") + "STOP\r\n" + "HORZ\r\n") + "5;136;22;1740\r\n" + "5;232;22;1740\r\n") + "5;424;22;1740\r\n" + "5;528;22;1740\r\n") + "5;616;22;1740\r\n" + "5;712;22;1740\r\n") + "5;808;22;1740\r\n" + "5;904;22;1740\r\n") + "5;1000;22;1740\r\n" + "5;1096;22;1740\r\n") + "STOP\r\n" + "VERT\r\n") + "5;290;136;1100\r\n" + "5;550;136;232\r\n") + "5;850;424;808\r\n" + "5;710;904;1100\r\n") + "5;750;136;232\r\n" + "5;1100;424;808\r\n") + "5;900;904;1100\r\n" + "5;1150;904;1100\r\n") + "5;1350;904;1100\r\n" + "STOP\r\n") + "FONT;FACE 92250;BOLD OFF;SLANT OFF;SYMSET 0\r\n" + "ALPHA\r\n") + "POINT;205;350;15;15;'" + str2 + "'\r\n";


        //    //条码

            
        //    if (ywtm != "")
        //    {
        //        str = str + "POINT;285;345;15;15;'" + ywtm + "'\r\n";
        //    }
        //    else
        //    {
        //        //原先的物料条码
        //        if ((str5 == null) || str5.Equals(""))
        //        {
        //            str = str + "POINT;285;345;15;15;'" + str4 + "'\r\n";
        //        }
        //        else
        //        {
        //            str = str + "POINT;285;345;15;15;'" + str6 + str5 + str4 + "'\r\n";
        //        }
        //    }
        //    str = (((((((((((((((((((((((((((((str + "POINT;490;350;15;15;'" + str7 + "'\r\n") + "POINT;490;1150;15;15;'" + str4 + "'\r\n") + "POINT;585;350;15;15;'" + str5 + "'\r\n") + "POINT;585;1150;15;15;'" + str8 + "'\r\n") + "POINT;965;350;15;15;'" + str14 + "'\r\n") + "POINT;965;930;15;15;'" + str15 + "'\r\n") + "POINT;1060;930;15;15;'" + str17 + "'\r\n") + "POINT;1060;1370;15;15;'" + str19 + "'\r\n") + "POINT;775;1150;15;15;'" + str12 + "'\r\n") + "POINT;690;350;15;15;'" + str9 + "'\r\n") + "POINT;680;1150;15;15;'" + str10 + "'\r\n") + "POINT;775;350;15;15;'" + str11 + "'\r\n") + "STOP\r\n" + "FONT;FACE 92250;BOLD ON;SLANT OFF;SYMSET 0\r\n") + "TWOBYTE\r\n" + "POINT;110;500;18;18;'鞍钢股份设备处备件卡'\r\n") + "POINT;195;90;10;8;'二级厂'\r\n" + "POINT;205;590;10;8;'物料描述'\r\n") + "POINT;205;810;12;10;'" + str3 + "'\r\n") + "POINT;345;90;10;8;'设备代码'\r\n" + "POINT;490;90;10;8;'采购订单号'\r\n") + "POINT;490;900;10;8;'物料号'\r\n" + "POINT;585;90;10;8;'批次号'\r\n") + "POINT;585;900;10;8;'入库日期'\r\n" + "POINT;680;90;10;8;'说明书'\r\n") + "POINT;680;900;10;8;'产品证书'\r\n" + "POINT;775;90;10;8;'合格证'\r\n") + "POINT;775;900;10;8;'装箱单'\r\n" + "POINT;870;90;10;8;'供货单位'\r\n") + "POINT;880;340;15;15;'" + str13 + "'\r\n") + "POINT;965;90;10;8;'货  位'\r\n") + "POINT;965;730;10;8;'货位数量'\r\n" + "POINT;965;1180;10;8;'货位备注'\r\n") + "POINT;965;1370;10;8;'" + str18 + "'\r\n") + "POINT;1060;90;10;8;'单  位'\r\n") + "POINT;1070;350;15;15;'" + str16 + "'\r\n") + "POINT;1060;730;10;8;'单  重'\r\n") + "POINT;1060;1180;10;8;'单　价'\r\n" + "STOP\r\n") + "BARCODE\r\n" + "C128C;H4.55;DARK;265;345\r\n";
        //    if (ywtm != "")
        //    {
        //        str = str + "*" + ywtm + "*\r\n";
        //    }
        //    else
        //    {
        //        if ((str5 == null) || str5.Equals(""))
        //        {
        //            str = str + "*" + str4 + "*\r\n";
        //        }
        //        else
        //        {
        //            str = str + "*" + str6 + str5 + str4 + "*\r\n";
        //        }
        //    }


        //    str = str + "PDF;S\r\n" + "STOP\r\n";
        //    string old = "";
        //    if (this.cmbLabelType.Text.Equals("RFID标签"))
        //    {
        //        if (ywtm != "")
        //        {
        //            old = ywtm;
        //        }
        //        else
        //        {
        //            if ((str5 == null) || str5.Equals(""))
        //            {
        //                old = str4;
        //            }
        //            else
        //            {
        //                old = str6 + str5 + str4;
        //            }
        //        }
        //        string str22 = (this.Data_Hex(old) + "000000000000000000000000000000000000").Substring(0, 0x44);
        //        str = ((((str + "RFWTAG;272;USR\r\n") + "128;H;*" + str22.Substring(0, 0x20) + "*\r\n") + "128;H;*" + str22.Substring(0x20, 0x20) + "*\r\n") + "16;H;*" + str22.Substring(0x40, 4) + "*\r\n") + "STOP\r\n";
        //    }
        //    return (((str + "END\r\n") + "@EXECUTE;ANSTEELLAB;" + str20 + "\r\n") + "@NORMAL\r\n");
        //}
      

