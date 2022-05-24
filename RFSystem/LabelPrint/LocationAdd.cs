using BL;
using RFSystem.CommonClass;
using System;
using System.Collections;
using System.Windows.Forms;

namespace RFSystem.LabelPrint
{
    public class LocationAdd : Form
    {
        private Button btnAdd;
        private Button btnCancel;
        private Label label1;
        private TextBox txtLocation;

        public LocationAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ArrayList locItem = new ArrayList();
                locItem.Add(txtLocation.Text.Trim());

                if (PrintDBOperate.AddLocation(locItem) != -1)
                {
                    CommonFunction.Sys_MsgBox("货位号" + txtLocation.Text.Trim() + " 添加成功");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    CommonFunction.Sys_MsgBox("货位号添加失败，请确认没有添加重复货位号并且数据库联接正常");
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
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(89, 109);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(128, 44);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(200, 26);
            this.txtLocation.TabIndex = 10;
            this.txtLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "货位号：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(195, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LocationAdd
            // 
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.ControlBox = false;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LocationAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "货位添加";
            this.Load += new System.EventHandler(this.LocationAdd_Load);
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
            if (txtLocation.Text.Trim().Equals(string.Empty))
            {
                CommonFunction.Sys_MsgBox("请填写货位号");
                return false;
            }

            return true;
        }

        private void LocationAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
