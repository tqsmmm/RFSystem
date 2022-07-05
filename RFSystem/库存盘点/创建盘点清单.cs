using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public class 创建盘点清单 : Form
    {
        private Button btBack;
        private Button btnCreatList;
        private Button btTo;
        private ComboBox comboBoxPlant;
        private DataTable dtPlantList = null;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListBox lstOperator;
        private ListBox lstST;
        private DataView m_DsvOperator = null;
        private DataView m_DsvST = null;
        private DataTable m_DtOperator = null;
        private string m_ErrMsg = "";
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox1;
        private TextBox textBoxSapInventoryNo;
        private Label label7;
        private TextBox txtKeeper;

        public 创建盘点清单()
        {
            InitializeComponent();
            
            dtPlantList = DBOperate.GetPlantList(string.Empty);
            comboBoxPlant.Items.Add("无");

            if (CommonFunction.IfHasData(dtPlantList))
            {
                foreach (DataRow row in dtPlantList.Rows)
                {
                    comboBoxPlant.Items.Add(row["PlantDescription"].ToString());
                }
            }

            comboBoxPlant.SelectedIndex = 0;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            if (lstST.SelectedItems.Count > 0)
            {
                int num;
                ArrayList list = new ArrayList();

                for (num = 0; num < lstST.SelectedItems.Count; num++)
                {
                    list.Add(((DataRowView)lstST.SelectedItems[num])["User_ID"].ToString());
                }

                for (num = 0; num < list.Count; num++)
                {
                    DataRow[] rowArray = m_DtOperator.Select("User_ID='" + list[num].ToString() + "'");

                    if (rowArray.Length != 0)
                    {
                        rowArray[0]["show"] = 'T';
                    }
                }
            }
        }

        private void btnCreatList_Click(object sender, EventArgs e)
        {
            if (textBoxSapInventoryNo.Text.Equals(string.Empty) || comboBoxPlant.Text.Trim().Equals("无"))
            {
                CommonFunction.Sys_MsgBox("PSCS盘点序号以及盘点货物所属公司均为必填(选)条件，请完成填写");
            }
            else if (CommonFunction.Sys_MsgYN("你确认要开始盘点么？"))
            {
                if (0 != DBOperate.GetSTNumber(out string sTNumber, out m_ErrMsg))
                {
                    CommonFunction.Sys_MsgBox(m_ErrMsg);
                }
                else
                {
                    string sTType = "0";

                    if (radioButton1.Checked)
                    {
                        sTType = "1";
                    }

                    if (0 != DBOperate.InSertSTOrder(m_DtOperator, ConstDefine.g_User, sTType, textBox1.Text.Trim(), sTNumber, textBoxSapInventoryNo.Text.Trim(), comboBoxPlant.Text.Trim(), out m_ErrMsg))
                    {
                        CommonFunction.Sys_MsgBox(m_ErrMsg);
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("创建盘点单号成功，单号为：" + sTNumber);
                        Close();
                    }
                }
            }
        }

        private void btTo_Click(object sender, EventArgs e)
        {
            if (lstOperator.SelectedItems.Count > 0)
            {
                int num;
                ArrayList list = new ArrayList();

                for (num = 0; num < lstOperator.SelectedItems.Count; num++)
                {
                    list.Add(((DataRowView)lstOperator.SelectedItems[num])["User_ID"].ToString());
                }

                for (num = 0; num < list.Count; num++)
                {
                    DataRow[] rowArray = m_DtOperator.Select("User_ID='" + list[num].ToString() + "'");

                    if (rowArray.Length != 0)
                    {
                        rowArray[0]["show"] = 'F';
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKeeper = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSapInventoryNo = new System.Windows.Forms.TextBox();
            this.btnCreatList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btBack = new System.Windows.Forms.Button();
            this.lstST = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btTo = new System.Windows.Forms.Button();
            this.lstOperator = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtKeeper);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxPlant);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxSapInventoryNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btBack);
            this.groupBox1.Controls.Add(this.lstST);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btTo);
            this.groupBox1.Controls.Add(this.lstOperator);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 496);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "盘点准备数据";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(160, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "盘点类型：";
            // 
            // txtKeeper
            // 
            this.txtKeeper.Location = new System.Drawing.Point(245, 153);
            this.txtKeeper.Name = "txtKeeper";
            this.txtKeeper.Size = new System.Drawing.Size(300, 26);
            this.txtKeeper.TabIndex = 10;
            this.txtKeeper.TextChanged += new System.EventHandler(this.txtKeeper_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "定位保管员：";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(245, 119);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(300, 28);
            this.comboBoxPlant.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "盘点货物所属公司：";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(334, 57);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(121, 24);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "年度/季度 盘点";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(245, 57);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 24);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "日常盘点";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "盘点人员信息：";
            // 
            // textBoxSapInventoryNo
            // 
            this.textBoxSapInventoryNo.Location = new System.Drawing.Point(245, 87);
            this.textBoxSapInventoryNo.Name = "textBoxSapInventoryNo";
            this.textBoxSapInventoryNo.Size = new System.Drawing.Size(300, 26);
            this.textBoxSapInventoryNo.TabIndex = 12;
            // 
            // btnCreatList
            // 
            this.btnCreatList.Location = new System.Drawing.Point(533, 514);
            this.btnCreatList.Name = "btnCreatList";
            this.btnCreatList.Size = new System.Drawing.Size(100, 40);
            this.btnCreatList.TabIndex = 5;
            this.btnCreatList.Text = "创建清单";
            this.btnCreatList.UseVisualStyleBackColor = true;
            this.btnCreatList.Click += new System.EventHandler(this.btnCreatList_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "保管员信息：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "PSCS盘点序号：";
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(287, 436);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(43, 31);
            this.btBack.TabIndex = 3;
            this.btBack.Text = "←";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // lstST
            // 
            this.lstST.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstST.FormattingEnabled = true;
            this.lstST.ItemHeight = 20;
            this.lstST.Location = new System.Drawing.Point(336, 263);
            this.lstST.Name = "lstST";
            this.lstST.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstST.Size = new System.Drawing.Size(209, 204);
            this.lstST.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(245, 25);
            this.textBox1.MaxLength = 100;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 26);
            this.textBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "盘点描述：";
            // 
            // btTo
            // 
            this.btTo.Location = new System.Drawing.Point(287, 263);
            this.btTo.Name = "btTo";
            this.btTo.Size = new System.Drawing.Size(43, 33);
            this.btTo.TabIndex = 0;
            this.btTo.Text = "→";
            this.btTo.UseVisualStyleBackColor = true;
            this.btTo.Click += new System.EventHandler(this.btTo_Click);
            // 
            // lstOperator
            // 
            this.lstOperator.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstOperator.FormattingEnabled = true;
            this.lstOperator.ItemHeight = 20;
            this.lstOperator.Location = new System.Drawing.Point(80, 263);
            this.lstOperator.Name = "lstOperator";
            this.lstOperator.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstOperator.Size = new System.Drawing.Size(201, 204);
            this.lstOperator.TabIndex = 1;
            // 
            // 创建盘点清单
            // 
            this.ClientSize = new System.Drawing.Size(645, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreatList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "创建盘点清单";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建盘点清单";
            this.Load += new System.EventHandler(this.创建盘点清单_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void 创建盘点清单_Load(object sender, EventArgs e)
        {
            if (0 != DBOperate.GetSTList(out DataSet ds, out m_ErrMsg))
            {
                CommonFunction.Sys_MsgBox(m_ErrMsg);
                Close();
            }
            else
            {
                m_DtOperator = ds.Tables[0];
                m_DsvOperator = new DataView(m_DtOperator);
                m_DsvOperator.RowFilter = "show='T'";
                m_DsvST = new DataView(m_DtOperator);
                m_DsvST.RowFilter = "show='F'";
                lstOperator.DataSource = m_DsvOperator;
                lstOperator.DisplayMember = "Display";
                lstST.DataSource = m_DsvST;
                lstST.DisplayMember = "Display";
                lstST.ValueMember = "User_ID";
            }
        }

        private void txtKeeper_TextChanged(object sender, EventArgs e)
        {
            string str = "show='T'";

            if (txtKeeper.Text.Trim() != "")
            {
                str = "show='T' and User_ID like '" + txtKeeper.Text.Trim() + "*'";
            }

            m_DsvOperator.RowFilter = str;
        }
    }
}
