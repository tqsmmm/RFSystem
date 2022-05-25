using System;
using System.Data;
using System.Windows.Forms;
using RFSystem.CommonClass;

namespace RFSystem
{
    public class SAP用户管理 : Form
    {
        // Fields
        private Button btnAdd;
        private Button btnDel;
        private Button btnExit;
        private Button btnMod;
        private Button btnSelect;
        private DataGridViewTextBoxColumn columnSapPassword;
        private DataGridViewTextBoxColumn columnSapUserID;
        private DataGridView dataGridViewSapUserList;
        private DataTable dtSapUserList;
        private Label label8;
        private TextBox textBoxSapUserID;

        private void InitializeComponent()
        {
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxSapUserID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewSapUserList = new System.Windows.Forms.DataGridView();
            this.columnSapUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSapPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(118, 423);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 41;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 423);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(224, 423);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 40);
            this.btnDel.TabIndex = 40;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(330, 423);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 40;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(282, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 20;
            this.btnSelect.Text = "查找";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxSapUserID
            // 
            this.textBoxSapUserID.Location = new System.Drawing.Point(156, 19);
            this.textBoxSapUserID.Name = "textBoxSapUserID";
            this.textBoxSapUserID.Size = new System.Drawing.Size(120, 26);
            this.textBoxSapUserID.TabIndex = 10;
            this.textBoxSapUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "用户编号：";
            // 
            // dataGridViewSapUserList
            // 
            this.dataGridViewSapUserList.AllowUserToAddRows = false;
            this.dataGridViewSapUserList.AllowUserToResizeRows = false;
            this.dataGridViewSapUserList.ColumnHeadersHeight = 30;
            this.dataGridViewSapUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSapUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSapUserID,
            this.columnSapPassword});
            this.dataGridViewSapUserList.Location = new System.Drawing.Point(12, 66);
            this.dataGridViewSapUserList.MultiSelect = false;
            this.dataGridViewSapUserList.Name = "dataGridViewSapUserList";
            this.dataGridViewSapUserList.ReadOnly = true;
            this.dataGridViewSapUserList.RowHeadersVisible = false;
            this.dataGridViewSapUserList.RowTemplate.Height = 23;
            this.dataGridViewSapUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSapUserList.Size = new System.Drawing.Size(420, 351);
            this.dataGridViewSapUserList.TabIndex = 30;
            this.dataGridViewSapUserList.SelectionChanged += new System.EventHandler(this.dataGridViewSapUserList_SelectionChanged);
            // 
            // columnSapUserID
            // 
            this.columnSapUserID.DataPropertyName = "SapUserID";
            this.columnSapUserID.HeaderText = "Sap用户帐号";
            this.columnSapUserID.Name = "columnSapUserID";
            this.columnSapUserID.ReadOnly = true;
            this.columnSapUserID.Width = 225;
            // 
            // columnSapPassword
            // 
            this.columnSapPassword.DataPropertyName = "SapPassword";
            this.columnSapPassword.HeaderText = "Sap密码";
            this.columnSapPassword.Name = "columnSapPassword";
            this.columnSapPassword.ReadOnly = true;
            this.columnSapPassword.Visible = false;
            // 
            // SAP用户管理
            // 
            this.ClientSize = new System.Drawing.Size(444, 475);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewSapUserList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxSapUserID);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SAP用户管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAP用户管理";
            this.Load += new System.EventHandler(this.SAP用户管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapUserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public SAP用户管理()
        {
            dtSapUserList = null;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SAP用户新增 sap用户新增 = new SAP用户新增();

            if (sap用户新增.ShowDialog() == DialogResult.OK)
            {
                btnSelect.PerformClick();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewSapUserList.SelectedRows != null)
            {
                if (!DBOperate.GetSapInfoBySapID(dataGridViewSapUserList.SelectedRows[0].Cells["columnSapUserID"].Value.ToString()).Rows[0][0].ToString().Equals("0"))
                {
                    CommonFunction.Sys_MsgBox("当前Sap用户还在被使用中，去除所有使用当前Sap用户的用户授权点");
                }
                else if (CommonFunction.IfHasData(dtSapUserList))
                {
                    if (CommonFunction.Sys_MsgYN("确认删除此条Sap用户信息么？") && (DBOperate.DelSapUser((string)dataGridViewSapUserList.SelectedRows[0].Cells["columnSapUserID"].Value) != -1))
                    {
                        CommonFunction.Sys_MsgBox("Sap用户信息删除成功");
                        btnSelect.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("没有检索到任何Sap用户信息，无法修改");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("请选择一条Sap用户信息");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            SAP用户修改 sap用户修改 = new SAP用户修改((string)dataGridViewSapUserList.SelectedRows[0].Cells["columnSapUserID"].Value);

            if (sap用户修改.ShowDialog() == DialogResult.OK)
            {
                btnSelect.PerformClick();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dtSapUserList = DBOperate.GetSapUserList(textBoxSapUserID.Text.Trim());
            dataGridViewSapUserList.DataSource = dtSapUserList;
        }

        private void dataGridViewSapUserList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewSapUserList.Rows != null) && (dataGridViewSapUserList.SelectedRows.Count != 0))
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

        private void SAP用户管理_Load(object sender, EventArgs e)
        {

        }
    }
}