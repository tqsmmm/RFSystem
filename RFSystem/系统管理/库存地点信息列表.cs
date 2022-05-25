using BL;
using RFSystem.CommonClass;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 库存地点信息列表 : Form
    {
        DataTable dtStoreLocusList = null;

        public 库存地点信息列表()
        {
            InitializeComponent();
        }

        private void 库存地点信息列表_Load(object sender, EventArgs e)
        {
            comboBoxPlantList.Items.Clear();
            DataTable plantList = DBOperate.GetPlantList(string.Empty);
            comboBoxPlantList.Items.Add("无");

            if (CommonFunction.IfHasData(plantList))
            {
                foreach (DataRow row in plantList.Rows)
                {
                    comboBoxPlantList.Items.Add(row["PlantID"].ToString());
                }
            }

            comboBoxPlantList.SelectedIndex = 0;
            comboBoxPlantList.SelectedIndex = 0;
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            库存地点信息 frm = new 库存地点信息(null);
            frm.Text = "库存新增";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnSelectStore.PerformClick();
            }
        }

        private void btnDelStore_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtStoreLocusList))
            {
                if (dataGridViewStoreList.SelectedRows != null)
                {
                    if (CommonFunction.Sys_MsgYN("确认删除此条库存地点信息么？") && (DBOperate.DelStoreLocus((string)this.dataGridViewStoreList.SelectedRows[0].Cells["columnStoreLocusID"].Value, (string)dataGridViewStoreList.SelectedRows[0].Cells["columnStorePlantID"].Value) == 1))
                    {
                        CommonFunction.Sys_MsgBox("库存地点信息删除成功");
                        btnSelectStore.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("请选择一条库存地点信息");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("没有检索到任何库存地点信息，无法修改");
            }
        }

        private void btnModStore_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtStoreLocusList))
            {
                if (dataGridViewStoreList.SelectedRows != null)
                {
                    Hashtable storeItem = new Hashtable();

                    foreach (DataGridViewCell cell in dataGridViewStoreList.SelectedRows[0].Cells)
                    {
                        storeItem.Add(cell.OwningColumn.DataPropertyName, cell.Value);
                    }

                    库存地点信息 frm = new 库存地点信息(storeItem);
                    frm.Text = "库存修改";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btnSelectStore.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("请选择一条库存地点信息");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("没有检索到任何库存地点信息，无法修改");
            }
        }

        private void btnSelectStore_Click(object sender, EventArgs e)
        {
            dtStoreLocusList = DBOperate.GetStoreLocusList(textBoxStoreID.Text.Trim(), comboBoxPlantList.Text.Trim().Equals("无") ? string.Empty : comboBoxPlantList.Text.Trim());
            dataGridViewStoreList.DataSource = dtStoreLocusList;
        }

        private void dataGridViewStoreList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewStoreList.Rows != null) && (dataGridViewStoreList.SelectedRows.Count != 0))
            {
                btnModStore.Enabled = true;
                btnDelStore.Enabled = true;
            }
            else
            {
                btnModStore.Enabled = false;
                btnDelStore.Enabled = false;
            }
        }
    }
}
