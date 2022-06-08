using System;
using System.Data;
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
        private Button btnReMaintain;
        private Button btnSelect;
        private Button btnStart;
        private Button btnSubmitMod;
        private CheckBox checkBoxTableMakeDate;
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
        private DataGridView dataGridViewMaintain;
        private DataGridView dataGridViewMaintainDetail;
        private DateTimePicker dateTimePickerTableMakeDateFrom;
        private DateTimePicker dateTimePickerTableMakeDateTo;
        private DataTable dtMaintainDetail;
        private DataTable dtMaintainHeader;
        private DataTable dtPlantList;
        private DataTable dtReport;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label10;
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxTableMakeDate = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTableMakeDateTo = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
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
            this.dateTimePickerTableMakeDateFrom = new System.Windows.Forms.DateTimePicker();
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
            this.dataGridViewMaintain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGridViewMaintain.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewMaintain.MultiSelect = false;
            this.dataGridViewMaintain.Name = "dataGridViewMaintain";
            this.dataGridViewMaintain.ReadOnly = true;
            this.dataGridViewMaintain.RowHeadersVisible = false;
            this.dataGridViewMaintain.RowTemplate.Height = 23;
            this.dataGridViewMaintain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintain.Size = new System.Drawing.Size(925, 194);
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
            this.ColumnFACTORY_NO.HeaderText = "公司";
            this.ColumnFACTORY_NO.Name = "ColumnFACTORY_NO";
            this.ColumnFACTORY_NO.ReadOnly = true;
            this.ColumnFACTORY_NO.Width = 62;
            // 
            // ColumnSL
            // 
            this.ColumnSL.DataPropertyName = "SL";
            this.ColumnSL.HeaderText = "库存地点";
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
            this.dataGridViewMaintainDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGridViewMaintainDetail.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewMaintainDetail.MultiSelect = false;
            this.dataGridViewMaintainDetail.Name = "dataGridViewMaintainDetail";
            this.dataGridViewMaintainDetail.ReadOnly = true;
            this.dataGridViewMaintainDetail.RowHeadersVisible = false;
            this.dataGridViewMaintainDetail.RowTemplate.Height = 23;
            this.dataGridViewMaintainDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintainDetail.Size = new System.Drawing.Size(1031, 160);
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
            // ColumnBIN
            // 
            this.ColumnBIN.DataPropertyName = "BIN";
            this.ColumnBIN.HeaderText = "货位";
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnReMaintain);
            this.groupBox1.Controls.Add(this.dataGridViewMaintain);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnEnd);
            this.groupBox1.Location = new System.Drawing.Point(12, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1043, 220);
            this.groupBox1.TabIndex = 30002;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保养单列表";
            // 
            // btnReMaintain
            // 
            this.btnReMaintain.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReMaintain.Enabled = false;
            this.btnReMaintain.Location = new System.Drawing.Point(937, 118);
            this.btnReMaintain.Name = "btnReMaintain";
            this.btnReMaintain.Size = new System.Drawing.Size(100, 40);
            this.btnReMaintain.TabIndex = 20007;
            this.btnReMaintain.Text = "重新保养";
            this.btnReMaintain.UseVisualStyleBackColor = true;
            this.btnReMaintain.Click += new System.EventHandler(this.btnReMaintain_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(937, 26);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 40);
            this.btnStart.TabIndex = 20002;
            this.btnStart.Text = "开始保养";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(937, 72);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 40);
            this.btnDel.TabIndex = 20003;
            this.btnDel.Text = "作废保养";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(937, 164);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(100, 40);
            this.btnEnd.TabIndex = 20004;
            this.btnEnd.Text = "结束保养";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewMaintainDetail);
            this.groupBox2.Location = new System.Drawing.Point(12, 374);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1043, 186);
            this.groupBox2.TabIndex = 30003;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保养单详细";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBoxTableMakeDate);
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateTo);
            this.groupBox3.Controls.Add(this.label10);
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
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateFrom);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1043, 130);
            this.groupBox3.TabIndex = 30004;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "保养单列表";
            // 
            // checkBoxTableMakeDate
            // 
            this.checkBoxTableMakeDate.AutoSize = true;
            this.checkBoxTableMakeDate.Location = new System.Drawing.Point(28, 91);
            this.checkBoxTableMakeDate.Name = "checkBoxTableMakeDate";
            this.checkBoxTableMakeDate.Size = new System.Drawing.Size(98, 24);
            this.checkBoxTableMakeDate.TabIndex = 20019;
            this.checkBoxTableMakeDate.Text = "制表日期：";
            this.checkBoxTableMakeDate.UseVisualStyleBackColor = true;
            this.checkBoxTableMakeDate.CheckedChanged += new System.EventHandler(this.checkBoxTableMakeDate_CheckedChanged);
            // 
            // dateTimePickerTableMakeDateTo
            // 
            this.dateTimePickerTableMakeDateTo.Enabled = false;
            this.dateTimePickerTableMakeDateTo.Location = new System.Drawing.Point(365, 91);
            this.dateTimePickerTableMakeDateTo.Name = "dateTimePickerTableMakeDateTo";
            this.dateTimePickerTableMakeDateTo.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerTableMakeDateTo.TabIndex = 20018;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(308, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 20);
            this.label10.TabIndex = 20015;
            this.label10.Text = "TO";
            // 
            // textBoxMaintainNo
            // 
            this.textBoxMaintainNo.Location = new System.Drawing.Point(132, 25);
            this.textBoxMaintainNo.Name = "textBoxMaintainNo";
            this.textBoxMaintainNo.Size = new System.Drawing.Size(150, 26);
            this.textBoxMaintainNo.TabIndex = 20014;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 28);
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
            this.comboBoxState.Location = new System.Drawing.Point(132, 57);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(150, 28);
            this.comboBoxState.TabIndex = 20012;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 20011;
            this.label3.Text = "单据状态：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(365, 25);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(150, 28);
            this.comboBoxPlant.TabIndex = 20009;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 20008;
            this.label7.Text = "公司：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(606, 25);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(150, 28);
            this.comboBoxSLocation.TabIndex = 20010;
            // 
            // textBoxOperator
            // 
            this.textBoxOperator.Location = new System.Drawing.Point(606, 59);
            this.textBoxOperator.Name = "textBoxOperator";
            this.textBoxOperator.Size = new System.Drawing.Size(150, 26);
            this.textBoxOperator.TabIndex = 20006;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(521, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 20007;
            this.label6.Text = "库存地点：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 20005;
            this.label2.Text = "制单人：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 20003;
            this.label1.Text = "保管员：";
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.Location = new System.Drawing.Point(365, 59);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.Size = new System.Drawing.Size(150, 26);
            this.textBoxStoreMan.TabIndex = 20004;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(937, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 20002;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dateTimePickerTableMakeDateFrom
            // 
            this.dateTimePickerTableMakeDateFrom.Enabled = false;
            this.dateTimePickerTableMakeDateFrom.Location = new System.Drawing.Point(132, 91);
            this.dateTimePickerTableMakeDateFrom.Name = "dateTimePickerTableMakeDateFrom";
            this.dateTimePickerTableMakeDateFrom.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerTableMakeDateFrom.TabIndex = 20017;
            // 
            // textBoxMaintain
            // 
            this.textBoxMaintain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMaintain.Enabled = false;
            this.textBoxMaintain.Location = new System.Drawing.Point(131, 573);
            this.textBoxMaintain.Name = "textBoxMaintain";
            this.textBoxMaintain.Size = new System.Drawing.Size(130, 26);
            this.textBoxMaintain.TabIndex = 30006;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 576);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 30007;
            this.label8.Text = "修改已保养数量";
            // 
            // btnModNum
            // 
            this.btnModNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModNum.Enabled = false;
            this.btnModNum.Location = new System.Drawing.Point(617, 566);
            this.btnModNum.Name = "btnModNum";
            this.btnModNum.Size = new System.Drawing.Size(100, 40);
            this.btnModNum.TabIndex = 30008;
            this.btnModNum.Text = "修改";
            this.btnModNum.UseVisualStyleBackColor = true;
            this.btnModNum.Click += new System.EventHandler(this.btnModNum_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(723, 566);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 30009;
            this.btnCancel.Text = "取消修改";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmitMod
            // 
            this.btnSubmitMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitMod.Enabled = false;
            this.btnSubmitMod.Location = new System.Drawing.Point(829, 566);
            this.btnSubmitMod.Name = "btnSubmitMod";
            this.btnSubmitMod.Size = new System.Drawing.Size(120, 40);
            this.btnSubmitMod.TabIndex = 30010;
            this.btnSubmitMod.Text = "提交重新保养";
            this.btnSubmitMod.UseVisualStyleBackColor = true;
            this.btnSubmitMod.Click += new System.EventHandler(this.btnSubmitMod_Click);
            // 
            // 管理保养单
            // 
            this.ClientSize = new System.Drawing.Size(1067, 618);
            this.ControlBox = false;
            this.Controls.Add(this.btnSubmitMod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModNum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxMaintain);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "管理保养单";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        public 管理保养单(UserInfo userItem, ArrayList userRoles)
        {
            dtReport = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
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

            dataGridViewMaintain.AutoGenerateColumns = false;
            dataGridViewMaintainDetail.AutoGenerateColumns = false;

            InitTableColumns();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否取消重新保养？继续此操作先前的修改将被取消，请确认"))
            {
                textBoxMaintain.Text = string.Empty;
                SetModControlsEnable(false);
                dataGridViewMaintain_SelectionChanged(null, null);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否作废本保养单？"))
            {
                if (DBOperate.MaintainModState(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "0", "-1") == 1)
                {
                    dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "作废单据";
                    CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 作废保养");
                }
                else
                {
                    CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 作废保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                }

                dataGridViewMaintain_SelectionChanged(null, null);
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否结束保养本保养单货物？"))
            {
                if (DBOperate.MaintainModState(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "1", "2") == 1)
                {
                    dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "保养完成";
                    CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 结束保养");
                }
                else
                {
                    CommonFunction.Sys_MsgBox("单据 " + this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 结束保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                }

                dataGridViewMaintain_SelectionChanged(null, null);
            }
        }

        private void btnModNum_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaintainDetail.SelectedRows[0].Index == (dataGridViewMaintainDetail.Rows.Count - 1))
            {
                textBoxMaintain.Text = "0";
                CommonFunction.Sys_MsgBox("合计行不可进行修改");
            }
            else
            {
                decimal num;

                try
                {
                    num = Convert.ToDecimal(textBoxMaintain.Text.Trim());

                    if ((num < 0M) || (num > Convert.ToDecimal(dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnPLAN_NUM"].Value)))
                    {
                        CommonFunction.Sys_MsgBox("重新保养数量必须大于0小于计划保养数量，请重新输入");
                        return;
                    }
                }
                catch
                {
                    CommonFunction.Sys_MsgBox("输入不符合数字格式，请重新输入");
                    return;
                }

                dtMaintainDetail.Select(" BARCODE='" + dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnBARCODE"].Value.ToString() + "' and BIN='" + dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnBIN"].Value.ToString() + "'")[0]["MAINTAINNUM"] = num;
            }
        }

        private void btnReMaintain_Click(object sender, EventArgs e)
        {
            SetButtonsEnable(false, false, false);
            SetModControlsEnable(true);
            dataGridViewMaintainDetail_SelectionChanged(null, null);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dataGridViewMaintainDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            ArrayList arriveList = new ArrayList
            {
                textBoxMaintainNo.Text.Trim(),
                comboBoxPlant.Text.Trim().Replace("无", string.Empty),
                comboBoxSLocation.Text.Trim().Replace("无", string.Empty),
                textBoxStoreMan.Text.Trim(),
                textBoxOperator.Text.Trim(),
                (comboBoxState.SelectedIndex == -1) ? "" : comboBoxState.SelectedIndex.ToString()
            };

            if (checkBoxTableMakeDate.Checked)
            {
                arriveList.Add(dateTimePickerTableMakeDateFrom.Value.Date.ToString());
                arriveList.Add(dateTimePickerTableMakeDateTo.Value.Date.ToString());
            }
            else
            {
                arriveList.Add(string.Empty);
                arriveList.Add(string.Empty);
            }

            dtMaintainHeader = DBOperate.MaintainGetHead(arriveList);
            dataGridViewMaintain.DataSource = dtMaintainHeader;

            if (!CommonFunction.IfHasData(dtMaintainHeader))
            {
                dtMaintainDetail.Rows.Clear();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否开始保养本保养单货物？"))
            {
                if (DBOperate.MaintainModState(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "0", "1") == 1)
                {
                    dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "保养中";
                    CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 开始保养");
                }
                else
                {
                    CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 开始保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                }

                dataGridViewMaintain_SelectionChanged(null, null);
            }
        }

        private void btnSubmitMod_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否提交重新保养？"))
            {
                if (DBOperate.MaintainReMaintain(dtMaintainDetail))
                {
                    CommonFunction.Sys_MsgBox("单据" + dtMaintainDetail.Rows[0]["MAINTAIN_NO"].ToString() + "被退回重新保养");
                    textBoxMaintain.Text = string.Empty;
                    SetModControlsEnable(false);
                    dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "保养中";
                    dataGridViewMaintain_SelectionChanged(null, null);
                }
                else
                {
                    CommonFunction.Sys_MsgBox("退保养失败，请重新查看单据是否已经被改动");
                }
            }
        }

        private void checkBoxTableMakeDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerTableMakeDateFrom.Enabled = dateTimePickerTableMakeDateTo.Enabled = checkBoxTableMakeDate.Checked;
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
            if ((dataGridViewMaintain.Rows == null) || (dataGridViewMaintain.SelectedRows.Count == 0))
            {
                SetButtonsEnable(false, false, false);
            }
            else
            {
                string str = dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value.ToString();

                if (str != null)
                {
                    if (!(str == "等待批准"))
                    {
                        if (str == "保养完成")
                        {
                            SetButtonsEnable(false, true, true);
                        }
                        else if ((str == "保养中") || (str == "作废单据"))
                        {
                            SetButtonsEnable(false, false, false);
                        }
                        else if (str == "结束保养")
                        {
                            SetButtonsEnable(false, true, false);
                        }
                    }
                    else
                    {
                        SetButtonsEnable(true, false, false);
                    }
                }

                dtMaintainDetail = DBOperate.MaintainGetDetail(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString());
            }

            dataGridViewMaintainDetail.DataSource = dtMaintainDetail;
            decimal num = 0M;
            decimal num2 = 0M;
            decimal num3 = 0M;

            if (CommonFunction.IfHasData(dtMaintainDetail))
            {
                foreach (DataRow row in dtMaintainDetail.Rows)
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
                dtMaintainDetail.Rows.Add(values);
            }
        }

        private void dataGridViewMaintainDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (textBoxMaintain.Enabled && ((dataGridViewMaintainDetail.Rows != null) && (dataGridViewMaintainDetail.SelectedRows.Count != 0)))
            {
                if (dataGridViewMaintainDetail.SelectedRows[0].Index != (dataGridViewMaintainDetail.Rows.Count - 1))
                {
                    textBoxMaintain.Text = dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnMAINTAINNUM"].Value.ToString();
                }
                else
                {
                    textBoxMaintain.Text = "0";
                }
            }
        }

        private void InitTableColumns()
        {
            dtMaintainHeader = new DataTable();
            dtMaintainHeader.Columns.Add("MAINTAIN_NO");
            dtMaintainHeader.Columns.Add("FACTORY_NO");
            dtMaintainHeader.Columns.Add("SL");
            dtMaintainHeader.Columns.Add("STOREMAN");
            dtMaintainHeader.Columns.Add("OPERATOR");
            dtMaintainHeader.Columns.Add("OPERATE_TIME");
            dtMaintainHeader.Columns.Add("State");
            dataGridViewMaintain.DataSource = dtMaintainHeader;
            dtMaintainDetail = new DataTable();
            dtMaintainDetail.Columns.Add("MAINTAIN_NO");
            dtMaintainDetail.Columns.Add("BARCODE");
            dtMaintainDetail.Columns.Add("FACT_NO");
            dtMaintainDetail.Columns.Add("PRODUCT_NO");
            dtMaintainDetail.Columns.Add("PATCH_NO");
            dtMaintainDetail.Columns.Add("PRODUCT_NAME");
            dtMaintainDetail.Columns.Add("UNIT");
            dtMaintainDetail.Columns.Add("BIN");
            dtMaintainDetail.Columns.Add("BIN_NUM");
            dtMaintainDetail.Columns.Add("MAINTAINNUM");
            dtMaintainDetail.Columns.Add("SUPPLIER_NO");
            dataGridViewMaintainDetail.DataSource = dtMaintainDetail;
            dtReport = new DataTable();
            dtReport.Columns.Add("物料号");
            dtReport.Columns.Add("批次号");
            dtReport.Columns.Add("物料名称");
            dtReport.Columns.Add("保养数量");
            dtReport.Columns.Add("物品单重");
            dtReport.Columns.Add("货位");
        }

        private void SetButtonsEnable(bool startEnable, bool delEnable, bool reMaintain)
        {
            btnStart.Enabled = startEnable;
            btnDel.Enabled = delEnable;
            btnReMaintain.Enabled = reMaintain;
        }

        private void SetModControlsEnable(bool controlsEnable)
        {
            btnSelect.Enabled = !controlsEnable;
            dataGridViewMaintain.Enabled = !controlsEnable;
            textBoxMaintain.Enabled = controlsEnable;
            btnModNum.Enabled = controlsEnable;
            btnCancel.Enabled = controlsEnable;
            btnSubmitMod.Enabled = controlsEnable;
        }
    }
}
