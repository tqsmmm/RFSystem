using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 库存账套信息列表 : Form
    {
        DataTable dtPlantList = null;

        public 库存账套信息列表()
        {
            InitializeComponent();
            
        }

        private void 库存账套信息列表_Load(object sender, EventArgs e)
        {

        }

        private void btnAddPlant_Click(object sender, EventArgs e)
        {
            库存账套信息 frm = new 库存账套信息(null);
            frm.Text = "库存账套新增";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnSelectPlant.PerformClick();
            }
        }

        private void btnDelPlant_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtPlantList))
            {
                if (dataGridViewPlantList.SelectedRows != null)
                {
                    if (CommonFunction.IfHasData(DBOperate.GetStoreLocusWithPlant((string)dataGridViewPlantList.SelectedRows[0].Cells["columnPlantID"].Value)))
                    {
                        CommonFunction.Sys_MsgBox("该库存账套信息下包含仓库地点信息，请先删除仓库地点信息");
                    }
                    else if (CommonFunction.Sys_MsgYN("确认删除此条库存账套信息么？") && (DBOperate.DelPlant((string)dataGridViewPlantList.SelectedRows[0].Cells["columnPlantID"].Value) == 1))
                    {
                        CommonFunction.Sys_MsgBox("库存账套信息删除成功");
                        btnSelectPlant.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("请选择一条库存账套信息");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("没有检索到任何库存账套信息，无法修改");
            }
        }

        private void btnModPlant_Click(object sender, EventArgs e)
        {
            if (CommonFunction.IfHasData(dtPlantList))
            {
                if (dataGridViewPlantList.SelectedRows != null)
                {
                    Hashtable plantItem = new Hashtable();

                    foreach (DataGridViewCell cell in dataGridViewPlantList.SelectedRows[0].Cells)
                    {
                        plantItem.Add(cell.OwningColumn.DataPropertyName, cell.Value);
                    }

                    库存账套信息 frm = new 库存账套信息(plantItem);
                    frm.Text = "库存账套修改";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btnSelectPlant.PerformClick();
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("请选择一条库存账套信息");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("没有检索到任何库存账套信息，无法修改");
            }
        }

        private void btnSelectPlant_Click(object sender, EventArgs e)
        {
            dtPlantList = DBOperate.GetPlantList(textBoxPlantID.Text.Trim(), false);
            dataGridViewPlantList.DataSource = dtPlantList;
        }

        private void dataGridViewPlantList_SelectionChanged(object sender, EventArgs e)
        {
            if ((dataGridViewPlantList.Rows != null) && (dataGridViewPlantList.SelectedRows.Count != 0))
            {
                btnModPlant.Enabled = true;
                btnDelPlant.Enabled = true;
            }
            else
            {
                btnModPlant.Enabled = false;
                btnDelPlant.Enabled = false;
            }
        }
    }
}
