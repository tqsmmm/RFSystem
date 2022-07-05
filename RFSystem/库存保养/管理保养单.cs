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
        private Button btnExit;
        private Button btnModNum;
        private Button btnPrint;
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
        private IContainer components;
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
        private Label label5;
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
            this.dataGridViewMaintain = new DataGridView();
            this.ColumnState = new DataGridViewTextBoxColumn();
            this.ColumnMAINTAIN_NO = new DataGridViewTextBoxColumn();
            this.ColumnFACTORY_NO = new DataGridViewTextBoxColumn();
            this.ColumnSL = new DataGridViewTextBoxColumn();
            this.ColumnSTOREMAN = new DataGridViewTextBoxColumn();
            this.ColumnOPERATOR = new DataGridViewTextBoxColumn();
            this.ColumnOPERATE_TIME = new DataGridViewTextBoxColumn();
            this.dataGridViewMaintainDetail = new DataGridView();
            this.ColumnBARCODE = new DataGridViewTextBoxColumn();
            this.ColumnFACT_NO = new DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NO = new DataGridViewTextBoxColumn();
            this.ColumnPATCH_NO = new DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NAME = new DataGridViewTextBoxColumn();
            this.ColumnBIN = new DataGridViewTextBoxColumn();
            this.ColumnBIN_NUM = new DataGridViewTextBoxColumn();
            this.ColumnPLAN_NUM = new DataGridViewTextBoxColumn();
            this.ColumnMAINTAINNUM = new DataGridViewTextBoxColumn();
            this.ColumnWeight = new DataGridViewTextBoxColumn();
            this.ColumnUNIT = new DataGridViewTextBoxColumn();
            this.ColumnSUPPLIER_NO = new DataGridViewTextBoxColumn();
            this.ColumnDetailMAINTAIN_NO = new DataGridViewTextBoxColumn();
            this.groupBox1 = new GroupBox();
            this.btnReMaintain = new Button();
            this.btnPrint = new Button();
            this.btnStart = new Button();
            this.btnDel = new Button();
            this.btnExit = new Button();
            this.btnEnd = new Button();
            this.groupBox2 = new GroupBox();
            this.groupBox3 = new GroupBox();
            this.checkBoxTableMakeDate = new CheckBox();
            this.dateTimePickerTableMakeDateTo = new DateTimePicker();
            this.dateTimePickerTableMakeDateFrom = new DateTimePicker();
            this.label10 = new Label();
            this.label5 = new Label();
            this.textBoxMaintainNo = new TextBox();
            this.label4 = new Label();
            this.comboBoxState = new ComboBox();
            this.label3 = new Label();
            this.comboBoxPlant = new ComboBox();
            this.label7 = new Label();
            this.comboBoxSLocation = new ComboBox();
            this.textBoxOperator = new TextBox();
            this.label6 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.textBoxStoreMan = new TextBox();
            this.btnSelect = new Button();
            this.textBoxMaintain = new TextBox();
            this.label8 = new Label();
            this.btnModNum = new Button();
            this.btnCancel = new Button();
            this.btnSubmitMod = new Button();
            ((ISupportInitialize)this.dataGridViewMaintain).BeginInit();
            ((ISupportInitialize)this.dataGridViewMaintainDetail).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.dataGridViewMaintain.AllowUserToAddRows = false;
            this.dataGridViewMaintain.AllowUserToResizeRows = false;
            this.dataGridViewMaintain.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.dataGridViewMaintain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMaintain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMaintain.Columns.AddRange(new DataGridViewColumn[] { this.ColumnState, this.ColumnMAINTAIN_NO, this.ColumnFACTORY_NO, this.ColumnSL, this.ColumnSTOREMAN, this.ColumnOPERATOR, this.ColumnOPERATE_TIME });
            this.dataGridViewMaintain.Location = new Point(6, 20);
            this.dataGridViewMaintain.MultiSelect = false;
            this.dataGridViewMaintain.Name = "dataGridViewMaintain";
            this.dataGridViewMaintain.ReadOnly = true;
            this.dataGridViewMaintain.RowHeadersVisible = false;
            this.dataGridViewMaintain.RowTemplate.Height = 0x17;
            this.dataGridViewMaintain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintain.Size = new Size(0x359, 0x8a);
            this.dataGridViewMaintain.TabIndex = 0x4e21;
            this.dataGridViewMaintain.SelectionChanged += new EventHandler(this.dataGridViewMaintain_SelectionChanged);
            this.ColumnState.DataPropertyName = "State";
            this.ColumnState.HeaderText = "状态";
            this.ColumnState.Name = "ColumnState";
            this.ColumnState.ReadOnly = true;
            this.ColumnState.Width = 0x36;
            this.ColumnMAINTAIN_NO.DataPropertyName = "MAINTAIN_NO";
            this.ColumnMAINTAIN_NO.HeaderText = "保养单号";
            this.ColumnMAINTAIN_NO.Name = "ColumnMAINTAIN_NO";
            this.ColumnMAINTAIN_NO.ReadOnly = true;
            this.ColumnMAINTAIN_NO.Width = 0x4e;
            this.ColumnFACTORY_NO.DataPropertyName = "FACTORY_NO";
            this.ColumnFACTORY_NO.HeaderText = "公司";
            this.ColumnFACTORY_NO.Name = "ColumnFACTORY_NO";
            this.ColumnFACTORY_NO.ReadOnly = true;
            this.ColumnFACTORY_NO.Width = 0x36;
            this.ColumnSL.DataPropertyName = "SL";
            this.ColumnSL.HeaderText = "库存地点";
            this.ColumnSL.Name = "ColumnSL";
            this.ColumnSL.ReadOnly = true;
            this.ColumnSL.Width = 0x4e;
            this.ColumnSTOREMAN.DataPropertyName = "STOREMAN";
            this.ColumnSTOREMAN.HeaderText = "保管员";
            this.ColumnSTOREMAN.Name = "ColumnSTOREMAN";
            this.ColumnSTOREMAN.ReadOnly = true;
            this.ColumnSTOREMAN.Width = 0x42;
            this.ColumnOPERATOR.DataPropertyName = "OPERATOR";
            this.ColumnOPERATOR.HeaderText = "制单人";
            this.ColumnOPERATOR.Name = "ColumnOPERATOR";
            this.ColumnOPERATOR.ReadOnly = true;
            this.ColumnOPERATOR.Width = 0x42;
            this.ColumnOPERATE_TIME.DataPropertyName = "OPERATE_TIME";
            this.ColumnOPERATE_TIME.HeaderText = "制单日期";
            this.ColumnOPERATE_TIME.Name = "ColumnOPERATE_TIME";
            this.ColumnOPERATE_TIME.ReadOnly = true;
            this.ColumnOPERATE_TIME.Width = 0x4e;
            this.dataGridViewMaintainDetail.AllowUserToAddRows = false;
            this.dataGridViewMaintainDetail.AllowUserToResizeRows = false;
            this.dataGridViewMaintainDetail.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.dataGridViewMaintainDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMaintainDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMaintainDetail.Columns.AddRange(new DataGridViewColumn[] { this.ColumnBARCODE, this.ColumnFACT_NO, this.ColumnPRODUCT_NO, this.ColumnPATCH_NO, this.ColumnPRODUCT_NAME, this.ColumnBIN, this.ColumnBIN_NUM, this.ColumnPLAN_NUM, this.ColumnMAINTAINNUM, this.ColumnWeight, this.ColumnUNIT, this.ColumnSUPPLIER_NO, this.ColumnDetailMAINTAIN_NO });
            this.dataGridViewMaintainDetail.Location = new Point(6, 20);
            this.dataGridViewMaintainDetail.MultiSelect = false;
            this.dataGridViewMaintainDetail.Name = "dataGridViewMaintainDetail";
            this.dataGridViewMaintainDetail.ReadOnly = true;
            this.dataGridViewMaintainDetail.RowHeadersVisible = false;
            this.dataGridViewMaintainDetail.RowTemplate.Height = 0x17;
            this.dataGridViewMaintainDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintainDetail.Size = new Size(0x3aa, 280);
            this.dataGridViewMaintainDetail.TabIndex = 0x7531;
            this.dataGridViewMaintainDetail.SelectionChanged += new EventHandler(this.dataGridViewMaintainDetail_SelectionChanged);
            this.ColumnBARCODE.DataPropertyName = "BARCODE";
            this.ColumnBARCODE.HeaderText = "条码号";
            this.ColumnBARCODE.Name = "ColumnBARCODE";
            this.ColumnBARCODE.ReadOnly = true;
            this.ColumnBARCODE.Visible = false;
            this.ColumnFACT_NO.DataPropertyName = "FACT_NO";
            this.ColumnFACT_NO.HeaderText = "公司号";
            this.ColumnFACT_NO.Name = "ColumnFACT_NO";
            this.ColumnFACT_NO.ReadOnly = true;
            this.ColumnFACT_NO.Visible = false;
            this.ColumnFACT_NO.Width = 60;
            this.ColumnPRODUCT_NO.DataPropertyName = "PRODUCT_NO";
            this.ColumnPRODUCT_NO.HeaderText = "物料号";
            this.ColumnPRODUCT_NO.Name = "ColumnPRODUCT_NO";
            this.ColumnPRODUCT_NO.ReadOnly = true;
            this.ColumnPRODUCT_NO.Width = 0x42;
            this.ColumnPATCH_NO.DataPropertyName = "PATCH_NO";
            this.ColumnPATCH_NO.HeaderText = "批次号";
            this.ColumnPATCH_NO.Name = "ColumnPATCH_NO";
            this.ColumnPATCH_NO.ReadOnly = true;
            this.ColumnPATCH_NO.Width = 0x42;
            this.ColumnPRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.ColumnPRODUCT_NAME.HeaderText = "物品名称";
            this.ColumnPRODUCT_NAME.Name = "ColumnPRODUCT_NAME";
            this.ColumnPRODUCT_NAME.ReadOnly = true;
            this.ColumnPRODUCT_NAME.Width = 0x4e;
            this.ColumnBIN.DataPropertyName = "BIN";
            this.ColumnBIN.HeaderText = "货位";
            this.ColumnBIN.Name = "ColumnBIN";
            this.ColumnBIN.ReadOnly = true;
            this.ColumnBIN.Width = 0x36;
            this.ColumnBIN_NUM.DataPropertyName = "BIN_NUM";
            this.ColumnBIN_NUM.HeaderText = "库存数量";
            this.ColumnBIN_NUM.Name = "ColumnBIN_NUM";
            this.ColumnBIN_NUM.ReadOnly = true;
            this.ColumnBIN_NUM.Visible = false;
            this.ColumnBIN_NUM.Width = 60;
            this.ColumnPLAN_NUM.DataPropertyName = "PLAN_NUM";
            this.ColumnPLAN_NUM.HeaderText = "计划数量";
            this.ColumnPLAN_NUM.Name = "ColumnPLAN_NUM";
            this.ColumnPLAN_NUM.ReadOnly = true;
            this.ColumnPLAN_NUM.Width = 0x4e;
            this.ColumnMAINTAINNUM.DataPropertyName = "MAINTAINNUM";
            this.ColumnMAINTAINNUM.HeaderText = "保养数量";
            this.ColumnMAINTAINNUM.Name = "ColumnMAINTAINNUM";
            this.ColumnMAINTAINNUM.ReadOnly = true;
            this.ColumnMAINTAINNUM.Width = 0x4e;
            this.ColumnWeight.DataPropertyName = "WEIGHT";
            this.ColumnWeight.HeaderText = "单重";
            this.ColumnWeight.Name = "ColumnWeight";
            this.ColumnWeight.ReadOnly = true;
            this.ColumnWeight.Width = 0x36;
            this.ColumnUNIT.DataPropertyName = "UNIT";
            this.ColumnUNIT.HeaderText = "单位";
            this.ColumnUNIT.Name = "ColumnUNIT";
            this.ColumnUNIT.ReadOnly = true;
            this.ColumnUNIT.Width = 0x36;
            this.ColumnSUPPLIER_NO.DataPropertyName = "SUPPLIER_NO";
            this.ColumnSUPPLIER_NO.HeaderText = "生产厂代码";
            this.ColumnSUPPLIER_NO.Name = "ColumnSUPPLIER_NO";
            this.ColumnSUPPLIER_NO.ReadOnly = true;
            this.ColumnSUPPLIER_NO.Visible = false;
            this.ColumnSUPPLIER_NO.Width = 90;
            this.ColumnDetailMAINTAIN_NO.DataPropertyName = "MAINTAIN_NO";
            this.ColumnDetailMAINTAIN_NO.HeaderText = "保养单号";
            this.ColumnDetailMAINTAIN_NO.Name = "ColumnDetailMAINTAIN_NO";
            this.ColumnDetailMAINTAIN_NO.ReadOnly = true;
            this.ColumnDetailMAINTAIN_NO.Visible = false;
            this.groupBox1.Controls.Add(this.btnReMaintain);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.dataGridViewMaintain);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnEnd);
            this.groupBox1.Location = new Point(12, 0x67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(950, 0xa4);
            this.groupBox1.TabIndex = 0x7532;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保养单列表";
            this.btnReMaintain.Enabled = false;
            this.btnReMaintain.Location = new Point(0x365, 0x4e);
            this.btnReMaintain.Name = "btnReMaintain";
            this.btnReMaintain.Size = new Size(0x4b, 0x17);
            this.btnReMaintain.TabIndex = 0x4e27;
            this.btnReMaintain.Text = "重新保养";
            this.btnReMaintain.UseVisualStyleBackColor = true;
            this.btnReMaintain.Click += new EventHandler(this.btnReMaintain_Click);
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new Point(0x365, 0x6b);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x4b, 0x17);
            this.btnPrint.TabIndex = 0x4e26;
            this.btnPrint.Text = "结束保养";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.btnStart.Enabled = false;
            this.btnStart.Location = new Point(0x365, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new Size(0x4b, 0x17);
            this.btnStart.TabIndex = 0x4e22;
            this.btnStart.Text = "开始保养";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new EventHandler(this.btnStart_Click);
            this.btnDel.Enabled = false;
            this.btnDel.Location = new Point(0x365, 0x31);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new Size(0x4b, 0x17);
            this.btnDel.TabIndex = 0x4e23;
            this.btnDel.Text = "作废保养";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new EventHandler(this.btnDel_Click);
            this.btnExit.Location = new Point(0x365, 0x88);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 0x4e25;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new Point(0x365, 0x3a);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new Size(0, 0);
            this.btnEnd.TabIndex = 0x4e24;
            this.btnEnd.Text = "结束保养";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new EventHandler(this.btnEnd_Click);
            this.groupBox2.Controls.Add(this.dataGridViewMaintainDetail);
            this.groupBox2.Location = new Point(12, 0x111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(950, 0x132);
            this.groupBox2.TabIndex = 0x7533;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保养单详细";
            this.groupBox3.Controls.Add(this.checkBoxTableMakeDate);
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateTo);
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateFrom);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label5);
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
            this.groupBox3.Location = new Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(950, 0x55);
            this.groupBox3.TabIndex = 0x7534;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "保养单列表";
            this.checkBoxTableMakeDate.AutoSize = true;
            this.checkBoxTableMakeDate.Location = new Point(0x218, 0x33);
            this.checkBoxTableMakeDate.Name = "checkBoxTableMakeDate";
            this.checkBoxTableMakeDate.Size = new Size(15, 14);
            this.checkBoxTableMakeDate.TabIndex = 0x4e33;
            this.checkBoxTableMakeDate.UseVisualStyleBackColor = true;
            this.checkBoxTableMakeDate.CheckedChanged += new EventHandler(this.checkBoxTableMakeDate_CheckedChanged);
            this.dateTimePickerTableMakeDateTo.Enabled = false;
            this.dateTimePickerTableMakeDateTo.Location = new Point(0x19d, 0x30);
            this.dateTimePickerTableMakeDateTo.Name = "dateTimePickerTableMakeDateTo";
            this.dateTimePickerTableMakeDateTo.Size = new Size(110, 0x15);
            this.dateTimePickerTableMakeDateTo.TabIndex = 0x4e32;
            this.dateTimePickerTableMakeDateFrom.Enabled = false;
            this.dateTimePickerTableMakeDateFrom.Location = new Point(0x112, 0x30);
            this.dateTimePickerTableMakeDateFrom.Name = "dateTimePickerTableMakeDateFrom";
            this.dateTimePickerTableMakeDateFrom.Size = new Size(110, 0x15);
            this.dateTimePickerTableMakeDateFrom.TabIndex = 0x4e31;
            this.label10.AutoSize = true;
            this.label10.Location = new Point(390, 0x34);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x11, 12);
            this.label10.TabIndex = 0x4e2f;
            this.label10.Text = "TO";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0xcb, 0x34);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x41, 12);
            this.label5.TabIndex = 0x4e30;
            this.label5.Text = "制单日期：";
            this.textBoxMaintainNo.Location = new Point(0x4d, 0x15);
            this.textBoxMaintainNo.Name = "textBoxMaintainNo";
            this.textBoxMaintainNo.Size = new Size(120, 0x15);
            this.textBoxMaintainNo.TabIndex = 0x4e2e;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(6, 0x19);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x41, 12);
            this.label4.TabIndex = 0x4e2d;
            this.label4.Text = "保养单号：";
            this.comboBoxState.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Items.AddRange(new object[] { "等待批准", "保养中", "保养完成", "结束保养", "作废单据", "全部" });
            this.comboBoxState.Location = new Point(0x4d, 0x30);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new Size(120, 20);
            this.comboBoxState.TabIndex = 0x4e2c;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 0x34);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x41, 12);
            this.label3.TabIndex = 0x4e2b;
            this.label3.Text = "单据状态：";
            this.comboBoxPlant.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new Point(0x112, 0x15);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new Size(120, 20);
            this.comboBoxPlant.TabIndex = 0x4e29;
            this.comboBoxPlant.SelectedIndexChanged += new EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0xcb, 0x19);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x41, 12);
            this.label7.TabIndex = 0x4e28;
            this.label7.Text = "公　　司：";
            this.comboBoxSLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new Point(0x1d7, 0x15);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new Size(120, 20);
            this.comboBoxSLocation.TabIndex = 0x4e2a;
            this.textBoxOperator.Location = new Point(0x341, 0x16);
            this.textBoxOperator.Name = "textBoxOperator";
            this.textBoxOperator.Size = new Size(100, 0x15);
            this.textBoxOperator.TabIndex = 0x4e26;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(400, 0x19);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x41, 12);
            this.label6.TabIndex = 0x4e27;
            this.label6.Text = "库存地点：";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x2fa, 0x19);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x41, 12);
            this.label2.TabIndex = 0x4e25;
            this.label2.Text = "制 单 人：";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x255, 0x19);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 12);
            this.label1.TabIndex = 0x4e23;
            this.label1.Text = "保管员：";
            this.textBoxStoreMan.Location = new Point(0x290, 0x15);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.Size = new Size(100, 0x15);
            this.textBoxStoreMan.TabIndex = 0x4e24;
            this.btnSelect.Location = new Point(0x35a, 0x2e);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new Size(0x4b, 0x17);
            this.btnSelect.TabIndex = 0x4e22;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
            this.textBoxMaintain.Enabled = false;
            this.textBoxMaintain.Location = new Point(0x69, 0x249);
            this.textBoxMaintain.Name = "textBoxMaintain";
            this.textBoxMaintain.Size = new Size(80, 0x15);
            this.textBoxMaintain.TabIndex = 0x7536;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(10, 0x24c);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x59, 12);
            this.label8.TabIndex = 0x7537;
            this.label8.Text = "修改已保养数量";
            this.btnModNum.Enabled = false;
            this.btnModNum.Location = new Point(0xbf, 0x247);
            this.btnModNum.Name = "btnModNum";
            this.btnModNum.Size = new Size(0x4b, 0x17);
            this.btnModNum.TabIndex = 0x7538;
            this.btnModNum.Text = "修改";
            this.btnModNum.UseVisualStyleBackColor = true;
            this.btnModNum.Click += new EventHandler(this.btnModNum_Click);
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new Point(0x110, 0x247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 0x7539;
            this.btnCancel.Text = "取消修改";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnSubmitMod.Enabled = false;
            this.btnSubmitMod.Location = new Point(0x161, 0x247);
            this.btnSubmitMod.Name = "btnSubmitMod";
            this.btnSubmitMod.Size = new Size(100, 0x17);
            this.btnSubmitMod.TabIndex = 0x753a;
            this.btnSubmitMod.Text = "提交重新保养";
            this.btnSubmitMod.UseVisualStyleBackColor = true;
            this.btnSubmitMod.Click += new EventHandler(this.btnSubmitMod_Click);
            //base.AutoScaleDimensions = new SizeF(6f, 12f);
            //base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3ce, 0x26a);
            base.ControlBox = false;
            base.Controls.Add(this.btnSubmitMod);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnModNum);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.textBoxMaintain);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            //base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "管理保养单";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "管理保养单";
            ((ISupportInitialize)this.dataGridViewMaintain).EndInit();
            ((ISupportInitialize)this.dataGridViewMaintainDetail).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        // Methods
        public 管理保养单(UserInfo userItem, ArrayList userRoles)
        {
            this.userItem = null;
            this.userRoles = null;
            this.dtPlantList = null;
            this.dtStoreLocusList = null;
            this.dtReport = null;
            this.components = null;
            this.InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
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
            if (this.checkBoxTableMakeDate.Checked)
            {
                arriveList.Add(this.dateTimePickerTableMakeDateFrom.Value.Date.ToString());
                arriveList.Add(this.dateTimePickerTableMakeDateTo.Value.Date.ToString());
            }
            else
            {
                arriveList.Add(string.Empty);
                arriveList.Add(string.Empty);
            }
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

        private void checkBoxTableMakeDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePickerTableMakeDateFrom.Enabled = this.dateTimePickerTableMakeDateTo.Enabled = this.checkBoxTableMakeDate.Checked;
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
            this.dtReport.Columns.Add("货位");
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
