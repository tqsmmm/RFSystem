using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BL;
using System.Collections;
using RFSystem.CommonClass;

namespace RFSystem
{
    public class 保养单列表 : Form
    {
        // Fields
        private Button btnEnter;
        private DataGridViewTextBoxColumn ColumnFACTORY_NO;
        private DataGridViewTextBoxColumn ColumnMAINTAIN_NO;
        private DataGridViewTextBoxColumn ColumnOPERATE_TIME;
        private DataGridViewTextBoxColumn ColumnOPERATOR;
        private DataGridViewTextBoxColumn ColumnSL;
        private DataGridViewTextBoxColumn ColumnState;
        private DataGridViewTextBoxColumn ColumnSTOREMAN;
        private DataGridView dataGridViewMaintain;
        private DataTable dtMaintainHeader;
        private 保养货物 maintain;
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
            this.btnEnter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintain)).BeginInit();
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
            this.dataGridViewMaintain.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewMaintain.MultiSelect = false;
            this.dataGridViewMaintain.Name = "dataGridViewMaintain";
            this.dataGridViewMaintain.ReadOnly = true;
            this.dataGridViewMaintain.RowHeadersVisible = false;
            this.dataGridViewMaintain.RowTemplate.Height = 23;
            this.dataGridViewMaintain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintain.Size = new System.Drawing.Size(906, 468);
            this.dataGridViewMaintain.TabIndex = 20002;
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
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Enabled = false;
            this.btnEnter.Location = new System.Drawing.Point(798, 486);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(120, 40);
            this.btnEnter.TabIndex = 20004;
            this.btnEnter.Text = "进入保养界面";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // 保养单列表
            // 
            this.ClientSize = new System.Drawing.Size(930, 538);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.dataGridViewMaintain);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "保养单列表";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保养单列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.保养单列表_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintain)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 保养单列表(UserInfo userItem, ArrayList userRoles)
        {
            this.userItem = null;
            this.userRoles = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            InitTableColumns();
            dataGridViewMaintain.AutoGenerateColumns = false;
            ArrayList arriveList = new ArrayList();
            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);

            if (userItem.isAdmin)
            {
                arriveList.Add(string.Empty);
            }
            else
            {
                arriveList.Add(userItem.userID);
            }

            arriveList.Add(string.Empty);
            arriveList.Add("1");
            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);
            dtMaintainHeader = DBOperate.MaintainGetHead(arriveList);
            dataGridViewMaintain.DataSource = dtMaintainHeader;

            if (!CommonFunction.IfHasData(dtMaintainHeader))
            {
                MessageBox.Show("当前没有可操作的货物！");
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (ParentForm.MdiChildren.Length <= 1)
            {
                maintain = new 保养货物(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString());
                maintain.MdiParent = ParentForm;
                maintain.Show();
            }
        }

        private void dataGridViewMaintain_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewMaintain.Rows != null) && (dataGridViewMaintain.SelectedRows.Count != 0))
            {
                btnEnter.Enabled = true;
            }
            else
            {
                btnEnter.Enabled = false;
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
        }

        private void 保养单列表_Load(object sender, EventArgs e)
        {

        }
    }
}
