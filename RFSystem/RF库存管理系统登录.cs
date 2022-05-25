using RFSystem.AnSteel;
using RFSystem.CommonClass;
using RFSystem.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RFSystem
{
    public class RF库存管理系统登录 : Form
    {
        private Button btnExit;
        private Button btnLogin;
        private IContainer components = null;
        private ErrorProvider errorProvider;
        private Label label1;
        private Label label2;
        private TextBox textBoxPassWord;
        private TextBox textBoxUserID;

        public RF库存管理系统登录()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (string.IsNullOrEmpty(textBoxUserID.Text.Trim()) || string.IsNullOrEmpty(textBoxPassWord.Text.Trim()))
            {
                CommonFunction.Sys_MsgBox("用户帐号及密码不可为空");

                if (string.IsNullOrEmpty(textBoxPassWord.Text.Trim()))
                {
                    errorProvider.SetError(textBoxPassWord, "输入不可为空");
                    textBoxPassWord.Focus();
                }

                if (string.IsNullOrEmpty(textBoxUserID.Text.Trim()))
                {
                    errorProvider.SetError(textBoxUserID, "输入不可为空");
                    textBoxUserID.Focus();
                }
            }
            else
            {
                string str2;
                string str = Settings.Default.RFSystem_AnSteel_AnSteelInterFace.ToString();
                ConstDefine.g_User = textBoxUserID.Text.Trim().ToUpperInvariant();
                ConstDefine.g_PassWord = textBoxPassWord.Text.Trim();
                ConstDefine.g_ConnStr = str;
                privilidge privateStr = new privilidge();

                try
                {
                    rfid2021Service.rfidService _rfid2021service = new rfid2021Service.rfidService();
                    rfid2021Service.privilidge privateStr_new;
                    rfid2021Service.MessagePack pack = _rfid2021service.Login(textBoxUserID.Text.Trim().ToUpperInvariant(), textBoxPassWord.Text.Trim(), out ConstDefine.g_bxuserid, out ConstDefine.g_bxusername, out ConstDefine.g_bxjobid, out privateStr_new, out str2);
                    
                    if (!pack.Result)
                    {
                        CommonFunction.Sys_MsgBox(pack.Message);
                        return;
                    }
                }
                catch (Exception exception)
                {
                    CommonFunction.Sys_MsgBox(exception.Message);
                    return;
                }

                ConstDefine.g_DbConnStr = str2;
                DBOperate.ConnStr = str2;
                ClsCommon.ConnStr = str2;
                PrintDBOperate.ConnStr = str2;
                DialogResult = DialogResult.OK;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.textBoxPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(119, 199);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 50);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(245, 199);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 50);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(185, 57);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(200, 26);
            this.textBoxUserID.TabIndex = 0;
            this.textBoxUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxPassWord
            // 
            this.textBoxPassWord.Location = new System.Drawing.Point(185, 94);
            this.textBoxPassWord.Name = "textBoxPassWord";
            this.textBoxPassWord.PasswordChar = '*';
            this.textBoxPassWord.Size = new System.Drawing.Size(200, 26);
            this.textBoxPassWord.TabIndex = 1;
            this.textBoxPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "用户帐号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "用户密码：";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RF库存管理系统登录
            // 
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassWord);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RF库存管理系统登录";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RF库存管理系统登录";
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
    }
}
