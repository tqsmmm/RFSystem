using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 新建保养单 : Form
    {
        DataTable dtMaintain = null;

        DataTable dtGoods = null;

        public 新建保养单()
        {
            InitializeComponent();

            InitTableColumns();
        }

        private void 新建保养单_Load(object sender, EventArgs e)
        {
            textBoxSTOREMAN.Text = AppSetter.User_Info.JobID;

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
            查询物料 frm = new 查询物料();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < frm.Ds.Tables[0].Rows.Count; i++)
                {
                    dtGoods.Rows.Add(new object[] {
                        frm.Ds.Tables[0].Rows[i][0].ToString(),
                        frm.Ds.Tables[0].Rows[i][1].ToString(),
                        frm.Ds.Tables[0].Rows[i][2].ToString(),
                        frm.Ds.Tables[0].Rows[i][3].ToString(),
                        frm.Ds.Tables[0].Rows[i][4].ToString(),
                        frm.Ds.Tables[0].Rows[i][5].ToString(),
                        frm.Ds.Tables[0].Rows[i][6].ToString(),
                        frm.Ds.Tables[0].Rows[i][7].ToString(),
                        frm.Ds.Tables[0].Rows[i][8].ToString(),
                        frm.Ds.Tables[0].Rows[i][9].ToString(),
                        frm.Ds.Tables[0].Rows[i][10].ToString(),
                        frm.Ds.Tables[0].Rows[i][11].ToString()});
                }
            }
        }

        private void btnMaintainPlan_Click(object sender, EventArgs e)
        {
            if (dataGridViewSapStockInfo.Rows.Count > 0)
            {
                if (CommonFunction.Sys_MsgYN("确认生成此保养单么？"))
                {
                    ArrayList billInfo = new ArrayList();

                    dtMaintain.Rows.Add(new object[] { comboBoxPlant.SelectedValue, comboBoxSLocation.SelectedValue, textBoxSTOREMAN.Text, AppSetter.User_Info.userID, DateTime.Today });

                    for (int i = 0; i < dtMaintain.Columns.Count; i++)
                    {
                        billInfo.Add(dtMaintain.Rows[0][i]);
                    }

                    string str = DBOperate.MaintainNewPlan(AppSetter.User_Info.userID, "MAINTAIN", billInfo, dtGoods);

                    if (!str.Equals("-1"))
                    {
                        CommonFunction.Sys_MsgBox("库存保养单 " + str + " 添加成功");

                        Close();
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("库存保养单添加失败，请联系管理员确认");
                    }
                }
            }
        }

        private void InitTableColumns()
        {
            dtMaintain = new DataTable();
            dtMaintain.Columns.Add("FACTORY_NO");
            dtMaintain.Columns.Add("SL");
            dtMaintain.Columns.Add("STOREMAN");
            dtMaintain.Columns.Add("OPERATOR");
            dtMaintain.Columns.Add("OPERATE_TIME");

            dtGoods = new DataTable();
            dtGoods.Columns.Add("BARCODE");
            dtGoods.Columns.Add("FACT_NO");
            dtGoods.Columns.Add("PRODUCT_NO");
            dtGoods.Columns.Add("PATCH_NO");
            dtGoods.Columns.Add("PRODUCT_NAME");
            dtGoods.Columns.Add("UNIT");
            dtGoods.Columns.Add("BIN");
            dtGoods.Columns.Add("BIN_NUM");
            dtGoods.Columns.Add("PLAN_NUM");
            dtGoods.Columns.Add("MAINTAINNUM");
            dtGoods.Columns.Add("SUPPLIER_NO");
            dtGoods.Columns.Add("WEIGHT");

            dataGridViewSapStockInfo.DataSource = dtGoods;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewSapStockInfo.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridViewSapStockInfo.SelectedRows.Count; i++)
                {
                    DataRowView drv = dataGridViewSapStockInfo.SelectedRows[i].DataBoundItem as DataRowView;
                    dtGoods.Rows.Remove(drv.Row);
                }

                foreach(DataRow dr in dataGridViewSapStockInfo.SelectedRows)
                {
                    dtGoods.Rows.Remove(dr);
                }
            }
            else
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MetarnetRegex.IsNumber(txtPlan_Num.Text) && MetarnetRegex.IsNumber(txtWeight.Text))
            {
                DataRow dr = dataGridViewSapStockInfo.SelectedRows[0].DataBoundItem as DataRow;

                dr["PLAN_NUM"] = txtPlan_Num.Text;
                dr["Weight"] = txtWeight.Text;
            }
            else
            {
                CommonFunction.Sys_MsgBox("请确定输入为数字！");
            }
        }

        private void dataGridViewSapStockInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSapStockInfo.SelectedRows.Count > 0)
            {
                txtPlan_Num.Text = dataGridViewSapStockInfo.SelectedRows[0].Cells["PLAN_NUM"].Value.ToString();
                txtWeight.Text = dataGridViewSapStockInfo.SelectedRows[0].Cells["Weight"].Value.ToString();

                btnEdit.Enabled = true;
            }
            else
            {
                txtPlan_Num.Text = string.Empty;
                txtWeight.Text = string.Empty;

                btnEdit.Enabled = false;
            }
        }
    }
}
