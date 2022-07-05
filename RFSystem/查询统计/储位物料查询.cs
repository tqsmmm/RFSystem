using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 储位物料查询 : Form
    {
        private UserInfo userItem;

        private DataTable dtPlantList;
        private DataTable dtStoreLocusList;

        private DataTable dtGoods;
        private DataTable dtMaintain;

        public 储位物料查询()
        {
            InitializeComponent();

            InitFctAndStore();
            InitTableColumns();
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

        private void InitTableColumns()
        {
            dtMaintain = new DataTable();
            dtMaintain.Columns.Add("FACTORY_NO");
            dtMaintain.Columns.Add("SL");
            dtMaintain.Columns.Add("STOREMAN");
            dtMaintain.Columns.Add("BINKEY");
            dataGridViewMaintain.DataSource = dtMaintain;
            
            dtGoods = new DataTable();
            dtGoods.Columns.Add("Werks");
            dtGoods.Columns.Add("Matnr");
            dtGoods.Columns.Add("Charg");
            dtGoods.Columns.Add("Lgort");
            dtGoods.Columns.Add("Maktx");
            dtGoods.Columns.Add("Meins");
            dtGoods.Columns.Add("Bct0");
            dtGoods.Columns.Add("Bct1");
            dtGoods.Columns.Add("Bct10");
            dtGoods.Columns.Add("Bct20");
            dtGoods.Columns.Add("Ebeln");
            dtGoods.Columns.Add("Name1");
            dtGoods.Columns.Add("Ntgew");
            dtGoods.Columns.Add("Verpr");
            dtGoods.Columns.Add("Menge");
            dataGridViewSapStockInfo.DataSource = dtGoods;
        }

        private void btnAddDetail_Click(object sender, System.EventArgs e)
        {
            if (!comboBoxPlant.Text.Trim().Equals("无") && !comboBoxSLocation.Text.Trim().Equals("无") && !textBoxBin.Text.Trim().Equals(string.Empty) && !textBoxSTOREMAN.Text.Trim().Equals(string.Empty))
            {
                if (dtMaintain.Select("FACTORY_NO='" + comboBoxPlant.Text.Trim() + "' and SL='" + comboBoxSLocation.Text.Trim() + "' and STOREMAN='" + textBoxSTOREMAN.Text.Trim() + "' and BINKEY='" + textBoxBin.Text.Trim() + "'").Length > 0)
                {
                    MessageBox.Show("已包含此检索条件，请不要重复输入");
                }
                else
                {
                    dtMaintain.Rows.Add(new object[] { comboBoxPlant.Text.Trim(), comboBoxSLocation.Text.Trim(), textBoxSTOREMAN.Text.Trim(), textBoxBin.Text.Trim() });
                }
            }
            else
            {
                MessageBox.Show("请填写完整信息！");
            }
        }

        private void 储位物料查询_Load(object sender, System.EventArgs e)
        {

        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            if (CommonFunction.Sys_MsgYN("是否清空页面所有数据？此前内容将会全部被清除。"))
            {
                this.ClearControls();

                btnSelect.Enabled = true;
                btnAddDetail.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DataRow[] rowArray = dtMaintain.Select("FACTORY_NO='" + dataGridViewMaintain.SelectedRows[0].Cells["ColumnFACTORY_NO"].Value.ToString() + "' and SL='" + dataGridViewMaintain.SelectedRows[0].Cells["ColumnSL"].Value.ToString() + "' and STOREMAN='" + dataGridViewMaintain.SelectedRows[0].Cells["ColumnSTOREMAN"].Value.ToString() + "' and BINKEY='" + dataGridViewMaintain.SelectedRows[0].Cells["ColumnBINKEY"].Value.ToString() + "'");

            if ((rowArray != null) && (rowArray.Length != 0))
            {
                dtMaintain.Rows.Remove(rowArray[0]);
            }
        }

        private void ClearControls()
        {
            comboBoxPlant.SelectedIndex = 0;
            textBoxBin.Text = string.Empty;
            dtGoods.Rows.Clear();
            dtMaintain.Rows.Clear();
        }

        private void comboBoxPlant_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            comboBoxSLocation.Items.Clear();
            comboBoxSLocation.Items.Add("无");

            foreach (DataRow row in dtStoreLocusList.Select("PlantID='" + comboBoxPlant.Text + "'"))
            {
                comboBoxSLocation.Items.Add(row["StoreLocusID"].ToString());
            }

            comboBoxSLocation.SelectedIndex = 0;
        }

        private void dataGridViewMaintain_SelectionChanged(object sender, System.EventArgs e)
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

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataRow row in dtMaintain.Rows)
                {
                    DataSet cxDs = new DataSet("货位查询");
                }

                if (!CommonFunction.IfHasData(dtGoods))
                {
                    MessageBox.Show("没有检索到任何数据，请重新输入条件进行检索");
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
    }
}
