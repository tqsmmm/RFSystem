using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BL;
using System.Collections;
using DsToExcel;
using RFSystem.CommonClass;

namespace RFSystem
{
    public class 盘点报表 : Form
    {
        private Button btnMod;
        private Button btnReason;
        private Button btnSelect;
        private ToExcelButton buttonExcel;
        private CheckBox checkBoxDiff;
        private DataGridViewTextBoxColumn ColumnBNumber;
        private DataGridViewTextBoxColumn ColumnCausation;
        private DataGridViewTextBoxColumn ColumnMaterial;
        private DataGridViewTextBoxColumn ColumnMDesc;
        private DataGridViewTextBoxColumn ColumnOperatorDateTime;
        private DataGridViewTextBoxColumn ColumnOperatorUser;
        private DataGridViewTextBoxColumn ColumnPlant;
        private DataGridViewTextBoxColumn ColumnSapBin1;
        private DataGridViewTextBoxColumn ColumnSapBin2;
        private DataGridViewTextBoxColumn ColumnSapBin3;
        private DataGridViewTextBoxColumn ColumnSapBinCount1;
        private DataGridViewTextBoxColumn ColumnSapBinCount2;
        private DataGridViewTextBoxColumn ColumnSapBinCount3;
        private DataGridViewTextBoxColumn ColumnSapCount;
        private DataGridViewTextBoxColumn ColumnSapItemNo;
        private DataGridViewTextBoxColumn ColumnSLocation;
        private DataGridViewTextBoxColumn ColumnSPEC;
        private DataGridViewTextBoxColumn ColumnSTBin1;
        private DataGridViewTextBoxColumn ColumnSTBin2;
        private DataGridViewTextBoxColumn ColumnSTBin3;
        private DataGridViewTextBoxColumn ColumnSTBinCount1;
        private DataGridViewTextBoxColumn ColumnSTBinCount2;
        private DataGridViewTextBoxColumn ColumnSTBinCount3;
        private DataGridViewTextBoxColumn ColumnSTCount;
        private DataGridViewTextBoxColumn ColumnSubPlant;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private ComboBox comboBoxOperatorUser;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private DataGridView dataGridViewReport;
        private DataTable dtExcel;
        private DataTable dtPlantList;
        private DataTable dtReport;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox2;
        private Label label1;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label7;
        private string stSerial;
        private string STStatus;
        private TextBox textBoxBNumber;
        private TextBox textBoxCausation;
        private TextBox textBoxMaterial;
        private UserInfo userItem;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.ColumnSapItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSapCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSapBin1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSapBinCount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSapBin2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSapBinCount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSapBin3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSapBinCount3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBin1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBinCount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBin2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBinCount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBin3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTBinCount3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCausation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxDiff = new System.Windows.Forms.CheckBox();
            this.comboBoxOperatorUser = new System.Windows.Forms.ComboBox();
            this.textBoxBNumber = new System.Windows.Forms.TextBox();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCausation = new System.Windows.Forms.TextBox();
            this.btnReason = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.AllowUserToAddRows = false;
            this.dataGridViewReport.AllowUserToResizeRows = false;
            this.dataGridViewReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewReport.ColumnHeadersHeight = 30;
            this.dataGridViewReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSapItemNo,
            this.ColumnPlant,
            this.ColumnSLocation,
            this.ColumnSubPlant,
            this.ColumnMaterial,
            this.ColumnBNumber,
            this.ColumnMDesc,
            this.ColumnUNIT,
            this.ColumnSPEC,
            this.ColumnSapCount,
            this.ColumnSTCount,
            this.ColumnSapBin1,
            this.ColumnSapBinCount1,
            this.ColumnSapBin2,
            this.ColumnSapBinCount2,
            this.ColumnSapBin3,
            this.ColumnSapBinCount3,
            this.ColumnSTBin1,
            this.ColumnSTBinCount1,
            this.ColumnSTBin2,
            this.ColumnSTBinCount2,
            this.ColumnSTBin3,
            this.ColumnSTBinCount3,
            this.ColumnOperatorUser,
            this.ColumnOperatorDateTime,
            this.ColumnCausation});
            this.dataGridViewReport.Location = new System.Drawing.Point(12, 118);
            this.dataGridViewReport.MultiSelect = false;
            this.dataGridViewReport.Name = "dataGridViewReport";
            this.dataGridViewReport.ReadOnly = true;
            this.dataGridViewReport.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewReport.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewReport.RowTemplate.Height = 23;
            this.dataGridViewReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReport.Size = new System.Drawing.Size(956, 474);
            this.dataGridViewReport.TabIndex = 300;
            this.dataGridViewReport.SelectionChanged += new System.EventHandler(this.dataGridViewReport_SelectionChanged);
            // 
            // ColumnSapItemNo
            // 
            this.ColumnSapItemNo.DataPropertyName = "SapItemNo";
            this.ColumnSapItemNo.HeaderText = "SapItemNo";
            this.ColumnSapItemNo.Name = "ColumnSapItemNo";
            this.ColumnSapItemNo.ReadOnly = true;
            this.ColumnSapItemNo.Visible = false;
            this.ColumnSapItemNo.Width = 109;
            // 
            // ColumnPlant
            // 
            this.ColumnPlant.DataPropertyName = "Plant";
            this.ColumnPlant.HeaderText = "公司";
            this.ColumnPlant.Name = "ColumnPlant";
            this.ColumnPlant.ReadOnly = true;
            this.ColumnPlant.Width = 62;
            // 
            // ColumnSLocation
            // 
            this.ColumnSLocation.DataPropertyName = "SLocation";
            this.ColumnSLocation.HeaderText = "存储位置";
            this.ColumnSLocation.Name = "ColumnSLocation";
            this.ColumnSLocation.ReadOnly = true;
            this.ColumnSLocation.Width = 90;
            // 
            // ColumnSubPlant
            // 
            this.ColumnSubPlant.DataPropertyName = "SubPlant";
            this.ColumnSubPlant.HeaderText = "工厂";
            this.ColumnSubPlant.Name = "ColumnSubPlant";
            this.ColumnSubPlant.ReadOnly = true;
            this.ColumnSubPlant.Width = 62;
            // 
            // ColumnMaterial
            // 
            this.ColumnMaterial.DataPropertyName = "Material";
            this.ColumnMaterial.HeaderText = "物料号";
            this.ColumnMaterial.Name = "ColumnMaterial";
            this.ColumnMaterial.ReadOnly = true;
            this.ColumnMaterial.Width = 76;
            // 
            // ColumnBNumber
            // 
            this.ColumnBNumber.DataPropertyName = "BNumber";
            this.ColumnBNumber.HeaderText = "批次号";
            this.ColumnBNumber.Name = "ColumnBNumber";
            this.ColumnBNumber.ReadOnly = true;
            this.ColumnBNumber.Width = 76;
            // 
            // ColumnMDesc
            // 
            this.ColumnMDesc.DataPropertyName = "MDesc";
            this.ColumnMDesc.HeaderText = "货物名称";
            this.ColumnMDesc.Name = "ColumnMDesc";
            this.ColumnMDesc.ReadOnly = true;
            this.ColumnMDesc.Width = 90;
            // 
            // ColumnUNIT
            // 
            this.ColumnUNIT.DataPropertyName = "UNIT";
            this.ColumnUNIT.HeaderText = "单位";
            this.ColumnUNIT.Name = "ColumnUNIT";
            this.ColumnUNIT.ReadOnly = true;
            this.ColumnUNIT.Width = 62;
            // 
            // ColumnSPEC
            // 
            this.ColumnSPEC.DataPropertyName = "SPEC";
            this.ColumnSPEC.HeaderText = "规格";
            this.ColumnSPEC.Name = "ColumnSPEC";
            this.ColumnSPEC.ReadOnly = true;
            this.ColumnSPEC.Width = 62;
            // 
            // ColumnSapCount
            // 
            this.ColumnSapCount.DataPropertyName = "SapCount";
            this.ColumnSapCount.HeaderText = "理论库存";
            this.ColumnSapCount.Name = "ColumnSapCount";
            this.ColumnSapCount.ReadOnly = true;
            this.ColumnSapCount.Width = 90;
            // 
            // ColumnSTCount
            // 
            this.ColumnSTCount.DataPropertyName = "STCount";
            this.ColumnSTCount.HeaderText = "实际库存";
            this.ColumnSTCount.Name = "ColumnSTCount";
            this.ColumnSTCount.ReadOnly = true;
            this.ColumnSTCount.Width = 90;
            // 
            // ColumnSapBin1
            // 
            this.ColumnSapBin1.DataPropertyName = "SapBin1";
            this.ColumnSapBin1.HeaderText = "理论货位①";
            this.ColumnSapBin1.Name = "ColumnSapBin1";
            this.ColumnSapBin1.ReadOnly = true;
            this.ColumnSapBin1.Width = 104;
            // 
            // ColumnSapBinCount1
            // 
            this.ColumnSapBinCount1.DataPropertyName = "SapBinCount1";
            this.ColumnSapBinCount1.HeaderText = "理论数量1";
            this.ColumnSapBinCount1.Name = "ColumnSapBinCount1";
            this.ColumnSapBinCount1.ReadOnly = true;
            this.ColumnSapBinCount1.Width = 98;
            // 
            // ColumnSapBin2
            // 
            this.ColumnSapBin2.DataPropertyName = "SapBin2";
            this.ColumnSapBin2.HeaderText = "理论货位②";
            this.ColumnSapBin2.Name = "ColumnSapBin2";
            this.ColumnSapBin2.ReadOnly = true;
            this.ColumnSapBin2.Width = 104;
            // 
            // ColumnSapBinCount2
            // 
            this.ColumnSapBinCount2.DataPropertyName = "SapBinCount2";
            this.ColumnSapBinCount2.HeaderText = "理论数量2";
            this.ColumnSapBinCount2.Name = "ColumnSapBinCount2";
            this.ColumnSapBinCount2.ReadOnly = true;
            this.ColumnSapBinCount2.Width = 98;
            // 
            // ColumnSapBin3
            // 
            this.ColumnSapBin3.DataPropertyName = "SapBin3";
            this.ColumnSapBin3.HeaderText = "理论货位③";
            this.ColumnSapBin3.Name = "ColumnSapBin3";
            this.ColumnSapBin3.ReadOnly = true;
            this.ColumnSapBin3.Width = 104;
            // 
            // ColumnSapBinCount3
            // 
            this.ColumnSapBinCount3.DataPropertyName = "SapBinCount3";
            this.ColumnSapBinCount3.HeaderText = "理论数量3";
            this.ColumnSapBinCount3.Name = "ColumnSapBinCount3";
            this.ColumnSapBinCount3.ReadOnly = true;
            this.ColumnSapBinCount3.Width = 98;
            // 
            // ColumnSTBin1
            // 
            this.ColumnSTBin1.DataPropertyName = "STBin1";
            this.ColumnSTBin1.HeaderText = "实际货位1";
            this.ColumnSTBin1.Name = "ColumnSTBin1";
            this.ColumnSTBin1.ReadOnly = true;
            this.ColumnSTBin1.Width = 98;
            // 
            // ColumnSTBinCount1
            // 
            this.ColumnSTBinCount1.DataPropertyName = "STBinCount1";
            this.ColumnSTBinCount1.HeaderText = "实际数量1";
            this.ColumnSTBinCount1.Name = "ColumnSTBinCount1";
            this.ColumnSTBinCount1.ReadOnly = true;
            this.ColumnSTBinCount1.Width = 98;
            // 
            // ColumnSTBin2
            // 
            this.ColumnSTBin2.DataPropertyName = "STBin2";
            this.ColumnSTBin2.HeaderText = "实际货位2";
            this.ColumnSTBin2.Name = "ColumnSTBin2";
            this.ColumnSTBin2.ReadOnly = true;
            this.ColumnSTBin2.Width = 98;
            // 
            // ColumnSTBinCount2
            // 
            this.ColumnSTBinCount2.DataPropertyName = "STBinCount2";
            this.ColumnSTBinCount2.HeaderText = "实际数量2";
            this.ColumnSTBinCount2.Name = "ColumnSTBinCount2";
            this.ColumnSTBinCount2.ReadOnly = true;
            this.ColumnSTBinCount2.Width = 98;
            // 
            // ColumnSTBin3
            // 
            this.ColumnSTBin3.DataPropertyName = "STBin3";
            this.ColumnSTBin3.HeaderText = "实际货位3";
            this.ColumnSTBin3.Name = "ColumnSTBin3";
            this.ColumnSTBin3.ReadOnly = true;
            this.ColumnSTBin3.Width = 98;
            // 
            // ColumnSTBinCount3
            // 
            this.ColumnSTBinCount3.DataPropertyName = "STBinCount3";
            this.ColumnSTBinCount3.HeaderText = "实际数量3";
            this.ColumnSTBinCount3.Name = "ColumnSTBinCount3";
            this.ColumnSTBinCount3.ReadOnly = true;
            this.ColumnSTBinCount3.Width = 98;
            // 
            // ColumnOperatorUser
            // 
            this.ColumnOperatorUser.DataPropertyName = "OperatorUser";
            this.ColumnOperatorUser.HeaderText = "盘点人";
            this.ColumnOperatorUser.Name = "ColumnOperatorUser";
            this.ColumnOperatorUser.ReadOnly = true;
            this.ColumnOperatorUser.Width = 76;
            // 
            // ColumnOperatorDateTime
            // 
            this.ColumnOperatorDateTime.DataPropertyName = "OperatorDateTime";
            this.ColumnOperatorDateTime.HeaderText = "盘点日期";
            this.ColumnOperatorDateTime.Name = "ColumnOperatorDateTime";
            this.ColumnOperatorDateTime.ReadOnly = true;
            this.ColumnOperatorDateTime.Width = 90;
            // 
            // ColumnCausation
            // 
            this.ColumnCausation.DataPropertyName = "Causation";
            this.ColumnCausation.HeaderText = "差异原因";
            this.ColumnCausation.Name = "ColumnCausation";
            this.ColumnCausation.ReadOnly = true;
            this.ColumnCausation.Visible = false;
            this.ColumnCausation.Width = 90;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBoxDiff);
            this.groupBox2.Controls.Add(this.comboBoxOperatorUser);
            this.groupBox2.Controls.Add(this.textBoxBNumber);
            this.groupBox2.Controls.Add(this.textBoxMaterial);
            this.groupBox2.Controls.Add(this.comboBoxPlant);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBoxSLocation);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(956, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "盘存信息检索";
            // 
            // checkBoxDiff
            // 
            this.checkBoxDiff.AutoSize = true;
            this.checkBoxDiff.Location = new System.Drawing.Point(483, 61);
            this.checkBoxDiff.Name = "checkBoxDiff";
            this.checkBoxDiff.Size = new System.Drawing.Size(84, 24);
            this.checkBoxDiff.TabIndex = 60;
            this.checkBoxDiff.Text = "存在差异";
            this.checkBoxDiff.UseVisualStyleBackColor = true;
            this.checkBoxDiff.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // comboBoxOperatorUser
            // 
            this.comboBoxOperatorUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperatorUser.FormattingEnabled = true;
            this.comboBoxOperatorUser.Location = new System.Drawing.Point(568, 25);
            this.comboBoxOperatorUser.Name = "comboBoxOperatorUser";
            this.comboBoxOperatorUser.Size = new System.Drawing.Size(150, 28);
            this.comboBoxOperatorUser.TabIndex = 50;
            this.comboBoxOperatorUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxBNumber
            // 
            this.textBoxBNumber.Location = new System.Drawing.Point(327, 59);
            this.textBoxBNumber.Name = "textBoxBNumber";
            this.textBoxBNumber.Size = new System.Drawing.Size(150, 26);
            this.textBoxBNumber.TabIndex = 40;
            this.textBoxBNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(86, 59);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.Size = new System.Drawing.Size(150, 26);
            this.textBoxMaterial.TabIndex = 30;
            this.textBoxMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(86, 25);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(150, 28);
            this.comboBoxPlant.TabIndex = 10;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            this.comboBoxPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "公司：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(327, 25);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(150, 28);
            this.comboBoxSLocation.TabIndex = 20;
            this.comboBoxSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "存储地点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "批次号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "盘点人员：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "物料号：";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(848, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 70;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnMod
            // 
            this.btnMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(868, 598);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 330;
            this.btnMod.Text = "修改数量";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 608);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "盈亏原因：";
            // 
            // textBoxCausation
            // 
            this.textBoxCausation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCausation.Location = new System.Drawing.Point(457, 605);
            this.textBoxCausation.Name = "textBoxCausation";
            this.textBoxCausation.Size = new System.Drawing.Size(299, 26);
            this.textBoxCausation.TabIndex = 310;
            // 
            // btnReason
            // 
            this.btnReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReason.Enabled = false;
            this.btnReason.Location = new System.Drawing.Point(762, 598);
            this.btnReason.Name = "btnReason";
            this.btnReason.Size = new System.Drawing.Size(100, 40);
            this.btnReason.TabIndex = 320;
            this.btnReason.Text = "修改原因";
            this.btnReason.UseVisualStyleBackColor = true;
            this.btnReason.Click += new System.EventHandler(this.btnReason_Click);
            // 
            // 盘点报表
            // 
            this.ClientSize = new System.Drawing.Size(980, 650);
            this.Controls.Add(this.btnReason);
            this.Controls.Add(this.textBoxCausation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewReport);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(980, 650);
            this.Name = "盘点报表";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盘点报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 盘点报表(UserInfo userItem, ArrayList userRoles, string stSerial, string STStatus)
        {
            DataTable table;
            string str;
            this.userItem = null;
            this.userRoles = null;
            this.stSerial = string.Empty;
            dtPlantList = null;
            dtStoreLocusList = null;
            dtReport = null;
            this.STStatus = "5";
            buttonExcel = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.stSerial = stSerial;
            this.STStatus = STStatus;
            dataGridViewReport.AutoGenerateColumns = false;
            DBOperate.GetSTItemDetail(stSerial, out table, out str);

            if (userItem.isAdmin)
            {
                comboBoxOperatorUser.Items.Add("无");

                if (CommonFunction.IfHasData(table))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        comboBoxOperatorUser.Items.Add(row["OperatorUser"].ToString());
                    }
                }

                comboBoxOperatorUser.SelectedIndex = 0;
            }
            else
            {
                comboBoxOperatorUser.Items.Add(this.userItem.userID);
                comboBoxOperatorUser.SelectedIndex = 0;
                comboBoxOperatorUser.Enabled = false;
            }

            dtPlantList = DBOperate.GetPlantList(string.Empty);
            dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, string.Empty);
            comboBoxSLocation.Items.Add("无");
            comboBoxSLocation.SelectedIndex = 0;
            comboBoxPlant.Items.Add("无");

            if (CommonFunction.IfHasData(dtPlantList))
            {
                foreach (DataRow row2 in dtPlantList.Rows)
                {
                    comboBoxPlant.Items.Add(row2["PlantID"].ToString());
                }
            }

            comboBoxPlant.SelectedIndex = 0;
            buttonExcel = new ToExcelButton();
            Controls.Add(buttonExcel);
            buttonExcel.Location = new Point(0x327, 0x238);
            buttonExcel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            buttonExcel.Size = new Size(0x4b, 0x17);
            buttonExcel.TableName = "collect";
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            ArrayList reportItem = new ArrayList();
            DataGridViewRow row = dataGridViewReport.SelectedRows[0];
            reportItem.Add(row.Cells["ColumnSapBin1"].Value);
            reportItem.Add(row.Cells["ColumnSapBinCount1"].Value);
            reportItem.Add(row.Cells["ColumnSapBin2"].Value);
            reportItem.Add(row.Cells["ColumnSapBinCount2"].Value);
            reportItem.Add(row.Cells["ColumnSapBin3"].Value);
            reportItem.Add(row.Cells["ColumnSapBinCount3"].Value);
            reportItem.Add(row.Cells["ColumnSTBin1"].Value);
            reportItem.Add(row.Cells["ColumnSTBinCount1"].Value);
            reportItem.Add(row.Cells["ColumnSTBin2"].Value);
            reportItem.Add(row.Cells["ColumnSTBinCount2"].Value);
            reportItem.Add(row.Cells["ColumnSTBin3"].Value);
            reportItem.Add(row.Cells["ColumnSTBinCount3"].Value);
            reportItem.Add(row.Cells["ColumnSapItemNo"].Value);
            盘点报表明细信息 盘点报表明细信息 = new 盘点报表明细信息(this.userItem, this.userRoles, reportItem);

            if (盘点报表明细信息.ShowDialog() == DialogResult.OK)
            {
                row.Cells["ColumnSTBin1"].Value = 盘点报表明细信息.ReportItem[6];
                row.Cells["ColumnSTBinCount1"].Value = 盘点报表明细信息.ReportItem[7];
                row.Cells["ColumnSTBin2"].Value = 盘点报表明细信息.ReportItem[8];
                row.Cells["ColumnSTBinCount2"].Value = 盘点报表明细信息.ReportItem[9];
                row.Cells["ColumnSTBin3"].Value = 盘点报表明细信息.ReportItem[10];
                row.Cells["ColumnSTBinCount3"].Value = 盘点报表明细信息.ReportItem[11];
                row.Cells["ColumnSTCount"].Value = Convert.ToString((decimal)((Convert.ToDecimal(盘点报表明细信息.ReportItem[7]) + Convert.ToDecimal(盘点报表明细信息.ReportItem[9])) + Convert.ToDecimal(盘点报表明细信息.ReportItem[11])));

                if (盘点报表明细信息.IfTurnRight)
                {
                    row.Cells["ColumnCausation"].Value = string.Empty;
                }

                dataGridViewReport_SelectionChanged(null, null);
            }
        }

        private void btnReason_Click(object sender, EventArgs e)
        {
            if (!textBoxCausation.Text.Trim().Equals(dataGridViewReport.SelectedRows[0].Cells["ColumnCausation"].Value.ToString()))
            {
                if (DBOperate.ModReportCausation(dataGridViewReport.SelectedRows[0].Cells["ColumnSapItemNo"].Value.ToString(), textBoxCausation.Text.Trim()) != -1)
                {
                    CommonFunction.Sys_MsgBox("盘点汇总条目 " + dataGridViewReport.SelectedRows[0].Cells["ColumnSapItemNo"].Value.ToString() + " 盈亏原因修改完毕");
                    btnSelect.PerformClick();
                }
                else
                {
                    CommonFunction.Sys_MsgBox("盘点汇总条目 " + dataGridViewReport.SelectedRows[0].Cells["ColumnSapItemNo"].Value.ToString() + " 盈亏原因修改失败，请重新尝试或联系管理员确认");
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ArrayList stReportList = new ArrayList();
            stReportList.Add(stSerial);

            if (!comboBoxPlant.Text.Equals("无"))
            {
                stReportList.Add(comboBoxPlant.Text);
            }
            else
            {
                stReportList.Add("");
            }

            if (!comboBoxSLocation.Text.Equals("无"))
            {
                stReportList.Add(comboBoxSLocation.Text);
            }
            else
            {
                stReportList.Add("");
            }

            if (!textBoxMaterial.Text.Equals(string.Empty))
            {
                stReportList.Add(textBoxMaterial.Text);
            }
            else
            {
                stReportList.Add("");
            }

            if (!textBoxBNumber.Text.Equals(string.Empty))
            {
                stReportList.Add(textBoxBNumber.Text);
            }
            else
            {
                stReportList.Add("");
            }

            if (!comboBoxOperatorUser.Text.Equals("无"))
            {
                stReportList.Add(comboBoxOperatorUser.Text);
            }
            else
            {
                stReportList.Add("");
            }

            stReportList.Add(checkBoxDiff.Checked ? "1" : string.Empty);
            dtReport = DBOperate.SelectReport(stReportList);
            dataGridViewReport.DataSource = dtReport;
            dtExcel = dtReport.Copy();

            for (int i = 0; i < (dtExcel.Columns.Count - 2); i++)
            {
                dtExcel.Columns[i].ColumnName = dataGridViewReport.Columns[i].HeaderText;
            }

            dtExcel.Columns[0].ColumnName = "Sap条目号";
            dtExcel.Columns["STSerial"].ColumnName = "盘点单号";
            dtExcel.Columns["Causation"].ColumnName = "差异原因";
            DataSet set = new DataSet();
            set.Tables.Add(dtExcel);
            buttonExcel.Source = set;
            buttonExcel.TableName = set.Tables[0].TableName;
            Hashtable hs = new Hashtable();

            foreach (DataColumn column in dtReport.Columns)
            {
                hs.Add(column.ToString(), column.ToString());
            }

            buttonExcel.SetMapping(hs);
        }

        private void comboBoxPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSLocation.Items.Clear();
            comboBoxSLocation.Items.Add("无");

            foreach (DataRow row in dtStoreLocusList.Select("PlantID='" + comboBoxPlant.Text + "'"))
            {
                comboBoxSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            comboBoxSLocation.SelectedIndex = 0;
        }

        private void dataGridViewReport_SelectionChanged(object sender, EventArgs e)
        {
            if (!STStatus.Equals("5"))
            {
                if ((dataGridViewReport.Rows != null) && (dataGridViewReport.SelectedRows.Count != 0))
                {
                    btnMod.Enabled = true;
                    textBoxCausation.Text = dataGridViewReport.SelectedRows[0].Cells["ColumnCausation"].Value.ToString();

                    if (!dataGridViewReport.SelectedRows[0].Cells["ColumnSapCount"].Value.ToString().Equals(dataGridViewReport.SelectedRows[0].Cells["ColumnSTCount"].Value.ToString()))
                    {
                        btnReason.Enabled = true;
                    }
                    else
                    {
                        btnReason.Enabled = false;
                    }
                }
                else
                {
                    btnReason.Enabled = false;
                    btnMod.Enabled = false;
                }
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