using System;
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace RFSystem
{
    public class 理论库存信息 : Form
    {
        private Button btnSelect;
        private DataGridViewTextBoxColumn ColumnACount;
        private DataGridViewTextBoxColumn ColumnACount1;
        private DataGridViewTextBoxColumn ColumnACount2;
        private DataGridViewTextBoxColumn ColumnACount3;
        private DataGridViewTextBoxColumn ColumnBin1;
        private DataGridViewTextBoxColumn ColumnBin2;
        private DataGridViewTextBoxColumn ColumnBin3;
        private DataGridViewTextBoxColumn ColumnBNumber;
        private DataGridViewTextBoxColumn ColumnItemNo;
        private DataGridViewTextBoxColumn ColumnMaterial;
        private DataGridViewTextBoxColumn ColumnMDesc;
        private DataGridViewTextBoxColumn ColumnOperatorUser;
        private DataGridViewTextBoxColumn ColumnPlant;
        private DataGridViewTextBoxColumn ColumnSLocation;
        private DataGridViewTextBoxColumn ColumnSPEC;
        private DataGridViewTextBoxColumn ColumnSubPlant;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private ComboBox comboBoxOperatorUser;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private DataGridView dataGridViewSapStockInfo;
        private DataTable dtPlantList;
        private DataTable dtSapStockInfo;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private string stSerial;
        private TextBox textBoxBin;
        private TextBox textBoxBNumber;
        private TextBox textBoxMaterial;
        private TextBox textBoxSubPlant;
        private UserInfo userItem;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.dataGridViewSapStockInfo = new System.Windows.Forms.DataGridView();
            this.ColumnItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnACount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnACount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnACount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnACount3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSubPlant = new System.Windows.Forms.TextBox();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.textBoxBNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxOperatorUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSapStockInfo
            // 
            this.dataGridViewSapStockInfo.AllowUserToAddRows = false;
            this.dataGridViewSapStockInfo.AllowUserToResizeRows = false;
            this.dataGridViewSapStockInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSapStockInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSapStockInfo.ColumnHeadersHeight = 30;
            this.dataGridViewSapStockInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSapStockInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItemNo,
            this.ColumnPlant,
            this.ColumnSLocation,
            this.ColumnMaterial,
            this.ColumnBNumber,
            this.ColumnMDesc,
            this.ColumnSubPlant,
            this.ColumnACount,
            this.ColumnBin1,
            this.ColumnACount1,
            this.ColumnBin2,
            this.ColumnACount2,
            this.ColumnBin3,
            this.ColumnACount3,
            this.ColumnUNIT,
            this.ColumnSPEC,
            this.ColumnOperatorUser});
            this.dataGridViewSapStockInfo.Location = new System.Drawing.Point(12, 118);
            this.dataGridViewSapStockInfo.MultiSelect = false;
            this.dataGridViewSapStockInfo.Name = "dataGridViewSapStockInfo";
            this.dataGridViewSapStockInfo.ReadOnly = true;
            this.dataGridViewSapStockInfo.RowHeadersVisible = false;
            this.dataGridViewSapStockInfo.RowTemplate.Height = 23;
            this.dataGridViewSapStockInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSapStockInfo.Size = new System.Drawing.Size(1135, 486);
            this.dataGridViewSapStockInfo.TabIndex = 300;
            // 
            // ColumnItemNo
            // 
            this.ColumnItemNo.DataPropertyName = "ItemNo";
            this.ColumnItemNo.HeaderText = "盘点条目编号";
            this.ColumnItemNo.Name = "ColumnItemNo";
            this.ColumnItemNo.ReadOnly = true;
            this.ColumnItemNo.Visible = false;
            this.ColumnItemNo.Width = 72;
            // 
            // ColumnPlant
            // 
            this.ColumnPlant.DataPropertyName = "Plant";
            this.ColumnPlant.HeaderText = "库存账套";
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
            // ColumnMDesc
            // 
            this.ColumnMDesc.DataPropertyName = "MDesc";
            this.ColumnMDesc.HeaderText = "货物名称";
            this.ColumnMDesc.Name = "ColumnMDesc";
            this.ColumnMDesc.ReadOnly = true;
            this.ColumnMDesc.Width = 90;
            // 
            // ColumnSubPlant
            // 
            this.ColumnSubPlant.DataPropertyName = "SubPlant";
            this.ColumnSubPlant.HeaderText = "产线部门代码";
            this.ColumnSubPlant.Name = "ColumnSubPlant";
            this.ColumnSubPlant.ReadOnly = true;
            this.ColumnSubPlant.Width = 76;
            // 
            // ColumnACount
            // 
            this.ColumnACount.DataPropertyName = "ACount";
            this.ColumnACount.HeaderText = "理论库存";
            this.ColumnACount.Name = "ColumnACount";
            this.ColumnACount.ReadOnly = true;
            this.ColumnACount.Width = 90;
            // 
            // ColumnBin1
            // 
            this.ColumnBin1.DataPropertyName = "Bin1";
            this.ColumnBin1.HeaderText = "储位①";
            this.ColumnBin1.Name = "ColumnBin1";
            this.ColumnBin1.ReadOnly = true;
            this.ColumnBin1.Width = 76;
            // 
            // ColumnACount1
            // 
            this.ColumnACount1.DataPropertyName = "ACount1";
            this.ColumnACount1.HeaderText = "数量";
            this.ColumnACount1.Name = "ColumnACount1";
            this.ColumnACount1.ReadOnly = true;
            this.ColumnACount1.Width = 62;
            // 
            // ColumnBin2
            // 
            this.ColumnBin2.DataPropertyName = "Bin2";
            this.ColumnBin2.HeaderText = "储位②";
            this.ColumnBin2.Name = "ColumnBin2";
            this.ColumnBin2.ReadOnly = true;
            this.ColumnBin2.Width = 76;
            // 
            // ColumnACount2
            // 
            this.ColumnACount2.DataPropertyName = "ACount2";
            this.ColumnACount2.HeaderText = "数量";
            this.ColumnACount2.Name = "ColumnACount2";
            this.ColumnACount2.ReadOnly = true;
            this.ColumnACount2.Width = 62;
            // 
            // ColumnBin3
            // 
            this.ColumnBin3.DataPropertyName = "Bin3";
            this.ColumnBin3.HeaderText = "储位③";
            this.ColumnBin3.Name = "ColumnBin3";
            this.ColumnBin3.ReadOnly = true;
            this.ColumnBin3.Width = 76;
            // 
            // ColumnACount3
            // 
            this.ColumnACount3.DataPropertyName = "ACount3";
            this.ColumnACount3.HeaderText = "数量";
            this.ColumnACount3.Name = "ColumnACount3";
            this.ColumnACount3.ReadOnly = true;
            this.ColumnACount3.Width = 62;
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
            // ColumnOperatorUser
            // 
            this.ColumnOperatorUser.DataPropertyName = "OperatorUser";
            this.ColumnOperatorUser.HeaderText = "保管员";
            this.ColumnOperatorUser.Name = "ColumnOperatorUser";
            this.ColumnOperatorUser.ReadOnly = true;
            this.ColumnOperatorUser.Width = 76;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxSubPlant);
            this.groupBox1.Controls.Add(this.textBoxBin);
            this.groupBox1.Controls.Add(this.textBoxBNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxOperatorUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxMaterial);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxPlant);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxSLocation);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1135, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盘存信息检索";
            // 
            // textBoxSubPlant
            // 
            this.textBoxSubPlant.Location = new System.Drawing.Point(782, 27);
            this.textBoxSubPlant.Name = "textBoxSubPlant";
            this.textBoxSubPlant.Size = new System.Drawing.Size(150, 26);
            this.textBoxSubPlant.TabIndex = 40;
            this.textBoxSubPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(553, 27);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(150, 26);
            this.textBoxBin.TabIndex = 30;
            this.textBoxBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxBNumber
            // 
            this.textBoxBNumber.Location = new System.Drawing.Point(326, 59);
            this.textBoxBNumber.Name = "textBoxBNumber";
            this.textBoxBNumber.Size = new System.Drawing.Size(150, 26);
            this.textBoxBNumber.TabIndex = 60;
            this.textBoxBNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "批次：";
            // 
            // comboBoxOperatorUser
            // 
            this.comboBoxOperatorUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperatorUser.FormattingEnabled = true;
            this.comboBoxOperatorUser.Location = new System.Drawing.Point(553, 59);
            this.comboBoxOperatorUser.Name = "comboBoxOperatorUser";
            this.comboBoxOperatorUser.Size = new System.Drawing.Size(150, 28);
            this.comboBoxOperatorUser.TabIndex = 70;
            this.comboBoxOperatorUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(482, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "盘点员：";
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(85, 59);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.Size = new System.Drawing.Size(150, 26);
            this.textBoxMaterial.TabIndex = 50;
            this.textBoxMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(1029, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 80;
            this.btnSelect.Text = "检索";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "物料：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(496, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "储位：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(85, 25);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(150, 28);
            this.comboBoxPlant.TabIndex = 10;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            this.comboBoxPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "库存账套：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(326, 25);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(150, 28);
            this.comboBoxSLocation.TabIndex = 20;
            this.comboBoxSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "逻辑库区：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(711, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "产线部门代码：";
            // 
            // 理论库存信息
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.ClientSize = new System.Drawing.Size(1159, 616);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewSapStockInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "理论库存信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "理论库存信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        // Methods
        public 理论库存信息(UserInfo userItem, ArrayList userRoles, string stSerial)
        {
            DataTable table;
            string str;
            this.userItem = null;
            this.userRoles = null;
            this.stSerial = string.Empty;
            dtSapStockInfo = null;
            dtPlantList = null;
            dtStoreLocusList = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.stSerial = stSerial;
            dataGridViewSapStockInfo.AutoGenerateColumns = false;
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ArrayList stList = new ArrayList();
            stList.Add(stSerial);

            if (!comboBoxPlant.Text.Equals("无"))
            {
                stList.Add(comboBoxPlant.Text);
            }
            else
            {
                stList.Add("");
            }

            if (!comboBoxSLocation.Text.Equals("无"))
            {
                stList.Add(comboBoxSLocation.Text);
            }
            else
            {
                stList.Add("");
            }

            if (!textBoxSubPlant.Text.Equals(string.Empty))
            {
                stList.Add(textBoxSubPlant.Text);
            }
            else
            {
                stList.Add("");
            }

            if (!textBoxBin.Text.Equals(string.Empty))
            {
                stList.Add(textBoxBin.Text);
            }
            else
            {
                stList.Add("");
            }

            if (!textBoxMaterial.Text.Equals(string.Empty))
            {
                stList.Add(textBoxMaterial.Text);
            }
            else
            {
                stList.Add("");
            }

            if (!textBoxBNumber.Text.Equals(string.Empty))
            {
                stList.Add(textBoxBNumber.Text);
            }
            else
            {
                stList.Add("");
            }

            if (!comboBoxOperatorUser.Text.Equals("无"))
            {
                stList.Add(comboBoxOperatorUser.Text);
            }
            else
            {
                stList.Add("");
            }

            dtSapStockInfo = DBOperate.STSapStockInfo(stList);
            dataGridViewSapStockInfo.DataSource = dtSapStockInfo;
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

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetNextControl(ActiveControl, true).Focus();
            }
        }
    }
}
