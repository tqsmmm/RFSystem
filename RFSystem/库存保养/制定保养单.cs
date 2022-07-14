using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RFSystem
{
    public class 制定保养单 : Form
    {
        // Fields
        private Button btnAddItem;
        private Button btnClear;
        private Button btnDelMain;
        private Button btnExit;
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
        private IContainer components;
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
        private Label label2;
        private Label label23;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label labelMaintainID;
        private TextBox textBoxBin;
        private TextBox textBoxBinDel;
        private TextBox textBoxPlanNum;
        private TextBox textBoxSTOREMAN;
        private UserInfo userItem;
        private ArrayList userRoles;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxInputInfo = new System.Windows.Forms.GroupBox();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxSTOREMAN = new System.Windows.Forms.TextBox();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMaintainID = new System.Windows.Forms.Label();
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
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
            this.groupBoxInputInfo.Controls.Add(this.textBoxBin);
            this.groupBoxInputInfo.Controls.Add(this.label23);
            this.groupBoxInputInfo.Controls.Add(this.textBoxSTOREMAN);
            this.groupBoxInputInfo.Controls.Add(this.comboBoxSLocation);
            this.groupBoxInputInfo.Controls.Add(this.label5);
            this.groupBoxInputInfo.Controls.Add(this.label4);
            this.groupBoxInputInfo.Controls.Add(this.comboBoxPlant);
            this.groupBoxInputInfo.Controls.Add(this.btnAddItem);
            this.groupBoxInputInfo.Controls.Add(this.label3);
            this.groupBoxInputInfo.Controls.Add(this.label2);
            this.groupBoxInputInfo.Controls.Add(this.labelMaintainID);
            this.groupBoxInputInfo.Controls.Add(this.label1);
            this.groupBoxInputInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInputInfo.Name = "groupBoxInputInfo";
            this.groupBoxInputInfo.Size = new System.Drawing.Size(722, 78);
            this.groupBoxInputInfo.TabIndex = 0;
            this.groupBoxInputInfo.TabStop = false;
            this.groupBoxInputInfo.Text = "保养单信息添加";
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(75, 43);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(91, 21);
            this.textBoxBin.TabIndex = 60;
            this.textBoxBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(187, 47);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "保管员码：";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSTOREMAN
            // 
            this.textBoxSTOREMAN.Location = new System.Drawing.Point(258, 43);
            this.textBoxSTOREMAN.Name = "textBoxSTOREMAN";
            this.textBoxSTOREMAN.ReadOnly = true;
            this.textBoxSTOREMAN.Size = new System.Drawing.Size(87, 21);
            this.textBoxSTOREMAN.TabIndex = 50;
            this.textBoxSTOREMAN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            this.textBoxSTOREMAN.Leave += new System.EventHandler(this.textBoxSTOREMAN_Leave);
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(586, 21);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(120, 20);
            this.comboBoxSLocation.TabIndex = 40;
            this.comboBoxSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "逻辑库区：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "公 司 号：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(389, 20);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(120, 20);
            this.comboBoxPlant.TabIndex = 30;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            this.comboBoxPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(631, 47);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 70;
            this.btnAddItem.Text = "添加信息";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "货 位 号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "(以最终生成单据为准)";
            // 
            // labelMaintainID
            // 
            this.labelMaintainID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMaintainID.ForeColor = System.Drawing.Color.Red;
            this.labelMaintainID.Location = new System.Drawing.Point(75, 20);
            this.labelMaintainID.Name = "labelMaintainID";
            this.labelMaintainID.Size = new System.Drawing.Size(106, 20);
            this.labelMaintainID.TabIndex = 10;
            this.labelMaintainID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "保养单号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewMaintain);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 193);
            this.groupBox2.TabIndex = 200;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保养单基本信息";
            // 
            // dataGridViewMaintain
            // 
            this.dataGridViewMaintain.AllowUserToAddRows = false;
            this.dataGridViewMaintain.AllowUserToResizeRows = false;
            this.dataGridViewMaintain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMaintain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMaintain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFACTORY_NO,
            this.ColumnSL,
            this.ColumnSTOREMAN,
            this.ColumnOPERATOR,
            this.ColumnOPERATE_TIME});
            this.dataGridViewMaintain.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewMaintain.MultiSelect = false;
            this.dataGridViewMaintain.Name = "dataGridViewMaintain";
            this.dataGridViewMaintain.ReadOnly = true;
            this.dataGridViewMaintain.RowHeadersVisible = false;
            this.dataGridViewMaintain.RowTemplate.Height = 23;
            this.dataGridViewMaintain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintain.Size = new System.Drawing.Size(627, 167);
            this.dataGridViewMaintain.TabIndex = 20000;
            this.dataGridViewMaintain.SelectionChanged += new System.EventHandler(this.dataGridViewMaintain_SelectionChanged);
            // 
            // ColumnFACTORY_NO
            // 
            this.ColumnFACTORY_NO.DataPropertyName = "FACTORY_NO";
            this.ColumnFACTORY_NO.HeaderText = "库存账套";
            this.ColumnFACTORY_NO.Name = "ColumnFACTORY_NO";
            this.ColumnFACTORY_NO.ReadOnly = true;
            // 
            // ColumnSL
            // 
            this.ColumnSL.DataPropertyName = "SL";
            this.ColumnSL.HeaderText = "逻辑库区";
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
            this.btnDelMain.Enabled = false;
            this.btnDelMain.Location = new System.Drawing.Point(214, 583);
            this.btnDelMain.Name = "btnDelMain";
            this.btnDelMain.Size = new System.Drawing.Size(75, 23);
            this.btnDelMain.TabIndex = 90;
            this.btnDelMain.Text = "删除";
            this.btnDelMain.UseVisualStyleBackColor = true;
            this.btnDelMain.Click += new System.EventHandler(this.btnDelMain_Click);
            // 
            // dataGridViewSapStockInfo
            // 
            this.dataGridViewSapStockInfo.AllowUserToAddRows = false;
            this.dataGridViewSapStockInfo.AllowUserToResizeRows = false;
            this.dataGridViewSapStockInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSapStockInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            this.dataGridViewSapStockInfo.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewSapStockInfo.MultiSelect = false;
            this.dataGridViewSapStockInfo.Name = "dataGridViewSapStockInfo";
            this.dataGridViewSapStockInfo.ReadOnly = true;
            this.dataGridViewSapStockInfo.RowHeadersVisible = false;
            this.dataGridViewSapStockInfo.RowTemplate.Height = 23;
            this.dataGridViewSapStockInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSapStockInfo.Size = new System.Drawing.Size(708, 256);
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
            this.ColumnBARCODE.Width = 90;
            // 
            // ColumnFACT_NO
            // 
            this.ColumnFACT_NO.DataPropertyName = "FACT_NO";
            this.ColumnFACT_NO.HeaderText = "库存账套编号";
            this.ColumnFACT_NO.Name = "ColumnFACT_NO";
            this.ColumnFACT_NO.ReadOnly = true;
            this.ColumnFACT_NO.Visible = false;
            this.ColumnFACT_NO.Width = 90;
            // 
            // ColumnPRODUCT_NO
            // 
            this.ColumnPRODUCT_NO.DataPropertyName = "PRODUCT_NO";
            this.ColumnPRODUCT_NO.HeaderText = "物料号";
            this.ColumnPRODUCT_NO.Name = "ColumnPRODUCT_NO";
            this.ColumnPRODUCT_NO.ReadOnly = true;
            this.ColumnPRODUCT_NO.Width = 66;
            // 
            // ColumnPATCH_NO
            // 
            this.ColumnPATCH_NO.DataPropertyName = "PATCH_NO";
            this.ColumnPATCH_NO.HeaderText = "批次号";
            this.ColumnPATCH_NO.Name = "ColumnPATCH_NO";
            this.ColumnPATCH_NO.ReadOnly = true;
            this.ColumnPATCH_NO.Width = 66;
            // 
            // ColumnPRODUCT_NAME
            // 
            this.ColumnPRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.ColumnPRODUCT_NAME.HeaderText = "物品名称";
            this.ColumnPRODUCT_NAME.Name = "ColumnPRODUCT_NAME";
            this.ColumnPRODUCT_NAME.ReadOnly = true;
            this.ColumnPRODUCT_NAME.Width = 78;
            // 
            // ColumnBIN_NUM
            // 
            this.ColumnBIN_NUM.DataPropertyName = "BIN_NUM";
            this.ColumnBIN_NUM.HeaderText = "数量";
            this.ColumnBIN_NUM.Name = "ColumnBIN_NUM";
            this.ColumnBIN_NUM.ReadOnly = true;
            this.ColumnBIN_NUM.Width = 54;
            // 
            // ColumnWeight
            // 
            this.ColumnWeight.DataPropertyName = "Weight";
            this.ColumnWeight.HeaderText = "单重";
            this.ColumnWeight.Name = "ColumnWeight";
            this.ColumnWeight.ReadOnly = true;
            this.ColumnWeight.Width = 54;
            // 
            // ColumnUNIT
            // 
            this.ColumnUNIT.DataPropertyName = "UNIT";
            this.ColumnUNIT.HeaderText = "单位";
            this.ColumnUNIT.Name = "ColumnUNIT";
            this.ColumnUNIT.ReadOnly = true;
            this.ColumnUNIT.Width = 54;
            // 
            // ColumnPLAN_NUM
            // 
            this.ColumnPLAN_NUM.DataPropertyName = "PLAN_NUM";
            this.ColumnPLAN_NUM.HeaderText = "计划数量";
            this.ColumnPLAN_NUM.Name = "ColumnPLAN_NUM";
            this.ColumnPLAN_NUM.ReadOnly = true;
            this.ColumnPLAN_NUM.Width = 78;
            // 
            // ColumnMAINTAINNUM
            // 
            this.ColumnMAINTAINNUM.DataPropertyName = "MAINTAINNUM";
            this.ColumnMAINTAINNUM.HeaderText = "保养数量";
            this.ColumnMAINTAINNUM.Name = "ColumnMAINTAINNUM";
            this.ColumnMAINTAINNUM.ReadOnly = true;
            this.ColumnMAINTAINNUM.Visible = false;
            // 
            // ColumnBIN
            // 
            this.ColumnBIN.DataPropertyName = "BIN";
            this.ColumnBIN.HeaderText = "储位";
            this.ColumnBIN.Name = "ColumnBIN";
            this.ColumnBIN.ReadOnly = true;
            this.ColumnBIN.Width = 54;
            // 
            // ColumnSUPPLIER_NO
            // 
            this.ColumnSUPPLIER_NO.DataPropertyName = "SUPPLIER_NO";
            this.ColumnSUPPLIER_NO.HeaderText = "生产厂代码";
            this.ColumnSUPPLIER_NO.Name = "ColumnSUPPLIER_NO";
            this.ColumnSUPPLIER_NO.ReadOnly = true;
            this.ColumnSUPPLIER_NO.Visible = false;
            // 
            // btnMaintainPlan
            // 
            this.btnMaintainPlan.Enabled = false;
            this.btnMaintainPlan.Location = new System.Drawing.Point(657, 191);
            this.btnMaintainPlan.Name = "btnMaintainPlan";
            this.btnMaintainPlan.Size = new System.Drawing.Size(75, 23);
            this.btnMaintainPlan.TabIndex = 500;
            this.btnMaintainPlan.Text = "生成保养单";
            this.btnMaintainPlan.UseVisualStyleBackColor = true;
            this.btnMaintainPlan.Click += new System.EventHandler(this.btnMaintainPlan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewSapStockInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 282);
            this.groupBox1.TabIndex = 300;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保养货物信息";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(657, 266);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 520;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(659, 116);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 510;
            this.btnClear.Text = "清空信息";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 588);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "需删除的储位号：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxBinDel
            // 
            this.textBoxBinDel.Location = new System.Drawing.Point(117, 585);
            this.textBoxBinDel.Name = "textBoxBinDel";
            this.textBoxBinDel.Size = new System.Drawing.Size(91, 21);
            this.textBoxBinDel.TabIndex = 80;
            // 
            // btnItemDel
            // 
            this.btnItemDel.Enabled = false;
            this.btnItemDel.Location = new System.Drawing.Point(295, 583);
            this.btnItemDel.Name = "btnItemDel";
            this.btnItemDel.Size = new System.Drawing.Size(75, 23);
            this.btnItemDel.TabIndex = 521;
            this.btnItemDel.Text = "条目删除";
            this.btnItemDel.UseVisualStyleBackColor = true;
            this.btnItemDel.Click += new System.EventHandler(this.btnItemDel_Click);
            // 
            // textBoxPlanNum
            // 
            this.textBoxPlanNum.Location = new System.Drawing.Point(562, 585);
            this.textBoxPlanNum.Name = "textBoxPlanNum";
            this.textBoxPlanNum.Size = new System.Drawing.Size(91, 21);
            this.textBoxPlanNum.TabIndex = 523;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(467, 588);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 522;
            this.label7.Text = "保养计划数量：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnModPlanNum
            // 
            this.btnModPlanNum.Enabled = false;
            this.btnModPlanNum.Location = new System.Drawing.Point(659, 583);
            this.btnModPlanNum.Name = "btnModPlanNum";
            this.btnModPlanNum.Size = new System.Drawing.Size(75, 23);
            this.btnModPlanNum.TabIndex = 524;
            this.btnModPlanNum.Text = "修改";
            this.btnModPlanNum.UseVisualStyleBackColor = true;
            this.btnModPlanNum.Click += new System.EventHandler(this.btnModPlanNum_Click);
            // 
            // 制定保养单
            // 
            this.ClientSize = new System.Drawing.Size(744, 618);
            this.Controls.Add(this.textBoxPlanNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnModPlanNum);
            this.Controls.Add(this.btnItemDel);
            this.Controls.Add(this.textBoxBinDel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDelMain);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMaintainPlan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxInputInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "制定保养单";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "制定保养单";
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
        public 制定保养单()
        {
            InitializeComponent();
            labelMaintainID.Text = DateTime.Now.ToString("yyMMdd") + "****";
            InitFctAndStore();
            InitTableColumns();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (((!comboBoxPlant.Text.Trim().Equals("无") && !comboBoxSLocation.Text.Trim().Equals("无")) && !textBoxBin.Text.Trim().Equals(string.Empty)) && !textBoxSTOREMAN.Text.Trim().Equals(string.Empty))
            {
                //DataSet cxDs = new DataSet("储位查询");
                //MessagePack pack = new MessagePack();

                //try
                //{
                //    pack = Utility.getSerive().GetHWCXInfo(textBoxSTOREMAN.Text, textBoxBin.Text, comboBoxSLocation.Text, comboBoxPlant.Text, out cxDs);
                //}
                //catch
                //{
                //    MessageBox.Show(pack.Message);
                //}

                //if (pack.Code == 0)
                //{
                //    if (FilterTheUsefulInfo(cxDs.Tables[0], dtGoods, textBoxBin.Text) && !CommonFunction.IfHasData(dtMaintain))
                //    {
                //        dtMaintain.Rows.Add(new object[] { comboBoxPlant.Text, comboBoxSLocation.Text, textBoxSTOREMAN.Text, userItem.userID, DateTime.Today });
                //    }
                //    if (CommonFunction.IfHasData(dtGoods))
                //    {
                //        btnItemDel.Enabled = true;
                //        btnDelMain.Enabled = true;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show(pack.Message);
                //}
            }
            else
            {
                MessageBox.Show("请填写完整信息！");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否清空页面所有数据？此前内容将会全部被清除。"))
            {
                this.ClearControls();
            }
        }

        private void btnDelMain_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否删除库位为 " + textBoxBinDel.Text.Trim() + " 的保养计划？"))
            {
                DataRow[] rowArray = this.dtGoods.Select(" BIN='" + textBoxBinDel.Text.Trim() + "'");
                foreach (DataRow row in rowArray)
                {
                    row.Delete();
                }
                this.dtGoods.AcceptChanges();
                MessageBox.Show("储位 " + textBoxBinDel.Text.Trim() + " 的保养计划被删除");
                if (!CommonFunction.IfHasData(this.dtGoods))
                {
                    this.btnItemDel.Enabled = false;
                    this.btnDelMain.Enabled = false;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnItemDel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否删除被选中条目？"))
            {
                DataRow[] rowArray = this.dtGoods.Select(" BARCODE='" + this.dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnBARCODE"].Value.ToString() + "' and BIN='" + this.dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnBIN"].Value.ToString() + "'");
                if (rowArray.Length == 1)
                {
                    rowArray[0].Delete();
                    this.dtGoods.AcceptChanges();
                }
                if (!CommonFunction.IfHasData(this.dtGoods))
                {
                    this.btnItemDel.Enabled = false;
                    this.btnDelMain.Enabled = false;
                }
            }
        }

        private void btnMaintainPlan_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("确认生成此保养单么？"))
            {
                ArrayList billInfo = new ArrayList();
                for (int i = 0; i < this.dtMaintain.Columns.Count; i++)
                {
                    billInfo.Add(this.dtMaintain.Rows[0][i]);
                }
                string str = DBOperate.MaintainNewPlan(this.userItem.userID, ConstDefine.MODULEKEY_MAINTAIN, billInfo, this.dtGoods);
                if (!str.Equals("-1"))
                {
                    MessageBox.Show("库存保养单 " + str + " 添加成功");
                    this.ClearControls();
                }
                else
                {
                    MessageBox.Show("库存保养单添加失败，请联系管理员确认");
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
                MessageBox.Show("数字格式不正确");
                return;
            }
            if (num <= 0M)
            {
                MessageBox.Show("保养数量不可小于等于0，如不需保养此货物请删除条目");
                this.dataGridViewSapStockInfo_SelectionChanged(null, null);
            }
            else if (num > Convert.ToDecimal(this.dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnPLAN_NUM"].Value))
            {
                MessageBox.Show("保养数量不可大于库存数量");
                this.dataGridViewSapStockInfo_SelectionChanged(null, null);
            }
            else
            {
                this.dtGoods.Select(" BARCODE='" + this.dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnBARCODE"].Value.ToString() + "' and BIN='" + this.dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnBin"].Value.ToString() + "'")[0]["PLAN_NUM"] = num;
            }
        }

        private void ClearControls()
        {
            this.comboBoxPlant.SelectedIndex = 0;
            this.textBoxBin.Text = string.Empty;
            this.dtGoods.Rows.Clear();
            this.dtMaintain.Rows.Clear();
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

        private void dataGridViewMaintain_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewMaintain.Rows != null) && (this.dataGridViewMaintain.SelectedRows.Count != 0))
            {
                this.comboBoxPlant.Enabled = false;
                this.comboBoxSLocation.Enabled = false;
                this.textBoxSTOREMAN.ReadOnly = true;
            }
            else
            {
                this.comboBoxPlant.Enabled = true;
                this.comboBoxSLocation.Enabled = true;
                this.textBoxSTOREMAN.ReadOnly = false;
            }
        }

        private void dataGridViewSapStockInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewSapStockInfo.Rows != null) && (this.dataGridViewSapStockInfo.SelectedRows.Count != 0))
            {
                this.btnMaintainPlan.Enabled = true;
                this.btnDelMain.Enabled = true;
                this.btnItemDel.Enabled = true;
                this.btnModPlanNum.Enabled = true;
                this.textBoxPlanNum.Text = this.dataGridViewSapStockInfo.SelectedRows[0].Cells["ColumnPLAN_NUM"].Value.ToString();
            }
            else
            {
                this.btnMaintainPlan.Enabled = false;
                this.btnDelMain.Enabled = false;
                this.btnItemDel.Enabled = false;
                this.btnModPlanNum.Enabled = false;
                this.textBoxBinDel.Text = string.Empty;
                this.textBoxPlanNum.Text = string.Empty;
            }
        }

        private void EnterDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.SelectNextControl(base.ActiveControl, true, true, true, true);
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
                    this.dataGridViewSapStockInfo_SelectionChanged(null, null);
                }
                return true;
            }
            return false;
        }

        private void InitFctAndStore()
        {
            this.dtPlantList = DBOperate.GetPlantList(string.Empty, true);
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
        }

        private void InitTableColumns()
        {
            this.dtMaintain = new DataTable();
            this.dtMaintain.Columns.Add("FACTORY_NO");
            this.dtMaintain.Columns.Add("SL");
            this.dtMaintain.Columns.Add("STOREMAN");
            this.dtMaintain.Columns.Add("OPERATOR");
            this.dtMaintain.Columns.Add("OPERATE_TIME");
            this.dataGridViewMaintain.DataSource = this.dtMaintain;
            this.dtGoods = new DataTable();
            this.dtGoods.Columns.Add("BARCODE");
            this.dtGoods.Columns.Add("FACT_NO");
            this.dtGoods.Columns.Add("PRODUCT_NO");
            this.dtGoods.Columns.Add("PATCH_NO");
            this.dtGoods.Columns.Add("PRODUCT_NAME");
            this.dtGoods.Columns.Add("UNIT");
            this.dtGoods.Columns.Add("BIN");
            this.dtGoods.Columns.Add("BIN_NUM");
            this.dtGoods.Columns.Add("PLAN_NUM");
            this.dtGoods.Columns.Add("MAINTAINNUM");
            this.dtGoods.Columns.Add("SUPPLIER_NO");
            this.dtGoods.Columns.Add("WEIGHT");
            this.dataGridViewSapStockInfo.DataSource = this.dtGoods;
        }

        private void textBoxSTOREMAN_Leave(object sender, EventArgs e)
        {
            if (!this.textBoxSTOREMAN.Text.Equals(string.Empty) && !CommonFunction.IfHasData(DBOperate.GetUserIDName(this.textBoxSTOREMAN.Text)))
            {
                MessageBox.Show("找不到相应人员，请确认输入", "数据不存在", MessageBoxButtons.OK);
                this.textBoxSTOREMAN.Focus();
            }
        }
    }
}
