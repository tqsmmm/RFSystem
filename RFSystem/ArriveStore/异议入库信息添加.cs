using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace RFSystem.ArriveStore
{
    public class 异议入库信息添加 : Form
    {
        // Fields
        private Button btnCancel;
        private Button btnOK;
        private Button btnStorageAdd;
        private Button btnStorageDel;
        private ComboBox comboBoxArriveListID;
        private DataGridView dataGridViewStorageInfo;
        private DataTable demurralInfoList;
        private ArrayList getDemurralInfo;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown numericUpDownGoodsAmount;
        private TextBox textBoxExceptionCausation;
        private TextBox textBoxGoodsName;
        private TextBox textBoxMaterielNum;
        private UserInfo userItem;
        private DataGridViewTextBoxColumn ColumnStorePosition;
        private DataGridViewTextBoxColumn ColumnAmount;
        private DataGridViewTextBoxColumn ColumnRemark;
        private ArrayList userRoles;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGoodsName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaterielNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownGoodsAmount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxExceptionCausation = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStorageDel = new System.Windows.Forms.Button();
            this.btnStorageAdd = new System.Windows.Forms.Button();
            this.dataGridViewStorageInfo = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBoxArriveListID = new System.Windows.Forms.ComboBox();
            this.ColumnStorePosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGoodsAmount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 9999;
            this.label1.Text = "到库单号：";
            // 
            // textBoxGoodsName
            // 
            this.textBoxGoodsName.Location = new System.Drawing.Point(533, 12);
            this.textBoxGoodsName.Name = "textBoxGoodsName";
            this.textBoxGoodsName.Size = new System.Drawing.Size(100, 26);
            this.textBoxGoodsName.TabIndex = 30;
            this.textBoxGoodsName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 9999;
            this.label2.Text = "货物名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 9999;
            this.label3.Text = "异议数量：";
            // 
            // textBoxMaterielNum
            // 
            this.textBoxMaterielNum.Location = new System.Drawing.Point(342, 12);
            this.textBoxMaterielNum.Name = "textBoxMaterielNum";
            this.textBoxMaterielNum.Size = new System.Drawing.Size(100, 26);
            this.textBoxMaterielNum.TabIndex = 20;
            this.textBoxMaterielNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 9999;
            this.label4.Text = "货物物料号：";
            // 
            // numericUpDownGoodsAmount
            // 
            this.numericUpDownGoodsAmount.Location = new System.Drawing.Point(137, 46);
            this.numericUpDownGoodsAmount.Name = "numericUpDownGoodsAmount";
            this.numericUpDownGoodsAmount.Size = new System.Drawing.Size(100, 26);
            this.numericUpDownGoodsAmount.TabIndex = 40;
            this.numericUpDownGoodsAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 9999;
            this.label5.Text = "异议原因：";
            // 
            // textBoxExceptionCausation
            // 
            this.textBoxExceptionCausation.Location = new System.Drawing.Point(342, 44);
            this.textBoxExceptionCausation.Name = "textBoxExceptionCausation";
            this.textBoxExceptionCausation.Size = new System.Drawing.Size(291, 26);
            this.textBoxExceptionCausation.TabIndex = 50;
            this.textBoxExceptionCausation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStorageDel);
            this.groupBox2.Controls.Add(this.btnStorageAdd);
            this.groupBox2.Controls.Add(this.dataGridViewStorageInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(668, 239);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "存放信息";
            // 
            // btnStorageDel
            // 
            this.btnStorageDel.Enabled = false;
            this.btnStorageDel.Location = new System.Drawing.Point(562, 92);
            this.btnStorageDel.Name = "btnStorageDel";
            this.btnStorageDel.Size = new System.Drawing.Size(100, 40);
            this.btnStorageDel.TabIndex = 90;
            this.btnStorageDel.Text = "删除";
            this.btnStorageDel.UseVisualStyleBackColor = true;
            this.btnStorageDel.Click += new System.EventHandler(this.btnStorageDel_Click);
            // 
            // btnStorageAdd
            // 
            this.btnStorageAdd.Location = new System.Drawing.Point(562, 46);
            this.btnStorageAdd.Name = "btnStorageAdd";
            this.btnStorageAdd.Size = new System.Drawing.Size(100, 40);
            this.btnStorageAdd.TabIndex = 70;
            this.btnStorageAdd.Text = "添加";
            this.btnStorageAdd.UseVisualStyleBackColor = true;
            this.btnStorageAdd.Click += new System.EventHandler(this.btnStorageAdd_Click);
            // 
            // dataGridViewStorageInfo
            // 
            this.dataGridViewStorageInfo.AllowUserToAddRows = false;
            this.dataGridViewStorageInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStorageInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStorePosition,
            this.ColumnAmount,
            this.ColumnRemark});
            this.dataGridViewStorageInfo.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewStorageInfo.MultiSelect = false;
            this.dataGridViewStorageInfo.Name = "dataGridViewStorageInfo";
            this.dataGridViewStorageInfo.ReadOnly = true;
            this.dataGridViewStorageInfo.RowHeadersVisible = false;
            this.dataGridViewStorageInfo.RowHeadersWidth = 30;
            this.dataGridViewStorageInfo.RowTemplate.Height = 23;
            this.dataGridViewStorageInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStorageInfo.Size = new System.Drawing.Size(550, 213);
            this.dataGridViewStorageInfo.TabIndex = 80;
            this.dataGridViewStorageInfo.SelectionChanged += new System.EventHandler(this.dataGridViewStorageInfo_SelectionChanged);
            this.dataGridViewStorageInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(476, 323);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 100;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(582, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 100;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBoxArriveListID
            // 
            this.comboBoxArriveListID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArriveListID.FormattingEnabled = true;
            this.comboBoxArriveListID.Location = new System.Drawing.Point(137, 12);
            this.comboBoxArriveListID.Name = "comboBoxArriveListID";
            this.comboBoxArriveListID.Size = new System.Drawing.Size(100, 28);
            this.comboBoxArriveListID.TabIndex = 10000;
            // 
            // ColumnStorePosition
            // 
            this.ColumnStorePosition.DataPropertyName = "StorePosition";
            this.ColumnStorePosition.HeaderText = "库位";
            this.ColumnStorePosition.Name = "ColumnStorePosition";
            this.ColumnStorePosition.ReadOnly = true;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "库位数量";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            // 
            // ColumnRemark
            // 
            this.ColumnRemark.DataPropertyName = "Remark";
            this.ColumnRemark.HeaderText = "备注";
            this.ColumnRemark.Name = "ColumnRemark";
            this.ColumnRemark.ReadOnly = true;
            this.ColumnRemark.Width = 250;
            // 
            // 异议入库信息添加
            // 
            this.ClientSize = new System.Drawing.Size(694, 375);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxArriveListID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxExceptionCausation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownGoodsAmount);
            this.Controls.Add(this.textBoxMaterielNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxGoodsName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "异议入库信息添加";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "异议入库信息添加";
            this.Load += new System.EventHandler(this.异议入库信息添加_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGoodsAmount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Methods
        public 异议入库信息添加(UserInfo userItem, ArrayList userRoles)
        {
            this.demurralInfoList = null;
            this.getDemurralInfo = null;
            this.userItem = null;
            this.InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
            this.demurralInfoList = new DataTable();
            this.demurralInfoList.Columns.Add("StorePosition");
            this.demurralInfoList.Columns.Add("Amount");
            this.demurralInfoList.Columns.Add("Remark");
            this.dataGridViewStorageInfo.DataSource = this.demurralInfoList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateInput())
            {
                string str = Guid.NewGuid().ToString();
                ArrayList demurralList = new ArrayList();
                demurralList.Add(str);
                demurralList.Add(this.comboBoxArriveListID.Text);
                demurralList.Add(this.textBoxMaterielNum.Text);
                demurralList.Add(this.textBoxGoodsName.Text);
                demurralList.Add(this.numericUpDownGoodsAmount.Value);
                demurralList.Add(this.textBoxExceptionCausation.Text);
                if (!DBOperate.ArriveStoreExceptionInfoAdd(demurralList, this.demurralInfoList).Equals("-1"))
                {
                    CommonFunction.Sys_MsgBox("对到库单 " + this.comboBoxArriveListID.Text + " 的异议入库信息添加成功");
                    base.DialogResult = DialogResult.OK;
                }
                else
                {
                    CommonFunction.Sys_MsgBox("数据库出错，请联系系统管理员确认");
                }
            }
        }

        private void btnStorageAdd_Click(object sender, EventArgs e)
        {
            异议货物存放信息 异议货物存放信息 = new 异议货物存放信息();
            if (异议货物存放信息.ShowDialog() == DialogResult.OK)
            {
                this.getDemurralInfo = 异议货物存放信息.DemurralStorageInfo;
                this.demurralInfoList.Rows.Add(new object[] { (string)this.getDemurralInfo[0], (int)this.getDemurralInfo[1], (string)this.getDemurralInfo[2] });
            }
        }

        private void btnStorageDel_Click(object sender, EventArgs e)
        {
            this.demurralInfoList.Rows[this.dataGridViewStorageInfo.SelectedRows[0].Index].Delete();
        }

        private void dataGridViewStorageInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewStorageInfo.Rows != null) && (this.dataGridViewStorageInfo.SelectedRows.Count != 0))
            {
                this.btnStorageDel.Enabled = true;
            }
            else
            {
                this.btnStorageDel.Enabled = false;
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.GetNextControl(base.ActiveControl, true).Focus();
            }
        }

        private void SetErrorProvider(ErrorProvider errorProvider, Control errorControl, string errorMsg)
        {
            errorProvider.SetError(errorControl, errorMsg);
        }

        private bool ValidateInput()
        {
            if (this.comboBoxArriveListID.Text.Trim().Equals(string.Empty) || (this.numericUpDownGoodsAmount.Value == 0M))
            {
                CommonFunction.Sys_MsgBox("请填写完整信息");
                return false;
            }
            decimal num = 0M;
            for (int i = 0; i < this.demurralInfoList.Rows.Count; i++)
            {
                num += Convert.ToDecimal(this.demurralInfoList.Rows[i][1]);
            }
            if (num != this.numericUpDownGoodsAmount.Value)
            {
                CommonFunction.Sys_MsgBox("异议数量和异议入库数量不一致，请确认");
                return false;
            }
            return true;
        }

        private void 异议入库信息添加_Load(object sender, EventArgs e)
        {
            int userRole = 2;
            if (!this.userItem.isAdmin)
            {
                userRole = 1;
                if (!this.userRoles.Contains("MakeArriveStoreRequisition"))
                {
                    userRole = 0;
                }
            }
            DataTable arriveListArriveStoreExceptionInfo = DBOperate.GetArriveListArriveStoreExceptionInfo(this.userItem.userID, userRole);
            if (CommonFunction.IfHasData(arriveListArriveStoreExceptionInfo))
            {
                for (int i = 0; i < arriveListArriveStoreExceptionInfo.Rows.Count; i++)
                {
                    this.comboBoxArriveListID.Items.Add(arriveListArriveStoreExceptionInfo.Rows[i]["ArriveListID"].ToString());
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("当前没有可进行异议入库货物的单据");
                base.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
