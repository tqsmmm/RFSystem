using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 管理盘点单 : Form
    {
        public DataTable m_HeadDt;

        public 管理盘点单()
        {
            InitializeComponent();
        }

        private void 管理盘点单_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            新建盘点单 frm = new 新建盘点单();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.Yes)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && CommonFunction.Sys_MsgYN("是否确定删除盘点单？"))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                    DataSet _sendDs = new DataSet();

                    DataTable _dt = _sendDs.Tables.Add("BODY");

                    _dt.Columns.Add("checkId", typeof(string));
                    _dt.Columns["checkId"].Caption = "盘点单号";

                    DataRow _dr = _dt.NewRow();
                    _dr[0] = dataGridView1.SelectedRows[0].Cells["checkId"].ToString();

                    _dt.Rows.Add(_dr);

                    rfid2021Service.MessagePack pack = newService.sendMsg("DVE161", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

                    if (pack.Result)
                    {
                        CommonFunction.Sys_MsgBox("盘点单删除成功！");

                        btnSearch_Click(null, e);
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && CommonFunction.Sys_MsgYN("是否确定确认盘点单？"))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                    DataSet _sendDs = new DataSet();

                    DataTable _dt = _sendDs.Tables.Add("BODY");

                    _dt.Columns.Add("checkId", typeof(string));
                    _dt.Columns["checkId"].Caption = "盘点单号";

                    DataRow _dr = _dt.NewRow();
                    _dr[0] = dataGridView1.SelectedRows[0].Cells["checkId"].ToString();

                    _dt.Rows.Add(_dr);

                    rfid2021Service.MessagePack pack = newService.sendMsg("DVE164", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

                    if (pack.Result)
                    {
                        CommonFunction.Sys_MsgBox("盘点单确认成功！");

                        btnSearch_Click(null, e);
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dtVDetail.DataSource = GetData.Get_65(dataGridView1.SelectedRows[0].Cells["checkId"].Value.ToString());
            }
        }
    }
}
