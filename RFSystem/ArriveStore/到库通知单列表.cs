using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace RFSystem.ArriveStore
{
    public partial class 到库通知单列表 : Form
    {
        // Fields
        private DataTable ArriveGoodsInfo;
        private Button btnComplete;
        private Button btnDeal;
        private Button btnDel;
        private Button btnExit;
        private Button btnMod;
        private Button btnSelect;
        private Button btnSignBack;
        private Button btnSignIn;
        private Button btnSplit;
        private Button btnUnite;
        private CheckBox checkBoxSignInDate;
        private CheckBox checkBoxTableMakeDate;
        private DataGridViewTextBoxColumn ColumnAcceptAmount;
        private DataGridViewTextBoxColumn ColumnArriveListDealState;
        private DataGridViewTextBoxColumn ColumnArriveListID;
        private DataGridViewTextBoxColumn ColumnConsigner;
        private DataGridViewTextBoxColumn ColumnDealAmount;
        private DataGridViewTextBoxColumn ColumnEquipmentName;
        private DataGridViewTextBoxColumn ColumnKeeper;
        private DataGridViewTextBoxColumn ColumnSignDate;
        private DataGridViewTextBoxColumn ColumnSignInManID;
        private DataGridViewTextBoxColumn ColumnTableMakeDate;
        private DataGridViewTextBoxColumn ColumnTableMaker;
        private ComboBox comboBoxArriveListDealState;
        private ComboBox comboBoxBankrollKinds;
        private ComboBox comboBoxConveyanceMode;
        private ComboBox comboBoxPackagingKinds;
        private ComboBox comboBoxQuantityUnits;
        private DataGridView dataGridViewArriveGoodsInfo;
        private DateTimePicker dateTimePickerSignInDateFrom;
        private DateTimePicker dateTimePickerSignInDateTo;
        private DateTimePicker dateTimePickerTableMakeDateFrom;
        private DateTimePicker dateTimePickerTableMakeDateTo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label25;
        private Label label27;
        private Label label28;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label9;
        private TextBox textBoxAcceptWeight;
        private TextBox textBoxArriveListID;
        private TextBox textBoxBargainID;
        private TextBox textBoxBargainMakerID;
        private TextBox textBoxConsigner;
        private TextBox textBoxConsignmentAmount;
        private TextBox textBoxConsignmentBillID;
        private TextBox textBoxConsignmentStation;
        private TextBox textBoxConveyanceID;
        private TextBox textBoxEquipmentName;
        private TextBox textBoxKeeper;
        private TextBox textBoxKeepPlace;
        private TextBox textBoxProjectID;
        private TextBox textBoxProvider;
        private TextBox textBoxRemark;
        private TextBox textBoxTableMaker;
        private TextBox textBoxVehicleNO;
        private UserInfo userItem;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewArriveGoodsInfo = new System.Windows.Forms.DataGridView();
            this.ColumnArriveListID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConsigner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAcceptAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDealAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeeper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArriveListDealState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTableMaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTableMakeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSignInManID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSignDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxArriveListDealState = new System.Windows.Forms.ComboBox();
            this.checkBoxTableMakeDate = new System.Windows.Forms.CheckBox();
            this.checkBoxSignInDate = new System.Windows.Forms.CheckBox();
            this.dateTimePickerSignInDateTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerSignInDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTableMakeDateTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTableMakeDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxTableMaker = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxKeeper = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxConsigner = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEquipmentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxArriveListID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxBankrollKinds = new System.Windows.Forms.ComboBox();
            this.comboBoxConveyanceMode = new System.Windows.Forms.ComboBox();
            this.comboBoxPackagingKinds = new System.Windows.Forms.ComboBox();
            this.comboBoxQuantityUnits = new System.Windows.Forms.ComboBox();
            this.textBoxKeepPlace = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBoxProvider = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBoxProjectID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxVehicleNO = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxConveyanceID = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxAcceptWeight = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxConsignmentBillID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxConsignmentAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxConsignmentStation = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxBargainMakerID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxBargainID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSignBack = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnDeal = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnUnite = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArriveGoodsInfo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewArriveGoodsInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1068, 234);
            this.groupBox1.TabIndex = 980;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "货物列表";
            // 
            // dataGridViewArriveGoodsInfo
            // 
            this.dataGridViewArriveGoodsInfo.AllowUserToAddRows = false;
            this.dataGridViewArriveGoodsInfo.AllowUserToResizeRows = false;
            this.dataGridViewArriveGoodsInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewArriveGoodsInfo.ColumnHeadersHeight = 30;
            this.dataGridViewArriveGoodsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewArriveGoodsInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnArriveListID,
            this.ColumnEquipmentName,
            this.ColumnConsigner,
            this.ColumnAcceptAmount,
            this.ColumnDealAmount,
            this.ColumnKeeper,
            this.ColumnArriveListDealState,
            this.ColumnTableMaker,
            this.ColumnTableMakeDate,
            this.ColumnSignInManID,
            this.ColumnSignDate});
            this.dataGridViewArriveGoodsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewArriveGoodsInfo.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewArriveGoodsInfo.MultiSelect = false;
            this.dataGridViewArriveGoodsInfo.Name = "dataGridViewArriveGoodsInfo";
            this.dataGridViewArriveGoodsInfo.ReadOnly = true;
            this.dataGridViewArriveGoodsInfo.RowHeadersVisible = false;
            this.dataGridViewArriveGoodsInfo.RowTemplate.Height = 23;
            this.dataGridViewArriveGoodsInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArriveGoodsInfo.Size = new System.Drawing.Size(1062, 209);
            this.dataGridViewArriveGoodsInfo.TabIndex = 990;
            this.dataGridViewArriveGoodsInfo.SelectionChanged += new System.EventHandler(this.dataGridViewArriveGoodsInfo_SelectionChanged);
            // 
            // ColumnArriveListID
            // 
            this.ColumnArriveListID.DataPropertyName = "ArriveListID";
            this.ColumnArriveListID.HeaderText = "到库单号";
            this.ColumnArriveListID.Name = "ColumnArriveListID";
            this.ColumnArriveListID.ReadOnly = true;
            this.ColumnArriveListID.Width = 90;
            // 
            // ColumnEquipmentName
            // 
            this.ColumnEquipmentName.DataPropertyName = "EquipmentName";
            this.ColumnEquipmentName.HeaderText = "设备名称及规格型号";
            this.ColumnEquipmentName.Name = "ColumnEquipmentName";
            this.ColumnEquipmentName.ReadOnly = true;
            this.ColumnEquipmentName.Width = 160;
            // 
            // ColumnConsigner
            // 
            this.ColumnConsigner.DataPropertyName = "Consigner";
            this.ColumnConsigner.HeaderText = "发货人";
            this.ColumnConsigner.Name = "ColumnConsigner";
            this.ColumnConsigner.ReadOnly = true;
            this.ColumnConsigner.Width = 76;
            // 
            // ColumnAcceptAmount
            // 
            this.ColumnAcceptAmount.DataPropertyName = "AcceptAmount";
            this.ColumnAcceptAmount.HeaderText = "实收件数";
            this.ColumnAcceptAmount.Name = "ColumnAcceptAmount";
            this.ColumnAcceptAmount.ReadOnly = true;
            this.ColumnAcceptAmount.Width = 90;
            // 
            // ColumnDealAmount
            // 
            this.ColumnDealAmount.DataPropertyName = "DealAmount";
            this.ColumnDealAmount.HeaderText = "处理件数";
            this.ColumnDealAmount.Name = "ColumnDealAmount";
            this.ColumnDealAmount.ReadOnly = true;
            this.ColumnDealAmount.Width = 90;
            // 
            // ColumnKeeper
            // 
            this.ColumnKeeper.DataPropertyName = "KeeperID";
            this.ColumnKeeper.HeaderText = "保管员";
            this.ColumnKeeper.Name = "ColumnKeeper";
            this.ColumnKeeper.ReadOnly = true;
            this.ColumnKeeper.Width = 76;
            // 
            // ColumnArriveListDealState
            // 
            this.ColumnArriveListDealState.DataPropertyName = "ArriveListDealState";
            this.ColumnArriveListDealState.HeaderText = "处理状态";
            this.ColumnArriveListDealState.Name = "ColumnArriveListDealState";
            this.ColumnArriveListDealState.ReadOnly = true;
            this.ColumnArriveListDealState.Width = 90;
            // 
            // ColumnTableMaker
            // 
            this.ColumnTableMaker.DataPropertyName = "TableMakerID";
            this.ColumnTableMaker.HeaderText = "制表员";
            this.ColumnTableMaker.Name = "ColumnTableMaker";
            this.ColumnTableMaker.ReadOnly = true;
            this.ColumnTableMaker.Width = 76;
            // 
            // ColumnTableMakeDate
            // 
            this.ColumnTableMakeDate.DataPropertyName = "TableMakeDate";
            this.ColumnTableMakeDate.HeaderText = "制表日期";
            this.ColumnTableMakeDate.Name = "ColumnTableMakeDate";
            this.ColumnTableMakeDate.ReadOnly = true;
            this.ColumnTableMakeDate.Width = 90;
            // 
            // ColumnSignInManID
            // 
            this.ColumnSignInManID.DataPropertyName = "SignInManID";
            this.ColumnSignInManID.HeaderText = "签收人";
            this.ColumnSignInManID.Name = "ColumnSignInManID";
            this.ColumnSignInManID.ReadOnly = true;
            this.ColumnSignInManID.Width = 76;
            // 
            // ColumnSignDate
            // 
            this.ColumnSignDate.DataPropertyName = "SignDate";
            this.ColumnSignDate.HeaderText = "签收日期";
            this.ColumnSignDate.Name = "ColumnSignDate";
            this.ColumnSignDate.ReadOnly = true;
            this.ColumnSignDate.Width = 90;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.comboBoxArriveListDealState);
            this.groupBox3.Controls.Add(this.checkBoxTableMakeDate);
            this.groupBox3.Controls.Add(this.checkBoxSignInDate);
            this.groupBox3.Controls.Add(this.dateTimePickerSignInDateTo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dateTimePickerSignInDateFrom);
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateTo);
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateFrom);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnSelect);
            this.groupBox3.Controls.Add(this.textBoxTableMaker);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxKeeper);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxConsigner);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxEquipmentName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxArriveListID);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1068, 171);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // comboBoxArriveListDealState
            // 
            this.comboBoxArriveListDealState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArriveListDealState.FormattingEnabled = true;
            this.comboBoxArriveListDealState.Location = new System.Drawing.Point(497, 55);
            this.comboBoxArriveListDealState.Name = "comboBoxArriveListDealState";
            this.comboBoxArriveListDealState.Size = new System.Drawing.Size(104, 28);
            this.comboBoxArriveListDealState.TabIndex = 50;
            this.comboBoxArriveListDealState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // checkBoxTableMakeDate
            // 
            this.checkBoxTableMakeDate.AutoSize = true;
            this.checkBoxTableMakeDate.Location = new System.Drawing.Point(26, 104);
            this.checkBoxTableMakeDate.Name = "checkBoxTableMakeDate";
            this.checkBoxTableMakeDate.Size = new System.Drawing.Size(98, 24);
            this.checkBoxTableMakeDate.TabIndex = 90;
            this.checkBoxTableMakeDate.Text = "制表日期：";
            this.checkBoxTableMakeDate.UseVisualStyleBackColor = true;
            this.checkBoxTableMakeDate.CheckedChanged += new System.EventHandler(this.checkBoxTableMakeDate_CheckedChanged);
            this.checkBoxTableMakeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // checkBoxSignInDate
            // 
            this.checkBoxSignInDate.AutoSize = true;
            this.checkBoxSignInDate.Location = new System.Drawing.Point(26, 134);
            this.checkBoxSignInDate.Name = "checkBoxSignInDate";
            this.checkBoxSignInDate.Size = new System.Drawing.Size(98, 24);
            this.checkBoxSignInDate.TabIndex = 120;
            this.checkBoxSignInDate.Text = "签收日期：";
            this.checkBoxSignInDate.UseVisualStyleBackColor = true;
            this.checkBoxSignInDate.CheckedChanged += new System.EventHandler(this.checkBoxSignInDate_CheckedChanged);
            this.checkBoxSignInDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dateTimePickerSignInDateTo
            // 
            this.dateTimePickerSignInDateTo.Enabled = false;
            this.dateTimePickerSignInDateTo.Location = new System.Drawing.Point(320, 132);
            this.dateTimePickerSignInDateTo.Name = "dateTimePickerSignInDateTo";
            this.dateTimePickerSignInDateTo.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerSignInDateTo.TabIndex = 110;
            this.dateTimePickerSignInDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "处理状态：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(286, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "TO";
            // 
            // dateTimePickerSignInDateFrom
            // 
            this.dateTimePickerSignInDateFrom.Enabled = false;
            this.dateTimePickerSignInDateFrom.Location = new System.Drawing.Point(130, 132);
            this.dateTimePickerSignInDateFrom.Name = "dateTimePickerSignInDateFrom";
            this.dateTimePickerSignInDateFrom.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerSignInDateFrom.TabIndex = 100;
            this.dateTimePickerSignInDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dateTimePickerTableMakeDateTo
            // 
            this.dateTimePickerTableMakeDateTo.Enabled = false;
            this.dateTimePickerTableMakeDateTo.Location = new System.Drawing.Point(320, 100);
            this.dateTimePickerTableMakeDateTo.Name = "dateTimePickerTableMakeDateTo";
            this.dateTimePickerTableMakeDateTo.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerTableMakeDateTo.TabIndex = 80;
            this.dateTimePickerTableMakeDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dateTimePickerTableMakeDateFrom
            // 
            this.dateTimePickerTableMakeDateFrom.Enabled = false;
            this.dateTimePickerTableMakeDateFrom.Location = new System.Drawing.Point(130, 100);
            this.dateTimePickerTableMakeDateFrom.Name = "dateTimePickerTableMakeDateFrom";
            this.dateTimePickerTableMakeDateFrom.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerTableMakeDateFrom.TabIndex = 70;
            this.dateTimePickerTableMakeDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "TO";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(913, 55);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 130;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxTableMaker
            // 
            this.textBoxTableMaker.Location = new System.Drawing.Point(95, 57);
            this.textBoxTableMaker.Name = "textBoxTableMaker";
            this.textBoxTableMaker.Size = new System.Drawing.Size(100, 26);
            this.textBoxTableMaker.TabIndex = 60;
            this.textBoxTableMaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "制表员码：";
            // 
            // textBoxKeeper
            // 
            this.textBoxKeeper.Location = new System.Drawing.Point(497, 25);
            this.textBoxKeeper.Name = "textBoxKeeper";
            this.textBoxKeeper.Size = new System.Drawing.Size(104, 26);
            this.textBoxKeeper.TabIndex = 40;
            this.textBoxKeeper.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(418, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "保 管 员：";
            // 
            // textBoxConsigner
            // 
            this.textBoxConsigner.Location = new System.Drawing.Point(286, 57);
            this.textBoxConsigner.Name = "textBoxConsigner";
            this.textBoxConsigner.Size = new System.Drawing.Size(120, 26);
            this.textBoxConsigner.TabIndex = 30;
            this.textBoxConsigner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "发 货 人：";
            // 
            // textBoxEquipmentName
            // 
            this.textBoxEquipmentName.Location = new System.Drawing.Point(286, 25);
            this.textBoxEquipmentName.Name = "textBoxEquipmentName";
            this.textBoxEquipmentName.Size = new System.Drawing.Size(120, 26);
            this.textBoxEquipmentName.TabIndex = 20;
            this.textBoxEquipmentName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "名称规格：";
            // 
            // textBoxArriveListID
            // 
            this.textBoxArriveListID.Location = new System.Drawing.Point(95, 25);
            this.textBoxArriveListID.Name = "textBoxArriveListID";
            this.textBoxArriveListID.Size = new System.Drawing.Size(100, 26);
            this.textBoxArriveListID.TabIndex = 10;
            this.textBoxArriveListID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "到库单号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBoxBankrollKinds);
            this.groupBox2.Controls.Add(this.comboBoxConveyanceMode);
            this.groupBox2.Controls.Add(this.comboBoxPackagingKinds);
            this.groupBox2.Controls.Add(this.comboBoxQuantityUnits);
            this.groupBox2.Controls.Add(this.textBoxKeepPlace);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.textBoxProvider);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.textBoxRemark);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.textBoxProjectID);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.textBoxVehicleNO);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.textBoxConveyanceID);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBoxAcceptWeight);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.textBoxConsignmentBillID);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBoxConsignmentAmount);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBoxConsignmentStation);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.textBoxBargainMakerID);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBoxBargainID);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 429);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1068, 159);
            this.groupBox2.TabIndex = 995;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计信息";
            // 
            // comboBoxBankrollKinds
            // 
            this.comboBoxBankrollKinds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxBankrollKinds.Enabled = false;
            this.comboBoxBankrollKinds.FormattingEnabled = true;
            this.comboBoxBankrollKinds.Location = new System.Drawing.Point(509, 89);
            this.comboBoxBankrollKinds.Name = "comboBoxBankrollKinds";
            this.comboBoxBankrollKinds.Size = new System.Drawing.Size(92, 26);
            this.comboBoxBankrollKinds.TabIndex = 620;
            // 
            // comboBoxConveyanceMode
            // 
            this.comboBoxConveyanceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxConveyanceMode.Enabled = false;
            this.comboBoxConveyanceMode.FormattingEnabled = true;
            this.comboBoxConveyanceMode.Location = new System.Drawing.Point(326, 89);
            this.comboBoxConveyanceMode.Name = "comboBoxConveyanceMode";
            this.comboBoxConveyanceMode.Size = new System.Drawing.Size(92, 26);
            this.comboBoxConveyanceMode.TabIndex = 610;
            // 
            // comboBoxPackagingKinds
            // 
            this.comboBoxPackagingKinds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxPackagingKinds.Enabled = false;
            this.comboBoxPackagingKinds.FormattingEnabled = true;
            this.comboBoxPackagingKinds.Location = new System.Drawing.Point(143, 89);
            this.comboBoxPackagingKinds.Name = "comboBoxPackagingKinds";
            this.comboBoxPackagingKinds.Size = new System.Drawing.Size(92, 26);
            this.comboBoxPackagingKinds.TabIndex = 600;
            // 
            // comboBoxQuantityUnits
            // 
            this.comboBoxQuantityUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxQuantityUnits.Enabled = false;
            this.comboBoxQuantityUnits.FormattingEnabled = true;
            this.comboBoxQuantityUnits.Location = new System.Drawing.Point(872, 57);
            this.comboBoxQuantityUnits.Name = "comboBoxQuantityUnits";
            this.comboBoxQuantityUnits.Size = new System.Drawing.Size(91, 26);
            this.comboBoxQuantityUnits.TabIndex = 590;
            // 
            // textBoxKeepPlace
            // 
            this.textBoxKeepPlace.ForeColor = System.Drawing.Color.Red;
            this.textBoxKeepPlace.Location = new System.Drawing.Point(872, 121);
            this.textBoxKeepPlace.Name = "textBoxKeepPlace";
            this.textBoxKeepPlace.ReadOnly = true;
            this.textBoxKeepPlace.Size = new System.Drawing.Size(91, 26);
            this.textBoxKeepPlace.TabIndex = 660;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(787, 124);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 20);
            this.label25.TabIndex = 0;
            this.label25.Text = "存放位置：";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxProvider
            // 
            this.textBoxProvider.ForeColor = System.Drawing.Color.Red;
            this.textBoxProvider.Location = new System.Drawing.Point(143, 121);
            this.textBoxProvider.Name = "textBoxProvider";
            this.textBoxProvider.ReadOnly = true;
            this.textBoxProvider.Size = new System.Drawing.Size(275, 26);
            this.textBoxProvider.TabIndex = 640;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(58, 124);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(79, 20);
            this.label28.TabIndex = 0;
            this.label28.Text = "供货单位：";
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.ForeColor = System.Drawing.Color.Red;
            this.textBoxRemark.Location = new System.Drawing.Point(509, 121);
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.ReadOnly = true;
            this.textBoxRemark.Size = new System.Drawing.Size(271, 26);
            this.textBoxRemark.TabIndex = 650;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(424, 124);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "备　　注：";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(424, 92);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(79, 20);
            this.label27.TabIndex = 0;
            this.label27.Text = "资金类别：";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxProjectID
            // 
            this.textBoxProjectID.ForeColor = System.Drawing.Color.Red;
            this.textBoxProjectID.Location = new System.Drawing.Point(690, 89);
            this.textBoxProjectID.Name = "textBoxProjectID";
            this.textBoxProjectID.ReadOnly = true;
            this.textBoxProjectID.Size = new System.Drawing.Size(273, 26);
            this.textBoxProjectID.TabIndex = 630;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(605, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "工程编号：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(241, 92);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "运输方式：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(58, 92);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "包装种类：";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(787, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "数量单位：";
            // 
            // textBoxVehicleNO
            // 
            this.textBoxVehicleNO.ForeColor = System.Drawing.Color.Red;
            this.textBoxVehicleNO.Location = new System.Drawing.Point(690, 57);
            this.textBoxVehicleNO.Name = "textBoxVehicleNO";
            this.textBoxVehicleNO.ReadOnly = true;
            this.textBoxVehicleNO.Size = new System.Drawing.Size(91, 26);
            this.textBoxVehicleNO.TabIndex = 580;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(605, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "车　　号：";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxConveyanceID
            // 
            this.textBoxConveyanceID.ForeColor = System.Drawing.Color.Red;
            this.textBoxConveyanceID.Location = new System.Drawing.Point(509, 57);
            this.textBoxConveyanceID.Name = "textBoxConveyanceID";
            this.textBoxConveyanceID.ReadOnly = true;
            this.textBoxConveyanceID.Size = new System.Drawing.Size(91, 26);
            this.textBoxConveyanceID.TabIndex = 570;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(430, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "运 输 号：";
            // 
            // textBoxAcceptWeight
            // 
            this.textBoxAcceptWeight.ForeColor = System.Drawing.Color.Red;
            this.textBoxAcceptWeight.Location = new System.Drawing.Point(872, 25);
            this.textBoxAcceptWeight.Name = "textBoxAcceptWeight";
            this.textBoxAcceptWeight.ReadOnly = true;
            this.textBoxAcceptWeight.Size = new System.Drawing.Size(91, 26);
            this.textBoxAcceptWeight.TabIndex = 540;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(787, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "实收重量：";
            // 
            // textBoxConsignmentBillID
            // 
            this.textBoxConsignmentBillID.ForeColor = System.Drawing.Color.Red;
            this.textBoxConsignmentBillID.Location = new System.Drawing.Point(327, 57);
            this.textBoxConsignmentBillID.Name = "textBoxConsignmentBillID";
            this.textBoxConsignmentBillID.ReadOnly = true;
            this.textBoxConsignmentBillID.Size = new System.Drawing.Size(91, 26);
            this.textBoxConsignmentBillID.TabIndex = 560;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(248, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "运 单 号：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxConsignmentAmount
            // 
            this.textBoxConsignmentAmount.ForeColor = System.Drawing.Color.Red;
            this.textBoxConsignmentAmount.Location = new System.Drawing.Point(143, 57);
            this.textBoxConsignmentAmount.Name = "textBoxConsignmentAmount";
            this.textBoxConsignmentAmount.ReadOnly = true;
            this.textBoxConsignmentAmount.Size = new System.Drawing.Size(91, 26);
            this.textBoxConsignmentAmount.TabIndex = 550;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(58, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "运单件数：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxConsignmentStation
            // 
            this.textBoxConsignmentStation.ForeColor = System.Drawing.Color.Red;
            this.textBoxConsignmentStation.Location = new System.Drawing.Point(509, 25);
            this.textBoxConsignmentStation.Name = "textBoxConsignmentStation";
            this.textBoxConsignmentStation.ReadOnly = true;
            this.textBoxConsignmentStation.Size = new System.Drawing.Size(272, 26);
            this.textBoxConsignmentStation.TabIndex = 530;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(424, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "发　　站：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxBargainMakerID
            // 
            this.textBoxBargainMakerID.ForeColor = System.Drawing.Color.Red;
            this.textBoxBargainMakerID.Location = new System.Drawing.Point(327, 25);
            this.textBoxBargainMakerID.Name = "textBoxBargainMakerID";
            this.textBoxBargainMakerID.ReadOnly = true;
            this.textBoxBargainMakerID.Size = new System.Drawing.Size(91, 26);
            this.textBoxBargainMakerID.TabIndex = 520;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "合同员码：";
            // 
            // textBoxBargainID
            // 
            this.textBoxBargainID.ForeColor = System.Drawing.Color.Red;
            this.textBoxBargainID.Location = new System.Drawing.Point(143, 25);
            this.textBoxBargainID.Name = "textBoxBargainID";
            this.textBoxBargainID.ReadOnly = true;
            this.textBoxBargainID.Size = new System.Drawing.Size(91, 26);
            this.textBoxBargainID.TabIndex = 510;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "合 同 号：";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(980, 594);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 1080;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSignBack
            // 
            this.btnSignBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignBack.Enabled = false;
            this.btnSignBack.Location = new System.Drawing.Point(768, 594);
            this.btnSignBack.Name = "btnSignBack";
            this.btnSignBack.Size = new System.Drawing.Size(100, 40);
            this.btnSignBack.TabIndex = 1060;
            this.btnSignBack.Text = "退签收";
            this.btnSignBack.UseVisualStyleBackColor = true;
            this.btnSignBack.Click += new System.EventHandler(this.btnSignBack_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignIn.Enabled = false;
            this.btnSignIn.Location = new System.Drawing.Point(662, 594);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(100, 40);
            this.btnSignIn.TabIndex = 1050;
            this.btnSignIn.Text = "签收";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(118, 594);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 40);
            this.btnDel.TabIndex = 1010;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(12, 594);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 1000;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnDeal
            // 
            this.btnDeal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeal.Enabled = false;
            this.btnDeal.Location = new System.Drawing.Point(556, 594);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(100, 40);
            this.btnDeal.TabIndex = 1040;
            this.btnDeal.Text = "处理";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplete.Enabled = false;
            this.btnComplete.Location = new System.Drawing.Point(874, 594);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(100, 40);
            this.btnComplete.TabIndex = 1070;
            this.btnComplete.Text = "完成";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnUnite
            // 
            this.btnUnite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnite.Enabled = false;
            this.btnUnite.Location = new System.Drawing.Point(224, 594);
            this.btnUnite.Name = "btnUnite";
            this.btnUnite.Size = new System.Drawing.Size(100, 40);
            this.btnUnite.TabIndex = 1020;
            this.btnUnite.Text = "合并";
            this.btnUnite.UseVisualStyleBackColor = true;
            this.btnUnite.Click += new System.EventHandler(this.btnUnite_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSplit.Enabled = false;
            this.btnSplit.Location = new System.Drawing.Point(330, 594);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(100, 40);
            this.btnSplit.TabIndex = 1030;
            this.btnSplit.Text = "拆分";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // 到库通知单列表
            // 
            this.ClientSize = new System.Drawing.Size(1092, 646);
            this.ControlBox = false;
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.btnUnite);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.btnSignBack);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "到库通知单列表";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "到库通知单列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.到库通知单列表_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArriveGoodsInfo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        // Methods
        public 到库通知单列表(UserInfo userItem, ArrayList userRoles)
        {
            this.ArriveGoodsInfo = null;
            this.userItem = null;
            this.InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.InitializeFormControls();
            if (!this.userItem.isAdmin)
            {
                if (this.userRoles.Contains("MakeArriveStoreRequisition"))
                {
                    this.textBoxTableMaker.Text = this.userItem.userID;
                    this.textBoxTableMaker.ReadOnly = true;
                }
                else
                {
                    this.textBoxKeeper.Text = this.userItem.userID;
                    this.textBoxKeeper.ReadOnly = true;
                }
            }
            this.dataGridViewArriveGoodsInfo.AutoGenerateColumns = false;
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            ArrayList dealInfo = new ArrayList();
            dealInfo.Add((string)this.dataGridViewArriveGoodsInfo.SelectedRows[0].Cells["ColumnArriveListID"].Value);
            dealInfo.Add(2);
            dealInfo.Add(string.Empty);
            dealInfo.Add(string.Empty);
            dealInfo.Add(this.userItem.userID);
            dealInfo.Add(DateTime.Now);
            if (DBOperate.ModArriveStoreDeal(dealInfo) != -1)
            {
                this.btnSelect.PerformClick();
            }
            else
            {
                CommonFunction.Sys_MsgBox("信息处理失败，请联系管理员");
            }
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridViewArriveGoodsInfo.SelectedRows[0];
            到库货物处理 到库货物处理 = new 到库货物处理(row.Cells["ColumnArriveListID"].Value.ToString(), row.Cells["ColumnEquipmentName"].Value.ToString(), row.Cells["ColumnAcceptAmount"].Value.ToString(), row.Cells["ColumnDealAmount"].Value.ToString());
            if (到库货物处理.ShowDialog() == DialogResult.OK)
            {
                this.btnSelect.PerformClick();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否删除选择条目？"))
            {
                if (DBOperate.DelBill(dataGridViewArriveGoodsInfo.SelectedRows[0].Cells["ColumnArriveListID"].Value.ToString()) != -1)
                {
                    btnSelect.PerformClick();
                }
                else
                {
                    CommonFunction.Sys_MsgBox("信息处理失败，请联系管理员");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            DataRow row = this.ArriveGoodsInfo.Select("ArriveListID='" + this.dataGridViewArriveGoodsInfo.SelectedRows[0].Cells["ColumnArriveListID"].Value.ToString() + "'")[0];
            ArrayList arriveListInfo = new ArrayList();
            for (int i = 0; i < 0x19; i++)
            {
                arriveListInfo.Add(row[i]);
            }
            到库通知单修改 到库通知单修改 = new 到库通知单修改(arriveListInfo);
            if (到库通知单修改.ShowDialog() == DialogResult.OK)
            {
                this.btnSelect.PerformClick();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ArrayList goodsInfo = new ArrayList();
            goodsInfo.Add(this.textBoxArriveListID.Text);
            goodsInfo.Add(this.textBoxEquipmentName.Text);
            goodsInfo.Add(this.textBoxConsigner.Text);
            goodsInfo.Add(this.textBoxKeeper.Text);
            goodsInfo.Add(this.textBoxTableMaker.Text);
            goodsInfo.Add((this.comboBoxArriveListDealState.SelectedIndex == 3) ? -1 : this.comboBoxArriveListDealState.SelectedIndex);
            if (this.checkBoxTableMakeDate.Checked)
            {
                goodsInfo.Add(this.dateTimePickerTableMakeDateFrom.Value.ToShortDateString());
                goodsInfo.Add(this.dateTimePickerTableMakeDateTo.Value.ToShortDateString());
            }
            else
            {
                goodsInfo.Add(string.Empty);
                goodsInfo.Add(string.Empty);
            }
            if (this.checkBoxSignInDate.Checked)
            {
                goodsInfo.Add(this.dateTimePickerSignInDateFrom.Value.ToShortDateString());
                goodsInfo.Add(this.dateTimePickerSignInDateTo.Value.ToShortDateString());
            }
            else
            {
                goodsInfo.Add(string.Empty);
                goodsInfo.Add(string.Empty);
            }
            this.ArriveGoodsInfo = DBOperate.SelectArriveStoreInfo(goodsInfo);
            this.dataGridViewArriveGoodsInfo.DataSource = this.ArriveGoodsInfo;
        }

        private void btnSignBack_Click(object sender, EventArgs e)
        {
            ArrayList dealInfo = new ArrayList();
            dealInfo.Add((string)this.dataGridViewArriveGoodsInfo.SelectedRows[0].Cells["ColumnArriveListID"].Value);
            dealInfo.Add(0);
            dealInfo.Add(string.Empty);
            dealInfo.Add(string.Empty);
            dealInfo.Add(this.userItem.userID);
            dealInfo.Add(DateTime.Now);
            if (DBOperate.ModArriveStoreDeal(dealInfo) != -1)
            {
                this.btnSelect.PerformClick();
            }
            else
            {
                CommonFunction.Sys_MsgBox("信息处理失败，请联系管理员");
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            ArrayList dealInfo = new ArrayList();
            dealInfo.Add((string)this.dataGridViewArriveGoodsInfo.SelectedRows[0].Cells["ColumnArriveListID"].Value);
            dealInfo.Add(1);
            dealInfo.Add(this.userItem.userID);
            dealInfo.Add(DateTime.Now);
            dealInfo.Add(string.Empty);
            dealInfo.Add(string.Empty);
            if (DBOperate.ModArriveStoreDeal(dealInfo) != -1)
            {
                this.btnSelect.PerformClick();
            }
            else
            {
                CommonFunction.Sys_MsgBox("信息处理失败，请联系管理员");
            }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            DataRow row = this.ArriveGoodsInfo.Select("ArriveListID='" + this.dataGridViewArriveGoodsInfo.SelectedRows[0].Cells["ColumnArriveListID"].Value.ToString() + "'")[0];
            ArrayList arriveListInfo = new ArrayList();
            arriveListInfo.Add(row["ArriveListID"]);
            arriveListInfo.Add(row["ConsignmentAmount"]);
            arriveListInfo.Add(row["AcceptAmount"]);
            arriveListInfo.Add(row["AcceptWeight"]);
            arriveListInfo.Add(Convert.ToString((decimal)(Convert.ToDecimal(row["AcceptAmount"]) - Convert.ToDecimal(row["DealAmount"]))));
            到库货物信息拆分 到库货物信息拆分 = new 到库货物信息拆分(arriveListInfo);
            if (到库货物信息拆分.ShowDialog() == DialogResult.OK)
            {
                this.btnSelect.PerformClick();
            }
        }

        private void btnUnite_Click(object sender, EventArgs e)
        {
            DataRow row = this.ArriveGoodsInfo.Select("ArriveListID='" + this.dataGridViewArriveGoodsInfo.SelectedRows[0].Cells["ColumnArriveListID"].Value.ToString() + "'")[0];
            ArrayList arriveListInfo = new ArrayList();
            for (int i = 0; i < 0x19; i++)
            {
                arriveListInfo.Add(row[i]);
            }
            到库货物信息合并 到库货物信息合并 = new 到库货物信息合并(arriveListInfo);
            if (到库货物信息合并.ShowDialog() == DialogResult.OK)
            {
                this.btnSelect.PerformClick();
            }
        }

        private void checkBoxSignInDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePickerSignInDateFrom.Enabled = this.dateTimePickerSignInDateTo.Enabled = this.checkBoxSignInDate.Checked;
        }

        private void checkBoxTableMakeDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePickerTableMakeDateFrom.Enabled = this.dateTimePickerTableMakeDateTo.Enabled = this.checkBoxTableMakeDate.Checked;
        }

        private void dataGridViewArriveGoodsInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewArriveGoodsInfo.Rows != null) && (this.dataGridViewArriveGoodsInfo.SelectedRows.Count != 0))
            {
                DataGridViewRow dgrSelect = this.dataGridViewArriveGoodsInfo.SelectedRows[0];
                this.ShowOtherInfo(dgrSelect);
                this.DealButtons(dgrSelect);
            }
            else
            {
                foreach (Control control in base.Controls)
                {
                    if (!(!(control is Button) || control.Name.Equals("btnExit")))
                    {
                        control.Enabled = false;
                    }
                }
            }
        }

        private void DealButtons(DataGridViewRow drSelect)
        {
            string str = drSelect.Cells["ColumnArriveListDealState"].Value.ToString();
            if (str != null)
            {
                if (!(str == "待签收"))
                {
                    if (str == "签收")
                    {
                        this.SetButtonsEnable(false, false, false, false, true, false, true);
                    }
                    else if (str == "完成")
                    {
                        this.SetButtonsEnable(false, false, false, false, false, false, false);
                    }
                }
                else
                {
                    this.SetButtonsEnable(true, true, true, true, false, true, false);
                }
            }
            if (drSelect.Cells["ColumnAcceptAmount"].Value.Equals(drSelect.Cells["ColumnDealAmount"].Value) || drSelect.Cells["ColumnAcceptAmount"].Value.ToString().Equals("1"))
            {
                this.btnSplit.Enabled = false;
            }
            else
            {
                this.btnSplit.Enabled = true;
            }
            if (drSelect.Cells["ColumnArriveListDealState"].Value.ToString().Equals("签收") && drSelect.Cells["ColumnAcceptAmount"].Value.ToString().Equals(drSelect.Cells["ColumnDealAmount"].Value.ToString()))
            {
                this.btnComplete.Enabled = true;
            }
            else
            {
                this.btnComplete.Enabled = false;
            }
            if (!(!drSelect.Cells["ColumnArriveListDealState"].Value.ToString().Equals("签收") || drSelect.Cells["ColumnDealAmount"].Value.ToString().Equals("0")))
            {
                this.btnSignBack.Enabled = false;
            }
            if (drSelect.Cells["ColumnAcceptAmount"].Value.Equals(drSelect.Cells["ColumnDealAmount"].Value))
            {
                this.btnDeal.Enabled = false;
            }
        }

        private void InitializeFormControls()
        {
            this.comboBoxArriveListDealState.Items.Add("待签收");
            this.comboBoxArriveListDealState.Items.Add("签收");
            this.comboBoxArriveListDealState.Items.Add("完成");
            this.comboBoxArriveListDealState.Items.Add("全部");
            this.comboBoxQuantityUnits.Items.Add("台");
            this.comboBoxQuantityUnits.Items.Add("件");
            this.comboBoxQuantityUnits.Items.Add("箱");
            this.comboBoxQuantityUnits.Items.Add("捆");
            this.comboBoxQuantityUnits.Items.Add("磅");
            this.comboBoxQuantityUnits.Items.Add("米");
            this.comboBoxQuantityUnits.Items.Add("公斤");
            this.comboBoxQuantityUnits.Items.Add("升");
            this.comboBoxQuantityUnits.Items.Add("千件");
            this.comboBoxQuantityUnits.Items.Add("袋");
            this.comboBoxPackagingKinds.Items.Add("纸箱");
            this.comboBoxPackagingKinds.Items.Add("木箱");
            this.comboBoxPackagingKinds.Items.Add("集装箱");
            this.comboBoxPackagingKinds.Items.Add("其它箱");
            this.comboBoxPackagingKinds.Items.Add("筐");
            this.comboBoxPackagingKinds.Items.Add("捆");
            this.comboBoxPackagingKinds.Items.Add("裸");
            this.comboBoxConveyanceMode.Items.Add("零担");
            this.comboBoxConveyanceMode.Items.Add("邮包");
            this.comboBoxConveyanceMode.Items.Add("送货");
            this.comboBoxConveyanceMode.Items.Add("整车局卸");
            this.comboBoxConveyanceMode.Items.Add("整车厂卸");
            this.comboBoxConveyanceMode.Items.Add("航空");
            this.comboBoxConveyanceMode.Items.Add("自提");
            this.comboBoxBankrollKinds.Items.Add("生产");
            this.comboBoxBankrollKinds.Items.Add("技改");
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.GetNextControl(base.ActiveControl, true).Focus();
            }
        }

        private void SetButtonsEnable(bool btnModEnable, bool btnDelEnable, bool btnUniteEnable, bool btnSplitEnable, bool btnDealEnable, bool btnSignInEnable, bool btnSignBackEnable)
        {
            this.btnMod.Enabled = btnModEnable;
            this.btnDel.Enabled = btnDelEnable;
            this.btnUnite.Enabled = btnUniteEnable;
            this.btnSplit.Enabled = btnSplitEnable;
            this.btnDeal.Enabled = btnDealEnable;
            this.btnSignIn.Enabled = btnSignInEnable;
            this.btnSignBack.Enabled = btnSignBackEnable;
        }

        private void ShowOtherInfo(DataGridViewRow dgrSelect)
        {
            DataRow row = this.ArriveGoodsInfo.Select("ArriveListID='" + dgrSelect.Cells["ColumnArriveListID"].Value.ToString() + "'")[0];
            this.textBoxBargainID.Text = row["BargainID"].ToString();
            this.textBoxBargainMakerID.Text = row["BargainMakerID"].ToString();
            this.textBoxConsignmentStation.Text = row["ConsignmentStation"].ToString();
            this.textBoxAcceptWeight.Text = row["AcceptWeight"].ToString();
            this.textBoxConsignmentAmount.Text = row["ConsignmentAmount"].ToString();
            this.textBoxConsignmentBillID.Text = row["ConsignmentBillID"].ToString();
            this.textBoxConveyanceID.Text = row["ConveyanceID"].ToString();
            this.textBoxVehicleNO.Text = row["VehicleNO"].ToString();
            this.comboBoxQuantityUnits.Text = row["QuantityUnits"].ToString();
            this.comboBoxPackagingKinds.SelectedIndex = Convert.ToInt32(row["PackagingKinds"].ToString()) - 1;
            this.comboBoxConveyanceMode.SelectedIndex = Convert.ToInt32(row["ConveyanceMode"].ToString()) - 1;
            this.comboBoxBankrollKinds.SelectedIndex = Convert.ToInt32(row["BankrollKinds"].ToString()) - 1;
            this.textBoxProjectID.Text = row["ProjectID"].ToString();
            this.textBoxProvider.Text = row["Provider"].ToString();
            this.textBoxRemark.Text = row["Remark"].ToString();
            this.textBoxKeepPlace.Text = row["KeepPlace"].ToString();
        }

        private void 到库通知单列表_Load(object sender, EventArgs e)
        {
            this.comboBoxArriveListDealState.SelectedIndex = 3;
        }
    }
}
