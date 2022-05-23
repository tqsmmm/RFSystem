using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using BL;
using System.Collections;
using RFSystem.CommonClass;

namespace RFSystem.Statistic
{
    public class 工作日志统计 : Form
    {
        #region Fields
        private Button btnExit;
        private Button btnSelect;
        private Button btnStockDelivery;
        private Button btnStockIn;
        private Button btnStockOut;
        private Button btnStockTake;
        private Button btStockOp;
        private CheckBox checkBoxEnableDate;
        private ComboBox comboBoxStock_opOpKind;
        private ComboBox comboBoxStock_opPlant;
        private ComboBox comboBoxStock_opSLocation;
        private ComboBox comboBoxStockDeliveryOpKind;
        private ComboBox comboBoxStockDeliveryPlant;
        private ComboBox comboBoxStockDeliverySLocation;
        private ComboBox comboBoxStockInOpKind;
        private ComboBox comboBoxStockInPlant;
        private ComboBox comboBoxStockInSLocation;
        private ComboBox comboBoxStockOutOpKind;
        private ComboBox comboBoxStockOutPlant;
        private ComboBox comboBoxStockOutSLocation;
        private ComboBox comboBoxStockTakePlant;
        private ComboBox comboBoxStockTakeSLocation;
        private DataGridView dataGridViewStock_op;
        private DataGridView dataGridViewStockDelivery;
        private DataGridView dataGridViewStockin;
        private DataGridView dataGridViewStockout;
        private DataGridView dataGridViewStocktake;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private DateTimePicker dateTimePickerDateFrom;
        private DateTimePicker dateTimePickerDateTo;
        private DataSet dsStatistic;
        private DataTable dtPlantList;
        private DataTable dtStoreLocusList;
        private DataView dvStock_op;
        private DataView dvStockdelivery;
        private DataView dvStockin;
        private DataView dvStockout;
        private DataView dvStocktake;
        private GroupBox groupBox1;
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
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TabControl tabControlStatistic;
        private TabPage tabPageDelivery;
        private TabPage tabPageStockIn;
        private TabPage tabPageStockOp;
        private TabPage tabPageStockOut;
        private TabPage tabPageStockTake;
        private TextBox textBoxStock_opBarcode;
        private TextBox textBoxStock_opDes;
        private TextBox textBoxStockDeliveryBarcode;
        private TextBox textBoxStockDeliveryDes;
        private TextBox textBoxStockDeliveryOrder_no;
        private TextBox textBoxStockDeliveryPzh;
        private TextBox textBoxStockDeliveryPznd;
        private TextBox textBoxStockInBarcode;
        private TextBox textBoxStockInDes;
        private TextBox textBoxStockInOrder_no;
        private TextBox textBoxStockInPzh;
        private TextBox textBoxStockInPznd;
        private TextBox textBoxStockOutBarcode;
        private TextBox textBoxStockOutDes;
        private TextBox textBoxStockOutOrder_no;
        private TextBox textBoxStockOutPzh;
        private TextBox textBoxStockOutPznd;
        private TextBox textBoxStockTakeBarcode;
        private TextBox textBoxStockTakeDes;
        private TextBox textBoxStockTakeOrder_no;
        private TextBox textBoxStoreMan;
        #endregion

