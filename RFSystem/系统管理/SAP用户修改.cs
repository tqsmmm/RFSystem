using BL;
using RFSystem.CommonClass;
using System;
using System.Windows.Forms;

namespace RFSystem
{
    public class SAP用户修改 : Form
    {
        private Button btnCancel;
        private Button btnMod;
        private Label label1;
        private Label label2;
        private TextBox textBoxSapPassword;
        private TextBox textBoxSapUserID;

        public SAP用户修改(string userID)
        {
            InitializeComponent();
            textBoxSapUserID.Text = userID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                RFdesOperator @operator = new RFdesOperator();
                @operator.EncryptKey = "12345678";
                @operator.InputString = textBoxSapPassword.Text;
                @operator.DesEncrypt();

                if (DBOperate.ModSapUser(textBoxSapUserID.Text, @operator.OutString) != -1)
                {
                    CommonFunction.Sys_MsgBox("SAP用户 " + textBoxSapUserID.Text.Trim() + " 修改成功");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    CommonFunction.Sys_MsgBox("数据库出错，请联系系统管理员确认");
                }
            }
        }

        private void InitializeComponent()
        {
            this.textBoxSapPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMod = new System.Windows.Forms.Button();
            this.textBoxSapUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSapPassword
            // 
            this.textBoxSapPassword.Location = new System.Drawing.Point(107, 73);
            this.textBoxSapPassword.Name = "textBoxSapPassword";
            this.textBoxSapPassword.PasswordChar = '*';
            this.textBoxSapPassword.Size = new System.Drawing.Size(165, 26);
            this.textBoxSapPassword.TabIndex = 10;
            this.textBoxSapPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "SAP密码：";
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(44, 123);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 20;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // textBoxSapUserID
            // 
            this.textBoxSapUserID.Location = new System.Drawing.Point(107, 41);
            this.textBoxSapUserID.Name = "textBoxSapUserID";
            this.textBoxSapUserID.ReadOnly = true;
            this.textBoxSapUserID.Size = new System.Drawing.Size(165, 26);
            this.textBoxSapUserID.TabIndex = 10000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "SAP用户：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SAP用户修改
            // 
            this.ClientSize = new System.Drawing.Size(294, 175);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxSapPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.textBoxSapUserID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SAP用户修改";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sap用户修改";
            this.Load += new System.EventHandler(this.SAP用户修改_Load);
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
            if (textBoxSapUserID.Text.Trim().Equals(string.Empty))
            {
                CommonFunction.Sys_MsgBox("请填写完整信息");
                return false;
            }

            return true;
        }

        private void SAP用户修改_Load(object sender, EventArgs e)
        {

        }
    }
}
