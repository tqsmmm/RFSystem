namespace RFSystem
{
    partial class 同步物理库区
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.地区代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.地区名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.库存账套 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.库存账套名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.到货点代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.到货点名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.物理库区代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.物理库区名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.逻辑库区代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.逻辑库区名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.虚拟库标记 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否可移拨 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否启用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否校验 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.领用账套 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(12, 12);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(120, 50);
            this.btnDownload.TabIndex = 30011;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(12, 120);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 50);
            this.btnUpdate.TabIndex = 30012;
            this.btnUpdate.Text = "同步";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.地区代码,
            this.地区名称,
            this.库存账套,
            this.库存账套名称,
            this.到货点代码,
            this.到货点名称,
            this.物理库区代码,
            this.物理库区名称,
            this.逻辑库区代码,
            this.逻辑库区名称,
            this.虚拟库标记,
            this.是否可移拨,
            this.是否启用,
            this.是否校验,
            this.领用账套,
            this.备注});
            this.dataGridView1.Location = new System.Drawing.Point(138, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(821, 533);
            this.dataGridView1.TabIndex = 30015;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 30019;
            this.label3.Text = "同步数据：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 196);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(120, 26);
            this.textBox2.TabIndex = 30018;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(120, 26);
            this.textBox1.TabIndex = 30017;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 30016;
            this.label2.Text = "查询数据：";
            // 
            // 地区代码
            // 
            this.地区代码.DataPropertyName = "areaId";
            this.地区代码.HeaderText = "地区代码";
            this.地区代码.Name = "地区代码";
            this.地区代码.Width = 70;
            // 
            // 地区名称
            // 
            this.地区名称.DataPropertyName = "areaName";
            this.地区名称.HeaderText = "地区名称";
            this.地区名称.Name = "地区名称";
            this.地区名称.Width = 70;
            // 
            // 库存账套
            // 
            this.库存账套.DataPropertyName = "billTo";
            this.库存账套.HeaderText = "库存账套";
            this.库存账套.Name = "库存账套";
            this.库存账套.Width = 70;
            // 
            // 库存账套名称
            // 
            this.库存账套名称.DataPropertyName = "billToName";
            this.库存账套名称.HeaderText = "库存账套名称";
            this.库存账套名称.Name = "库存账套名称";
            this.库存账套名称.Width = 83;
            // 
            // 到货点代码
            // 
            this.到货点代码.DataPropertyName = "shiptoId";
            this.到货点代码.HeaderText = "到货点代码";
            this.到货点代码.Name = "到货点代码";
            this.到货点代码.Width = 83;
            // 
            // 到货点名称
            // 
            this.到货点名称.DataPropertyName = "shiptoName";
            this.到货点名称.HeaderText = "到货点名称";
            this.到货点名称.Name = "到货点名称";
            this.到货点名称.Width = 83;
            // 
            // 物理库区代码
            // 
            this.物理库区代码.DataPropertyName = "invPhysicCode";
            this.物理库区代码.HeaderText = "物理库区代码";
            this.物理库区代码.Name = "物理库区代码";
            this.物理库区代码.Width = 83;
            // 
            // 物理库区名称
            // 
            this.物理库区名称.DataPropertyName = "invPhysicName";
            this.物理库区名称.HeaderText = "物理库区名称";
            this.物理库区名称.Name = "物理库区名称";
            this.物理库区名称.Width = 83;
            // 
            // 逻辑库区代码
            // 
            this.逻辑库区代码.DataPropertyName = "invLogicCode";
            this.逻辑库区代码.HeaderText = "逻辑库区代码";
            this.逻辑库区代码.Name = "逻辑库区代码";
            this.逻辑库区代码.Width = 83;
            // 
            // 逻辑库区名称
            // 
            this.逻辑库区名称.DataPropertyName = "invLogicName";
            this.逻辑库区名称.HeaderText = "逻辑库区名称";
            this.逻辑库区名称.Name = "逻辑库区名称";
            this.逻辑库区名称.Width = 83;
            // 
            // 虚拟库标记
            // 
            this.虚拟库标记.DataPropertyName = "virtualMark";
            this.虚拟库标记.HeaderText = "虚拟库标记";
            this.虚拟库标记.Name = "虚拟库标记";
            this.虚拟库标记.Width = 83;
            // 
            // 是否可移拨
            // 
            this.是否可移拨.DataPropertyName = "ifTransfer";
            this.是否可移拨.HeaderText = "是否可移拨";
            this.是否可移拨.Name = "是否可移拨";
            this.是否可移拨.Width = 83;
            // 
            // 是否启用
            // 
            this.是否启用.DataPropertyName = "isActive";
            this.是否启用.HeaderText = "是否启用";
            this.是否启用.Name = "是否启用";
            this.是否启用.Width = 70;
            // 
            // 是否校验
            // 
            this.是否校验.DataPropertyName = "ifCheck";
            this.是否校验.HeaderText = "是否校验";
            this.是否校验.Name = "是否校验";
            this.是否校验.Width = 70;
            // 
            // 领用账套
            // 
            this.领用账套.DataPropertyName = "ddBillTo";
            this.领用账套.HeaderText = "领用账套";
            this.领用账套.Name = "领用账套";
            this.领用账套.Width = 70;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "remark";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.Width = 58;
            // 
            // 同步物理库区
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 557);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpdate);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "同步物理库区";
            this.Text = "同步物理库区";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.同步物理库区_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 地区代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 地区名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库存账套;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库存账套名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 到货点代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 到货点名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 物理库区代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 物理库区名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 逻辑库区代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 逻辑库区名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 虚拟库标记;
        private System.Windows.Forms.DataGridViewTextBoxColumn 是否可移拨;
        private System.Windows.Forms.DataGridViewTextBoxColumn 是否启用;
        private System.Windows.Forms.DataGridViewTextBoxColumn 是否校验;
        private System.Windows.Forms.DataGridViewTextBoxColumn 领用账套;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
    }
}