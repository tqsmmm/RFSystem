using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RFSystem
{
    public class 盘点报表明细信息 : Form
    {
        private Button btnExit;
        private Button btnMod;
        private bool ifTurnRight = true;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Regex regex;
        private ArrayList reportItem;
        private TextBox textBoxSapBin1;
        private TextBox textBoxSapBin2;
        private TextBox textBoxSapBin3;
        private TextBox textBoxSapBinCount1;
        private TextBox textBoxSapBinCount2;
        private TextBox textBoxSapBinCount3;
        private TextBox textBoxSTBin1;
        private TextBox textBoxSTBin2;
        private TextBox textBoxSTBin3;
        private TextBox textBoxSTBinCount1;
        private TextBox textBoxSTBinCount2;
        private TextBox textBoxSTBinCount3;
        private UserInfo userItem = null;
        private ArrayList userRoles = null;

        public 盘点报表明细信息(UserInfo userItem, ArrayList userRoles, ArrayList reportItem)
        {
            InitializeComponent();
            regex = new Regex(ConstDefine.REGEX_NUM);
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.reportItem = reportItem;
            textBoxSapBin1.Text = reportItem[0].ToString();
            textBoxSapBinCount1.Text = reportItem[1].ToString();
            textBoxSapBin2.Text = reportItem[2].ToString();
            textBoxSapBinCount2.Text = reportItem[3].ToString();
            textBoxSapBin3.Text = reportItem[4].ToString();
            textBoxSapBinCount3.Text = reportItem[5].ToString();
            textBoxSTBin1.Text = reportItem[6].ToString();
            textBoxSTBinCount1.Text = reportItem[7].ToString();
            textBoxSTBin2.Text = reportItem[8].ToString();
            textBoxSTBinCount2.Text = reportItem[9].ToString();
            textBoxSTBin3.Text = reportItem[10].ToString();
            textBoxSTBinCount3.Text = reportItem[11].ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            bool flag = true;

            if ((((!textBoxSapBin1.Text.Equals(textBoxSTBin1.Text) || !textBoxSapBinCount1.Text.Equals(textBoxSTBinCount1.Text)) || (!textBoxSapBin2.Text.Equals(textBoxSTBin2.Text) || !this.textBoxSapBinCount2.Text.Equals(this.textBoxSTBinCount2.Text))) || !this.textBoxSapBin3.Text.Equals(this.textBoxSTBin3.Text)) || !this.textBoxSapBinCount3.Text.Equals(this.textBoxSTBinCount3.Text))
            {
                ifTurnRight = false;

                if (!CommonFunction.Sys_MsgYN("当前盘点货位信息或数量信息与SAP理论库存信息不一致，是否继续修改？"))
                {
                    flag = false;
                }
            }

            if (flag)
            {
                ArrayList reportList = new ArrayList();
                reportList.Add(reportItem[12].ToString());
                reportList.Add(textBoxSTBin1.Text);
                reportList.Add(Convert.ToDecimal(textBoxSTBinCount1.Text));
                reportList.Add(textBoxSTBin2.Text);
                reportList.Add(Convert.ToDecimal(textBoxSTBinCount2.Text));
                reportList.Add(textBoxSTBin3.Text);
                reportList.Add(Convert.ToDecimal(textBoxSTBinCount3.Text));

                if (DBOperate.ModReport(reportList) != -1)
                {
                    CommonFunction.Sys_MsgBox("盘点报表条目修改成功");
                    reportItem[6] = textBoxSTBin1.Text;
                    reportItem[7] = textBoxSTBinCount1.Text;
                    reportItem[8] = textBoxSTBin2.Text;
                    reportItem[9] = textBoxSTBinCount2.Text;
                    reportItem[10] = textBoxSTBin3.Text;
                    reportItem[11] = textBoxSTBinCount3.Text;
                    DialogResult = DialogResult.OK;

                    if (ifTurnRight)
                    {
                        DBOperate.ModReportCausation(reportItem[12].ToString(), string.Empty);
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSapBin1 = new System.Windows.Forms.TextBox();
            this.textBoxSapBinCount1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSapBinCount2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSapBin2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSapBinCount3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSapBin3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSTBinCount3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSTBin3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSTBinCount2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSTBin2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSTBinCount1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxSTBin1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "理论货位1：";
            // 
            // textBoxSapBin1
            // 
            this.textBoxSapBin1.Location = new System.Drawing.Point(135, 32);
            this.textBoxSapBin1.Name = "textBoxSapBin1";
            this.textBoxSapBin1.ReadOnly = true;
            this.textBoxSapBin1.Size = new System.Drawing.Size(150, 26);
            this.textBoxSapBin1.TabIndex = 1;
            // 
            // textBoxSapBinCount1
            // 
            this.textBoxSapBinCount1.Location = new System.Drawing.Point(135, 64);
            this.textBoxSapBinCount1.Name = "textBoxSapBinCount1";
            this.textBoxSapBinCount1.ReadOnly = true;
            this.textBoxSapBinCount1.Size = new System.Drawing.Size(150, 26);
            this.textBoxSapBinCount1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "理论数量：";
            // 
            // textBoxSapBinCount2
            // 
            this.textBoxSapBinCount2.Location = new System.Drawing.Point(135, 128);
            this.textBoxSapBinCount2.Name = "textBoxSapBinCount2";
            this.textBoxSapBinCount2.ReadOnly = true;
            this.textBoxSapBinCount2.Size = new System.Drawing.Size(150, 26);
            this.textBoxSapBinCount2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "理论数量：";
            // 
            // textBoxSapBin2
            // 
            this.textBoxSapBin2.Location = new System.Drawing.Point(135, 96);
            this.textBoxSapBin2.Name = "textBoxSapBin2";
            this.textBoxSapBin2.ReadOnly = true;
            this.textBoxSapBin2.Size = new System.Drawing.Size(150, 26);
            this.textBoxSapBin2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "理论货位2：";
            // 
            // textBoxSapBinCount3
            // 
            this.textBoxSapBinCount3.Location = new System.Drawing.Point(135, 192);
            this.textBoxSapBinCount3.Name = "textBoxSapBinCount3";
            this.textBoxSapBinCount3.ReadOnly = true;
            this.textBoxSapBinCount3.Size = new System.Drawing.Size(150, 26);
            this.textBoxSapBinCount3.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "理论数量：";
            // 
            // textBoxSapBin3
            // 
            this.textBoxSapBin3.Location = new System.Drawing.Point(135, 160);
            this.textBoxSapBin3.Name = "textBoxSapBin3";
            this.textBoxSapBin3.ReadOnly = true;
            this.textBoxSapBin3.Size = new System.Drawing.Size(150, 26);
            this.textBoxSapBin3.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "理论货位3：";
            // 
            // textBoxSTBinCount3
            // 
            this.textBoxSTBinCount3.Location = new System.Drawing.Point(392, 192);
            this.textBoxSTBinCount3.Name = "textBoxSTBinCount3";
            this.textBoxSTBinCount3.Size = new System.Drawing.Size(150, 26);
            this.textBoxSTBinCount3.TabIndex = 23;
            this.textBoxSTBinCount3.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "实际数量：";
            // 
            // textBoxSTBin3
            // 
            this.textBoxSTBin3.Location = new System.Drawing.Point(392, 160);
            this.textBoxSTBin3.Name = "textBoxSTBin3";
            this.textBoxSTBin3.Size = new System.Drawing.Size(150, 26);
            this.textBoxSTBin3.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "实际货位3：";
            // 
            // textBoxSTBinCount2
            // 
            this.textBoxSTBinCount2.Location = new System.Drawing.Point(392, 128);
            this.textBoxSTBinCount2.Name = "textBoxSTBinCount2";
            this.textBoxSTBinCount2.Size = new System.Drawing.Size(150, 26);
            this.textBoxSTBinCount2.TabIndex = 19;
            this.textBoxSTBinCount2.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(307, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "实际数量：";
            // 
            // textBoxSTBin2
            // 
            this.textBoxSTBin2.Location = new System.Drawing.Point(392, 96);
            this.textBoxSTBin2.Name = "textBoxSTBin2";
            this.textBoxSTBin2.Size = new System.Drawing.Size(150, 26);
            this.textBoxSTBin2.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(299, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "实际货位2：";
            // 
            // textBoxSTBinCount1
            // 
            this.textBoxSTBinCount1.Location = new System.Drawing.Point(392, 64);
            this.textBoxSTBinCount1.Name = "textBoxSTBinCount1";
            this.textBoxSTBinCount1.Size = new System.Drawing.Size(150, 26);
            this.textBoxSTBinCount1.TabIndex = 15;
            this.textBoxSTBinCount1.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(307, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "实际数量：";
            // 
            // textBoxSTBin1
            // 
            this.textBoxSTBin1.Location = new System.Drawing.Point(392, 32);
            this.textBoxSTBin1.Name = "textBoxSTBin1";
            this.textBoxSTBin1.Size = new System.Drawing.Size(150, 26);
            this.textBoxSTBin1.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(299, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "实际货位1：";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(295, 259);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(189, 259);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 25;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // 盘点报表明细信息
            // 
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.textBoxSTBinCount3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSTBin3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxSTBinCount2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxSTBin2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxSTBinCount1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxSTBin1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxSapBinCount3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxSapBin3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxSapBinCount2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSapBin2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSapBinCount1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSapBin1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "盘点报表明细信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "盘点报表明细信息";
            this.Leave += new System.EventHandler(this.RegexNum);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void RegexNum(object sender, EventArgs e)
        {
            if (!((TextBox)sender).Text.Equals(string.Empty) && !regex.IsMatch(((TextBox)sender).Text))
            {
                CommonFunction.Sys_MsgBox("对不起，您所输入的不符合数字格式要求，请从新输入");
                ((TextBox)sender).Focus();
            }
        }

        public bool IfTurnRight
        {
            get
            {
                return ifTurnRight;
            }
        }

        public ArrayList ReportItem
        {
            get
            {
                return reportItem;
            }
        }
    }
}
