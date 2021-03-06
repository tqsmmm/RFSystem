using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public class 用户信息 : Form
    {
        private Button btnCancel;
        private Button btnMod;
        private CheckBox checkBoxIsAdmin;
        private IContainer components = null;
        private ErrorProvider errorProvider;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private TextBox textBoxPassWord;
        private TextBox textBoxRePassWord;
        private TextBox textBoxUserID;
        private TextBox txtSapRolePoint;
        private Label label4;
        private TextBox textBoxUserName;

        public 用户信息(Hashtable userItem)
        {
            InitializeComponent();

            if (userItem != null)
            {
                textBoxUserID.Text = (string)userItem["User_ID"];
                textBoxUserName.Text = (string)userItem["User_Name"];

                txtSapRolePoint.Text = (string)userItem["Post_ID"];

                if (userItem["IsAdmin"].ToString() == "是")
                {
                    checkBoxIsAdmin.Checked = true;
                }
                else
                {
                    checkBoxIsAdmin.Checked = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ArrayList userItem = new ArrayList
                {
                    textBoxUserID.Text.Trim(),
                    textBoxUserName.Text.Trim(),
                    CommonFunction.getMd5Hash(textBoxPassWord.Text.Trim()),
                    txtSapRolePoint.Text.Trim(),
                    checkBoxIsAdmin.Checked ? 1 : 0
                };

                if (Text == "用户新增")
                {
                    int num = UserInfo.AddUser(userItem);

                    if (num != -1)
                    {
                        CommonFunction.Sys_MsgBox("用户 " + textBoxUserID.Text.Trim() + "|" + textBoxUserName.Text.Trim() + " 添加成功");
                        DialogResult = DialogResult.OK;
                    }
                    else if ((num == -10) || (num == 0xa43))
                    {
                        CommonFunction.Sys_MsgBox("您尝试添加重复用户，请确认");
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("添加用户出错，请确认是否添加重复用户并检查数据库联接是否正常");
                    }
                }
                else if (Text == "用户修改")
                {
                    if (UserInfo.ModUser(userItem) != -1)
                    {
                        CommonFunction.Sys_MsgBox("用户 " + textBoxUserID.Text.Trim() + "|" + textBoxUserName.Text.Trim() + " 信息修改成功");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("数据库出错，请联系系统管理员确认");
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxIsAdmin = new System.Windows.Forms.CheckBox();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.textBoxRePassWord = new System.Windows.Forms.TextBox();
            this.textBoxPassWord = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtSapRolePoint = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "用户工号：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(248, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.TabIndex = 908;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(122, 202);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(120, 50);
            this.btnMod.TabIndex = 907;
            this.btnMod.Text = "确定";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "确认密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "用户姓名：";
            // 
            // checkBoxIsAdmin
            // 
            this.checkBoxIsAdmin.AutoSize = true;
            this.checkBoxIsAdmin.Location = new System.Drawing.Point(184, 172);
            this.checkBoxIsAdmin.Name = "checkBoxIsAdmin";
            this.checkBoxIsAdmin.Size = new System.Drawing.Size(112, 24);
            this.checkBoxIsAdmin.TabIndex = 906;
            this.checkBoxIsAdmin.Text = "是否是管理员";
            this.checkBoxIsAdmin.UseVisualStyleBackColor = true;
            this.checkBoxIsAdmin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(184, 12);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(200, 26);
            this.textBoxUserID.TabIndex = 901;
            this.textBoxUserID.TabStop = false;
            // 
            // textBoxRePassWord
            // 
            this.textBoxRePassWord.Location = new System.Drawing.Point(184, 140);
            this.textBoxRePassWord.Name = "textBoxRePassWord";
            this.textBoxRePassWord.PasswordChar = '*';
            this.textBoxRePassWord.Size = new System.Drawing.Size(200, 26);
            this.textBoxRePassWord.TabIndex = 904;
            this.textBoxRePassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxPassWord
            // 
            this.textBoxPassWord.Location = new System.Drawing.Point(184, 108);
            this.textBoxPassWord.Name = "textBoxPassWord";
            this.textBoxPassWord.PasswordChar = '*';
            this.textBoxPassWord.Size = new System.Drawing.Size(200, 26);
            this.textBoxPassWord.TabIndex = 903;
            this.textBoxPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(184, 44);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(200, 26);
            this.textBoxUserName.TabIndex = 902;
            this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtSapRolePoint
            // 
            this.txtSapRolePoint.Location = new System.Drawing.Point(184, 76);
            this.txtSapRolePoint.Name = "txtSapRolePoint";
            this.txtSapRolePoint.Size = new System.Drawing.Size(200, 26);
            this.txtSapRolePoint.TabIndex = 910;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 909;
            this.label4.Text = "保管员岗位号：";
            // 
            // 用户信息
            // 
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.ControlBox = false;
            this.Controls.Add(this.txtSapRolePoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxIsAdmin);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.textBoxRePassWord);
            this.Controls.Add(this.textBoxPassWord);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "用户信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改用户信息";
            this.Load += new System.EventHandler(this.修改用户信息_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetNextControl(ActiveControl, true).Focus();
            }
        }

        private void SetErrorProvider(ErrorProvider errorProvider, Control errorControl, string errorMsg)
        {
            errorProvider.SetError(errorControl, errorMsg);
        }

        private bool ValidateInput()
        {
            if (textBoxUserID.Text.Trim().Equals(string.Empty) || textBoxUserName.Text.Trim().Equals(string.Empty))
            {
                CommonFunction.Sys_MsgBox("请填写完整信息");
                return false;
            }

            if (!textBoxPassWord.Text.Trim().Equals(textBoxRePassWord.Text.Trim()))
            {
                CommonFunction.Sys_MsgBox("请确认两次输入密码一致");
                textBoxPassWord.Focus();
                SetErrorProvider(errorProvider, textBoxPassWord, "两次输入密码不一致");
                SetErrorProvider(errorProvider, textBoxRePassWord, "两次输入密码不一致");
                return false;
            }

            return true;
        }

        private void 修改用户信息_Load(object sender, EventArgs e)
        {
            if (Text == "用户新增")
            {
                textBoxUserID.ReadOnly = false;
            }
            else if (Text == "用户修改")
            {
                textBoxUserID.ReadOnly = true;
            }
        }
    }
}
