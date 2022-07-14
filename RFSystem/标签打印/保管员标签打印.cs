using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace RFSystem
{
    public partial class 保管员标签打印 : Form
    {
        private Button btnPrint;
        private DataGridView dataGridViewContractorList;
        private DataGridView dataGridViewPrinterList;
        private DataTable dtContractorList;
        private DataTable dtPrinterList;
        private DataGridViewTextBoxColumn postid;
        private DataGridViewTextBoxColumn userid;
        private DataGridViewTextBoxColumn userName;
        private DataGridViewTextBoxColumn columnPName;
        private DataGridViewTextBoxColumn columnPAddress;
        private DataGridViewTextBoxColumn columnSocket;
        private NumericUpDown nudCopy;
        private Label label10;
        private TextBox txtPrinter;
        private Label label11;
        private Button btnPatchPrint;

        // Methods
        public 保管员标签打印()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string copy = nudCopy.Value.ToString();
            TcpClient client = new TcpClient();
            string hostname = dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            int port = int.Parse(dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

            try
            {
                for (int i = 0; i < dataGridViewContractorList.SelectedRows.Count; i++)
                {
                    client.Connect(hostname, port);

                    string con = dataGridViewContractorList.SelectedRows[i].Cells["userid"].Value.ToString();
                    string xx = "4";
                    string xz = "10";
                    string s = dealPrintData(con, xx, xz, copy);
                    client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                    client.GetStream().Flush();

                    client.Close();
                }
            }
            catch (Exception exception)
            {
                CommonFunction.Sys_MsgBox(exception.Message);
            }
        }

        private string dealPrintData(string con, string xx, string xz, string copy)
        {
            string str = "";
            str = str + "@CREATE;LOC\r\n" + "BARCODE\r\n" + "C128C;VSCAN;X2;H4.65;DARK;" + xx + ";1\r\n" + "*" + con + "*\r\n" + "PDF;S\r\n" + "STOP\r\n" + "FONT;FACE 92250;BOLD OFF;SLANT OFF;SYMSET 0\r\n" + "ALPHA\r\n";
            return str + "CCW;POINT;" + xz + ";7;15;15;'" + con + "'\r\n" + "STOP\r\n" + "END\r\n" + "@EXECUTE;LOC;" + copy + "\r\n" + "@NORMAL\r\n";
        }

        private void InitializeComponent()
        {
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataGridViewContractorList = new System.Windows.Forms.DataGridView();
            this.postid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.columnPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPatchPrint = new System.Windows.Forms.Button();
            this.nudCopy = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContractorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(12, 302);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPrint.TabIndex = 50;
            this.btnPrint.Text = "单个打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dataGridViewContractorList
            // 
            this.dataGridViewContractorList.AllowUserToAddRows = false;
            this.dataGridViewContractorList.AllowUserToResizeRows = false;
            this.dataGridViewContractorList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewContractorList.ColumnHeadersHeight = 30;
            this.dataGridViewContractorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewContractorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.postid,
            this.userid,
            this.userName});
            this.dataGridViewContractorList.Location = new System.Drawing.Point(138, 12);
            this.dataGridViewContractorList.MultiSelect = false;
            this.dataGridViewContractorList.Name = "dataGridViewContractorList";
            this.dataGridViewContractorList.ReadOnly = true;
            this.dataGridViewContractorList.RowHeadersVisible = false;
            this.dataGridViewContractorList.RowTemplate.Height = 23;
            this.dataGridViewContractorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContractorList.Size = new System.Drawing.Size(907, 591);
            this.dataGridViewContractorList.TabIndex = 30;
            this.dataGridViewContractorList.SelectionChanged += new System.EventHandler(this.dataGridViewContractorList_SelectionChanged);
            // 
            // postid
            // 
            this.postid.DataPropertyName = "postid";
            this.postid.HeaderText = "保管员岗位号";
            this.postid.Name = "postid";
            this.postid.ReadOnly = true;
            // 
            // userid
            // 
            this.userid.DataPropertyName = "userid";
            this.userid.HeaderText = "用户工号";
            this.userid.Name = "userid";
            this.userid.ReadOnly = true;
            // 
            // userName
            // 
            this.userName.DataPropertyName = "userName";
            this.userName.HeaderText = "保管员名称";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            // 
            // dataGridViewPrinterList
            // 
            this.dataGridViewPrinterList.AllowUserToAddRows = false;
            this.dataGridViewPrinterList.AllowUserToResizeRows = false;
            this.dataGridViewPrinterList.ColumnHeadersHeight = 30;
            this.dataGridViewPrinterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPrinterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPName,
            this.columnPAddress,
            this.columnSocket});
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(120, 180);
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
            this.columnPAddress.Visible = false;
            // 
            // columnSocket
            // 
            this.columnSocket.DataPropertyName = "PrinterSocket";
            this.columnSocket.HeaderText = "端口号";
            this.columnSocket.Name = "columnSocket";
            this.columnSocket.ReadOnly = true;
            this.columnSocket.Visible = false;
            // 
            // btnPatchPrint
            // 
            this.btnPatchPrint.Enabled = false;
            this.btnPatchPrint.Location = new System.Drawing.Point(12, 358);
            this.btnPatchPrint.Name = "btnPatchPrint";
            this.btnPatchPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPatchPrint.TabIndex = 211;
            this.btnPatchPrint.Text = "批量打印";
            this.btnPatchPrint.UseVisualStyleBackColor = true;
            this.btnPatchPrint.Click += new System.EventHandler(this.btnPatchPrint_Click);
            // 
            // nudCopy
            // 
            this.nudCopy.Location = new System.Drawing.Point(12, 270);
            this.nudCopy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopy.Name = "nudCopy";
            this.nudCopy.Size = new System.Drawing.Size(120, 26);
            this.nudCopy.TabIndex = 1010;
            this.nudCopy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1009;
            this.label10.Text = "打印份数：";
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(12, 218);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(120, 26);
            this.txtPrinter.TabIndex = 1008;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 1007;
            this.label11.Text = "打印机：";
            // 
            // 保管员标签打印
            // 
            this.ClientSize = new System.Drawing.Size(1057, 615);
            this.ControlBox = false;
            this.Controls.Add(this.nudCopy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPrinter);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPatchPrint);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dataGridViewContractorList);
            this.Controls.Add(this.dataGridViewPrinterList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "保管员标签打印";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保管员标签打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ContractorLabel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContractorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridViewContractorList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewContractorList.Rows != null) && (dataGridViewContractorList.SelectedRows.Count != 0))
            {
                btnPrint.Enabled = true;
            }
            else
            {
                btnPrint.Enabled = false;
            }
        }

        private void ContractorLabel_Load(object sender, EventArgs e)
        {
            dtContractorList = DBOperate.GetContractorList("");
            dataGridViewContractorList.DataSource = dtContractorList;

            dtPrinterList = DBOperate.GetPrinterList(txtPrinter.Text, "%");
            dataGridViewPrinterList.DataSource = dtPrinterList;
        }

        private void btnPatchPrint_Click(object sender, EventArgs e)
        {
            string copy = nudCopy.Value.ToString();

            TcpClient client = new TcpClient();
            string hostname = dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            int port = int.Parse(dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());

            try
            {
                client.Connect(hostname, port);

                for (int i = 0; i < dataGridViewContractorList.RowCount; i++)
                {
                    string con = dataGridViewContractorList.Rows[i].Cells["userid"].Value.ToString();
                    string xx = "4";
                    string xz = "10";
                    string s = dealPrintData(con, xx, xz, copy);
                    client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                    client.GetStream().Flush();
                }

                client.Close();
            }
            catch (Exception exception)
            {
                CommonFunction.Sys_MsgBox(exception.Message);
            }
        }
    }
}
