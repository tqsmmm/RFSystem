using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace RFSystem
{
    public class 盘点对照 : Form
    {
        // Fields
        private Button btnAdjust;
        private Button btnSelect;
        private ComboBox comboBoxOperatorUser;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private DataGridView dataGridViewSTCompare;
        private DataTable dtCompare;
        private DataTable dtPlantList;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox2;
        private Label label1;
        private Label label11;
        private Label label16;
        private Label label3;
        private Label label6;
        private Label label7;
        private RadioButton radioButtonBinDif;
        private RadioButton radioButtonNoSap;
        private RadioButton radioButtonNoST;
        private RadioButton radioButtonOperatorDif;
        private RadioButton radioButtonSumErr;
        private string stSerial;
        private TextBox textBoxBNumber;
        private TextBox textBoxMaterial;
        private TextBox textBoxMDesc;
        private UserInfo userItem;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonNoSap = new System.Windows.Forms.RadioButton();
            this.radioButtonNoST = new System.Windows.Forms.RadioButton();
            this.radioButtonOperatorDif = new System.Windows.Forms.RadioButton();
            this.radioButtonBinDif = new System.Windows.Forms.RadioButton();
            this.radioButtonSumErr = new System.Windows.Forms.RadioButton();
            this.comboBoxOperatorUser = new System.Windows.Forms.ComboBox();
            this.textBoxBNumber = new System.Windows.Forms.TextBox();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.textBoxMDesc = new System.Windows.Forms.TextBox();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataGridViewSTCompare = new System.Windows.Forms.DataGridView();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSTCompare)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButtonNoSap);
            this.groupBox2.Controls.Add(this.radioButtonNoST);
            this.groupBox2.Controls.Add(this.radioButtonOperatorDif);
            this.groupBox2.Controls.Add(this.radioButtonBinDif);
            this.groupBox2.Controls.Add(this.radioButtonSumErr);
            this.groupBox2.Controls.Add(this.comboBoxOperatorUser);
            this.groupBox2.Controls.Add(this.textBoxBNumber);
            this.groupBox2.Controls.Add(this.textBoxMaterial);
            this.groupBox2.Controls.Add(this.textBoxMDesc);
            this.groupBox2.Controls.Add(this.comboBoxPlant);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBoxSLocation);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 130);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "盘存信息检索";
            // 
            // radioButtonNoSap
            // 
            this.radioButtonNoSap.AutoSize = true;
            this.radioButtonNoSap.Location = new System.Drawing.Point(330, 25);
            this.radioButtonNoSap.Name = "radioButtonNoSap";
            this.radioButtonNoSap.Size = new System.Drawing.Size(167, 24);
            this.radioButtonNoSap.TabIndex = 52;
            this.radioButtonNoSap.Text = "理论库存不存在的货物";
            this.radioButtonNoSap.UseVisualStyleBackColor = true;
            // 
            // radioButtonNoST
            // 
            this.radioButtonNoST.AutoSize = true;
            this.radioButtonNoST.Location = new System.Drawing.Point(157, 25);
            this.radioButtonNoST.Name = "radioButtonNoST";
            this.radioButtonNoST.Size = new System.Drawing.Size(167, 24);
            this.radioButtonNoST.TabIndex = 51;
            this.radioButtonNoST.Text = "实际库存不存在的货物";
            this.radioButtonNoST.UseVisualStyleBackColor = true;
            // 
            // radioButtonOperatorDif
            // 
            this.radioButtonOperatorDif.AutoSize = true;
            this.radioButtonOperatorDif.Location = new System.Drawing.Point(648, 25);
            this.radioButtonOperatorDif.Name = "radioButtonOperatorDif";
            this.radioButtonOperatorDif.Size = new System.Drawing.Size(181, 24);
            this.radioButtonOperatorDif.TabIndex = 49;
            this.radioButtonOperatorDif.Text = "盘点人与保管员存在差异";
            this.radioButtonOperatorDif.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinDif
            // 
            this.radioButtonBinDif.AutoSize = true;
            this.radioButtonBinDif.Location = new System.Drawing.Point(503, 25);
            this.radioButtonBinDif.Name = "radioButtonBinDif";
            this.radioButtonBinDif.Size = new System.Drawing.Size(139, 24);
            this.radioButtonBinDif.TabIndex = 48;
            this.radioButtonBinDif.Text = "储位数量存在差异";
            this.radioButtonBinDif.UseVisualStyleBackColor = true;
            // 
            // radioButtonSumErr
            // 
            this.radioButtonSumErr.AutoSize = true;
            this.radioButtonSumErr.Checked = true;
            this.radioButtonSumErr.Location = new System.Drawing.Point(26, 25);
            this.radioButtonSumErr.Name = "radioButtonSumErr";
            this.radioButtonSumErr.Size = new System.Drawing.Size(125, 24);
            this.radioButtonSumErr.TabIndex = 47;
            this.radioButtonSumErr.TabStop = true;
            this.radioButtonSumErr.Text = "总数量存在差异";
            this.radioButtonSumErr.UseVisualStyleBackColor = true;
            // 
            // comboBoxOperatorUser
            // 
            this.comboBoxOperatorUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperatorUser.FormattingEnabled = true;
            this.comboBoxOperatorUser.Location = new System.Drawing.Point(575, 57);
            this.comboBoxOperatorUser.Name = "comboBoxOperatorUser";
            this.comboBoxOperatorUser.Size = new System.Drawing.Size(150, 28);
            this.comboBoxOperatorUser.TabIndex = 46;
            // 
            // textBoxBNumber
            // 
            this.textBoxBNumber.Location = new System.Drawing.Point(334, 91);
            this.textBoxBNumber.Name = "textBoxBNumber";
            this.textBoxBNumber.Size = new System.Drawing.Size(150, 26);
            this.textBoxBNumber.TabIndex = 39;
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(93, 91);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.Size = new System.Drawing.Size(150, 26);
            this.textBoxMaterial.TabIndex = 38;
            // 
            // textBoxMDesc
            // 
            this.textBoxMDesc.Location = new System.Drawing.Point(575, 91);
            this.textBoxMDesc.Name = "textBoxMDesc";
            this.textBoxMDesc.Size = new System.Drawing.Size(150, 26);
            this.textBoxMDesc.TabIndex = 37;
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(93, 57);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(150, 28);
            this.comboBoxPlant.TabIndex = 36;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "库存账套：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(334, 57);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(150, 28);
            this.comboBoxSLocation.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "存储地点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "批次号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "保管员：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(842, 84);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "物料号：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(490, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "货物名称：";
            // 
            // dataGridViewSTCompare
            // 
            this.dataGridViewSTCompare.AllowUserToAddRows = false;
            this.dataGridViewSTCompare.AllowUserToResizeRows = false;
            this.dataGridViewSTCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSTCompare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSTCompare.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSTCompare.ColumnHeadersHeight = 30;
            this.dataGridViewSTCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSTCompare.Location = new System.Drawing.Point(12, 148);
            this.dataGridViewSTCompare.MultiSelect = false;
            this.dataGridViewSTCompare.Name = "dataGridViewSTCompare";
            this.dataGridViewSTCompare.ReadOnly = true;
            this.dataGridViewSTCompare.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewSTCompare.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSTCompare.RowTemplate.Height = 23;
            this.dataGridViewSTCompare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSTCompare.Size = new System.Drawing.Size(948, 410);
            this.dataGridViewSTCompare.TabIndex = 300;
            this.dataGridViewSTCompare.SelectionChanged += new System.EventHandler(this.dataGridViewSTCompare_SelectionChanged);
            // 
            // btnAdjust
            // 
            this.btnAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdjust.Enabled = false;
            this.btnAdjust.Location = new System.Drawing.Point(860, 564);
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(100, 40);
            this.btnAdjust.TabIndex = 500;
            this.btnAdjust.Text = "数据调整";
            this.btnAdjust.UseVisualStyleBackColor = true;
            this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);
            // 
            // 盘点对照
            // 
            this.ClientSize = new System.Drawing.Size(972, 616);
            this.Controls.Add(this.btnAdjust);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewSTCompare);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "盘点对照";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盘点对照";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSTCompare)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 盘点对照(UserInfo userItem, ArrayList userRoles, string stSerial)
        {
            DataTable table;
            string str;
            this.userItem = null;
            this.userRoles = null;
            this.stSerial = string.Empty;
            dtPlantList = null;
            dtStoreLocusList = null;
            dtCompare = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.stSerial = stSerial;
            dataGridViewSTCompare.AutoGenerateColumns = true;
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

            dtPlantList = DBOperate.GetPlantList(string.Empty, true);
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

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            ArrayList adjustItem = new ArrayList();
            adjustItem.Add(dataGridViewSTCompare.SelectedRows[0].Cells["盘点号"].Value.ToString());
            adjustItem.Add(dataGridViewSTCompare.SelectedRows[0].Cells["所属库存账套"].Value.ToString());
            adjustItem.Add(dataGridViewSTCompare.SelectedRows[0].Cells["存储地点"].Value.ToString());
            adjustItem.Add(dataGridViewSTCompare.SelectedRows[0].Cells["物料号"].Value.ToString());
            adjustItem.Add(dataGridViewSTCompare.SelectedRows[0].Cells["批次号"].Value.ToString());
            盘点对照明细信息 盘点对照明细信息 = new 盘点对照明细信息(userItem, userRoles, adjustItem);

            if (盘点对照明细信息.ShowDialog() == DialogResult.OK)
            {
                btnSelect.PerformClick();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
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

            if (!textBoxMDesc.Text.Equals(string.Empty))
            {
                stOriginList.Add(textBoxMDesc.Text);
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

            bool flag = false;

            if (radioButtonSumErr.Checked)
            {
                stOriginList.Add(0);
            }
            else if (radioButtonNoST.Checked)
            {
                stOriginList.Add(1);
            }
            else if (radioButtonNoSap.Checked)
            {
                stOriginList.Add(2);
            }
            else if (radioButtonBinDif.Checked)
            {
                flag = true;
                stOriginList.Add(0);
            }
            else if (radioButtonOperatorDif.Checked)
            {
                flag = true;
                stOriginList.Add(1);
            }

            if (flag)
            {
                dtCompare = DBOperate.CompareOther(stOriginList);
                dataGridViewSTCompare.DataSource = dtCompare;
            }
            else
            {
                dtCompare = DBOperate.CompareSum(stOriginList);
                dataGridViewSTCompare.DataSource = dtCompare;
            }
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

        private void dataGridViewSTCompare_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewSTCompare.Rows != null) && (dataGridViewSTCompare.SelectedRows.Count != 0))
            {
                btnAdjust.Enabled = true;
            }
            else
            {
                btnAdjust.Enabled = false;
            }
        }
    }
}