        private Thread thread;
        private UserInfo userItem;
        private DataGridViewTextBoxColumn ColumnStoreman;
        private DataGridViewTextBoxColumn ColumnOperator_date;
        private DataGridViewTextBoxColumn ColumnProduct_barcode;
        private DataGridViewTextBoxColumn Column1Product_desc;
        private DataGridViewTextBoxColumn ColumnGch;
        private DataGridViewTextBoxColumn ColumnSL;
        private DataGridViewTextBoxColumn ColumnBill_type;
        private DataGridViewTextBoxColumn ColumnPty;
        private DataGridViewTextBoxColumn ColumnBin1;
        private DataGridViewTextBoxColumn ColumnBin1_qty;
        private DataGridViewTextBoxColumn ColumnBin2;
        private DataGridViewTextBoxColumn ColumnBin2_pty;
        private DataGridViewTextBoxColumn ColumnBin3;
        private DataGridViewTextBoxColumn ColumnBin3_qty;
        private DataGridViewTextBoxColumn ColumnRemark;
        private DataGridViewTextBoxColumn ColumnYWTM;
        private DataGridViewTextBoxColumn ColumnOrder_no;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn ColumnPzh;
        private DataGridViewTextBoxColumn ColumnPznd;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private DataGridViewTextBoxColumn ColumnSTSerial;
        private DataGridViewTextBoxColumn ColumnPlant;
        private DataGridViewTextBoxColumn ColumnSLocation;
        private DataGridViewTextBoxColumn ColumnSubPlant;
        private DataGridViewTextBoxColumn ColumnMaterial;
        private DataGridViewTextBoxColumn ColumnBNumber;
        private DataGridViewTextBoxColumn ColumnMDesc;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private DataGridViewTextBoxColumn ColumnSPEC;
        private DataGridViewTextBoxColumn ColumnSTCount;
        private DataGridViewTextBoxColumn ColumnSTBin1;
        private DataGridViewTextBoxColumn ColumnSTBinCount1;
        private DataGridViewTextBoxColumn ColumnSTBin2;
        private DataGridViewTextBoxColumn ColumnSTBinCount2;
        private DataGridViewTextBoxColumn ColumnSTBin3;
        private DataGridViewTextBoxColumn ColumnSTBinCount3;
        private DataGridViewTextBoxColumn ColumnOperatorUser;
        private DataGridViewTextBoxColumn ColumnOperatorDateTime;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlStatistic = new System.Windows.Forms.TabControl();
            this.tabPageStockOp = new System.Windows.Forms.TabPage();
            this.comboBoxStock_opPlant = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxStock_opSLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewStock_op = new System.Windows.Forms.DataGridView();
            this.ColumnStoreman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperator_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProduct_barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1Product_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBill_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin1_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin2_pty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin3_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYWTM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btStockOp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxStock_opDes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxStock_opOpKind = new System.Windows.Forms.ComboBox();
            this.textBoxStock_opBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageStockIn = new System.Windows.Forms.TabPage();
            this.textBoxStockInPznd = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxStockInPzh = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxStockInOrder_no = new System.Windows.Forms.TextBox();
            this.comboBoxStockInPlant = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxStockInSLocation = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewStockin = new System.Windows.Forms.DataGridView();
            this.ColumnOrder_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPznd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStockIn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxStockInDes = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxStockInOpKind = new System.Windows.Forms.ComboBox();
            this.textBoxStockInBarcode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPageStockOut = new System.Windows.Forms.TabPage();
            this.textBoxStockOutPznd = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxStockOutPzh = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxStockOutOrder_no = new System.Windows.Forms.TextBox();
            this.comboBoxStockOutPlant = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBoxStockOutSLocation = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dataGridViewStockout = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStockOut = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxStockOutDes = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.comboBoxStockOutOpKind = new System.Windows.Forms.ComboBox();
            this.textBoxStockOutBarcode = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tabPageStockTake = new System.Windows.Forms.TabPage();
            this.textBoxStockTakeOrder_no = new System.Windows.Forms.TextBox();
            this.btnStockTake = new System.Windows.Forms.Button();
            this.comboBoxStockTakePlant = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.comboBoxStockTakeSLocation = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.textBoxStockTakeDes = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBoxStockTakeBarcode = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.dataGridViewStocktake = new System.Windows.Forms.DataGridView();
            this.ColumnSTSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBin1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBinCount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBin2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBinCount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBin3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBinCount3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageDelivery = new System.Windows.Forms.TabPage();
            this.textBoxStockDeliveryPznd = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxStockDeliveryPzh = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBoxStockDeliveryOrder_no = new System.Windows.Forms.TextBox();
            this.comboBoxStockDeliveryPlant = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBoxStockDeliverySLocation = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.dataGridViewStockDelivery = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStockDelivery = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.textBoxStockDeliveryDes = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.comboBoxStockDeliveryOpKind = new System.Windows.Forms.ComboBox();
            this.textBoxStockDeliveryBarcode = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.checkBoxEnableDate = new System.Windows.Forms.CheckBox();
            this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tabControlStatistic.SuspendLayout();
            this.tabPageStockOp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock_op)).BeginInit();
            this.tabPageStockIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockin)).BeginInit();
            this.tabPageStockOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockout)).BeginInit();
            this.tabPageStockTake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocktake)).BeginInit();
            this.tabPageDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockDelivery)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlStatistic
            // 
            this.tabControlStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlStatistic.Controls.Add(this.tabPageStockOp);
            this.tabControlStatistic.Controls.Add(this.tabPageStockIn);
            this.tabControlStatistic.Controls.Add(this.tabPageStockOut);
            this.tabControlStatistic.Controls.Add(this.tabPageStockTake);
            this.tabControlStatistic.Controls.Add(this.tabPageDelivery);
            this.tabControlStatistic.Location = new System.Drawing.Point(12, 93);
            this.tabControlStatistic.Name = "tabControlStatistic";
            this.tabControlStatistic.SelectedIndex = 0;
            this.tabControlStatistic.Size = new System.Drawing.Size(1177, 565);
            this.tabControlStatistic.TabIndex = 100;
            // 
            // tabPageStockOp
            // 
            this.tabPageStockOp.Controls.Add(this.comboBoxStock_opPlant);
            this.tabPageStockOp.Controls.Add(this.label7);
            this.tabPageStockOp.Controls.Add(this.comboBoxStock_opSLocation);
            this.tabPageStockOp.Controls.Add(this.label6);
            this.tabPageStockOp.Controls.Add(this.dataGridViewStock_op);
            this.tabPageStockOp.Controls.Add(this.btStockOp);
            this.tabPageStockOp.Controls.Add(this.label5);
            this.tabPageStockOp.Controls.Add(this.textBoxStock_opDes);
            this.tabPageStockOp.Controls.Add(this.label4);
            this.tabPageStockOp.Controls.Add(this.comboBoxStock_opOpKind);
            this.tabPageStockOp.Controls.Add(this.textBoxStock_opBarcode);
            this.tabPageStockOp.Controls.Add(this.label3);
            this.tabPageStockOp.Location = new System.Drawing.Point(4, 29);
            this.tabPageStockOp.Name = "tabPageStockOp";
            this.tabPageStockOp.Size = new System.Drawing.Size(1169, 532);
            this.tabPageStockOp.TabIndex = 1;
            this.tabPageStockOp.Text = "移库/上架/移至报废库统计";
            this.tabPageStockOp.UseVisualStyleBackColor = true;
            // 
            // comboBoxStock_opPlant
            // 
            this.comboBoxStock_opPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStock_opPlant.FormattingEnabled = true;
            this.comboBoxStock_opPlant.Location = new System.Drawing.Point(251, 20);
            this.comboBoxStock_opPlant.Name = "comboBoxStock_opPlant";
            this.comboBoxStock_opPlant.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStock_opPlant.TabIndex = 1010;
            this.comboBoxStock_opPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxStock_opPlant_SelectedIndexChanged);
            this.comboBoxStock_opPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 303;
            this.label7.Text = "公司：";
            // 
            // comboBoxStock_opSLocation
            // 
            this.comboBoxStock_opSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStock_opSLocation.FormattingEnabled = true;
            this.comboBoxStock_opSLocation.Location = new System.Drawing.Point(442, 20);
            this.comboBoxStock_opSLocation.Name = "comboBoxStock_opSLocation";
            this.comboBoxStock_opSLocation.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStock_opSLocation.TabIndex = 1020;
            this.comboBoxStock_opSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 302;
            this.label6.Text = "库存地点：";
            // 
            // dataGridViewStock_op
            // 
            this.dataGridViewStock_op.AllowUserToAddRows = false;
            this.dataGridViewStock_op.AllowUserToResizeRows = false;
            this.dataGridViewStock_op.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStock_op.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStock_op.ColumnHeadersHeight = 30;
            this.dataGridViewStock_op.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStock_op.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStoreman,
            this.ColumnOperator_date,
            this.ColumnProduct_barcode,
            this.Column1Product_desc,
            this.ColumnGch,
            this.ColumnSL,
            this.ColumnBill_type,
            this.ColumnPty,
            this.ColumnBin1,
            this.ColumnBin1_qty,
            this.ColumnBin2,
            this.ColumnBin2_pty,
            this.ColumnBin3,
            this.ColumnBin3_qty,
            this.ColumnRemark,
            this.ColumnYWTM});
            this.dataGridViewStock_op.Location = new System.Drawing.Point(5, 59);
            this.dataGridViewStock_op.MultiSelect = false;
            this.dataGridViewStock_op.Name = "dataGridViewStock_op";
            this.dataGridViewStock_op.ReadOnly = true;
            this.dataGridViewStock_op.RowHeadersVisible = false;
            this.dataGridViewStock_op.RowTemplate.Height = 23;
            this.dataGridViewStock_op.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStock_op.Size = new System.Drawing.Size(1161, 455);
            this.dataGridViewStock_op.TabIndex = 1060;
            // 
            // ColumnStoreman
            // 
            this.ColumnStoreman.DataPropertyName = "storeman";
            this.ColumnStoreman.HeaderText = "保管员";
            this.ColumnStoreman.Name = "ColumnStoreman";
            this.ColumnStoreman.ReadOnly = true;
            this.ColumnStoreman.Width = 76;
            // 
            // ColumnOperator_date
            // 
            this.ColumnOperator_date.DataPropertyName = "operator_date";
            this.ColumnOperator_date.HeaderText = "操作时间";
            this.ColumnOperator_date.Name = "ColumnOperator_date";
            this.ColumnOperator_date.ReadOnly = true;
            this.ColumnOperator_date.Width = 90;
            // 
            // ColumnProduct_barcode
            // 
            this.ColumnProduct_barcode.DataPropertyName = "product_barcode";
            this.ColumnProduct_barcode.HeaderText = "物料条码";
            this.ColumnProduct_barcode.Name = "ColumnProduct_barcode";
            this.ColumnProduct_barcode.ReadOnly = true;
            this.ColumnProduct_barcode.Width = 90;
            // 
            // Column1Product_desc
            // 
            this.Column1Product_desc.DataPropertyName = "product_desc";
            this.Column1Product_desc.HeaderText = "物料描述";
            this.Column1Product_desc.Name = "Column1Product_desc";
            this.Column1Product_desc.ReadOnly = true;
            this.Column1Product_desc.Width = 90;
            // 
            // ColumnGch
            // 
            this.ColumnGch.DataPropertyName = "gch";
            this.ColumnGch.HeaderText = "公司";
            this.ColumnGch.Name = "ColumnGch";
            this.ColumnGch.ReadOnly = true;
            this.ColumnGch.Width = 62;
            // 
            // ColumnSL
            // 
            this.ColumnSL.DataPropertyName = "SL";
            this.ColumnSL.HeaderText = "库存地点";
            this.ColumnSL.Name = "ColumnSL";
            this.ColumnSL.ReadOnly = true;
            this.ColumnSL.Width = 90;
            // 
            // ColumnBill_type
            // 
            this.ColumnBill_type.DataPropertyName = "bill_type";
            this.ColumnBill_type.HeaderText = "单据类型";
            this.ColumnBill_type.Name = "ColumnBill_type";
            this.ColumnBill_type.ReadOnly = true;
            this.ColumnBill_type.Width = 90;
            // 
            // ColumnPty
            // 
            this.ColumnPty.DataPropertyName = "qty";
            this.ColumnPty.HeaderText = "数量";
            this.ColumnPty.Name = "ColumnPty";
            this.ColumnPty.ReadOnly = true;
            this.ColumnPty.Width = 62;
            // 
            // ColumnBin1
            // 
            this.ColumnBin1.DataPropertyName = "bin1";
            this.ColumnBin1.HeaderText = "货位1";
            this.ColumnBin1.Name = "ColumnBin1";
            this.ColumnBin1.ReadOnly = true;
            this.ColumnBin1.Width = 70;
            // 
            // ColumnBin1_qty
            // 
            this.ColumnBin1_qty.DataPropertyName = "bin1_qty";
            this.ColumnBin1_qty.HeaderText = "货位1数量";
            this.ColumnBin1_qty.Name = "ColumnBin1_qty";
            this.ColumnBin1_qty.ReadOnly = true;
            this.ColumnBin1_qty.Width = 98;
            // 
            // ColumnBin2
            // 
            this.ColumnBin2.DataPropertyName = "bin2";
            this.ColumnBin2.HeaderText = "货位2";
            this.ColumnBin2.Name = "ColumnBin2";
            this.ColumnBin2.ReadOnly = true;
            this.ColumnBin2.Width = 70;
            // 
            // ColumnBin2_pty
            // 
            this.ColumnBin2_pty.DataPropertyName = "bin2_qty";
            this.ColumnBin2_pty.HeaderText = "货位2数量";
            this.ColumnBin2_pty.Name = "ColumnBin2_pty";
            this.ColumnBin2_pty.ReadOnly = true;
            this.ColumnBin2_pty.Width = 98;
            // 
            // ColumnBin3
            // 
            this.ColumnBin3.DataPropertyName = "bin3";
            this.ColumnBin3.HeaderText = "货位3";
            this.ColumnBin3.Name = "ColumnBin3";
            this.ColumnBin3.ReadOnly = true;
            this.ColumnBin3.Width = 70;
            // 
            // ColumnBin3_qty
            // 
            this.ColumnBin3_qty.DataPropertyName = "bin3_qty";
            this.ColumnBin3_qty.HeaderText = "货位3数量";
            this.ColumnBin3_qty.Name = "ColumnBin3_qty";
            this.ColumnBin3_qty.ReadOnly = true;
            this.ColumnBin3_qty.Width = 98;
            // 
            // ColumnRemark
            // 
            this.ColumnRemark.DataPropertyName = "remark";
            this.ColumnRemark.HeaderText = "备注";
            this.ColumnRemark.Name = "ColumnRemark";
            this.ColumnRemark.ReadOnly = true;
            this.ColumnRemark.Width = 62;
            // 
            // ColumnYWTM
            // 
            this.ColumnYWTM.DataPropertyName = "ywtm";
            this.ColumnYWTM.HeaderText = "一维条码";
            this.ColumnYWTM.Name = "ColumnYWTM";
            this.ColumnYWTM.ReadOnly = true;
            this.ColumnYWTM.Width = 90;
            // 
            // btStockOp
            // 
            this.btStockOp.Enabled = false;
            this.btStockOp.Location = new System.Drawing.Point(1030, 13);
            this.btStockOp.Name = "btStockOp";
            this.btStockOp.Size = new System.Drawing.Size(100, 40);
            this.btStockOp.TabIndex = 1050;
            this.btStockOp.Text = "筛选";
            this.btStockOp.UseVisualStyleBackColor = true;
            this.btStockOp.Click += new System.EventHandler(this.btStockOp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(789, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 91;
            this.label5.Text = "物料描述：";
            // 
            // textBoxStock_opDes
            // 
            this.textBoxStock_opDes.Location = new System.Drawing.Point(874, 20);
            this.textBoxStock_opDes.Name = "textBoxStock_opDes";
            this.textBoxStock_opDes.Size = new System.Drawing.Size(150, 26);
            this.textBoxStock_opDes.TabIndex = 1040;
            this.textBoxStock_opDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 89;
            this.label4.Text = "物料条码：";
            // 
            // comboBoxStock_opOpKind
            // 
            this.comboBoxStock_opOpKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStock_opOpKind.FormattingEnabled = true;
            this.comboBoxStock_opOpKind.Items.AddRange(new object[] {
            "所有",
            "实时移库",
            "批量移库",
            "上架",
            "移至报废库"});
            this.comboBoxStock_opOpKind.Location = new System.Drawing.Point(88, 20);
            this.comboBoxStock_opOpKind.Name = "comboBoxStock_opOpKind";
            this.comboBoxStock_opOpKind.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStock_opOpKind.TabIndex = 1000;
            this.comboBoxStock_opOpKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxStock_opBarcode
            // 
            this.textBoxStock_opBarcode.Location = new System.Drawing.Point(633, 20);
            this.textBoxStock_opBarcode.Name = "textBoxStock_opBarcode";
            this.textBoxStock_opBarcode.Size = new System.Drawing.Size(150, 26);
            this.textBoxStock_opBarcode.TabIndex = 1030;
            this.textBoxStock_opBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 83;
            this.label3.Text = "统计类型：";
            // 
            // tabPageStockIn
            // 
            this.tabPageStockIn.Controls.Add(this.textBoxStockInPznd);
            this.tabPageStockIn.Controls.Add(this.label16);
            this.tabPageStockIn.Controls.Add(this.label14);
            this.tabPageStockIn.Controls.Add(this.textBoxStockInPzh);
            this.tabPageStockIn.Controls.Add(this.label15);
            this.tabPageStockIn.Controls.Add(this.textBoxStockInOrder_no);
            this.tabPageStockIn.Controls.Add(this.comboBoxStockInPlant);
            this.tabPageStockIn.Controls.Add(this.label8);
            this.tabPageStockIn.Controls.Add(this.comboBoxStockInSLocation);
            this.tabPageStockIn.Controls.Add(this.label9);
            this.tabPageStockIn.Controls.Add(this.dataGridViewStockin);
            this.tabPageStockIn.Controls.Add(this.btnStockIn);
            this.tabPageStockIn.Controls.Add(this.label11);
            this.tabPageStockIn.Controls.Add(this.textBoxStockInDes);
            this.tabPageStockIn.Controls.Add(this.label12);
            this.tabPageStockIn.Controls.Add(this.comboBoxStockInOpKind);
            this.tabPageStockIn.Controls.Add(this.textBoxStockInBarcode);
            this.tabPageStockIn.Controls.Add(this.label13);
            this.tabPageStockIn.Location = new System.Drawing.Point(4, 29);
            this.tabPageStockIn.Name = "tabPageStockIn";
            this.tabPageStockIn.Size = new System.Drawing.Size(1169, 532);
            this.tabPageStockIn.TabIndex = 2;
            this.tabPageStockIn.Text = "入库/库存退货统计";
            this.tabPageStockIn.UseVisualStyleBackColor = true;
            // 
            // textBoxStockInPznd
            // 
            this.textBoxStockInPznd.Location = new System.Drawing.Point(747, 54);
            this.textBoxStockInPznd.Name = "textBoxStockInPznd";
            this.textBoxStockInPznd.Size = new System.Drawing.Size(100, 26);
            this.textBoxStockInPznd.TabIndex = 2050;
            this.textBoxStockInPznd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(662, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 322;
            this.label16.Text = "凭证年度：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(485, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.TabIndex = 321;
            this.label14.Text = "凭证号：";
            // 
            // textBoxStockInPzh
            // 
            this.textBoxStockInPzh.Location = new System.Drawing.Point(556, 54);
            this.textBoxStockInPzh.Name = "textBoxStockInPzh";
            this.textBoxStockInPzh.Size = new System.Drawing.Size(100, 26);
            this.textBoxStockInPzh.TabIndex = 2040;
            this.textBoxStockInPzh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(548, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 20);
            this.label15.TabIndex = 319;
            this.label15.Text = "订单号：";
            // 
            // textBoxStockInOrder_no
            // 
            this.textBoxStockInOrder_no.Location = new System.Drawing.Point(619, 20);
            this.textBoxStockInOrder_no.Name = "textBoxStockInOrder_no";
            this.textBoxStockInOrder_no.Size = new System.Drawing.Size(200, 26);
            this.textBoxStockInOrder_no.TabIndex = 2030;
            this.textBoxStockInOrder_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // comboBoxStockInPlant
            // 
            this.comboBoxStockInPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockInPlant.FormattingEnabled = true;
            this.comboBoxStockInPlant.Location = new System.Drawing.Point(251, 20);
            this.comboBoxStockInPlant.Name = "comboBoxStockInPlant";
            this.comboBoxStockInPlant.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockInPlant.TabIndex = 2010;
            this.comboBoxStockInPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxStockInPlant_SelectedIndexChanged);
            this.comboBoxStockInPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(194, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 315;
            this.label8.Text = "公司：";
            // 
            // comboBoxStockInSLocation
            // 
            this.comboBoxStockInSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockInSLocation.FormattingEnabled = true;
            this.comboBoxStockInSLocation.Location = new System.Drawing.Point(442, 20);
            this.comboBoxStockInSLocation.Name = "comboBoxStockInSLocation";
            this.comboBoxStockInSLocation.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockInSLocation.TabIndex = 2020;
            this.comboBoxStockInSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(357, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 314;
            this.label9.Text = "库存地点：";
            // 
            // dataGridViewStockin
            // 
            this.dataGridViewStockin.AllowUserToAddRows = false;
            this.dataGridViewStockin.AllowUserToResizeRows = false;
            this.dataGridViewStockin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStockin.ColumnHeadersHeight = 30;
            this.dataGridViewStockin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStockin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOrder_no,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.ColumnPzh,
            this.ColumnPznd,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn45});
            this.dataGridViewStockin.Location = new System.Drawing.Point(5, 86);
            this.dataGridViewStockin.MultiSelect = false;
            this.dataGridViewStockin.Name = "dataGridViewStockin";
            this.dataGridViewStockin.ReadOnly = true;
            this.dataGridViewStockin.RowHeadersVisible = false;
            this.dataGridViewStockin.RowTemplate.Height = 23;
            this.dataGridViewStockin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockin.Size = new System.Drawing.Size(1161, 428);
            this.dataGridViewStockin.TabIndex = 2090;
            // 
            // ColumnOrder_no
            // 
            this.ColumnOrder_no.DataPropertyName = "order_no";
            this.ColumnOrder_no.HeaderText = "订单号";
            this.ColumnOrder_no.Name = "ColumnOrder_no";
            this.ColumnOrder_no.ReadOnly = true;
            this.ColumnOrder_no.Width = 76;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "operator_date";
            this.dataGridViewTextBoxColumn2.HeaderText = "操作时间";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "storeman";
            this.dataGridViewTextBoxColumn1.HeaderText = "保管员";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 76;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "gch";
            this.dataGridViewTextBoxColumn5.HeaderText = "公司";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 62;
            // 
            // ColumnPzh
            // 
            this.ColumnPzh.DataPropertyName = "pzh";
            this.ColumnPzh.HeaderText = "凭证号";
            this.ColumnPzh.Name = "ColumnPzh";
            this.ColumnPzh.ReadOnly = true;
            this.ColumnPzh.Width = 76;
            // 
            // ColumnPznd
            // 
            this.ColumnPznd.DataPropertyName = "pznd";
            this.ColumnPznd.HeaderText = "凭证年度";
            this.ColumnPznd.Name = "ColumnPznd";
            this.ColumnPznd.ReadOnly = true;
            this.ColumnPznd.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "bill_type";
            this.dataGridViewTextBoxColumn7.HeaderText = "单据类型";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "product_barcode";
            this.dataGridViewTextBoxColumn3.HeaderText = "物料条码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "product_desc";
            this.dataGridViewTextBoxColumn4.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "qty";
            this.dataGridViewTextBoxColumn8.HeaderText = "数量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 62;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SL";
            this.dataGridViewTextBoxColumn6.HeaderText = "库存地点";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "bin1";
            this.dataGridViewTextBoxColumn9.HeaderText = "货位1";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "bin1_qty";
            this.dataGridViewTextBoxColumn10.HeaderText = "货位1数量";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 98;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "bin2";
            this.dataGridViewTextBoxColumn11.HeaderText = "货位2";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 70;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "bin2_qty";
            this.dataGridViewTextBoxColumn12.HeaderText = "货位2数量";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 98;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "bin3";
            this.dataGridViewTextBoxColumn13.HeaderText = "货位3";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 70;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "bin3_qty";
            this.dataGridViewTextBoxColumn14.HeaderText = "货位3数量";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 98;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn15.HeaderText = "备注";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 62;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.DataPropertyName = "ywtm";
            this.dataGridViewTextBoxColumn45.HeaderText = "一维条码";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            this.dataGridViewTextBoxColumn45.Width = 90;
            // 
            // btnStockIn
            // 
            this.btnStockIn.Enabled = false;
            this.btnStockIn.Location = new System.Drawing.Point(1024, 34);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(100, 40);
            this.btnStockIn.TabIndex = 2080;
            this.btnStockIn.Text = "筛选";
            this.btnStockIn.UseVisualStyleBackColor = true;
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            this.btnStockIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(244, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 311;
            this.label11.Text = "物料描述：";
            // 
            // textBoxStockInDes
            // 
            this.textBoxStockInDes.Location = new System.Drawing.Point(329, 54);
            this.textBoxStockInDes.Name = "textBoxStockInDes";
            this.textBoxStockInDes.Size = new System.Drawing.Size(150, 26);
            this.textBoxStockInDes.TabIndex = 2070;
            this.textBoxStockInDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 309;
            this.label12.Text = "物料条码：";
            // 
            // comboBoxStockInOpKind
            // 
            this.comboBoxStockInOpKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockInOpKind.FormattingEnabled = true;
            this.comboBoxStockInOpKind.Items.AddRange(new object[] {
            "所有",
            "验收入库",
            "代保管入库",
            "异议入库",
            "库存退货"});
            this.comboBoxStockInOpKind.Location = new System.Drawing.Point(88, 20);
            this.comboBoxStockInOpKind.Name = "comboBoxStockInOpKind";
            this.comboBoxStockInOpKind.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockInOpKind.TabIndex = 2000;
            this.comboBoxStockInOpKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxStockInBarcode
            // 
            this.textBoxStockInBarcode.Location = new System.Drawing.Point(88, 54);
            this.textBoxStockInBarcode.Name = "textBoxStockInBarcode";
            this.textBoxStockInBarcode.Size = new System.Drawing.Size(150, 26);
            this.textBoxStockInBarcode.TabIndex = 2060;
            this.textBoxStockInBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 20);
            this.label13.TabIndex = 306;
            this.label13.Text = "统计类型：";
            // 
            // tabPageStockOut
            // 
            this.tabPageStockOut.Controls.Add(this.textBoxStockOutPznd);
            this.tabPageStockOut.Controls.Add(this.label17);
            this.tabPageStockOut.Controls.Add(this.label18);
            this.tabPageStockOut.Controls.Add(this.textBoxStockOutPzh);
            this.tabPageStockOut.Controls.Add(this.label19);
            this.tabPageStockOut.Controls.Add(this.textBoxStockOutOrder_no);
            this.tabPageStockOut.Controls.Add(this.comboBoxStockOutPlant);
            this.tabPageStockOut.Controls.Add(this.label20);
            this.tabPageStockOut.Controls.Add(this.comboBoxStockOutSLocation);
            this.tabPageStockOut.Controls.Add(this.label21);
            this.tabPageStockOut.Controls.Add(this.dataGridViewStockout);
            this.tabPageStockOut.Controls.Add(this.btnStockOut);
            this.tabPageStockOut.Controls.Add(this.label22);
            this.tabPageStockOut.Controls.Add(this.textBoxStockOutDes);
            this.tabPageStockOut.Controls.Add(this.label23);
            this.tabPageStockOut.Controls.Add(this.comboBoxStockOutOpKind);
            this.tabPageStockOut.Controls.Add(this.textBoxStockOutBarcode);
            this.tabPageStockOut.Controls.Add(this.label24);
            this.tabPageStockOut.Location = new System.Drawing.Point(4, 29);
            this.tabPageStockOut.Name = "tabPageStockOut";
            this.tabPageStockOut.Size = new System.Drawing.Size(1169, 532);
            this.tabPageStockOut.TabIndex = 3;
            this.tabPageStockOut.Text = "出库统计";
            this.tabPageStockOut.UseVisualStyleBackColor = true;
            // 
            // textBoxStockOutPznd
            // 
            this.textBoxStockOutPznd.Location = new System.Drawing.Point(747, 53);
            this.textBoxStockOutPznd.Name = "textBoxStockOutPznd";
            this.textBoxStockOutPznd.Size = new System.Drawing.Size(100, 26);
            this.textBoxStockOutPznd.TabIndex = 3050;
            this.textBoxStockOutPznd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(662, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 20);
            this.label17.TabIndex = 340;
            this.label17.Text = "凭证年度：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(485, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 20);
            this.label18.TabIndex = 339;
            this.label18.Text = "凭证号：";
            // 
            // textBoxStockOutPzh
            // 
            this.textBoxStockOutPzh.Location = new System.Drawing.Point(556, 53);
            this.textBoxStockOutPzh.Name = "textBoxStockOutPzh";
            this.textBoxStockOutPzh.Size = new System.Drawing.Size(100, 26);
            this.textBoxStockOutPzh.TabIndex = 3040;
            this.textBoxStockOutPzh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(548, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 20);
            this.label19.TabIndex = 337;
            this.label19.Text = "订单号：";
            // 
            // textBoxStockOutOrder_no
            // 
            this.textBoxStockOutOrder_no.Location = new System.Drawing.Point(619, 19);
            this.textBoxStockOutOrder_no.Name = "textBoxStockOutOrder_no";
            this.textBoxStockOutOrder_no.Size = new System.Drawing.Size(200, 26);
            this.textBoxStockOutOrder_no.TabIndex = 3030;
            this.textBoxStockOutOrder_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // comboBoxStockOutPlant
            // 
            this.comboBoxStockOutPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockOutPlant.FormattingEnabled = true;
            this.comboBoxStockOutPlant.Location = new System.Drawing.Point(251, 20);
            this.comboBoxStockOutPlant.Name = "comboBoxStockOutPlant";
            this.comboBoxStockOutPlant.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockOutPlant.TabIndex = 3010;
            this.comboBoxStockOutPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxStockOutPlant_SelectedIndexChanged);
            this.comboBoxStockOutPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(194, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 20);
            this.label20.TabIndex = 333;
            this.label20.Text = "公司：";
            // 
            // comboBoxStockOutSLocation
            // 
            this.comboBoxStockOutSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockOutSLocation.FormattingEnabled = true;
            this.comboBoxStockOutSLocation.Location = new System.Drawing.Point(442, 19);
            this.comboBoxStockOutSLocation.Name = "comboBoxStockOutSLocation";
            this.comboBoxStockOutSLocation.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockOutSLocation.TabIndex = 3020;
            this.comboBoxStockOutSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(357, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 20);
            this.label21.TabIndex = 332;
            this.label21.Text = "库存地点：";
            // 
            // dataGridViewStockout
            // 
            this.dataGridViewStockout.AllowUserToAddRows = false;
            this.dataGridViewStockout.AllowUserToResizeRows = false;
            this.dataGridViewStockout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockout.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStockout.ColumnHeadersHeight = 30;
            this.dataGridViewStockout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStockout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn46});
            this.dataGridViewStockout.Location = new System.Drawing.Point(5, 85);
            this.dataGridViewStockout.MultiSelect = false;
            this.dataGridViewStockout.Name = "dataGridViewStockout";
            this.dataGridViewStockout.ReadOnly = true;
            this.dataGridViewStockout.RowHeadersVisible = false;
            this.dataGridViewStockout.RowTemplate.Height = 23;
            this.dataGridViewStockout.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockout.Size = new System.Drawing.Size(1161, 429);
            this.dataGridViewStockout.TabIndex = 3090;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "order_no";
            this.dataGridViewTextBoxColumn16.HeaderText = "订单号";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 76;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "operator_date";
            this.dataGridViewTextBoxColumn17.HeaderText = "操作时间";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 90;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "storeman";
            this.dataGridViewTextBoxColumn18.HeaderText = "保管员";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 76;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "gch";
            this.dataGridViewTextBoxColumn19.HeaderText = "公司";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 62;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "pzh";
            this.dataGridViewTextBoxColumn20.HeaderText = "凭证号";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 76;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "pznd";
            this.dataGridViewTextBoxColumn21.HeaderText = "凭证年度";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 90;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "bill_type";
            this.dataGridViewTextBoxColumn22.HeaderText = "单据类型";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 90;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "product_barcode";
            this.dataGridViewTextBoxColumn23.HeaderText = "物料条码";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 90;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "product_desc";
            this.dataGridViewTextBoxColumn24.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 90;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "qty";
            this.dataGridViewTextBoxColumn25.HeaderText = "数量";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 62;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "SL";
            this.dataGridViewTextBoxColumn26.HeaderText = "库存地点";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Width = 90;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "bin1";
            this.dataGridViewTextBoxColumn27.HeaderText = "货位1";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Width = 70;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "bin1_qty";
            this.dataGridViewTextBoxColumn28.HeaderText = "货位1数量";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Width = 98;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "bin2";
            this.dataGridViewTextBoxColumn29.HeaderText = "货位2";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.Width = 70;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "bin2_qty";
            this.dataGridViewTextBoxColumn30.HeaderText = "货位2数量";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Width = 98;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "bin3";
            this.dataGridViewTextBoxColumn31.HeaderText = "货位3";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Width = 70;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "bin3_qty";
            this.dataGridViewTextBoxColumn32.HeaderText = "货位3数量";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Width = 98;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn33.HeaderText = "备注";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            this.dataGridViewTextBoxColumn33.Width = 62;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.DataPropertyName = "ywtm";
            this.dataGridViewTextBoxColumn46.HeaderText = "一维条码";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            this.dataGridViewTextBoxColumn46.Width = 90;
            // 
            // btnStockOut
            // 
            this.btnStockOut.Enabled = false;
            this.btnStockOut.Location = new System.Drawing.Point(1023, 34);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(100, 40);
            this.btnStockOut.TabIndex = 3080;
            this.btnStockOut.Text = "筛选";
            this.btnStockOut.UseVisualStyleBackColor = true;
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            this.btnStockOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(244, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 20);
            this.label22.TabIndex = 329;
            this.label22.Text = "物料描述：";
            // 
            // textBoxStockOutDes
            // 
            this.textBoxStockOutDes.Location = new System.Drawing.Point(329, 53);
            this.textBoxStockOutDes.Name = "textBoxStockOutDes";
            this.textBoxStockOutDes.Size = new System.Drawing.Size(150, 26);
            this.textBoxStockOutDes.TabIndex = 3070;
            this.textBoxStockOutDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 56);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 20);
            this.label23.TabIndex = 327;
            this.label23.Text = "物料条码：";
            // 
            // comboBoxStockOutOpKind
            // 
            this.comboBoxStockOutOpKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockOutOpKind.FormattingEnabled = true;
            this.comboBoxStockOutOpKind.Items.AddRange(new object[] {
            "所有",
            "生产领料",
            "报废出库",
            "代保管出库"});
            this.comboBoxStockOutOpKind.Location = new System.Drawing.Point(88, 19);
            this.comboBoxStockOutOpKind.Name = "comboBoxStockOutOpKind";
            this.comboBoxStockOutOpKind.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockOutOpKind.TabIndex = 3000;
            this.comboBoxStockOutOpKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxStockOutBarcode
            // 
            this.textBoxStockOutBarcode.Location = new System.Drawing.Point(88, 53);
            this.textBoxStockOutBarcode.Name = "textBoxStockOutBarcode";
            this.textBoxStockOutBarcode.Size = new System.Drawing.Size(150, 26);
            this.textBoxStockOutBarcode.TabIndex = 3060;
            this.textBoxStockOutBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 20);
            this.label24.TabIndex = 324;
            this.label24.Text = "统计类型：";
            // 
            // tabPageStockTake
            // 
            this.tabPageStockTake.Controls.Add(this.textBoxStockTakeOrder_no);
            this.tabPageStockTake.Controls.Add(this.btnStockTake);
            this.tabPageStockTake.Controls.Add(this.comboBoxStockTakePlant);
            this.tabPageStockTake.Controls.Add(this.label33);
            this.tabPageStockTake.Controls.Add(this.comboBoxStockTakeSLocation);
            this.tabPageStockTake.Controls.Add(this.label34);
            this.tabPageStockTake.Controls.Add(this.label35);
            this.tabPageStockTake.Controls.Add(this.textBoxStockTakeDes);
            this.tabPageStockTake.Controls.Add(this.label36);
            this.tabPageStockTake.Controls.Add(this.textBoxStockTakeBarcode);
            this.tabPageStockTake.Controls.Add(this.label37);
            this.tabPageStockTake.Controls.Add(this.dataGridViewStocktake);
            this.tabPageStockTake.Location = new System.Drawing.Point(4, 29);
            this.tabPageStockTake.Name = "tabPageStockTake";
            this.tabPageStockTake.Size = new System.Drawing.Size(1169, 532);
            this.tabPageStockTake.TabIndex = 4;
            this.tabPageStockTake.Text = "盘点统计";
            this.tabPageStockTake.UseVisualStyleBackColor = true;
            // 
            // textBoxStockTakeOrder_no
            // 
            this.textBoxStockTakeOrder_no.Location = new System.Drawing.Point(88, 17);
            this.textBoxStockTakeOrder_no.Name = "textBoxStockTakeOrder_no";
            this.textBoxStockTakeOrder_no.Size = new System.Drawing.Size(200, 26);
            this.textBoxStockTakeOrder_no.TabIndex = 4000;
            this.textBoxStockTakeOrder_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnStockTake
            // 
            this.btnStockTake.Enabled = false;
            this.btnStockTake.Location = new System.Drawing.Point(793, 17);
            this.btnStockTake.Name = "btnStockTake";
            this.btnStockTake.Size = new System.Drawing.Size(100, 40);
            this.btnStockTake.TabIndex = 4050;
            this.btnStockTake.Text = "筛选";
            this.btnStockTake.UseVisualStyleBackColor = true;
            this.btnStockTake.Click += new System.EventHandler(this.btnStockTake_Click);
            this.btnStockTake.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // comboBoxStockTakePlant
            // 
            this.comboBoxStockTakePlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockTakePlant.FormattingEnabled = true;
            this.comboBoxStockTakePlant.Location = new System.Drawing.Point(351, 17);
            this.comboBoxStockTakePlant.Name = "comboBoxStockTakePlant";
            this.comboBoxStockTakePlant.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockTakePlant.TabIndex = 4010;
            this.comboBoxStockTakePlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxStockTakePlant_SelectedIndexChanged);
            this.comboBoxStockTakePlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(294, 20);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(51, 20);
            this.label33.TabIndex = 343;
            this.label33.Text = "公司：";
            // 
            // comboBoxStockTakeSLocation
            // 
            this.comboBoxStockTakeSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockTakeSLocation.FormattingEnabled = true;
            this.comboBoxStockTakeSLocation.Location = new System.Drawing.Point(542, 17);
            this.comboBoxStockTakeSLocation.Name = "comboBoxStockTakeSLocation";
            this.comboBoxStockTakeSLocation.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockTakeSLocation.TabIndex = 4020;
            this.comboBoxStockTakeSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(457, 20);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(79, 20);
            this.label34.TabIndex = 342;
            this.label34.Text = "库存地点：";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(243, 52);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(79, 20);
            this.label35.TabIndex = 341;
            this.label35.Text = "物料描述：";
            // 
            // textBoxStockTakeDes
            // 
            this.textBoxStockTakeDes.Location = new System.Drawing.Point(328, 49);
            this.textBoxStockTakeDes.Name = "textBoxStockTakeDes";
            this.textBoxStockTakeDes.Size = new System.Drawing.Size(200, 26);
            this.textBoxStockTakeDes.TabIndex = 4040;
            this.textBoxStockTakeDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(2, 52);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(79, 20);
            this.label36.TabIndex = 339;
            this.label36.Text = "物料条码：";
            // 
            // textBoxStockTakeBarcode
            // 
            this.textBoxStockTakeBarcode.Location = new System.Drawing.Point(87, 49);
            this.textBoxStockTakeBarcode.Name = "textBoxStockTakeBarcode";
            this.textBoxStockTakeBarcode.Size = new System.Drawing.Size(150, 26);
            this.textBoxStockTakeBarcode.TabIndex = 4030;
            this.textBoxStockTakeBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(3, 20);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(79, 20);
            this.label37.TabIndex = 336;
            this.label37.Text = "盘点单号：";
            // 
            // dataGridViewStocktake
            // 
            this.dataGridViewStocktake.AllowUserToAddRows = false;
            this.dataGridViewStocktake.AllowUserToResizeRows = false;
            this.dataGridViewStocktake.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStocktake.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStocktake.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStocktake.ColumnHeadersHeight = 30;
            this.dataGridViewStocktake.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStocktake.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSTSerial,
            this.ColumnPlant,
            this.ColumnSLocation,
            this.ColumnSubPlant,
            this.ColumnMaterial,
            this.ColumnBNumber,
            this.ColumnMDesc,
            this.ColumnUNIT,
            this.ColumnSPEC,
            this.ColumnSTCount,
            this.ColumnSTBin1,
            this.ColumnSTBinCount1,
            this.ColumnSTBin2,
            this.ColumnSTBinCount2,
            this.ColumnSTBin3,
            this.ColumnSTBinCount3,
            this.ColumnOperatorUser,
            this.ColumnOperatorDateTime,
            this.dataGridViewTextBoxColumn47});
            this.dataGridViewStocktake.Location = new System.Drawing.Point(5, 81);
            this.dataGridViewStocktake.MultiSelect = false;
            this.dataGridViewStocktake.Name = "dataGridViewStocktake";
            this.dataGridViewStocktake.ReadOnly = true;
            this.dataGridViewStocktake.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewStocktake.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStocktake.RowTemplate.Height = 23;
            this.dataGridViewStocktake.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStocktake.Size = new System.Drawing.Size(1161, 433);
            this.dataGridViewStocktake.TabIndex = 4060;
            // 
            // ColumnSTSerial
            // 
            this.ColumnSTSerial.DataPropertyName = "STSerial";
            this.ColumnSTSerial.HeaderText = "盘点序号";
            this.ColumnSTSerial.Name = "ColumnSTSerial";
            this.ColumnSTSerial.ReadOnly = true;
            this.ColumnSTSerial.Width = 90;
            // 
            // ColumnPlant
            // 
            this.ColumnPlant.DataPropertyName = "Plant";
            this.ColumnPlant.HeaderText = "公司";
            this.ColumnPlant.Name = "ColumnPlant";
            this.ColumnPlant.ReadOnly = true;
            this.ColumnPlant.Width = 62;
            // 
            // ColumnSLocation
            // 
            this.ColumnSLocation.DataPropertyName = "SLocation";
            this.ColumnSLocation.HeaderText = "存储位置";
            this.ColumnSLocation.Name = "ColumnSLocation";
            this.ColumnSLocation.ReadOnly = true;
            this.ColumnSLocation.Width = 90;
            // 
            // ColumnSubPlant
            // 
            this.ColumnSubPlant.DataPropertyName = "SubPlant";
            this.ColumnSubPlant.HeaderText = "工厂";
            this.ColumnSubPlant.Name = "ColumnSubPlant";
            this.ColumnSubPlant.ReadOnly = true;
            this.ColumnSubPlant.Width = 62;
            // 
            // ColumnMaterial
            // 
            this.ColumnMaterial.DataPropertyName = "Material";
            this.ColumnMaterial.HeaderText = "物料号";
            this.ColumnMaterial.Name = "ColumnMaterial";
            this.ColumnMaterial.ReadOnly = true;
            this.ColumnMaterial.Width = 76;
            // 
            // ColumnBNumber
            // 
            this.ColumnBNumber.DataPropertyName = "BNumber";
            this.ColumnBNumber.HeaderText = "批次号";
            this.ColumnBNumber.Name = "ColumnBNumber";
            this.ColumnBNumber.ReadOnly = true;
            this.ColumnBNumber.Width = 76;
            // 
            // ColumnMDesc
            // 
            this.ColumnMDesc.DataPropertyName = "MDesc";
            this.ColumnMDesc.HeaderText = "货物名称";
            this.ColumnMDesc.Name = "ColumnMDesc";
            this.ColumnMDesc.ReadOnly = true;
            this.ColumnMDesc.Width = 90;
            // 
            // ColumnUNIT
            // 
            this.ColumnUNIT.DataPropertyName = "UNIT";
            this.ColumnUNIT.HeaderText = "单位";
            this.ColumnUNIT.Name = "ColumnUNIT";
            this.ColumnUNIT.ReadOnly = true;
            this.ColumnUNIT.Width = 62;
            // 
            // ColumnSPEC
            // 
            this.ColumnSPEC.DataPropertyName = "SPEC";
            this.ColumnSPEC.HeaderText = "规格";
            this.ColumnSPEC.Name = "ColumnSPEC";
            this.ColumnSPEC.ReadOnly = true;
            this.ColumnSPEC.Width = 62;
            // 
            // ColumnSTCount
            // 
            this.ColumnSTCount.DataPropertyName = "STCount";
            this.ColumnSTCount.HeaderText = "库存";
            this.ColumnSTCount.Name = "ColumnSTCount";
            this.ColumnSTCount.ReadOnly = true;
            this.ColumnSTCount.Width = 62;
            // 
            // ColumnSTBin1
            // 
            this.ColumnSTBin1.DataPropertyName = "STBin1";
            this.ColumnSTBin1.HeaderText = "货位1";
            this.ColumnSTBin1.Name = "ColumnSTBin1";
            this.ColumnSTBin1.ReadOnly = true;
            this.ColumnSTBin1.Width = 70;
            // 
            // ColumnSTBinCount1
            // 
            this.ColumnSTBinCount1.DataPropertyName = "STBinCount1";
            this.ColumnSTBinCount1.HeaderText = "货位1数量";
            this.ColumnSTBinCount1.Name = "ColumnSTBinCount1";
            this.ColumnSTBinCount1.ReadOnly = true;
            this.ColumnSTBinCount1.Width = 98;
            // 
            // ColumnSTBin2
            // 
            this.ColumnSTBin2.DataPropertyName = "STBin2";
            this.ColumnSTBin2.HeaderText = "货位2";
            this.ColumnSTBin2.Name = "ColumnSTBin2";
            this.ColumnSTBin2.ReadOnly = true;
            this.ColumnSTBin2.Width = 70;
            // 
            // ColumnSTBinCount2
            // 
            this.ColumnSTBinCount2.DataPropertyName = "STBinCount2";
            this.ColumnSTBinCount2.HeaderText = "货位2数量";
            this.ColumnSTBinCount2.Name = "ColumnSTBinCount2";
            this.ColumnSTBinCount2.ReadOnly = true;
            this.ColumnSTBinCount2.Width = 98;
            // 
            // ColumnSTBin3
            // 
            this.ColumnSTBin3.DataPropertyName = "STBin3";
            this.ColumnSTBin3.HeaderText = "货位3";
            this.ColumnSTBin3.Name = "ColumnSTBin3";
            this.ColumnSTBin3.ReadOnly = true;
            this.ColumnSTBin3.Width = 70;
            // 
            // ColumnSTBinCount3
            // 
            this.ColumnSTBinCount3.DataPropertyName = "STBinCount3";
            this.ColumnSTBinCount3.HeaderText = "货位3数量";
            this.ColumnSTBinCount3.Name = "ColumnSTBinCount3";
            this.ColumnSTBinCount3.ReadOnly = true;
            this.ColumnSTBinCount3.Width = 98;
            // 
            // ColumnOperatorUser
            // 
            this.ColumnOperatorUser.DataPropertyName = "OperatorUser";
            this.ColumnOperatorUser.HeaderText = "盘点人";
            this.ColumnOperatorUser.Name = "ColumnOperatorUser";
            this.ColumnOperatorUser.ReadOnly = true;
            this.ColumnOperatorUser.Width = 76;
            // 
            // ColumnOperatorDateTime
            // 
            this.ColumnOperatorDateTime.DataPropertyName = "OperatorDateTime";
            this.ColumnOperatorDateTime.HeaderText = "盘点日期";
            this.ColumnOperatorDateTime.Name = "ColumnOperatorDateTime";
            this.ColumnOperatorDateTime.ReadOnly = true;
            this.ColumnOperatorDateTime.Width = 90;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.DataPropertyName = "ywtm";
            this.dataGridViewTextBoxColumn47.HeaderText = "一维条码";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.ReadOnly = true;
            this.dataGridViewTextBoxColumn47.Width = 90;
            // 
            // tabPageDelivery
            // 
            this.tabPageDelivery.Controls.Add(this.textBoxStockDeliveryPznd);
            this.tabPageDelivery.Controls.Add(this.label25);
            this.tabPageDelivery.Controls.Add(this.label26);
            this.tabPageDelivery.Controls.Add(this.textBoxStockDeliveryPzh);
            this.tabPageDelivery.Controls.Add(this.label27);
            this.tabPageDelivery.Controls.Add(this.textBoxStockDeliveryOrder_no);
            this.tabPageDelivery.Controls.Add(this.comboBoxStockDeliveryPlant);
            this.tabPageDelivery.Controls.Add(this.label28);
            this.tabPageDelivery.Controls.Add(this.comboBoxStockDeliverySLocation);
            this.tabPageDelivery.Controls.Add(this.label29);
            this.tabPageDelivery.Controls.Add(this.dataGridViewStockDelivery);
            this.tabPageDelivery.Controls.Add(this.btnStockDelivery);
            this.tabPageDelivery.Controls.Add(this.label30);
            this.tabPageDelivery.Controls.Add(this.textBoxStockDeliveryDes);
            this.tabPageDelivery.Controls.Add(this.label31);
            this.tabPageDelivery.Controls.Add(this.comboBoxStockDeliveryOpKind);
            this.tabPageDelivery.Controls.Add(this.textBoxStockDeliveryBarcode);
            this.tabPageDelivery.Controls.Add(this.label32);
            this.tabPageDelivery.Location = new System.Drawing.Point(4, 29);
            this.tabPageDelivery.Name = "tabPageDelivery";
            this.tabPageDelivery.Size = new System.Drawing.Size(1169, 532);
            this.tabPageDelivery.TabIndex = 5;
            this.tabPageDelivery.Text = "收货/冻结库退货统计";
            this.tabPageDelivery.UseVisualStyleBackColor = true;
            // 
            // textBoxStockDeliveryPznd
            // 
            this.textBoxStockDeliveryPznd.Location = new System.Drawing.Point(746, 54);
            this.textBoxStockDeliveryPznd.Name = "textBoxStockDeliveryPznd";
            this.textBoxStockDeliveryPznd.Size = new System.Drawing.Size(100, 26);
            this.textBoxStockDeliveryPznd.TabIndex = 5050;
            this.textBoxStockDeliveryPznd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(661, 57);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 20);
            this.label25.TabIndex = 358;
            this.label25.Text = "凭证年度：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(484, 57);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 20);
            this.label26.TabIndex = 357;
            this.label26.Text = "凭证号：";
            // 
            // textBoxStockDeliveryPzh
            // 
            this.textBoxStockDeliveryPzh.Location = new System.Drawing.Point(555, 54);
            this.textBoxStockDeliveryPzh.Name = "textBoxStockDeliveryPzh";
            this.textBoxStockDeliveryPzh.Size = new System.Drawing.Size(100, 26);
            this.textBoxStockDeliveryPzh.TabIndex = 5040;
            this.textBoxStockDeliveryPzh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(548, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 20);
            this.label27.TabIndex = 355;
            this.label27.Text = "订单号：";
            // 
            // textBoxStockDeliveryOrder_no
            // 
            this.textBoxStockDeliveryOrder_no.Location = new System.Drawing.Point(619, 20);
            this.textBoxStockDeliveryOrder_no.Name = "textBoxStockDeliveryOrder_no";
            this.textBoxStockDeliveryOrder_no.Size = new System.Drawing.Size(200, 26);
            this.textBoxStockDeliveryOrder_no.TabIndex = 5030;
            this.textBoxStockDeliveryOrder_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // comboBoxStockDeliveryPlant
            // 
            this.comboBoxStockDeliveryPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockDeliveryPlant.FormattingEnabled = true;
            this.comboBoxStockDeliveryPlant.Location = new System.Drawing.Point(251, 20);
            this.comboBoxStockDeliveryPlant.Name = "comboBoxStockDeliveryPlant";
            this.comboBoxStockDeliveryPlant.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockDeliveryPlant.TabIndex = 5010;
            this.comboBoxStockDeliveryPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxStockDeliveryPlant_SelectedIndexChanged);
            this.comboBoxStockDeliveryPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(194, 23);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(51, 20);
            this.label28.TabIndex = 351;
            this.label28.Text = "公司：";
            // 
            // comboBoxStockDeliverySLocation
            // 
            this.comboBoxStockDeliverySLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockDeliverySLocation.FormattingEnabled = true;
            this.comboBoxStockDeliverySLocation.Location = new System.Drawing.Point(442, 20);
            this.comboBoxStockDeliverySLocation.Name = "comboBoxStockDeliverySLocation";
            this.comboBoxStockDeliverySLocation.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockDeliverySLocation.TabIndex = 5020;
            this.comboBoxStockDeliverySLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(357, 23);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(79, 20);
            this.label29.TabIndex = 350;
            this.label29.Text = "库存地点：";
            // 
            // dataGridViewStockDelivery
            // 
            this.dataGridViewStockDelivery.AllowUserToAddRows = false;
            this.dataGridViewStockDelivery.AllowUserToResizeRows = false;
            this.dataGridViewStockDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockDelivery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStockDelivery.ColumnHeadersHeight = 30;
            this.dataGridViewStockDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStockDelivery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn42,
            this.dataGridViewTextBoxColumn43,
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn44,
            this.dataGridViewTextBoxColumn51});
            this.dataGridViewStockDelivery.Location = new System.Drawing.Point(5, 86);
            this.dataGridViewStockDelivery.MultiSelect = false;
            this.dataGridViewStockDelivery.Name = "dataGridViewStockDelivery";
            this.dataGridViewStockDelivery.ReadOnly = true;
            this.dataGridViewStockDelivery.RowHeadersVisible = false;
            this.dataGridViewStockDelivery.RowTemplate.Height = 23;
            this.dataGridViewStockDelivery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockDelivery.Size = new System.Drawing.Size(1161, 428);
            this.dataGridViewStockDelivery.TabIndex = 5090;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "order_no";
            this.dataGridViewTextBoxColumn34.HeaderText = "订单号";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Width = 76;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "operator_date";
            this.dataGridViewTextBoxColumn35.HeaderText = "操作时间";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            this.dataGridViewTextBoxColumn35.Width = 90;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "storeman";
            this.dataGridViewTextBoxColumn36.HeaderText = "保管员";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Width = 76;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "pzh";
            this.dataGridViewTextBoxColumn38.HeaderText = "凭证号";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Width = 76;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "pznd";
            this.dataGridViewTextBoxColumn39.HeaderText = "凭证年度";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Width = 90;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "bill_type";
            this.dataGridViewTextBoxColumn40.HeaderText = "单据类型";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Width = 90;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "product_no";
            this.dataGridViewTextBoxColumn41.HeaderText = "物料号";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            this.dataGridViewTextBoxColumn41.Width = 76;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "product_desc";
            this.dataGridViewTextBoxColumn42.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Width = 90;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "qty";
            this.dataGridViewTextBoxColumn43.HeaderText = "数量";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            this.dataGridViewTextBoxColumn43.Width = 62;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "gch";
            this.dataGridViewTextBoxColumn37.HeaderText = "公司";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            this.dataGridViewTextBoxColumn37.Width = 62;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "SL";
            this.dataGridViewTextBoxColumn44.HeaderText = "库存地点";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            this.dataGridViewTextBoxColumn44.Width = 90;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn51.HeaderText = "备注";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.ReadOnly = true;
            this.dataGridViewTextBoxColumn51.Width = 62;
            // 
            // btnStockDelivery
            // 
            this.btnStockDelivery.Enabled = false;
            this.btnStockDelivery.Location = new System.Drawing.Point(889, 23);
            this.btnStockDelivery.Name = "btnStockDelivery";
            this.btnStockDelivery.Size = new System.Drawing.Size(100, 40);
            this.btnStockDelivery.TabIndex = 5080;
            this.btnStockDelivery.Text = "筛选";
            this.btnStockDelivery.UseVisualStyleBackColor = true;
            this.btnStockDelivery.Click += new System.EventHandler(this.btnStockDelivery_Click);
            this.btnStockDelivery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(243, 57);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 20);
            this.label30.TabIndex = 347;
            this.label30.Text = "物料描述：";
            // 
            // textBoxStockDeliveryDes
            // 
            this.textBoxStockDeliveryDes.Location = new System.Drawing.Point(328, 54);
            this.textBoxStockDeliveryDes.Name = "textBoxStockDeliveryDes";
            this.textBoxStockDeliveryDes.Size = new System.Drawing.Size(150, 26);
            this.textBoxStockDeliveryDes.TabIndex = 5070;
            this.textBoxStockDeliveryDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(16, 57);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 20);
            this.label31.TabIndex = 345;
            this.label31.Text = "物料号：";
            // 
            // comboBoxStockDeliveryOpKind
            // 
            this.comboBoxStockDeliveryOpKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockDeliveryOpKind.FormattingEnabled = true;
            this.comboBoxStockDeliveryOpKind.Items.AddRange(new object[] {
            "所有",
            "收货",
            "冻结库退货"});
            this.comboBoxStockDeliveryOpKind.Location = new System.Drawing.Point(88, 20);
            this.comboBoxStockDeliveryOpKind.Name = "comboBoxStockDeliveryOpKind";
            this.comboBoxStockDeliveryOpKind.Size = new System.Drawing.Size(100, 28);
            this.comboBoxStockDeliveryOpKind.TabIndex = 5000;
            this.comboBoxStockDeliveryOpKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxStockDeliveryBarcode
            // 
            this.textBoxStockDeliveryBarcode.Location = new System.Drawing.Point(87, 54);
            this.textBoxStockDeliveryBarcode.Name = "textBoxStockDeliveryBarcode";
            this.textBoxStockDeliveryBarcode.Size = new System.Drawing.Size(150, 26);
            this.textBoxStockDeliveryBarcode.TabIndex = 5060;
            this.textBoxStockDeliveryBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 23);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 20);
            this.label32.TabIndex = 342;
            this.label32.Text = "统计类型：";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(1087, 37);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 9999;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.EventExit);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxStoreMan);
            this.groupBox1.Controls.Add(this.checkBoxEnableDate);
            this.groupBox1.Controls.Add(this.dateTimePickerDateTo);
            this.groupBox1.Controls.Add(this.dateTimePickerDateFrom);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1069, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工作信息统计检索";
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.Location = new System.Drawing.Point(495, 32);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.ReadOnly = true;
            this.textBoxStoreMan.Size = new System.Drawing.Size(100, 26);
            this.textBoxStoreMan.TabIndex = 40;
            this.textBoxStoreMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // checkBoxEnableDate
            // 
            this.checkBoxEnableDate.AutoSize = true;
            this.checkBoxEnableDate.Location = new System.Drawing.Point(405, 34);
            this.checkBoxEnableDate.Name = "checkBoxEnableDate";
            this.checkBoxEnableDate.Size = new System.Drawing.Size(84, 24);
            this.checkBoxEnableDate.TabIndex = 10;
            this.checkBoxEnableDate.Text = "保管员：";
            this.checkBoxEnableDate.UseVisualStyleBackColor = true;
            this.checkBoxEnableDate.CheckedChanged += new System.EventHandler(this.checkBoxEnableDate_CheckedChanged);
            this.checkBoxEnableDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dateTimePickerDateTo
            // 
            this.dateTimePickerDateTo.Enabled = false;
            this.dateTimePickerDateTo.Location = new System.Drawing.Point(265, 30);
            this.dateTimePickerDateTo.Name = "dateTimePickerDateTo";
            this.dateTimePickerDateTo.Size = new System.Drawing.Size(134, 26);
            this.dateTimePickerDateTo.TabIndex = 30;
            this.dateTimePickerDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dateTimePickerDateFrom
            // 
            this.dateTimePickerDateFrom.Enabled = false;
            this.dateTimePickerDateFrom.Location = new System.Drawing.Point(91, 30);
            this.dateTimePickerDateFrom.Name = "dateTimePickerDateFrom";
            this.dateTimePickerDateFrom.Size = new System.Drawing.Size(134, 26);
            this.dateTimePickerDateFrom.TabIndex = 20;
            this.dateTimePickerDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(231, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 20);
            this.label10.TabIndex = 81;
            this.label10.Text = "TO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 82;
            this.label1.Text = "范围日期：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(601, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 50;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // 工作日志统计
            // 
            this.ClientSize = new System.Drawing.Size(1199, 655);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControlStatistic);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "工作日志统计";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "统计检索";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControlStatistic.ResumeLayout(false);
            this.tabPageStockOp.ResumeLayout(false);
            this.tabPageStockOp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock_op)).EndInit();
            this.tabPageStockIn.ResumeLayout(false);
            this.tabPageStockIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockin)).EndInit();
            this.tabPageStockOut.ResumeLayout(false);
            this.tabPageStockOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockout)).EndInit();
            this.tabPageStockTake.ResumeLayout(false);
            this.tabPageStockTake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocktake)).EndInit();
            this.tabPageDelivery.ResumeLayout(false);
            this.tabPageDelivery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockDelivery)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        // Methods
        public 工作日志统计(UserInfo userItem, ArrayList userRoles)
        {
            this.userItem = null;
            this.userRoles = null;
            this.dtPlantList = null;
            this.dtStoreLocusList = null;
            this.thread = null;
            this.InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            if (userItem.isAdmin)
            {
                this.textBoxStoreMan.ReadOnly = false;
            }
            this.dvStock_op = new DataView();
            this.dtPlantList = DBOperate.GetPlantList(string.Empty);
            this.dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, string.Empty);
            this.comboBoxStock_opOpKind.SelectedIndex = 0;
            this.comboBoxStock_opSLocation.Items.Add("无");
            this.comboBoxStock_opSLocation.SelectedIndex = 0;
            this.comboBoxStock_opPlant.Items.Add("无");
            if (CommonFunction.IfHasData(this.dtPlantList))
            {
                foreach (DataRow row in this.dtPlantList.Rows)
                {
                    this.comboBoxStock_opPlant.Items.Add(row["PlantID"].ToString());
                }
            }
            this.comboBoxStock_opPlant.SelectedIndex = 0;
            this.comboBoxStockInOpKind.SelectedIndex = 0;
            this.comboBoxStockInSLocation.Items.Add("无");
            this.comboBoxStockInSLocation.SelectedIndex = 0;
            this.comboBoxStockInPlant.Items.Add("无");
            if (CommonFunction.IfHasData(this.dtPlantList))
            {
                foreach (DataRow row in this.dtPlantList.Rows)
                {
                    this.comboBoxStockInPlant.Items.Add(row["PlantID"].ToString());
                }
            }
            this.comboBoxStockInPlant.SelectedIndex = 0;
            this.comboBoxStockOutOpKind.SelectedIndex = 0;
            this.comboBoxStockOutSLocation.Items.Add("无");
            this.comboBoxStockOutSLocation.SelectedIndex = 0;
            this.comboBoxStockOutPlant.Items.Add("无");
            if (CommonFunction.IfHasData(this.dtPlantList))
            {
                foreach (DataRow row in this.dtPlantList.Rows)
                {
                    this.comboBoxStockOutPlant.Items.Add(row["PlantID"].ToString());
                }
            }
            this.comboBoxStockOutPlant.SelectedIndex = 0;
            this.comboBoxStockDeliveryOpKind.SelectedIndex = 0;
            this.comboBoxStockDeliverySLocation.Items.Add("无");
            this.comboBoxStockDeliverySLocation.SelectedIndex = 0;
            this.comboBoxStockDeliveryPlant.Items.Add("无");
            if (CommonFunction.IfHasData(this.dtPlantList))
            {
                foreach (DataRow row in this.dtPlantList.Rows)
                {
                    this.comboBoxStockDeliveryPlant.Items.Add(row["PlantID"].ToString());
                }
            }
            this.comboBoxStockDeliveryPlant.SelectedIndex = 0;
            this.comboBoxStockTakeSLocation.Items.Add("无");
            this.comboBoxStockTakeSLocation.SelectedIndex = 0;
            this.comboBoxStockTakePlant.Items.Add("无");
            if (CommonFunction.IfHasData(this.dtPlantList))
            {
                foreach (DataRow row in this.dtPlantList.Rows)
                {
                    this.comboBoxStockTakePlant.Items.Add(row["PlantID"].ToString());
                }
            }
            this.comboBoxStockTakePlant.SelectedIndex = 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(this.ShowWaitingMsg));
            this.thread.Start();
        }

        private void btnStockDelivery_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(this.btnStockDeliveryShowWaitingMsg));
            this.thread.Start();
        }

        private void btnStockDeliveryShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = " 1=1 ";
                str = (((str + (this.comboBoxStockDeliveryOpKind.Text.Equals("所有") ? string.Empty : (" and bill_type='" + this.comboBoxStockDeliveryOpKind.Text + "'")) + (this.comboBoxStockDeliveryPlant.Text.Equals("无") ? string.Empty : (" and gch='" + this.comboBoxStockDeliveryPlant.Text + "'"))) + (this.comboBoxStockDeliverySLocation.Text.Equals("无") ? string.Empty : (" and SL='" + this.comboBoxStockDeliverySLocation.Text + "'")) + (string.IsNullOrEmpty(this.textBoxStockDeliveryOrder_no.Text.Trim()) ? string.Empty : (" and order_no like '%" + this.textBoxStockDeliveryOrder_no.Text + "%'"))) + (string.IsNullOrEmpty(this.textBoxStockDeliveryPzh.Text.Trim()) ? string.Empty : (" and pzh like '%" + this.textBoxStockDeliveryPzh.Text + "%'")) + (string.IsNullOrEmpty(this.textBoxStockDeliveryPznd.Text.Trim()) ? string.Empty : (" and pznd like '%" + this.textBoxStockDeliveryPznd.Text + "%'"))) + (string.IsNullOrEmpty(this.textBoxStockDeliveryBarcode.Text.Trim()) ? string.Empty : (" and product_no like '%" + this.textBoxStockDeliveryBarcode.Text + "%'")) + (string.IsNullOrEmpty(this.textBoxStockDeliveryDes.Text.Trim()) ? string.Empty : (" and product_desc like '%" + this.textBoxStockDeliveryDes.Text + "%'"));
                this.dvStockdelivery.RowFilter = str;
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStockDeliveryShowWaitingMsg()
        {
            base.Invoke(new EventHandler(this.btnStockDeliveryShowMsg));
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(this.btnStockInShowWaitingMsg));
            this.thread.Start();
        }

        private void btnStockInShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = " 1=1 ";
                str = (((str + (this.comboBoxStockInOpKind.Text.Equals("所有") ? string.Empty : (" and bill_type='" + this.comboBoxStockInOpKind.Text + "'")) + (this.comboBoxStockInPlant.Text.Equals("无") ? string.Empty : (" and gch='" + this.comboBoxStockInPlant.Text + "'"))) + (this.comboBoxStockInSLocation.Text.Equals("无") ? string.Empty : (" and SL='" + this.comboBoxStockInSLocation.Text + "'")) + (string.IsNullOrEmpty(this.textBoxStockInOrder_no.Text.Trim()) ? string.Empty : (" and order_no like '%" + this.textBoxStockInOrder_no.Text + "%'"))) + (string.IsNullOrEmpty(this.textBoxStockInPzh.Text.Trim()) ? string.Empty : (" and pzh like '%" + this.textBoxStockInPzh.Text + "%'")) + (string.IsNullOrEmpty(this.textBoxStockInPznd.Text.Trim()) ? string.Empty : (" and pznd like '%" + this.textBoxStockInPznd.Text + "%'")))
                    + (string.IsNullOrEmpty(this.textBoxStockInBarcode.Text.Trim()) ? string.Empty : (" and (product_barcode like '%" + this.textBoxStockInBarcode.Text + "%' or isnull(ywtm,'') like '%" + this.textBoxStockInBarcode.Text + "%')")) 
                    + (string.IsNullOrEmpty(this.textBoxStockInDes.Text.Trim()) ? string.Empty : (" and product_desc like '%" + this.textBoxStockInDes.Text + "%'"));
                this.dvStockin.RowFilter = str;
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStockInShowWaitingMsg()
        {
            base.Invoke(new EventHandler(this.btnStockInShowMsg));
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(this.btnStockOutShowWaitingMsg));
            this.thread.Start();
        }

        private void btnStockOutShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = " 1=1 ";
                str = (((str + (this.comboBoxStockOutOpKind.Text.Equals("所有") ? string.Empty : (" and bill_type='" + this.comboBoxStockOutOpKind.Text + "'")) + (this.comboBoxStockOutPlant.Text.Equals("无") ? string.Empty : (" and gch='" + this.comboBoxStockOutPlant.Text + "'"))) + (this.comboBoxStockOutSLocation.Text.Equals("无") ? string.Empty : (" and SL='" + this.comboBoxStockOutSLocation.Text + "'")) + (string.IsNullOrEmpty(this.textBoxStockOutOrder_no.Text.Trim()) ? string.Empty : (" and order_no like '%" + this.textBoxStockOutOrder_no.Text + "%'"))) + (string.IsNullOrEmpty(this.textBoxStockOutPzh.Text.Trim()) ? string.Empty : (" and pzh like '%" + this.textBoxStockOutPzh.Text + "%'")) + (string.IsNullOrEmpty(this.textBoxStockOutPznd.Text.Trim()) ? string.Empty : (" and pznd like '%" + this.textBoxStockOutPznd.Text + "%'")))
                    + (string.IsNullOrEmpty(this.textBoxStockOutBarcode.Text.Trim()) ? string.Empty : (" and (product_barcode like '%" + this.textBoxStockOutBarcode.Text + "%' or isnull(ywtm,'') like '%" + this.textBoxStockOutBarcode.Text + "%')")) 
                    + (string.IsNullOrEmpty(this.textBoxStockOutDes.Text.Trim()) ? string.Empty : (" and product_desc like '%" + this.textBoxStockOutDes.Text + "%'"));
                this.dvStockout.RowFilter = str;
            }
            catch
            {
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStockOutShowWaitingMsg()
        {
            base.Invoke(new EventHandler(this.btnStockOutShowMsg));
        }

        private void btnStockTake_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(this.btnStockTakeShowWaitingMsg));
            this.thread.Start();
        }

        private void btnStockTakeShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = " 1=1 ";
                str = ((str + (string.IsNullOrEmpty(this.textBoxStockTakeOrder_no.Text.Trim()) ? string.Empty : (" and STSerial='" + this.textBoxStockTakeOrder_no.Text + "'"))) + (this.comboBoxStockTakePlant.Text.Equals("无") ? string.Empty : (" and Plant='" + this.comboBoxStockTakePlant.Text + "'")) + (this.comboBoxStockTakeSLocation.Text.Equals("无") ? string.Empty : (" and SLocation='" + this.comboBoxStockTakeSLocation.Text + "'")))
                    + (string.IsNullOrEmpty(this.textBoxStockTakeBarcode.Text.Trim()) ? string.Empty : (" and (Material like '%" + this.textBoxStockTakeBarcode.Text + "%' or isnull(ywtm,'') like '%" + this.textBoxStockTakeBarcode.Text + "%')")) 
                    + (string.IsNullOrEmpty(this.textBoxStockTakeDes.Text.Trim()) ? string.Empty : (" and MDesc like '%" + this.textBoxStockTakeDes.Text + "%'"));
                this.dvStocktake.RowFilter = str;
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnStockTakeShowWaitingMsg()
        {
            base.Invoke(new EventHandler(this.btnStockTakeShowMsg));
        }

        private void btStockOp_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(this.btStockOpShowWaitingMsg));
            this.thread.Start();
        }

        private void btStockOpShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = " 1=1 ";
                //str = ((str + (this.comboBoxStock_opOpKind.Text.Equals("所有") ? string.Empty : (" and bill_type='" + this.comboBoxStock_opOpKind.Text + "'"))) + (this.comboBoxStock_opPlant.Text.Equals("无") ? string.Empty : (" and gch='" + this.comboBoxStock_opPlant.Text + "'")) + (this.comboBoxStock_opSLocation.Text.Equals("无") ? string.Empty : (" and SL='" + this.comboBoxStock_opSLocation.Text + "'"))) + (string.IsNullOrEmpty(this.textBoxStock_opBarcode.Text.Trim()) ? string.Empty : (" and product_barcode like '%" + this.textBoxStock_opBarcode.Text + "%'")) + (string.IsNullOrEmpty(this.textBoxStock_opDes.Text.Trim()) ? string.Empty : (" and product_desc like '%" + this.textBoxStock_opDes.Text + "%'"));

                str = (
                        (
                         str + (this.comboBoxStock_opOpKind.Text.Equals("所有") ? string.Empty : (" and bill_type='" + this.comboBoxStock_opOpKind.Text + "'"))
                        )
                      + (this.comboBoxStock_opPlant.Text.Equals("无") ? string.Empty : (" and gch='" + this.comboBoxStock_opPlant.Text + "'"))
                      + (this.comboBoxStock_opSLocation.Text.Equals("无") ? string.Empty : (" and SL='" + this.comboBoxStock_opSLocation.Text + "'"))
                      )

                    + (string.IsNullOrEmpty(this.textBoxStock_opBarcode.Text.Trim()) ? string.Empty : (" and (product_barcode like '%" + this.textBoxStock_opBarcode.Text + "%' or isnull(ywtm,'') like '%" + this.textBoxStock_opBarcode.Text + "%')")) 
                    + (string.IsNullOrEmpty(this.textBoxStock_opDes.Text.Trim()) ? string.Empty : (" and product_desc like '%" + this.textBoxStock_opDes.Text + "%'"));

                this.dvStock_op.RowFilter = str;
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btStockOpShowWaitingMsg()
        {
            base.Invoke(new EventHandler(this.btStockOpShowMsg));
        }

        private void checkBoxEnableDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePickerDateFrom.Enabled = this.dateTimePickerDateTo.Enabled = this.checkBoxEnableDate.Checked;
        }

        private void comboBoxStock_opPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxStock_opSLocation.Items.Clear();
            this.comboBoxStock_opSLocation.Items.Add("无");

            foreach (DataRow row in this.dtStoreLocusList.Select("PlantID='" + this.comboBoxStock_opPlant.Text + "'"))
            {
                this.comboBoxStock_opSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            this.comboBoxStock_opSLocation.SelectedIndex = 0;
        }

        private void comboBoxStockDeliveryPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxStockDeliverySLocation.Items.Clear();
            this.comboBoxStockDeliverySLocation.Items.Add("无");

            foreach (DataRow row in this.dtStoreLocusList.Select("PlantID='" + this.comboBoxStockDeliveryPlant.Text + "'"))
            {
                this.comboBoxStockDeliverySLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            this.comboBoxStockDeliverySLocation.SelectedIndex = 0;
        }

        private void comboBoxStockInPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxStockInSLocation.Items.Clear();
            this.comboBoxStockInSLocation.Items.Add("无");

            foreach (DataRow row in this.dtStoreLocusList.Select("PlantID='" + this.comboBoxStockInPlant.Text + "'"))
            {
                this.comboBoxStockInSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            this.comboBoxStockInSLocation.SelectedIndex = 0;
        }

        private void comboBoxStockOutPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxStockOutSLocation.Items.Clear();
            this.comboBoxStockOutSLocation.Items.Add("无");

            foreach (DataRow row in this.dtStoreLocusList.Select("PlantID='" + this.comboBoxStockOutPlant.Text + "'"))
            {
                this.comboBoxStockOutSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            this.comboBoxStockOutSLocation.SelectedIndex = 0;
        }

        private void comboBoxStockTakePlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxStockTakeSLocation.Items.Clear();
            this.comboBoxStockTakeSLocation.Items.Add("无");

            foreach (DataRow row in this.dtStoreLocusList.Select("PlantID='" + this.comboBoxStockTakePlant.Text + "'"))
            {
                this.comboBoxStockTakeSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            this.comboBoxStockTakeSLocation.SelectedIndex = 0;
        }

        private void EventExit(object sender, EventArgs e)
        {
            base.Close();
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
                bool flag = this.checkBoxEnableDate.Checked;
                //this.dsStatistic = DBOperate.StatisticInfo(this.textBoxStoreMan.Text, flag ? this.dateTimePickerDateFrom.Value.ToShortDateString() : string.Empty, flag ? this.dateTimePickerDateTo.Value.ToShortDateString() : string.Empty);
                this.dsStatistic = BL.ClsCommon.StatisticInfo_New(this.textBoxStoreMan.Text, flag ? this.dateTimePickerDateFrom.Value.ToShortDateString() : string.Empty, flag ? this.dateTimePickerDateTo.Value.ToShortDateString() : string.Empty);

                if (this.dsStatistic.Tables.Count != 0)
                {
                    this.dvStock_op = this.dsStatistic.Tables[1].DefaultView;
                    this.dvStockin = this.dsStatistic.Tables[2].DefaultView;
                    this.dvStockout = this.dsStatistic.Tables[3].DefaultView;
                    this.dvStocktake = this.dsStatistic.Tables[4].DefaultView;
                    this.dvStockdelivery = this.dsStatistic.Tables[5].DefaultView;
                    this.btStockOp.Enabled = true;
                    this.btnStockIn.Enabled = true;
                    this.btnStockOut.Enabled = true;
                    this.btnStockTake.Enabled = true;
                    this.btnStockDelivery.Enabled = true;
                }
                else
                {
                    this.btStockOp.Enabled = false;
                    this.btnStockIn.Enabled = false;
                    this.btnStockOut.Enabled = false;
                    this.btnStockTake.Enabled = false;
                    this.btnStockDelivery.Enabled = false;
                }

                this.dataGridViewStock_op.DataSource = this.dvStock_op;
                this.dataGridViewStockin.DataSource = this.dvStockin;
                this.dataGridViewStockout.DataSource = this.dvStockout;
                this.dataGridViewStocktake.DataSource = this.dvStocktake;
                this.dataGridViewStockDelivery.DataSource = this.dvStockdelivery;
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
    }
}
