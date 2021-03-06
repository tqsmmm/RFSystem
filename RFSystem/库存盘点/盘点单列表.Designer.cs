namespace RFSystem
{
    partial class 盘点单列表
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
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtVDetail = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.recCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recCreatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recCreatorJobId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recRevisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recRevisorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recRevisorJobId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recReviseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.archiveFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.archiveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.internalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmJobId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtVDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(12, 84);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 26);
            this.dateTimePicker2.TabIndex = 156;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 155;
            this.label2.Text = "结束日期：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 26);
            this.dateTimePicker1.TabIndex = 154;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(12, 116);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 50);
            this.btnSearch.TabIndex = 152;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 153;
            this.label3.Text = "开始日期：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtVDetail);
            this.groupBox2.Location = new System.Drawing.Point(138, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(751, 175);
            this.groupBox2.TabIndex = 158;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "盘点清单详细";
            // 
            // dtVDetail
            // 
            this.dtVDetail.AllowUserToAddRows = false;
            this.dtVDetail.AllowUserToDeleteRows = false;
            this.dtVDetail.AllowUserToResizeRows = false;
            this.dtVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVDetail.Location = new System.Drawing.Point(3, 22);
            this.dtVDetail.MultiSelect = false;
            this.dtVDetail.Name = "dtVDetail";
            this.dtVDetail.ReadOnly = true;
            this.dtVDetail.RowHeadersVisible = false;
            this.dtVDetail.RowTemplate.Height = 23;
            this.dtVDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtVDetail.Size = new System.Drawing.Size(745, 150);
            this.dtVDetail.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(138, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 202);
            this.groupBox1.TabIndex = 157;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盘点清单列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recCreator,
            this.recCreatorName,
            this.recCreatorJobId,
            this.recCreateTime,
            this.recRevisor,
            this.recRevisorName,
            this.recRevisorJobId,
            this.recReviseTime,
            this.archiveFlag,
            this.archiveTime,
            this.internalCode,
            this.checkId,
            this.status,
            this.checkDate,
            this.checkUser,
            this.checkRemark,
            this.confirmJobId,
            this.confirmDate,
            this.genUser,
            this.genDate});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(745, 177);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // recCreator
            // 
            this.recCreator.DataPropertyName = "recCreator";
            this.recCreator.HeaderText = "记录创建人";
            this.recCreator.Name = "recCreator";
            this.recCreator.ReadOnly = true;
            // 
            // recCreatorName
            // 
            this.recCreatorName.DataPropertyName = "recCreatorName";
            this.recCreatorName.HeaderText = "记录创建人姓名";
            this.recCreatorName.Name = "recCreatorName";
            this.recCreatorName.ReadOnly = true;
            // 
            // recCreatorJobId
            // 
            this.recCreatorJobId.DataPropertyName = "recCreatorJobId";
            this.recCreatorJobId.HeaderText = "创建人岗位号";
            this.recCreatorJobId.Name = "recCreatorJobId";
            this.recCreatorJobId.ReadOnly = true;
            // 
            // recCreateTime
            // 
            this.recCreateTime.DataPropertyName = "recCreateTime";
            this.recCreateTime.HeaderText = "记录创建时间";
            this.recCreateTime.Name = "recCreateTime";
            this.recCreateTime.ReadOnly = true;
            // 
            // recRevisor
            // 
            this.recRevisor.DataPropertyName = "recRevisor";
            this.recRevisor.HeaderText = "记录修改人";
            this.recRevisor.Name = "recRevisor";
            this.recRevisor.ReadOnly = true;
            // 
            // recRevisorName
            // 
            this.recRevisorName.DataPropertyName = "recRevisorName";
            this.recRevisorName.HeaderText = "记录修改人姓名";
            this.recRevisorName.Name = "recRevisorName";
            this.recRevisorName.ReadOnly = true;
            // 
            // recRevisorJobId
            // 
            this.recRevisorJobId.DataPropertyName = "recRevisorJobId";
            this.recRevisorJobId.HeaderText = "记录修改人岗位号";
            this.recRevisorJobId.Name = "recRevisorJobId";
            this.recRevisorJobId.ReadOnly = true;
            // 
            // recReviseTime
            // 
            this.recReviseTime.DataPropertyName = "recReviseTime";
            this.recReviseTime.HeaderText = "记录修改时间";
            this.recReviseTime.Name = "recReviseTime";
            this.recReviseTime.ReadOnly = true;
            // 
            // archiveFlag
            // 
            this.archiveFlag.DataPropertyName = "archiveFlag";
            this.archiveFlag.HeaderText = "归档标志";
            this.archiveFlag.Name = "archiveFlag";
            this.archiveFlag.ReadOnly = true;
            // 
            // archiveTime
            // 
            this.archiveTime.DataPropertyName = "archiveTime";
            this.archiveTime.HeaderText = "归档时间";
            this.archiveTime.Name = "archiveTime";
            this.archiveTime.ReadOnly = true;
            // 
            // internalCode
            // 
            this.internalCode.DataPropertyName = "internalCode";
            this.internalCode.HeaderText = "内码";
            this.internalCode.Name = "internalCode";
            this.internalCode.ReadOnly = true;
            // 
            // checkId
            // 
            this.checkId.DataPropertyName = "checkId";
            this.checkId.HeaderText = "盘点单号";
            this.checkId.Name = "checkId";
            this.checkId.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // checkDate
            // 
            this.checkDate.DataPropertyName = "checkDate";
            this.checkDate.HeaderText = "盘点日期";
            this.checkDate.Name = "checkDate";
            this.checkDate.ReadOnly = true;
            // 
            // checkUser
            // 
            this.checkUser.DataPropertyName = "checkUser";
            this.checkUser.HeaderText = "盘点人";
            this.checkUser.Name = "checkUser";
            this.checkUser.ReadOnly = true;
            // 
            // checkRemark
            // 
            this.checkRemark.DataPropertyName = "checkRemark";
            this.checkRemark.HeaderText = "盘点备注";
            this.checkRemark.Name = "checkRemark";
            this.checkRemark.ReadOnly = true;
            // 
            // confirmJobId
            // 
            this.confirmJobId.DataPropertyName = "confirmJobId";
            this.confirmJobId.HeaderText = "确认人";
            this.confirmJobId.Name = "confirmJobId";
            this.confirmJobId.ReadOnly = true;
            // 
            // confirmDate
            // 
            this.confirmDate.DataPropertyName = "confirmDate";
            this.confirmDate.HeaderText = "确定日期";
            this.confirmDate.Name = "confirmDate";
            this.confirmDate.ReadOnly = true;
            // 
            // genUser
            // 
            this.genUser.DataPropertyName = "genUser";
            this.genUser.HeaderText = "生成人";
            this.genUser.Name = "genUser";
            this.genUser.ReadOnly = true;
            // 
            // genDate
            // 
            this.genDate.DataPropertyName = "genDate";
            this.genDate.HeaderText = "生成日期";
            this.genDate.Name = "genDate";
            this.genDate.ReadOnly = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Location = new System.Drawing.Point(517, 401);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(120, 50);
            this.btnCheck.TabIndex = 159;
            this.btnCheck.Text = "盘点单录入";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(643, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.TabIndex = 160;
            this.btnCancel.Text = "盘点单取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInput
            // 
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInput.Location = new System.Drawing.Point(769, 401);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(120, 50);
            this.btnInput.TabIndex = 161;
            this.btnInput.Text = "挑选库存";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // 盘点单列表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 463);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "盘点单列表";
            this.Text = "盘点单列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtVDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtVDetail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn recCreator;
        private System.Windows.Forms.DataGridViewTextBoxColumn recCreatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn recCreatorJobId;
        private System.Windows.Forms.DataGridViewTextBoxColumn recCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn recRevisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn recRevisorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn recRevisorJobId;
        private System.Windows.Forms.DataGridViewTextBoxColumn recReviseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn archiveFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn archiveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn internalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmJobId;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn genUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn genDate;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInput;
    }
}