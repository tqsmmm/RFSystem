using System;
using System.Collections;
using System.Windows.Forms;

namespace RFSystem
{
    public class 库存账套信息 : Form
    {
        private Button btnCancel;
        private Button btnMod;
        private Label label1;
        private Label label2;
        private TextBox textBoxPlantID;
        private Label label3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBoxPlantDescription;

        public 库存账套信息(Hashtable plantItem)
        {
            InitializeComponent();

            if (plantItem != null)
            {
                textBoxPlantID.Text = (string)plantItem["PlantID"];
                textBoxPlantDescription.Text = (string)plantItem["PlantDescription"];

                if (string.IsNullOrEmpty(plantItem["isActive"].ToString()))
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    if ((bool)plantItem["isActive"])
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                bool bIsActive = false;

                if (radioButton1.Checked)
                {
                    bIsActive = true;
                }

                if (Text == "库存账套新增")
                {
                    if (DBOperate.AddPlant(textBoxPlantID.Text.Trim(), textBoxPlantDescription.Text.Trim(), bIsActive) != -1)
                    {
                        CommonFunction.Sys_MsgBox("库存账套 " + textBoxPlantID.Text.Trim() + " 添加成功");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("库存账套信息添加失败，请确认没有添加重复库存账套编号并且数据库联接正常");
                    }
                }
                else if (Text == "库存账套修改")
                {
                    if (DBOperate.ModPlant(textBoxPlantID.Text, textBoxPlantDescription.Text.Trim(), bIsActive) != -1)
                    {
                        CommonFunction.Sys_MsgBox("库存账套 " + textBoxPlantID.Text + " 信息修改成功");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("数据库出错，请联系系统管理员确认");
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            if (textBoxPlantID.Text.Trim().Equals(string.Empty) || textBoxPlantDescription.Text.Trim().Equals(string.Empty))
            {
                CommonFunction.Sys_MsgBox("请填写完整信息");
                return false;
            }

            return true;
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPlantDescription = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.textBoxPlantID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "库存账套编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "库存账套描述：";
            // 
            // textBoxPlantDescription
            // 
            this.textBoxPlantDescription.Location = new System.Drawing.Point(140, 61);
            this.textBoxPlantDescription.Name = "textBoxPlantDescription";
            this.textBoxPlantDescription.Size = new System.Drawing.Size(200, 26);
            this.textBoxPlantDescription.TabIndex = 10;
            this.textBoxPlantDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 149);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(74, 149);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(120, 50);
            this.btnMod.TabIndex = 20;
            this.btnMod.Text = "确定";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // textBoxPlantID
            // 
            this.textBoxPlantID.Location = new System.Drawing.Point(140, 29);
            this.textBoxPlantID.Name = "textBoxPlantID";
            this.textBoxPlantID.Size = new System.Drawing.Size(200, 26);
            this.textBoxPlantID.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "是否启用：";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(140, 93);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 24);
            this.radioButton1.TabIndex = 33;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "是";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(187, 93);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 24);
            this.radioButton2.TabIndex = 34;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "否";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // 库存账套信息
            // 
            this.ClientSize = new System.Drawing.Size(394, 211);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPlantID);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBoxPlantDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "库存账套信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "库存账套修改";
            this.Load += new System.EventHandler(this.库存账套信息_Load);
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

        private void 库存账套信息_Load(object sender, EventArgs e)
        {
            if (Text == "库存账套新增")
            {
                textBoxPlantID.ReadOnly = false;
            }
            else if (Text == "库存账套修改")
            {
                textBoxPlantID.ReadOnly = true;
            }
        }
    }
}
