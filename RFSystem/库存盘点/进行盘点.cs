using System;
using System.Windows.Forms;
using System.Threading;
using System.Data;

namespace RFSystem
{
    public class 进行盘点 : Form
    {
        // Fields
        private Button btnInventory;
        private Button btnList;
        private Button btnMakeInventory;
        private Button btnOver;
        private Button btnSubmit;
        private ProgressBar progressBar1;
        private bool SapDowning;
        private bool SapUping;
        private StatusStrip statusStrip1;
        public string STSerial;
        private string STType;
        private Thread thread;
        private System.Timers.Timer timer1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;

        private void InitializeComponent()
        {
            this.btnOver = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnMakeInventory = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Timers.Timer();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOver
            // 
            this.btnOver.Enabled = false;
            this.btnOver.Location = new System.Drawing.Point(104, 167);
            this.btnOver.Name = "btnOver";
            this.btnOver.Size = new System.Drawing.Size(100, 40);
            this.btnOver.TabIndex = 30;
            this.btnOver.Text = "结束盘点";
            this.btnOver.UseVisualStyleBackColor = true;
            this.btnOver.Click += new System.EventHandler(this.btnOver_Click);
            // 
            // btnList
            // 
            this.btnList.Enabled = false;
            this.btnList.Location = new System.Drawing.Point(104, 75);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(100, 40);
            this.btnList.TabIndex = 10;
            this.btnList.Text = "开始盘点";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Enabled = false;
            this.btnInventory.Location = new System.Drawing.Point(104, 121);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(100, 40);
            this.btnInventory.TabIndex = 20;
            this.btnInventory.Text = "停止盘点";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(294, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // btnMakeInventory
            // 
            this.btnMakeInventory.Enabled = false;
            this.btnMakeInventory.Location = new System.Drawing.Point(104, 29);
            this.btnMakeInventory.Name = "btnMakeInventory";
            this.btnMakeInventory.Size = new System.Drawing.Size(100, 40);
            this.btnMakeInventory.TabIndex = 0;
            this.btnMakeInventory.Text = "数据下载";
            this.btnMakeInventory.UseVisualStyleBackColor = true;
            this.btnMakeInventory.Click += new System.EventHandler(this.btnMakeInventory_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(104, 213);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 40);
            this.btnSubmit.TabIndex = 40;
            this.btnSubmit.Text = "数据提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 293);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(294, 25);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 20);
            this.toolStripStatusLabel1.Text = "盘点序号：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(105, 20);
            this.toolStripStatusLabel2.Text = "200805160001";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000D;
            this.timer1.SynchronizingObject = this;
            // 
            // 进行盘点
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.ClientSize = new System.Drawing.Size(294, 318);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnMakeInventory);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnOver);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "进行盘点";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "进行盘点";
            this.Load += new System.EventHandler(this.进行盘点_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 进行盘点(string STStatus, string STType)
        {
            STSerial = "";
            this.STType = "";
            SapDowning = false;
            SapUping = false;
            thread = null;
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(进行盘点_FormClosing);
            timer1.Enabled = true;
            ////this.timer1.Tick += new EventHandler(this.timer1_Tick);??????????????????????????????????
            this.STType = STType;
            string str = STStatus;

            if (str != null)
            {
                if (!(str == "0"))
                {
                    if (str == "1")
                    {
                        btnList.Enabled = true;
                    }
                    else if (str == "2")
                    {
                        btnInventory.Enabled = true;
                    }
                    else if (str == "3")
                    {
                        btnOver.Enabled = true;
                    }
                    else if (str == "4")
                    {
                        btnSubmit.Enabled = true;
                    }
                }
                else
                {
                    btnMakeInventory.Enabled = true;
                }
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            int num = DBOperate.STOrderChangeState(Convert.ToInt32(STSerial), 3);

            if (num == 0)
            {
                CommonFunction.Sys_MsgBox("该盘点单已被其他管理员改变，请退出并从新操作");
            }
            else if (num != -1)
            {
                btnInventory.Enabled = false;
                btnOver.Enabled = true;
            }
            else
            {
                CommonFunction.Sys_MsgBox("更新出错，请检查数据库");
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            int num = DBOperate.STOrderChangeState(Convert.ToInt32(STSerial), 2);

            if (num == 0)
            {
                CommonFunction.Sys_MsgBox("该盘点单已被其他管理员改变，请退出并从新操作");
            }
            else if (num != -1)
            {
                btnList.Enabled = false;
                btnInventory.Enabled = true;
            }
            else
            {
                CommonFunction.Sys_MsgBox("更新出错，请检查数据库");
            }
        }

        private void btnMakeInventory_Click(object sender, EventArgs e)
        {
            if (!SapDowning)
            {
                thread = new Thread(new ThreadStart(SAPSTDownLoad));
                thread.Start();
            }
            else
            {
                CommonFunction.Sys_MsgBox("现在正在处理库存下载中");
            }
        }

        private void btnOver_Click(object sender, EventArgs e)
        {
            DataTable dataList = DBOperate.CheckCompare(toolStripStatusLabel2.Text);

            if (CommonFunction.IfHasData(dataList))
            {
                string str = string.Empty + "存在超过四个储位存放的货物信息为：\r\n\r\n盘点单号|库存账套|逻辑库区|物料号|批次\r\n";

                foreach (DataRow row in dataList.Rows)
                {
                    string str2 = str;
                    str = str2 + row["STSerial"].ToString() + "|" + row["Plant"].ToString() + "|" + row["SLocation"].ToString() + "|" + row["Material"].ToString() + "|" + row["BNumber"].ToString() + "\r\n";
                }

                CommonFunction.Sys_MsgBox(str + "\r\n请调整其储位至少于等于三个");
            }
            else if (DBOperate.AddCompare(Convert.ToDecimal(toolStripStatusLabel2.Text)) != -1)
            {
                CommonFunction.Sys_MsgBox("盘点单 " + toolStripStatusLabel2.Text + " 盘点信息汇总完毕，请在盘点报表中进行查询修改");
                int num = DBOperate.STOrderChangeState(Convert.ToInt32(STSerial), 4);

                if (num == 0)
                {
                    CommonFunction.Sys_MsgBox("该盘点单已被其他管理员改变，请退出并从新操作");
                }
                else
                {
                    if (num != 1)
                    {
                        CommonFunction.Sys_MsgBox("更新出错，请检查数据库");
                    }

                    if (num != -1)
                    {
                        if (STType.Equals("1"))
                        {
                            btnOver.Enabled = false;
                            CommonFunction.Sys_MsgBox("本次日常盘点结束");
                            Close();
                        }
                        else
                        {
                            btnOver.Enabled = false;
                            btnSubmit.Enabled = true;
                        }
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("更新出错，请检查数据库");
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!SapUping)
            {
                thread = new Thread(new ThreadStart(SAPSTUpLoad));
                thread.Start();
            }
            else
            {
                CommonFunction.Sys_MsgBox("现在正在上传Sap盘点数据中");
            }
        }

        private void ReflashProcess(object o, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
            }
            else if (progressBar1.Value == 50)
            {
                progressBar1.Value = 100;
            }
            else if (progressBar1.Value == 0)
            {
                progressBar1.Value = 50;
            }
        }

        private void ReflashProcess100(object o, EventArgs e)
        {
            CommonFunction.Sys_MsgBox("成功下载Sap系统库存");
            progressBar1.Value = 100;
        }

        private void ReflashProcess101(object o, EventArgs e)
        {
            CommonFunction.Sys_MsgBox("成功上传Sap盘点数据");
            progressBar1.Value = 100;
            btnSubmit.Enabled = false;
        }

        private void SAPSTDownLoad()
        {
            SapDowning = true;

            try
            {
                
            }
            catch (Exception exception)
            {
                SapDowning = false;
                CommonFunction.Sys_MsgBox(exception.Message);
            }
            finally
            {
                SapDowning = false;
            }
        }

        private void SAPSTUpLoad()
        {
            SapUping = true;

            try
            {

            }
            catch (Exception exception)
            {
                SapUping = false;
                CommonFunction.Sys_MsgBox(exception.Message);
            }
            finally
            {
                SapUping = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SapDowning)
            {
                Invoke(new EventHandler(ReflashProcess));
            }

            if (SapUping)
            {
                Invoke(new EventHandler(ReflashProcess));
            }
        }

        private void 进行盘点_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SapDowning)
            {
                e.Cancel = true;
                CommonFunction.Sys_MsgBox("数据正在下载中不能关闭窗口");
            }
            else if (SapUping)
            {
                e.Cancel = true;
                CommonFunction.Sys_MsgBox("数据正在上传中不能关闭窗口");
            }
        }

        private void 进行盘点_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            toolStripStatusLabel2.Text = STSerial;
        }
    }
}

