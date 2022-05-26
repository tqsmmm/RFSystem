using System;
using System.Data;
using System.Windows.Forms;
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
        private TextBox textBoxUserID;
        private TextBox textBoxUserName;
        private TreeView treeViewRoles;

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.treeViewRoles);
            this.groupBox1.Location = new System.Drawing.Point(567, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 675);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "权限管理：";
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.CheckBoxes = true;
            this.treeViewRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRoles.Enabled = false;
            this.treeViewRoles.Location = new System.Drawing.Point(3, 22);
            this.treeViewRoles.Name = "treeViewRoles";
            this.treeViewRoles.Size = new System.Drawing.Size(539, 650);
            this.treeViewRoles.TabIndex = 40;
            this.treeViewRoles.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewRoles_BeforeCheck);
            this.treeViewRoles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRoles_AfterCheck);
            this.treeViewRoles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(12, 172);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 50);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dataGridViewUserList);
            this.groupBox2.Location = new System.Drawing.Point(138, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 675);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户选择";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 116);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 50);
            this.btnSelect.TabIndex = 20;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            this.btnSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(12, 84);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(120, 26);
            this.textBoxUserName.TabIndex = 10;
            this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "用户姓名：";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(12, 32);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(120, 26);
            this.textBoxUserID.TabIndex = 5;
            this.textBoxUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "用户编号：";
            // 
            // dataGridViewUserList
            // 
            this.dataGridViewUserList.AllowUserToAddRows = false;
            this.dataGridViewUserList.AllowUserToResizeRows = false;
            this.dataGridViewUserList.ColumnHeadersHeight = 30;
            this.dataGridViewUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUser_ID,
            this.ColumnUser_Name});
            this.dataGridViewUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUserList.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewUserList.MultiSelect = false;
            this.dataGridViewUserList.Name = "dataGridViewUserList";
            this.dataGridViewUserList.ReadOnly = true;
            this.dataGridViewUserList.RowHeadersVisible = false;
            this.dataGridViewUserList.RowTemplate.Height = 23;
            this.dataGridViewUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserList.Size = new System.Drawing.Size(417, 650);
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
            this.ClientSize = new System.Drawing.Size(1124, 699);
            this.ControlBox = false;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.label1);
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
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
                btnOK.Enabled = true;
                dtUserRoles = DBOperate.GetUserRoles(dataGridViewUserList.SelectedRows[0].Cells["ColumnUser_ID"].Value.ToString());
                RoleInit.InitUserRoles(treeViewRoles, dtUserRoles);
            }
            else
            {
                RoleInit.ClearNodesCheckState(treeViewRoles.Nodes);
                treeViewRoles.Enabled = false;
                btnOK.Enabled = false;
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
