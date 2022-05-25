using System;
using System.Data;
using System.Windows.Forms;
using RFSystem.CommonClass;
using System.Collections;

namespace RFSystem.SystemConfig
{
    public class 打印机信息列表 : Form
    {
        // Fields
        private Button btnAdd;
        private Button btnDel;
        private Button btnMod;
        private Button btnSelect;
        private DataGridViewTextBoxColumn columnPrinterAddress;
        private DataGridViewTextBoxColumn columnPrinterName;
        private DataGridViewTextBoxColumn columnPrinterSocket;
        private DataGridView dataGridViewPrinterList;
        private DataTable dtPrinterList;
        private Label label8;
        private Label label9;
        private TextBox textBoxPrinterAddress;
        private TextBox textBoxPrinterName;

        private void InitializeComponent()
        {
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxPrinterAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPrinterName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.columnPrinterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPrinterAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPrinterSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 284);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 50);
            this.btnSelect.TabIndex = 30;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxPrinterAddress
            // 
            this.textBoxPrinterAddress.Location = new System.Drawing.Point(12, 252);
            this.textBoxPrinterAddress.Name = "textBoxPrinterAddress";
            this.textBoxPrinterAddress.Size = new System.Drawing.Size(120, 26);
            this.textBoxPrinterAddress.TabIndex = 20;
            this.textBoxPrinterAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "打印机地址：";
            // 
            // textBoxPrinterName
            // 
            this.textBoxPrinterName.Location = new System.Drawing.Point(12, 200);
            this.textBoxPrinterName.Name = "textBoxPrinterName";
            this.textBoxPrinterName.Size = new System.Drawing.Size(120, 26);
            this.textBoxPrinterName.TabIndex = 10;
            this.textBoxPrinterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "打印机名称：";
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
            this.columnPrinterName,
            this.columnPrinterAddress,
            this.columnPrinterSocket});
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(138, 12);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(699, 464);
            this.dataGridViewPrinterList.TabIndex = 40;
            this.dataGridViewPrinterList.SelectionChanged += new System.EventHandler(this.dataGridViewPrinterList_SelectionChanged);
            // 
            // columnPrinterName
            // 
            this.columnPrinterName.DataPropertyName = "PrinterName";
            this.columnPrinterName.HeaderText = "打印机名称";
            this.columnPrinterName.Name = "columnPrinterName";
            this.columnPrinterName.ReadOnly = true;
            this.columnPrinterName.Width = 150;
            // 
            // columnPrinterAddress
            // 
            this.columnPrinterAddress.DataPropertyName = "PrinterAddress";
            this.columnPrinterAddress.HeaderText = "打印机地址";
            this.columnPrinterAddress.Name = "columnPrinterAddress";
            this.columnPrinterAddress.ReadOnly = true;
            this.columnPrinterAddress.Width = 150;
            // 
            // columnPrinterSocket
            // 
            this.columnPrinterSocket.DataPropertyName = "PrinterSocket";
            this.columnPrinterSocket.HeaderText = "打印机端口";
            this.columnPrinterSocket.Name = "columnPrinterSocket";
            this.columnPrinterSocket.ReadOnly = true;
            this.columnPrinterSocket.Width = 150;
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(12, 124);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(120, 50);
            this.btnDel.TabIndex = 50;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(12, 68);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(120, 50);
            this.btnMod.TabIndex = 50;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 50);
            this.btnAdd.TabIndex = 50;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // 打印机列表
            // 
            this.ClientSize = new System.Drawing.Size(849, 488);
            this.ControlBox = false;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxPrinterAddress);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.textBoxPrinterName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridViewPrinterList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "打印机列表";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印机信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 打印机信息列表()
        {
            dtPrinterList = null;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            打印机信息 frm = new 打印机信息(null);
            frm.Text = "打印机新增";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnSelect.PerformClick();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtPrinterList))
            {
                if (dataGridViewPrinterList.SelectedRows != null)
                {
                    if (CommonFunction.Sys_MsgYN("确认删除此条打印机信息么？") && (DBOperate.DelPrinter((string)dataGridViewPrinterList.SelectedRows[0].Cells["columnPrinterName"].Value) != -1))
                    {
                        CommonFunction.Sys_MsgBox("打印机信息删除成功");
                        btnSelect.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("请选择一条打印机信息");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("没有检索到任何打印机信息，无法修改");
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtPrinterList))
            {
                if (dataGridViewPrinterList.SelectedRows != null)
                {
                    Hashtable printerItem = new Hashtable();

                    foreach (DataGridViewCell cell in dataGridViewPrinterList.SelectedRows[0].Cells)
                    {
                        printerItem.Add(cell.OwningColumn.DataPropertyName, cell.Value);
                    }

                    打印机信息 frm = new 打印机信息(printerItem);
                    frm.Text = "打印机修改";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btnSelect.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("请选择一条打印机信息");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("没有检索到任何打印机信息，无法修改");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dtPrinterList = DBOperate.GetPrinterList(textBoxPrinterName.Text.Trim(), textBoxPrinterAddress.Text.Trim());
            dataGridViewPrinterList.DataSource = dtPrinterList;
        }

        private void dataGridViewPrinterList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewPrinterList.Rows != null) && (dataGridViewPrinterList.SelectedRows.Count != 0))
            {
                btnMod.Enabled = true;
                btnDel.Enabled = true;
            }
            else
            {
                btnMod.Enabled = false;
                btnDel.Enabled = false;
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetNextControl(ActiveControl, true).Focus();
            }
        }
    }
}
