using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using RFSystem.AnSteel;

namespace RFSystem
{
    public class 制定保养单 : Form
    {
        // Fields
        private Button btnAddItem;
        private Button btnClear;
        private Button btnDelMain;
        private Button btnItemDel;
        private Button btnMaintainPlan;
        private Button btnModPlanNum;
        private DataGridViewTextBoxColumn ColumnBARCODE;
        private DataGridViewTextBoxColumn ColumnBIN;
        private DataGridViewTextBoxColumn ColumnBIN_NUM;
        private DataGridViewTextBoxColumn ColumnFACT_NO;
        private DataGridViewTextBoxColumn ColumnFACTORY_NO;
        private DataGridViewTextBoxColumn ColumnMAINTAINNUM;
        private DataGridViewTextBoxColumn ColumnOPERATE_TIME;
        private DataGridViewTextBoxColumn ColumnOPERATOR;
        private DataGridViewTextBoxColumn ColumnPATCH_NO;
        private DataGridViewTextBoxColumn ColumnPLAN_NUM;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NAME;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NO;
        private DataGridViewTextBoxColumn ColumnSL;
        private DataGridViewTextBoxColumn ColumnSTOREMAN;
        private DataGridViewTextBoxColumn ColumnSUPPLIER_NO;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private DataGridViewTextBoxColumn ColumnWeight;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private DataGridView dataGridViewMaintain;
        private DataGridView dataGridViewSapStockInfo;
        private DataTable dtGoods;
        private DataTable dtMaintain;
        private DataTable dtPlantList;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBoxInputInfo;
        private Label label1;
        private Label label23;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBoxBin;
        private TextBox textBoxBinDel;
        private TextBox textBoxPlanNum;
        private TextBox textBoxSTOREMAN;
        private UserInfo userItem;
        private TextBox labelMaintainID;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.groupBoxInputInfo = new System.Windows.Forms.GroupBox();
            this.labelMaintainID = new System.Windows.Forms.TextBox();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxSTOREMAN = new System.Windows.Forms.TextBox();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewMaintain = new System.Windows.Forms.DataGridView();
            this.ColumnFACTORY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTOREMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOPERATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOPERATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelMain = new System.Windows.Forms.Button();
            this.dataGridViewSapStockInfo = new System.Windows.Forms.DataGridView();
            this.ColumnBARCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFACT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPATCH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBIN_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPLAN_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMAINTAINNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSUPPLIER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMaintainPlan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBinDel = new System.Windows.Forms.TextBox();
            this.btnItemDel = new System.Windows.Forms.Button();
            this.textBoxPlanNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnModPlanNum = new System.Windows.Forms.Button();
            this.groupBoxInputInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInputInfo
            // 
            this.groupBoxInputInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInputInfo.Controls.Add(this.labelMaintainID);
            this.groupBoxInputInfo.Controls.Add(this.textBoxBin);
            this.groupBoxInputInfo.Controls.Add(this.label23);
            this.groupBoxInputInfo.Controls.Add(this.textBoxSTOREMAN);
            this.groupBoxInputInfo.Controls.Add(this.comboBoxSLocation);
            this.groupBoxInputInfo.Controls.Add(this.label5);
            this.groupBoxInputInfo.Controls.Add(this.label4);
            this.groupBoxInputInfo.Controls.Add(this.comboBoxPlant);
            this.groupBoxInputInfo.Controls.Add(this.btnClear);
            this.groupBoxInputInfo.Controls.Add(this.btnAddItem);
            this.groupBoxInputInfo.Controls.Add(this.label3);
            this.groupBoxInputInfo.Controls.Add(this.label1);
            this.groupBoxInputInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInputInfo.Name = "groupBoxInputInfo";
            this.groupBoxInputInfo.Size = new System.Drawing.Size(988, 100);
            this.groupBoxInputInfo.TabIndex = 0;
            this.groupBoxInputInfo.TabStop = false;
            this.groupBoxInputInfo.Text = "保养单信息添加";
            // 
            // labelMaintainID
            // 
            this.labelMaintainID.Location = new System.Drawing.Point(91, 25);
            this.labelMaintainID.Name = "labelMaintainID";
            this.labelMaintainID.ReadOnly = true;
            this.labelMaintainID.Size = new System.Drawing.Size(150, 26);
            this.labelMaintainID.TabIndex = 511;
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(91, 57);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(150, 26);
            this.textBoxBin.TabIndex = 60;
            this.textBoxBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(247, 60);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "保管员码：";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSTOREMAN
            // 
            this.textBoxSTOREMAN.Location = new System.Drawing.Point(332, 57);
            this.textBoxSTOREMAN.Name = "textBoxSTOREMAN";
            this.textBoxSTOREMAN.ReadOnly = true;
            this.textBoxSTOREMAN.Size = new System.Drawing.Size(150, 26);
            this.textBoxSTOREMAN.TabIndex = 50;
            this.textBoxSTOREMAN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            this.textBoxSTOREMAN.Leave += new System.EventHandler(this.textBoxSTOREMAN_Leave);
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(573, 25);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(150, 28);
            this.comboBoxSLocation.TabIndex = 40;
            this.comboBoxSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(488, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "库存地点：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "公司号：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(332, 25);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(150, 28);
            this.comboBoxPlant.TabIndex = 30;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            this.comboBoxPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(776, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 510;
            this.btnClear.Text = "清空信息";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Location = new System.Drawing.Point(882, 25);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 40);
            this.btnAddItem.TabIndex = 70;
            this.btnAddItem.Text = "添加信息";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "货 位 号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "保养单号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewMaintain);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 193);
            this.groupBox2.TabIndex = 200;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保养单基本信息";
            // 
            // dataGridViewMaintain
            // 
            this.dataGridViewMaintain.AllowUserToAddRows = false;
            this.dataGridViewMaintain.AllowUserToResizeRows = false;
            this.dataGridViewMaintain.ColumnHeadersHeight = 30;
            this.dataGridViewMaintain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMaintain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFACTORY_NO,
            this.ColumnSL,
            this.ColumnSTOREMAN,
            this.ColumnOPERATOR,
            this.ColumnOPERATE_TIME});
            this.dataGridViewMaintain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMaintain.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewMaintain.MultiSelect = false;
            this.dataGridViewMaintain.Name = "dataGridViewMaintain";
            this.dataGridViewMaintain.ReadOnly = true;
            this.dataGridViewMaintain.RowHeadersVisible = false;
            this.dataGridViewMaintain.RowTemplate.Height = 23;
            this.dataGridViewMaintain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintain.Size = new System.Drawing.Size(982, 168);
            this.dataGridViewMaintain.TabIndex = 20000;
            this.dataGridViewMaintain.SelectionChanged += new System.EventHandler(this.dataGridViewMaintain_SelectionChanged);
            // 
            // ColumnFACTORY_NO
            // 
            this.ColumnFACTORY_NO.DataPropertyName = "FACTORY_NO";
            this.ColumnFACTORY_NO.HeaderText = "公司";
            this.ColumnFACTORY_NO.Name = "ColumnFACTORY_NO";
            this.ColumnFACTORY_NO.ReadOnly = true;
            // 
            // ColumnSL
            // 
            this.ColumnSL.DataPropertyName = "SL";
            this.ColumnSL.HeaderText = "库存地点";
            this.ColumnSL.Name = "ColumnSL";
            this.ColumnSL.ReadOnly = true;
            this.ColumnSL.Width = 120;
            // 
            // ColumnSTOREMAN
            // 
            this.ColumnSTOREMAN.DataPropertyName = "STOREMAN";
            this.ColumnSTOREMAN.HeaderText = "保管员";
            this.ColumnSTOREMAN.Name = "ColumnSTOREMAN";
            this.ColumnSTOREMAN.ReadOnly = true;
            // 
            // ColumnOPERATOR
            // 
            this.ColumnOPERATOR.DataPropertyName = "OPERATOR";
            this.ColumnOPERATOR.HeaderText = "制单人";
            this.ColumnOPERATOR.Name = "ColumnOPERATOR";
            this.ColumnOPERATOR.ReadOnly = true;
            // 
            // ColumnOPERATE_TIME
            // 
            this.ColumnOPERATE_TIME.DataPropertyName = "OPERATE_TIME";
            this.ColumnOPERATE_TIME.HeaderText = "制单日期";
            this.ColumnOPERATE_TIME.Name = "ColumnOPERATE_TIME";
            this.ColumnOPERATE_TIME.ReadOnly = true;
            this.ColumnOPERATE_TIME.Width = 175;
            // 
            // btnDelMain
            // 
            this.btnDelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelMain.Enabled = false;
            this.btnDelMain.Location = new System.Drawing.Point(232, 577);
            this.btnDelMain.Name = "btnDelMain";
            this.btnDelMain.Size = new System.Drawing.Size(100, 40);
            this.btnDelMain.TabIndex = 90;
            this.btnDelMain.Text = "删除";
            this.btnDelMain.UseVisualStyleBackColor = true;
            this.btnDelMain.Click += new System.EventHandler(this.btnDelMain_Click);
            // 
            // dataGridViewSapStockInfo
            // 
            this.dataGridViewSapStockInfo.AllowUserToAddRows = false;
            this.dataGridViewSapStockInfo.AllowUserToResizeRows = false;
            this.dataGridViewSapStockInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSapStockInfo.ColumnHeadersHeight = 30;
            this.dataGridViewSapStockInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSapStockInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBARCODE,
            this.ColumnFACT_NO,
            this.ColumnPRODUCT_NO,
            this.ColumnPATCH_NO,
            this.ColumnPRODUCT_NAME,
            this.ColumnBIN_NUM,
            this.ColumnWeight,
            this.ColumnUNIT,
            this.ColumnPLAN_NUM,
            this.ColumnMAINTAINNUM,
            this.ColumnBIN,
            this.ColumnSUPPLIER_NO});
            this.dataGridViewSapStockInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSapStockInfo.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewSapStockInfo.MultiSelect = false;
            this.dataGridViewSapStockInfo.Name = "dataGridViewSapStockInfo";
            this.dataGridViewSapStockInfo.ReadOnly = true;
            this.dataGridViewSapStockInfo.RowHeadersVisible = false;
            this.dataGridViewSapStockInfo.RowTemplate.Height = 23;
            this.dataGridViewSapStockInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSapStockInfo.Size = new System.Drawing.Size(982, 229);
            this.dataGridViewSapStockInfo.TabIndex = 30000;
            this.dataGridViewSapStockInfo.SelectionChanged += new System.EventHandler(this.dataGridViewSapStockInfo_SelectionChanged);
            // 
            // ColumnBARCODE
            // 
            this.ColumnBARCODE.DataPropertyName = "BARCODE";
            this.ColumnBARCODE.HeaderText = "条码号";
            this.ColumnBARCODE.Name = "ColumnBARCODE";
            this.ColumnBARCODE.ReadOnly = true;
            this.ColumnBARCODE.Visible = false;
            this.ColumnBARCODE.Width = 61;
            // 
            // ColumnFACT_NO
            // 
            this.ColumnFACT_NO.DataPropertyName = "FACT_NO";
            this.ColumnFACT_NO.HeaderText = "公司号";
            this.ColumnFACT_NO.Name = "ColumnFACT_NO";
            this.ColumnFACT_NO.ReadOnly = true;
            this.ColumnFACT_NO.Visible = false;
            this.ColumnFACT_NO.Width = 61;
            // 
            // ColumnPRODUCT_NO
            // 
            this.ColumnPRODUCT_NO.DataPropertyName = "PRODUCT_NO";
            this.ColumnPRODUCT_NO.HeaderText = "物料号";
            this.ColumnPRODUCT_NO.Name = "ColumnPRODUCT_NO";
            this.ColumnPRODUCT_NO.ReadOnly = true;
            this.ColumnPRODUCT_NO.Width = 76;
            // 
            // ColumnPATCH_NO
            // 
            this.ColumnPATCH_NO.DataPropertyName = "PATCH_NO";
            this.ColumnPATCH_NO.HeaderText = "批次号";
            this.ColumnPATCH_NO.Name = "ColumnPATCH_NO";
            this.ColumnPATCH_NO.ReadOnly = true;
            this.ColumnPATCH_NO.Width = 76;
            // 
            // ColumnPRODUCT_NAME
            // 
            this.ColumnPRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.ColumnPRODUCT_NAME.HeaderText = "物品名称";
            this.ColumnPRODUCT_NAME.Name = "ColumnPRODUCT_NAME";
            this.ColumnPRODUCT_NAME.ReadOnly = true;
            this.ColumnPRODUCT_NAME.Width = 90;
            // 
            // ColumnBIN_NUM
            // 
            this.ColumnBIN_NUM.DataPropertyName = "BIN_NUM";
            this.ColumnBIN_NUM.HeaderText = "数量";
            this.ColumnBIN_NUM.Name = "ColumnBIN_NUM";
            this.ColumnBIN_NUM.ReadOnly = true;
            this.ColumnBIN_NUM.Width = 62;
            // 
            // ColumnWeight
            // 
            this.ColumnWeight.DataPropertyName = "Weight";
            this.ColumnWeight.HeaderText = "单重";
            this.ColumnWeight.Name = "ColumnWeight";
            this.ColumnWeight.ReadOnly = true;
            this.ColumnWeight.Width = 62;
            // 
            // ColumnUNIT
            // 
            this.ColumnUNIT.DataPropertyName = "UNIT";
            this.ColumnUNIT.HeaderText = "单位";
            this.ColumnUNIT.Name = "ColumnUNIT";
            this.ColumnUNIT.ReadOnly = true;
            this.ColumnUNIT.Width = 62;
            // 
            // ColumnPLAN_NUM
            // 
            this.ColumnPLAN_NUM.DataPropertyName = "PLAN_NUM";
            this.ColumnPLAN_NUM.HeaderText = "计划数量";
            this.ColumnPLAN_NUM.Name = "ColumnPLAN_NUM";
            this.ColumnPLAN_NUM.ReadOnly = true;
            this.ColumnPLAN_NUM.Width = 90;
            // 
            // ColumnMAINTAINNUM
            // 
            this.ColumnMAINTAINNUM.DataPropertyName = "MAINTAINNUM";
            this.ColumnMAINTAINNUM.HeaderText = "保养数量";
            this.ColumnMAINTAINNUM.Name = "ColumnMAINTAINNUM";
            this.ColumnMAINTAINNUM.ReadOnly = true;
            this.ColumnMAINTAINNUM.Visible = false;
            this.ColumnMAINTAINNUM.Width = 61;
            // 
            // ColumnBIN
            // 
            this.ColumnBIN.DataPropertyName = "BIN";
            this.ColumnBIN.HeaderText = "货位";
            this.ColumnBIN.Name = "ColumnBIN";
            this.ColumnBIN.ReadOnly = true;
            this.ColumnBIN.Width = 62;
            // 
            // ColumnSUPPLIER_NO
            // 
            this.ColumnSUPPLIER_NO.DataPropertyName = "SUPPLIER_NO";
            this.ColumnSUPPLIER_NO.HeaderText = "生产厂代码";
            this.ColumnSUPPLIER_NO.Name = "ColumnSUPPLIER_NO";
            this.ColumnSUPPLIER_NO.ReadOnly = true;
            this.ColumnSUPPLIER_NO.Visible = false;
            this.ColumnSUPPLIER_NO.Width = 72;
            // 
            // btnMaintainPlan
            // 
            this.btnMaintainPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaintainPlan.Enabled = false;
            this.btnMaintainPlan.Location = new System.Drawing.Point(900, 577);
            this.btnMaintainPlan.Name = "btnMaintainPlan";
            this.btnMaintainPlan.Size = new System.Drawing.Size(100, 40);
            this.btnMaintainPlan.TabIndex = 500;
            this.btnMaintainPlan.Text = "生成保养单";
            this.btnMaintainPlan.UseVisualStyleBackColor = true;
            this.btnMaintainPlan.Click += new System.EventHandler(this.btnMaintainPlan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewSapStockInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 254);
            this.groupBox1.TabIndex = 300;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保养货物信息";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 587);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "需删除的货位号：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxBinDel
            // 
            this.textBoxBinDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxBinDel.Location = new System.Drawing.Point(135, 584);
            this.textBoxBinDel.Name = "textBoxBinDel";
            this.textBoxBinDel.Size = new System.Drawing.Size(91, 26);
            this.textBoxBinDel.TabIndex = 80;
            // 
            // btnItemDel
            // 
            this.btnItemDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnItemDel.Enabled = false;
            this.btnItemDel.Location = new System.Drawing.Point(338, 577);
            this.btnItemDel.Name = "btnItemDel";
            this.btnItemDel.Size = new System.Drawing.Size(100, 40);
            this.btnItemDel.TabIndex = 521;
            this.btnItemDel.Text = "条目删除";
            this.btnItemDel.UseVisualStyleBackColor = true;
            this.btnItemDel.Click += new System.EventHandler(this.btnItemDel_Click);
            // 
            // textBoxPlanNum
            // 
            this.textBoxPlanNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPlanNum.Location = new System.Drawing.Point(557, 584);
            this.textBoxPlanNum.Name = "textBoxPlanNum";
            this.textBoxPlanNum.Size = new System.Drawing.Size(91, 26);
            this.textBoxPlanNum.TabIndex = 523;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(444, 587);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 522;
            this.label7.Text = "保养计划数量：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnModPlanNum
            // 
            this.btnModPlanNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModPlanNum.Enabled = false;
            this.btnModPlanNum.Location = new System.Drawing.Point(654, 577);
            this.btnModPlanNum.Name = "btnModPlanNum";
            this.btnModPlanNum.Size = new System.Drawing.Size(100, 40);
            this.btnModPlanNum.TabIndex = 524;
            this.btnModPlanNum.Text = "修改";
            this.btnModPlanNum.UseVisualStyleBackColor = true;
            this.btnModPlanNum.Click += new System.EventHandler(this.btnModPlanNum_Click);
            // 
            // 制定保养单
            // 
            this.ClientSize = new System.Drawing.Size(1012, 629);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxPlanNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnModPlanNum);
            this.Controls.Add(this.btnItemDel);
            this.Controls.Add(this.textBoxBinDel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDelMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMaintainPlan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxInputInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "制定保养单";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "制定保养单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.制定保养单_Load);
            this.groupBoxInputInfo.ResumeLayout(false);
            this.groupBoxInputInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 制定保养单(UserInfo userItem, ArrayList userRoles)
        {
            this.userItem = null;
            this.userRoles = null;
            dtMaintain = null;
            dtGoods = null;
            dtPlantList = null;
            dtStoreLocusList = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            labelMaintainID.Text = this.userItem.userID + DateTime.Now.ToString("yyMMdd") + "****";
            textBoxSTOREMAN.Text = userItem.userID;

            if (userItem.isAdmin)
            {
                textBoxSTOREMAN.ReadOnly = false;
            }

            InitFctAndStore();
            InitTableColumns();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!comboBoxPlant.Text.Trim().Equals("无") && !comboBoxSLocation.Text.Trim().Equals("无") && !textBoxBin.Text.Trim().Equals(string.Empty) && !textBoxSTOREMAN.Text.Trim().Equals(string.Empty))
            {
                DataSet cxDs = new DataSet("货位查询");
                MessagePack pack = new MessagePack();

                try
                {
                    pack = Utility.getSerive().GetHWCXInfo(textBoxSTOREMAN.Text, textBoxBin.Text, comboBoxSLocation.Text, comboBoxPlant.Text, out cxDs);
                }
                catch
                {
                    CommonFunction.Sys_MsgBox(pack.Message);
                }

                if (pack.Code == 0)
                {
                    if (FilterTheUsefulInfo(cxDs.Tables[0], dtGoods, textBoxBin.Text) && !CommonFunction.IfHasData(dtMaintain))
                    {
                        dtMaintain.Rows.Add(new object[] { comboBoxPlant.Text, comboBoxSLocation.Text, textBoxSTOREMAN.Text, userItem.userID, DateTime.Today });
                    }

                    if (CommonFunction.IfHasData(dtGoods))
                    {
                        btnItemDel.Enabled = true;
                        btnDelMain.Enabled = true;
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox(pack.Message);
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("请填写完整信息！");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否清空页面所有数据？此前内容将会全部被清除。"))
            {
                ClearControls();
            }
        }

        private void btnDelMain_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否删除库位为 " + textBoxBinDel.Text.Trim() + " 的保养计划？"))
            {
                DataRow[] rowArray = dtGoods.Select(" BIN='" + textBoxBinDel.Text.Trim() + "'");

                foreach (DataRow row in rowArray)
                {
                    row.Delete();
                }

                dtGoods.AcceptChanges();
                CommonFunction.Sys_MsgBox("货位 " + textBoxBinDel.Text.Trim() + " 的保养计划被删除");

                if (!CommonFunction.IfHasData(dtGoods))
                {
                    btnItemDel.Enabled = false;
                    btnDelMain.Enabled = false;
                }
            }
        }

        private void btnItemDel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否删除被选中条目？"))
            {
                DataRow[] rowArray = dtGoods.Select(" BARCODE='" + dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnBARCODE"].Value.ToString() + "' and BIN='" + dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnBIN"].Value.ToString() + "'");

                if (rowArray.Length == 1)
                {
                    rowArray[0].Delete();
                    dtGoods.AcceptChanges();
                }

                if (!CommonFunction.IfHasData(dtGoods))
                {
                    btnItemDel.Enabled = false;
                    btnDelMain.Enabled = false;
                }
            }
        }

        private void btnMaintainPlan_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("确认生成此保养单么？"))
            {
                ArrayList billInfo = new ArrayList();

                for (int i = 0; i < dtMaintain.Columns.Count; i++)
                {
                    billInfo.Add(dtMaintain.Rows[0][i]);
                }

                string str = DBOperate.MaintainNewPlan(userItem.userID, ConstDefine.MODULEKEY_MAINTAIN, billInfo, dtGoods);

                if (!str.Equals("-1"))
                {
                    CommonFunction.Sys_MsgBox("库存保养单 " + str + " 添加成功");
                    ClearControls();
                }
                else
                {
                    CommonFunction.Sys_MsgBox("库存保养单添加失败，请联系管理员确认");
                }
            }
        }

        private void btnModPlanNum_Click(object sender, EventArgs e)
        {
            decimal num = 0M;

            try
            {
                num = Convert.ToDecimal(textBoxPlanNum.Text.Trim());
            }
            catch
            {
                CommonFunction.Sys_MsgBox("数字格式不正确");
                return;
            }

            if (num <= 0M)
            {
                CommonFunction.Sys_MsgBox("保养数量不可小于等于0，如不需保养此货物请删除条目");
                dataGridViewSapStockInfo_SelectionChanged(null, null);
            }
            else if (num > Convert.ToDecimal(dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnPLAN_NUM"].Value))
            {
                CommonFunction.Sys_MsgBox("保养数量不可大于库存数量");
                dataGridViewSapStockInfo_SelectionChanged(null, null);
            }
            else
            {
                dtGoods.Select(" BARCODE='" + dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnBARCODE"].Value.ToString() + "' and BIN='" + dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnBin"].Value.ToString() + "'")[0]["PLAN_NUM"] = num;
            }
        }

        private void ClearControls()
        {
            comboBoxPlant.SelectedIndex = 0;
            textBoxBin.Text = string.Empty;
            dtGoods.Rows.Clear();
            dtMaintain.Rows.Clear();
        }

        private void comboBoxPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSLocation.Items.Clear();
            comboBoxSLocation.Items.Add("无");

            foreach (DataRow row in dtStoreLocusList.Select("PlantID='" + comboBoxPlant.Text + "'"))
            {
                comboBoxSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            comboBoxSLocation.SelectedIndex = 0;
        }

        private void dataGridViewMaintain_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewMaintain.Rows != null) && (dataGridViewMaintain.SelectedRows.Count != 0))
            {
                comboBoxPlant.Enabled = false;
                comboBoxSLocation.Enabled = false;
                textBoxSTOREMAN.ReadOnly = true;
            }
            else
            {
                comboBoxPlant.Enabled = true;
                comboBoxSLocation.Enabled = true;
                textBoxSTOREMAN.ReadOnly = false;
            }
        }

        private void dataGridViewSapStockInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewSapStockInfo.Rows != null) && (dataGridViewSapStockInfo.SelectedRows.Count != 0))
            {
                btnMaintainPlan.Enabled = true;
                btnDelMain.Enabled = true;
                btnItemDel.Enabled = true;
                btnModPlanNum.Enabled = true;
                textBoxPlanNum.Text = dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnPLAN_NUM"].Value.ToString();
            }
            else
            {
                btnMaintainPlan.Enabled = false;
                btnDelMain.Enabled = false;
                btnItemDel.Enabled = false;
                btnModPlanNum.Enabled = false;
                textBoxBinDel.Text = string.Empty;
                textBoxPlanNum.Text = string.Empty;
            }
        }

        private void EnterDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private bool FilterTheUsefulInfo(DataTable goodsInfo, DataTable usefulInfo, string bin)
        {
            if (CommonFunction.IfHasData(goodsInfo))
            {
                foreach (DataRow row in goodsInfo.Rows)
                {
                    ArrayList list = new ArrayList();
                    list.Add(row["Bct50"]);
                    list.Add(row["Bct51"]);
                    list.Add(row["Bct60"]);
                    list.Add(row["Bct61"]);
                    list.Add(row["Bct70"]);
                    list.Add(row["Bct71"]);

                    if (list[0].ToString().Contains(bin) && (usefulInfo.Select("BARCODE='" + row["Werks"].ToString() + row["Charg"].ToString() + row["Matnr"].ToString() + "' and BIN='" + list[0].ToString() + "'").Length == 0))
                    {
                        usefulInfo.Rows.Add(new object[] { row["Werks"].ToString() + row["Charg"].ToString() + row["Matnr"].ToString(), row["Werks"], row["Matnr"], row["Charg"], row["Maktx"], row["Meins"], list[0].ToString(), 0, 0, 0, row["Bct20"], row["Ntgew"] });
                        usefulInfo.Rows[usefulInfo.Rows.Count - 1]["PLAN_NUM"] = usefulInfo.Rows[usefulInfo.Rows.Count - 1]["BIN_NUM"] = list[1];
                    }

                    if (list[2].ToString().Contains(bin) && (usefulInfo.Select("BARCODE='" + row["Werks"].ToString() + row["Charg"].ToString() + row["Matnr"].ToString() + "' and BIN='" + list[2].ToString() + "'").Length == 0))
                    {
                        usefulInfo.Rows.Add(new object[] { row["Werks"].ToString() + row["Charg"].ToString() + row["Matnr"].ToString(), row["Werks"], row["Matnr"], row["Charg"], row["Maktx"], row["Meins"], list[2].ToString(), 0, 0, 0, row["Bct20"], row["Ntgew"] });
                        usefulInfo.Rows[usefulInfo.Rows.Count - 1]["PLAN_NUM"] = usefulInfo.Rows[usefulInfo.Rows.Count - 1]["BIN_NUM"] = list[3];
                    }

                    if (list[4].ToString().Contains(bin) && (usefulInfo.Select("BARCODE='" + row["Werks"].ToString() + row["Charg"].ToString() + row["Matnr"].ToString() + "' and BIN='" + list[4].ToString() + "'").Length == 0))
                    {
                        usefulInfo.Rows.Add(new object[] { row["Werks"].ToString() + row["Charg"].ToString() + row["Matnr"].ToString(), row["Werks"], row["Matnr"], row["Charg"], row["Maktx"], row["Meins"], list[4].ToString(), 0, 0, 0, row["Bct20"], row["Ntgew"] });
                        usefulInfo.Rows[usefulInfo.Rows.Count - 1]["PLAN_NUM"] = usefulInfo.Rows[usefulInfo.Rows.Count - 1]["BIN_NUM"] = list[5];
                    }

                    dataGridViewSapStockInfo_SelectionChanged(null, null);
                }
                return true;
            }
            return false;
        }

        private void InitFctAndStore()
        {
            dtPlantList = DBOperate.GetPlantList(string.Empty);
            dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, string.Empty);
            comboBoxSLocation.Items.Add("无");
            comboBoxSLocation.SelectedIndex = 0;
            comboBoxPlant.Items.Add("无");

            if (CommonFunction.IfHasData(dtPlantList))
            {
                foreach (DataRow row in dtPlantList.Rows)
                {
                    comboBoxPlant.Items.Add(row["PlantID"].ToString());
                }
            }

            comboBoxPlant.SelectedIndex = 0;
        }

        private void InitTableColumns()
        {
            dtMaintain = new DataTable();
            dtMaintain.Columns.Add("FACTORY_NO");
            dtMaintain.Columns.Add("SL");
            dtMaintain.Columns.Add("STOREMAN");
            dtMaintain.Columns.Add("OPERATOR");
            dtMaintain.Columns.Add("OPERATE_TIME");
            dataGridViewMaintain.DataSource = dtMaintain;
            dtGoods = new DataTable();
            dtGoods.Columns.Add("BARCODE");
            dtGoods.Columns.Add("FACT_NO");
            dtGoods.Columns.Add("PRODUCT_NO");
            dtGoods.Columns.Add("PATCH_NO");
            dtGoods.Columns.Add("PRODUCT_NAME");
            dtGoods.Columns.Add("UNIT");
            dtGoods.Columns.Add("BIN");
            dtGoods.Columns.Add("BIN_NUM");
            dtGoods.Columns.Add("PLAN_NUM");
            dtGoods.Columns.Add("MAINTAINNUM");
            dtGoods.Columns.Add("SUPPLIER_NO");
            dtGoods.Columns.Add("WEIGHT");
            dataGridViewSapStockInfo.DataSource = dtGoods;
        }

        private void textBoxSTOREMAN_Leave(object sender, EventArgs e)
        {
            if (!textBoxSTOREMAN.Text.Equals(string.Empty) && !CommonFunction.IfHasData(DBOperate.GetUserIDName(textBoxSTOREMAN.Text)))
            {
                CommonFunction.Sys_MsgBox("找不到相应人员，请确认输入");
                textBoxSTOREMAN.Focus();
            }
        }

        private void 制定保养单_Load(object sender, EventArgs e)
        {

        }
    }
}
