using BL;
using RFSystem.CommonClass;
using System;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RFSystem
{
    public class 盘点条目信息新增 : Form
    {
        private Button btnAdd;
        private Button btnExit;
        private IContainer components = null;
        private Label label1;
        private Label label11;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Regex regex;
        private ArrayList stOriginItem = null;
        private TextBox textBoxBarCode;
        private TextBox textBoxBin;
        private TextBox textBoxBinCount;
        private TextBox textBoxBNumber;
        private TextBox textBoxMaterial;
        private TextBox textBoxOperatorDateTime;
        private TextBox textBoxOperatorUser;
        private TextBox textBoxPlant;
        private TextBox textBoxSLocation;
        private TextBox textBoxSTSerial;

        public 盘点条目信息新增(ArrayList stOriginItem)
        {
            InitializeComponent();
            regex = new Regex(ConstDefine.REGEX_NUM);
            this.stOriginItem = stOriginItem;
            textBoxSTSerial.Text = stOriginItem[0].ToString();
            textBoxPlant.Text = stOriginItem[1].ToString();
            textBoxSLocation.Text = stOriginItem[2].ToString();
            textBoxMaterial.Text = stOriginItem[3].ToString();
            textBoxBNumber.Text = stOriginItem[4].ToString();
            textBoxBarCode.Text = stOriginItem[5].ToString();
            textBoxOperatorUser.Text = stOriginItem[6].ToString();
            textBoxOperatorDateTime.Text = stOriginItem[7].ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxBin.Text.Equals(string.Empty) || textBoxBinCount.Text.Equals(string.Empty))
            {
                MessageBox.Show("信息填写不完整，请确认并填写完整信息", "信息填写不完整", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                ArrayList stOriginList = new ArrayList();
                stOriginList.Add(Convert.ToDecimal(textBoxSTSerial.Text));
                stOriginList.Add(textBoxPlant.Text);
                stOriginList.Add(textBoxSLocation.Text);
                stOriginList.Add(textBoxMaterial.Text);
                stOriginList.Add(textBoxBNumber.Text);
                stOriginList.Add(textBoxBin.Text);
                stOriginList.Add(Convert.ToDecimal(textBoxBinCount.Text));
                stOriginList.Add(textBoxBarCode.Text);
                stOriginList.Add(textBoxOperatorUser.Text);
                stOriginList.Add(textBoxOperatorDateTime.Text);

                if (DBOperate.AddNewSTOrigin(stOriginList) != -1)
                {
                    MessageBox.Show("盘点条目新增成功");
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void InitializeComponent()
        {
            this.textBoxSTSerial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPlant = new System.Windows.Forms.TextBox();
            this.textBoxOperatorDateTime = new System.Windows.Forms.TextBox();
            this.textBoxOperatorUser = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBinCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxSLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxSTSerial
            // 
            this.textBoxSTSerial.Location = new System.Drawing.Point(139, 27);
            this.textBoxSTSerial.Name = "textBoxSTSerial";
            this.textBoxSTSerial.ReadOnly = true;
            this.textBoxSTSerial.Size = new System.Drawing.Size(150, 26);
            this.textBoxSTSerial.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 76;
            this.label6.Text = "盘点序号：";
            // 
            // textBoxPlant
            // 
            this.textBoxPlant.Location = new System.Drawing.Point(380, 27);
            this.textBoxPlant.Name = "textBoxPlant";
            this.textBoxPlant.ReadOnly = true;
            this.textBoxPlant.Size = new System.Drawing.Size(150, 26);
            this.textBoxPlant.TabIndex = 75;
            // 
            // textBoxOperatorDateTime
            // 
            this.textBoxOperatorDateTime.Location = new System.Drawing.Point(380, 155);
            this.textBoxOperatorDateTime.Name = "textBoxOperatorDateTime";
            this.textBoxOperatorDateTime.ReadOnly = true;
            this.textBoxOperatorDateTime.Size = new System.Drawing.Size(150, 26);
            this.textBoxOperatorDateTime.TabIndex = 74;
            // 
            // textBoxOperatorUser
            // 
            this.textBoxOperatorUser.Location = new System.Drawing.Point(139, 155);
            this.textBoxOperatorUser.Name = "textBoxOperatorUser";
            this.textBoxOperatorUser.ReadOnly = true;
            this.textBoxOperatorUser.Size = new System.Drawing.Size(150, 26);
            this.textBoxOperatorUser.TabIndex = 73;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(295, 209);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 72;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 71;
            this.label5.Text = "盘点日时：";
            // 
            // textBoxBinCount
            // 
            this.textBoxBinCount.Location = new System.Drawing.Point(139, 123);
            this.textBoxBinCount.Name = "textBoxBinCount";
            this.textBoxBinCount.Size = new System.Drawing.Size(150, 26);
            this.textBoxBinCount.TabIndex = 70;
            this.textBoxBinCount.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 69;
            this.label4.Text = "实际库存：";
            // 
            // textBoxBarCode
            // 
            this.textBoxBarCode.Location = new System.Drawing.Point(380, 123);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.ReadOnly = true;
            this.textBoxBarCode.Size = new System.Drawing.Size(150, 26);
            this.textBoxBarCode.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "条码号：";
            // 
            // textBoxBNumber
            // 
            this.textBoxBNumber.Location = new System.Drawing.Point(139, 91);
            this.textBoxBNumber.Name = "textBoxBNumber";
            this.textBoxBNumber.ReadOnly = true;
            this.textBoxBNumber.Size = new System.Drawing.Size(150, 26);
            this.textBoxBNumber.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "批次：";
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(380, 91);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(150, 26);
            this.textBoxBin.TabIndex = 64;
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(380, 59);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.ReadOnly = true;
            this.textBoxMaterial.Size = new System.Drawing.Size(150, 26);
            this.textBoxMaterial.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 62;
            this.label1.Text = "盘点人：";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(189, 209);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 61;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(323, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 20);
            this.label14.TabIndex = 58;
            this.label14.Text = "公司：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(323, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 60;
            this.label11.Text = "物料：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(323, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 20);
            this.label13.TabIndex = 59;
            this.label13.Text = "货位：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(54, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 20);
            this.label15.TabIndex = 56;
            this.label15.Text = "存储地点：";
            // 
            // textBoxSLocation
            // 
            this.textBoxSLocation.Location = new System.Drawing.Point(139, 59);
            this.textBoxSLocation.Name = "textBoxSLocation";
            this.textBoxSLocation.ReadOnly = true;
            this.textBoxSLocation.Size = new System.Drawing.Size(150, 26);
            this.textBoxSLocation.TabIndex = 78;
            // 
            // 盘点条目信息新增
            // 
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxSLocation);
            this.Controls.Add(this.textBoxSTSerial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPlant);
            this.Controls.Add(this.textBoxOperatorDateTime);
            this.Controls.Add(this.textBoxOperatorUser);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxBinCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxBarCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxBNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxBin);
            this.Controls.Add(this.textBoxMaterial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "盘点条目信息新增";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "盘点条目信息新增";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void RegexNum(object sender, EventArgs e)
        {
            if (!((TextBox)sender).Text.Equals(string.Empty) && !regex.IsMatch(((TextBox)sender).Text))
            {
                MessageBox.Show("对不起，您所输入的不符合数字格式要求，请从新输入", "数字格式不符", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ((TextBox)sender).Focus();
            }
        }
    }
}
