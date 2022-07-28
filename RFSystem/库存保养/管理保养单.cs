using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 管理保养单 : Form
    {
        public 管理保养单()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaintain.SelectedRows.Count > 0)
            {
                if (CommonFunction.Sys_MsgYN("是否开始保养本保养单物料？"))
                {
                    if (DBOperate.MaintainModState(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "0", "1") == 1)
                    {
                        dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "保养中";

                        CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 开始保养");
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 开始保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                    }

                    dataGridViewMaintain_SelectionChanged(null, null);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaintain.SelectedRows.Count > 0)
            {
                if (CommonFunction.Sys_MsgYN("是否作废本保养单？"))
                {
                    if (DBOperate.MaintainModState(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "0", "-1") == 1)
                    {
                        dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "作废单据";

                        CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 作废保养");
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 作废保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                    }

                    dataGridViewMaintain_SelectionChanged(null, null);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaintain.SelectedRows.Count > 0)
            {
                if (CommonFunction.Sys_MsgYN("是否结束保养本保养单货物？"))
                {
                    if (DBOperate.MaintainModState(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString(), "1", "2") == 1)
                    {
                        dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value = "保养完成";

                        CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 结束保养");
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("单据 " + dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString() + " 结束保养失败，请确认是否其他人已改变单据状态，或数据库联接失败");
                    }

                    dataGridViewMaintain_SelectionChanged(null, null);
                }
            }
        }

        private void 管理保养单_Load(object sender, EventArgs e)
        {
            //comboBoxPlant
            DataTable dtPlantList = DBOperate.GetPlantList(string.Empty, true);

            DataRow row = dtPlantList.NewRow();

            row["PlantID"] = 0;
            row["PlantDescription"] = "无";

            dtPlantList.Rows.InsertAt(row, 0);

            comboBoxPlant.DataSource = dtPlantList;
            comboBoxPlant.DisplayMember = "PlantDescription";
            comboBoxPlant.ValueMember = "PlantID";

            comboBoxPlant.SelectedIndex = 0;

            comboBoxSLocation.Items.Add("无");

            comboBoxSLocation.SelectedIndex = 0;
        }

        private void comboBoxPlant_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBoxSLocation.DataSource = null;

            comboBoxSLocation.Items.Clear();

            DataTable dtStoreLocusList = DBOperate.GetStoreLocusList(string.Empty, comboBoxPlant.SelectedValue.ToString());

            DataRow row = dtStoreLocusList.NewRow();

            row["StoreLocusID"] = 0;
            row["StoreLocusDescription"] = "无";

            dtStoreLocusList.Rows.InsertAt(row, 0);

            comboBoxSLocation.DataSource = dtStoreLocusList;
            comboBoxSLocation.DisplayMember = "StoreLocusDescription";
            comboBoxSLocation.ValueMember = "StoreLocusID";

            comboBoxSLocation.SelectedIndex = 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dataGridViewMaintainDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            ArrayList arriveList = new ArrayList();
            arriveList.Add(textBoxMaintainNo.Text.Trim());
            arriveList.Add(comboBoxPlant.Text.Trim().Replace("无", string.Empty));
            arriveList.Add(comboBoxSLocation.Text.Trim().Replace("无", string.Empty));
            arriveList.Add(textBoxStoreMan.Text.Trim());
            arriveList.Add(textBoxOperator.Text.Trim());
            arriveList.Add((comboBoxState.SelectedIndex == -1) ? "" : comboBoxState.SelectedIndex.ToString());

            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);

            DataTable dtMaintainHeader = DBOperate.MaintainGetHead(arriveList);
            dataGridViewMaintain.DataSource = dtMaintainHeader;
        }

        private void dataGridViewMaintain_SelectionChanged(object sender, EventArgs e)
        {
            DataTable dtMaintainDetail = new DataTable();

            if ((dataGridViewMaintain.Rows == null) || (dataGridViewMaintain.SelectedRows.Count == 0))
            {
                SetButtonsEnable(false, false, false);
            }
            else
            {
                string str = dataGridViewMaintain.SelectedRows[0].Cells["ColumnState"].Value.ToString();

                if (str != null)
                {
                    if (!(str == "等待批准"))
                    {
                        if (str == "保养完成")
                        {
                            btnPrint.Text = "结束保养";
                            SetButtonsEnable(false, true, false);
                        }
                        else if ((str == "保养中") || (str == "作废单据"))
                        {
                            btnPrint.Text = "结束保养";
                            SetButtonsEnable(false, false, false);
                        }
                        else if (str == "结束保养")
                        {
                            btnPrint.Text = "打印";
                            SetButtonsEnable(false, true, false);
                        }
                    }
                    else
                    {
                        btnPrint.Text = "结束保养";
                        SetButtonsEnable(true, false, true);
                    }
                }

                dtMaintainDetail = DBOperate.MaintainGetDetail(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString());
            }

            dataGridViewMaintainDetail.DataSource = dtMaintainDetail;

            decimal num = 0M;
            decimal num2 = 0M;
            decimal num3 = 0M;

            if (CommonFunction.IfHasData(dtMaintainDetail))
            {
                foreach (DataRow row in dtMaintainDetail.Rows)
                {
                    num += (decimal)row["PLAN_NUM"];
                    num2 += (decimal)row["MAINTAINNUM"];
                    num3 += ((decimal)row["PLAN_NUM"]) * ((decimal)row["WEIGHT"]);
                }

                object[] values = new object[13];
                values[3] = "合计";
                values[9] = num;
                values[10] = num2;
                values[12] = num3;
                dtMaintainDetail.Rows.Add(values);
            }
        }

        private void SetButtonsEnable(bool startEnable, bool endEnable, bool delEnable)
        {
            btnStart.Enabled = startEnable;
            btnPrint.Enabled = endEnable;
            btnDel.Enabled = delEnable;
        }
    }
}
