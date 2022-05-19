using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BL;
using RFSystem.Properties;
using System.Net.Sockets;

namespace RFSystem.LabelPrint
{
    public partial class ContractorLabel : Form
    {
        // Fields
        private Button btnExit;
        private Button btnPrint;
        private Button btnSelect;
        private Button btnSelectPrinter;
        private DataGridViewTextBoxColumn columnContractor;
        private DataGridViewTextBoxColumn columnPAddress;
        private DataGridViewTextBoxColumn columnPName;
        private DataGridViewTextBoxColumn columnSocket;
        private IContainer components;
        private DataGridView dataGridViewContractorList;
        private DataGridView dataGridViewPrinterList;
        private DataTable dtContractorList;
        private DataTable dtPrinterList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label5;
        private Label label8;
        private TextBox txtContractor;
        private TextBox txtPrinter;

        // Methods
        public ContractorLabel()
        {
            this.dtContractorList = null;
            this.dtPrinterList = null;
            this.components = null;
            this.InitializeComponent();
            this.dtPrinterList = DBOperate.GetPrinterList("%", "%" + Settings.Default.DefaultPrinterIP.ToString() + "%");
            this.dataGridViewPrinterList.DataSource = this.dtPrinterList;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.PrintContractorLabel();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.dtContractorList = PrintDBOperate.GetContractorList(this.txtContractor.Text.Trim());
            this.dataGridViewContractorList.DataSource = this.dtContractorList;
        }

        private void btnSelectPrinter_Click(object sender, EventArgs e)
        {
            this.dtPrinterList = DBOperate.GetPrinterList("%" + this.txtPrinter.Text + "%", "%");
            this.dataGridViewPrinterList.DataSource = this.dtPrinterList;
        }

        private void dataGridViewContractorList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string dealPrintData(string con, string xx, string xz, string copy)
        {
            string str = "";
            str = ((((str + "@CREATE;LOC\r\n" + "BARCODE\r\n") + "C128C;VSCAN;X2;H4.65;DARK;" + xx + ";1\r\n") + "*" + con + "*\r\n") + "PDF;S\r\n" + "STOP\r\n") + "FONT;FACE 92250;BOLD OFF;SLANT OFF;SYMSET 0\r\n" + "ALPHA\r\n";
            return ((((str + "CCW;POINT;" + xz + ";7;15;15;'" + con + "'\r\n") + "STOP\r\n" + "END\r\n") + "@EXECUTE;LOC;" + copy + "\r\n") + "@NORMAL\r\n");
        }

        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtContractor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewContractorList = new System.Windows.Forms.DataGridView();
            this.columnContractor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectPrinter = new System.Windows.Forms.Button();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.columnPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContractorList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.txtContractor);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 75);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保管员选择";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(689, 497);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 50;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(795, 497);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 70;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(261, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 20;
            this.btnSelect.Text = "查找";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtContractor
            // 
            this.txtContractor.Location = new System.Drawing.Point(77, 32);
            this.txtContractor.Name = "txtContractor";
            this.txtContractor.Size = new System.Drawing.Size(150, 26);
            this.txtContractor.TabIndex = 10;
            this.txtContractor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "保管员：";
            // 
            // dataGridViewContractorList
            // 
            this.dataGridViewContractorList.AllowUserToAddRows = false;
            this.dataGridViewContractorList.AllowUserToResizeRows = false;
            this.dataGridViewContractorList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewContractorList.ColumnHeadersHeight = 30;
            this.dataGridViewContractorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewContractorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnContractor});
            this.dataGridViewContractorList.Location = new System.Drawing.Point(12, 93);
            this.dataGridViewContractorList.MultiSelect = false;
            this.dataGridViewContractorList.Name = "dataGridViewContractorList";
            this.dataGridViewContractorList.ReadOnly = true;
            this.dataGridViewContractorList.RowHeadersVisible = false;
            this.dataGridViewContractorList.RowTemplate.Height = 23;
            this.dataGridViewContractorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContractorList.Size = new System.Drawing.Size(367, 444);
            this.dataGridViewContractorList.TabIndex = 30;
            this.dataGridViewContractorList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContractorList_CellContentClick);
            this.dataGridViewContractorList.SelectionChanged += new System.EventHandler(this.dataGridViewContractorList_SelectionChanged);
            // 
            // columnContractor
            // 
            this.columnContractor.DataPropertyName = "User_ID";
            this.columnContractor.HeaderText = "保管员";
            this.columnContractor.Name = "columnContractor";
            this.columnContractor.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSelectPrinter);
            this.groupBox1.Controls.Add(this.txtPrinter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(385, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 75);
            this.groupBox1.TabIndex = 200;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印机选择";
            // 
            // btnSelectPrinter
            // 
            this.btnSelectPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPrinter.Location = new System.Drawing.Point(404, 25);
            this.btnSelectPrinter.Name = "btnSelectPrinter";
            this.btnSelectPrinter.Size = new System.Drawing.Size(100, 40);
            this.btnSelectPrinter.TabIndex = 212;
            this.btnSelectPrinter.Text = "查找";
            this.btnSelectPrinter.UseVisualStyleBackColor = true;
            this.btnSelectPrinter.Click += new System.EventHandler(this.btnSelectPrinter_Click);
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(77, 32);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(151, 26);
            this.txtPrinter.TabIndex = 213;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 211;
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
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(385, 93);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(510, 398);
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
            // ContractorLabel
            // 
            this.ClientSize = new System.Drawing.Size(907, 549);
            this.ControlBox = false;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridViewContractorList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewPrinterList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContractorLabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保管员标签打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ContractorLabel_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContractorList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            this.ResumeLayout(false);

        }

        private void PrintContractorLabel()
        {
            string s = "";
            string con = "";
            string copy = "1";
            string xx = "4";
            string xz = "10";

            TcpClient client = new TcpClient();
            string hostname = this.dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            int port = int.Parse(this.dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

            try
            {
                client.Connect(hostname, port);

                for (int i = 0; i < this.dataGridViewContractorList.RowCount; i++)
                {
                    con = this.dataGridViewContractorList.Rows[i].Cells["columnContractor"].Value.ToString();
                    xx = "4";
                    xz = "10";
                    s = this.dealPrintData(con, xx, xz, copy);
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

        private void dataGridViewContractorList_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewContractorList.Rows != null) && (this.dataGridViewContractorList.SelectedRows.Count != 0))
            {
                this.btnPrint.Enabled = true;
            }
            else
            {
                this.btnPrint.Enabled = false;
            }
        }

        private void ContractorLabel_Load(object sender, EventArgs e)
        {

        }
    }
}
