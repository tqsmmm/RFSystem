namespace RFSystem.ArriveStore
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class 到库货物存放信息 : Form
    {
        private ArrayList arriveStoreStorageInfo = null;
        private Button btnCancel;
        private Button btnOK;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDownAmount;
        private TextBox textBoxRemark;
        private TextBox textBoxStorePosition;

        public 到库货物存放信息()
        {
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.textBoxStorePosition.Text.Trim().Equals(string.Empty) || (this.numericUpDownAmount.Value == 0M))
            {
                MessageBox.Show("录入信息不完整，请填写完整信息(库位及库位数量)", "信息不完整", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.arriveStoreStorageInfo = new ArrayList();
                this.arriveStoreStorageInfo.Add(this.textBoxStorePosition.Text);
                this.arriveStoreStorageInfo.Add((int)this.numericUpDownAmount.Value);
                this.arriveStoreStorageInfo.Add(this.textBoxRemark.Text);
                base.DialogResult = DialogResult.OK;
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStorePosition = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1000;
            this.label1.Text = "存放库位：";
            // 
            // textBoxStorePosition
            // 
            this.textBoxStorePosition.Location = new System.Drawing.Point(97, 12);
            this.textBoxStorePosition.Name = "textBoxStorePosition";
            this.textBoxStorePosition.Size = new System.Drawing.Size(169, 26);
            this.textBoxStorePosition.TabIndex = 0;
            this.textBoxStorePosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 1000;
            this.label2.Text = "存放数量：";
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Location = new System.Drawing.Point(357, 12);
            this.numericUpDownAmount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(75, 26);
            this.numericUpDownAmount.TabIndex = 10;
            this.numericUpDownAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 1000;
            this.label3.Text = "备注：";
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.Location = new System.Drawing.Point(97, 44);
            this.textBoxRemark.Multiline = true;
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(335, 73);
            this.textBoxRemark.TabIndex = 20;
            this.textBoxRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(332, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(226, 123);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // 到库货物存放信息
            // 
            this.ClientSize = new System.Drawing.Size(444, 175);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBoxRemark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxStorePosition);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "到库货物存放信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "到库货物存放信息";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.GetNextControl(base.ActiveControl, true).Focus();
            }
        }

        public ArrayList ArriveStoreStorageInfo
        {
            get
            {
                return this.arriveStoreStorageInfo;
            }
        }
    }
}
