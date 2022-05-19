﻿using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using RFSystem.AnSteel;
using RFSystem.CommonClass;

namespace RFSystem.LabelPrint
{
    public class 保管员货品 : Form
    {
        // Fields
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private IContainer components;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataSet m_Ds;
        private DataView m_Dv;
        private Thread thread;
        private TextBox txtBatch;
        private TextBox txtKeeper;
        private TextBox txtMaterial;
        private TextBox txtPlant;
        private TextBox txtSubPlant;

        // Methods
        public 保管员货品()
        {
            this.m_Ds = null;
            this.m_Dv = null;
            this.thread = null;
            this.components = null;
            this.InitializeComponent();
            base.Load += new EventHandler(this.保管员货品_Load);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtKeeper.Text.Trim() != "")
            {
                this.thread = new Thread(new ThreadStart(this.ShowWaitingMsg));
                this.thread.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(this.RowFilterShowWaitingMsg));
            this.thread.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeeper = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSubPlant = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlant = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "保管员：";
            // 
            // txtKeeper
            // 
            this.txtKeeper.Location = new System.Drawing.Point(77, 32);
            this.txtKeeper.Name = "txtKeeper";
            this.txtKeeper.Size = new System.Drawing.Size(117, 26);
            this.txtKeeper.TabIndex = 10;
            this.txtKeeper.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 108);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(956, 450);
            this.dataGridView1.TabIndex = 1000;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtKeeper);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 20;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtSubPlant);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPlant);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtBatch);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtMaterial);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(333, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 90);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "过滤信息";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(512, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 50;
            this.button2.Text = "过滤";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSubPlant
            // 
            this.txtSubPlant.Location = new System.Drawing.Point(77, 51);
            this.txtSubPlant.Name = "txtSubPlant";
            this.txtSubPlant.Size = new System.Drawing.Size(132, 26);
            this.txtSubPlant.TabIndex = 40;
            this.txtSubPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "二级厂：";
            // 
            // txtPlant
            // 
            this.txtPlant.Location = new System.Drawing.Point(286, 51);
            this.txtPlant.Name = "txtPlant";
            this.txtPlant.Size = new System.Drawing.Size(132, 26);
            this.txtPlant.TabIndex = 30;
            this.txtPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "工厂号：";
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(286, 19);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(132, 26);
            this.txtBatch.TabIndex = 20;
            this.txtBatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "批次号：";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(77, 19);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(132, 26);
            this.txtMaterial.TabIndex = 10;
            this.txtMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "物料号：";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(860, 564);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 40);
            this.button3.TabIndex = 510;
            this.button3.Text = "退出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(754, 564);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 40);
            this.button4.TabIndex = 500;
            this.button4.Text = "打印";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // 保管员货品
            // 
            this.ClientSize = new System.Drawing.Size(972, 616);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "保管员货品";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保管员货品";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void RowFilterShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if ((this.m_Ds != null) && (this.dataGridView1.DataSource != null))
                {
                    string str = "";
                    if (this.txtBatch.Text.Trim() != "")
                    {
                        str = str + "Charg='" + this.txtBatch.Text.Trim() + "' and ";
                    }

                    if (this.txtMaterial.Text.Trim() != "")
                    {
                        str = str + "Matnr='" + this.txtMaterial.Text.Trim() + "' and ";
                    }

                    if (this.txtPlant.Text.Trim() != "")
                    {
                        str = str + "Werks='" + this.txtPlant.Text.Trim() + "' and ";
                    }

                    if (this.txtSubPlant.Text.Trim() != "")
                    {
                        str = str + "Bct20='" + this.txtSubPlant.Text.Trim() + "' and ";
                    }

                    if (str != "")
                    {
                        str = str.Substring(0, str.Length - 4);
                    }

                    this.m_Dv.RowFilter = str;
                }
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void RowFilterShowWaitingMsg()
        {
            base.Invoke(new EventHandler(this.RowFilterShowMsg));
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.GetNextControl(base.ActiveControl, true).Focus();
            }
        }

        private void ShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    MessagePack bGYInfo = Utility.getSerive().GetBGYInfo(this.txtKeeper.Text.Trim(), out this.m_Ds);

                    if (bGYInfo.Code != 0)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(bGYInfo.Message);
                    }
                    else
                    {
                        this.m_Dv = new DataView(this.m_Ds.Tables["Detail"]);
                        this.dataGridView1.DataSource = this.m_Dv;
                        this.dataGridView1.Columns["Bct10"].HeaderText = "保管员";
                        this.dataGridView1.Columns["Bct20"].HeaderText = "二级厂";
                        this.dataGridView1.Columns["Maktx"].HeaderText = "物料描述";
                        this.dataGridView1.Columns["Matnr"].HeaderText = "物料号";
                        this.dataGridView1.Columns["Bct50"].HeaderText = "货位1";
                        this.dataGridView1.Columns["Bct51"].HeaderText = "货位1数量";
                        this.dataGridView1.Columns["Bct60"].HeaderText = "货位2";
                        this.dataGridView1.Columns["Bct61"].HeaderText = "货位2数量";
                        this.dataGridView1.Columns["Bct70"].HeaderText = "货位3";
                        this.dataGridView1.Columns["Bct71"].HeaderText = "货位3数量";
                        this.dataGridView1.Columns["Charg"].HeaderText = "批次";
                        this.dataGridView1.Columns["Lgort"].HeaderText = "库存地点";
                        this.dataGridView1.Columns["Meins"].HeaderText = "单位";
                        this.dataGridView1.Columns["Werks"].HeaderText = "工厂";
                        this.dataGridView1.Columns["Ebeln"].HeaderText = "订单号";
                        this.dataGridView1.Columns["Verpr"].HeaderText = "单价";
                        this.dataGridView1.Columns["Name1"].HeaderText = "供应商";
                        this.dataGridView1.Columns["Ntgew"].HeaderText = "单重";
                        this.dataGridView1.Columns["Clabs"].HeaderText = "库存数量";
                        Cursor.Current = Cursors.Default;
                    }
                }
                catch (Exception exception)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(exception.Message);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ShowWaitingMsg()
        {
            base.Invoke(new EventHandler(this.ShowMsg));
        }

        private void 保管员货品_Load(object sender, EventArgs e)
        {
            this.txtKeeper.Text = ConstDefine.g_User;
        }
    }
}
