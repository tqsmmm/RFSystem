using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BL;
using System.Collections;
using DsToExcel;

namespace RFSystem.ArriveStore
{
    public partial class 异议入库 : Form
    {
        // Fields
        private Button btnAdd;
        private Button btnDel;
        private Button btnExit;
        private Button btnSelect;
        private ToExcelButton buttonExcel;
        private CheckBox checkBoxTableMakeDate;
        private IContainer components;
        private DataGridView dataGridViewGoodsList;
        private DataGridView dataGridViewStorageInfo;
        private DateTimePicker dateTimePickerTableMakeDateFrom;
        private DateTimePicker dateTimePickerTableMakeDateTo;
        private DataTable demurralInfoList;
        private DataTable demurralStorageInfoList;
        private DataTable dtExcel;
        private DataView dvDemurralStorageInfoList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label9;
        private TextBox textBoxArriveListID;
        private TextBox textBoxGoodsName;
        private TextBox textBoxMateriel;
        private UserInfo userItem;
        private DataGridViewTextBoxColumn ColumnExceptionID;
        private DataGridViewTextBoxColumn ColumnArriveListID;
        private DataGridViewTextBoxColumn ColumnMaterielNum;
        private DataGridViewTextBoxColumn ColumnGoodsName;
        private DataGridViewTextBoxColumn ColumnGoodsAmount;
        private DataGridViewTextBoxColumn ColumnExceptionCausation;
        private DataGridViewTextBoxColumn ColumnExceptionIDinS;
        private DataGridViewTextBoxColumn ColumnExceptionStorageID;
        private DataGridViewTextBoxColumn ColumnStorePosition;
        private DataGridViewTextBoxColumn ColumnAmount;
        private DataGridViewTextBoxColumn ColumnRemark;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxTableMakeDate = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTableMakeDateTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTableMakeDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxGoodsName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMateriel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxArriveListID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewGoodsList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewStorageInfo = new System.Windows.Forms.DataGridView();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.ColumnExceptionIDinS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExceptionStorageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStorePosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExceptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArriveListID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaterielNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGoodsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExceptionCausation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoodsList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBoxTableMakeDate);
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateTo);
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateFrom);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnSelect);
            this.groupBox3.Controls.Add(this.textBoxGoodsName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxMateriel);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxArriveListID);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(926, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // checkBoxTableMakeDate
            // 
            this.checkBoxTableMakeDate.AutoSize = true;
            this.checkBoxTableMakeDate.Location = new System.Drawing.Point(22, 61);
            this.checkBoxTableMakeDate.Name = "checkBoxTableMakeDate";
            this.checkBoxTableMakeDate.Size = new System.Drawing.Size(98, 24);
            this.checkBoxTableMakeDate.TabIndex = 60;
            this.checkBoxTableMakeDate.Text = "制表日期：";
            this.checkBoxTableMakeDate.UseVisualStyleBackColor = true;
            this.checkBoxTableMakeDate.CheckedChanged += new System.EventHandler(this.checkBoxTableMakeDate_CheckedChanged);
            this.checkBoxTableMakeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dateTimePickerTableMakeDateTo
            // 
            this.dateTimePickerTableMakeDateTo.Enabled = false;
            this.dateTimePickerTableMakeDateTo.Location = new System.Drawing.Point(306, 57);
            this.dateTimePickerTableMakeDateTo.Name = "dateTimePickerTableMakeDateTo";
            this.dateTimePickerTableMakeDateTo.Size = new System.Drawing.Size(140, 26);
            this.dateTimePickerTableMakeDateTo.TabIndex = 50;
            this.dateTimePickerTableMakeDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dateTimePickerTableMakeDateFrom
            // 
            this.dateTimePickerTableMakeDateFrom.Enabled = false;
            this.dateTimePickerTableMakeDateFrom.Location = new System.Drawing.Point(126, 57);
            this.dateTimePickerTableMakeDateFrom.Name = "dateTimePickerTableMakeDateFrom";
            this.dateTimePickerTableMakeDateFrom.Size = new System.Drawing.Size(140, 26);
            this.dateTimePickerTableMakeDateFrom.TabIndex = 40;
            this.dateTimePickerTableMakeDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "TO";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(811, 36);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 70;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxGoodsName
            // 
            this.textBoxGoodsName.Location = new System.Drawing.Point(499, 25);
            this.textBoxGoodsName.Name = "textBoxGoodsName";
            this.textBoxGoodsName.Size = new System.Drawing.Size(100, 26);
            this.textBoxGoodsName.TabIndex = 30;
            this.textBoxGoodsName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "货物名称：";
            // 
            // textBoxMateriel
            // 
            this.textBoxMateriel.Location = new System.Drawing.Point(308, 25);
            this.textBoxMateriel.Name = "textBoxMateriel";
            this.textBoxMateriel.Size = new System.Drawing.Size(100, 26);
            this.textBoxMateriel.TabIndex = 20;
            this.textBoxMateriel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "货物物料号：";
            // 
            // textBoxArriveListID
            // 
            this.textBoxArriveListID.Location = new System.Drawing.Point(103, 25);
            this.textBoxArriveListID.Name = "textBoxArriveListID";
            this.textBoxArriveListID.Size = new System.Drawing.Size(100, 26);
            this.textBoxArriveListID.TabIndex = 10;
            this.textBoxArriveListID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "到库单号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewGoodsList);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(926, 283);
            this.groupBox1.TabIndex = 200;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "异议货物列表";
            // 
            // dataGridViewGoodsList
            // 
            this.dataGridViewGoodsList.AllowUserToAddRows = false;
            this.dataGridViewGoodsList.AllowUserToResizeRows = false;
            this.dataGridViewGoodsList.ColumnHeadersHeight = 30;
            this.dataGridViewGoodsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewGoodsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnExceptionID,
            this.ColumnArriveListID,
            this.ColumnMaterielNum,
            this.ColumnGoodsName,
            this.ColumnGoodsAmount,
            this.ColumnExceptionCausation});
            this.dataGridViewGoodsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGoodsList.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewGoodsList.MultiSelect = false;
            this.dataGridViewGoodsList.Name = "dataGridViewGoodsList";
            this.dataGridViewGoodsList.ReadOnly = true;
            this.dataGridViewGoodsList.RowHeadersVisible = false;
            this.dataGridViewGoodsList.RowTemplate.Height = 23;
            this.dataGridViewGoodsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGoodsList.Size = new System.Drawing.Size(920, 258);
            this.dataGridViewGoodsList.TabIndex = 210;
            this.dataGridViewGoodsList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGoodsList_CellDoubleClick);
            this.dataGridViewGoodsList.SelectionChanged += new System.EventHandler(this.dataGridViewGoodsList_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewStorageInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(926, 156);
            this.groupBox2.TabIndex = 300;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "存放信息";
            // 
            // dataGridViewStorageInfo
            // 
            this.dataGridViewStorageInfo.AllowUserToAddRows = false;
            this.dataGridViewStorageInfo.ColumnHeadersHeight = 30;
            this.dataGridViewStorageInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStorageInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnExceptionIDinS,
            this.ColumnExceptionStorageID,
            this.ColumnStorePosition,
            this.ColumnAmount,
            this.ColumnRemark});
            this.dataGridViewStorageInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStorageInfo.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewStorageInfo.MultiSelect = false;
            this.dataGridViewStorageInfo.Name = "dataGridViewStorageInfo";
            this.dataGridViewStorageInfo.ReadOnly = true;
            this.dataGridViewStorageInfo.RowHeadersVisible = false;
            this.dataGridViewStorageInfo.RowHeadersWidth = 30;
            this.dataGridViewStorageInfo.RowTemplate.Height = 23;
            this.dataGridViewStorageInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStorageInfo.Size = new System.Drawing.Size(920, 131);
            this.dataGridViewStorageInfo.TabIndex = 310;
            this.dataGridViewStorageInfo.SelectionChanged += new System.EventHandler(this.dataGridViewStorageInfo_SelectionChanged);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(732, 569);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 40);
            this.btnDel.TabIndex = 510;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(626, 569);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 500;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(838, 569);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 550;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ColumnExceptionIDinS
            // 
            this.ColumnExceptionIDinS.DataPropertyName = "ExceptionID";
            this.ColumnExceptionIDinS.HeaderText = "异议入库序号";
            this.ColumnExceptionIDinS.Name = "ColumnExceptionIDinS";
            this.ColumnExceptionIDinS.ReadOnly = true;
            this.ColumnExceptionIDinS.Visible = false;
            // 
            // ColumnExceptionStorageID
            // 
            this.ColumnExceptionStorageID.DataPropertyName = "ExceptionStorageID";
            this.ColumnExceptionStorageID.HeaderText = "异议入库存储编号";
            this.ColumnExceptionStorageID.Name = "ColumnExceptionStorageID";
            this.ColumnExceptionStorageID.ReadOnly = true;
            this.ColumnExceptionStorageID.Visible = false;
            // 
            // ColumnStorePosition
            // 
            this.ColumnStorePosition.DataPropertyName = "StorePosition";
            this.ColumnStorePosition.HeaderText = "库位";
            this.ColumnStorePosition.Name = "ColumnStorePosition";
            this.ColumnStorePosition.ReadOnly = true;
            this.ColumnStorePosition.Width = 115;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "库位数量";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            // 
            // ColumnRemark
            // 
            this.ColumnRemark.DataPropertyName = "Remark";
            this.ColumnRemark.HeaderText = "备注";
            this.ColumnRemark.Name = "ColumnRemark";
            this.ColumnRemark.ReadOnly = true;
            this.ColumnRemark.Width = 250;
            // 
            // ColumnExceptionID
            // 
            this.ColumnExceptionID.DataPropertyName = "异议货物编号";
            this.ColumnExceptionID.HeaderText = "异议入库编号";
            this.ColumnExceptionID.Name = "ColumnExceptionID";
            this.ColumnExceptionID.ReadOnly = true;
            this.ColumnExceptionID.Visible = false;
            // 
            // ColumnArriveListID
            // 
            this.ColumnArriveListID.DataPropertyName = "所属到库单号";
            this.ColumnArriveListID.HeaderText = "到库单号";
            this.ColumnArriveListID.Name = "ColumnArriveListID";
            this.ColumnArriveListID.ReadOnly = true;
            // 
            // ColumnMaterielNum
            // 
            this.ColumnMaterielNum.DataPropertyName = "物料号";
            this.ColumnMaterielNum.HeaderText = "货物物料号";
            this.ColumnMaterielNum.Name = "ColumnMaterielNum";
            this.ColumnMaterielNum.ReadOnly = true;
            this.ColumnMaterielNum.Width = 120;
            // 
            // ColumnGoodsName
            // 
            this.ColumnGoodsName.DataPropertyName = "货物名";
            this.ColumnGoodsName.HeaderText = "货物名称";
            this.ColumnGoodsName.Name = "ColumnGoodsName";
            this.ColumnGoodsName.ReadOnly = true;
            this.ColumnGoodsName.Width = 150;
            // 
            // ColumnGoodsAmount
            // 
            this.ColumnGoodsAmount.DataPropertyName = "异议数量";
            this.ColumnGoodsAmount.HeaderText = "货物件数";
            this.ColumnGoodsAmount.Name = "ColumnGoodsAmount";
            this.ColumnGoodsAmount.ReadOnly = true;
            // 
            // ColumnExceptionCausation
            // 
            this.ColumnExceptionCausation.DataPropertyName = "异议原因";
            this.ColumnExceptionCausation.HeaderText = "异议原因";
            this.ColumnExceptionCausation.Name = "ColumnExceptionCausation";
            this.ColumnExceptionCausation.ReadOnly = true;
            // 
            // 异议入库
            // 
            this.ClientSize = new System.Drawing.Size(950, 621);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "异议入库";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "异议入库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoodsList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfo)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 异议入库(UserInfo userItem, ArrayList userRoles)
        {
            this.components = null;
            this.demurralInfoList = null;
            this.demurralStorageInfoList = null;
            this.dvDemurralStorageInfoList = null;
            this.userItem = null;
            this.buttonExcel = null;
            this.InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.dataGridViewGoodsList.AutoGenerateColumns = false;
            this.demurralInfoList = new DataTable();
            this.demurralInfoList.Columns.Add("异议货物编号");
            this.demurralInfoList.Columns.Add("所属到库单号");
            this.demurralInfoList.Columns.Add("物料号");
            this.demurralInfoList.Columns.Add("货物名");
            this.demurralInfoList.Columns.Add("异议数量");
            this.demurralInfoList.Columns.Add("异议原因");
            this.demurralStorageInfoList = new DataTable();
            this.demurralStorageInfoList.Columns.Add("ExceptionID", Type.GetType("System.Guid"));
            this.demurralStorageInfoList.Columns.Add("ExceptionStorageID", Type.GetType("System.Guid"));
            this.demurralStorageInfoList.Columns.Add("StorePosition");
            this.demurralStorageInfoList.Columns.Add("Amount", Type.GetType("System.Decimal"));
            this.demurralStorageInfoList.Columns.Add("Remark");
            this.buttonExcel = new ToExcelButton();
            base.Controls.Add(this.buttonExcel);
            this.buttonExcel.Location = new Point(0x1f3, 0x213);
            this.buttonExcel.Size = new Size(0x4b, 0x17);
            this.buttonExcel.TableName = "collect";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            异议入库信息添加 异议入库信息添加 = new 异议入库信息添加(this.userItem, this.userRoles);
            if (异议入库信息添加.ShowDialog() == DialogResult.OK)
            {
                this.btnSelect.PerformClick();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (DBOperate.DelArriveStoreExceptionInfo(this.dataGridViewGoodsList.SelectedRows[0].Cells["ColumnExceptionID"].Value.ToString()) != -1)
            {
                MessageBox.Show("信息删除成功！");
                this.btnSelect.PerformClick();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.dataGridViewGoodsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.demurralStorageInfoList.Rows.Clear();
            ArrayList exceptionInfo = new ArrayList();
            exceptionInfo.Add(this.textBoxArriveListID.Text);
            exceptionInfo.Add(this.textBoxMateriel.Text);
            exceptionInfo.Add(this.textBoxGoodsName.Text);
            if (this.checkBoxTableMakeDate.Checked)
            {
                exceptionInfo.Add(this.dateTimePickerTableMakeDateFrom.Value.ToShortDateString());
                exceptionInfo.Add(this.dateTimePickerTableMakeDateTo.Value.ToShortDateString());
            }
            else
            {
                exceptionInfo.Add(string.Empty);
                exceptionInfo.Add(string.Empty);
            }
            this.demurralInfoList = DBOperate.GetArriveStoreExceptionInfoList(exceptionInfo);
            foreach (DataRow row in this.demurralInfoList.Rows)
            {
                DataTable storageExceptionInfoList = DBOperate.GetStorageExceptionInfoList(row["异议货物编号"].ToString());
                this.demurralStorageInfoList.Merge(storageExceptionInfoList);
            }
            this.dvDemurralStorageInfoList = this.demurralStorageInfoList.DefaultView;
            this.dataGridViewGoodsList.DataSource = this.demurralInfoList;
            if ((this.dataGridViewGoodsList.Rows != null) && (this.dataGridViewGoodsList.SelectedRows.Count != 0))
            {
                this.dvDemurralStorageInfoList.RowFilter = "ExceptionID='" + this.dataGridViewGoodsList.SelectedRows[0].Cells["ColumnExceptionID"].Value.ToString() + "'";
            }
            else
            {
                MessageBox.Show("当前没有异议入库的货物信息，请确认", "数据不存在", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.dataGridViewStorageInfo.DataSource = this.dvDemurralStorageInfoList;
            this.dtExcel = this.demurralInfoList.Copy();
            DataSet set = new DataSet();
            foreach (DataRow row2 in this.dtExcel.Rows)
            {
                row2["所属到库单号"] = "'" + row2["所属到库单号"];
            }
            set.Tables.Add(this.dtExcel);
            this.buttonExcel.Source = set;
            this.buttonExcel.TableName = set.Tables[0].TableName;
            Hashtable hs = new Hashtable();
            foreach (DataColumn column in this.demurralInfoList.Columns)
            {
                hs.Add(column.ToString(), column.ToString());
            }
            this.buttonExcel.SetMapping(hs);
        }

        private void checkBoxTableMakeDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePickerTableMakeDateFrom.Enabled = this.dateTimePickerTableMakeDateTo.Enabled = this.checkBoxTableMakeDate.Checked;
        }

        private void dataGridViewGoodsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewGoodsList_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewGoodsList.Rows != null) && (this.dataGridViewGoodsList.SelectedRows.Count != 0))
            {
                this.dvDemurralStorageInfoList.RowFilter = "ExceptionID='" + this.dataGridViewGoodsList.SelectedRows[0].Cells["ColumnExceptionID"].Value.ToString() + "'";
            }
        }

        private void dataGridViewStorageInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewStorageInfo.Rows != null) && (this.dataGridViewStorageInfo.SelectedRows.Count != 0))
            {
                this.btnDel.Enabled = true;
            }
            else
            {
                this.btnDel.Enabled = false;
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.GetNextControl(base.ActiveControl, true).Focus();
            }
        }
    }
}
