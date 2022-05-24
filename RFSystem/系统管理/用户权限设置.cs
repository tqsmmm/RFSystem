using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using RFSystem.CommonClass;
using BL;
using System.Collections;

namespace RFSystem
{
    public partial class 用户权限设置 : Form
    {
        private Button btnOK;
        private Button btnSelect;
        private DataGridViewTextBoxColumn ColumnUser_ID;
        private DataGridViewTextBoxColumn ColumnUser_Name;
        private DataGridView dataGridViewUserList;
        private DataTable dtUserAndRoles;
        private DataTable dtUserRoles;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private bool ifMouseClick;
        private Label label1;
        private Label label2;
        private RadioButton rbSelectAll;
        private RadioButton rbUnSelectAll;
        private TextBox textBoxUserID;
        private TextBox textBoxUserName;
        private TreeView treeViewRoles;

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUnSelectAll = new System.Windows.Forms.RadioButton();
            this.rbSelectAll = new System.Windows.Forms.RadioButton();
            this.treeViewRoles = new System.Windows.Forms.TreeView();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewUserList = new System.Windows.Forms.DataGridView();
            this.ColumnUser_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUser_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbUnSelectAll);
            this.groupBox1.Controls.Add(this.rbSelectAll);
            this.groupBox1.Controls.Add(this.treeViewRoles);
            this.groupBox1.Location = new System.Drawing.Point(449, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 493);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "权限管理：";
            // 
            // rbUnSelectAll
            // 
            this.rbUnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbUnSelectAll.AutoSize = true;
            this.rbUnSelectAll.Checked = true;
            this.rbUnSelectAll.Enabled = false;
            this.rbUnSelectAll.Location = new System.Drawing.Point(59, 463);
            this.rbUnSelectAll.Name = "rbUnSelectAll";
            this.rbUnSelectAll.Size = new System.Drawing.Size(83, 24);
            this.rbUnSelectAll.TabIndex = 50;
            this.rbUnSelectAll.TabStop = true;
            this.rbUnSelectAll.Text = "取消全选";
            this.rbUnSelectAll.UseVisualStyleBackColor = true;
            this.rbUnSelectAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // rbSelectAll
            // 
            this.rbSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbSelectAll.AutoSize = true;
            this.rbSelectAll.Enabled = false;
            this.rbSelectAll.Location = new System.Drawing.Point(6, 463);
            this.rbSelectAll.Name = "rbSelectAll";
            this.rbSelectAll.Size = new System.Drawing.Size(55, 24);
            this.rbSelectAll.TabIndex = 50;
            this.rbSelectAll.Text = "全选";
            this.rbSelectAll.UseVisualStyleBackColor = true;
            this.rbSelectAll.CheckedChanged += new System.EventHandler(this.rbSelectAll_CheckedChanged);
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewRoles.CheckBoxes = true;
            this.treeViewRoles.Enabled = false;
            this.treeViewRoles.Location = new System.Drawing.Point(6, 20);
            this.treeViewRoles.Name = "treeViewRoles";
            this.treeViewRoles.Size = new System.Drawing.Size(420, 437);
            this.treeViewRoles.TabIndex = 40;
            this.treeViewRoles.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewRoles_BeforeCheck);
            this.treeViewRoles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRoles_AfterCheck);
            this.treeViewRoles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(781, 511);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.textBoxUserName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxUserID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dataGridViewUserList);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 539);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户选择";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(325, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 20;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            this.btnSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(91, 57);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(150, 26);
            this.textBoxUserName.TabIndex = 10;
            this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "用户姓名：";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(91, 25);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(150, 26);
            this.textBoxUserID.TabIndex = 5;
            this.textBoxUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "用户编号：";
            // 
            // dataGridViewUserList
            // 
            this.dataGridViewUserList.AllowUserToAddRows = false;
            this.dataGridViewUserList.AllowUserToResizeRows = false;
            this.dataGridViewUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUserList.ColumnHeadersHeight = 30;
            this.dataGridViewUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUser_ID,
            this.ColumnUser_Name});
            this.dataGridViewUserList.Location = new System.Drawing.Point(6, 89);
            this.dataGridViewUserList.MultiSelect = false;
            this.dataGridViewUserList.Name = "dataGridViewUserList";
            this.dataGridViewUserList.ReadOnly = true;
            this.dataGridViewUserList.RowHeadersVisible = false;
            this.dataGridViewUserList.RowTemplate.Height = 23;
            this.dataGridViewUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserList.Size = new System.Drawing.Size(419, 444);
            this.dataGridViewUserList.TabIndex = 30;
            this.dataGridViewUserList.SelectionChanged += new System.EventHandler(this.dataGridViewUserList_SelectionChanged);
            this.dataGridViewUserList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // ColumnUser_ID
            // 
            this.ColumnUser_ID.DataPropertyName = "User_ID";
            this.ColumnUser_ID.HeaderText = "用户编号";
            this.ColumnUser_ID.Name = "ColumnUser_ID";
            this.ColumnUser_ID.ReadOnly = true;
            this.ColumnUser_ID.Width = 125;
            // 
            // ColumnUser_Name
            // 
            this.ColumnUser_Name.DataPropertyName = "User_Name";
            this.ColumnUser_Name.HeaderText = "用户姓名";
            this.ColumnUser_Name.Name = "ColumnUser_Name";
            this.ColumnUser_Name.ReadOnly = true;
            this.ColumnUser_Name.Width = 150;
            // 
            // 用户权限设置
            // 
            this.ClientSize = new System.Drawing.Size(893, 563);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "用户权限设置";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户权限设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.用户权限设置_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserList)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 用户权限设置()
        {
            dtUserAndRoles = null;
            dtUserRoles = null;
            ifMouseClick = true;
            InitializeComponent();
            dtUserRoles = new DataTable();
            dataGridViewUserList.AutoGenerateColumns = false;
            RoleInit.CreateTreeView(treeViewRoles, DBOperate.GetMRoles());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ArrayList userRolesID = RoleInit.GetUserRolesID(treeViewRoles);

            string userRoles = string.Empty;

            for (int i = 0; i < userRolesID.Count; i++)
            {
                userRoles = userRoles + userRolesID[i].ToString() + ",";
            }

            if (userRoles.Length == 0)
            {
                if (DBOperate.DelUserRoles(dataGridViewUserList.SelectedRows[0].Cells["ColumnUser_ID"].Value.ToString()) != -1)
                {
                    CommonFunction.Sys_MsgBox("用户 " + dataGridViewUserList.SelectedRows[0].Cells["ColumnUser_ID"].Value.ToString() + " 权限更新成功");
                }
            }
            else
            {
                userRoles = userRoles.Remove(userRoles.Length - 1);

                if (DBOperate.ModUserRoles(dataGridViewUserList.SelectedRows[0].Cells["ColumnUser_ID"].Value.ToString(), userRoles) != -1)
                {
                    CommonFunction.Sys_MsgBox("用户 " + dataGridViewUserList.SelectedRows[0].Cells["ColumnUser_ID"].Value.ToString() + " 权限更新成功");
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dtUserAndRoles = DBOperate.GetUserList(textBoxUserID.Text.Trim(), textBoxUserName.Text.Trim(), true);
            dataGridViewUserList.DataSource = dtUserAndRoles;
        }

        private void dataGridViewUserList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewUserList.Rows != null) && (dataGridViewUserList.SelectedRows.Count != 0))
            {
                treeViewRoles.Enabled = true;
                rbSelectAll.Enabled = true;
                rbUnSelectAll.Enabled = true;
                btnOK.Enabled = true;
                dtUserRoles = DBOperate.GetUserRoles(dataGridViewUserList.SelectedRows[0].Cells["ColumnUser_ID"].Value.ToString());
                RoleInit.InitUserRoles(treeViewRoles, dtUserRoles);
            }
            else
            {
                RoleInit.ClearNodesCheckState(treeViewRoles.Nodes);
                treeViewRoles.Enabled = false;
                rbSelectAll.Enabled = false;
                rbUnSelectAll.Enabled = false;
                btnOK.Enabled = false;
            }
        }

        private void rbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelectAll.Checked)
            {
                SelectAllNodes(treeViewRoles.Nodes, false);
            }
            else
            {
                SelectAllNodes(treeViewRoles.Nodes, true);
            }
        }

        private void SelectAllNodes(TreeNodeCollection Nds, bool Selected)
        {
            foreach (TreeNode node in Nds)
            {
                if (node.Checked == Selected)
                {
                    node.Checked = !Selected;
                }

                SelectAllNodes(node.Nodes, Selected);
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetNextControl(ActiveControl, true).Focus();
            }
        }

        private void treeViewRoles_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                ifMouseClick = false;
                e.Node.Parent.Checked = false;

                if (e.Node.Checked)
                {
                    e.Node.Parent.Checked = true;
                }
                else
                {
                    foreach (TreeNode node in e.Node.Parent.Nodes)
                    {
                        if (node.Checked)
                        {
                            e.Node.Parent.Checked = true;
                        }
                    }
                }

                ifMouseClick = true;
            }
        }

        private void treeViewRoles_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if ((e.Node.Parent == null) && ifMouseClick)
            {
                e.Cancel = true;
            }
        }

        private void 用户权限设置_Load(object sender, EventArgs e)
        {

        }
    }
}
