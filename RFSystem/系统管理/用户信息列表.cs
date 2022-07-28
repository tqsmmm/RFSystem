using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace RFSystem
{
    public class 用户信息列表 : Form
    {
        // Fields
        private Button btnAdd;
        private Button btnDel;
        private Button btnMod;
        private DataGridView dataGridViewUserList;
        private DataTable dtUserList;
        private Label label8;
        private Label label9;
        private TextBox textBoxUserID;
        private Button btnSelect;
        private DataGridViewTextBoxColumn columnUserID;
        private DataGridViewTextBoxColumn columnRealName;
        private DataGridViewTextBoxColumn columnPassWord;
        private DataGridViewTextBoxColumn columnSapRolePoint;
        private DataGridViewTextBoxColumn columnInEffect;
        private DataGridViewTextBoxColumn columnIsAdmin;
        private TextBox textBoxUserName;

        private void InitializeComponent()
        {
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewUserList = new System.Windows.Forms.DataGridView();
            this.columnUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPassWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSapRolePoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnInEffect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIsAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(12, 252);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(120, 26);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "用户姓名：";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(12, 200);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(120, 26);
            this.textBoxUserID.TabIndex = 0;
            this.textBoxUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "用户工号：";
            // 
            // dataGridViewUserList
            // 
            this.dataGridViewUserList.AllowUserToAddRows = false;
            this.dataGridViewUserList.AllowUserToDeleteRows = false;
            this.dataGridViewUserList.AllowUserToResizeRows = false;
            this.dataGridViewUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUserList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewUserList.ColumnHeadersHeight = 30;
            this.dataGridViewUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnUserID,
            this.columnRealName,
            this.columnPassWord,
            this.columnSapRolePoint,
            this.columnInEffect,
            this.columnIsAdmin});
            this.dataGridViewUserList.Location = new System.Drawing.Point(138, 12);
            this.dataGridViewUserList.MultiSelect = false;
            this.dataGridViewUserList.Name = "dataGridViewUserList";
            this.dataGridViewUserList.ReadOnly = true;
            this.dataGridViewUserList.RowHeadersVisible = false;
            this.dataGridViewUserList.RowTemplate.Height = 23;
            this.dataGridViewUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewUserList.Size = new System.Drawing.Size(894, 606);
            this.dataGridViewUserList.TabIndex = 32;
            this.dataGridViewUserList.SelectionChanged += new System.EventHandler(this.dataGridViewUserList_SelectionChanged);
            // 
            // columnUserID
            // 
            this.columnUserID.DataPropertyName = "User_ID";
            this.columnUserID.HeaderText = "用户工号";
            this.columnUserID.Name = "columnUserID";
            this.columnUserID.ReadOnly = true;
            this.columnUserID.Width = 90;
            // 
            // columnRealName
            // 
            this.columnRealName.DataPropertyName = "User_Name";
            this.columnRealName.HeaderText = "用户姓名";
            this.columnRealName.Name = "columnRealName";
            this.columnRealName.ReadOnly = true;
            this.columnRealName.Width = 90;
            // 
            // columnPassWord
            // 
            this.columnPassWord.DataPropertyName = "PassWord";
            this.columnPassWord.HeaderText = "密码";
            this.columnPassWord.Name = "columnPassWord";
            this.columnPassWord.ReadOnly = true;
            this.columnPassWord.Visible = false;
            this.columnPassWord.Width = 51;
            // 
            // columnSapRolePoint
            // 
            this.columnSapRolePoint.DataPropertyName = "Post_ID";
            this.columnSapRolePoint.HeaderText = "保管员岗位号";
            this.columnSapRolePoint.Name = "columnSapRolePoint";
            this.columnSapRolePoint.ReadOnly = true;
            this.columnSapRolePoint.Width = 118;
            // 
            // columnInEffect
            // 
            this.columnInEffect.DataPropertyName = "InEffect";
            this.columnInEffect.HeaderText = "是否可用";
            this.columnInEffect.Name = "columnInEffect";
            this.columnInEffect.ReadOnly = true;
            this.columnInEffect.Width = 90;
            // 
            // columnIsAdmin
            // 
            this.columnIsAdmin.DataPropertyName = "IsAdmin";
            this.columnIsAdmin.HeaderText = "是否为管理员";
            this.columnIsAdmin.Name = "columnIsAdmin";
            this.columnIsAdmin.ReadOnly = true;
            this.columnIsAdmin.Width = 118;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(12, 124);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(120, 50);
            this.btnDel.TabIndex = 38;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(12, 68);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(120, 50);
            this.btnMod.TabIndex = 39;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 50);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 284);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 50);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // 用户信息列表
            // 
            this.ClientSize = new System.Drawing.Size(1044, 630);
            this.ControlBox = false;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridViewUserList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "用户信息列表";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.用户信息_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 用户信息列表()
        {
            dtUserList = null;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("新增"))
            {
                用户信息 frm = new 用户信息(null);
                frm.Text = "用户新增";

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    btnSelect.PerformClick();
                }
            }
            else if (CommonFunction.IfHasData(dtUserList))
            {
                if (dataGridViewUserList.SelectedRows != null)
                {
                    if (CommonFunction.Sys_MsgYN("确认恢复此条用户信息么？") && (UserInfo.RebornUser((string)dataGridViewUserList.SelectedRows[0].Cells["columnUserID"].Value) != -1))
                    {
                        CommonFunction.Sys_MsgBox("用户恢复成功，如果需要检索此用户信息请取消选择\"被删除过的用户\"");
                        btnSelect.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("请选择一条用户信息");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("没有检索到任何人员信息，无法恢复");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtUserList))
            {
                if (dataGridViewUserList.SelectedRows != null)
                {
                    if (CommonFunction.Sys_MsgYN("确认删除此条用户信息么？") && (UserInfo.DelUser((string)dataGridViewUserList.SelectedRows[0].Cells["columnUserID"].Value) != -1))
                    {
                        CommonFunction.Sys_MsgBox("用户删除成功，如果需要检索此用户信息请选择\"被删除过的用户\"");
                        btnSelect.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("请选择一条用户信息");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("没有检索到任何人员信息，无法删除");
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtUserList))
            {
                if (dataGridViewUserList.SelectedRows != null)
                {
                    Hashtable userItem = new Hashtable();

                    foreach (DataGridViewCell cell in dataGridViewUserList.SelectedRows[0].Cells)
                    {
                        userItem.Add(cell.OwningColumn.DataPropertyName, cell.Value);
                    }

                    用户信息 frm = new 用户信息(userItem);
                    frm.Text = "用户修改";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btnSelect.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("请选择一条用户信息");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("没有检索到任何人员信息，无法修改");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dtUserList = UserInfo.GetUserList(textBoxUserID.Text.Trim(), textBoxUserName.Text.Trim(), true);
            
            dataGridViewUserList.DataSource = dtUserList;
        }

        private void dataGridViewUserList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewUserList.Rows != null) && (dataGridViewUserList.SelectedRows.Count != 0))
            {
                btnMod.Enabled = true;
                btnDel.Enabled = true;
            }
            else
            {
                btnMod.Enabled = false;
                btnDel.Enabled = false;
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetNextControl(ActiveControl, true).Focus();
            }
        }

        private void 用户信息_Load(object sender, EventArgs e)
        {

        }
    }

}
