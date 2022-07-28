using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 查询保养单 : Form
    {
        public 查询保养单()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ArrayList arriveList = new ArrayList();

            arriveList.Add(textBoxMaintainID.Text.Trim().Equals(string.Empty) ? string.Empty : textBoxMaintainID.Text.Trim());
            arriveList.Add(comboBoxPlant.Text.Equals("无") ? string.Empty : comboBoxPlant.Text);
            arriveList.Add(comboBoxSLocation.Text.Equals("无") ? string.Empty : comboBoxSLocation.Text);
            arriveList.Add(textBoxBin.Text.Trim().Equals(string.Empty) ? string.Empty : textBoxBin.Text.Trim());
            arriveList.Add(textBoxStoreMan.Text.Trim().Equals(string.Empty) ? string.Empty : textBoxStoreMan.Text.Trim());
            arriveList.Add(textBoxOperator.Text.Trim().Equals(string.Empty) ? string.Empty : textBoxOperator.Text.Trim());

            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);

            arriveList.Add(checkBoxComplete.Checked ? "1" : string.Empty);

            string param = "";

            foreach (object obj2 in arriveList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            TDB.db.OpenProcedure("RF_Maintain_GetList_New", param, out DataTable dt);

            dataGridViewMaintainInfo.DataSource = dt;
        }

        private void 查询保养单_Load(object sender, EventArgs e)
        {
            dataGridViewMaintainInfo.AutoGenerateColumns = false;

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
    }
}
