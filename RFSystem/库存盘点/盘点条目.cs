using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BL;
using System.Collections;
using RFSystem.CommonClass;

namespace RFSystem
{
    public class 盘点条目 : Form
    {
        // Fields
        private Button btnBlankOut;
        private Button btnMod;
        private Button btnSelect;
        private CheckBox checkBoxBlankOut;
        private CheckBox checkBoxUnCheck;
        private DataGridViewTextBoxColumn ColumnBarCode;
        private DataGridViewTextBoxColumn ColumnBin;
        private DataGridViewTextBoxColumn ColumnBinCount;
        private DataGridViewTextBoxColumn ColumnBNumber;
        private DataGridViewTextBoxColumn ColumnItemNo;
        private DataGridViewTextBoxColumn ColumnMaterial;
        private DataGridViewTextBoxColumn ColumnOperatorDateTime;
        private DataGridViewTextBoxColumn ColumnOperatorUser;
        private DataGridViewTextBoxColumn ColumnPlant;
        private DataGridViewTextBoxColumn ColumnSLocation;
        private ComboBox comboBoxOperatorUser;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private DataGridView dataGridViewSTOrigin;
        private DataTable dtPlantList;
        private DataTable dtStoreLocusList;
        private DataTable dtSTOrigin;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private string stSerial;
        private TextBox textBoxBarCode;
        private TextBox textBoxBin;
        private TextBox textBoxBNumber;
        private TextBox textBoxMaterial;
        private UserInfo userItem;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.dataGridViewSTOrigin = new System.Windows.Forms.DataGridView();
            this.ColumnItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBinCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxBlankOut = new System.Windows.Forms.CheckBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.textBoxBNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxOperatorUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxUnCheck = new System.Windows.Forms.CheckBox();
            this.btnBlankOut = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSTOrigin)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSTOrigin
            // 
            this.dataGridViewSTOrigin.AllowUserToAddRows = false;
            this.dataGridViewSTOrigin.AllowUserToResizeRows = false;
            this.dataGridViewSTOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSTOrigin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSTOrigin.ColumnHeadersHeight = 30;
            this.dataGridViewSTOrigin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSTOrigin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItemNo,
            this.ColumnPlant,
            this.ColumnSLocation,
            this.ColumnMaterial,
            this.ColumnBNumber,
            this.ColumnBin,
            this.ColumnBinCount,
            this.ColumnBarCode,
            this.ColumnOperatorUser,
            this.ColumnOperatorDateTime});
            this.dataGridViewSTOrigin.Location = new System.Drawing.Point(12, 148);
            this.dataGridViewSTOrigin.MultiSelect = false;
            this.dataGridViewSTOrigin.Name = "dataGridViewSTOrigin";
            this.dataGridViewSTOrigin.ReadOnly = true;
            this.dataGridViewSTOrigin.RowHeadersVisible = false;
            this.dataGridViewSTOrigin.RowTemplate.Height = 23;
            this.dataGridViewSTOrigin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSTOrigin.Size = new System.Drawing.Size(1055, 444);
            this.dataGridViewSTOrigin.TabIndex = 13;
            this.dataGridViewSTOrigin.SelectionChanged += new System.EventHandler(this.dataGridViewSTOrigin_SelectionChanged);
            // 
            // ColumnItemNo
            // 
            this.ColumnItemNo.DataPropertyName = "ItemNo";
            this.ColumnItemNo.HeaderText = "盘点条目编号";
            this.ColumnItemNo.Name = "ColumnItemNo";
            this.ColumnItemNo.ReadOnly = true;
            this.ColumnItemNo.Width = 118;
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
            this.ColumnSLocation.HeaderText = "存储地点";
            this.ColumnSLocation.Name = "ColumnSLocation";
            this.ColumnSLocation.ReadOnly = true;
            this.ColumnSLocation.Width = 90;
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
            // ColumnBin
            // 
            this.ColumnBin.DataPropertyName = "Bin";
            this.ColumnBin.HeaderText = "货位";
            this.ColumnBin.Name = "ColumnBin";
            this.ColumnBin.ReadOnly = true;
            this.ColumnBin.Width = 62;
            // 
            // ColumnBinCount
            // 
            this.ColumnBinCount.DataPropertyName = "BinCount";
            this.ColumnBinCount.HeaderText = "实际库存";
            this.ColumnBinCount.Name = "ColumnBinCount";
            this.ColumnBinCount.ReadOnly = true;
            this.ColumnBinCount.Width = 90;
            // 
            // ColumnBarCode
            // 
            this.ColumnBarCode.DataPropertyName = "BarCode";
            this.ColumnBarCode.HeaderText = "条码号";
            this.ColumnBarCode.Name = "ColumnBarCode";
            this.ColumnBarCode.ReadOnly = true;
            this.ColumnBarCode.Width = 76;
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
            this.ColumnOperatorDateTime.HeaderText = "盘点日时";
            this.ColumnOperatorDateTime.Name = "ColumnOperatorDateTime";
            this.ColumnOperatorDateTime.ReadOnly = true;
            this.ColumnOperatorDateTime.Width = 90;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxBarCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkBoxBlankOut);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.textBoxBin);
            this.groupBox2.Controls.Add(this.textBoxBNumber);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxOperatorUser);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxMaterial);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBoxPlant);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBoxSLocation);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.checkBoxUnCheck);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1055, 130);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "盘存信息检索";
            // 
            // textBoxBarCode
            // 
            this.textBoxBarCode.Location = new System.Drawing.Point(84, 59);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.Size = new System.Drawing.Size(150, 26);
            this.textBoxBarCode.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "条码号：";
            // 
            // checkBoxBlankOut
            // 
            this.checkBoxBlankOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBlankOut.AutoSize = true;
            this.checkBoxBlankOut.Location = new System.Drawing.Point(802, 60);
            this.checkBoxBlankOut.Name = "checkBoxBlankOut";
            this.checkBoxBlankOut.Size = new System.Drawing.Size(98, 24);
            this.checkBoxBlankOut.TabIndex = 41;
            this.checkBoxBlankOut.Text = "已作废条目";
            this.checkBoxBlankOut.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(949, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 40;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(538, 58);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(150, 26);
            this.textBoxBin.TabIndex = 38;
            // 
            // textBoxBNumber
            // 
            this.textBoxBNumber.Location = new System.Drawing.Point(751, 25);
            this.textBoxBNumber.Name = "textBoxBNumber";
            this.textBoxBNumber.Size = new System.Drawing.Size(150, 26);
            this.textBoxBNumber.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(694, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "批次：";
            // 
            // comboBoxOperatorUser
            // 
            this.comboBoxOperatorUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperatorUser.FormattingEnabled = true;
            this.comboBoxOperatorUser.Location = new System.Drawing.Point(325, 59);
            this.comboBoxOperatorUser.Name = "comboBoxOperatorUser";
            this.comboBoxOperatorUser.Size = new System.Drawing.Size(150, 28);
            this.comboBoxOperatorUser.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "盘点员：";
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(538, 24);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.Size = new System.Drawing.Size(150, 26);
            this.textBoxMaterial.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(481, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "物料：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(481, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "货位：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(84, 25);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(150, 28);
            this.comboBoxPlant.TabIndex = 29;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "公司：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(325, 25);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(150, 28);
            this.comboBoxSLocation.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "存储地点：";
            // 
            // checkBoxUnCheck
            // 
            this.checkBoxUnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxUnCheck.AutoSize = true;
            this.checkBoxUnCheck.Location = new System.Drawing.Point(698, 60);
            this.checkBoxUnCheck.Name = "checkBoxUnCheck";
            this.checkBoxUnCheck.Size = new System.Drawing.Size(98, 24);
            this.checkBoxUnCheck.TabIndex = 24;
            this.checkBoxUnCheck.Text = "未盘点货物";
            this.checkBoxUnCheck.UseVisualStyleBackColor = true;
            // 
            // btnBlankOut
            // 
            this.btnBlankOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlankOut.Enabled = false;
            this.btnBlankOut.Location = new System.Drawing.Point(967, 598);
            this.btnBlankOut.Name = "btnBlankOut";
            this.btnBlankOut.Size = new System.Drawing.Size(100, 40);
            this.btnBlankOut.TabIndex = 31;
            this.btnBlankOut.Text = "作废";
            this.btnBlankOut.UseVisualStyleBackColor = true;
            this.btnBlankOut.Click += new System.EventHandler(this.btnBlankOut_Click);
            // 
            // btnMod
            // 
            this.btnMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(861, 598);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 32;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // 盘点条目
            // 
            this.ClientSize = new System.Drawing.Size(1079, 650);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnBlankOut);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewSTOrigin);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(980, 650);
            this.Name = "盘点条目";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盘点条目";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSTOrigin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        // Methods
        public 盘点条目(UserInfo userItem, ArrayList userRoles, string stSerial)
        {
            DataTable table;
            string str;
            this.userItem = null;
            this.userRoles = null;
            this.stSerial = string.Empty;
            dtSTOrigin = null;
            dtPlantList = null;
            dtStoreLocusList = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.stSerial = stSerial;
            dataGridViewSTOrigin.AutoGenerateColumns = false;
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
        }

        private void btnBlankOut_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("继续本操作将作废被选择条目，是否继续？") && (DBOperate.BlankOutSTOrigin(Convert.ToInt32(this.dataGridViewSTOrigin.SelectedRows[0].Cells["ColumnItemNo"].Value)) != -1))
            {
                CommonFunction.Sys_MsgBox("条目信息作废成功");
                btnSelect.PerformClick();
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            ArrayList stOriginItem = new ArrayList();

            foreach (DataGridViewCell cell in dataGridViewSTOrigin.SelectedRows[0].Cells)
            {
                stOriginItem.Add(cell.Value);
            }

            盘点条目明细信息 盘点条目明细信息 = new 盘点条目明细信息(stOriginItem);

            if (盘点条目明细信息.ShowDialog() == DialogResult.OK)
            {
                DataRow row = dtSTOrigin.Select("ItemNo=" + dataGridViewSTOrigin.SelectedRows[0].Cells["ColumnItemNo"].Value.ToString())[0];
                row["SLocation"] = 盘点条目明细信息.STOriginItem[2];
                row["Bin"] = 盘点条目明细信息.STOriginItem[5];
                row["BinCount"] = 盘点条目明细信息.STOriginItem[6];
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dataGridViewSTOrigin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ArrayList stOriginList = new ArrayList();
            stOriginList.Add(stSerial);

            if (!comboBoxPlant.Text.Equals("无"))
            {
                stOriginList.Add(comboBoxPlant.Text);
            }
            else
            {
                stOriginList.Add("");
            }

            if (!comboBoxSLocation.Text.Equals("无"))
            {
                stOriginList.Add(comboBoxSLocation.Text);
            }
            else
            {
                stOriginList.Add("");
            }

            if (!textBoxBin.Text.Equals(string.Empty))
            {
                stOriginList.Add(textBoxBin.Text);
            }
            else
            {
                stOriginList.Add("");
            }

            if (!textBoxMaterial.Text.Equals(string.Empty))
            {
                stOriginList.Add(textBoxMaterial.Text);
            }
            else
            {
                stOriginList.Add("");
            }

            if (!textBoxBNumber.Text.Equals(string.Empty))
            {
                stOriginList.Add(textBoxBNumber.Text);
            }
            else
            {
                stOriginList.Add("");
            }

            if (!textBoxBarCode.Text.Equals(string.Empty))
            {
                stOriginList.Add(textBoxBarCode.Text);
            }
            else
            {
                stOriginList.Add("");
            }

            if (!comboBoxOperatorUser.Text.Equals("无"))
            {
                stOriginList.Add(comboBoxOperatorUser.Text);
            }
            else
            {
                stOriginList.Add("");
            }

            stOriginList.Add(checkBoxBlankOut.Checked ? "0" : "1");
            dtSTOrigin = DBOperate.STOrigin(stOriginList);
            dataGridViewSTOrigin.DataSource = dtSTOrigin;
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

        private void dataGridViewSTOrigin_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewSTOrigin.Rows != null) && (dataGridViewSTOrigin.SelectedRows.Count != 0))
            {
                btnMod.Enabled = true;
                btnBlankOut.Enabled = true;
            }
            else
            {
                btnMod.Enabled = false;
                btnBlankOut.Enabled = false;
            }
        }
    }
}
