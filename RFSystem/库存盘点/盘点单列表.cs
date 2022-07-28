using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 盘点单列表 : Form
    {
        public 盘点单列表()
        {
            InitializeComponent();
        }

        private void dataGridView1_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dtVDetail.DataSource = GetData.Get_65(dataGridView1.SelectedRows[0].Cells["checkId"].Value.ToString());
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("date", typeof(string));
                _dt.Columns["date"].Caption = "创建日期开始";

                _dt.Columns.Add("dateEnd", typeof(string));
                _dt.Columns["dateEnd"].Caption = "创建日期结束";

                DataRow _dr = _dt.NewRow();
                _dr[0] = dateTimePicker1.Value.ToString("yyyyMMdd");
                _dr[1] = dateTimePicker2.Value.ToString("yyyyMMdd");

                _dt.Rows.Add(_dr);

                rfid2021Service.MessagePack pack = newService.sendMsg("DVE160", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

                if (pack.Result)
                {
                    dataGridView1.DataSource = _outDs.Tables[0].DefaultView;
                }
                else
                {
                    CommonFunction.Sys_MsgBox(pack.Message);
                }
            }
            catch (Exception Ex)
            {
                CommonFunction.Sys_MsgBox(Ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (dtVDetail.SelectedRows.Count > 0)
            {
                盘点单录入 frm = new 盘点单录入();
                frm.txtCheckId.Text = dtVDetail.SelectedRows[0].Cells["checkId"].Value.ToString();
                frm.txtCheckLineId.Text = dtVDetail.SelectedRows[0].Cells["checkLineId"].Value.ToString();
                frm.txtCheckQty.Text = dtVDetail.SelectedRows[0].Cells["checkQty"].Value.ToString();
                frm.txtCheckRemark.Text = dtVDetail.SelectedRows[0].Cells["checkRemark"].Value.ToString();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.Yes)
                {
                    dataGridView1_SelectionChanged(null, null);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dtVDetail.SelectedRows.Count > 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                    DataSet _sendDs = new DataSet();

                    DataTable _dt = _sendDs.Tables.Add("BODY");

                    _dt.Columns.Add("checkId", typeof(string));
                    _dt.Columns["checkId"].Caption = "盘点单号";

                    _dt.Columns.Add("checkLineId", typeof(string));
                    _dt.Columns["checkLineId"].Caption = "盘点单行号";

                    DataRow _dr = _dt.NewRow();
                    _dr[0] = dataGridView1.SelectedRows[0].Cells["checkId"].ToString();
                    _dr[1] = dataGridView1.SelectedRows[0].Cells["checkLineId"].ToString();

                    _dt.Rows.Add(_dr);

                    rfid2021Service.MessagePack pack = newService.sendMsg("DVE163", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

                    if (pack.Result)
                    {
                        CommonFunction.Sys_MsgBox("盘点单取消库存成功！");

                        dataGridView1_SelectionChanged(null, null);
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox(pack.Message);
                    }
                }
                catch (Exception Ex)
                {
                    CommonFunction.Sys_MsgBox(Ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (dtVDetail.SelectedRows.Count > 0)
            {
                挑选库存 frm = new 挑选库存();
                frm.txtCheckId.Text = dtVDetail.SelectedRows[0].Cells["checkId"].Value.ToString();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.Yes)
                {
                    dataGridView1_SelectionChanged(null, null);
                }
            }
        }
    }
}
