using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace RFSystem
{
    public class 盘点对照明细信息 : Form
    {
        // Fields
        private ArrayList adjustItem;
        private Button btnAdd;
        private Button btnDel;
        private Button btnMod;
        private Button btnOK;
        private DataGridViewTextBoxColumn ColumnACount;
        private DataGridViewTextBoxColumn ColumnACount1;
        private DataGridViewTextBoxColumn ColumnACount2;
        private DataGridViewTextBoxColumn ColumnACount3;
        private DataGridViewTextBoxColumn ColumnBarCodeS;
        private DataGridViewTextBoxColumn ColumnBin1;
        private DataGridViewTextBoxColumn ColumnBin2;
        private DataGridViewTextBoxColumn ColumnBin3;
        private DataGridViewTextBoxColumn ColumnBinCountS;
        private DataGridViewTextBoxColumn ColumnBinS;
        private DataGridViewTextBoxColumn ColumnBNumber;
        private DataGridViewTextBoxColumn ColumnBNumberS;
        private DataGridViewTextBoxColumn ColumnItemNo;
        private DataGridViewTextBoxColumn ColumnMaterial;
        private DataGridViewTextBoxColumn ColumnMaterialS;
        private DataGridViewTextBoxColumn ColumnMDesc;
        private DataGridViewTextBoxColumn ColumnOperatorDateTimeS;
        private DataGridViewTextBoxColumn ColumnOperatorUser;
        private DataGridViewTextBoxColumn ColumnOperatorUserS;
        private DataGridViewTextBoxColumn ColumnPlant;
        private DataGridViewTextBoxColumn ColumnPlantS;
        private DataGridViewTextBoxColumn ColumnPrice;
        private DataGridViewTextBoxColumn ColumnSLocation;
        private DataGridViewTextBoxColumn ColumnSLocationS;
        private DataGridViewTextBoxColumn ColumnSPEC;
        private DataGridViewTextBoxColumn ColumnSubPlant;
        private DataGridViewTextBoxColumn ColumnWeight;
        private DataGridView dataGridViewSapStockInfo;
        private DataGridView dataGridViewSTOrigin;
        private DataSet dsAdjustItem;
        private UserInfo userItem;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewSapStockInfo = new System.Windows.Forms.DataGridView();
            this.ColumnPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnACount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnACount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnACount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBin3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnACount3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridViewSTOrigin = new System.Windows.Forms.DataGridView();
            this.ColumnItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlantS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSLocationS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaterialS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBNumberS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBinS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBinCountS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBarCodeS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorUserS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperatorDateTimeS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSTOrigin)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSapStockInfo
            // 
            this.dataGridViewSapStockInfo.AllowUserToAddRows = false;
            this.dataGridViewSapStockInfo.AllowUserToResizeRows = false;
            this.dataGridViewSapStockInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSapStockInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSapStockInfo.ColumnHeadersHeight = 30;
            this.dataGridViewSapStockInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSapStockInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPlant,
            this.ColumnSLocation,
            this.ColumnMaterial,
            this.ColumnBNumber,
            this.ColumnACount,
            this.ColumnBin1,
            this.ColumnACount1,
            this.ColumnBin2,
            this.ColumnACount2,
            this.ColumnBin3,
            this.ColumnACount3,
            this.ColumnSubPlant,
            this.ColumnMDesc,
            this.ColumnSPEC,
            this.ColumnPrice,
            this.ColumnWeight,
            this.ColumnOperatorUser});
            this.dataGridViewSapStockInfo.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewSapStockInfo.MultiSelect = false;
            this.dataGridViewSapStockInfo.Name = "dataGridViewSapStockInfo";
            this.dataGridViewSapStockInfo.ReadOnly = true;
            this.dataGridViewSapStockInfo.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewSapStockInfo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSapStockInfo.RowTemplate.Height = 23;
            this.dataGridViewSapStockInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSapStockInfo.Size = new System.Drawing.Size(950, 196);
            this.dataGridViewSapStockInfo.TabIndex = 24;
            // 
            // ColumnPlant
            // 
            this.ColumnPlant.DataPropertyName = "Plant";
            this.ColumnPlant.HeaderText = "所属库存账套";
            this.ColumnPlant.Name = "ColumnPlant";
            this.ColumnPlant.ReadOnly = true;
            this.ColumnPlant.Width = 90;
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
            // ColumnACount
            // 
            this.ColumnACount.DataPropertyName = "ACount";
            this.ColumnACount.HeaderText = "库存数量";
            this.ColumnACount.Name = "ColumnACount";
            this.ColumnACount.ReadOnly = true;
            this.ColumnACount.Width = 90;
            // 
            // ColumnBin1
            // 
            this.ColumnBin1.DataPropertyName = "Bin1";
            this.ColumnBin1.HeaderText = "储位1";
            this.ColumnBin1.Name = "ColumnBin1";
            this.ColumnBin1.ReadOnly = true;
            this.ColumnBin1.Width = 70;
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
            this.ColumnBin2.HeaderText = "储位2";
            this.ColumnBin2.Name = "ColumnBin2";
            this.ColumnBin2.ReadOnly = true;
            this.ColumnBin2.Width = 70;
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
            this.ColumnBin3.HeaderText = "储位3";
            this.ColumnBin3.Name = "ColumnBin3";
            this.ColumnBin3.ReadOnly = true;
            this.ColumnBin3.Width = 70;
            // 
            // ColumnACount3
            // 
            this.ColumnACount3.DataPropertyName = "ACount3";
            this.ColumnACount3.HeaderText = "数量";
            this.ColumnACount3.Name = "ColumnACount3";
            this.ColumnACount3.ReadOnly = true;
            this.ColumnACount3.Width = 62;
            // 
            // ColumnSubPlant
            // 
            this.ColumnSubPlant.DataPropertyName = "SubPlant";
            this.ColumnSubPlant.HeaderText = "产线部门代码";
            this.ColumnSubPlant.Name = "ColumnSubPlant";
            this.ColumnSubPlant.ReadOnly = true;
            this.ColumnSubPlant.Width = 76;
            // 
            // ColumnMDesc
            // 
            this.ColumnMDesc.DataPropertyName = "MDesc";
            this.ColumnMDesc.HeaderText = "货物名称";
            this.ColumnMDesc.Name = "ColumnMDesc";
            this.ColumnMDesc.ReadOnly = true;
            this.ColumnMDesc.Width = 90;
            // 
            // ColumnSPEC
            // 
            this.ColumnSPEC.DataPropertyName = "SPEC";
            this.ColumnSPEC.HeaderText = "规格";
            this.ColumnSPEC.Name = "ColumnSPEC";
            this.ColumnSPEC.ReadOnly = true;
            this.ColumnSPEC.Width = 62;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.DataPropertyName = "Price";
            this.ColumnPrice.HeaderText = "单价";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.ReadOnly = true;
            this.ColumnPrice.Width = 62;
            // 
            // ColumnWeight
            // 
            this.ColumnWeight.DataPropertyName = "Weight";
            this.ColumnWeight.HeaderText = "单重";
            this.ColumnWeight.Name = "ColumnWeight";
            this.ColumnWeight.ReadOnly = true;
            this.ColumnWeight.Width = 62;
            // 
            // ColumnOperatorUser
            // 
            this.ColumnOperatorUser.DataPropertyName = "OperatorUser";
            this.ColumnOperatorUser.HeaderText = "保管员";
            this.ColumnOperatorUser.Name = "ColumnOperatorUser";
            this.ColumnOperatorUser.ReadOnly = true;
            this.ColumnOperatorUser.Width = 76;
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(756, 609);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 40);
            this.btnDel.TabIndex = 33;
            this.btnDel.Text = "作废";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(862, 609);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 34;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dataGridViewSTOrigin
            // 
            this.dataGridViewSTOrigin.AllowUserToAddRows = false;
            this.dataGridViewSTOrigin.AllowUserToResizeRows = false;
            this.dataGridViewSTOrigin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSTOrigin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSTOrigin.ColumnHeadersHeight = 30;
            this.dataGridViewSTOrigin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSTOrigin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItemNo,
            this.ColumnPlantS,
            this.ColumnSLocationS,
            this.ColumnMaterialS,
            this.ColumnBNumberS,
            this.ColumnBinS,
            this.ColumnBinCountS,
            this.ColumnBarCodeS,
            this.ColumnOperatorUserS,
            this.ColumnOperatorDateTimeS});
            this.dataGridViewSTOrigin.Location = new System.Drawing.Point(12, 214);
            this.dataGridViewSTOrigin.MultiSelect = false;
            this.dataGridViewSTOrigin.Name = "dataGridViewSTOrigin";
            this.dataGridViewSTOrigin.ReadOnly = true;
            this.dataGridViewSTOrigin.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewSTOrigin.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSTOrigin.RowTemplate.Height = 23;
            this.dataGridViewSTOrigin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSTOrigin.Size = new System.Drawing.Size(950, 389);
            this.dataGridViewSTOrigin.TabIndex = 35;
            this.dataGridViewSTOrigin.SelectionChanged += new System.EventHandler(this.dataGridViewSTOrigin_SelectionChanged);
            // 
            // ColumnItemNo
            // 
            this.ColumnItemNo.DataPropertyName = "ItemNo";
            this.ColumnItemNo.HeaderText = "ItemNo";
            this.ColumnItemNo.Name = "ColumnItemNo";
            this.ColumnItemNo.ReadOnly = true;
            this.ColumnItemNo.Visible = false;
            this.ColumnItemNo.Width = 84;
            // 
            // ColumnPlantS
            // 
            this.ColumnPlantS.DataPropertyName = "Plant";
            this.ColumnPlantS.HeaderText = "所属库存账套";
            this.ColumnPlantS.Name = "ColumnPlantS";
            this.ColumnPlantS.ReadOnly = true;
            this.ColumnPlantS.Width = 90;
            // 
            // ColumnSLocationS
            // 
            this.ColumnSLocationS.DataPropertyName = "SLocation";
            this.ColumnSLocationS.HeaderText = "存储地点";
            this.ColumnSLocationS.Name = "ColumnSLocationS";
            this.ColumnSLocationS.ReadOnly = true;
            this.ColumnSLocationS.Width = 90;
            // 
            // ColumnMaterialS
            // 
            this.ColumnMaterialS.DataPropertyName = "Material";
            this.ColumnMaterialS.HeaderText = "物料号";
            this.ColumnMaterialS.Name = "ColumnMaterialS";
            this.ColumnMaterialS.ReadOnly = true;
            this.ColumnMaterialS.Width = 76;
            // 
            // ColumnBNumberS
            // 
            this.ColumnBNumberS.DataPropertyName = "BNumber";
            this.ColumnBNumberS.HeaderText = "批次号";
            this.ColumnBNumberS.Name = "ColumnBNumberS";
            this.ColumnBNumberS.ReadOnly = true;
            this.ColumnBNumberS.Width = 76;
            // 
            // ColumnBinS
            // 
            this.ColumnBinS.DataPropertyName = "Bin";
            this.ColumnBinS.HeaderText = "储位";
            this.ColumnBinS.Name = "ColumnBinS";
            this.ColumnBinS.ReadOnly = true;
            this.ColumnBinS.Width = 62;
            // 
            // ColumnBinCountS
            // 
            this.ColumnBinCountS.DataPropertyName = "BinCount";
            this.ColumnBinCountS.HeaderText = "数量";
            this.ColumnBinCountS.Name = "ColumnBinCountS";
            this.ColumnBinCountS.ReadOnly = true;
            this.ColumnBinCountS.Width = 62;
            // 
            // ColumnBarCodeS
            // 
            this.ColumnBarCodeS.DataPropertyName = "BarCode";
            this.ColumnBarCodeS.HeaderText = "条码号";
            this.ColumnBarCodeS.Name = "ColumnBarCodeS";
            this.ColumnBarCodeS.ReadOnly = true;
            this.ColumnBarCodeS.Width = 76;
            // 
            // ColumnOperatorUserS
            // 
            this.ColumnOperatorUserS.DataPropertyName = "OperatorUser";
            this.ColumnOperatorUserS.HeaderText = "盘点员";
            this.ColumnOperatorUserS.Name = "ColumnOperatorUserS";
            this.ColumnOperatorUserS.ReadOnly = true;
            this.ColumnOperatorUserS.Width = 76;
            // 
            // ColumnOperatorDateTimeS
            // 
            this.ColumnOperatorDateTimeS.DataPropertyName = "OperatorDateTime";
            this.ColumnOperatorDateTimeS.HeaderText = "盘点日时";
            this.ColumnOperatorDateTimeS.Name = "ColumnOperatorDateTimeS";
            this.ColumnOperatorDateTimeS.ReadOnly = true;
            this.ColumnOperatorDateTimeS.Width = 90;
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(544, 609);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 36;
            this.btnMod.Text = "调整";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(650, 609);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // 盘点对照明细信息
            // 
            this.ClientSize = new System.Drawing.Size(974, 661);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.dataGridViewSTOrigin);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.dataGridViewSapStockInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "盘点对照明细信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "盘点对照明细信息";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSTOrigin)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 盘点对照明细信息(UserInfo userItem, ArrayList userRoles, ArrayList adjustItem)
        {
            this.userItem = null;
            this.userRoles = null;
            this.adjustItem = null;
            dsAdjustItem = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.adjustItem = adjustItem;
            dataGridViewSapStockInfo.AutoGenerateColumns = false;
            dataGridViewSTOrigin.AutoGenerateColumns = false;

            if (!this.userItem.isAdmin)
            {
                btnAdd.Enabled = false;
            }

            FlushDate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ArrayList stOriginItem = new ArrayList();

            if (CommonFunction.IfHasData(dsAdjustItem.Tables[1]))
            {
                stOriginItem.Add(dsAdjustItem.Tables[1].Rows[0]["STSerial"]);
                stOriginItem.Add(dsAdjustItem.Tables[1].Rows[0]["Plant"].ToString());
                stOriginItem.Add(dsAdjustItem.Tables[1].Rows[0]["SLocation"].ToString());
                stOriginItem.Add(dsAdjustItem.Tables[1].Rows[0]["Material"].ToString());
                stOriginItem.Add(dsAdjustItem.Tables[1].Rows[0]["BNumber"].ToString());
                stOriginItem.Add(dsAdjustItem.Tables[1].Rows[0]["BarCode"].ToString());
                stOriginItem.Add(dsAdjustItem.Tables[1].Rows[0]["OperatorUser"].ToString());
                stOriginItem.Add(DateTime.Now);
            }
            else
            {
                stOriginItem.Add(dsAdjustItem.Tables[0].Rows[0]["STSerial"]);
                stOriginItem.Add(dsAdjustItem.Tables[0].Rows[0]["Plant"].ToString());
                stOriginItem.Add(dsAdjustItem.Tables[0].Rows[0]["SLocation"].ToString());
                stOriginItem.Add(dsAdjustItem.Tables[0].Rows[0]["Material"].ToString());
                stOriginItem.Add(dsAdjustItem.Tables[0].Rows[0]["BNumber"].ToString());
                stOriginItem.Add("");
                stOriginItem.Add(dsAdjustItem.Tables[0].Rows[0]["OperatorUser"].ToString());
                stOriginItem.Add(DateTime.Now);
            }

            盘点条目明细信息 frm = new 盘点条目明细信息(stOriginItem);
            frm.Text = "盘点条目信息新增";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                FlushDate();
            }

            GetDiffrient();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("继续本操作将作废被选择条目，是否继续？") && (DBOperate.BlankOutSTOrigin(Convert.ToInt32(this.dataGridViewSTOrigin.SelectedRows[0].Cells["ColumnItemNo"].Value)) != -1))
            {
                CommonFunction.Sys_MsgBox("条目信息作废成功");
                FlushDate();
            }

            GetDiffrient();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            ArrayList stOriginItem = new ArrayList();
            stOriginItem.Add(dataGridViewSTOrigin.SelectedRows[0].Cells["ColumnItemNo"].Value.ToString());

            foreach (DataGridViewCell cell in dataGridViewSTOrigin.SelectedRows[0].Cells)
            {
                stOriginItem.Add(cell.Value);
            }

            stOriginItem.Add(dataGridViewSTOrigin.SelectedRows[0].Cells[0].Value);
            stOriginItem.RemoveAt(1);
            stOriginItem[8] = userItem.userID;

            盘点条目明细信息 frm = new 盘点条目明细信息(stOriginItem);
            frm.Text = "盘点条目信息修改";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow row = dsAdjustItem.Tables[1].Select("ItemNo=" + dataGridViewSTOrigin.SelectedRows[0].Cells["ColumnItemNo"].Value.ToString())[0];
                row["SLocation"] = frm.STOriginItem[2];
                row["Bin"] = frm.STOriginItem[5];
                row["BinCount"] = frm.STOriginItem[6];
            }

            GetDiffrient();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void dataGridViewSTOrigin_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewSTOrigin.Rows != null) && (dataGridViewSTOrigin.SelectedRows.Count != 0))
            {
                btnMod.Enabled = true;
                btnDel.Enabled = true;
            }
            else
            {
                btnMod.Enabled = false;
                btnDel.Enabled = false;
            }
        }

        private void FlushDate()
        {
            dsAdjustItem = DBOperate.CompareInfo(adjustItem);
            dataGridViewSapStockInfo.DataSource = dsAdjustItem.Tables[0];
            dataGridViewSTOrigin.DataSource = dsAdjustItem.Tables[1];
            GetDiffrient();
        }

        private void GetDiffrient()
        {
            decimal num = 0M;

            foreach (DataRow row in dsAdjustItem.Tables[1].Rows)
            {
                num += Convert.ToDecimal(row["BinCount"]);
            }
        }
    }
}
