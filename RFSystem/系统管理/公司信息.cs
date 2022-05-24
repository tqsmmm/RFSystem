using BL;
using RFSystem.CommonClass;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RFSystem
{
    public class 公司信息 : Form
    {
        private Button btnCancel;
        private Button btnMod;
        private Label label1;
        private Label label2;
        private TextBox textBoxPlantID;
        private TextBox textBoxPlantDescription;

        public 公司信息(Hashtable plantItem)
        {
            InitializeComponent();
            textBoxPlantID.Text = (string)plantItem["PlantID"];
            textBoxPlantDescription.Text = (string)plantItem["PlantDescription"];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (Text == "公司新增")
                {
                    if (DBOperate.AddPlant(textBoxPlantID.Text.Trim(), textBoxPlantDescription.Text.Trim()) != -1)
                    {
                        CommonFunction.Sys_MsgBox("公司 " + textBoxPlantID.Text.Trim() + " 添加成功");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("公司信息添加失败，请确认没有添加重复公司编号并且数据库联接正常");
                    }
                }
                else if (Text == "公司修改")
                {
                    if (DBOperate.ModPlant(textBoxPlantID.Text, textBoxPlantDescription.Text.Trim()) != -1)
                    {
                        CommonFunction.Sys_MsgBox("公司 " + textBoxPlantID.Text + " 信息修改成功");
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "公司编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "公司描述：";
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
            this.btnCancel.Location = new System.Drawing.Point(200, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(94, 123);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
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
            // 公司信息
            // 
            this.ClientSize = new System.Drawing.Size(394, 175);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxPlantID);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBoxPlantDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "公司信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "公司修改";
            this.Load += new System.EventHandler(this.公司信息_Load);
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

        private void 公司信息_Load(object sender, EventArgs e)
        {
            if (Text == "公司新增")
            {
                textBoxPlantID.ReadOnly = false;
            }
            else if (Text == "公司修改")
            {
                textBoxPlantID.ReadOnly = true;
            }
        }
    }
}
