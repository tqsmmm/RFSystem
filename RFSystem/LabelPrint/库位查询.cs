using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using RFSystem.AnSteel;

namespace RFSystem.LabelPrint
{
    public class 库位查询 : Form
    {
        // Fields
        private Button btnAddDetail;
        private Button btnClear;
        private Button btnDelete;
        private Button btnExit;
        private Button btnSelect;
        private DataGridViewTextBoxColumn ColumnBct1;
        private DataGridViewTextBoxColumn ColumnBillNo;
        private DataGridViewTextBoxColumn ColumnBIN;
        private DataGridViewTextBoxColumn ColumnBINKEY;
        private DataGridViewTextBoxColumn ColumnFACT_NO;
        private DataGridViewTextBoxColumn ColumnFACTORY_NO;
        private DataGridViewTextBoxColumn ColumnMenge;
        private DataGridViewTextBoxColumn ColumnPATCH_NO;
        private DataGridViewTextBoxColumn ColumnPName;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NAME;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NO;
        private DataGridViewTextBoxColumn ColumnSL;
        private DataGridViewTextBoxColumn ColumnSLocation;
        private DataGridViewTextBoxColumn ColumnSTOREMAN;
        private DataGridViewTextBoxColumn ColumnStoreManDetail;
        private DataGridViewTextBoxColumn ColumnSUPPLIER_NO;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private DataGridViewTextBoxColumn ColumnVerpr;
        private DataGridViewTextBoxColumn ColumnWeight;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private DataGridView dataGridViewMaintain;
        private DataGridView dataGridViewSapStockInfo;
        private DataTable dtGoods;
        private DataTable dtMaintain;
        private DataTable dtPlantList;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBoxInputInfo;
        private Label label23;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxBin;
        private TextBox textBoxSTOREMAN;
        private Thread thread;
        private UserInfo userItem;
        private ArrayList userRoles;

