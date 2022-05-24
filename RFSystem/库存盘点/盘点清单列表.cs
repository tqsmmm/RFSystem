using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BL;
using System.Collections;
using RFSystem.CommonClass;

namespace RFSystem
{
    public class 盘点清单列表 : Form
    {
        // Fields
        private Button btDel;
        private Button btnCollate;
        private Button btnEntry;
        private Button btnOperate;
        private Button btnReport;
        private Button btnTheoryAmount;
        private Button btReflash;
        private 理论库存信息 dataInStore;
        private DataSet ds;
        private DataGridView dtVDetail;
        private DataGridView dtVHead;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Hashtable hs;
        private 盘点对照 invertoryCompare;
        private 盘点条目 invertoryData;
        private 盘点报表 invertoryReport;
        private DataTable m_DetailDt;
        private DataView m_DsvDetail;
        private DataView m_DsvHead;
        private string m_ErrMsg;
        private DataTable m_HeadDt;
        private UserInfo userItem;
        private DateTimePicker dateTimePickerTableMakeDateTo;
        private DateTimePicker dateTimePickerTableMakeDateFrom;
        private Label label10;
        private Label label1;
        private Button btn_query;
        private Button btn_tohis;
        private Button button1;
        private GroupBox groupBox3;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.dtVHead = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtVDetail = new System.Windows.Forms.DataGridView();
            this.btDel = new System.Windows.Forms.Button();
            this.btReflash = new System.Windows.Forms.Button();
            this.btnOperate = new System.Windows.Forms.Button();
            this.btnTheoryAmount = new System.Windows.Forms.Button();
            this.btnEntry = new System.Windows.Forms.Button();
            this.btnCollate = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.dateTimePickerTableMakeDateTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTableMakeDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.btn_tohis = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtVHead)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtVDetail)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtVHead
            // 
            this.dtVHead.AllowUserToAddRows = false;
            this.dtVHead.AllowUserToDeleteRows = false;
            this.dtVHead.AllowUserToResizeRows = false;
            this.dtVHead.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtVHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVHead.Location = new System.Drawing.Point(3, 22);
            this.dtVHead.MultiSelect = false;
            this.dtVHead.Name = "dtVHead";
            this.dtVHead.ReadOnly = true;
            this.dtVHead.RowHeadersVisible = false;
            this.dtVHead.RowTemplate.Height = 23;
            this.dtVHead.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtVHead.Size = new System.Drawing.Size(942, 237);
            this.dtVHead.TabIndex = 3;
            this.dtVHead.SelectionChanged += new System.EventHandler(this.dtVHead_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtVHead);
            this.groupBox1.Location = new System.Drawing.Point(118, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(948, 262);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盘点清单列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtVDetail);
            this.groupBox2.Location = new System.Drawing.Point(118, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 247);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "盘点清单详细";
            // 
            // dtVDetail
            // 
            this.dtVDetail.AllowUserToAddRows = false;
            this.dtVDetail.AllowUserToDeleteRows = false;
            this.dtVDetail.AllowUserToResizeRows = false;
            this.dtVDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVDetail.Location = new System.Drawing.Point(3, 22);
            this.dtVDetail.MultiSelect = false;
            this.dtVDetail.Name = "dtVDetail";
            this.dtVDetail.ReadOnly = true;
            this.dtVDetail.RowHeadersVisible = false;
            this.dtVDetail.RowTemplate.Height = 23;
            this.dtVDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtVDetail.Size = new System.Drawing.Size(942, 222);
            this.dtVDetail.TabIndex = 3;
            // 
            // btDel
            // 
            this.btDel.Location = new System.Drawing.Point(12, 58);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(100, 40);
            this.btDel.TabIndex = 9;
            this.btDel.Text = "作废单据";
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btReflash
            // 
            this.btReflash.Location = new System.Drawing.Point(12, 380);
            this.btReflash.Name = "btReflash";
            this.btReflash.Size = new System.Drawing.Size(100, 40);
            this.btReflash.TabIndex = 10;
            this.btReflash.Text = "刷新";
            this.btReflash.UseVisualStyleBackColor = true;
            this.btReflash.Click += new System.EventHandler(this.btReflash_Click);
            // 
            // btnOperate
            // 
            this.btnOperate.Location = new System.Drawing.Point(12, 12);
            this.btnOperate.Name = "btnOperate";
            this.btnOperate.Size = new System.Drawing.Size(100, 40);
            this.btnOperate.TabIndex = 11;
            this.btnOperate.Text = "进行盘点";
            this.btnOperate.UseVisualStyleBackColor = true;
            this.btnOperate.Click += new System.EventHandler(this.btnOperate_Click);
            // 
            // btnTheoryAmount
            // 
            this.btnTheoryAmount.Location = new System.Drawing.Point(12, 104);
            this.btnTheoryAmount.Name = "btnTheoryAmount";
            this.btnTheoryAmount.Size = new System.Drawing.Size(100, 40);
            this.btnTheoryAmount.TabIndex = 12;
            this.btnTheoryAmount.Text = "理论库存";
            this.btnTheoryAmount.UseVisualStyleBackColor = true;
            this.btnTheoryAmount.Click += new System.EventHandler(this.btnTheoryAmount_Click);
            // 
            // btnEntry
            // 
            this.btnEntry.Location = new System.Drawing.Point(12, 150);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Size = new System.Drawing.Size(100, 40);
            this.btnEntry.TabIndex = 13;
            this.btnEntry.Text = "盘点条目";
            this.btnEntry.UseVisualStyleBackColor = true;
            this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click);
            // 
            // btnCollate
            // 
            this.btnCollate.Location = new System.Drawing.Point(12, 196);
            this.btnCollate.Name = "btnCollate";
            this.btnCollate.Size = new System.Drawing.Size(100, 40);
            this.btnCollate.TabIndex = 14;
            this.btnCollate.Text = "盘点对照";
            this.btnCollate.UseVisualStyleBackColor = true;
            this.btnCollate.Click += new System.EventHandler(this.btnCollate_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(12, 242);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 40);
            this.btnReport.TabIndex = 15;
            this.btnReport.Text = "盘点报表";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dateTimePickerTableMakeDateTo
            // 
            this.dateTimePickerTableMakeDateTo.Location = new System.Drawing.Point(309, 32);
            this.dateTimePickerTableMakeDateTo.Name = "dateTimePickerTableMakeDateTo";
            this.dateTimePickerTableMakeDateTo.Size = new System.Drawing.Size(140, 26);
            this.dateTimePickerTableMakeDateTo.TabIndex = 74;
            this.dateTimePickerTableMakeDateTo.ValueChanged += new System.EventHandler(this.dateTimePickerTableMakeDateFrom_ValueChanged);
            // 
            // dateTimePickerTableMakeDateFrom
            // 
            this.dateTimePickerTableMakeDateFrom.Location = new System.Drawing.Point(129, 32);
            this.dateTimePickerTableMakeDateFrom.Name = "dateTimePickerTableMakeDateFrom";
            this.dateTimePickerTableMakeDateFrom.Size = new System.Drawing.Size(140, 26);
            this.dateTimePickerTableMakeDateFrom.TabIndex = 73;
            this.dateTimePickerTableMakeDateFrom.ValueChanged += new System.EventHandler(this.dateTimePickerTableMakeDateFrom_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(275, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 20);
            this.label10.TabIndex = 71;
            this.label10.Text = "TO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 72;
            this.label1.Text = "盘点日期：";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(455, 25);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(100, 40);
            this.btn_query.TabIndex = 75;
            this.btn_query.Text = "查　　询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_tohis
            // 
            this.btn_tohis.Location = new System.Drawing.Point(12, 288);
            this.btn_tohis.Name = "btn_tohis";
            this.btn_tohis.Size = new System.Drawing.Size(100, 40);
            this.btn_tohis.TabIndex = 134;
            this.btn_tohis.Text = "批量转移";
            this.btn_tohis.UseVisualStyleBackColor = true;
            this.btn_tohis.Click += new System.EventHandler(this.btn_tohis_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 135;
            this.button1.Text = "移至历史库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateFrom);
            this.groupBox3.Controls.Add(this.btn_query);
            this.groupBox3.Controls.Add(this.dateTimePickerTableMakeDateTo);
            this.groupBox3.Location = new System.Drawing.Point(118, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(948, 80);
            this.groupBox3.TabIndex = 136;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // 盘点清单列表
            // 
            this.ClientSize = new System.Drawing.Size(1078, 625);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_tohis);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCollate);
            this.Controls.Add(this.btnEntry);
            this.Controls.Add(this.btnTheoryAmount);
            this.Controls.Add(this.btnOperate);
            this.Controls.Add(this.btReflash);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "盘点清单列表";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盘点清单列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dtVHead)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtVDetail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        // Methods
        public 盘点清单列表(UserInfo userItem, ArrayList userRoles)
        {
            userItem = null;
            this.userRoles = null;
            m_ErrMsg = "";
            m_HeadDt = null;
            m_DsvHead = null;
            m_DetailDt = null;
            m_DsvDetail = null;
            ds = new DataSet();
            hs = new Hashtable();
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            Load += new EventHandler(盘点清单列表_Load);
        }

        private void BindDetail()
        {
            m_DsvDetail = new DataView(m_DetailDt);
            dtVDetail.DataSource = m_DsvDetail;
            dtVDetail.Columns["STSerial"].HeaderText = "盘点序号";
            dtVDetail.Columns["OperatorUser"].HeaderText = "参与盘点员工";
        }

        private void BindHead()
        {
            m_DsvHead = new DataView(m_HeadDt);
            dtVHead.DataSource = m_DsvHead;
            m_DsvHead.RowFilter = "STStatus <>-1";
            dtVHead.Columns["STSerial"].HeaderText = "盘点序号";
            dtVHead.Columns["STStatus"].HeaderText = "盘点状态";
            dtVHead.Columns["STCreateUser"].HeaderText = "盘点创建人";
            dtVHead.Columns["STType"].HeaderText = "盘点类型";
            dtVHead.Columns["STCreateDate"].HeaderText = "盘点创建时间";
            dtVHead.Columns["STDesc"].HeaderText = "盘点描述";
            dtVHead.Columns["Plant"].HeaderText = "公司";
            dtVHead.Columns["DocumentID"].HeaderText = "SAP盘点单号";
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dtVHead.SelectedRows.Count <= 0)
            {
                CommonFunction.Sys_MsgBox("请选择要作废的单据号");
            }
            else
            {
                string sTSerial = dtVHead.SelectedRows[0].Cells["STSerial"].Value.ToString();
                string str2 = dtVHead.SelectedRows[0].Cells["STCreateUser"].Value.ToString();
                int num = Convert.ToInt32(dtVHead.SelectedRows[0].Cells["STSTatus"].Value);

                if (str2.Trim() != ConstDefine.g_User.Trim())
                {
                    CommonFunction.Sys_MsgBox("只有创建该单号的用户才能作废该单据");
                }
                else if (num > 0)
                {
                    CommonFunction.Sys_MsgBox("该单据的所处的状态不能被作废");
                }
                else if (CommonFunction.Sys_MsgYN("你确认要作废该单据么？"))
                {
                    if (0 != DBOperate.CancelSTItem(sTSerial, str2, out m_ErrMsg))
                    {
                        CommonFunction.Sys_MsgBox(m_ErrMsg);
                    }
                    else
                    {
                        m_HeadDt.Rows.Remove(m_HeadDt.Select("STSerial=" + sTSerial)[0]);
                        dtVHead_SelectionChanged(null, null);
                    }
                }
            }
        }

        private void btnCollate_Click(object sender, EventArgs e)
        {
            if (ParentForm.MdiChildren.Length <= 1)
            {
                invertoryCompare = new 盘点对照(userItem, userRoles, dtVHead.SelectedRows[0].Cells["STSerial"].Value.ToString());
                invertoryCompare.MdiParent = ParentForm;
                invertoryCompare.Show();
            }
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            if (ParentForm.MdiChildren.Length <= 1)
            {
                invertoryData = new 盘点条目(userItem, userRoles, dtVHead.SelectedRows[0].Cells["STSerial"].Value.ToString());
                invertoryData.MdiParent = ParentForm;
                invertoryData.Show();
            }
        }

        private void btnOperate_Click(object sender, EventArgs e)
        {
            if (dtVHead.SelectedRows.Count <= 0)
            {
                CommonFunction.Sys_MsgBox("请选择要操作的单据号");
            }
            else
            {
                string str = dtVHead.SelectedRows[0].Cells["STSerial"].Value.ToString();
                int num = Convert.ToInt32(dtVHead.SelectedRows[0].Cells["STStatus"].Value);

                if ((num > -1) && (num < 5))
                {
                    new 进行盘点(dtVHead.SelectedRows[0].Cells["STStatus"].Value.ToString(), dtVHead.SelectedRows[0].Cells["STType"].Value.ToString()) { STSerial = str }.ShowDialog();
                    盘点清单列表_Load(null, null);
                }
                else
                {
                    CommonFunction.Sys_MsgBox("该盘点单已经不可操作，请确认");
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (ParentForm.MdiChildren.Length <= 1)
            {
                invertoryReport = new 盘点报表(userItem, userRoles, dtVHead.SelectedRows[0].Cells["STSerial"].Value.ToString(), dtVHead.SelectedRows[0].Cells["STStatus"].Value.ToString());
                invertoryReport.MdiParent = ParentForm;
                invertoryReport.Show();
            }
        }

        private void btnTheoryAmount_Click(object sender, EventArgs e)
        {
            if (ParentForm.MdiChildren.Length <= 1)
            {
                dataInStore = new 理论库存信息(userItem, userRoles, dtVHead.SelectedRows[0].Cells["STSerial"].Value.ToString());
                dataInStore.MdiParent = ParentForm;
                dataInStore.Show();
            }
        }

        private void btReflash_Click(object sender, EventArgs e)
        {
            盘点清单列表_Load(null, null);
        }

        private void dtVHead_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtVHead.SelectedRows.Count > 0)
            {
                string sTSerial = dtVHead.SelectedRows[0].Cells["STSerial"].Value.ToString();

                if (!LoadDetail(sTSerial, out m_DetailDt))
                {
                    CommonFunction.Sys_MsgBox(m_ErrMsg);
                }
                else
                {
                    BindDetail();
                }
            }
        }

        private void dtVHead_SelectionChanged(object sender, EventArgs e)
        {
            if (dtVHead.SelectedRows.Count <= 0)
            {
                SetButtonsEnable(false, false, false, false, false, false);
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                string sTSerial = dtVHead.SelectedRows[0].Cells["STSerial"].Value.ToString();

                if (!LoadDetail(sTSerial, out m_DetailDt))
                {
                    CommonFunction.Sys_MsgBox(m_ErrMsg);
                }
                else
                {
                    BindDetail();
                    string str2 = dtVHead.SelectedRows[0].Cells["STStatus"].Value.ToString();

                    if (str2 != null)
                    {
                        if (!(str2 == "0"))
                        {
                            if (str2 == "1")
                            {
                                SetButtonsEnable(true, true, true, false, false, false);
                            }
                            else if (str2 == "2")
                            {
                                SetButtonsEnable(false, true, true, true, true, false);
                            }
                            else if (str2 == "3")
                            {
                                SetButtonsEnable(false, true, true, true, true, false);
                            }
                            else if (str2 == "4")
                            {
                                if (dtVHead.SelectedRows[0].Cells["STType"].Value.ToString().Equals("1"))
                                {
                                    SetButtonsEnable(false, false, false, false, false, true);
                                }
                                else
                                {
                                    SetButtonsEnable(false, true, false, false, false, true);
                                }
                            }
                            else if (str2 == "5")
                            {
                                SetButtonsEnable(false, false, false, false, false, true);
                            }
                        }
                        else
                        {
                            SetButtonsEnable(true, true, false, false, false, false);
                        }
                    }
                }
            }
        }

        private bool LoadDetail(string STSerial, out DataTable dt)
        {
            if (0 != DBOperate.GetSTItemDetail(STSerial, out dt, out m_ErrMsg))
            {
                return false;
            }

            return true;
        }

        private void SetButtonsEnable(bool delEnabled, bool operateEnabled, bool amountEnabled, bool entryEnabled, bool collateEnable, bool reportEnable)
        {
            delEnabled = delEnabled && dtVHead.SelectedRows[0].Cells["STCreateUser"].Value.ToString().Equals(userItem.userID);
            btDel.Enabled = delEnabled;
            btnOperate.Enabled = operateEnabled;
            btnTheoryAmount.Enabled = amountEnabled;
            btnEntry.Enabled = entryEnabled;
            btnCollate.Enabled = collateEnable;
            btnReport.Enabled = reportEnable;
        }

        private void 盘点清单列表_Load(object sender, EventArgs e)
        {
            if (0 != DBOperate.GetSTItem("", DateTime.Now, out m_HeadDt, out m_ErrMsg))
            {
                CommonFunction.Sys_MsgBox(m_ErrMsg);
            }
            else if (!CommonFunction.IfHasData(m_HeadDt))
            {
                CommonFunction.Sys_MsgBox("没有检索到任何有效单据，请确认");
                SetButtonsEnable(false, false, false, false, false, false);
                button1.Enabled = false;
            }
            else
            {
                BindHead();
                ds.Tables.Add(m_HeadDt);
                hs.Clear();

                for (int i = 0; i < dtVHead.Columns.Count; i++)
                {
                    hs.Add(dtVHead.Columns[i].Name, dtVHead.Columns[i].HeaderText);
                }
            }

            btn_tohis.Enabled = false;
        }

        #region new 

        //查询待转移数据
        private void btn_query_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Cursor.Position = MousePosition;
            ((Button)sender).Enabled = false;
            btn_tohis.Enabled = false;

            try
            {
                DataTable dt = new DataTable();

                if (0 != BL.ClsCommon.GetSTItem_New(dateTimePickerTableMakeDateFrom.Value, dateTimePickerTableMakeDateTo.Value, out dt, out m_ErrMsg))
                {
                    CommonFunction.Sys_MsgBox(m_ErrMsg);
                    return;
                }

                if (!CommonFunction.IfHasData(m_HeadDt))
                {
                    CommonFunction.Sys_MsgBox("没有检索到任何有效单据，请确认");
                    SetButtonsEnable(false, false, false, false, false, false);
                    return;
                }

                BindDgv(dt.DefaultView, dtVHead);

                if (dtVHead.Rows.Count > 0)
                {
                    btn_tohis.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.Sys_MsgBox("操作失败，请稍后重试。失败原因：\r\n" + ex.Message);
            }
            finally
            {
                ((Button)sender).Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        //转移至历史库
        private void btn_tohis_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Cursor.Position = MousePosition;
            ((Button)sender).Enabled = false;

            try
            {
                if (0 != BL.ClsCommon.STItemToHis(dateTimePickerTableMakeDateFrom.Value, dateTimePickerTableMakeDateTo.Value, ConstDefine.g_User))
                {
                    //MessageBox.Show("转移至历史库失败，请稍后重试", "注意", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ((Button)sender).Enabled = true;
                    //return;
                }

                dtVHead.Rows.Clear();
                btn_query_Click(sender, e);
                ((Button)sender).Enabled = false;
            }
            catch
            {
                //MessageBox.Show("操作失败，失败原因：\r\n" + ex.Message, "注意", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((Button)sender).Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            Cursor = Cursors.WaitCursor;

            Cursor.Position = MousePosition;
            ((Button)sender).Enabled = false;
            btn_tohis.Enabled = false;

            try
            {
                DataTable dt = new DataTable();

                if (0 != BL.ClsCommon.GetSTItem_New(dateTimePickerTableMakeDateFrom.Value, dateTimePickerTableMakeDateTo.Value, out dt, out m_ErrMsg))
                {
                    CommonFunction.Sys_MsgBox(m_ErrMsg);
                    return;
                }

                if (!CommonFunction.IfHasData(m_HeadDt))
                {
                    CommonFunction.Sys_MsgBox("没有检索到任何有效单据，请确认");
                    SetButtonsEnable(false, false, false, false, false, false);
                    return;
                }

                BindDgv(dt.DefaultView, dtVHead);

                if (dtVHead.Rows.Count > 0)
                {
                    btn_tohis.Enabled = true;
                }
            }
            catch
            {
                //MessageBox.Show("操作失败，请稍后重试。失败原因：\r\n" + ex.Message, "注意", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                ((Button)sender).Enabled = false;
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 绑定datagridview数据，转移至历史库之前的查询
        /// </summary>
        /// <param name="_DsvHead"></param>
        /// <param name="dgv"></param>
        private void BindDgv(DataView _DsvHead,DataGridView dgv)
        {
            dgv.DataSource = _DsvHead;
            _DsvHead.RowFilter = "STStatus <>-1";
            dgv.Columns["STSerial"].HeaderText = "盘点序号";
            dgv.Columns["STStatus"].HeaderText = "盘点状态";
            dgv.Columns["STCreateUser"].HeaderText = "盘点创建人";
            dgv.Columns["STType"].HeaderText = "盘点类型";
            dgv.Columns["STCreateDate"].HeaderText = "盘点创建时间";
            dgv.Columns["STDesc"].HeaderText = "盘点描述";
            dgv.Columns["Plant"].HeaderText = "公司";
            dgv.Columns["DocumentID"].HeaderText = "SAP盘点单号";
        }
        #endregion

        private void dateTimePickerTableMakeDateFrom_ValueChanged(object sender, EventArgs e)
        {
            btn_tohis.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CommonFunction.Sys_MsgYN("真的删除此条盘点数据吗？"))
            {
                return;
            }

            Cursor = Cursors.WaitCursor;
            Cursor.Position = MousePosition;
            ((Button)sender).Enabled = false;

            try
            {
                if (0 != BL.ClsCommon.STItemToHis_s(dtVHead.SelectedRows[0].Cells["STSerial"].Value.ToString(), ConstDefine.g_User))
                {
                    CommonFunction.Sys_MsgBox("转移至历史库失败，请稍后重试");
                    ((Button)sender).Enabled = true;
                    return;
                }

                dtVHead.Rows.Clear();
                btn_query_Click(sender, e);
                ((Button)sender).Enabled = false;
            }
            catch
            {
                //MessageBox.Show("操作失败，失败原因：\r\n" + ex.Message, "注意", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((Button)sender).Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            Cursor = Cursors.WaitCursor;
            Cursor.Position = MousePosition;
            ((Button)sender).Enabled = false;
            btn_tohis.Enabled = false;

            try
            {
                DataTable dt = new DataTable();

                if (0 != BL.ClsCommon.GetSTItem_New(dateTimePickerTableMakeDateFrom.Value, dateTimePickerTableMakeDateTo.Value, out dt, out m_ErrMsg))
                {
                    CommonFunction.Sys_MsgBox(m_ErrMsg);
                    return;
                }

                if (!CommonFunction.IfHasData(m_HeadDt))
                {
                    CommonFunction.Sys_MsgBox("没有检索到任何有效单据，请确认");
                    SetButtonsEnable(false, false, false, false, false, false);
                    return;
                }

                BindDgv(dt.DefaultView, dtVHead);

                if (dtVHead.Rows.Count > 0)
                {
                    btn_tohis.Enabled = true;
                }
            }
            catch
            {
                //MessageBox.Show("操作失败，请稍后重试。失败原因：\r\n" + ex.Message, "注意", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                ((Button)sender).Enabled = false;
                Cursor = Cursors.Default;
            }
        }
    }
}
