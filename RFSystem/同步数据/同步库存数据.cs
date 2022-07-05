using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 同步库存数据 : Form
    {
        DataTable mDt = null;
        int rC = 0;
        int recC = 0;

        public 同步库存数据()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (textBoxStoreMan.Text.Trim() == "")
            {
                CommonFunction.Sys_MsgBox("请输入正确保管员岗位号。");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnDownload.Enabled = false;

                DBOperate.clearE1DV11(textBoxStoreMan.Text.Trim());

                rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("custodianJobId", typeof(string));
                _dt.Columns["custodianJobId"].Caption = "保管员岗位号";

                DataRow _dr = _dt.NewRow();
                _dr[0] = textBoxStoreMan.Text.Trim();

                _dt.Rows.Add(_dr);

                rfid2021Service.MessagePack pack = newService.sendMsg("DVE111", ConstDefine.g_bxuserid, ConstDefine.g_bxusername, ConstDefine.g_bxjobid, _sendDs, out DataSet _outDs);

                if (pack.Result)
                {
                    rC = Convert.ToInt32(_outDs.Tables[0].Rows[0]["totalNumber"]);
                    textBox1.Text = rC.ToString();
                    timer1.Enabled = true;
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
                btnDownload.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mDt = DBOperate.getE1DV11(textBoxStoreMan.Text.Trim());

            if (mDt != null)
            {
                dataGridViewSapStockInfo.DataSource = mDt;
                textBox2.Text = mDt.Rows.Count.ToString();
                recC = mDt.Rows.Count;

                if (rC == recC)
                {
                    btnUpdate.Enabled = true;

                    timer1.Enabled = false;
                }
            }
            else 
            {
                textBox2.Text = "0";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rC < 0 || rC != recC)
            {
                CommonFunction.Sys_MsgBox("没有接收到数据，或记录数为0");
                return;
            }

            DBOperate.clearbx_transaction(textBoxStoreMan.Text.Trim());

            int updateCount = DBOperate.updateTransaction(textBoxStoreMan.Text.Trim());

            if (updateCount > -1)
            {
                CommonFunction.Sys_MsgBox("同步成功，同步 " + updateCount + "条数据");
            }
            else
            {
                CommonFunction.Sys_MsgBox("同步失败");
            }
        }

        private void 同步库存数据_Load(object sender, EventArgs e)
        {
            dataGridViewSapStockInfo.AutoGenerateColumns = false;
        }
    }
}
