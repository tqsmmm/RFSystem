using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using RFSystem.CommonClass;
using RFSystem.AnSteel;

namespace RFSystem.Statistic
{
    public class 数据同步 : Form
    {
        // Fields
        private Button btnDownload;
        private Button btnExit;
        private Button btnUpdate;
        private DataGridViewTextBoxColumn ColumnBct1;
        private DataGridViewTextBoxColumn ColumnBct60;
        private DataGridViewTextBoxColumn ColumnBct61;
        private DataGridViewTextBoxColumn ColumnBct70;
        private DataGridViewTextBoxColumn ColumnBct71;
        private DataGridViewTextBoxColumn ColumnBillNo;
        private DataGridViewTextBoxColumn ColumnBIN;
        private DataGridViewTextBoxColumn ColumnFACT_NO;
        private DataGridViewTextBoxColumn ColumnMenge;
        private DataGridViewTextBoxColumn ColumnPATCH_NO;
        private DataGridViewTextBoxColumn ColumnPName;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NAME;
        private DataGridViewTextBoxColumn ColumnPRODUCT_NO;
        private DataGridViewTextBoxColumn ColumnSLocation;
        private DataGridViewTextBoxColumn ColumnStoreManDetail;
        private DataGridViewTextBoxColumn ColumnSUPPLIER_NO;
        private DataGridViewTextBoxColumn ColumnUNIT;
        private DataGridViewTextBoxColumn ColumnVerpr;
        private DataGridViewTextBoxColumn ColumnWeight;
        private ComboBox comboBoxPlant;
        private ComboBox comboBoxSLocation;
        private DataGridView dataGridViewSapStockInfo;
        private DataSet dsResult;
        private DataTable dtPlantList;
        private DataTable dtStoreLocusList;
        private GroupBox groupBox1;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private RadioButton radioButtonSLocation;
        private RadioButton radioButtonStoreMan;
        private TextBox textBoxBin;
        private TextBox textBoxStoreMan;
        private Thread thread;
        private UserInfo userItem;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.radioButtonSLocation = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.radioButtonStoreMan = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridViewSapStockInfo = new System.Windows.Forms.DataGridView();
            this.ColumnFACT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPATCH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBct71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStoreManDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSUPPLIER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVerpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMenge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxBin);
            this.groupBox1.Controls.Add(this.textBoxStoreMan);
            this.groupBox1.Controls.Add(this.radioButtonSLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxSLocation);
            this.groupBox1.Controls.Add(this.radioButtonStoreMan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxPlant);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1031, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(773, 35);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.ReadOnly = true;
            this.textBoxBin.Size = new System.Drawing.Size(90, 26);
            this.textBoxBin.TabIndex = 50;
            this.textBoxBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.Location = new System.Drawing.Point(208, 35);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.Size = new System.Drawing.Size(120, 26);
            this.textBoxStoreMan.TabIndex = 20;
            this.textBoxStoreMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // radioButtonSLocation
            // 
            this.radioButtonSLocation.AutoSize = true;
            this.radioButtonSLocation.Location = new System.Drawing.Point(6, 55);
            this.radioButtonSLocation.Name = "radioButtonSLocation";
            this.radioButtonSLocation.Size = new System.Drawing.Size(97, 24);
            this.radioButtonSLocation.TabIndex = 10;
            this.radioButtonSLocation.Text = "按货位同步";
            this.radioButtonSLocation.UseVisualStyleBackColor = true;
            this.radioButtonSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "保管员码：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.Enabled = false;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(596, 35);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(100, 28);
            this.comboBoxSLocation.TabIndex = 40;
            this.comboBoxSLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // radioButtonStoreMan
            // 
            this.radioButtonStoreMan.AutoSize = true;
            this.radioButtonStoreMan.Checked = true;
            this.radioButtonStoreMan.Location = new System.Drawing.Point(6, 25);
            this.radioButtonStoreMan.Name = "radioButtonStoreMan";
            this.radioButtonStoreMan.Size = new System.Drawing.Size(111, 24);
            this.radioButtonStoreMan.TabIndex = 10;
            this.radioButtonStoreMan.TabStop = true;
            this.radioButtonStoreMan.Text = "按管理员同步";
            this.radioButtonStoreMan.UseVisualStyleBackColor = true;
            this.radioButtonStoreMan.CheckedChanged += new System.EventHandler(this.radioButtonStoreMan_CheckedChanged);
            this.radioButtonStoreMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(511, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "库存地点：";
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(914, 28);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(100, 40);
            this.btnDownload.TabIndex = 60;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            this.btnDownload.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "公司号：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.Enabled = false;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(405, 35);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(100, 28);
            this.comboBoxPlant.TabIndex = 30;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            this.comboBoxPlant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(702, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 63;
            this.label3.Text = "货位号：";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(943, 573);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 10001;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(837, 573);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 10000;
            this.btnUpdate.Text = "同步";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.ColumnFACT_NO,
            this.ColumnPRODUCT_NO,
            this.ColumnPATCH_NO,
            this.ColumnSLocation,
            this.ColumnPRODUCT_NAME,
            this.ColumnUNIT,
            this.ColumnBIN,
            this.ColumnBct1,
            this.ColumnBct60,
            this.ColumnBct61,
            this.ColumnBct70,
            this.ColumnBct71,
            this.ColumnStoreManDetail,
            this.ColumnSUPPLIER_NO,
            this.ColumnBillNo,
            this.ColumnPName,
            this.ColumnWeight,
            this.ColumnVerpr,
            this.ColumnMenge});
            this.dataGridViewSapStockInfo.Location = new System.Drawing.Point(12, 108);
            this.dataGridViewSapStockInfo.MultiSelect = false;
            this.dataGridViewSapStockInfo.Name = "dataGridViewSapStockInfo";
            this.dataGridViewSapStockInfo.ReadOnly = true;
            this.dataGridViewSapStockInfo.RowHeadersVisible = false;
            this.dataGridViewSapStockInfo.RowTemplate.Height = 23;
            this.dataGridViewSapStockInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSapStockInfo.Size = new System.Drawing.Size(1031, 459);
            this.dataGridViewSapStockInfo.TabIndex = 30002;
            this.dataGridViewSapStockInfo.SelectionChanged += new System.EventHandler(this.dataGridViewSapStockInfo_SelectionChanged);
            // 
            // ColumnFACT_NO
            // 
            this.ColumnFACT_NO.DataPropertyName = "Werks";
            this.ColumnFACT_NO.HeaderText = "公司号";
            this.ColumnFACT_NO.Name = "ColumnFACT_NO";
            this.ColumnFACT_NO.ReadOnly = true;
            this.ColumnFACT_NO.Width = 76;
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
            this.ColumnBIN.DataPropertyName = "Bct50";
            this.ColumnBIN.HeaderText = "货位1";
            this.ColumnBIN.Name = "ColumnBIN";
            this.ColumnBIN.ReadOnly = true;
            this.ColumnBIN.Width = 70;
            // 
            // ColumnBct1
            // 
            this.ColumnBct1.DataPropertyName = "Bct51";
            this.ColumnBct1.HeaderText = "货位1数量";
            this.ColumnBct1.Name = "ColumnBct1";
            this.ColumnBct1.ReadOnly = true;
            this.ColumnBct1.Width = 98;
            // 
            // ColumnBct60
            // 
            this.ColumnBct60.DataPropertyName = "Bct60";
            this.ColumnBct60.HeaderText = "货位2";
            this.ColumnBct60.Name = "ColumnBct60";
            this.ColumnBct60.ReadOnly = true;
            this.ColumnBct60.Width = 70;
            // 
            // ColumnBct61
            // 
            this.ColumnBct61.DataPropertyName = "Bct61";
            this.ColumnBct61.HeaderText = "货位2数量";
            this.ColumnBct61.Name = "ColumnBct61";
            this.ColumnBct61.ReadOnly = true;
            this.ColumnBct61.Width = 98;
            // 
            // ColumnBct70
            // 
            this.ColumnBct70.DataPropertyName = "Bct70";
            this.ColumnBct70.HeaderText = "货位3";
            this.ColumnBct70.Name = "ColumnBct70";
            this.ColumnBct70.ReadOnly = true;
            this.ColumnBct70.Width = 70;
            // 
            // ColumnBct71
            // 
            this.ColumnBct71.DataPropertyName = "Bct71";
            this.ColumnBct71.HeaderText = "货位3数量";
            this.ColumnBct71.Name = "ColumnBct71";
            this.ColumnBct71.ReadOnly = true;
            this.ColumnBct71.Width = 98;
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
            this.ColumnSUPPLIER_NO.Width = 90;
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
            // 数据同步
            // 
            this.ClientSize = new System.Drawing.Size(1055, 625);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewSapStockInfo);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "数据同步";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据同步";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSapStockInfo)).EndInit();
            this.ResumeLayout(false);

        }

        // Methods
        public 数据同步(UserInfo userItem, ArrayList userRoles)
        {
            this.userItem = null;
            this.userRoles = null;
            this.dtPlantList = null;
            this.dtStoreLocusList = null;
            this.thread = null;
            this.InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.textBoxStoreMan.Text = this.userItem.userID;

            if (userItem.isAdmin)
            {
                this.textBoxStoreMan.ReadOnly = false;
            }

            this.dtPlantList = DBOperate.GetPlantList(string.Empty);
            this.dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, string.Empty);
            this.comboBoxSLocation.Items.Add("无");
            this.comboBoxSLocation.SelectedIndex = 0;
            this.comboBoxPlant.Items.Add("无");

            if (CommonFunction.IfHasData(this.dtPlantList))
            {
                foreach (DataRow row in this.dtPlantList.Rows)
                {
                    this.comboBoxPlant.Items.Add(row["PlantID"].ToString());
                }
            }

            this.comboBoxPlant.SelectedIndex = 0;
            this.dataGridViewSapStockInfo.AutoGenerateColumns = false;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Equals("下载"))
            {
                this.thread = new Thread(new ThreadStart(this.ShowWaitingMsg));
                this.thread.Start();
            }
            else
            {
                this.SetControlsState(true);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables.Count == 0)
            {
                CommonFunction.Sys_MsgBox("请先检索数据");
            }
            else if (dsResult.Tables["Detail"].Rows.Count == 0)
            {
                CommonFunction.Sys_MsgBox("更新数据为空不可更新");
            }
            else
            {
                string str;
                bool flag;

                if (radioButtonStoreMan.Checked)
                {
                    str = textBoxStoreMan.Text.Trim();
                    flag = true;
                }
                else
                {
                    str = textBoxBin.Text.Trim();
                    flag = false;
                }

                if (DBOperate.UpdateStock(dsResult.Tables["Detail"], str, flag).Equals("-1"))
                {
                    CommonFunction.Sys_MsgBox("更新失败");
                }
                else
                {
                    CommonFunction.Sys_MsgBox("数据同步成功");
                    SetControlsState(true);
                }
            }
        }

        private void comboBoxPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxSLocation.Items.Clear();
            this.comboBoxSLocation.Items.Add("无");

            foreach (DataRow row in this.dtStoreLocusList.Select("PlantID='" + this.comboBoxPlant.Text + "'"))
            {
                this.comboBoxSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            this.comboBoxSLocation.SelectedIndex = 0;
        }

        private void dataGridViewSapStockInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewSapStockInfo.Rows != null) && (this.dataGridViewSapStockInfo.SelectedRows.Count != 0))
            {
                this.btnUpdate.Enabled = true;
            }
            else
            {
                this.btnUpdate.Enabled = false;
            }
        }

        private Control GetNextSelectControl(Control activeControl)
        {
            Control nextControl = null;
            nextControl = base.GetNextControl(activeControl, true);

            if ((!nextControl.Enabled || !nextControl.TabStop) || (nextControl.TabStop && !nextControl.CanSelect))
            {
                nextControl = this.GetNextSelectControl(nextControl);
            }

            return nextControl;
        }

        private void radioButtonStoreMan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonStoreMan.Checked)
            {
                this.comboBoxPlant.Enabled = false;
                this.comboBoxSLocation.Enabled = false;
                this.textBoxBin.ReadOnly = true;
                this.comboBoxPlant.SelectedIndex = 0;
                this.comboBoxSLocation.SelectedIndex = 0;
                this.textBoxBin.Text = string.Empty;
            }
            else
            {
                this.comboBoxPlant.Enabled = true;
                this.comboBoxSLocation.Enabled = true;
                this.textBoxBin.ReadOnly = false;
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.GetNextSelectControl(base.ActiveControl).Focus();
            }
        }

        private void SetControlsState(bool controlsEnable)
        {
            try
            {
                this.radioButtonStoreMan.Enabled = controlsEnable;
                this.radioButtonSLocation.Enabled = controlsEnable;
                this.textBoxStoreMan.Enabled = controlsEnable;
                this.textBoxBin.Enabled = controlsEnable;

                if (controlsEnable)
                {
                    this.comboBoxPlant.Enabled = this.radioButtonSLocation.Checked;
                    this.comboBoxSLocation.Enabled = this.radioButtonSLocation.Checked;
                    this.btnDownload.Text = "下载";
                }
                else
                {
                    this.comboBoxPlant.Enabled = controlsEnable;
                    this.comboBoxSLocation.Enabled = controlsEnable;
                    this.btnDownload.Text = "重新下载";
                }

                if (controlsEnable)
                {
                    this.dsResult.Tables["Detail"].Rows.Clear();
                }
            }
            catch
            {
                this.dsResult = null;
            }
        }

        private void ShowMsg(object o, EventArgs e)
        {
            if (this.textBoxStoreMan.Text.Trim() == "")
            {
                CommonFunction.Sys_MsgBox("请输入正确管理员码");
                return;
            }
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.radioButtonStoreMan.Checked)
                {
                    if (this.textBoxStoreMan.Text.Trim() == "")
                    {
                        CommonFunction.Sys_MsgBox("请输入正确管理员码");
                    }
                    else
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            MessagePack bGYInfo = Utility.getSerive().GetBGYInfo(this.textBoxStoreMan.Text.Trim(), out this.dsResult);

                            if (bGYInfo.Code != 0)
                            {
                                Cursor.Current = Cursors.Default;
                                CommonFunction.Sys_MsgBox(bGYInfo.Message);
                                return;
                            }

                            this.dsResult.Tables["Detail"].Columns["Clabs"].ColumnName = "Menge";
                            this.dataGridViewSapStockInfo.DataSource = this.dsResult.Tables["Detail"];
                            this.dsResult.WriteXml("d:\\111.xml");

                            Cursor.Current = Cursors.Default;
                        }
                        catch (Exception exception)
                        {
                            Cursor.Current = Cursors.Default;
                            CommonFunction.Sys_MsgBox(exception.Message);
                            return;
                        }

                        this.SetControlsState(false);
                    }
                }
                else
                {
                    this.dsResult = new DataSet();
                    MessagePack pack2 = new MessagePack();

                    try
                    {
                        pack2 = Utility.getSerive().GetHWCXInfo(this.textBoxStoreMan.Text.Trim(), this.textBoxBin.Text.Trim(), this.comboBoxSLocation.Text.Trim(), this.comboBoxPlant.Text.Trim(), out this.dsResult);

                        if (pack2.Code != 0)
                        {
                            Cursor.Current = Cursors.Default;
                            CommonFunction.Sys_MsgBox(pack2.Message);
                            return;
                        }

                        this.dataGridViewSapStockInfo.DataSource = this.dsResult.Tables["Detail"];
                        Cursor.Current = Cursors.Default;
                    }
                    catch
                    {
                        Cursor.Current = Cursors.Default;
                        CommonFunction.Sys_MsgBox(pack2.Message);
                        return;
                    }
                    this.SetControlsState(false);
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
            base.Invoke(new EventHandler(this.ShowMsg));
        }
    }
}
