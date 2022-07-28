using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 保养单列表 : Form
    {
        public 保养单列表()
        {
            InitializeComponent();
        }

        private void 保养单列表_Load(object sender, EventArgs e)
        {
            ArrayList arriveList = new ArrayList();

            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);
            arriveList.Add("1");
            arriveList.Add(string.Empty);
            arriveList.Add(string.Empty);

            DataTable dtMaintainHeader = DBOperate.MaintainGetHead(arriveList);

            dataGridViewMaintain.DataSource = dtMaintainHeader;
        }

        private void dataGridViewMaintain_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMaintain.SelectedRows.Count > 0)
            {
                dataGridViewMaintainDetail.DataSource = DBOperate.MaintainGetDetail(dataGridViewMaintain.SelectedRows[0].Cells["ColumnMAINTAIN_NO"].Value.ToString());
            }
        }

        private void dataGridViewMaintainDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMaintainDetail.SelectedRows.Count > 0)
            {
                txtPLAN_NUM.Text = dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnPLAN_NUM"].Value.ToString();
                txtMAINTAINNUM.Text = dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnMAINTAINNUM"].Value.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDecimal(txtMAINTAINNUM.Text.Trim());
            }
            catch
            {
                CommonFunction.Sys_MsgBox("数字格式输入不正确，请确认");
                return;
            }

            if (Convert.ToDecimal(txtPLAN_NUM.Text.Trim()) < Convert.ToDecimal(txtMAINTAINNUM.Text.Trim()))
            {
                MessageBox.Show("保养数量超过保养单中的计划数量，请确认");
            }
            else
            {
                ArrayList alParams = new ArrayList();

                alParams.Add(dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnDetailMAINTAIN_NO"].Value);
                alParams.Add(dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnBARCODE"].Value);
                alParams.Add(dataGridViewMaintainDetail.SelectedRows[0].Cells["ColumnBIN"].Value);
                alParams.Add(Convert.ToDecimal(txtMAINTAINNUM.Text.Trim()));
                
                if (DBOperate.MaintainDetailAddCount(alParams) == -1)
                {
                    CommonFunction.Sys_MsgBox("数据更新失败，请确认保养过程中保养单状态没有被改变且数据库联接正常");
                }
                else
                {
                    CommonFunction.Sys_MsgBox("保养成功");

                    dataGridViewMaintain_SelectionChanged(null, e);
                }
            }
        }
    }
}