        // Methods
        public 库位查询(UserInfo userItem, ArrayList userRoles)
        {
            this.userItem = null;
            this.userRoles = null;
            dtMaintain = null;
            dtGoods = null;
            dtPlantList = null;
            dtStoreLocusList = null;
            thread = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            textBoxSTOREMAN.Text = userItem.userID;

            if (userItem.isAdmin)
            {
                textBoxSTOREMAN.ReadOnly = false;
            }

            InitFctAndStore();
            InitTableColumns();
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (!comboBoxPlant.Text.Trim().Equals("无") && !comboBoxSLocation.Text.Trim().Equals("无") && !textBoxBin.Text.Trim().Equals(string.Empty) && !textBoxSTOREMAN.Text.Trim().Equals(string.Empty))
            {
                if (dtMaintain.Select("FACTORY_NO='" + comboBoxPlant.Text.Trim() + "' and SL='" + comboBoxSLocation.Text.Trim() + "' and STOREMAN='" + textBoxSTOREMAN.Text.Trim() + "' and BINKEY='" + textBoxBin.Text.Trim() + "'").Length > 0)
                {
                    CommonFunction.Sys_MsgBox("已包含此检索条件，请不要重复输入");
                }
                else
                {
                    dtMaintain.Rows.Add(new object[] { comboBoxPlant.Text.Trim(), comboBoxSLocation.Text.Trim(), textBoxSTOREMAN.Text.Trim(), textBoxBin.Text.Trim() });
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("请填写完整信息！");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否清空页面所有数据？此前内容将会全部被清除。"))
            {
                ClearControls();
                btnSelect.Enabled = true;
                btnAddDetail.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow[] rowArray = dtMaintain.Select("FACTORY_NO='" + dataGridViewMaintain.SelectedRows[0].Cells["ColumnFACTORY_NO"].Value.ToString() + "' and SL='" + dataGridViewMaintain.SelectedRows[0].Cells["ColumnSL"].Value.ToString() + "' and STOREMAN='" + dataGridViewMaintain.SelectedRows[0].Cells["ColumnSTOREMAN"].Value.ToString() + "' and BINKEY='" + dataGridViewMaintain.SelectedRows[0].Cells["ColumnBINKEY"].Value.ToString() + "'");

            if ((rowArray != null) && (rowArray.Length != 0))
            {
                dtMaintain.Rows.Remove(rowArray[0]);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(ShowWaitingMsg));
            thread.Start();
        }

        private void ClearControls()
        {
            comboBoxPlant.SelectedIndex = 0;
            textBoxBin.Text = string.Empty;
            dtGoods.Rows.Clear();
            dtMaintain.Rows.Clear();
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

        private void dataGridViewMaintain_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewMaintain.Rows != null) && (dataGridViewMaintain.SelectedRows.Count != 0))
            {
                btnDelete.Enabled = true;
                btnSelect.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnSelect.Enabled = false;
            }
        }

        private void EnterDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private bool FilterTheUsefulInfo(DataTable goodsInfo, DataTable usefulInfo, string bin)
        {
            if (CommonFunction.IfHasData(goodsInfo))
            {
                foreach (DataRow row in goodsInfo.Rows)
                {
                    ArrayList list = new ArrayList();
                    list.Add(row["Bct50"]);
                    list.Add(row["Bct51"]);
                    list.Add(row["Bct60"]);
                    list.Add(row["Bct61"]);
                    list.Add(row["Bct70"]);
                    list.Add(row["Bct71"]);

                    if (list[0].ToString().Contains(bin) && (usefulInfo.Select("Werks='" + row["Werks"].ToString() + "' and Charg='" + row["Charg"].ToString() + "' and Matnr='" + row["Matnr"].ToString() + "' and Bct0='" + list[0].ToString() + "'").Length == 0))
                    {
                        usefulInfo.Rows.Add(new object[] { row["Werks"].ToString(), row["Matnr"].ToString(), row["Charg"].ToString(), row["Lgort"].ToString(), row["Maktx"].ToString(), row["Meins"].ToString(), list[0], list[1], row["Bct10"].ToString(), row["Bct20"].ToString(), row["Ebeln"].ToString(), row["Name1"].ToString(), row["Ntgew"].ToString(), row["Verpr"].ToString(), row["Menge"].ToString() });
                    }

                    if (list[2].ToString().Contains(bin) && (usefulInfo.Select("Werks='" + row["Werks"].ToString() + "' and Charg='" + row["Charg"].ToString() + "' and Matnr='" + row["Matnr"].ToString() + "' and Bct0='" + list[2].ToString() + "'").Length == 0))
                    {
                        usefulInfo.Rows.Add(new object[] { row["Werks"].ToString(), row["Matnr"].ToString(), row["Charg"].ToString(), row["Lgort"].ToString(), row["Maktx"].ToString(), row["Meins"].ToString(), list[2], list[3], row["Bct10"].ToString(), row["Bct20"].ToString(), row["Ebeln"].ToString(), row["Name1"].ToString(), row["Ntgew"].ToString(), row["Verpr"].ToString(), row["Menge"].ToString() });
                    }

                    if (list[4].ToString().Contains(bin) && (usefulInfo.Select("Werks='" + row["Werks"].ToString() + "' and Charg='" + row["Charg"].ToString() + "' and Matnr='" + row["Matnr"].ToString() + "' and Bct0='" + list[4].ToString() + "'").Length == 0))
                    {
                        usefulInfo.Rows.Add(new object[] { row["Werks"].ToString(), row["Matnr"].ToString(), row["Charg"].ToString(), row["Lgort"].ToString(), row["Maktx"].ToString(), row["Meins"].ToString(), list[4], list[5], row["Bct10"].ToString(), row["Bct20"].ToString(), row["Ebeln"].ToString(), row["Name1"].ToString(), row["Ntgew"].ToString(), row["Verpr"].ToString(), row["Menge"].ToString() });
                    }
                }

                return true;
            }

            return false;
        }

        private void InitFctAndStore()
        {
            dtPlantList = DBOperate.GetPlantList(string.Empty);
            dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, string.Empty);
            comboBoxSLocation.Items.Add("无");
            comboBoxSLocation.SelectedIndex = 0;
            comboBoxPlant.Items.Add("无");

            if (CommonFunction.IfHasData(dtPlantList))
            {
                foreach (DataRow row in dtPlantList.Rows)
                {
                    comboBoxPlant.Items.Add(row["PlantID"].ToString());
                }
            }

            comboBoxPlant.SelectedIndex = 0;
        }

