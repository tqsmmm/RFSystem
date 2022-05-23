using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RFSystem.CommonClass;
using BL;
using RFSystem.Properties;
using System.Net.Sockets;

namespace RFSystem.LabelPrint
{
    public class LocationLabel : Form
    {
        // Fields
        private Button btnAdd;
        private Button btnDel;
        private Button btnExit;
        private Button btnPrint;
        private Button btnSelect;
        private Button btnSelectPrinter;
        private DataGridViewTextBoxColumn columnLocation;
        private DataGridViewTextBoxColumn columnPAddress;
        private DataGridViewTextBoxColumn columnPName;
        private DataGridViewTextBoxColumn columnSocket;
        private DataGridView dataGridViewLocationList;
        private DataGridView dataGridViewPrinterList;
        private DataTable dtLocationList;
        private DataTable dtPrinterList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label5;
        private Label label8;
        private TextBox txtLocation;
        private TextBox txtPrinter;

        // Methods
        public LocationLabel()
        {
            this.dtLocationList = null;
            this.dtPrinterList = null;
            this.InitializeComponent();
            this.dtPrinterList = DBOperate.GetPrinterList("%", "%" + Settings.Default.DefaultPrinterIP.ToString() + "%");
            this.dataGridViewPrinterList.DataSource = this.dtPrinterList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LocationAdd add = new LocationAdd();
            if (add.ShowDialog() == DialogResult.OK)
            {
                this.btnSelect.PerformClick();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewLocationList.SelectedRows != null)
            {
                if (CommonFunction.IfHasData(this.dtLocationList))
                {
                    if ((MessageBox.Show("确认删除此条货位号么？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) && (PrintDBOperate.DelLocation((string)this.dataGridViewLocationList.SelectedRows[0].Cells["columnLocation"].Value) != -1))
                    {
                        MessageBox.Show("货位号删除成功");
                        this.btnSelect.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show("没有检索到任何货位信息，无法进行删除操作", "检索无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("请选择一条货位信息", "选择无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.PrintLocationLabel();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.dtLocationList = PrintDBOperate.GetLocationList(this.txtLocation.Text.Trim());
            this.dataGridViewLocationList.DataSource = this.dtLocationList;
        }

        private void btnSelectPrinter_Click(object sender, EventArgs e)
        {
            this.dtPrinterList = DBOperate.GetPrinterList("%" + this.txtPrinter.Text + "%", "%");
            this.dataGridViewPrinterList.DataSource = this.dtPrinterList;
        }

        private void dataGridViewLocationList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewLocationList_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewLocationList.Rows != null) && (this.dataGridViewLocationList.SelectedRows.Count != 0))
            {
                this.btnPrint.Enabled = true;
                this.btnDel.Enabled = true;
            }
            else
            {
                this.btnPrint.Enabled = false;
                this.btnDel.Enabled = false;
            }
        }

        private string dealPrintData(string loc, string xx, string xz, string copy)
        {
            string str = "";
            str = ((((str + "@CREATE;LOC\r\n" + "BARCODE\r\n") + "C128C;VSCAN;X1.5;H4.65;DARK;" + xx + ";1\r\n") + "*" + loc + "*\r\n") + "PDF;S\r\n" + "STOP\r\n") + "FONT;FACE 92250;BOLD OFF;SLANT OFF;SYMSET 0\r\n" + "ALPHA\r\n";
            return ((((str + "CCW;POINT;" + xz + ";7;15;15;'" + loc + "'\r\n") + "STOP\r\n" + "END\r\n") + "@EXECUTE;LOC;" + copy + "\r\n") + "@NORMAL\r\n");
        }

        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewLocationList = new System.Windows.Forms.DataGridView();
            this.columnLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectPrinter = new System.Windows.Forms.Button();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.columnPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocationList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.txtLocation);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dataGridViewLocationList);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 509);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "货位选择";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(645, 527);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 50;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(433, 527);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(539, 527);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 40);
            this.btnDel.TabIndex = 60;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(751, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 70;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(221, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 20;
            this.btnSelect.Text = "查找";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(77, 32);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(138, 26);
            this.txtLocation.TabIndex = 10;
            this.txtLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "货位号：";
            // 
            // dataGridViewLocationList
            // 
            this.dataGridViewLocationList.AllowUserToAddRows = false;
            this.dataGridViewLocationList.AllowUserToResizeRows = false;
            this.dataGridViewLocationList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewLocationList.ColumnHeadersHeight = 30;
            this.dataGridViewLocationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewLocationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnLocation});
            this.dataGridViewLocationList.Location = new System.Drawing.Point(9, 71);
            this.dataGridViewLocationList.MultiSelect = false;
            this.dataGridViewLocationList.Name = "dataGridViewLocationList";
            this.dataGridViewLocationList.ReadOnly = true;
            this.dataGridViewLocationList.RowHeadersVisible = false;
            this.dataGridViewLocationList.RowTemplate.Height = 23;
            this.dataGridViewLocationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLocationList.Size = new System.Drawing.Size(312, 432);
            this.dataGridViewLocationList.TabIndex = 30;
            this.dataGridViewLocationList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLocationList_CellContentClick);
            this.dataGridViewLocationList.SelectionChanged += new System.EventHandler(this.dataGridViewLocationList_SelectionChanged);
            // 
            // columnLocation
            // 
            this.columnLocation.DataPropertyName = "LocNo";
            this.columnLocation.HeaderText = "货位号";
            this.columnLocation.Name = "columnLocation";
            this.columnLocation.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSelectPrinter);
            this.groupBox1.Controls.Add(this.txtPrinter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dataGridViewPrinterList);
            this.groupBox1.Location = new System.Drawing.Point(345, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 509);
            this.groupBox1.TabIndex = 200;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印机选择";
            // 
            // btnSelectPrinter
            // 
            this.btnSelectPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPrinter.Location = new System.Drawing.Point(400, 25);
            this.btnSelectPrinter.Name = "btnSelectPrinter";
            this.btnSelectPrinter.Size = new System.Drawing.Size(100, 40);
            this.btnSelectPrinter.TabIndex = 215;
            this.btnSelectPrinter.Text = "查找";
            this.btnSelectPrinter.UseVisualStyleBackColor = true;
            this.btnSelectPrinter.Click += new System.EventHandler(this.btnSelectPrinter_Click);
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(77, 32);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(151, 26);
            this.txtPrinter.TabIndex = 216;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 214;
            this.label5.Text = "打印机：";
            // 
            // dataGridViewPrinterList
            // 
            this.dataGridViewPrinterList.AllowUserToAddRows = false;
            this.dataGridViewPrinterList.AllowUserToResizeRows = false;
            this.dataGridViewPrinterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPrinterList.ColumnHeadersHeight = 30;
            this.dataGridViewPrinterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPrinterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPName,
            this.columnPAddress,
            this.columnSocket});
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(10, 71);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(490, 432);
            this.dataGridViewPrinterList.TabIndex = 210;
            // 
            // columnPName
            // 
            this.columnPName.DataPropertyName = "PrinterName";
            this.columnPName.HeaderText = "打印机";
            this.columnPName.Name = "columnPName";
            this.columnPName.ReadOnly = true;
            // 
            // columnPAddress
            // 
            this.columnPAddress.DataPropertyName = "PrinterAddress";
            this.columnPAddress.HeaderText = "IP地址";
            this.columnPAddress.Name = "columnPAddress";
            this.columnPAddress.ReadOnly = true;
            // 
            // columnSocket
            // 
            this.columnSocket.DataPropertyName = "PrinterSocket";
            this.columnSocket.HeaderText = "端口号";
            this.columnSocket.Name = "columnSocket";
            this.columnSocket.ReadOnly = true;
            // 
            // LocationLabel
            // 
            this.ClientSize = new System.Drawing.Size(863, 579);
            this.ControlBox = false;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LocationLabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "货位标签打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocationList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            this.ResumeLayout(false);

        }

        private void PrintLocationLabel()
        {
            string s = "";
            string loc = "";
            string copy = "1";
            string xx = "2";
            string xz = "12";
            TcpClient client = new TcpClient();
            string hostname = this.dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            int port = int.Parse(this.dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

            try
            {
                client.Connect(hostname, port);

                for (int i = 0; i < this.dataGridViewLocationList.RowCount; i++)
                {
                    loc = this.dataGridViewLocationList.Rows[i].Cells["columnLocation"].Value.ToString();
                    xx = "5.5";
                    xz = "13";
                    s = this.dealPrintData(loc, xx, xz, copy);
                    client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                    client.GetStream().Flush();
                }

                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.GetNextControl(base.ActiveControl, true).Focus();
            }
        }
    }
}
