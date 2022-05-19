using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RFSystem.Properties;
using BL;
using System.Threading;
using RFSystem.CommonClass;
using System.Collections;
using System.Net.Sockets;

namespace RFSystem.Statistic
{
    public class 本地数据库查询 : Form
    {
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
        private DataGridViewTextBoxColumn columnSocket;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private IContainer components;
        private DataGridView dataGridViewPrinterList;
        private DataGridView dataGridViewStock;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataTable dtPlantList;
        private DataTable dtPrinterList;
        private DataTable dtResult;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBoxBarcode;
        private TextBox textBoxBin;
        private TextBox textBoxDes;
        private TextBox textBoxOrderNo;
        private TextBox textBoxStoreMan;
        private TextBox textBoxSubPlant;
        private TextBox textBoxSupplier;
        private Thread thread;
        private TextBox txtCopy;
        private TextBox txtPrinter;
        private UserInfo userItem;
        private DataGridViewTextBoxColumn ColumnFACT_NO;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NO;
        private DataGridViewTextBoxColumn ColumnPATCH_NO;
        private DataGridViewTextBoxColumn ColumnSLocation;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NAME;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private DataGridViewTextBoxColumn ColumnBIN;
        private DataGridViewTextBoxColumn ColumnBct1;
        private DataGridViewTextBoxColumn ColumnBct60;
        private DataGridViewTextBoxColumn ColumnBct61;
        private DataGridViewTextBoxColumn ColumnBct70;
        private DataGridViewTextBoxColumn ColumnBct71;
        private DataGridViewTextBoxColumn ColumnStoreManDetail;
        private DataGridViewTextBoxColumn ColumnSUPPLIER_NO;
        private DataGridViewTextBoxColumn ColumnBillNo;
        private DataGridViewTextBoxColumn ColumnPName;
        private DataGridViewTextBoxColumn ColumnWeight;
        private DataGridViewTextBoxColumn ColumnVerpr;
        private DataGridViewTextBoxColumn ColumnMenge;
        private DataGridViewTextBoxColumn ColumnPrintCount;
        private DataGridViewTextBoxColumn YWTM;
        private DataGridViewTextBoxColumn PZH;
        private DataGridViewTextBoxColumn RKRQ;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSubPlant = new System.Windows.Forms.TextBox();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.btnPrintCountMod = new System.Windows.Forms.Button();
            this.txtCopy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPatchPrint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(1046, 595);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 1000;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxSubPlant);
            this.groupBox1.Controls.Add(this.textBoxBarcode);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBoxPlant);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxSLocation);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1134, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地数据库查询";
            // 
            // textBoxSupplier
            // 
            this.textBoxSupplier.Location = new System.Drawing.Point(481, 59);
            this.textBoxSupplier.Name = "textBoxSupplier";
            this.textBoxSupplier.Size = new System.Drawing.Size(110, 26);
            this.textBoxSupplier.TabIndex = 80;
            this.textBoxSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 87;
            this.label5.Text = "供 应 商：";
            // 
            // textBoxOrderNo
            // 
            this.textBoxOrderNo.Location = new System.Drawing.Point(85, 59);
            this.textBoxOrderNo.Name = "textBoxOrderNo";
            this.textBoxOrderNo.Size = new System.Drawing.Size(110, 26);
            this.textBoxOrderNo.TabIndex = 60;
            this.textBoxOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(871, 25);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(110, 26);
            this.textBoxBin.TabIndex = 50;
            this.textBoxBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(798, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "货    位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "订 单 号：";
            // 
            // textBoxDes
            // 
            this.textBoxDes.Location = new System.Drawing.Point(682, 25);
            this.textBoxDes.Name = "textBoxDes";
            this.textBoxDes.Size = new System.Drawing.Size(110, 26);
            this.textBoxDes.TabIndex = 40;
            this.textBoxDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(597, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 83;
            this.label1.Text = "物品名称：";
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.Location = new System.Drawing.Point(676, 59);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.ReadOnly = true;
            this.textBoxStoreMan.Size = new System.Drawing.Size(110, 26);
            this.textBoxStoreMan.TabIndex = 90;
            this.textBoxStoreMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(597, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 81;
            this.label2.Text = "保 管 员：";
            // 
            // textBoxSubPlant
            // 
            this.textBoxSubPlant.Location = new System.Drawing.Point(286, 59);
            this.textBoxSubPlant.Name = "textBoxSubPlant";
            this.textBoxSubPlant.Size = new System.Drawing.Size(110, 26);
            this.textBoxSubPlant.TabIndex = 70;
            this.textBoxSubPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Location = new System.Drawing.Point(481, 25);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(110, 26);
            this.textBoxBarcode.TabIndex = 30;
            this.textBoxBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(1008, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 100;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            this.btnSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(402, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "条 码 号：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(85, 25);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(110, 28);
            this.comboBoxPlant.TabIndex = 10;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            this.comboBoxPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "公    司：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(286, 25);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(110, 28);
            this.comboBoxSLocation.TabIndex = 20;
            this.comboBoxSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "库存地点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "二 级 厂：";
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
            this.dataGridViewStock.Location = new System.Drawing.Point(12, 118);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.RowHeadersVisible = false;
            this.dataGridViewStock.RowTemplate.Height = 23;
            this.dataGridViewStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStock.Size = new System.Drawing.Size(1134, 364);
            this.dataGridViewStock.TabIndex = 110;
            this.dataGridViewStock.SelectionChanged += new System.EventHandler(this.dataGridViewStock_SelectionChanged);
            this.dataGridViewStock.Sorted += new System.EventHandler(this.dataGridViewStock_Sorted);
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
            // btnPrintCountMod
            // 
            this.btnPrintCountMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintCountMod.Enabled = false;
            this.btnPrintCountMod.Location = new System.Drawing.Point(1046, 499);
            this.btnPrintCountMod.Name = "btnPrintCountMod";
            this.btnPrintCountMod.Size = new System.Drawing.Size(100, 40);
            this.btnPrintCountMod.TabIndex = 1003;
            this.btnPrintCountMod.Text = "修改";
            this.btnPrintCountMod.UseVisualStyleBackColor = true;
            this.btnPrintCountMod.Click += new System.EventHandler(this.btnPrintCountMod_Click);
            // 
            // txtCopy
            // 
            this.txtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopy.Location = new System.Drawing.Point(976, 506);
            this.txtCopy.Name = "txtCopy";
            this.txtCopy.Size = new System.Drawing.Size(64, 26);
            this.txtCopy.TabIndex = 1002;
            this.txtCopy.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(891, 509);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1001;
            this.label10.Text = "打印份数：";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(940, 549);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 1004;
            this.btnPrint.Text = "单个打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPatchPrint
            // 
            this.btnPatchPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPatchPrint.Enabled = false;
            this.btnPatchPrint.Location = new System.Drawing.Point(1046, 549);
            this.btnPatchPrint.Name = "btnPatchPrint";
            this.btnPatchPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPatchPrint.TabIndex = 1005;
            this.btnPatchPrint.Text = "批量打印";
            this.btnPatchPrint.UseVisualStyleBackColor = true;
            this.btnPatchPrint.Click += new System.EventHandler(this.btnPatchPrint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.cmbLabelType);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtPrinter);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dataGridViewPrinterList);
            this.groupBox2.Location = new System.Drawing.Point(22, 488);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 147);
            this.groupBox2.TabIndex = 1006;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打印机选择";
            // 
            // cmbLabelType
            // 
            this.cmbLabelType.FormattingEnabled = true;
            this.cmbLabelType.Items.AddRange(new object[] {
            "普通标签",
            "RFID标签"});
            this.cmbLabelType.Location = new System.Drawing.Point(412, 57);
            this.cmbLabelType.Name = "cmbLabelType";
            this.cmbLabelType.Size = new System.Drawing.Size(100, 28);
            this.cmbLabelType.TabIndex = 1102;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(518, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 1101;
            this.button2.Text = "默认打印机";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 101;
            this.button1.Text = "查找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(412, 25);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(100, 26);
            this.txtPrinter.TabIndex = 102;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(341, 28);
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
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(10, 23);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(325, 109);
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
            // 
            // columnSocket
            // 
            this.columnSocket.DataPropertyName = "PrinterSocket";
            this.columnSocket.HeaderText = "端口号";
            this.columnSocket.Name = "columnSocket";
            this.columnSocket.ReadOnly = true;
            // 
            // 本地数据库查询
            // 
            this.ClientSize = new System.Drawing.Size(1158, 647);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPatchPrint);
            this.Controls.Add(this.btnPrintCountMod);
            this.Controls.Add(this.txtCopy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridViewStock);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "本地数据库查询";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "本地数据库查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.本地数据库查询_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 本地数据库查询(UserInfo userItem, ArrayList userRoles)
        {
            this.components = null;
            this.userItem = null;
            this.userRoles = null;
            this.dtPlantList = null;
            this.dtStoreLocusList = null;
            this.dtPrinterList = null;
            this.thread = null;
            this.InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;

            if (userItem.isAdmin)
            {
                this.textBoxStoreMan.ReadOnly = false;
            }

            this.textBoxStoreMan.Text = this.userItem.userID;
            this.dtPlantList = DBOperate.GetPlantList(string.Empty);
            this.dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, string.Empty);
            this.comboBoxSLocation.Items.Add("无");
            this.comboBoxSLocation.SelectedIndex = 0;
            this.comboBoxPlant.Items.Add("无");

            if (CommonFunction.IfHasData(this.dtPlantList))
            {
                foreach (DataRow row in this.dtPlantList.Rows)
                {
                    this.comboBoxPlant.Items.Add(row["PlantID"].ToString());
                }
            }

            this.comboBoxPlant.SelectedIndex = 0;
            this.dataGridViewStock.AutoGenerateColumns = false;
            this.dtPrinterList = DBOperate.GetPrinterList("%", "%" + Settings.Default.DefaultPrinterIP.ToString() + "%");
            this.dataGridViewPrinterList.DataSource = this.dtPrinterList;
            this.cmbLabelType.Text = "普通标签";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPatchPrint_Click(object sender, EventArgs e)
        {
            this.PrintProductLabelNew_Patch(this.dataGridViewStock.Rows);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.PrintProductLabelNew_Patch(this.dataGridViewStock.SelectedRows);
        }

        private void btnPrintCountMod_Click(object sender, EventArgs e)
        {
            this.dataGridViewStock.SelectedRows[0].Cells["ColumnPrintCount"].Value = this.txtCopy.Text;
            this.dataGridViewStock_SelectionChanged(null, null);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(this.ShowWaitingMsg));
            this.thread.Start();
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

        private void comboBoxPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxSLocation.Items.Clear();
            this.comboBoxSLocation.Items.Add("无");

            foreach (DataRow row in this.dtStoreLocusList.Select("PlantID='" + this.comboBoxPlant.Text + "'"))
            {
                this.comboBoxSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            this.comboBoxSLocation.SelectedIndex = 0;
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

        private void dataGridViewStock_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewStock.Rows != null) && (this.dataGridViewStock.SelectedRows.Count != 0))
            {
                if (this.dataGridViewStock.SelectedRows[0].Cells["ColumnPrintCount"].Value != null)
                {
                    //this.txtCopy.Text = this.dataGridViewStock.SelectedRows[0].Cells["ColumnPrintCount"].Value.ToString();
                    this.txtCopy.Text ="1";
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

        private void dataGridViewStock_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in (IEnumerable)this.dataGridViewStock.Rows)
            {
                row.Cells["ColumnPrintCount"].Value = row.Cells["ColumnMenge"].Value;
            }
        }

        private Control GetNextSelectControl(Control activeControl)
        {
            Control nextControl = null;
            nextControl = base.GetNextControl(activeControl, true);

            if ((!nextControl.Enabled || !nextControl.TabStop) || (nextControl.TabStop && !nextControl.CanSelect))
            {
                nextControl = this.GetNextSelectControl(nextControl);
            }

            return nextControl;
        }

        private void PrintProductLabelNew_Patch(DataGridViewRowCollection dgvr)
        {
            if (this.dataGridViewPrinterList.RowCount < 1)
            {
                MessageBox.Show("请指定打印机!");
            }
            else
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
                        string f = dgvr[i].Cells["ColumnSUPPLIER_NO"].Value.ToString();
                        string proName = dgvr[i].Cells["ColumnPRODUCT_NAME"].Value.ToString();
                        string proNo = dgvr[i].Cells["ColumnPRODUCT_NO"].Value.ToString();
                        string patch = dgvr[i].Cells["ColumnPATCH_NO"].Value.ToString();
                        string wareNo = dgvr[i].Cells["ColumnFACT_NO"].Value.ToString();
                        string deNo = dgvr[i].Cells["pzh"].Value.ToString();//凭证号 string.Empty;
                        string ckDate = dgvr[i].Cells["rkrq"].Value.ToString();//入库日期 string.Empty;
                        string manu = "";
                        string pC = dgvr[i].Cells["ColumnBillNo"].Value.ToString();//ColumnBillNo
                        string cert = "";
                        string pL = "";
                        string supp = dgvr[i].Cells["ColumnPName"].Value.ToString();
                        string loca = dgvr[i].Cells["ColumnBIN"].Value.ToString();
                        string q = dgvr[i].Cells["ColumnBct1"].Value.ToString();
                        string r = "";
                        string u = dgvr[i].Cells["ColumnUNIT"].Value.ToString();
                        string w = dgvr[i].Cells["ColumnWeight"].Value.ToString();
                        string p = dgvr[i].Cells["ColumnVerpr"].Value.ToString();
                        //string cop = Math.Truncate(Convert.ToDecimal(dgvr[i].Cells["ColumnPrintCount"].Value)).ToString();
                        string cop = "1";

                        string baoguanyuan = dgvr[i].Cells["ColumnStoreManDetail"].Value.ToString();
                        string ywtm = dgvr[i].Cells["ywtm"].Value.ToString();
                        //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                        s = ClsCommon.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, this.cmbLabelType.Text);
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
        }

        private void PrintProductLabelNew_Patch(DataGridViewSelectedRowCollection dgvr)
        {
            if (this.dataGridViewPrinterList.RowCount < 1)
            {
                MessageBox.Show("请指定打印机!");
            }
            else
            {
                TcpClient client = new TcpClient();
                //string hostname = "192.1.77.12";
                //int port = 9100;
                string hostname = this.dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
                int port = int.Parse(this.dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

                try
                {
                    client.Connect(hostname, port);

                    for (int i = 0; i < dgvr.Count; i++)
                    {
                        string s = string.Empty;
                        string f = dgvr[i].Cells["ColumnSUPPLIER_NO"].Value.ToString();
                        string proName = dgvr[i].Cells["ColumnPRODUCT_NAME"].Value.ToString();
                        string proNo = dgvr[i].Cells["ColumnPRODUCT_NO"].Value.ToString();
                        string patch = dgvr[i].Cells["ColumnPATCH_NO"].Value.ToString();
                        string wareNo = dgvr[i].Cells["ColumnFACT_NO"].Value.ToString();
                        string deNo = dgvr[i].Cells["pzh"].Value.ToString();//凭证号 string.Empty;
                        string ckDate = dgvr[i].Cells["rkrq"].Value.ToString();//入库日期 string.Empty;
                        string manu = "";
                        string pC = dgvr[i].Cells["ColumnBillNo"].Value.ToString(); 
                        string cert = "";
                        string pL = "";
                        string supp = dgvr[i].Cells["ColumnPName"].Value.ToString();
                        string loca = dgvr[i].Cells["ColumnBIN"].Value.ToString();
                        string q = dgvr[i].Cells["ColumnBct1"].Value.ToString();
                        string r = "";
                        string u = dgvr[i].Cells["ColumnUNIT"].Value.ToString();
                        string w = dgvr[i].Cells["ColumnWeight"].Value.ToString();
                        string p = dgvr[i].Cells["ColumnVerpr"].Value.ToString();
                        //string cop = Math.Truncate(Convert.ToDecimal(dgvr[i].Cells["ColumnPrintCount"].Value)).ToString();
                        string cop = this.txtCopy.Text;
                        string baoguanyuan = dgvr[i].Cells["ColumnStoreManDetail"].Value.ToString();
                        string ywtm =  dgvr[i].Cells["ywtm"].Value.ToString();//"R2000450000531020000401030814";
                        //string ywtm = "R2000450000531020000401030814";
                        //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                        s = ClsCommon.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, this.cmbLabelType.Text);
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
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.GetNextSelectControl(base.ActiveControl).Focus();
            }
        }

        private void ShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ArrayList alParams = new ArrayList();
                alParams.Add(this.comboBoxPlant.Text.Equals("无") ? string.Empty : this.comboBoxPlant.Text);
                alParams.Add(this.comboBoxSLocation.Text.Equals("无") ? string.Empty : this.comboBoxSLocation.Text);
                alParams.Add(this.textBoxBarcode.Text.Trim());
                alParams.Add(this.textBoxDes.Text.Trim());
                alParams.Add(this.textBoxBin.Text.Trim());
                alParams.Add(this.textBoxOrderNo.Text.Trim());
                alParams.Add(this.textBoxSubPlant.Text.Trim());
                alParams.Add(this.textBoxSupplier.Text.Trim());
                alParams.Add(this.textBoxStoreMan.Text.Trim());
                //this.dtResult = DBOperate.LocalStockGetList_New(alParams);
                this.dtResult = BL.ClsCommon.LocalStockGetList_New(alParams);

                if (CommonFunction.IfHasData(this.dtResult))
                {
                    this.dataGridViewStock.DataSource = this.dtResult;
                }
                else
                {
                    this.dataGridViewStock.DataSource = this.dtResult;
                    MessageBox.Show("没有检索到任何数据，请重新检索");
                }

                this.dataGridViewStock_SelectionChanged(null, null);
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
            base.Invoke(new EventHandler(this.ShowMsg));
        }

        private void 本地数据库查询_Load(object sender, EventArgs e)
        {

        }
    }
}
