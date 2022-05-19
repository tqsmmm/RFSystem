using BL;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RFSystem
{
    public class 新增保养数量 : Form
    {
        private Button btnCancel;
        private Button btnMaintain;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private decimal resultValue = 0M;
        private TextBox textBoxAddNum;
        private TextBox textBoxBARCODE;
        private TextBox textBoxBIN;
        private TextBox textBoxBIN_NUM;
        private TextBox textBoxMAINTAINNUM;
        private TextBox labelMAINTAIN_NO;
        private TextBox textBoxPRODUCT_NAME;

        public 新增保养数量(string maintainNo, string bin, string barCode, string productName, string binNum, string maintainNum)
        {
            InitializeComponent();
            labelMAINTAIN_NO.Text = maintainNo;
            textBoxBIN.Text = bin;
            textBoxBARCODE.Text = barCode;
            textBoxPRODUCT_NAME.Text = productName;
            textBoxBIN_NUM.Text = binNum;
            textBoxMAINTAINNUM.Text = maintainNum;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnMaintain_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDecimal(textBoxAddNum.Text.Trim());
            }
            catch
            {
                MessageBox.Show("数字格式输入不正确，请确认");
                return;
            }
            if (Convert.ToDecimal(textBoxBIN_NUM.Text.Trim()) < (Convert.ToDecimal(textBoxMAINTAINNUM.Text.Trim()) + Convert.ToDecimal(textBoxAddNum.Text.Trim())))
            {
                MessageBox.Show("保养数量超过保养单中的计划数量，请确认");
            }
            else
            {
                ArrayList alParams = new ArrayList();
                alParams.Add(labelMAINTAIN_NO.Text);
                alParams.Add(textBoxBARCODE.Text);
                alParams.Add(textBoxBIN.Text);
                alParams.Add(Convert.ToDecimal(textBoxAddNum.Text.Trim()));

                if (DBOperate.MaintainDetailAddCount(alParams) == -1)
                {
                    MessageBox.Show("数据更新失败，请确认保养过程中保养单状态没有被改变且数据库联接正常");
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    MessageBox.Show("保养成功");
                    resultValue = Convert.ToDecimal(textBoxAddNum.Text);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBIN_NUM = new System.Windows.Forms.TextBox();
            this.textBoxMAINTAINNUM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAddNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMaintain = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxBIN = new System.Windows.Forms.TextBox();
            this.textBoxBARCODE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPRODUCT_NAME = new System.Windows.Forms.TextBox();
            this.labelMAINTAIN_NO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "总保养量：";
            // 
            // textBoxBIN_NUM
            // 
            this.textBoxBIN_NUM.Location = new System.Drawing.Point(139, 124);
            this.textBoxBIN_NUM.Name = "textBoxBIN_NUM";
            this.textBoxBIN_NUM.ReadOnly = true;
            this.textBoxBIN_NUM.Size = new System.Drawing.Size(150, 26);
            this.textBoxBIN_NUM.TabIndex = 1;
            // 
            // textBoxMAINTAINNUM
            // 
            this.textBoxMAINTAINNUM.Location = new System.Drawing.Point(380, 124);
            this.textBoxMAINTAINNUM.Name = "textBoxMAINTAINNUM";
            this.textBoxMAINTAINNUM.ReadOnly = true;
            this.textBoxMAINTAINNUM.Size = new System.Drawing.Size(150, 26);
            this.textBoxMAINTAINNUM.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "已保养量：";
            // 
            // textBoxAddNum
            // 
            this.textBoxAddNum.Location = new System.Drawing.Point(139, 156);
            this.textBoxAddNum.Name = "textBoxAddNum";
            this.textBoxAddNum.Size = new System.Drawing.Size(150, 26);
            this.textBoxAddNum.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "新增保养：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(295, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMaintain
            // 
            this.btnMaintain.Location = new System.Drawing.Point(189, 209);
            this.btnMaintain.Name = "btnMaintain";
            this.btnMaintain.Size = new System.Drawing.Size(100, 40);
            this.btnMaintain.TabIndex = 7;
            this.btnMaintain.Text = "进行保养";
            this.btnMaintain.UseVisualStyleBackColor = true;
            this.btnMaintain.Click += new System.EventHandler(this.btnMaintain_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "保养单号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "货位：";
            // 
            // textBoxBIN
            // 
            this.textBoxBIN.Location = new System.Drawing.Point(380, 28);
            this.textBoxBIN.Name = "textBoxBIN";
            this.textBoxBIN.ReadOnly = true;
            this.textBoxBIN.Size = new System.Drawing.Size(150, 26);
            this.textBoxBIN.TabIndex = 11;
            // 
            // textBoxBARCODE
            // 
            this.textBoxBARCODE.Location = new System.Drawing.Point(139, 60);
            this.textBoxBARCODE.Name = "textBoxBARCODE";
            this.textBoxBARCODE.ReadOnly = true;
            this.textBoxBARCODE.Size = new System.Drawing.Size(391, 26);
            this.textBoxBARCODE.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "条 码 号：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "货物名称：";
            // 
            // textBoxPRODUCT_NAME
            // 
            this.textBoxPRODUCT_NAME.Location = new System.Drawing.Point(139, 92);
            this.textBoxPRODUCT_NAME.Name = "textBoxPRODUCT_NAME";
            this.textBoxPRODUCT_NAME.ReadOnly = true;
            this.textBoxPRODUCT_NAME.Size = new System.Drawing.Size(391, 26);
            this.textBoxPRODUCT_NAME.TabIndex = 15;
            // 
            // labelMAINTAIN_NO
            // 
            this.labelMAINTAIN_NO.Location = new System.Drawing.Point(139, 28);
            this.labelMAINTAIN_NO.Name = "labelMAINTAIN_NO";
            this.labelMAINTAIN_NO.ReadOnly = true;
            this.labelMAINTAIN_NO.Size = new System.Drawing.Size(150, 26);
            this.labelMAINTAIN_NO.TabIndex = 16;
            // 
            // 新增保养数量
            // 
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.ControlBox = false;
            this.Controls.Add(this.labelMAINTAIN_NO);
            this.Controls.Add(this.textBoxPRODUCT_NAME);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxBARCODE);
            this.Controls.Add(this.textBoxBIN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnMaintain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBoxAddNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMAINTAINNUM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxBIN_NUM);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "新增保养数量";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增保养数量";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public decimal ResultValue
        {
            get
            {
                return resultValue;
            }
        }
    }
}