        private void InitializeComponent()
        {
            this.groupBoxInputInfo = new System.Windows.Forms.GroupBox();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxSTOREMAN = new System.Windows.Forms.TextBox();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSapStockInfo = new System.Windows.Forms.DataGridView();
            this.ColumnFACT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPATCH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStoreManDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSUPPLIER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVerpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMenge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewMaintain = new System.Windows.Forms.DataGridView();
            this.ColumnFACTORY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSTOREMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBINKEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBoxInputInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintain)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInputInfo
            // 
            this.groupBoxInputInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInputInfo.Controls.Add(this.textBoxBin);
            this.groupBoxInputInfo.Controls.Add(this.label23);
            this.groupBoxInputInfo.Controls.Add(this.textBoxSTOREMAN);
            this.groupBoxInputInfo.Controls.Add(this.comboBoxSLocation);
            this.groupBoxInputInfo.Controls.Add(this.label5);
            this.groupBoxInputInfo.Controls.Add(this.label4);
            this.groupBoxInputInfo.Controls.Add(this.comboBoxPlant);
            this.groupBoxInputInfo.Controls.Add(this.btnAddDetail);
            this.groupBoxInputInfo.Controls.Add(this.label3);
            this.groupBoxInputInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInputInfo.Name = "groupBoxInputInfo";
            this.groupBoxInputInfo.Size = new System.Drawing.Size(1003, 75);
            this.groupBoxInputInfo.TabIndex = 526;
            this.groupBoxInputInfo.TabStop = false;
            this.groupBoxInputInfo.Text = "库位查询条件信息添加";
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(445, 32);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(100, 26);
            this.textBoxBin.TabIndex = 60;
            this.textBoxBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(551, 35);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "保管员码：";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSTOREMAN
            // 
            this.textBoxSTOREMAN.Location = new System.Drawing.Point(636, 32);
            this.textBoxSTOREMAN.Name = "textBoxSTOREMAN";
            this.textBoxSTOREMAN.ReadOnly = true;
            this.textBoxSTOREMAN.Size = new System.Drawing.Size(100, 26);
            this.textBoxSTOREMAN.TabIndex = 50;
            this.textBoxSTOREMAN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(268, 32);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(100, 28);
            this.comboBoxSLocation.TabIndex = 40;
            this.comboBoxSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "库存地点：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "公司号：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(77, 32);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(100, 28);
            this.comboBoxPlant.TabIndex = 30;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            this.comboBoxPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterDown);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDetail.Location = new System.Drawing.Point(897, 25);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(100, 40);
            this.btnAddDetail.TabIndex = 70;
            this.btnAddDetail.Text = "添加条件";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "货位号：";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(597, 587);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 532;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(915, 587);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 533;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewSapStockInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1003, 250);
            this.groupBox1.TabIndex = 530;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "货物信息";
            // 
            // dataGridViewSapStockInfo
            // 
            this.dataGridViewSapStockInfo.AllowUserToAddRows = false;
            this.dataGridViewSapStockInfo.AllowUserToResizeRows = false;
            this.dataGridViewSapStockInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSapStockInfo.ColumnHeadersHeight = 30;
            this.dataGridViewSapStockInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSapStockInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFACT_NO,
            this.ColumnPRODUCT_NO,
            this.ColumnPATCH_NO,
            this.ColumnSLocation,
            this.ColumnPRODUCT_NAME,
            this.ColumnUNIT,
            this.ColumnBIN,
            this.ColumnBct1,
            this.ColumnStoreManDetail,
            this.ColumnSUPPLIER_NO,
            this.ColumnBillNo,
            this.ColumnPName,
            this.ColumnWeight,
            this.ColumnVerpr,
            this.ColumnMenge});
            this.dataGridViewSapStockInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSapStockInfo.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewSapStockInfo.MultiSelect = false;
            this.dataGridViewSapStockInfo.Name = "dataGridViewSapStockInfo";
            this.dataGridViewSapStockInfo.ReadOnly = true;
            this.dataGridViewSapStockInfo.RowHeadersVisible = false;
            this.dataGridViewSapStockInfo.RowTemplate.Height = 23;
            this.dataGridViewSapStockInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSapStockInfo.Size = new System.Drawing.Size(997, 225);
            this.dataGridViewSapStockInfo.TabIndex = 30001;
            // 
            // ColumnFACT_NO
            // 
            this.ColumnFACT_NO.DataPropertyName = "Werks";
            this.ColumnFACT_NO.HeaderText = "公司号";
            this.ColumnFACT_NO.Name = "ColumnFACT_NO";
            this.ColumnFACT_NO.ReadOnly = true;
            this.ColumnFACT_NO.Visible = false;
            this.ColumnFACT_NO.Width = 90;
            // 
            // ColumnPRODUCT_NO
            // 
            this.ColumnPRODUCT_NO.DataPropertyName = "Matnr";
            this.ColumnPRODUCT_NO.HeaderText = "物料号";
            this.ColumnPRODUCT_NO.Name = "ColumnPRODUCT_NO";
            this.ColumnPRODUCT_NO.ReadOnly = true;
            this.ColumnPRODUCT_NO.Width = 76;
            // 
            // ColumnPATCH_NO
            // 
            this.ColumnPATCH_NO.DataPropertyName = "Charg";
            this.ColumnPATCH_NO.HeaderText = "批次号";
            this.ColumnPATCH_NO.Name = "ColumnPATCH_NO";
            this.ColumnPATCH_NO.ReadOnly = true;
            this.ColumnPATCH_NO.Width = 76;
            // 
            // ColumnSLocation
            // 
            this.ColumnSLocation.DataPropertyName = "Lgort";
            this.ColumnSLocation.HeaderText = "库存地点";
            this.ColumnSLocation.Name = "ColumnSLocation";
            this.ColumnSLocation.ReadOnly = true;
            this.ColumnSLocation.Width = 90;
            // 
            // ColumnPRODUCT_NAME
            // 
            this.ColumnPRODUCT_NAME.DataPropertyName = "Maktx";
            this.ColumnPRODUCT_NAME.HeaderText = "物品名称";
            this.ColumnPRODUCT_NAME.Name = "ColumnPRODUCT_NAME";
            this.ColumnPRODUCT_NAME.ReadOnly = true;
            this.ColumnPRODUCT_NAME.Width = 90;
            // 
            // ColumnUNIT
            // 
            this.ColumnUNIT.DataPropertyName = "Meins";
            this.ColumnUNIT.HeaderText = "单位";
            this.ColumnUNIT.Name = "ColumnUNIT";
            this.ColumnUNIT.ReadOnly = true;
            this.ColumnUNIT.Width = 62;
            // 
            // ColumnBIN
            // 
            this.ColumnBIN.DataPropertyName = "Bct0";
            this.ColumnBIN.HeaderText = "货位";
            this.ColumnBIN.Name = "ColumnBIN";
            this.ColumnBIN.ReadOnly = true;
            this.ColumnBIN.Width = 62;
            // 
            // ColumnBct1
            // 
            this.ColumnBct1.DataPropertyName = "Bct1";
            this.ColumnBct1.HeaderText = "数量";
            this.ColumnBct1.Name = "ColumnBct1";
            this.ColumnBct1.ReadOnly = true;
            this.ColumnBct1.Width = 62;
            // 
            // ColumnStoreManDetail
            // 
            this.ColumnStoreManDetail.DataPropertyName = "Bct10";
            this.ColumnStoreManDetail.HeaderText = "保管员";
            this.ColumnStoreManDetail.Name = "ColumnStoreManDetail";
            this.ColumnStoreManDetail.ReadOnly = true;
            this.ColumnStoreManDetail.Width = 76;
            // 
            // ColumnSUPPLIER_NO
            // 
            this.ColumnSUPPLIER_NO.DataPropertyName = "Bct20";
            this.ColumnSUPPLIER_NO.HeaderText = "二级厂码";
            this.ColumnSUPPLIER_NO.Name = "ColumnSUPPLIER_NO";
            this.ColumnSUPPLIER_NO.ReadOnly = true;
            this.ColumnSUPPLIER_NO.Visible = false;
            this.ColumnSUPPLIER_NO.Width = 75;
            // 
            // ColumnBillNo
            // 
            this.ColumnBillNo.DataPropertyName = "Ebeln";
            this.ColumnBillNo.HeaderText = "订单号";
            this.ColumnBillNo.Name = "ColumnBillNo";
            this.ColumnBillNo.ReadOnly = true;
            this.ColumnBillNo.ToolTipText = "Ebeln";
            this.ColumnBillNo.Width = 76;
            // 
            // ColumnPName
            // 
            this.ColumnPName.DataPropertyName = "Name1";
            this.ColumnPName.HeaderText = "供应商";
            this.ColumnPName.Name = "ColumnPName";
            this.ColumnPName.ReadOnly = true;
            this.ColumnPName.ToolTipText = "Name1";
            this.ColumnPName.Width = 76;
            // 
            // ColumnWeight
            // 
            this.ColumnWeight.DataPropertyName = "Ntgew";
            this.ColumnWeight.HeaderText = "重量";
            this.ColumnWeight.Name = "ColumnWeight";
            this.ColumnWeight.ReadOnly = true;
            this.ColumnWeight.Width = 62;
            // 
            // ColumnVerpr
            // 
            this.ColumnVerpr.DataPropertyName = "Verpr";
            this.ColumnVerpr.HeaderText = "金额";
            this.ColumnVerpr.Name = "ColumnVerpr";
            this.ColumnVerpr.ReadOnly = true;
            this.ColumnVerpr.Width = 62;
            // 
            // ColumnMenge
            // 
            this.ColumnMenge.DataPropertyName = "Menge";
            this.ColumnMenge.HeaderText = "库存数量";
            this.ColumnMenge.Name = "ColumnMenge";
            this.ColumnMenge.ReadOnly = true;
            this.ColumnMenge.Width = 90;
            // 
            // dataGridViewMaintain
            // 
            this.dataGridViewMaintain.AllowUserToAddRows = false;
            this.dataGridViewMaintain.AllowUserToResizeRows = false;
            this.dataGridViewMaintain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMaintain.ColumnHeadersHeight = 30;
            this.dataGridViewMaintain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMaintain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFACTORY_NO,
            this.ColumnSL,
            this.ColumnSTOREMAN,
            this.ColumnBINKEY});
            this.dataGridViewMaintain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMaintain.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewMaintain.MultiSelect = false;
            this.dataGridViewMaintain.Name = "dataGridViewMaintain";
            this.dataGridViewMaintain.ReadOnly = true;
            this.dataGridViewMaintain.RowHeadersVisible = false;
            this.dataGridViewMaintain.RowTemplate.Height = 23;
            this.dataGridViewMaintain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaintain.Size = new System.Drawing.Size(997, 207);
            this.dataGridViewMaintain.TabIndex = 20000;
            this.dataGridViewMaintain.SelectionChanged += new System.EventHandler(this.dataGridViewMaintain_SelectionChanged);
            // 
            // ColumnFACTORY_NO
            // 
            this.ColumnFACTORY_NO.DataPropertyName = "FACTORY_NO";
            this.ColumnFACTORY_NO.HeaderText = "公司";
            this.ColumnFACTORY_NO.Name = "ColumnFACTORY_NO";
            this.ColumnFACTORY_NO.ReadOnly = true;
            this.ColumnFACTORY_NO.Width = 62;
            // 
            // ColumnSL
            // 
            this.ColumnSL.DataPropertyName = "SL";
            this.ColumnSL.HeaderText = "库存地点";
            this.ColumnSL.Name = "ColumnSL";
            this.ColumnSL.ReadOnly = true;
            this.ColumnSL.Width = 90;
            // 
            // ColumnSTOREMAN
            // 
            this.ColumnSTOREMAN.DataPropertyName = "STOREMAN";
            this.ColumnSTOREMAN.HeaderText = "保管员";
            this.ColumnSTOREMAN.Name = "ColumnSTOREMAN";
            this.ColumnSTOREMAN.ReadOnly = true;
            this.ColumnSTOREMAN.Width = 76;
            // 
            // ColumnBINKEY
            // 
            this.ColumnBINKEY.DataPropertyName = "BINKEY";
            this.ColumnBINKEY.HeaderText = "货位";
            this.ColumnBINKEY.Name = "ColumnBINKEY";
            this.ColumnBINKEY.ReadOnly = true;
            this.ColumnBINKEY.Width = 62;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewMaintain);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1003, 232);
            this.groupBox2.TabIndex = 529;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(703, 587);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 534;
            this.btnDelete.Text = "删除条件";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(809, 587);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 535;
            this.btnClear.Text = "清空信息";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // 库位查询
            // 
            this.ClientSize = new System.Drawing.Size(1027, 639);
            this.ControlBox = false;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBoxInputInfo);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "库位查询";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库位查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBoxInputInfo.ResumeLayout(false);
            this.groupBoxInputInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintain)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitTableColumns()
        {
            this.dtMaintain = new DataTable();
            this.dtMaintain.Columns.Add("FACTORY_NO");
            this.dtMaintain.Columns.Add("SL");
            this.dtMaintain.Columns.Add("STOREMAN");
            this.dtMaintain.Columns.Add("BINKEY");
            this.dataGridViewMaintain.DataSource = this.dtMaintain;
            this.dtGoods = new DataTable();
            this.dtGoods.Columns.Add("Werks");
            this.dtGoods.Columns.Add("Matnr");
            this.dtGoods.Columns.Add("Charg");
            this.dtGoods.Columns.Add("Lgort");
            this.dtGoods.Columns.Add("Maktx");
            this.dtGoods.Columns.Add("Meins");
            this.dtGoods.Columns.Add("Bct0");
            this.dtGoods.Columns.Add("Bct1");
            this.dtGoods.Columns.Add("Bct10");
            this.dtGoods.Columns.Add("Bct20");
            this.dtGoods.Columns.Add("Ebeln");
            this.dtGoods.Columns.Add("Name1");
            this.dtGoods.Columns.Add("Ntgew");
            this.dtGoods.Columns.Add("Verpr");
            this.dtGoods.Columns.Add("Menge");
            this.dataGridViewSapStockInfo.DataSource = this.dtGoods;
        }

        private void ShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataRow row in dtMaintain.Rows)
                {
                    DataSet cxDs = new DataSet("货位查询");
                    MessagePack pack = new MessagePack();

                    try
                    {
                        pack = Utility.getSerive().GetHWCXInfo(row["STOREMAN"].ToString(), row["BINKEY"].ToString(), row["SL"].ToString(), row["FACTORY_NO"].ToString(), out cxDs);
                    }
                    catch
                    {
                        CommonFunction.Sys_MsgBox(pack.Message);
                        return;
                    }

                    if (pack.Code == 0)
                    {
                        FilterTheUsefulInfo(cxDs.Tables[0], dtGoods, row["BINKEY"].ToString());
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox(pack.Message);
                    }
                }

                if (!CommonFunction.IfHasData(dtGoods))
                {
                    CommonFunction.Sys_MsgBox("没有检索到任何数据，请重新输入条件进行检索");
                    ClearControls();
                }
                else
                {
                    btnSelect.Enabled = false;
                    btnAddDetail.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ShowWaitingMsg()
        {
            Invoke(new EventHandler(ShowMsg));
        }
    }
}
