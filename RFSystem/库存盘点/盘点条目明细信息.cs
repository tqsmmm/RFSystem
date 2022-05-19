using BL;
using RFSystem.CommonClass;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RFSystem
{
    public class 盘点条目明细信息 : Form
    {
        private Button btnExit;
        private Button btnMod;
        private ComboBox comboBoxSLocation;
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
        private TextBox textBoxSTSerial;

        public 盘点条目明细信息(ArrayList stOriginItem)
        {
            InitializeComponent();
            regex = new Regex(ConstDefine.REGEX_NUM);
            this.stOriginItem = stOriginItem;
            textBoxSTSerial.Text = stOriginItem[0].ToString();
            textBoxPlant.Text = stOriginItem[1].ToString();
            DataTable storeLocusList = null;
            storeLocusList = DBOperate.GetStoreLocusList(string.Empty, textBoxPlant.Text);

            foreach (DataRow row in storeLocusList.Rows)
            {
                comboBoxSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            comboBoxSLocation.Text = stOriginItem[2].ToString();
            textBoxMaterial.Text = stOriginItem[3].ToString();
            textBoxBNumber.Text = stOriginItem[4].ToString();
            textBoxBin.Text = stOriginItem[5].ToString();
            textBoxBinCount.Text = stOriginItem[6].ToString();
            textBoxBarCode.Text = stOriginItem[7].ToString();
            textBoxOperatorUser.Text = stOriginItem[8].ToString();
            textBoxOperatorDateTime.Text = stOriginItem[9].ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if ((comboBoxSLocation.Text.Equals(string.Empty) || textBoxBin.Text.Equals(string.Empty)) || textBoxBinCount.Text.Equals(string.Empty))
            {
                MessageBox.Show("信息填写不完整，请确认并填写完整信息", "信息填写不完整", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                ArrayList stOriginList = new ArrayList();
                stOriginList.Add(Convert.ToDecimal(stOriginItem[0]));
                stOriginList.Add(comboBoxSLocation.Text);
                stOriginList.Add(textBoxBin.Text);
                stOriginList.Add(Convert.ToDecimal(textBoxBinCount.Text));

                if (DBOperate.ModSTOrigin(stOriginList) != -1)
                {
                    MessageBox.Show("盘点条目修改成功");
                    stOriginItem[2] = comboBoxSLocation.Text;
                    stOriginItem[5] = textBoxBin.Text;
                    stOriginItem[6] = textBoxBinCount.Text;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void InitializeComponent()
        {
            this.textBoxBNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMod = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBinCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.textBoxOperatorUser = new System.Windows.Forms.TextBox();
            this.textBoxOperatorDateTime = new System.Windows.Forms.TextBox();
            this.textBoxPlant = new System.Windows.Forms.TextBox();
            this.textBoxSTSerial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxBNumber
            // 
            this.textBoxBNumber.Location = new System.Drawing.Point(146, 88);
            this.textBoxBNumber.Name = "textBoxBNumber";
            this.textBoxBNumber.ReadOnly = true;
            this.textBoxBNumber.Size = new System.Drawing.Size(150, 26);
            this.textBoxBNumber.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "批次：";
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(387, 88);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(150, 26);
            this.textBoxBin.TabIndex = 41;
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(387, 56);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.ReadOnly = true;
            this.textBoxMaterial.Size = new System.Drawing.Size(150, 26);
            this.textBoxMaterial.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "盘点人：";
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(189, 209);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 36;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(330, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "公司：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(330, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "物料：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(330, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "货位：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(61, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "存储地点：";
            // 
            // textBoxBarCode
            // 
            this.textBoxBarCode.Location = new System.Drawing.Point(387, 120);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.ReadOnly = true;
            this.textBoxBarCode.Size = new System.Drawing.Size(150, 26);
            this.textBoxBarCode.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "条码号：";
            // 
            // textBoxBinCount
            // 
            this.textBoxBinCount.Location = new System.Drawing.Point(146, 120);
            this.textBoxBinCount.Name = "textBoxBinCount";
            this.textBoxBinCount.Size = new System.Drawing.Size(150, 26);
            this.textBoxBinCount.TabIndex = 47;
            this.textBoxBinCount.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "实际库存：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "盘点日时：";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(295, 209);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 50;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // textBoxOperatorUser
            // 
            this.textBoxOperatorUser.Location = new System.Drawing.Point(146, 152);
            this.textBoxOperatorUser.Name = "textBoxOperatorUser";
            this.textBoxOperatorUser.ReadOnly = true;
            this.textBoxOperatorUser.Size = new System.Drawing.Size(150, 26);
            this.textBoxOperatorUser.TabIndex = 51;
            // 
            // textBoxOperatorDateTime
            // 
            this.textBoxOperatorDateTime.Location = new System.Drawing.Point(387, 152);
            this.textBoxOperatorDateTime.Name = "textBoxOperatorDateTime";
            this.textBoxOperatorDateTime.ReadOnly = true;
            this.textBoxOperatorDateTime.Size = new System.Drawing.Size(150, 26);
            this.textBoxOperatorDateTime.TabIndex = 52;
            // 
            // textBoxPlant
            // 
            this.textBoxPlant.Location = new System.Drawing.Point(387, 24);
            this.textBoxPlant.Name = "textBoxPlant";
            this.textBoxPlant.ReadOnly = true;
            this.textBoxPlant.Size = new System.Drawing.Size(150, 26);
            this.textBoxPlant.TabIndex = 53;
            // 
            // textBoxSTSerial
            // 
            this.textBoxSTSerial.Location = new System.Drawing.Point(146, 22);
            this.textBoxSTSerial.Name = "textBoxSTSerial";
            this.textBoxSTSerial.ReadOnly = true;
            this.textBoxSTSerial.Size = new System.Drawing.Size(150, 26);
            this.textBoxSTSerial.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 54;
            this.label6.Text = "条目流水号：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(146, 54);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(150, 28);
            this.comboBoxSLocation.TabIndex = 31;
            // 
            // 盘点条目明细信息
            // 
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.ControlBox = false;
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
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboBoxSLocation);
            this.Controls.Add(this.label15);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "盘点条目明细信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "货物盘点明细条目信息";
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

        public ArrayList STOriginItem
        {
            get
            {
                return stOriginItem;
            }
        }
    }
}
