using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RFSystem
{
    public class 日志信息查看 : Form
    {
        private RichTextBox richTextBox1;
        public string val = "";

        public 日志信息查看()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(792, 473);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // 日志信息查看
            // 
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "日志信息查看";
            this.Text = "日志信息查看";
            this.Load += new System.EventHandler(this.日志信息查看_Load);
            this.ResumeLayout(false);

        }

        private void 日志信息查看_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = val;
        }
    }
}
