namespace RFSystem
{
    partial class 逻辑库区信息列表
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
            this.comboBoxPlantList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectStore = new System.Windows.Forms.Button();
            this.textBoxStoreID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddStore = new System.Windows.Forms.Button();
            this.btnDelStore = new System.Windows.Forms.Button();
            this.dataGridViewStoreList = new System.Windows.Forms.DataGridView();
            this.columnStoreLocusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStorePlantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStoreDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModStore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStoreList)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxPlantList
            // 
            this.comboBoxPlantList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlantList.FormattingEnabled = true;
            this.comboBoxPlantList.Location = new System.Drawing.Point(12, 252);
            this.comboBoxPlantList.Name = "comboBoxPlantList";
            this.comboBoxPlantList.Size = new System.Drawing.Size(120, 28);
            this.comboBoxPlantList.TabIndex = 1054;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 1052;
            this.label5.Text = "从属库存账套：";
            // 
            // btnSelectStore
            // 
            this.btnSelectStore.Location = new System.Drawing.Point(12, 286);
            this.btnSelectStore.Name = "btnSelectStore";
            this.btnSelectStore.Size = new System.Drawing.Size(120, 50);
            this.btnSelectStore.TabIndex = 1055;
            this.btnSelectStore.Text = "查询";
            this.btnSelectStore.UseVisualStyleBackColor = true;
            this.btnSelectStore.Click += new System.EventHandler(this.btnSelectStore_Click);
            // 
            // textBoxStoreID
            // 
            this.textBoxStoreID.Location = new System.Drawing.Point(12, 200);
            this.textBoxStoreID.Name = "textBoxStoreID";
            this.textBoxStoreID.Size = new System.Drawing.Size(120, 26);
            this.textBoxStoreID.TabIndex = 1053;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 1051;
            this.label3.Text = "编号：";
            // 
            // btnAddStore
            // 
            this.btnAddStore.Location = new System.Drawing.Point(12, 12);
            this.btnAddStore.Name = "btnAddStore";
            this.btnAddStore.Size = new System.Drawing.Size(120, 50);
            this.btnAddStore.TabIndex = 1057;
            this.btnAddStore.Text = "添加";
            this.btnAddStore.UseVisualStyleBackColor = true;
            this.btnAddStore.Click += new System.EventHandler(this.btnAddStore_Click);
            // 
            // btnDelStore
            // 
            this.btnDelStore.Enabled = false;
            this.btnDelStore.Location = new System.Drawing.Point(12, 124);
            this.btnDelStore.Name = "btnDelStore";
            this.btnDelStore.Size = new System.Drawing.Size(120, 50);
            this.btnDelStore.TabIndex = 1058;
            this.btnDelStore.Text = "删除";
            this.btnDelStore.UseVisualStyleBackColor = true;
            this.btnDelStore.Click += new System.EventHandler(this.btnDelStore_Click);
            // 
            // dataGridViewStoreList
            // 
            this.dataGridViewStoreList.AllowUserToAddRows = false;
            this.dataGridViewStoreList.AllowUserToResizeColumns = false;
            this.dataGridViewStoreList.AllowUserToResizeRows = false;
            this.dataGridViewStoreList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStoreList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStoreList.ColumnHeadersHeight = 30;
            this.dataGridViewStoreList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStoreList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnStoreLocusID,
            this.columnStorePlantID,
            this.columnStoreDescription});
            this.dataGridViewStoreList.Location = new System.Drawing.Point(138, 12);
            this.dataGridViewStoreList.MultiSelect = false;
            this.dataGridViewStoreList.Name = "dataGridViewStoreList";
            this.dataGridViewStoreList.ReadOnly = true;
            this.dataGridViewStoreList.RowHeadersVisible = false;
            this.dataGridViewStoreList.RowTemplate.Height = 23;
            this.dataGridViewStoreList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewStoreList.Size = new System.Drawing.Size(869, 508);
            this.dataGridViewStoreList.TabIndex = 1056;
            this.dataGridViewStoreList.SelectionChanged += new System.EventHandler(this.dataGridViewStoreList_SelectionChanged);
            // 
            // columnStoreLocusID
            // 
            this.columnStoreLocusID.DataPropertyName = "StoreLocusID";
            this.columnStoreLocusID.HeaderText = "逻辑库区编号";
            this.columnStoreLocusID.Name = "columnStoreLocusID";
            this.columnStoreLocusID.ReadOnly = true;
            this.columnStoreLocusID.Width = 118;
            // 
            // columnStorePlantID
            // 
            this.columnStorePlantID.DataPropertyName = "PlantID";
            this.columnStorePlantID.HeaderText = "从属库存账套编号";
            this.columnStorePlantID.Name = "columnStorePlantID";
            this.columnStorePlantID.ReadOnly = true;
            this.columnStorePlantID.Width = 118;
            // 
            // columnStoreDescription
            // 
            this.columnStoreDescription.DataPropertyName = "StoreLocusDescription";
            this.columnStoreDescription.HeaderText = "逻辑库区描述";
            this.columnStoreDescription.Name = "columnStoreDescription";
            this.columnStoreDescription.ReadOnly = true;
            this.columnStoreDescription.Width = 118;
            // 
            // btnModStore
            // 
            this.btnModStore.Enabled = false;
            this.btnModStore.Location = new System.Drawing.Point(12, 68);
            this.btnModStore.Name = "btnModStore";
            this.btnModStore.Size = new System.Drawing.Size(120, 50);
            this.btnModStore.TabIndex = 1059;
            this.btnModStore.Text = "修改";
            this.btnModStore.UseVisualStyleBackColor = true;
            this.btnModStore.Click += new System.EventHandler(this.btnModStore_Click);
            // 
            // 逻辑库区信息列表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 532);
            this.Controls.Add(this.comboBoxPlantList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSelectStore);
            this.Controls.Add(this.textBoxStoreID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddStore);
            this.Controls.Add(this.btnDelStore);
            this.Controls.Add(this.dataGridViewStoreList);
            this.Controls.Add(this.btnModStore);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "逻辑库区信息列表";
            this.Text = "逻辑库区信息列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.逻辑库区信息列表_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStoreList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPlantList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectStore;
        private System.Windows.Forms.TextBox textBoxStoreID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddStore;
        private System.Windows.Forms.Button btnDelStore;
        private System.Windows.Forms.DataGridView dataGridViewStoreList;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStoreLocusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStorePlantID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStoreDescription;
        private System.Windows.Forms.Button btnModStore;
    }
}