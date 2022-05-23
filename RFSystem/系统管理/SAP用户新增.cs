using BL;
using RFSystem.CommonClass;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RFSystem
{
    public class SAP用户新增 : Form
    {
        private Button btnAdd;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private TextBox textBoxSapPassword;
        private TextBox textBoxSapUserID;

        public SAP用户新增()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                RFdesOperator @operator = new RFdesOperator();
                @operator.EncryptKey = "12345678";
                @operator.InputString = textBoxSapPassword.Text;
                @operator.DesEncrypt();

                if (DBOperate.AddSapUser(textBoxSapUserID.Text, @operator.OutString) != -1)
                {
                    MessageBox.Show("SAP用户 " + textBoxSapUserID.Text.Trim() + " 添加成功");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("SAP用户添加失败，请确认没有添加重复用户并且数据库联接正常");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxSapUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSapPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(44, 123);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBoxSapUserID
            // 
            this.textBoxSapUserID.Location = new System.Drawing.Point(107, 38);
            this.textBoxSapUserID.Name = "textBoxSapUserID";
            this.textBoxSapUserID.Size = new System.Drawing.Size(165, 26);
            this.textBoxSapUserID.TabIndex = 10;
            this.textBoxSapUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 41);
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
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "SAP密码：";
            // 
            // textBoxSapPassword
            // 
            this.textBoxSapPassword.Location = new System.Drawing.Point(107, 70);
            this.textBoxSapPassword.Name = "textBoxSapPassword";
            this.textBoxSapPassword.PasswordChar = '*';
            this.textBoxSapPassword.Size = new System.Drawing.Size(165, 26);
            this.textBoxSapPassword.TabIndex = 20;
            this.textBoxSapPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // SAP用户新增
            // 
            this.ClientSize = new System.Drawing.Size(294, 175);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxSapPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxSapUserID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SAP用户新增";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SAP用户添加";
            this.Load += new System.EventHandler(this.SAP用户新增_Load);
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
                MessageBox.Show("请填写完整信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void SAP用户新增_Load(object sender, EventArgs e)
        {

        }
    }
}
