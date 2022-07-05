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
    public class 保养单列表 : Form
    {
        // Fields
        private Button btnEnter;
        private Button btnExit;
        private DataGridViewTextBoxColumn ColumnFACTORY_NO;
        private DataGridViewTextBoxColumn ColumnMAINTAIN_NO;
        private DataGridViewTextBoxColumn ColumnOPERATE_TIME;
        private DataGridViewTextBoxColumn ColumnOPERATOR;
        private DataGridViewTextBoxColumn ColumnSL;
        private DataGridViewTextBoxColumn ColumnState;
        private DataGridViewTextBoxColumn ColumnSTOREMAN;
        private IContainer components;
        private DataGridView dataGridViewMaintain;
        private DataTable dtMaintainHeader;
        private 保养货物 maintain;
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
            this.btnExit = new System.Windows.Forms.Button();
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
            this.dataGridViewMaintain.Size = new System.Drawing.Size(528, 198);
            this.dataGridViewMaintain.TabIndex = 20002;
            this.dataGridViewMaintain.SelectionChanged += new System.EventHandler(this.dataGridViewMaintain_SelectionChanged);
            // 
            // ColumnState
            // 
            this.ColumnState.DataPropertyName = "State";
            this.ColumnState.HeaderText = "状态";
            this.ColumnState.Name = "ColumnState";
            this.ColumnState.ReadOnly = true;
            this.ColumnState.Width = 54;
            // 
            // ColumnMAINTAIN_NO
            // 
            this.ColumnMAINTAIN_NO.DataPropertyName = "MAINTAIN_NO";
            this.ColumnMAINTAIN_NO.HeaderText = "保养单号";
            this.ColumnMAINTAIN_NO.Name = "ColumnMAINTAIN_NO";
            this.ColumnMAINTAIN_NO.ReadOnly = true;
            this.ColumnMAINTAIN_NO.Width = 78;
            // 
            // ColumnFACTORY_NO
            // 
            this.ColumnFACTORY_NO.DataPropertyName = "FACTORY_NO";
            this.ColumnFACTORY_NO.HeaderText = "公司";
            this.ColumnFACTORY_NO.Name = "ColumnFACTORY_NO";
            this.ColumnFACTORY_NO.ReadOnly = true;
            this.ColumnFACTORY_NO.Width = 54;
            // 
            // ColumnSL
            // 
            this.ColumnSL.DataPropertyName = "SL";
            this.ColumnSL.HeaderText = "库存地点";
            this.ColumnSL.Name = "ColumnSL";
            this.ColumnSL.ReadOnly = true;
            this.ColumnSL.Width = 78;
            // 
            // ColumnSTOREMAN
            // 
            this.ColumnSTOREMAN.DataPropertyName = "STOREMAN";
            this.ColumnSTOREMAN.HeaderText = "保管员";
            this.ColumnSTOREMAN.Name = "ColumnSTOREMAN";
            this.ColumnSTOREMAN.ReadOnly = true;
            this.ColumnSTOREMAN.Width = 66;
            // 
            // ColumnOPERATOR
            // 
            this.ColumnOPERATOR.DataPropertyName = "OPERATOR";
            this.ColumnOPERATOR.HeaderText = "制单人";
            this.ColumnOPERATOR.Name = "ColumnOPERATOR";
            this.ColumnOPERATOR.ReadOnly = true;
            this.ColumnOPERATOR.Width = 66;
            // 
            // ColumnOPERATE_TIME
            // 
            this.ColumnOPERATE_TIME.DataPropertyName = "OPERATE_TIME";
            this.ColumnOPERATE_TIME.HeaderText = "制单日期";
            this.ColumnOPERATE_TIME.Name = "ColumnOPERATE_TIME";
            this.ColumnOPERATE_TIME.ReadOnly = true;
            this.ColumnOPERATE_TIME.Width = 78;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(465, 216);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 20003;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Enabled = false;
            this.btnEnter.Location = new System.Drawing.Point(359, 216);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 23);
            this.btnEnter.TabIndex = 20004;
            this.btnEnter.Text = "进入保养界面";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // 保养单列表
            // 
            this.ClientSize = new System.Drawing.Size(552, 251);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridViewMaintain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "保养单列表";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保养单列表";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintain)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 保养单列表(UserInfo userItem, ArrayList userRoles)
        {
            this.components = null;
            this.userItem = null;
            this.userRoles = null;
            this.InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.InitTableColumns();
            this.dataGridViewMaintain.AutoGenerateColumns = false;
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
            this.dtMaintainHeader = DBOperate.MaintainGetHead(arriveList);
            this.dataGridViewMaintain.DataSource = this.dtMaintainHeader;
            if (!CommonFunction.IfHasData(this.dtMaintainHeader))
            {
                MessageBox.Show("当前没有可操作的货物！");
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (base.ParentForm.MdiChildren.Length <= 1)
            {
                this.maintain = new 保养货物(this.dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString());
                this.maintain.MdiParent = base.ParentForm;
                this.maintain.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void dataGridViewMaintain_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewMaintain.Rows != null) && (this.dataGridViewMaintain.SelectedRows.Count != 0))
            {
                this.btnEnter.Enabled = true;
            }
            else
            {
                this.btnEnter.Enabled = false;
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
        }
    }
}
