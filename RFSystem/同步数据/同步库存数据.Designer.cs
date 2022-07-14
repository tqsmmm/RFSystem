
namespace RFSystem
{
    partial class 同步库存数据
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.dataGridViewSapStockInfo = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.deliveryLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiveId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.储位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemUom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invLogicCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invBillTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invQualifiedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invOrQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invPhysicCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invResponserUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invResponserDeptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custodianJobId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inspectorJobId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invTransactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxStoreMan.Location = new System.Drawing.Point(12, 38);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.Size = new System.Drawing.Size(120, 26);
            this.textBoxStoreMan.TabIndex = 30004;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 30003;
            this.label1.Text = "保管员岗位号：";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(12, 70);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(120, 50);
            this.btnDownload.TabIndex = 30005;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dataGridViewSapStockInfo
            // 
            this.dataGridViewSapStockInfo.AllowUserToAddRows = false;
            this.dataGridViewSapStockInfo.AllowUserToDeleteRows = false;
            this.dataGridViewSapStockInfo.AllowUserToResizeRows = false;
            this.dataGridViewSapStockInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSapStockInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSapStockInfo.ColumnHeadersHeight = 30;
            this.dataGridViewSapStockInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSapStockInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deliveryLineId,
            this.receiveId,
            this.储位,
            this.itemId,
            this.itemName,
            this.itemDesc,
            this.itemUom,
            this.invLogicCode,
            this.invBillTo,
            this.invQualifiedQty,
            this.invOrQty,
            this.invQty,
            this.invPhysicCode,
            this.invResponserUserId,
            this.invResponserDeptId,
            this.accountTime,
            this.accountUserId,
            this.orderLineId,
            this.custodianJobId,
            this.inspectorJobId,
            this.transactionId,
            this.invTransactionId});
            this.dataGridViewSapStockInfo.Location = new System.Drawing.Point(138, 12);
            this.dataGridViewSapStockInfo.MultiSelect = false;
            this.dataGridViewSapStockInfo.Name = "dataGridViewSapStockInfo";
            this.dataGridViewSapStockInfo.ReadOnly = true;
            this.dataGridViewSapStockInfo.RowHeadersVisible = false;
            this.dataGridViewSapStockInfo.RowTemplate.Height = 23;
            this.dataGridViewSapStockInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSapStockInfo.Size = new System.Drawing.Size(814, 509);
            this.dataGridViewSapStockInfo.TabIndex = 30008;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(12, 178);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 50);
            this.btnUpdate.TabIndex = 30006;
            this.btnUpdate.Text = "同步";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 30009;
            this.label2.Text = "查询数据：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 146);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(120, 26);
            this.textBox1.TabIndex = 30010;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 254);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(120, 26);
            this.textBox2.TabIndex = 30011;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 30012;
            this.label3.Text = "同步数据：";
            // 
            // deliveryLineId
            // 
            this.deliveryLineId.DataPropertyName = "deliveryLineId";
            this.deliveryLineId.HeaderText = "送货单行号";
            this.deliveryLineId.Name = "deliveryLineId";
            this.deliveryLineId.ReadOnly = true;
            this.deliveryLineId.Width = 104;
            // 
            // receiveId
            // 
            this.receiveId.DataPropertyName = "receiveId";
            this.receiveId.HeaderText = "收货单号";
            this.receiveId.Name = "receiveId";
            this.receiveId.ReadOnly = true;
            this.receiveId.Width = 90;
            // 
            // 储位
            // 
            this.储位.DataPropertyName = "invBin";
            this.储位.HeaderText = "储位";
            this.储位.Name = "储位";
            this.储位.ReadOnly = true;
            this.储位.Width = 62;
            // 
            // itemId
            // 
            this.itemId.DataPropertyName = "itemId";
            this.itemId.HeaderText = "物料代码";
            this.itemId.Name = "itemId";
            this.itemId.ReadOnly = true;
            this.itemId.Width = 90;
            // 
            // itemName
            // 
            this.itemName.DataPropertyName = "itemName";
            this.itemName.HeaderText = "物料名称";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 90;
            // 
            // itemDesc
            // 
            this.itemDesc.DataPropertyName = "itemDesc";
            this.itemDesc.HeaderText = "物料短描述";
            this.itemDesc.Name = "itemDesc";
            this.itemDesc.ReadOnly = true;
            this.itemDesc.Width = 104;
            // 
            // itemUom
            // 
            this.itemUom.DataPropertyName = "itemUom";
            this.itemUom.HeaderText = "计量单位";
            this.itemUom.Name = "itemUom";
            this.itemUom.ReadOnly = true;
            this.itemUom.Width = 90;
            // 
            // invLogicCode
            // 
            this.invLogicCode.DataPropertyName = "invLogicCode";
            this.invLogicCode.HeaderText = "逻辑库区";
            this.invLogicCode.Name = "invLogicCode";
            this.invLogicCode.ReadOnly = true;
            this.invLogicCode.Width = 90;
            // 
            // invBillTo
            // 
            this.invBillTo.DataPropertyName = "invBillTo";
            this.invBillTo.HeaderText = "库存账套";
            this.invBillTo.Name = "invBillTo";
            this.invBillTo.ReadOnly = true;
            this.invBillTo.Width = 90;
            // 
            // invQualifiedQty
            // 
            this.invQualifiedQty.DataPropertyName = "invQualifiedQty";
            this.invQualifiedQty.HeaderText = "送货合格数量";
            this.invQualifiedQty.Name = "invQualifiedQty";
            this.invQualifiedQty.ReadOnly = true;
            this.invQualifiedQty.Width = 118;
            // 
            // invOrQty
            // 
            this.invOrQty.DataPropertyName = "invOrQty";
            this.invOrQty.HeaderText = "库存预约量";
            this.invOrQty.Name = "invOrQty";
            this.invOrQty.ReadOnly = true;
            this.invOrQty.Width = 104;
            // 
            // invQty
            // 
            this.invQty.DataPropertyName = "invQty";
            this.invQty.HeaderText = "库存数量";
            this.invQty.Name = "invQty";
            this.invQty.ReadOnly = true;
            this.invQty.Width = 90;
            // 
            // invPhysicCode
            // 
            this.invPhysicCode.DataPropertyName = "invPhysicCode";
            this.invPhysicCode.HeaderText = "物理库区";
            this.invPhysicCode.Name = "invPhysicCode";
            this.invPhysicCode.ReadOnly = true;
            this.invPhysicCode.Width = 90;
            // 
            // invResponserUserId
            // 
            this.invResponserUserId.DataPropertyName = "invResponserUserId";
            this.invResponserUserId.HeaderText = "库存责任人";
            this.invResponserUserId.Name = "invResponserUserId";
            this.invResponserUserId.ReadOnly = true;
            this.invResponserUserId.Width = 104;
            // 
            // invResponserDeptId
            // 
            this.invResponserDeptId.DataPropertyName = "invResponserDeptId";
            this.invResponserDeptId.HeaderText = "责任人部门";
            this.invResponserDeptId.Name = "invResponserDeptId";
            this.invResponserDeptId.ReadOnly = true;
            this.invResponserDeptId.Width = 104;
            // 
            // accountTime
            // 
            this.accountTime.DataPropertyName = "accountTime";
            this.accountTime.HeaderText = "收货日期";
            this.accountTime.Name = "accountTime";
            this.accountTime.ReadOnly = true;
            this.accountTime.Width = 90;
            // 
            // accountUserId
            // 
            this.accountUserId.DataPropertyName = "accountUserId";
            this.accountUserId.HeaderText = "收货人";
            this.accountUserId.Name = "accountUserId";
            this.accountUserId.ReadOnly = true;
            this.accountUserId.Width = 76;
            // 
            // orderLineId
            // 
            this.orderLineId.DataPropertyName = "orderLineId";
            this.orderLineId.HeaderText = "订单行号";
            this.orderLineId.Name = "orderLineId";
            this.orderLineId.ReadOnly = true;
            this.orderLineId.Width = 90;
            // 
            // custodianJobId
            // 
            this.custodianJobId.DataPropertyName = "custodianJobId";
            this.custodianJobId.HeaderText = "保管员";
            this.custodianJobId.Name = "custodianJobId";
            this.custodianJobId.ReadOnly = true;
            this.custodianJobId.Width = 76;
            // 
            // inspectorJobId
            // 
            this.inspectorJobId.DataPropertyName = "inspectorJobId";
            this.inspectorJobId.HeaderText = "验收员";
            this.inspectorJobId.Name = "inspectorJobId";
            this.inspectorJobId.ReadOnly = true;
            this.inspectorJobId.Width = 76;
            // 
            // transactionId
            // 
            this.transactionId.DataPropertyName = "transactionId";
            this.transactionId.HeaderText = "库存明细交易号";
            this.transactionId.Name = "transactionId";
            this.transactionId.ReadOnly = true;
            this.transactionId.Width = 132;
            // 
            // invTransactionId
            // 
            this.invTransactionId.DataPropertyName = "invTransactionId";
            this.invTransactionId.HeaderText = "库存主表交易号";
            this.invTransactionId.Name = "invTransactionId";
            this.invTransactionId.ReadOnly = true;
            this.invTransactionId.Width = 132;
            // 
            // 同步库存数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 533);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.textBoxStoreMan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewSapStockInfo);
            this.Controls.Add(this.btnUpdate);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "同步库存数据";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "同步库存数据";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.同步库存数据_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStoreMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridView dataGridViewSapStockInfo;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiveId;
        private System.Windows.Forms.DataGridViewTextBoxColumn 储位;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemUom;
        private System.Windows.Forms.DataGridViewTextBoxColumn invLogicCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn invBillTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn invQualifiedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn invOrQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn invQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn invPhysicCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn invResponserUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn invResponserDeptId;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn custodianJobId;
        private System.Windows.Forms.DataGridViewTextBoxColumn inspectorJobId;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn invTransactionId;
    }
}