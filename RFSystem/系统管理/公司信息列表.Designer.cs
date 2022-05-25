namespace RFSystem
{
    partial class 公司信息列表
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
            this.btnSelectPlant = new System.Windows.Forms.Button();
            this.textBoxPlantID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPlant = new System.Windows.Forms.Button();
            this.btnModPlant = new System.Windows.Forms.Button();
            this.dataGridViewPlantList = new System.Windows.Forms.DataGridView();
            this.columnPlantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPlantDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelPlant = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlantList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectPlant
            // 
            this.btnSelectPlant.Location = new System.Drawing.Point(12, 232);
            this.btnSelectPlant.Name = "btnSelectPlant";
            this.btnSelectPlant.Size = new System.Drawing.Size(120, 50);
            this.btnSelectPlant.TabIndex = 53;
            this.btnSelectPlant.Text = "查询";
            this.btnSelectPlant.UseVisualStyleBackColor = true;
            this.btnSelectPlant.Click += new System.EventHandler(this.btnSelectPlant_Click);
            // 
            // textBoxPlantID
            // 
            this.textBoxPlantID.Location = new System.Drawing.Point(12, 200);
            this.textBoxPlantID.Name = "textBoxPlantID";
            this.textBoxPlantID.Size = new System.Drawing.Size(120, 26);
            this.textBoxPlantID.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "编号：";
            // 
            // btnAddPlant
            // 
            this.btnAddPlant.Location = new System.Drawing.Point(12, 12);
            this.btnAddPlant.Name = "btnAddPlant";
            this.btnAddPlant.Size = new System.Drawing.Size(120, 50);
            this.btnAddPlant.TabIndex = 55;
            this.btnAddPlant.Text = "添加";
            this.btnAddPlant.UseVisualStyleBackColor = true;
            this.btnAddPlant.Click += new System.EventHandler(this.btnAddPlant_Click);
            // 
            // btnModPlant
            // 
            this.btnModPlant.Enabled = false;
            this.btnModPlant.Location = new System.Drawing.Point(12, 68);
            this.btnModPlant.Name = "btnModPlant";
            this.btnModPlant.Size = new System.Drawing.Size(120, 50);
            this.btnModPlant.TabIndex = 56;
            this.btnModPlant.Text = "修改";
            this.btnModPlant.UseVisualStyleBackColor = true;
            this.btnModPlant.Click += new System.EventHandler(this.btnModPlant_Click);
            // 
            // dataGridViewPlantList
            // 
            this.dataGridViewPlantList.AllowUserToAddRows = false;
            this.dataGridViewPlantList.AllowUserToResizeColumns = false;
            this.dataGridViewPlantList.AllowUserToResizeRows = false;
            this.dataGridViewPlantList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPlantList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPlantList.ColumnHeadersHeight = 30;
            this.dataGridViewPlantList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPlantList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPlantID,
            this.columnPlantDescription});
            this.dataGridViewPlantList.Location = new System.Drawing.Point(138, 12);
            this.dataGridViewPlantList.MultiSelect = false;
            this.dataGridViewPlantList.Name = "dataGridViewPlantList";
            this.dataGridViewPlantList.ReadOnly = true;
            this.dataGridViewPlantList.RowHeadersVisible = false;
            this.dataGridViewPlantList.RowTemplate.Height = 23;
            this.dataGridViewPlantList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPlantList.Size = new System.Drawing.Size(805, 539);
            this.dataGridViewPlantList.TabIndex = 54;
            this.dataGridViewPlantList.SelectionChanged += new System.EventHandler(this.dataGridViewPlantList_SelectionChanged);
            // 
            // columnPlantID
            // 
            this.columnPlantID.DataPropertyName = "PlantID";
            this.columnPlantID.HeaderText = "公司编号";
            this.columnPlantID.Name = "columnPlantID";
            this.columnPlantID.ReadOnly = true;
            this.columnPlantID.Width = 90;
            // 
            // columnPlantDescription
            // 
            this.columnPlantDescription.DataPropertyName = "PlantDescription";
            this.columnPlantDescription.HeaderText = "公司描述";
            this.columnPlantDescription.Name = "columnPlantDescription";
            this.columnPlantDescription.ReadOnly = true;
            this.columnPlantDescription.Width = 90;
            // 
            // btnDelPlant
            // 
            this.btnDelPlant.Enabled = false;
            this.btnDelPlant.Location = new System.Drawing.Point(12, 124);
            this.btnDelPlant.Name = "btnDelPlant";
            this.btnDelPlant.Size = new System.Drawing.Size(120, 50);
            this.btnDelPlant.TabIndex = 57;
            this.btnDelPlant.Text = "删除";
            this.btnDelPlant.UseVisualStyleBackColor = true;
            this.btnDelPlant.Click += new System.EventHandler(this.btnDelPlant_Click);
            // 
            // 公司信息列表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 563);
            this.Controls.Add(this.btnSelectPlant);
            this.Controls.Add(this.textBoxPlantID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddPlant);
            this.Controls.Add(this.btnModPlant);
            this.Controls.Add(this.dataGridViewPlantList);
            this.Controls.Add(this.btnDelPlant);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "公司信息列表";
            this.Text = "公司信息列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.公司信息列表_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlantList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectPlant;
        private System.Windows.Forms.TextBox textBoxPlantID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPlant;
        private System.Windows.Forms.Button btnModPlant;
        private System.Windows.Forms.DataGridView dataGridViewPlantList;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPlantID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPlantDescription;
        private System.Windows.Forms.Button btnDelPlant;
    }
}