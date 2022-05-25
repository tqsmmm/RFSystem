using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using RFSystem.CommonClass;

namespace RFSystem.ArriveStore
{
    public partial class 到库货物信息拆分 : Form
    {
        // Fields
        private ArrayList arriveListInfo;
        private Button btnAddF;
        private Button btnAddS;
        private Button btnCancel;
        private Button btnDelF;
        private Button btnDelS;
        private Button btnSplit;
        private Button btnSubmit;
        private Button btnUnsplit;
        private DataGridView dataGridViewStorageInfoF;
        private DataGridView dataGridViewStorageInfoS;
        private ArrayList getStorageInfo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBoxInputInfo;
        private Label label1;
        private Label label10;
        private Label label2;
        private Label label20;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelArriveListID;
        private Regex regex;
        private DataTable storageInfoListF;
        private DataTable storageInfoListS;
        private TextBox textBoxAcceptAmount;
        private TextBox textBoxAcceptAmountF;
        private TextBox textBoxAcceptAmountS;
        private TextBox textBoxAcceptWeight;
        private TextBox textBoxAcceptWeightF;
        private TextBox textBoxAcceptWeightS;
        private TextBox textBoxConsignmentAmount;
        private TextBox textBoxConsignmentAmountF;
        private TextBox textBoxConsignmentAmountS;
        private DataGridViewTextBoxColumn ColumnStorePosition;
        private DataGridViewTextBoxColumn ColumnAmount;
        private DataGridViewTextBoxColumn ColumnRemark;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private TextBox textBoxUnDealAmount;

