using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RFSystem
{
    public class 保养货物 : Form
    {
        // Fields
        private Button btnAddCount;
        private Button btnSelect;
        private CheckBox checkBoxComplete;
        private DataGridView dataGridViewMaintainInfo;
        private DataTable dtMaintainList;
        private DataView dvMaintainList;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxBARCODE;
        private TextBox textBoxBin;
        private TextBox textBoxPRODUCT_NAME;
        private DataGridViewTextBoxColumn ColumnMAINTAIN_NO;
        private DataGridViewTextBoxColumn ColumnSL;
        private DataGridViewTextBoxColumn ColumnFACTORY_NO;
        private DataGridViewTextBoxColumn ColumnPATCH_NO;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NO;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NAME;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private DataGridViewTextBoxColumn ColumnBIN;
        private DataGridViewTextBoxColumn ColumnPLAN_NUM;
        private DataGridViewTextBoxColumn ColumnMAINTAINNUM;
        private DataGridViewTextBoxColumn ColumnSUPPLIER_NO;
        private DataGridViewTextBoxColumn ColumnSTOREMAN;
        private DataGridViewTextBoxColumn ColumnOPERATOR;
        private DataGridViewTextBoxColumn ColumnOPERATE_TIME;
        private DataGridViewTextBoxColumn ColumnBARCODE;
        private DataGridViewTextBoxColumn ColumnYWTM;
        private TextBox labelSL;
        private TextBox lablePlant;

        private void InitializeComponent()
        {
            this.dataGridViewMaintainInfo = new System.Windows.Forms.DataGridView();
            this.ColumnMAINTAIN_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFACTORY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPATCH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPLAN_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMAINTAINNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSUPPLIER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTOREMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOPERATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOPERATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBARCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYWTM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSL = new System.Windows.Forms.TextBox();
            this.lablePlant = new System.Windows.Forms.TextBox();
            this.textBoxPRODUCT_NAME = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBARCODE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxComplete = new System.Windows.Forms.CheckBox();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddCount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintainInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMaintainInfo
            // 
            this.dataGridViewMaintainInfo.AllowUserToAddRows = false;
            this.dataGridViewMaintainInfo.AllowUserToResizeRows = false;
            this.dataGridViewMaintainInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMaintainInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMaintainInfo.ColumnHeadersHeight = 30;
            this.dataGridViewMaintainInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMaintainInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMAINTAIN_NO,
            this.ColumnSL,
            this.ColumnFACTORY_NO,
            this.ColumnPATCH_NO,
            this.ColumnPRODUCT_NO,
            this.ColumnPRODUCT_NAME,
            this.ColumnUNIT,
            this.ColumnBIN,
            this.ColumnPLAN_NUM,
            this.ColumnMAINTAINNUM,
            this.ColumnSUPPLIER_NO,
            this.ColumnSTOREMAN,
            this.ColumnOPERATOR,
            this.ColumnOPERATE_TIME,
            this.ColumnBARCODE,
            this.ColumnYWTM});
            this.dataGridViewMaintainInfo.Location = new System.Drawing.Point(12, 118);
            this.dataGridViewMaintainInfo.MultiSelect = false;
            this.dataGridViewMaintainInfo.Name = "dataGridViewMaintainInfo";
            this.dataGridViewMaintainInfo.ReadOnly = true;
            this.dataGridViewMaintainInfo.RowHeadersVisible = false;
            this.dataGridViewMaintainInfo.RowTemplate.Height = 23;
            this.dataGridViewMaintainInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintainInfo.Size = new System.Drawing.Size(950, 442);
            this.dataGridViewMaintainInfo.TabIndex = 13;
            this.dataGridViewMaintainInfo.SelectionChanged += new System.EventHandler(this.dataGridViewMaintainInfo_SelectionChanged);
            // 
            // ColumnMAINTAIN_NO
            // 
            this.ColumnMAINTAIN_NO.DataPropertyName = "MAINTAIN_NO";
            this.ColumnMAINTAIN_NO.HeaderText = "保养单号";
            this.ColumnMAINTAIN_NO.Name = "ColumnMAINTAIN_NO";
            this.ColumnMAINTAIN_NO.ReadOnly = true;
            this.ColumnMAINTAIN_NO.Width = 90;
            // 
            // ColumnSL
            // 
            this.ColumnSL.DataPropertyName = "SL";
            this.ColumnSL.HeaderText = "存储地点";
            this.ColumnSL.Name = "ColumnSL";
            this.ColumnSL.ReadOnly = true;
            this.ColumnSL.Width = 90;
            // 
            // ColumnFACTORY_NO
            // 
            this.ColumnFACTORY_NO.DataPropertyName = "FACTORY_NO";
            this.ColumnFACTORY_NO.HeaderText = "公司";
            this.ColumnFACTORY_NO.Name = "ColumnFACTORY_NO";
            this.ColumnFACTORY_NO.ReadOnly = true;
            this.ColumnFACTORY_NO.Width = 62;
            // 
            // ColumnPATCH_NO
            // 
            this.ColumnPATCH_NO.DataPropertyName = "PATCH_NO";
            this.ColumnPATCH_NO.HeaderText = "批次号";
            this.ColumnPATCH_NO.Name = "ColumnPATCH_NO";
            this.ColumnPATCH_NO.ReadOnly = true;
            this.ColumnPATCH_NO.Width = 76;
            // 
            // ColumnPRODUCT_NO
            // 
            this.ColumnPRODUCT_NO.DataPropertyName = "PRODUCT_NO";
            this.ColumnPRODUCT_NO.HeaderText = "物料号";
            this.ColumnPRODUCT_NO.Name = "ColumnPRODUCT_NO";
            this.ColumnPRODUCT_NO.ReadOnly = true;
            this.ColumnPRODUCT_NO.Width = 76;
            // 
            // ColumnPRODUCT_NAME
            // 
            this.ColumnPRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.ColumnPRODUCT_NAME.HeaderText = "货物名称";
            this.ColumnPRODUCT_NAME.Name = "ColumnPRODUCT_NAME";
            this.ColumnPRODUCT_NAME.ReadOnly = true;
            this.ColumnPRODUCT_NAME.Width = 90;
            // 
            // ColumnUNIT
            // 
            this.ColumnUNIT.DataPropertyName = "UNIT";
            this.ColumnUNIT.HeaderText = "单位";
            this.ColumnUNIT.Name = "ColumnUNIT";
            this.ColumnUNIT.ReadOnly = true;
            this.ColumnUNIT.Width = 62;
            // 
            // ColumnBIN
            // 
            this.ColumnBIN.DataPropertyName = "BIN";
            this.ColumnBIN.HeaderText = "货位";
            this.ColumnBIN.Name = "ColumnBIN";
            this.ColumnBIN.ReadOnly = true;
            this.ColumnBIN.Width = 62;
            // 
            // ColumnPLAN_NUM
            // 
            this.ColumnPLAN_NUM.DataPropertyName = "PLAN_NUM";
            this.ColumnPLAN_NUM.HeaderText = "计划数量";
            this.ColumnPLAN_NUM.Name = "ColumnPLAN_NUM";
            this.ColumnPLAN_NUM.ReadOnly = true;
            this.ColumnPLAN_NUM.Width = 90;
            // 
            // ColumnMAINTAINNUM
            // 
            this.ColumnMAINTAINNUM.DataPropertyName = "MAINTAINNUM";
            this.ColumnMAINTAINNUM.HeaderText = "保养数量";
            this.ColumnMAINTAINNUM.Name = "ColumnMAINTAINNUM";
            this.ColumnMAINTAINNUM.ReadOnly = true;
            this.ColumnMAINTAINNUM.Width = 90;
            // 
            // ColumnSUPPLIER_NO
            // 
            this.ColumnSUPPLIER_NO.DataPropertyName = "SUPPLIER_NO";
            this.ColumnSUPPLIER_NO.HeaderText = "二级厂";
            this.ColumnSUPPLIER_NO.Name = "ColumnSUPPLIER_NO";
            this.ColumnSUPPLIER_NO.ReadOnly = true;
            this.ColumnSUPPLIER_NO.Width = 76;
            // 
            // ColumnSTOREMAN
            // 
            this.ColumnSTOREMAN.DataPropertyName = "STOREMAN";
            this.ColumnSTOREMAN.HeaderText = "保管员";
            this.ColumnSTOREMAN.Name = "ColumnSTOREMAN";
            this.ColumnSTOREMAN.ReadOnly = true;
            this.ColumnSTOREMAN.Width = 76;
            // 
            // ColumnOPERATOR
            // 
            this.ColumnOPERATOR.DataPropertyName = "OPERATOR";
            this.ColumnOPERATOR.HeaderText = "制单员";
            this.ColumnOPERATOR.Name = "ColumnOPERATOR";
            this.ColumnOPERATOR.ReadOnly = true;
            this.ColumnOPERATOR.Width = 76;
            // 
            // ColumnOPERATE_TIME
            // 
            this.ColumnOPERATE_TIME.DataPropertyName = "OPERATE_TIME";
            this.ColumnOPERATE_TIME.HeaderText = "制单日期";
            this.ColumnOPERATE_TIME.Name = "ColumnOPERATE_TIME";
            this.ColumnOPERATE_TIME.ReadOnly = true;
            this.ColumnOPERATE_TIME.Width = 90;
            // 
            // ColumnBARCODE
            // 
            this.ColumnBARCODE.DataPropertyName = "BARCODE";
            this.ColumnBARCODE.HeaderText = "条码号";
            this.ColumnBARCODE.Name = "ColumnBARCODE";
            this.ColumnBARCODE.ReadOnly = true;
            this.ColumnBARCODE.Visible = false;
            this.ColumnBARCODE.Width = 61;
            // 
            // ColumnYWTM
            // 
            this.ColumnYWTM.DataPropertyName = "ywtm";
            this.ColumnYWTM.HeaderText = "一维条码";
            this.ColumnYWTM.Name = "ColumnYWTM";
            this.ColumnYWTM.ReadOnly = true;
            this.ColumnYWTM.Width = 90;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelSL);
            this.groupBox1.Controls.Add(this.lablePlant);
            this.groupBox1.Controls.Add(this.textBoxPRODUCT_NAME);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxBARCODE);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxComplete);
            this.groupBox1.Controls.Add(this.textBoxBin);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(948, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盘存信息检索";
            // 
            // labelSL
            // 
            this.labelSL.Location = new System.Drawing.Point(330, 25);
            this.labelSL.Name = "labelSL";
            this.labelSL.Size = new System.Drawing.Size(150, 26);
            this.labelSL.TabIndex = 140;
            // 
            // lablePlant
            // 
            this.lablePlant.Location = new System.Drawing.Point(89, 25);
            this.lablePlant.Name = "lablePlant";
            this.lablePlant.Size = new System.Drawing.Size(150, 26);
            this.lablePlant.TabIndex = 139;
            // 
            // textBoxPRODUCT_NAME
            // 
            this.textBoxPRODUCT_NAME.Location = new System.Drawing.Point(330, 57);
            this.textBoxPRODUCT_NAME.Name = "textBoxPRODUCT_NAME";
            this.textBoxPRODUCT_NAME.Size = new System.Drawing.Size(150, 26);
            this.textBoxPRODUCT_NAME.TabIndex = 138;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 137;
            this.label2.Text = "货物名称：";
            // 
            // textBoxBARCODE
            // 
            this.textBoxBARCODE.Location = new System.Drawing.Point(89, 57);
            this.textBoxBARCODE.Name = "textBoxBARCODE";
            this.textBoxBARCODE.Size = new System.Drawing.Size(150, 26);
            this.textBoxBARCODE.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 135;
            this.label1.Text = "条码号：";
            // 
            // checkBoxComplete
            // 
            this.checkBoxComplete.AutoSize = true;
            this.checkBoxComplete.Location = new System.Drawing.Point(699, 27);
            this.checkBoxComplete.Name = "checkBoxComplete";
            this.checkBoxComplete.Size = new System.Drawing.Size(70, 24);
            this.checkBoxComplete.TabIndex = 120;
            this.checkBoxComplete.Text = "未完成";
            this.checkBoxComplete.UseVisualStyleBackColor = true;
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(543, 25);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(150, 26);
            this.textBoxBin.TabIndex = 40;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(842, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 130;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(486, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "货位：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "公司：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "存储地点：";
            // 
            // btnAddCount
            // 
            this.btnAddCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCount.Enabled = false;
            this.btnAddCount.Location = new System.Drawing.Point(862, 566);
            this.btnAddCount.Name = "btnAddCount";
            this.btnAddCount.Size = new System.Drawing.Size(100, 40);
            this.btnAddCount.TabIndex = 503;
            this.btnAddCount.Text = "进行保养";
            this.btnAddCount.UseVisualStyleBackColor = true;
            this.btnAddCount.Click += new System.EventHandler(this.btnAddCount_Click);
            // 
            // 保养货物
            // 
            this.ClientSize = new System.Drawing.Size(974, 618);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddCount);
            this.Controls.Add(this.dataGridViewMaintainInfo);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "保养货物";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保养货物";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.保养货物_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintainInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        // Methods
        public 保养货物(string maintainNo)
        {
            InitializeComponent();
            dtMaintainList = new DataTable();
            ArrayList arriveList = new ArrayList();
            arriveList.Add(maintainNo);

            for (int i = 0; i < 8; i++)
            {
                arriveList.Add(string.Empty);
            }

            //this.dtMaintainList = DBOperate.MaintainGetList(arriveList);
            //2015-09-09
            dtMaintainList = ClsCommon.MaintainGetList_New(arriveList);
            dvMaintainList = dtMaintainList.DefaultView;
            dataGridViewMaintainInfo.DataSource = dvMaintainList;
        }

        private void btnAddCount_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridViewMaintainInfo.SelectedRows[0];

            新增保养数量 新增保养数量 = new 新增保养数量(row.Cells["ColumnMAINTAIN_NO"].Value.ToString(), row.Cells["ColumnBIN"].Value.ToString(), row.Cells["ColumnBARCODE"].Value.ToString(), row.Cells["ColumnPRODUCT_NAME"].Value.ToString(), row.Cells["ColumnPLAN_NUM"].Value.ToString(), row.Cells["ColumnMAINTAINNUM"].Value.ToString());

            if (新增保养数量.ShowDialog() == DialogResult.OK)
            {
                dtMaintainList.Select(" MAINTAIN_NO='" + row.Cells["ColumnMAINTAIN_NO"].Value.ToString() + "' and BIN='" + row.Cells["ColumnBIN"].Value.ToString() + "' and BARCODE='" + row.Cells["ColumnBARCODE"].Value.ToString() + "'")[0]["MAINTAINNUM"] = ((decimal)row.Cells["ColumnMAINTAINNUM"].Value) + 新增保养数量.ResultValue;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" 1=1 ");

            if (!textBoxBin.Text.Trim().Equals(string.Empty))
            {
                builder.Append(" and BIN LIKE '%" + textBoxBin.Text.Trim() + "%'");
            }

            if (!textBoxBARCODE.Text.Trim().Equals(string.Empty))
            {
                builder.Append(" and BARCODE LIKE '%" + textBoxBARCODE.Text.Trim() + "%'");
            }

            if (!textBoxBARCODE.Text.Trim().Equals(string.Empty))
            {
                builder.Append(" and ywtm LIKE '%" + textBoxBARCODE.Text.Trim() + "%'");
            }

            if (!textBoxPRODUCT_NAME.Text.Trim().Equals(string.Empty))
            {
                builder.Append(" and PRODUCT_NAME LIKE'%" + textBoxPRODUCT_NAME.Text.Trim() + "%'");
            }

            if (checkBoxComplete.Checked)
            {
                builder.Append(" and PLAN_NUM>MAINTAINNUM");
            }

            dvMaintainList.RowFilter = builder.ToString();
        }

        private void dataGridViewMaintainInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewMaintainInfo.Rows != null) && (dataGridViewMaintainInfo.SelectedRows.Count != 0))
            {
                DataGridViewRow row = dataGridViewMaintainInfo.SelectedRows[0];

                if (((decimal)row.Cells["ColumnPLAN_NUM"].Value) > ((decimal)row.Cells["ColumnMAINTAINNUM"].Value))
                {
                    btnAddCount.Enabled = true;
                }
                else
                {
                    btnAddCount.Enabled = false;
                }
            }
            else
            {
                btnAddCount.Enabled = false;
            }
        }

        private void 保养货物_Load(object sender, EventArgs e)
        {

        }
    }
}
