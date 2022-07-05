namespace RFSystem
{
    partial class 保管员物料查询
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nudCopy = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPatchPrint = new System.Windows.Forms.Button();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewPrinterList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bct10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bct20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maktx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bct50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bct51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bct60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bct61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bct70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bct71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Charg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lgort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Werks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ebeln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ntgew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clabs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nudCopy
            // 
            this.nudCopy.Location = new System.Drawing.Point(12, 430);
            this.nudCopy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopy.Name = "nudCopy";
            this.nudCopy.Size = new System.Drawing.Size(120, 26);
            this.nudCopy.TabIndex = 1125;
            this.nudCopy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 407);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1122;
            this.label10.Text = "打印份数：";
            // 
            // btnPatchPrint
            // 
            this.btnPatchPrint.Enabled = false;
            this.btnPatchPrint.Location = new System.Drawing.Point(12, 518);
            this.btnPatchPrint.Name = "btnPatchPrint";
            this.btnPatchPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPatchPrint.TabIndex = 1124;
            this.btnPatchPrint.Text = "批量打印";
            this.btnPatchPrint.UseVisualStyleBackColor = true;
            this.btnPatchPrint.Click += new System.EventHandler(this.btnPatchPrint_Click);
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(12, 378);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(120, 26);
            this.txtPrinter.TabIndex = 1121;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(12, 462);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPrint.TabIndex = 1123;
            this.btnPrint.Text = "单个打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 1120;
            this.label11.Text = "打印机：";
            // 
            // dataGridViewPrinterList
            // 
            this.dataGridViewPrinterList.AllowUserToAddRows = false;
            this.dataGridViewPrinterList.AllowUserToResizeRows = false;
            this.dataGridViewPrinterList.ColumnHeadersHeight = 30;
            this.dataGridViewPrinterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPrinterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.columnPAddress,
            this.columnSocket});
            this.dataGridViewPrinterList.Location = new System.Drawing.Point(12, 172);
            this.dataGridViewPrinterList.MultiSelect = false;
            this.dataGridViewPrinterList.Name = "dataGridViewPrinterList";
            this.dataGridViewPrinterList.ReadOnly = true;
            this.dataGridViewPrinterList.RowHeadersVisible = false;
            this.dataGridViewPrinterList.RowTemplate.Height = 23;
            this.dataGridViewPrinterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrinterList.Size = new System.Drawing.Size(120, 180);
            this.dataGridViewPrinterList.TabIndex = 1126;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrinterName";
            this.dataGridViewTextBoxColumn1.HeaderText = "打印机";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
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
            this.groupBox2.Location = new System.Drawing.Point(138, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(826, 90);
            this.groupBox2.TabIndex = 1127;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "过滤信息";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(700, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 50);
            this.button2.TabIndex = 50;
            this.button2.Text = "过滤";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSubPlant
            // 
            this.txtSubPlant.Location = new System.Drawing.Point(101, 57);
            this.txtSubPlant.Name = "txtSubPlant";
            this.txtSubPlant.Size = new System.Drawing.Size(120, 26);
            this.txtSubPlant.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "二级厂：";
            // 
            // txtPlant
            // 
            this.txtPlant.Location = new System.Drawing.Point(495, 25);
            this.txtPlant.Name = "txtPlant";
            this.txtPlant.Size = new System.Drawing.Size(120, 26);
            this.txtPlant.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "工厂号：";
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(298, 25);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(120, 26);
            this.txtBatch.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "批次号：";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(101, 25);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(120, 26);
            this.txtMaterial.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "物料号：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 64);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 50);
            this.btnSelect.TabIndex = 30007;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxStoreMan.Location = new System.Drawing.Point(12, 32);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.Size = new System.Drawing.Size(120, 26);
            this.textBoxStoreMan.TabIndex = 30009;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 30008;
            this.label1.Text = "保管员岗位号：";
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
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bct10,
            this.Bct20,
            this.Maktx,
            this.Matnr,
            this.Bct50,
            this.Bct51,
            this.Bct60,
            this.Bct61,
            this.Bct70,
            this.Bct71,
            this.Charg,
            this.Lgort,
            this.Meins,
            this.Werks,
            this.Ebeln,
            this.Verpr,
            this.Name1,
            this.Ntgew,
            this.Clabs});
            this.dataGridView1.Location = new System.Drawing.Point(138, 108);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(826, 476);
            this.dataGridView1.TabIndex = 30010;
            // 
            // bct10
            // 
            this.bct10.HeaderText = "保管员";
            this.bct10.Name = "bct10";
            this.bct10.ReadOnly = true;
            this.bct10.Width = 76;
            // 
            // Bct20
            // 
            this.Bct20.HeaderText = "二级厂";
            this.Bct20.Name = "Bct20";
            this.Bct20.ReadOnly = true;
            this.Bct20.Width = 76;
            // 
            // Maktx
            // 
            this.Maktx.HeaderText = "物料描述";
            this.Maktx.Name = "Maktx";
            this.Maktx.ReadOnly = true;
            this.Maktx.Width = 90;
            // 
            // Matnr
            // 
            this.Matnr.HeaderText = "物料号";
            this.Matnr.Name = "Matnr";
            this.Matnr.ReadOnly = true;
            this.Matnr.Width = 76;
            // 
            // Bct50
            // 
            this.Bct50.HeaderText = "货位1";
            this.Bct50.Name = "Bct50";
            this.Bct50.ReadOnly = true;
            this.Bct50.Width = 70;
            // 
            // Bct51
            // 
            this.Bct51.HeaderText = "货位1数量";
            this.Bct51.Name = "Bct51";
            this.Bct51.ReadOnly = true;
            this.Bct51.Width = 98;
            // 
            // Bct60
            // 
            this.Bct60.HeaderText = "货位2";
            this.Bct60.Name = "Bct60";
            this.Bct60.ReadOnly = true;
            this.Bct60.Width = 70;
            // 
            // Bct61
            // 
            this.Bct61.HeaderText = "货位2数量";
            this.Bct61.Name = "Bct61";
            this.Bct61.ReadOnly = true;
            this.Bct61.Width = 98;
            // 
            // Bct70
            // 
            this.Bct70.HeaderText = "货位3";
            this.Bct70.Name = "Bct70";
            this.Bct70.ReadOnly = true;
            this.Bct70.Width = 70;
            // 
            // Bct71
            // 
            this.Bct71.HeaderText = "货位3数量";
            this.Bct71.Name = "Bct71";
            this.Bct71.ReadOnly = true;
            this.Bct71.Width = 98;
            // 
            // Charg
            // 
            this.Charg.HeaderText = "批次";
            this.Charg.Name = "Charg";
            this.Charg.ReadOnly = true;
            this.Charg.Width = 62;
            // 
            // Lgort
            // 
            this.Lgort.HeaderText = "库存地点";
            this.Lgort.Name = "Lgort";
            this.Lgort.ReadOnly = true;
            this.Lgort.Width = 90;
            // 
            // Meins
            // 
            this.Meins.HeaderText = "单位";
            this.Meins.Name = "Meins";
            this.Meins.ReadOnly = true;
            this.Meins.Width = 62;
            // 
            // Werks
            // 
            this.Werks.HeaderText = "工厂";
            this.Werks.Name = "Werks";
            this.Werks.ReadOnly = true;
            this.Werks.Width = 62;
            // 
            // Ebeln
            // 
            this.Ebeln.HeaderText = "订单号";
            this.Ebeln.Name = "Ebeln";
            this.Ebeln.ReadOnly = true;
            this.Ebeln.Width = 76;
            // 
            // Verpr
            // 
            this.Verpr.HeaderText = "单价";
            this.Verpr.Name = "Verpr";
            this.Verpr.ReadOnly = true;
            this.Verpr.Width = 62;
            // 
            // Name1
            // 
            this.Name1.HeaderText = "供应商";
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            this.Name1.Width = 76;
            // 
            // Ntgew
            // 
            this.Ntgew.HeaderText = "单重";
            this.Ntgew.Name = "Ntgew";
            this.Ntgew.ReadOnly = true;
            this.Ntgew.Width = 62;
            // 
            // Clabs
            // 
            this.Clabs.HeaderText = "库存数量";
            this.Clabs.Name = "Clabs";
            this.Clabs.ReadOnly = true;
            this.Clabs.Width = 90;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(120, 26);
            this.textBox1.TabIndex = 30024;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 30023;
            this.label6.Text = "查询数据：";
            // 
            // 保管员物料查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 596);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.textBoxStoreMan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nudCopy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPatchPrint);
            this.Controls.Add(this.txtPrinter);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridViewPrinterList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "保管员物料查询";
            this.Text = "保管员物料查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.保管员物料查询_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinterList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudCopy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPatchPrint;
        private System.Windows.Forms.TextBox txtPrinter;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewPrinterList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSocket;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSubPlant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox textBoxStoreMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bct10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bct20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maktx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bct50;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bct51;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bct60;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bct61;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bct70;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bct71;
        private System.Windows.Forms.DataGridViewTextBoxColumn Charg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lgort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meins;
        private System.Windows.Forms.DataGridViewTextBoxColumn Werks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ebeln;
        private System.Windows.Forms.DataGridViewTextBoxColumn Verpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ntgew;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clabs;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
    }
}