        private void InitializeComponent()
        {
            this.btnUnsplit = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxInputInfo = new System.Windows.Forms.GroupBox();
            this.textBoxUnDealAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelArriveListID = new System.Windows.Forms.Label();
            this.textBoxAcceptWeight = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxAcceptAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxConsignmentAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelF = new System.Windows.Forms.Button();
            this.btnAddF = new System.Windows.Forms.Button();
            this.dataGridViewStorageInfoF = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSplit = new System.Windows.Forms.Button();
            this.textBoxAcceptWeightF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAcceptAmountF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxConsignmentAmountF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAcceptWeightS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAcceptAmountS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxConsignmentAmountS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDelS = new System.Windows.Forms.Button();
            this.btnAddS = new System.Windows.Forms.Button();
            this.dataGridViewStorageInfoS = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStorePosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxInputInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfoF)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfoS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUnsplit
            // 
            this.btnUnsplit.Enabled = false;
            this.btnUnsplit.Location = new System.Drawing.Point(676, 423);
            this.btnUnsplit.Name = "btnUnsplit";
            this.btnUnsplit.Size = new System.Drawing.Size(100, 40);
            this.btnUnsplit.TabIndex = 1219;
            this.btnUnsplit.Text = "取消拆分";
            this.btnUnsplit.UseVisualStyleBackColor = true;
            this.btnUnsplit.Click += new System.EventHandler(this.btnUnsplit_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(570, 423);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 40);
            this.btnSubmit.TabIndex = 1216;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(782, 423);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 1217;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxInputInfo
            // 
            this.groupBoxInputInfo.Controls.Add(this.textBoxUnDealAmount);
            this.groupBoxInputInfo.Controls.Add(this.label10);
            this.groupBoxInputInfo.Controls.Add(this.labelArriveListID);
            this.groupBoxInputInfo.Controls.Add(this.textBoxAcceptWeight);
            this.groupBoxInputInfo.Controls.Add(this.label20);
            this.groupBoxInputInfo.Controls.Add(this.textBoxAcceptAmount);
            this.groupBoxInputInfo.Controls.Add(this.label7);
            this.groupBoxInputInfo.Controls.Add(this.textBoxConsignmentAmount);
            this.groupBoxInputInfo.Controls.Add(this.label8);
            this.groupBoxInputInfo.Controls.Add(this.label1);
            this.groupBoxInputInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInputInfo.Name = "groupBoxInputInfo";
            this.groupBoxInputInfo.Size = new System.Drawing.Size(870, 73);
            this.groupBoxInputInfo.TabIndex = 1214;
            this.groupBoxInputInfo.TabStop = false;
            this.groupBoxInputInfo.Text = "到库货物信息";
            // 
            // textBoxUnDealAmount
            // 
            this.textBoxUnDealAmount.Location = new System.Drawing.Point(705, 22);
            this.textBoxUnDealAmount.Name = "textBoxUnDealAmount";
            this.textBoxUnDealAmount.ReadOnly = true;
            this.textBoxUnDealAmount.Size = new System.Drawing.Size(50, 26);
            this.textBoxUnDealAmount.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(620, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "剩余件数：";
            // 
            // labelArriveListID
            // 
            this.labelArriveListID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelArriveListID.ForeColor = System.Drawing.Color.Red;
            this.labelArriveListID.Location = new System.Drawing.Point(91, 22);
            this.labelArriveListID.Name = "labelArriveListID";
            this.labelArriveListID.Size = new System.Drawing.Size(100, 26);
            this.labelArriveListID.TabIndex = 0;
            this.labelArriveListID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAcceptWeight
            // 
            this.textBoxAcceptWeight.Location = new System.Drawing.Point(564, 22);
            this.textBoxAcceptWeight.Name = "textBoxAcceptWeight";
            this.textBoxAcceptWeight.ReadOnly = true;
            this.textBoxAcceptWeight.Size = new System.Drawing.Size(50, 26);
            this.textBoxAcceptWeight.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(479, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "实收重量：";
            // 
            // textBoxAcceptAmount
            // 
            this.textBoxAcceptAmount.Location = new System.Drawing.Point(423, 22);
            this.textBoxAcceptAmount.Name = "textBoxAcceptAmount";
            this.textBoxAcceptAmount.ReadOnly = true;
            this.textBoxAcceptAmount.Size = new System.Drawing.Size(50, 26);
            this.textBoxAcceptAmount.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "实收件数：";
            // 
            // textBoxConsignmentAmount
            // 
            this.textBoxConsignmentAmount.Location = new System.Drawing.Point(282, 22);
            this.textBoxConsignmentAmount.Name = "textBoxConsignmentAmount";
            this.textBoxConsignmentAmount.ReadOnly = true;
            this.textBoxConsignmentAmount.Size = new System.Drawing.Size(50, 26);
            this.textBoxConsignmentAmount.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "运单件数：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "到库单号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelF
            // 
            this.btnDelF.Enabled = false;
            this.btnDelF.Location = new System.Drawing.Point(764, 117);
            this.btnDelF.Name = "btnDelF";
            this.btnDelF.Size = new System.Drawing.Size(100, 40);
            this.btnDelF.TabIndex = 512;
            this.btnDelF.Text = "删除";
            this.btnDelF.UseVisualStyleBackColor = true;
            this.btnDelF.Click += new System.EventHandler(this.btnDelF_Click);
            // 
            // btnAddF
            // 
            this.btnAddF.Enabled = false;
            this.btnAddF.Location = new System.Drawing.Point(764, 71);
            this.btnAddF.Name = "btnAddF";
            this.btnAddF.Size = new System.Drawing.Size(100, 40);
            this.btnAddF.TabIndex = 511;
            this.btnAddF.Text = "新增";
            this.btnAddF.UseVisualStyleBackColor = true;
            this.btnAddF.Click += new System.EventHandler(this.btnAddF_Click);
            // 
            // dataGridViewStorageInfoF
            // 
            this.dataGridViewStorageInfoF.AllowUserToAddRows = false;
            this.dataGridViewStorageInfoF.AllowUserToResizeRows = false;
            this.dataGridViewStorageInfoF.ColumnHeadersHeight = 30;
            this.dataGridViewStorageInfoF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStorageInfoF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStorePosition,
            this.ColumnAmount,
            this.ColumnRemark});
            this.dataGridViewStorageInfoF.Location = new System.Drawing.Point(8, 57);
            this.dataGridViewStorageInfoF.MultiSelect = false;
            this.dataGridViewStorageInfoF.Name = "dataGridViewStorageInfoF";
            this.dataGridViewStorageInfoF.ReadOnly = true;
            this.dataGridViewStorageInfoF.RowHeadersWidth = 30;
            this.dataGridViewStorageInfoF.RowTemplate.Height = 23;
            this.dataGridViewStorageInfoF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStorageInfoF.Size = new System.Drawing.Size(750, 97);
            this.dataGridViewStorageInfoF.TabIndex = 510;
            this.dataGridViewStorageInfoF.SelectionChanged += new System.EventHandler(this.dataGridViewStorageInfoF_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSplit);
            this.groupBox2.Controls.Add(this.textBoxAcceptWeightF);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxAcceptAmountF);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxConsignmentAmountF);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnDelF);
            this.groupBox2.Controls.Add(this.btnAddF);
            this.groupBox2.Controls.Add(this.dataGridViewStorageInfoF);
            this.groupBox2.Location = new System.Drawing.Point(12, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(870, 160);
            this.groupBox2.TabIndex = 1215;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拆分存放信息";
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(764, 25);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(100, 40);
            this.btnSplit.TabIndex = 1217;
            this.btnSplit.Text = "拆分";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // textBoxAcceptWeightF
            // 
            this.textBoxAcceptWeightF.Location = new System.Drawing.Point(455, 25);
            this.textBoxAcceptWeightF.Name = "textBoxAcceptWeightF";
            this.textBoxAcceptWeightF.ReadOnly = true;
            this.textBoxAcceptWeightF.Size = new System.Drawing.Size(91, 26);
            this.textBoxAcceptWeightF.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "实收重量：";
            // 
            // textBoxAcceptAmountF
            // 
            this.textBoxAcceptAmountF.Location = new System.Drawing.Point(273, 25);
            this.textBoxAcceptAmountF.Name = "textBoxAcceptAmountF";
            this.textBoxAcceptAmountF.ReadOnly = true;
            this.textBoxAcceptAmountF.Size = new System.Drawing.Size(91, 26);
            this.textBoxAcceptAmountF.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "实收件数：";
            // 
            // textBoxConsignmentAmountF
            // 
            this.textBoxConsignmentAmountF.Location = new System.Drawing.Point(91, 25);
            this.textBoxConsignmentAmountF.Name = "textBoxConsignmentAmountF";
            this.textBoxConsignmentAmountF.ReadOnly = true;
            this.textBoxConsignmentAmountF.Size = new System.Drawing.Size(91, 26);
            this.textBoxConsignmentAmountF.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "运单件数：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAcceptWeightS);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxAcceptAmountS);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxConsignmentAmountS);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnDelS);
            this.groupBox1.Controls.Add(this.btnAddS);
            this.groupBox1.Controls.Add(this.dataGridViewStorageInfoS);
            this.groupBox1.Location = new System.Drawing.Point(12, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 160);
            this.groupBox1.TabIndex = 1220;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拆分存放信息";
            // 
            // textBoxAcceptWeightS
            // 
            this.textBoxAcceptWeightS.Location = new System.Drawing.Point(455, 25);
            this.textBoxAcceptWeightS.Name = "textBoxAcceptWeightS";
            this.textBoxAcceptWeightS.Size = new System.Drawing.Size(91, 26);
            this.textBoxAcceptWeightS.TabIndex = 518;
            this.textBoxAcceptWeightS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            this.textBoxAcceptWeightS.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 514;
            this.label5.Text = "实收重量：";
            // 
            // textBoxAcceptAmountS
            // 
            this.textBoxAcceptAmountS.Location = new System.Drawing.Point(273, 25);
            this.textBoxAcceptAmountS.Name = "textBoxAcceptAmountS";
            this.textBoxAcceptAmountS.Size = new System.Drawing.Size(91, 26);
            this.textBoxAcceptAmountS.TabIndex = 517;
            this.textBoxAcceptAmountS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            this.textBoxAcceptAmountS.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 513;
            this.label6.Text = "实收件数：";
            // 
            // textBoxConsignmentAmountS
            // 
            this.textBoxConsignmentAmountS.Location = new System.Drawing.Point(91, 25);
            this.textBoxConsignmentAmountS.Name = "textBoxConsignmentAmountS";
            this.textBoxConsignmentAmountS.Size = new System.Drawing.Size(91, 26);
            this.textBoxConsignmentAmountS.TabIndex = 516;
            this.textBoxConsignmentAmountS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            this.textBoxConsignmentAmountS.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 515;
            this.label9.Text = "运单件数：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelS
            // 
            this.btnDelS.Enabled = false;
            this.btnDelS.Location = new System.Drawing.Point(764, 104);
            this.btnDelS.Name = "btnDelS";
            this.btnDelS.Size = new System.Drawing.Size(100, 40);
            this.btnDelS.TabIndex = 512;
            this.btnDelS.Text = "删除";
            this.btnDelS.UseVisualStyleBackColor = true;
            this.btnDelS.Click += new System.EventHandler(this.btnDelS_Click);
            // 
            // btnAddS
            // 
            this.btnAddS.Enabled = false;
            this.btnAddS.Location = new System.Drawing.Point(764, 58);
            this.btnAddS.Name = "btnAddS";
            this.btnAddS.Size = new System.Drawing.Size(100, 40);
            this.btnAddS.TabIndex = 511;
            this.btnAddS.Text = "新增";
            this.btnAddS.UseVisualStyleBackColor = true;
            this.btnAddS.Click += new System.EventHandler(this.btnAddS_Click);
            // 
            // dataGridViewStorageInfoS
            // 
            this.dataGridViewStorageInfoS.AllowUserToAddRows = false;
            this.dataGridViewStorageInfoS.AllowUserToResizeRows = false;
            this.dataGridViewStorageInfoS.ColumnHeadersHeight = 30;
            this.dataGridViewStorageInfoS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStorageInfoS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewStorageInfoS.Location = new System.Drawing.Point(8, 58);
            this.dataGridViewStorageInfoS.MultiSelect = false;
            this.dataGridViewStorageInfoS.Name = "dataGridViewStorageInfoS";
            this.dataGridViewStorageInfoS.ReadOnly = true;
            this.dataGridViewStorageInfoS.RowHeadersWidth = 30;
            this.dataGridViewStorageInfoS.RowTemplate.Height = 23;
            this.dataGridViewStorageInfoS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStorageInfoS.Size = new System.Drawing.Size(750, 96);
            this.dataGridViewStorageInfoS.TabIndex = 510;
            this.dataGridViewStorageInfoS.SelectionChanged += new System.EventHandler(this.dataGridViewStorageInfoS_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StorePosition";
            this.dataGridViewTextBoxColumn1.HeaderText = "库位";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 105;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn2.HeaderText = "库位数量";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn3.HeaderText = "备注";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 400;
            // 
            // ColumnStorePosition
            // 
            this.ColumnStorePosition.DataPropertyName = "StorePosition";
            this.ColumnStorePosition.HeaderText = "库位";
            this.ColumnStorePosition.Name = "ColumnStorePosition";
            this.ColumnStorePosition.ReadOnly = true;
            this.ColumnStorePosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnStorePosition.Width = 105;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "库位数量";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnRemark
            // 
            this.ColumnRemark.DataPropertyName = "Remark";
            this.ColumnRemark.HeaderText = "备注";
            this.ColumnRemark.Name = "ColumnRemark";
            this.ColumnRemark.ReadOnly = true;
            this.ColumnRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRemark.Width = 400;
            // 
            // 到库货物信息拆分
            // 
            this.ClientSize = new System.Drawing.Size(894, 475);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUnsplit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBoxInputInfo);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "到库货物信息拆分";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "到库货物信息拆分";
            this.Shown += new System.EventHandler(this.到库货物信息拆分_Shown);
            this.groupBoxInputInfo.ResumeLayout(false);
            this.groupBoxInputInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfoF)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfoS)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 到库货物信息拆分(ArrayList arriveListInfo)
        {
            this.storageInfoListF = null;
            this.storageInfoListS = null;
            this.getStorageInfo = null;
            this.arriveListInfo = null;
            this.InitializeComponent();
            this.regex = new Regex(ConstDefine.REGEX_NUM);
            this.storageInfoListF = new DataTable();
            this.storageInfoListF.Columns.Add("StorePosition");
            this.storageInfoListF.Columns.Add("Amount");
            this.storageInfoListF.Columns.Add("Remark");
            this.dataGridViewStorageInfoF.DataSource = this.storageInfoListF;
            this.storageInfoListS = new DataTable();
            this.storageInfoListS.Columns.Add("StorePosition");
            this.storageInfoListS.Columns.Add("Amount");
            this.storageInfoListS.Columns.Add("Remark");
            this.dataGridViewStorageInfoS.DataSource = this.storageInfoListS;
            this.arriveListInfo = arriveListInfo;
            this.labelArriveListID.Text = arriveListInfo[0].ToString();
            this.textBoxConsignmentAmount.Text = arriveListInfo[1].ToString();
            this.textBoxAcceptAmount.Text = arriveListInfo[2].ToString();
            this.textBoxAcceptWeight.Text = arriveListInfo[3].ToString();
            this.textBoxUnDealAmount.Text = arriveListInfo[4].ToString();
        }

        private void btnAddF_Click(object sender, EventArgs e)
        {
            到库货物存放信息 到库货物存放信息 = new 到库货物存放信息();
            if (到库货物存放信息.ShowDialog() == DialogResult.OK)
            {
                this.getStorageInfo = 到库货物存放信息.ArriveStoreStorageInfo;
                this.storageInfoListF.Rows.Add(new object[] { (string)this.getStorageInfo[0], (int)this.getStorageInfo[1], (string)this.getStorageInfo[2] });
            }
        }

        private void btnAddS_Click(object sender, EventArgs e)
        {
            到库货物存放信息 到库货物存放信息 = new 到库货物存放信息();
            if (到库货物存放信息.ShowDialog() == DialogResult.OK)
            {
                this.getStorageInfo = 到库货物存放信息.ArriveStoreStorageInfo;
                this.storageInfoListS.Rows.Add(new object[] { (string)this.getStorageInfo[0], (int)this.getStorageInfo[1], (string)this.getStorageInfo[2] });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnDelF_Click(object sender, EventArgs e)
        {
            this.storageInfoListF.Rows.RemoveAt(this.dataGridViewStorageInfoF.SelectedRows[0].Index);
        }

        private void btnDelS_Click(object sender, EventArgs e)
        {
            this.storageInfoListS.Rows.RemoveAt(this.dataGridViewStorageInfoS.SelectedRows[0].Index);
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            if ((this.textBoxAcceptAmountS.Text.Equals(string.Empty) || this.textBoxAcceptWeightS.Text.Equals(string.Empty)) || this.textBoxConsignmentAmountS.Text.Equals(string.Empty))
            {
                CommonFunction.Sys_MsgBox("请填写完整信息");
            }
            else
            {
                if (Convert.ToDecimal(this.textBoxAcceptAmountS.Text) > Convert.ToDecimal(this.textBoxUnDealAmount.Text))
                {
                    str = "AcceptAmount";
                }
                else if (Convert.ToDecimal(this.textBoxConsignmentAmountS.Text) > Convert.ToDecimal(this.textBoxConsignmentAmount.Text))
                {
                    str = "ConsignmentAmount";
                }
                else if (Convert.ToDecimal(this.textBoxAcceptWeightS.Text) > Convert.ToDecimal(this.textBoxAcceptWeight.Text))
                {
                    str = "Split";
                }
                if (str.Equals(string.Empty))
                {
                    this.textBoxAcceptAmountF.Text = Convert.ToString((double)(Convert.ToDouble(this.textBoxAcceptAmount.Text) - Convert.ToDouble(this.textBoxAcceptAmountS.Text)));
                    this.textBoxAcceptWeightF.Text = Convert.ToString((double)(Convert.ToDouble(this.textBoxAcceptWeight.Text) - Convert.ToDouble(this.textBoxAcceptWeightS.Text)));
                    this.textBoxConsignmentAmountF.Text = Convert.ToString((double)(Convert.ToDouble(this.textBoxConsignmentAmount.Text) - Convert.ToDouble(this.textBoxConsignmentAmountS.Text)));
                    this.btnSplit.Enabled = false;
                    this.btnAddF.Enabled = true;
                    this.btnAddS.Enabled = true;
                    this.btnSubmit.Enabled = true;
                    this.btnUnsplit.Enabled = true;
                }
                else
                {
                    string str2 = str;
                    if (str2 != null)
                    {
                        if (!(str2 == "AcceptAmount"))
                        {
                            if (str2 == "ConsignmentAmount")
                            {
                                CommonFunction.Sys_MsgBox("运单件数的数量大于剩余货物数量");
                            }
                            else if (str2 == "Split")
                            {
                                CommonFunction.Sys_MsgBox("拆分的数量大于剩余货物数量");
                            }
                        }
                        else
                        {
                            CommonFunction.Sys_MsgBox("实收重量的数量大于剩余货物数量");
                        }
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            decimal num = 0M;
            decimal num2 = 0M;
            foreach (DataRow row in this.storageInfoListF.Rows)
            {
                num += Convert.ToDecimal(row["Amount"]);
            }
            foreach (DataRow row in this.storageInfoListS.Rows)
            {
                num2 += Convert.ToDecimal(row["Amount"]);
            }
            if (num.ToString().Equals(this.textBoxAcceptAmountF.Text) && num2.ToString().Equals(this.textBoxAcceptAmountS.Text))
            {
                ArrayList billInfo = new ArrayList();
                billInfo.Add(this.labelArriveListID.Text);
                billInfo.Add(this.textBoxConsignmentAmountS.Text);
                billInfo.Add(this.textBoxAcceptAmountS.Text);
                billInfo.Add(this.textBoxAcceptWeightS.Text);
                this.UpdateData(billInfo, this.storageInfoListF, this.storageInfoListS);
            }
            else
            {
                CommonFunction.Sys_MsgBox("实收数量和临时入库数量不一致，请确认");
            }
        }

        private void btnUnsplit_Click(object sender, EventArgs e)
        {
            this.btnSplit.Enabled = true;
            this.btnAddF.Enabled = false;
            this.btnAddS.Enabled = false;
            this.btnSubmit.Enabled = false;
            this.btnUnsplit.Enabled = false;
            this.storageInfoListF.Rows.Clear();
            this.storageInfoListS.Rows.Clear();
        }

        private void dataGridViewStorageInfoF_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewStorageInfoF.Rows != null) && (this.dataGridViewStorageInfoF.SelectedRows.Count != 0))
            {
                this.btnDelF.Enabled = true;
            }
            else
            {
                this.btnDelF.Enabled = false;
            }
        }

        private void dataGridViewStorageInfoS_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewStorageInfoS.Rows != null) && (this.dataGridViewStorageInfoS.SelectedRows.Count != 0))
            {
                this.btnDelS.Enabled = true;
            }
            else
            {
                this.btnDelS.Enabled = false;
            }
        }

        private void RegexNum(object sender, EventArgs e)
        {
            if (!((TextBox)sender).Text.Equals(string.Empty) && !this.regex.IsMatch(((TextBox)sender).Text))
            {
                CommonFunction.Sys_MsgBox("对不起，您所输入的不符合数字格式要求，请从新输入");
                ((TextBox)sender).Focus();
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.GetNextControl(base.ActiveControl, true).Focus();
            }
        }

        private void UpdateData(ArrayList billInfo, DataTable storageInfoListF, DataTable storageInfoListS)
        {
            string str = DBOperate.SplitArriveStore(this.arriveListInfo[0].ToString(), billInfo, storageInfoListF, storageInfoListS);
            if (!str.Equals("-1"))
            {
                CommonFunction.Sys_MsgBox("到库通知单 " + billInfo[0].ToString() + " 拆分为 " + this.labelArriveListID.Text + "|" + str + " 两个到库单");
                DialogResult = DialogResult.OK;
            }
            else
            {
                CommonFunction.Sys_MsgBox("到库通知单拆分失败，请联系管理员确认");
                DialogResult = DialogResult.OK;
            }
        }

        private void 到库货物信息拆分_Shown(object sender, EventArgs e)
        {
            textBoxConsignmentAmountS.Focus();
        }

    }
}

