using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BL;
using RFSystem.CommonClass;
using System.Collections;

namespace RFSystem
{
    public class 公司及库存地点信息 : Form
    {
        // Fields
        private Button btnAddPlant;
        private Button btnAddStore;
        private Button btnDelPlant;
        private Button btnDelStore;
        private Button btnModPlant;
        private Button btnModStore;
        private Button btnSelectPlant;
        private Button btnSelectStore;
        private DataGridViewTextBoxColumn columnPlantDescription;
        private DataGridViewTextBoxColumn columnPlantID;
        private DataGridViewTextBoxColumn columnStoreDescription;
        private DataGridViewTextBoxColumn columnStoreLocusID;
        private DataGridViewTextBoxColumn columnStorePlantID;
        private ComboBox comboBoxPlantList;
        private IContainer components;
        private DataGridView dataGridViewPlantList;
        private DataGridView dataGridViewStoreList;
        private DataTable dtPlantList;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label3;
        private Label label5;
        private TextBox textBoxPlantID;
        private TextBox textBoxStoreID;

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectPlant = new System.Windows.Forms.Button();
            this.textBoxPlantID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPlant = new System.Windows.Forms.Button();
            this.btnModPlant = new System.Windows.Forms.Button();
            this.btnDelPlant = new System.Windows.Forms.Button();
            this.dataGridViewPlantList = new System.Windows.Forms.DataGridView();
            this.columnPlantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPlantDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxPlantList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectStore = new System.Windows.Forms.Button();
            this.textBoxStoreID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddStore = new System.Windows.Forms.Button();
            this.btnModStore = new System.Windows.Forms.Button();
            this.btnDelStore = new System.Windows.Forms.Button();
            this.dataGridViewStoreList = new System.Windows.Forms.DataGridView();
            this.columnStoreLocusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStorePlantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStoreDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlantList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStoreList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectPlant);
            this.groupBox1.Controls.Add(this.textBoxPlantID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "公司信息";
            // 
            // btnSelectPlant
            // 
            this.btnSelectPlant.Location = new System.Drawing.Point(245, 25);
            this.btnSelectPlant.Name = "btnSelectPlant";
            this.btnSelectPlant.Size = new System.Drawing.Size(100, 40);
            this.btnSelectPlant.TabIndex = 30;
            this.btnSelectPlant.Text = "查询";
            this.btnSelectPlant.UseVisualStyleBackColor = true;
            this.btnSelectPlant.Click += new System.EventHandler(this.btnSelectPlant_Click);
            // 
            // textBoxPlantID
            // 
            this.textBoxPlantID.Location = new System.Drawing.Point(63, 32);
            this.textBoxPlantID.Name = "textBoxPlantID";
            this.textBoxPlantID.Size = new System.Drawing.Size(150, 26);
            this.textBoxPlantID.TabIndex = 20;
            this.textBoxPlantID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "编号：";
            // 
            // btnAddPlant
            // 
            this.btnAddPlant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPlant.Location = new System.Drawing.Point(12, 498);
            this.btnAddPlant.Name = "btnAddPlant";
            this.btnAddPlant.Size = new System.Drawing.Size(100, 40);
            this.btnAddPlant.TabIndex = 50;
            this.btnAddPlant.Text = "添加";
            this.btnAddPlant.UseVisualStyleBackColor = true;
            this.btnAddPlant.Click += new System.EventHandler(this.btnAddPlant_Click);
            // 
            // btnModPlant
            // 
            this.btnModPlant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModPlant.Enabled = false;
            this.btnModPlant.Location = new System.Drawing.Point(118, 498);
            this.btnModPlant.Name = "btnModPlant";
            this.btnModPlant.Size = new System.Drawing.Size(100, 40);
            this.btnModPlant.TabIndex = 50;
            this.btnModPlant.Text = "修改";
            this.btnModPlant.UseVisualStyleBackColor = true;
            this.btnModPlant.Click += new System.EventHandler(this.btnModPlant_Click);
            // 
            // btnDelPlant
            // 
            this.btnDelPlant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelPlant.Enabled = false;
            this.btnDelPlant.Location = new System.Drawing.Point(224, 498);
            this.btnDelPlant.Name = "btnDelPlant";
            this.btnDelPlant.Size = new System.Drawing.Size(100, 40);
            this.btnDelPlant.TabIndex = 50;
            this.btnDelPlant.Text = "删除";
            this.btnDelPlant.UseVisualStyleBackColor = true;
            this.btnDelPlant.Click += new System.EventHandler(this.btnDelPlant_Click);
            // 
            // dataGridViewPlantList
            // 
            this.dataGridViewPlantList.AllowUserToAddRows = false;
            this.dataGridViewPlantList.AllowUserToResizeColumns = false;
            this.dataGridViewPlantList.AllowUserToResizeRows = false;
            this.dataGridViewPlantList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewPlantList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPlantList.ColumnHeadersHeight = 30;
            this.dataGridViewPlantList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPlantList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPlantID,
            this.columnPlantDescription});
            this.dataGridViewPlantList.Location = new System.Drawing.Point(12, 93);
            this.dataGridViewPlantList.MultiSelect = false;
            this.dataGridViewPlantList.Name = "dataGridViewPlantList";
            this.dataGridViewPlantList.ReadOnly = true;
            this.dataGridViewPlantList.RowHeadersVisible = false;
            this.dataGridViewPlantList.RowTemplate.Height = 23;
            this.dataGridViewPlantList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPlantList.Size = new System.Drawing.Size(351, 399);
            this.dataGridViewPlantList.TabIndex = 40;
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBoxPlantList);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnSelectStore);
            this.groupBox2.Controls.Add(this.textBoxStoreID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(369, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 75);
            this.groupBox2.TabIndex = 1000;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存地点信息";
            // 
            // comboBoxPlantList
            // 
            this.comboBoxPlantList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlantList.FormattingEnabled = true;
            this.comboBoxPlantList.Location = new System.Drawing.Point(304, 32);
            this.comboBoxPlantList.Name = "comboBoxPlantList";
            this.comboBoxPlantList.Size = new System.Drawing.Size(150, 28);
            this.comboBoxPlantList.TabIndex = 1020;
            this.comboBoxPlantList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "从属公司：";
            // 
            // btnSelectStore
            // 
            this.btnSelectStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectStore.Location = new System.Drawing.Point(506, 25);
            this.btnSelectStore.Name = "btnSelectStore";
            this.btnSelectStore.Size = new System.Drawing.Size(100, 40);
            this.btnSelectStore.TabIndex = 1030;
            this.btnSelectStore.Text = "查询";
            this.btnSelectStore.UseVisualStyleBackColor = true;
            this.btnSelectStore.Click += new System.EventHandler(this.btnSelectStore_Click);
            // 
            // textBoxStoreID
            // 
            this.textBoxStoreID.Location = new System.Drawing.Point(63, 32);
            this.textBoxStoreID.Name = "textBoxStoreID";
            this.textBoxStoreID.Size = new System.Drawing.Size(150, 26);
            this.textBoxStoreID.TabIndex = 1010;
            this.textBoxStoreID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "编号：";
            // 
            // btnAddStore
            // 
            this.btnAddStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddStore.Location = new System.Drawing.Point(669, 498);
            this.btnAddStore.Name = "btnAddStore";
            this.btnAddStore.Size = new System.Drawing.Size(100, 40);
            this.btnAddStore.TabIndex = 1050;
            this.btnAddStore.Text = "添加";
            this.btnAddStore.UseVisualStyleBackColor = true;
            this.btnAddStore.Click += new System.EventHandler(this.btnAddStore_Click);
            // 
            // btnModStore
            // 
            this.btnModStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModStore.Enabled = false;
            this.btnModStore.Location = new System.Drawing.Point(775, 498);
            this.btnModStore.Name = "btnModStore";
            this.btnModStore.Size = new System.Drawing.Size(100, 40);
            this.btnModStore.TabIndex = 1050;
            this.btnModStore.Text = "修改";
            this.btnModStore.UseVisualStyleBackColor = true;
            this.btnModStore.Click += new System.EventHandler(this.btnModStore_Click);
            // 
            // btnDelStore
            // 
            this.btnDelStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelStore.Enabled = false;
            this.btnDelStore.Location = new System.Drawing.Point(881, 498);
            this.btnDelStore.Name = "btnDelStore";
            this.btnDelStore.Size = new System.Drawing.Size(100, 40);
            this.btnDelStore.TabIndex = 1050;
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
            this.dataGridViewStoreList.Location = new System.Drawing.Point(369, 93);
            this.dataGridViewStoreList.MultiSelect = false;
            this.dataGridViewStoreList.Name = "dataGridViewStoreList";
            this.dataGridViewStoreList.ReadOnly = true;
            this.dataGridViewStoreList.RowHeadersVisible = false;
            this.dataGridViewStoreList.RowTemplate.Height = 23;
            this.dataGridViewStoreList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStoreList.Size = new System.Drawing.Size(612, 399);
            this.dataGridViewStoreList.TabIndex = 1040;
            this.dataGridViewStoreList.SelectionChanged += new System.EventHandler(this.dataGridViewStoreList_SelectionChanged);
            // 
            // columnStoreLocusID
            // 
            this.columnStoreLocusID.DataPropertyName = "StoreLocusID";
            this.columnStoreLocusID.HeaderText = "库存地点编号";
            this.columnStoreLocusID.Name = "columnStoreLocusID";
            this.columnStoreLocusID.ReadOnly = true;
            this.columnStoreLocusID.Width = 118;
            // 
            // columnStorePlantID
            // 
            this.columnStorePlantID.DataPropertyName = "PlantID";
            this.columnStorePlantID.HeaderText = "从属公司编号";
            this.columnStorePlantID.Name = "columnStorePlantID";
            this.columnStorePlantID.ReadOnly = true;
            this.columnStorePlantID.Width = 118;
            // 
            // columnStoreDescription
            // 
            this.columnStoreDescription.DataPropertyName = "StoreLocusDescription";
            this.columnStoreDescription.HeaderText = "库存地点描述";
            this.columnStoreDescription.Name = "columnStoreDescription";
            this.columnStoreDescription.ReadOnly = true;
            this.columnStoreDescription.Width = 118;
            // 
            // 公司及库存地点信息
            // 
            this.ClientSize = new System.Drawing.Size(993, 550);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddPlant);
            this.Controls.Add(this.btnModPlant);
            this.Controls.Add(this.dataGridViewPlantList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDelPlant);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddStore);
            this.Controls.Add(this.btnDelStore);
            this.Controls.Add(this.dataGridViewStoreList);
            this.Controls.Add(this.btnModStore);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "公司及库存地点信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公司及库存地点信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlantList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStoreList)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 公司及库存地点信息()
        {
            components = null;
            dtPlantList = null;
            dtStoreLocusList = null;
            InitializeComponent();
            RefreshDate();
        }

        private void btnAddPlant_Click(object sender, EventArgs e)
        {
            公司信息 frm = new 公司信息(null);
            frm.Text = "公司新增";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnSelectPlant.PerformClick();
                RefreshDate();
            }
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            库存地点信息 frm = new 库存地点信息(null);
            frm.Text = "库存新增";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnSelectStore.PerformClick();
            }
        }

        private void btnDelPlant_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtPlantList))
            {
                if (dataGridViewPlantList.SelectedRows != null)
                {
                    if (CommonFunction.IfHasData(DBOperate.GetStoreLocusWithPlant((string)dataGridViewPlantList.SelectedRows[0].Cells["columnPlantID"].Value)))
                    {
                        MessageBox.Show("该公司信息下包含仓库地点信息，请先删除仓库地点信息", "不可删除", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                    else if ((MessageBox.Show("确认删除此条公司信息么？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) && (DBOperate.DelPlant((string)this.dataGridViewPlantList.SelectedRows[0].Cells["columnPlantID"].Value) == 1))
                    {
                        MessageBox.Show("公司信息删除成功");
                        btnSelectPlant.PerformClick();
                        RefreshDate();
                    }
                }
                else
                {
                    MessageBox.Show("请选择一条公司信息", "选择无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("没有检索到任何公司信息，无法修改", "检索无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelStore_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtStoreLocusList))
            {
                if (dataGridViewStoreList.SelectedRows != null)
                {
                    if ((MessageBox.Show("确认删除此条库存地点信息么？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) && (DBOperate.DelStoreLocus((string)this.dataGridViewStoreList.SelectedRows[0].Cells["columnStoreLocusID"].Value, (string)this.dataGridViewStoreList.SelectedRows[0].Cells["columnStorePlantID"].Value) == 1))
                    {
                        MessageBox.Show("库存地点信息删除成功");
                        btnSelectStore.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show("请选择一条库存地点信息", "选择无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("没有检索到任何库存地点信息，无法修改", "检索无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnModPlant_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtPlantList))
            {
                if (dataGridViewPlantList.SelectedRows != null)
                {
                    Hashtable plantItem = new Hashtable();

                    foreach (DataGridViewCell cell in dataGridViewPlantList.SelectedRows[0].Cells)
                    {
                        plantItem.Add(cell.OwningColumn.DataPropertyName, cell.Value);
                    }

                    公司信息 frm = new 公司信息(plantItem);
                    frm.Text = "公司修改";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btnSelectPlant.PerformClick();
                        RefreshDate();
                    }
                }
                else
                {
                    MessageBox.Show("请选择一条公司信息", "选择无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("没有检索到任何公司信息，无法修改", "检索无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnModStore_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtStoreLocusList))
            {
                if (dataGridViewStoreList.SelectedRows != null)
                {
                    Hashtable storeItem = new Hashtable();

                    foreach (DataGridViewCell cell in dataGridViewStoreList.SelectedRows[0].Cells)
                    {
                        storeItem.Add(cell.OwningColumn.DataPropertyName, cell.Value);
                    }

                    库存地点信息 frm = new 库存地点信息(storeItem);
                    frm.Text = "库存修改";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btnSelectStore.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show("请选择一条库存地点信息", "选择无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("没有检索到任何库存地点信息，无法修改", "检索无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSelectPlant_Click(object sender, EventArgs e)
        {
            dtPlantList = DBOperate.GetPlantList(textBoxPlantID.Text.Trim());
            dataGridViewPlantList.DataSource = dtPlantList;
        }

        private void btnSelectStore_Click(object sender, EventArgs e)
        {
            dtStoreLocusList = DBOperate.GetStoreLocusList(textBoxStoreID.Text.Trim(), comboBoxPlantList.Text.Trim().Equals("无") ? string.Empty : comboBoxPlantList.Text.Trim());
            dataGridViewStoreList.DataSource = dtStoreLocusList;
        }

        private void dataGridViewPlantList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewPlantList.Rows != null) && (dataGridViewPlantList.SelectedRows.Count != 0))
            {
                btnModPlant.Enabled = true;
                btnDelPlant.Enabled = true;
            }
            else
            {
                btnModPlant.Enabled = false;
                btnDelPlant.Enabled = false;
            }
        }

        private void dataGridViewStoreList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewStoreList.Rows != null) && (dataGridViewStoreList.SelectedRows.Count != 0))
            {
                btnModStore.Enabled = true;
                btnDelStore.Enabled = true;
            }
            else
            {
                btnModStore.Enabled = false;
                btnDelStore.Enabled = false;
            }
        }

        private void RefreshDate()
        {
            comboBoxPlantList.Items.Clear();
            DataTable plantList = DBOperate.GetPlantList(string.Empty);
            comboBoxPlantList.Items.Add("无");

            if (CommonFunction.IfHasData(plantList))
            {
                foreach (DataRow row in plantList.Rows)
                {
                    comboBoxPlantList.Items.Add(row["PlantID"].ToString());
                }
            }

            this.comboBoxPlantList.SelectedIndex = 0;
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
