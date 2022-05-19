using BL;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public class 库存地点信息 : Form
    {
        private Button btnCancel;
        private Button btnMod;
        private ComboBox comboBoxPlantID;
        private IContainer components = null;
        private DataTable dtPlant = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxStoreLocusID;
        private TextBox textBoxStoreLocusDescription;

        public 库存地点信息(Hashtable storeItem)
        {
            InitializeComponent();
            dtPlant = DBOperate.GetPlant();

            foreach (DataRow row in dtPlant.Rows)
            {
                comboBoxPlantID.Items.Add(row["PlantID"]);
            }

            textBoxStoreLocusID.Text = (string)storeItem["StoreLocusID"];
            comboBoxPlantID.Text = (string)storeItem["PlantID"];
            textBoxStoreLocusDescription.Text = (string)storeItem["StoreLocusDescription"];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (Text == "库存新增")
                {
                    if (DBOperate.AddStoreLocus(textBoxStoreLocusID.Text.Trim(), comboBoxPlantID.Text.Trim(), textBoxStoreLocusDescription.Text.Trim()) != -1)
                    {
                        MessageBox.Show("库存地点 " + textBoxStoreLocusID.Text.Trim() + " 添加成功");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("库存地点信息添加失败，请确认没有添加重复库存地点编号并且数据库联接正常");
                    }
                }
                else if (Text == "库存修改")
                {
                    if (DBOperate.ModStoreLocus(textBoxStoreLocusID.Text, comboBoxPlantID.Text.Trim(), textBoxStoreLocusDescription.Text.Trim()) != -1)
                    {
                        MessageBox.Show("库存地点 " + textBoxStoreLocusID.Text + " 信息修改成功");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("数据库出错，请联系系统管理员确认");
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBoxStoreLocusDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPlantID = new System.Windows.Forms.ComboBox();
            this.textBoxStoreLocusID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "所属公司编号：";
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(139, 209);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 40;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(245, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBoxStoreLocusDescription
            // 
            this.textBoxStoreLocusDescription.Location = new System.Drawing.Point(145, 121);
            this.textBoxStoreLocusDescription.Name = "textBoxStoreLocusDescription";
            this.textBoxStoreLocusDescription.Size = new System.Drawing.Size(308, 26);
            this.textBoxStoreLocusDescription.TabIndex = 30;
            this.textBoxStoreLocusDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "库存地点描述：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "库存地点编号：";
            // 
            // comboBoxPlantID
            // 
            this.comboBoxPlantID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlantID.FormattingEnabled = true;
            this.comboBoxPlantID.Location = new System.Drawing.Point(145, 87);
            this.comboBoxPlantID.Name = "comboBoxPlantID";
            this.comboBoxPlantID.Size = new System.Drawing.Size(308, 28);
            this.comboBoxPlantID.TabIndex = 20;
            this.comboBoxPlantID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxStoreLocusID
            // 
            this.textBoxStoreLocusID.Location = new System.Drawing.Point(145, 55);
            this.textBoxStoreLocusID.Name = "textBoxStoreLocusID";
            this.textBoxStoreLocusID.Size = new System.Drawing.Size(308, 26);
            this.textBoxStoreLocusID.TabIndex = 51;
            // 
            // 库存地点信息
            // 
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxStoreLocusID);
            this.Controls.Add(this.comboBoxPlantID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBoxStoreLocusDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "库存地点信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "库存地点修改";
            this.Load += new System.EventHandler(this.库存地点修改_Load);
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

        private bool ValidateInput()
        {
            if ((textBoxStoreLocusID.Text.Trim().Equals(string.Empty) || comboBoxPlantID.Text.Trim().Equals(string.Empty)) || textBoxStoreLocusDescription.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请填写完整信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void 库存地点修改_Load(object sender, EventArgs e)
        {
            if (Text == "库存新增")
            {
                textBoxStoreLocusID.ReadOnly = false;

                dtPlant = DBOperate.GetPlant();

                foreach (DataRow row in dtPlant.Rows)
                {
                    comboBoxPlantID.Items.Add(row["PlantID"]);
                }
            }
            else if (Text == "库存修改")
            {
                textBoxStoreLocusID.ReadOnly = true;
            }
        }
    }
}
