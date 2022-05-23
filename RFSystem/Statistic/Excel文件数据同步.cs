using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using BL;
using System.Collections;
using RFSystem.CommonClass;
using Excel;
using System.Reflection;

namespace RFSystem.Statistic
{
    public class Excel文件数据同步 : Form
    {
        // Fields
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox comboBoxPlant;
        private System.Windows.Forms.ComboBox comboBoxSLocation;
        private System.Windows.Forms.DataGridView dataGridViewStockInfo;
        private System.Data.DataTable dtPlantList;
        private System.Data.DataTable dtStore;
        private System.Data.DataTable dtStoreLocusList;
        private System.Data.DataView dvStore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBoxBin;
        private System.Windows.Forms.TextBox textBoxStoreMan;
        private Thread thread;
        private UserInfo userItem;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.dataGridViewStockInfo = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.textBoxBin = new System.Windows.Forms.TextBox();
            this.textBoxStoreMan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewStockInfo
            // 
            this.dataGridViewStockInfo.AllowUserToAddRows = false;
            this.dataGridViewStockInfo.AllowUserToResizeRows = false;
            this.dataGridViewStockInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStockInfo.ColumnHeadersHeight = 30;
            this.dataGridViewStockInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStockInfo.Location = new System.Drawing.Point(12, 93);
            this.dataGridViewStockInfo.MultiSelect = false;
            this.dataGridViewStockInfo.Name = "dataGridViewStockInfo";
            this.dataGridViewStockInfo.ReadOnly = true;
            this.dataGridViewStockInfo.RowHeadersVisible = false;
            this.dataGridViewStockInfo.RowTemplate.Height = 23;
            this.dataGridViewStockInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockInfo.Size = new System.Drawing.Size(1008, 391);
            this.dataGridViewStockInfo.TabIndex = 30006;
            this.dataGridViewStockInfo.SelectionChanged += new System.EventHandler(this.dataGridViewStockInfo_SelectionChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(814, 490);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 30004;
            this.btnUpdate.Text = "同步";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(920, 490);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 30005;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnOpenFile);
            this.groupBox1.Controls.Add(this.textBoxBin);
            this.groupBox1.Controls.Add(this.textBoxStoreMan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxSLocation);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxPlant);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 75);
            this.groupBox1.TabIndex = 30003;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(6, 25);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(100, 40);
            this.btnOpenFile.TabIndex = 64;
            this.btnOpenFile.Text = "打开文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // textBoxBin
            // 
            this.textBoxBin.Location = new System.Drawing.Point(759, 32);
            this.textBoxBin.Name = "textBoxBin";
            this.textBoxBin.Size = new System.Drawing.Size(100, 26);
            this.textBoxBin.TabIndex = 50;
            // 
            // textBoxStoreMan
            // 
            this.textBoxStoreMan.Location = new System.Drawing.Point(197, 32);
            this.textBoxStoreMan.Name = "textBoxStoreMan";
            this.textBoxStoreMan.ReadOnly = true;
            this.textBoxStoreMan.Size = new System.Drawing.Size(117, 26);
            this.textBoxStoreMan.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "保管员码：";
            // 
            // comboBoxSLocation
            // 
            this.comboBoxSLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLocation.FormattingEnabled = true;
            this.comboBoxSLocation.Location = new System.Drawing.Point(582, 32);
            this.comboBoxSLocation.Name = "comboBoxSLocation";
            this.comboBoxSLocation.Size = new System.Drawing.Size(100, 28);
            this.comboBoxSLocation.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "库存地点：";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(902, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 40);
            this.btnSelect.TabIndex = 60;
            this.btnSelect.Text = "筛选";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "公司号：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(391, 32);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(100, 28);
            this.comboBoxPlant.TabIndex = 30;
            this.comboBoxPlant.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlant_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(688, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 63;
            this.label3.Text = "货位号：";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Excel文件数据同步
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.ClientSize = new System.Drawing.Size(1032, 542);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewStockInfo);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Excel文件数据同步";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel文件数据同步";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        // Methods
        public Excel文件数据同步(UserInfo userItem, ArrayList userRoles)
        {
            this.userItem = null;
            this.userRoles = null;
            this.dtPlantList = null;
            this.dtStoreLocusList = null;
            this.thread = null;

            this.InitializeComponent();// InitializeComponent();

            this.userItem = userItem;
            this.userRoles = userRoles;
            this.dtStore = new System.Data.DataTable();

            for (int i = 0; i < 30; i++)
            {
                this.dtStore.Columns.Add(i.ToString());
            }

            this.textBoxStoreMan.Text = userItem.userID;

            if (userItem.isAdmin)
            {
                this.textBoxStoreMan.ReadOnly = false;
            }

            this.dvStore = this.dtStore.DefaultView;
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
            this.dataGridViewStockInfo.DataSource = this.dvStore;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.thread = new Thread(new ThreadStart(this.ShowWaitingMsg));
                this.thread.Start();
                this.Refresh();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(this.btnSelectShowWaitingMsg));
            this.thread.Start();
        }

        private void btnSelectShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = " 1=1 ";

                if (!string.IsNullOrEmpty(this.textBoxStoreMan.Text.Trim()))
                {
                    str = str + " and 保管员='" + this.textBoxStoreMan.Text.Trim() + "'";
                }

                if (!this.comboBoxPlant.Text.Equals("无"))
                {
                    str = str + " and 工厂='" + this.comboBoxPlant.Text.Trim() + "'";
                }

                if (!this.comboBoxSLocation.Text.Equals("无"))
                {
                    str = str + " and 库存地='" + this.comboBoxSLocation.Text.Trim() + "'";
                }

                if (!string.IsNullOrEmpty(this.textBoxBin.Text.Trim()))
                {
                    string str2 = str;
                    str = str2 + " and (货位1='" + this.textBoxBin.Text.Trim() + "' or 货位2='" + this.textBoxBin.Text.Trim() + "' or 货位3='" + this.textBoxBin.Text.Trim() + "')";
                }

                this.dvStore.RowFilter = str;
            }
            catch
            {
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSelectShowWaitingMsg()
        {
            base.Invoke(new EventHandler(this.btnSelectShowMsg));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DBOperate.ExcelUpdateStock(this.dvStore.ToTable()).Equals("-1"))
            {
                MessageBox.Show("更新失败");
            }
            else
            {
                MessageBox.Show("数据同步成功");
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

        private void dataGridViewStockInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewStockInfo.Rows != null) && (this.dataGridViewStockInfo.SelectedRows.Count != 0))
            {
                this.btnUpdate.Enabled = true;
            }
            else
            {
                this.btnUpdate.Enabled = false;
            }
        }

        private void ShowMsg(object o, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Excel.Application application = new Excel.Application();// ApplicationClass();

                if (CommonFunction.IfHasData(this.dtStore))
                {
                    this.dtStore.Rows.Clear();
                }

                try
                {
                    int num;
                    Range range;
                    Worksheet worksheet = (Worksheet)application.Workbooks._Open(this.openFileDialog.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value).Sheets[1];

                    for (num = 2; num < 0x20; num++)
                    {
                        range = (Range)worksheet.Cells[5, num];
                        this.dtStore.Columns[num - 2].ColumnName = range.Value2.ToString();
                    }

                    this.dvStore.RowFilter = "1=2";

                    for (num = 7; num < (worksheet.UsedRange.Rows.Count + 1); num++)
                    {
                        DataRow row = this.dtStore.NewRow();

                        for (int i = 2; i < 0x20; i++)
                        {
                            range = (Range)worksheet.Cells[num, i];

                            if (i == 0x11)
                            {
                                row[i - 2] = ExcelDateOperator.ConvertExcelDateToDate(range.Value2.ToString());
                            }
                            else
                            {
                                row[i - 2] = range.Value2;
                            }
                        }

                        this.dtStore.Rows.Add(row);
                    }
                }
                catch
                {
                    MessageBox.Show("文件读取失败，请确认文件格式是否正确");
                }
                finally
                {
                    application.Workbooks.Close();
                }

                if (CommonFunction.IfHasData(this.dtStore))
                {
                    this.btnSelect.Enabled = true;
                    this.btnSelectShowMsg(null, null);
                }
                else
                {
                    this.btnSelect.Enabled = false;
                    MessageBox.Show("当前文件数据为空");
                    return;
                }

                if (this.dvStore.Count == 0)
                {
                    MessageBox.Show("当前数据为空，如果您确认文件中存在数据，那么造成数据为空的结果可能为您的筛选条件造成，比如没有当前用户的所属数据");
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
