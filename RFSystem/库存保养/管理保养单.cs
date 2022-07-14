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
    public class 管理保养单 : Form
    {
        // Fields
        private Button btnCancel;
        private Button btnDel;
        private Button btnEnd;
        private Button btnModNum;
        private Button btnPrint;
        private Button btnReMaintain;
        private Button btnSelect;
        private Button btnStart;
        private Button btnSubmitMod;
        private DataGridViewTextBoxColumn ColumnBARCODE;
        private DataGridViewTextBoxColumn ColumnBIN;
        private DataGridViewTextBoxColumn ColumnBIN_NUM;
        private DataGridViewTextBoxColumn ColumnDetailMAINTAIN_NO;
        private DataGridViewTextBoxColumn ColumnFACT_NO;
        private DataGridViewTextBoxColumn ColumnFACTORY_NO;
        private DataGridViewTextBoxColumn ColumnMAINTAIN_NO;
        private DataGridViewTextBoxColumn ColumnMAINTAINNUM;
        private DataGridViewTextBoxColumn ColumnOPERATE_TIME;
        private DataGridViewTextBoxColumn ColumnOPERATOR;
        private DataGridViewTextBoxColumn ColumnPATCH_NO;
        private DataGridViewTextBoxColumn ColumnPLAN_NUM;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NAME;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NO;
        private DataGridViewTextBoxColumn ColumnSL;
        private DataGridViewTextBoxColumn ColumnState;
        private DataGridViewTextBoxColumn ColumnSTOREMAN;
        private DataGridViewTextBoxColumn ColumnSUPPLIER_NO;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private DataGridViewTextBoxColumn ColumnWeight;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private ComboBox comboBoxState;
        private IContainer components;
        private DataGridView dataGridViewMaintain;
        private DataGridView dataGridViewMaintainDetail;
        private DataTable dtMaintainDetail;
        private DataTable dtMaintainHeader;
        private DataTable dtPlantList;
        private DataTable dtReport;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxMaintain;
        private TextBox textBoxMaintainNo;
        private TextBox textBoxOperator;
        private TextBox textBoxStoreMan;
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
            this.dataGridViewMaintain = new System.Windows.Forms.DataGridView();
            this.ColumnState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMAINTAIN_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFACTORY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTOREMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOPERATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOPERATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewMaintainDetail = new System.Windows.Forms.DataGridView();
            this.ColumnBARCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFACT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPATCH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBIN_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPLAN_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMAINTAINNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSUPPLIER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDetailMAINTAIN_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReMaintain = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxMaintainNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.textBoxOperator = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxMaintain = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnModNum = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmitMod = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintainDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMaintain
            // 
            this.dataGridViewMaintain.AllowUserToAddRows = false;
            this.dataGridViewMaintain.AllowUserToResizeRows = false;
            this.dataGridViewMaintain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMaintain.ColumnHeadersHeight = 30;
            this.dataGridViewMaintain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMaintain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnState,
            this.ColumnMAINTAIN_NO,
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
            this.dataGridViewMaintain.Size = new System.Drawing.Size(818, 193);
            this.dataGridViewMaintain.TabIndex = 20001;
            this.dataGridViewMaintain.SelectionChanged += new System.EventHandler(this.dataGridViewMaintain_SelectionChanged);
            // 
            // ColumnState
            // 
            this.ColumnState.DataPropertyName = "State";
            this.ColumnState.HeaderText = "状态";
            this.ColumnState.Name = "ColumnState";
            this.ColumnState.ReadOnly = true;
            this.ColumnState.Width = 62;
            // 
            // ColumnMAINTAIN_NO
            // 
            this.ColumnMAINTAIN_NO.DataPropertyName = "MAINTAIN_NO";
            this.ColumnMAINTAIN_NO.HeaderText = "保养单号";
            this.ColumnMAINTAIN_NO.Name = "ColumnMAINTAIN_NO";
            this.ColumnMAINTAIN_NO.ReadOnly = true;
            this.ColumnMAINTAIN_NO.Width = 90;
            // 
            // ColumnFACTORY_NO
            // 
            this.ColumnFACTORY_NO.DataPropertyName = "FACTORY_NO";
            this.ColumnFACTORY_NO.HeaderText = "库存账套";
            this.ColumnFACTORY_NO.Name = "ColumnFACTORY_NO";
            this.ColumnFACTORY_NO.ReadOnly = true;
            this.ColumnFACTORY_NO.Width = 90;
            // 
            // ColumnSL
            // 
            this.ColumnSL.DataPropertyName = "SL";
            this.ColumnSL.HeaderText = "逻辑库区";
            this.ColumnSL.Name = "ColumnSL";
            this.ColumnSL.ReadOnly = true;
            this.ColumnSL.Width = 90;
            // 
            // ColumnSTOREMAN
            // 
            this.ColumnSTOREMAN.DataPropertyName = "STOREMAN";
            this.ColumnSTOREMAN.HeaderText = "保管员";
            this.ColumnSTOREMAN.Name = "ColumnSTOREMAN";
            this.ColumnSTOREMAN.ReadOnly = true;
            this.ColumnSTOREMAN.Width = 76;
            // 
            // ColumnOPERATOR
            // 
            this.ColumnOPERATOR.DataPropertyName = "OPERATOR";
            this.ColumnOPERATOR.HeaderText = "制单人";
            this.ColumnOPERATOR.Name = "ColumnOPERATOR";
            this.ColumnOPERATOR.ReadOnly = true;
            this.ColumnOPERATOR.Width = 76;
            // 
            // ColumnOPERATE_TIME
            // 
            this.ColumnOPERATE_TIME.DataPropertyName = "OPERATE_TIME";
            this.ColumnOPERATE_TIME.HeaderText = "制单日期";
            this.ColumnOPERATE_TIME.Name = "ColumnOPERATE_TIME";
            this.ColumnOPERATE_TIME.ReadOnly = true;
            this.ColumnOPERATE_TIME.Width = 90;
            // 
            // dataGridViewMaintainDetail
            // 
            this.dataGridViewMaintainDetail.AllowUserToAddRows = false;
            this.dataGridViewMaintainDetail.AllowUserToResizeRows = false;
            this.dataGridViewMaintainDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMaintainDetail.ColumnHeadersHeight = 30;
            this.dataGridViewMaintainDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMaintainDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBARCODE,
            this.ColumnFACT_NO,
            this.ColumnPRODUCT_NO,
            this.ColumnPATCH_NO,
            this.ColumnPRODUCT_NAME,
            this.ColumnBIN,
            this.ColumnBIN_NUM,
            this.ColumnPLAN_NUM,
            this.ColumnMAINTAINNUM,
            this.ColumnWeight,
            this.ColumnUNIT,
            this.ColumnSUPPLIER_NO,
            this.ColumnDetailMAINTAIN_NO});
            this.dataGridViewMaintainDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMaintainDetail.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewMaintainDetail.MultiSelect = false;
            this.dataGridViewMaintainDetail.Name = "dataGridViewMaintainDetail";
            this.dataGridViewMaintainDetail.ReadOnly = true;
            this.dataGridViewMaintainDetail.RowHeadersVisible = false;
            this.dataGridViewMaintainDetail.RowTemplate.Height = 23;
            this.dataGridViewMaintainDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintainDetail.Size = new System.Drawing.Size(944, 87);
            this.dataGridViewMaintainDetail.TabIndex = 30001;
            this.dataGridViewMaintainDetail.SelectionChanged += new System.EventHandler(this.dataGridViewMaintainDetail_SelectionChanged);
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
            this.ColumnFACT_NO.HeaderText = "库存账套编号";
            this.ColumnFACT_NO.Name = "ColumnFACT_NO";
            this.ColumnFACT_NO.ReadOnly = true;
            this.ColumnFACT_NO.Visible = false;
            this.ColumnFACT_NO.Width = 72;
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
            // ColumnBIN
            // 
            this.ColumnBIN.DataPropertyName = "BIN";
            this.ColumnBIN.HeaderText = "储位";
            this.ColumnBIN.Name = "ColumnBIN";
            this.ColumnBIN.ReadOnly = true;
            this.ColumnBIN.Width = 62;
            // 
            // ColumnBIN_NUM
            // 
            this.ColumnBIN_NUM.DataPropertyName = "BIN_NUM";
            this.ColumnBIN_NUM.HeaderText = "库存数量";
            this.ColumnBIN_NUM.Name = "ColumnBIN_NUM";
            this.ColumnBIN_NUM.ReadOnly = true;
            this.ColumnBIN_NUM.Visible = false;
            this.ColumnBIN_NUM.Width = 61;
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
            this.ColumnMAINTAINNUM.Width = 90;
            // 
            // ColumnWeight
            // 
            this.ColumnWeight.DataPropertyName = "WEIGHT";
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
            // ColumnSUPPLIER_NO
            // 
            this.ColumnSUPPLIER_NO.DataPropertyName = "SUPPLIER_NO";
            this.ColumnSUPPLIER_NO.HeaderText = "生产厂代码";
            this.ColumnSUPPLIER_NO.Name = "ColumnSUPPLIER_NO";
            this.ColumnSUPPLIER_NO.ReadOnly = true;
            this.ColumnSUPPLIER_NO.Visible = false;
            this.ColumnSUPPLIER_NO.Width = 72;
            // 
            // ColumnDetailMAINTAIN_NO
            // 
            this.ColumnDetailMAINTAIN_NO.DataPropertyName = "MAINTAIN_NO";
            this.ColumnDetailMAINTAIN_NO.HeaderText = "保养单号";
            this.ColumnDetailMAINTAIN_NO.Name = "ColumnDetailMAINTAIN_NO";
            this.ColumnDetailMAINTAIN_NO.ReadOnly = true;
            this.ColumnDetailMAINTAIN_NO.Visible = false;
            this.ColumnDetailMAINTAIN_NO.Width = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewMaintain);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(824, 218);
            this.groupBox1.TabIndex = 30002;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保养单列表";
            // 
            // btnReMaintain
            // 
            this.btnReMaintain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReMaintain.Enabled = false;
            this.btnReMaintain.Location = new System.Drawing.Point(842, 230);
            this.btnReMaintain.Name = "btnReMaintain";
            this.btnReMaintain.Size = new System.Drawing.Size(120, 50);
            this.btnReMaintain.TabIndex = 20007;
            this.btnReMaintain.Text = "重新保养";
            this.btnReMaintain.UseVisualStyleBackColor = true;
            this.btnReMaintain.Click += new System.EventHandler(this.btnReMaintain_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(842, 286);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPrint.TabIndex = 20006;
            this.btnPrint.Text = "结束保养";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(842, 118);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 50);
            this.btnStart.TabIndex = 20002;
            this.btnStart.Text = "开始保养";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(842, 174);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(120, 50);
            this.btnDel.TabIndex = 20003;
            this.btnDel.Text = "作废保养";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(887, 156);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(0, 0);
            this.btnEnd.TabIndex = 20004;
            this.btnEnd.Text = "结束保养";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewMaintainDetail);
            this.groupBox2.Location = new System.Drawing.Point(12, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(950, 112);
            this.groupBox2.TabIndex = 30003;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保养单详细";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textBoxMaintainNo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBoxState);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboBoxPlant);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.comboBoxSLocation);
            this.groupBox3.Controls.Add(this.textBoxOperator);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxStoreMan);
            this.groupBox3.Controls.Add(this.btnSelect);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(950, 100);
            this.groupBox3.TabIndex = 30004;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "保养单列表";
            // 
            // textBoxMaintainNo
            // 
            this.textBoxMaintainNo.Location = new System.Drawing.Point(91, 25);
            this.textBoxMaintainNo.Name = "textBoxMaintainNo";
            this.textBoxMaintainNo.Size = new System.Drawing.Size(120, 26);
            this.textBoxMaintainNo.TabIndex = 20014;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 20013;
            this.label4.Text = "保养单号：";
            // 
            // comboBoxState
            // 
            this.comboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Items.AddRange(new object[] {
            "等待批准",
            "保养中",
            "保养完成",
            "结束保养",
            "作废单据",
            "全部"});
            this.comboBoxState.Location = new System.Drawing.Point(513, 60);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(120, 28);
            this.comboBoxState.TabIndex = 20012;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 20011;
            this.label3.Text = "单据状态：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(302, 25);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(120, 28);
            this.comboBoxPlant.TabIndex = 20009;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 20008;
            this.label7.Text = "库存账套：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(513, 25);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(120, 28);
            this.comboBoxSLocation.TabIndex = 20010;
            // 
            // textBoxOperator
            // 
            this.textBoxOperator.Location = new System.Drawing.Point(302, 62);
            this.textBoxOperator.Name = "textBoxOperator";
            this.textBoxOperator.Size = new System.Drawing.Size(120, 26);
            this.textBoxOperator.TabIndex = 20006;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 20007;
            this.label6.Text = "逻辑库区：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 20005;
            this.label2.Text = "制单人：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 20003;
            this.label1.Text = "保管员：";
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.Location = new System.Drawing.Point(91, 60);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.Size = new System.Drawing.Size(120, 26);
            this.textBoxStoreMan.TabIndex = 20004;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(824, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 50);
            this.btnSelect.TabIndex = 20002;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxMaintain
            // 
            this.textBoxMaintain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMaintain.Enabled = false;
            this.textBoxMaintain.Location = new System.Drawing.Point(133, 472);
            this.textBoxMaintain.Name = "textBoxMaintain";
            this.textBoxMaintain.Size = new System.Drawing.Size(80, 26);
            this.textBoxMaintain.TabIndex = 30006;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 30007;
            this.label8.Text = "修改已保养数量";
            // 
            // btnModNum
            // 
            this.btnModNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModNum.Enabled = false;
            this.btnModNum.Location = new System.Drawing.Point(219, 460);
            this.btnModNum.Name = "btnModNum";
            this.btnModNum.Size = new System.Drawing.Size(120, 50);
            this.btnModNum.TabIndex = 30008;
            this.btnModNum.Text = "修改";
            this.btnModNum.UseVisualStyleBackColor = true;
            this.btnModNum.Click += new System.EventHandler(this.btnModNum_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(345, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.TabIndex = 30009;
            this.btnCancel.Text = "取消修改";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmitMod
            // 
            this.btnSubmitMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitMod.Enabled = false;
            this.btnSubmitMod.Location = new System.Drawing.Point(471, 460);
            this.btnSubmitMod.Name = "btnSubmitMod";
            this.btnSubmitMod.Size = new System.Drawing.Size(120, 50);
            this.btnSubmitMod.TabIndex = 30010;
            this.btnSubmitMod.Text = "提交重新保养";
            this.btnSubmitMod.UseVisualStyleBackColor = true;
            this.btnSubmitMod.Click += new System.EventHandler(this.btnSubmitMod_Click);
            // 
            // 管理保养单
            // 
            this.ClientSize = new System.Drawing.Size(974, 522);
            this.Controls.Add(this.btnReMaintain);
            this.Controls.Add(this.btnSubmitMod);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModNum);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxMaintain);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "管理保养单";
            this.Text = "管理保养单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintainDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 管理保养单()
        {
            this.userItem = null;
            this.userRoles = null;
            this.dtPlantList = null;
            this.dtStoreLocusList = null;
            this.dtReport = null;
            this.components = null;
            this.InitializeComponent();
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
            this.dataGridViewMaintain.AutoGenerateColumns = false;
            this.dataGridViewMaintainDetail.AutoGenerateColumns = false;
            this.InitTableColumns();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否取消重新保养？继续此操作先前的修改将被取消，请确认"))
            {
                this.textBoxMaintain.Text = string.Empty;
                this.SetModControlsEnable(false);
                this.dataGridViewMaintain_SelectionChanged(null, null);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否作废本保养单？"))
            {
                if (DBOperate.MaintainModState(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "0", "-1") == 1)
                {
                    this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "作废单据";
                    MessageBox.Show("单据 " + this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 作废保养");
                }
                else
                {
                    MessageBox.Show("单据 " + this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 作废保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                }
                this.dataGridViewMaintain_SelectionChanged(null, null);
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否结束保养本保养单货物？"))
            {
                if (DBOperate.MaintainModState(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "1", "2") == 1)
                {
                    this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "保养完成";
                    MessageBox.Show("单据 " + this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 结束保养");
                }
                else
                {
                    MessageBox.Show("单据 " + this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 结束保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                }
                this.dataGridViewMaintain_SelectionChanged(null, null);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnModNum_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewMaintainDetail.SelectedRows[0].Index == (this.dataGridViewMaintainDetail.Rows.Count - 1))
            {
                this.textBoxMaintain.Text = "0";
                MessageBox.Show("合计行不可进行修改", "合计行修改错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                decimal num = 0M;
                try
                {
                    num = Convert.ToDecimal(this.textBoxMaintain.Text.Trim());
                    if ((num < 0M) || (num > Convert.ToDecimal(this.dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnPLAN_NUM"].Value)))
                    {
                        MessageBox.Show("重新保养数量必须大于0小于计划保养数量，请重新输入");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("输入不符合数字格式，请重新输入");
                    return;
                }
                this.dtMaintainDetail.Select(" BARCODE='" + this.dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnBARCODE"].Value.ToString() + "' and BIN='" + this.dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnBIN"].Value.ToString() + "'")[0]["MAINTAINNUM"] = num;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.btnPrint.Text.Equals("打印"))
            {
                //需要恢复的0608
                ////MaintainDataSet dataSet = new MaintainDataSet();
                ////ArrayList baseInfo = new ArrayList();
                ////baseInfo.Add(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString());
                ////baseInfo.Add(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnOPERATE_TIME"].Value.ToString());
                ////baseInfo.Add(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnSTOREMAN"].Value.ToString());
                ////baseInfo.Add(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnOPERATOR"].Value.ToString());
                ////foreach (DataRow row in this.dtMaintainDetail.Rows)
                ////{
                ////    dataSet.Tables[0].Rows.Add(new object[] { row["PRODUCT_NO"], row["PATCH_NO"], row["PRODUCT_NAME"], row["MAINTAINNUM"], row["WEIGHT"], row["BIN"] });
                ////}
                ////new RptViewer(dataSet, baseInfo).ShowDialog();
            }
            else if (CommonFunction.Sys_MsgYN("此步操作将结束本次保养，是否继续？"))
            {
                if (DBOperate.MaintainModState(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "2", "3") == 1)
                {
                    this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "结束保养";
                    MessageBox.Show("单据 " + this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 结束保养");
                }
                else
                {
                    MessageBox.Show("单据 " + this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 结束保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                }
                this.dataGridViewMaintain_SelectionChanged(null, null);
            }
        }

        private void btnReMaintain_Click(object sender, EventArgs e)
        {
            this.SetButtonsEnable(false, false, false, false);
            this.SetModControlsEnable(true);
            this.dataGridViewMaintainDetail_SelectionChanged(null, null);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.dataGridViewMaintainDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ArrayList arriveList = new ArrayList();
            arriveList.Add(this.textBoxMaintainNo.Text.Trim());
            arriveList.Add(this.comboBoxPlant.Text.Trim().Replace("无", string.Empty));
            arriveList.Add(this.comboBoxSLocation.Text.Trim().Replace("无", string.Empty));
            arriveList.Add(this.textBoxStoreMan.Text.Trim());
            arriveList.Add(this.textBoxOperator.Text.Trim());
            arriveList.Add((this.comboBoxState.SelectedIndex == -1) ? "" : this.comboBoxState.SelectedIndex.ToString());
            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);
            this.dtMaintainHeader = DBOperate.MaintainGetHead(arriveList);
            this.dataGridViewMaintain.DataSource = this.dtMaintainHeader;
            if (!CommonFunction.IfHasData(this.dtMaintainHeader))
            {
                this.dtMaintainDetail.Rows.Clear();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否开始保养本保养单货物？"))
            {
                if (DBOperate.MaintainModState(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "0", "1") == 1)
                {
                    this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "保养中";
                    MessageBox.Show("单据 " + this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 开始保养");
                }
                else
                {
                    MessageBox.Show("单据 " + this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 开始保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                }
                this.dataGridViewMaintain_SelectionChanged(null, null);
            }
        }

        private void btnSubmitMod_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否提交重新保养？"))
            {
                if (DBOperate.MaintainReMaintain(this.dtMaintainDetail))
                {
                    MessageBox.Show("单据" + this.dtMaintainDetail.Rows[0]["MAINTAIN_NO"].ToString() + "被退回重新保养");
                    this.textBoxMaintain.Text = string.Empty;
                    this.SetModControlsEnable(false);
                    this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "保养中";
                    this.dataGridViewMaintain_SelectionChanged(null, null);
                }
                else
                {
                    MessageBox.Show("退保养失败，请重新查看单据是否已经被改动");
                }
            }
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
            if ((this.dataGridViewMaintain.Rows == null) || (this.dataGridViewMaintain.SelectedRows.Count == 0))
            {
                this.SetButtonsEnable(false, false, false, false);
            }
            else
            {
                string str = this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value.ToString();
                if (str != null)
                {
                    if (!(str == "等待批准"))
                    {
                        if (str == "保养完成")
                        {
                            this.btnPrint.Text = "结束保养";
                            this.SetButtonsEnable(false, true, false, true);
                        }
                        else if ((str == "保养中") || (str == "作废单据"))
                        {
                            this.btnPrint.Text = "结束保养";
                            this.SetButtonsEnable(false, false, false, false);
                        }
                        else if (str == "结束保养")
                        {
                            this.btnPrint.Text = "打印";
                            this.SetButtonsEnable(false, true, false, false);
                        }
                    }
                    else
                    {
                        this.btnPrint.Text = "结束保养";
                        this.SetButtonsEnable(true, false, true, false);
                    }
                }
                this.dtMaintainDetail = DBOperate.MaintainGetDetail(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString());
            }
            this.dataGridViewMaintainDetail.DataSource = this.dtMaintainDetail;
            decimal num = 0M;
            decimal num2 = 0M;
            decimal num3 = 0M;
            if (CommonFunction.IfHasData(this.dtMaintainDetail))
            {
                foreach (DataRow row in this.dtMaintainDetail.Rows)
                {
                    num += (decimal)row["PLAN_NUM"];
                    num2 += (decimal)row["MAINTAINNUM"];
                    num3 += ((decimal)row["PLAN_NUM"]) * ((decimal)row["WEIGHT"]);
                }
                object[] values = new object[13];
                values[3] = "合计";
                values[9] = num;
                values[10] = num2;
                values[12] = num3;
                this.dtMaintainDetail.Rows.Add(values);
            }
        }

        private void dataGridViewMaintainDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (this.textBoxMaintain.Enabled && ((this.dataGridViewMaintainDetail.Rows != null) && (this.dataGridViewMaintainDetail.SelectedRows.Count != 0)))
            {
                if (this.dataGridViewMaintainDetail.SelectedRows[0].Index != (this.dataGridViewMaintainDetail.Rows.Count - 1))
                {
                    this.textBoxMaintain.Text = this.dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnMAINTAINNUM"].Value.ToString();
                }
                else
                {
                    this.textBoxMaintain.Text = "0";
                }
            }
        }

        private void InitTableColumns()
        {
            this.dtMaintainHeader = new DataTable();
            this.dtMaintainHeader.Columns.Add("MAINTAIN_NO");
            this.dtMaintainHeader.Columns.Add("FACTORY_NO");
            this.dtMaintainHeader.Columns.Add("SL");
            this.dtMaintainHeader.Columns.Add("STOREMAN");
            this.dtMaintainHeader.Columns.Add("OPERATOR");
            this.dtMaintainHeader.Columns.Add("OPERATE_TIME");
            this.dtMaintainHeader.Columns.Add("State");
            this.dataGridViewMaintain.DataSource = this.dtMaintainHeader;
            this.dtMaintainDetail = new DataTable();
            this.dtMaintainDetail.Columns.Add("MAINTAIN_NO");
            this.dtMaintainDetail.Columns.Add("BARCODE");
            this.dtMaintainDetail.Columns.Add("FACT_NO");
            this.dtMaintainDetail.Columns.Add("PRODUCT_NO");
            this.dtMaintainDetail.Columns.Add("PATCH_NO");
            this.dtMaintainDetail.Columns.Add("PRODUCT_NAME");
            this.dtMaintainDetail.Columns.Add("UNIT");
            this.dtMaintainDetail.Columns.Add("BIN");
            this.dtMaintainDetail.Columns.Add("BIN_NUM");
            this.dtMaintainDetail.Columns.Add("MAINTAINNUM");
            this.dtMaintainDetail.Columns.Add("SUPPLIER_NO");
            this.dataGridViewMaintainDetail.DataSource = this.dtMaintainDetail;
            this.dtReport = new DataTable();
            this.dtReport.Columns.Add("物料号");
            this.dtReport.Columns.Add("批次号");
            this.dtReport.Columns.Add("物料名称");
            this.dtReport.Columns.Add("保养数量");
            this.dtReport.Columns.Add("物品单重");
            this.dtReport.Columns.Add("储位");
        }

        private void SetButtonsEnable(bool startEnable, bool endEnable, bool delEnable, bool reMaintain)
        {
            this.btnStart.Enabled = startEnable;
            this.btnPrint.Enabled = endEnable;
            this.btnDel.Enabled = delEnable;
            this.btnReMaintain.Enabled = reMaintain;
        }

        private void SetModControlsEnable(bool controlsEnable)
        {
            this.btnSelect.Enabled = !controlsEnable;
            this.dataGridViewMaintain.Enabled = !controlsEnable;
            this.textBoxMaintain.Enabled = controlsEnable;
            this.btnModNum.Enabled = controlsEnable;
            this.btnCancel.Enabled = controlsEnable;
            this.btnSubmitMod.Enabled = controlsEnable;
        }
    }
}
