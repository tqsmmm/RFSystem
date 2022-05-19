using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RFSystem.AnSteel;
using RFSystem.CommonClass;
using System.Net;

namespace RFSystem
{
    public class 日志管理 : Form
    {
        // Fields
        private Button btDel;
        private Button btSee;
        private IContainer components;
        private DataGridView dataGridView1;
        private DataSet m_poDs;

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btSee = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(568, 320);
            this.dataGridView1.TabIndex = 0;
            // 
            // btSee
            // 
            this.btSee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSee.Location = new System.Drawing.Point(374, 338);
            this.btSee.Name = "btSee";
            this.btSee.Size = new System.Drawing.Size(100, 40);
            this.btSee.TabIndex = 1;
            this.btSee.Text = "查看";
            this.btSee.UseVisualStyleBackColor = true;
            this.btSee.Click += new System.EventHandler(this.btSee_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Location = new System.Drawing.Point(480, 338);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(100, 40);
            this.btDel.TabIndex = 2;
            this.btDel.Text = "删除";
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // 日志管理
            // 
            this.ClientSize = new System.Drawing.Size(592, 390);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btSee);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "日志管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 日志管理()
        {
            components = null;
            m_poDs = null;
            InitializeComponent();
            Load += new EventHandler(日志管理_Load);
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dataGridView1.SelectedRows.Count > 0) && (DialogResult.No != MessageBox.Show("你确认要删除该文件么？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)))
                {
                    string fileName = dataGridView1.SelectedRows[0].Cells["fileName"].Value.ToString();
                    MessagePack pack = Utility.getSerive().DelLog(fileName);

                    if (pack.Code != 0)
                    {
                        MessageBox.Show(pack.Message);
                    }
                    else
                    {
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                        MessageBox.Show("删除成功");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btSee_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    WebClient client = new WebClient();
                    string address = ConstDefine.g_ConnStr;
                    address = address.Substring(0, address.LastIndexOf('/') + 1) + "Log/" + dataGridView1.SelectedRows[0].Cells["fileName"].Value.ToString();
                    byte[] bytes = client.DownloadData(address);
                    string str2 = Encoding.GetEncoding("gb2312").GetString(bytes);
                    new 日志信息查看 { val = str2 }.ShowDialog();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void 日志管理_Load(object sender, EventArgs e)
        {
            try
            {
                MessagePack pack = Utility.getSerive().SeeLog(out m_poDs);

                if (pack.Code != 0)
                {
                    MessageBox.Show(pack.Message);
                }
                else
                {
                    dataGridView1.DataSource = m_poDs.Tables[0];
                    dataGridView1.Columns["Time"].HeaderText = "日志时间";
                    dataGridView1.Columns["fileName"].HeaderText = "日志文件名";
                    dataGridView1.Columns["fileName"].Width = 180;
                    dataGridView1.Columns["Time"].Width = 150;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
