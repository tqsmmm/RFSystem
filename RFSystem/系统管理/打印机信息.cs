using BL;
using RFSystem.CommonClass;
using System;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RFSystem.SystemConfig
{
    public class 打印机信息 : Form
    {
        private Button btnCancel;
        private Button btnMod;
        private Label label1;
        private Label label2;
        private Label label3;
        private Regex regex;
        private TextBox textBoxPrinterAddress;
        private TextBox textBoxPrinterName;
        private TextBox textBoxPrinterSocket;

        public 打印机信息(Hashtable printerItem)
        {
            InitializeComponent();
            regex = new Regex(@"^(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))$");
            textBoxPrinterName.Text = (string)printerItem["PrinterName"];
            textBoxPrinterAddress.Text = (string)printerItem["PrinterAddress"];
            textBoxPrinterSocket.Text = (string)printerItem["PrinterSocket"];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ArrayList printerItem = new ArrayList();
                printerItem.Add(textBoxPrinterName.Text.Trim());
                printerItem.Add(textBoxPrinterAddress.Text.Trim());
                printerItem.Add(textBoxPrinterSocket.Text.Trim());

                if (Text == "打印机新增")
                {
                    if (DBOperate.AddPrinter(printerItem) != -1)
                    {
                        CommonFunction.Sys_MsgBox("打印机 " + textBoxPrinterName.Text.Trim() + " 添加成功");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("打印机信息添加失败，请确认没有添加重复信息并且数据库联接正常");
                    }
                }
                else if (Text == "打印机修改")
                {
                    if (DBOperate.ModPrinter(printerItem) != -1)
                    {
                        CommonFunction.Sys_MsgBox("打印机 " + textBoxPrinterName.Text.Trim() + " 信息修改成功");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("数据库出错，请联系系统管理员确认");
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.textBoxPrinterSocket = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPrinterAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrinterName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(245, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(139, 209);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 30;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // textBoxPrinterSocket
            // 
            this.textBoxPrinterSocket.Location = new System.Drawing.Point(192, 114);
            this.textBoxPrinterSocket.Name = "textBoxPrinterSocket";
            this.textBoxPrinterSocket.Size = new System.Drawing.Size(200, 26);
            this.textBoxPrinterSocket.TabIndex = 20;
            this.textBoxPrinterSocket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "打印机端口：";
            // 
            // textBoxPrinterAddress
            // 
            this.textBoxPrinterAddress.Location = new System.Drawing.Point(192, 82);
            this.textBoxPrinterAddress.Name = "textBoxPrinterAddress";
            this.textBoxPrinterAddress.Size = new System.Drawing.Size(200, 26);
            this.textBoxPrinterAddress.TabIndex = 10;
            this.textBoxPrinterAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            this.textBoxPrinterAddress.Leave += new System.EventHandler(this.textBoxPrinterAddress_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "打印机地址：";
            // 
            // textBoxPrinterName
            // 
            this.textBoxPrinterName.Location = new System.Drawing.Point(192, 50);
            this.textBoxPrinterName.Name = "textBoxPrinterName";
            this.textBoxPrinterName.ReadOnly = true;
            this.textBoxPrinterName.Size = new System.Drawing.Size(200, 26);
            this.textBoxPrinterName.TabIndex = 10000;
            this.textBoxPrinterName.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印机名称：";
            // 
            // 修改打印机信息
            // 
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.textBoxPrinterSocket);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPrinterAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPrinterName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "修改打印机信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改打印机信息";
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

        private void textBoxPrinterAddress_Leave(object sender, EventArgs e)
        {
            if (!((TextBox)sender).Text.Equals(string.Empty) && !regex.IsMatch(textBoxPrinterAddress.Text))
            {
                CommonFunction.Sys_MsgBox("对不起，您所输入的不符合IP格式要求，请从新输入");
                ((TextBox)sender).Focus();
            }
        }

        private bool ValidateInput()
        {
            if (textBoxPrinterName.Text.Trim().Equals(string.Empty) || textBoxPrinterAddress.Text.Trim().Equals(string.Empty))
            {
                CommonFunction.Sys_MsgBox("请填写完整信息");
                return false;
            }

            return true;
        }
    }
}
