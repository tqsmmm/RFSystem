using BL;
using RFSystem.CommonClass;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RFSystem.ArriveStore
{
    public class 到库货物处理 : Form
    {
        private Button btnCancel;
        private Button btnDeal;
        private Label label4;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label labelAcceptAmount;
        private Label labelArriveListID;
        private Label labelDealAmount;
        private Label labelEquipmentName;
        private NumericUpDown numericUpDownDealAmount;
        private Regex regex;

        public 到库货物处理(string arriveListID, string equipmentName, string acceptAmount, string dealAmount)
        {
            InitializeComponent();
            regex = new Regex(ConstDefine.REGEX_NUM);
            labelArriveListID.Text = arriveListID;
            labelEquipmentName.Text = equipmentName;
            labelAcceptAmount.Text = acceptAmount;
            labelDealAmount.Text = dealAmount;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (numericUpDownDealAmount.Value == 0M)
            {
                MessageBox.Show("处理数量不能为零", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if ((numericUpDownDealAmount.Value + Convert.ToDecimal(labelDealAmount.Text)) <= Convert.ToDecimal(labelAcceptAmount.Text))
            {
                if (DBOperate.AddAmountArriveStoreDeal(labelArriveListID.Text, numericUpDownDealAmount.Value) == 1)
                {
                    MessageBox.Show("处理成功");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("处理失败，数据库出错", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("您要处理的货物数量超过实收货物数量，请确认", "数量超标", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void InitializeComponent()
        {
            this.labelArriveListID = new System.Windows.Forms.Label();
            this.labelEquipmentName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAcceptAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelDealAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeal = new System.Windows.Forms.Button();
            this.numericUpDownDealAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDealAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelArriveListID
            // 
            this.labelArriveListID.AutoSize = true;
            this.labelArriveListID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelArriveListID.Location = new System.Drawing.Point(97, 33);
            this.labelArriveListID.Name = "labelArriveListID";
            this.labelArriveListID.Size = new System.Drawing.Size(107, 22);
            this.labelArriveListID.TabIndex = 1;
            this.labelArriveListID.Text = "200801010001";
            // 
            // labelEquipmentName
            // 
            this.labelEquipmentName.AutoSize = true;
            this.labelEquipmentName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelEquipmentName.Location = new System.Drawing.Point(308, 55);
            this.labelEquipmentName.Name = "labelEquipmentName";
            this.labelEquipmentName.Size = new System.Drawing.Size(107, 22);
            this.labelEquipmentName.TabIndex = 3;
            this.labelEquipmentName.Text = "200801010001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "货物名称：";
            // 
            // labelAcceptAmount
            // 
            this.labelAcceptAmount.AutoSize = true;
            this.labelAcceptAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAcceptAmount.Location = new System.Drawing.Point(97, 55);
            this.labelAcceptAmount.Name = "labelAcceptAmount";
            this.labelAcceptAmount.Size = new System.Drawing.Size(107, 22);
            this.labelAcceptAmount.TabIndex = 5;
            this.labelAcceptAmount.Text = "200801010001";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "实收件数：";
            // 
            // labelDealAmount
            // 
            this.labelDealAmount.AutoSize = true;
            this.labelDealAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDealAmount.Location = new System.Drawing.Point(308, 82);
            this.labelDealAmount.Name = "labelDealAmount";
            this.labelDealAmount.Size = new System.Drawing.Size(107, 22);
            this.labelDealAmount.TabIndex = 7;
            this.labelDealAmount.Text = "200801010001";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "处理件数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "增加处理：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeal
            // 
            this.btnDeal.Location = new System.Drawing.Point(94, 123);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(100, 40);
            this.btnDeal.TabIndex = 10;
            this.btnDeal.Text = "处理";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // numericUpDownDealAmount
            // 
            this.numericUpDownDealAmount.Location = new System.Drawing.Point(97, 80);
            this.numericUpDownDealAmount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownDealAmount.Name = "numericUpDownDealAmount";
            this.numericUpDownDealAmount.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownDealAmount.TabIndex = 9;
            this.numericUpDownDealAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // 到库货物处理
            // 
            this.ClientSize = new System.Drawing.Size(444, 175);
            this.ControlBox = false;
            this.Controls.Add(this.numericUpDownDealAmount);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelDealAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelAcceptAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelEquipmentName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelArriveListID);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "到库货物处理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "到库货物处理";
            this.Load += new System.EventHandler(this.到库货物处理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDealAmount)).EndInit();
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

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetNextControl(ActiveControl, true).Focus();
            }
        }

        private void 到库货物处理_Load(object sender, EventArgs e)
        {

        }
    }
}
