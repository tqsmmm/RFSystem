using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BL;
using System.Collections;
using RFSystem.CommonClass;

namespace RFSystem
{
    public class 查询保养单 : Form
    {
        private Button btnSelect;
        private CheckBox checkBoxComplete;
        private DataGridViewTextBoxColumn ColumnBIN;
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
        private DataGridViewTextBoxColumn ColumnSTOREMAN;
        private DataGridViewTextBoxColumn ColumnSUPPLIER_NO;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private IContainer components;
        private DataGridView dataGridViewMaintainInfo;
        private DateTimePicker dateTimePickerTableMakeDateFrom;
        private DateTimePicker dateTimePickerTableMakeDateTo;
        private DataTable dtPlantList;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox1;
        private Label label10;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBoxBin;
        private TextBox textBoxMaintainID;
        private TextBox textBoxOperator;
        private TextBox textBoxStoreMan;
        private UserInfo userItem;
        private Button btn_tohis;
        private DateTimePicker dtpto;
        private DateTimePicker dtpfrom;
        private Label label4;
        private Label label5;
        private Button btn_query;
        private CheckBox checkBoxTableMakeDate;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxOperator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMaintainID = new System.Windows.Forms.TextBox();
            this.checkBoxTableMakeDate = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTableMakeDateTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTableMakeDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxComplete = new System.Windows.Forms.CheckBox();
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewMaintainInfo = new System.Windows.Forms.DataGridView();
            this.ColumnMAINTAIN_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFACTORY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPATCH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPLAN_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMAINTAINNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSUPPLIER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTOREMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOPERATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOPERATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_tohis = new System.Windows.Forms.Button();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintainInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxOperator);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxMaintainID);
            this.groupBox1.Controls.Add(this.checkBoxTableMakeDate);
            this.groupBox1.Controls.Add(this.dateTimePickerTableMakeDateTo);
            this.groupBox1.Controls.Add(this.dateTimePickerTableMakeDateFrom);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkBoxComplete);
            this.groupBox1.Controls.Add(this.textBoxStoreMan);
            this.groupBox1.Controls.Add(this.textBoxBin);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxPlant);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxSLocation);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1113, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盘存信息检索";
            // 
            // textBoxOperator
            // 
            this.textBoxOperator.Location = new System.Drawing.Point(806, 57);
            this.textBoxOperator.Name = "textBoxOperator";
            this.textBoxOperator.ReadOnly = true;
            this.textBoxOperator.Size = new System.Drawing.Size(150, 26);
            this.textBoxOperator.TabIndex = 132;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(735, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 131;
            this.label2.Text = "制单员：";
            // 
            // textBoxMaintainID
            // 
            this.textBoxMaintainID.Location = new System.Drawing.Point(125, 25);
            this.textBoxMaintainID.Name = "textBoxMaintainID";
            this.textBoxMaintainID.Size = new System.Drawing.Size(150, 26);
            this.textBoxMaintainID.TabIndex = 10;
            this.textBoxMaintainID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // checkBoxTableMakeDate
            // 
            this.checkBoxTableMakeDate.AutoSize = true;
            this.checkBoxTableMakeDate.Location = new System.Drawing.Point(21, 59);
            this.checkBoxTableMakeDate.Name = "checkBoxTableMakeDate";
            this.checkBoxTableMakeDate.Size = new System.Drawing.Size(98, 24);
            this.checkBoxTableMakeDate.TabIndex = 80;
            this.checkBoxTableMakeDate.Text = "制表日期：";
            this.checkBoxTableMakeDate.UseVisualStyleBackColor = true;
            this.checkBoxTableMakeDate.CheckedChanged += new System.EventHandler(this.checkBoxTableMakeDate_CheckedChanged);
            this.checkBoxTableMakeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dateTimePickerTableMakeDateTo
            // 
            this.dateTimePickerTableMakeDateTo.Enabled = false;
            this.dateTimePickerTableMakeDateTo.Location = new System.Drawing.Point(338, 59);
            this.dateTimePickerTableMakeDateTo.Name = "dateTimePickerTableMakeDateTo";
            this.dateTimePickerTableMakeDateTo.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerTableMakeDateTo.TabIndex = 70;
            this.dateTimePickerTableMakeDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dateTimePickerTableMakeDateFrom
            // 
            this.dateTimePickerTableMakeDateFrom.Enabled = false;
            this.dateTimePickerTableMakeDateFrom.Location = new System.Drawing.Point(125, 57);
            this.dateTimePickerTableMakeDateFrom.Name = "dateTimePickerTableMakeDateFrom";
            this.dateTimePickerTableMakeDateFrom.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerTableMakeDateFrom.TabIndex = 60;
            this.dateTimePickerTableMakeDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(294, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "TO";
            // 
            // checkBoxComplete
            // 
            this.checkBoxComplete.AutoSize = true;
            this.checkBoxComplete.Location = new System.Drawing.Point(1023, 71);
            this.checkBoxComplete.Name = "checkBoxComplete";
            this.checkBoxComplete.Size = new System.Drawing.Size(70, 24);
            this.checkBoxComplete.TabIndex = 120;
            this.checkBoxComplete.Text = "未完成";
            this.checkBoxComplete.UseVisualStyleBackColor = true;
            this.checkBoxComplete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.Location = new System.Drawing.Point(579, 59);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.ReadOnly = true;
            this.textBoxStoreMan.Size = new System.Drawing.Size(150, 26);
            this.textBoxStoreMan.TabIndex = 50;
            this.textBoxStoreMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(806, 25);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(150, 26);
            this.textBoxBin.TabIndex = 40;
            this.textBoxBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(1007, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 130;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "保养单号：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(749, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "货位：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(338, 25);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(150, 28);
            this.comboBoxPlant.TabIndex = 20;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            this.comboBoxPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "公司：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(579, 25);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(150, 28);
            this.comboBoxSLocation.TabIndex = 30;
            this.comboBoxSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(494, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "存储地点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "保管员：";
            // 
            // dataGridViewMaintainInfo
            // 
            this.dataGridViewMaintainInfo.AllowUserToAddRows = false;
            this.dataGridViewMaintainInfo.AllowUserToResizeRows = false;
            this.dataGridViewMaintainInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMaintainInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMaintainInfo.ColumnHeadersHeight = 30;
            this.dataGridViewMaintainInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMaintainInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMAINTAIN_NO,
            this.ColumnFACTORY_NO,
            this.ColumnSL,
            this.ColumnPRODUCT_NO,
            this.ColumnPATCH_NO,
            this.ColumnPRODUCT_NAME,
            this.ColumnUNIT,
            this.ColumnBIN,
            this.ColumnPLAN_NUM,
            this.ColumnMAINTAINNUM,
            this.ColumnSUPPLIER_NO,
            this.ColumnSTOREMAN,
            this.ColumnOPERATOR,
            this.ColumnOPERATE_TIME});
            this.dataGridViewMaintainInfo.Location = new System.Drawing.Point(12, 118);
            this.dataGridViewMaintainInfo.MultiSelect = false;
            this.dataGridViewMaintainInfo.Name = "dataGridViewMaintainInfo";
            this.dataGridViewMaintainInfo.ReadOnly = true;
            this.dataGridViewMaintainInfo.RowHeadersVisible = false;
            this.dataGridViewMaintainInfo.RowTemplate.Height = 23;
            this.dataGridViewMaintainInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintainInfo.Size = new System.Drawing.Size(1113, 442);
            this.dataGridViewMaintainInfo.TabIndex = 11;
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
            this.ColumnSL.HeaderText = "存储地点";
            this.ColumnSL.Name = "ColumnSL";
            this.ColumnSL.ReadOnly = true;
            this.ColumnSL.Width = 90;
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
            this.ColumnPRODUCT_NAME.HeaderText = "货物名称";
            this.ColumnPRODUCT_NAME.Name = "ColumnPRODUCT_NAME";
            this.ColumnPRODUCT_NAME.ReadOnly = true;
            this.ColumnPRODUCT_NAME.Width = 90;
            // 
            // ColumnUNIT
            // 
            this.ColumnUNIT.DataPropertyName = "UNIT";
            this.ColumnUNIT.HeaderText = "单位";
            this.ColumnUNIT.Name = "ColumnUNIT";
            this.ColumnUNIT.ReadOnly = true;
            this.ColumnUNIT.Width = 62;
            // 
            // ColumnBIN
            // 
            this.ColumnBIN.DataPropertyName = "BIN";
            this.ColumnBIN.HeaderText = "货位";
            this.ColumnBIN.Name = "ColumnBIN";
            this.ColumnBIN.ReadOnly = true;
            this.ColumnBIN.Width = 62;
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
            // ColumnSUPPLIER_NO
            // 
            this.ColumnSUPPLIER_NO.DataPropertyName = "SUPPLIER_NO";
            this.ColumnSUPPLIER_NO.HeaderText = "二级厂";
            this.ColumnSUPPLIER_NO.Name = "ColumnSUPPLIER_NO";
            this.ColumnSUPPLIER_NO.ReadOnly = true;
            this.ColumnSUPPLIER_NO.Width = 76;
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
            this.ColumnOPERATOR.HeaderText = "制单员";
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
            // btn_tohis
            // 
            this.btn_tohis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_tohis.Location = new System.Drawing.Point(555, 566);
            this.btn_tohis.Name = "btn_tohis";
            this.btn_tohis.Size = new System.Drawing.Size(120, 40);
            this.btn_tohis.TabIndex = 133;
            this.btn_tohis.Text = "转移至历史库";
            this.btn_tohis.UseVisualStyleBackColor = true;
            this.btn_tohis.Click += new System.EventHandler(this.btn_tohis_Click);
            // 
            // dtpto
            // 
            this.dtpto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpto.Location = new System.Drawing.Point(293, 571);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(150, 26);
            this.dtpto.TabIndex = 504;
            this.dtpto.ValueChanged += new System.EventHandler(this.dtpfrom_ValueChanged);
            // 
            // dtpfrom
            // 
            this.dtpfrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpfrom.Location = new System.Drawing.Point(103, 573);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(150, 26);
            this.dtpfrom.TabIndex = 503;
            this.dtpfrom.ValueChanged += new System.EventHandler(this.dtpfrom_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 576);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 20);
            this.label4.TabIndex = 501;
            this.label4.Text = "TO";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 576);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 502;
            this.label5.Text = "制单日期：";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_query.Location = new System.Drawing.Point(449, 566);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(100, 40);
            this.btn_query.TabIndex = 505;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // 查询保养单
            // 
            this.ClientSize = new System.Drawing.Size(1136, 618);
            this.ControlBox = false;
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_tohis);
            this.Controls.Add(this.dataGridViewMaintainInfo);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "查询保养单";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询保养单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.查询保养单_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintainInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 查询保养单(UserInfo userItem, ArrayList userRoles)
        {
            this.userItem = null;
            this.userRoles = null;
            dtPlantList = null;
            dtStoreLocusList = null;
            components = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;

            if (this.userItem.isAdmin)
            {
                textBoxOperator.ReadOnly = false;
                textBoxStoreMan.ReadOnly = false;
            }

            textBoxOperator.Text = userItem.userID;
            textBoxStoreMan.Text = userItem.userID;
            dataGridViewMaintainInfo.AutoGenerateColumns = false;
            InitFctAndStore();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ArrayList arriveList = new ArrayList();
            arriveList.Add(textBoxMaintainID.Text.Trim().Equals(string.Empty) ? string.Empty : textBoxMaintainID.Text.Trim());
            arriveList.Add(comboBoxPlant.Text.Equals("无") ? string.Empty : comboBoxPlant.Text);
            arriveList.Add(comboBoxSLocation.Text.Equals("无") ? string.Empty : comboBoxSLocation.Text);
            arriveList.Add(textBoxBin.Text.Trim().Equals(string.Empty) ? string.Empty : textBoxBin.Text.Trim());
            arriveList.Add(textBoxStoreMan.Text.Trim().Equals(string.Empty) ? string.Empty : textBoxStoreMan.Text.Trim());
            arriveList.Add(textBoxOperator.Text.Trim().Equals(string.Empty) ? string.Empty : textBoxOperator.Text.Trim());

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

            arriveList.Add(checkBoxComplete.Checked ? "1" : string.Empty);
            //this.dataGridViewMaintainInfo.DataSource = DBOperate.MaintainGetList(arriveList);
            dataGridViewMaintainInfo.DataSource = BL.ClsCommon.MaintainGetList_New(arriveList);
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

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetNextControl(ActiveControl, true).Focus();
            }
        }

        private void dtpfrom_ValueChanged(object sender, EventArgs e)
        {
            btn_tohis.Enabled = false;
        }

        private void 查询保养单_Load(object sender, EventArgs e)
        {
            btn_tohis.Enabled = false;
        }

        #region 转移至历史库

        private void btn_query_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Cursor.Position = MousePosition;
            ((Button)sender).Enabled = false;
            btn_tohis.Enabled = false;

            try
            {
                ArrayList arriveList = new ArrayList();
                arriveList.Add("");
                arriveList.Add("");
                arriveList.Add("");
                arriveList.Add("");
                arriveList.Add("");
                arriveList.Add("");
                arriveList.Add(dtpfrom.Value.Date.ToString());
                arriveList.Add(dtpto.Value.Date.ToString());
                arriveList.Add("");
                dataGridViewMaintainInfo.DataSource = BL.ClsCommon.MaintainGetList_New(arriveList);

                if (dataGridViewMaintainInfo.Rows.Count > 0)
                {
                    btn_tohis.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败，请稍后重试。失败原因：\r\n" + ex.Message, "注意", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                ((Button)sender).Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btn_tohis_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Cursor.Position = MousePosition;
            ((Button)sender).Enabled = false;

            try
            {
                if (0 != BL.ClsCommon.MaintainItemToHis(dtpfrom.Value, dtpto.Value, ConstDefine.g_User))
                {
                    MessageBox.Show("转移至历史库失败，请稍后重试", "注意", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ((Button)sender).Enabled = true;
                    return;
                }
                //this.dataGridViewMaintainInfo.Rows.Clear();
                btn_query_Click(sender, e);
                ((Button)sender).Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败，失败原因：\r\n" + ex.Message, "注意", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((Button)sender).Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}
