using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 同步保管员信息 : Form
    {
        DataTable mDt = null;
        int rC = 0;
        int recC = 0;

        public 同步保管员信息()
        {
            InitializeComponent();
        }

        private void 同步保管员信息_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("auth", typeof(string));
                _dt.Columns["auth"].Caption = "鉴权";

                DataRow _dr = _dt.NewRow();
                _dr[0] = "getUsers";

                _dt.Rows.Add(_dr);

                rfid2021Service.MessagePack pack = newService.sendMsg("DVE130", ConstDefine.g_bxuserid, ConstDefine.g_bxusername, ConstDefine.g_bxjobid, _sendDs, out DataSet _outDs);

                if (pack.Result)
                {
                    rC = Convert.ToInt32(_outDs.Tables[0].Rows.Count);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rC < 0 || rC != recC)
            {
                CommonFunction.Sys_MsgBox("没有接收到数据，或记录数为0");
                return;
            }

            DBOperate.clearRF_Users();

            int updateCount = DBOperate.updateRF_Users();

            if (updateCount > -1)
            {
                CommonFunction.Sys_MsgBox("同步成功，同步 " + updateCount + "条数据");
            }
            else
            {
                CommonFunction.Sys_MsgBox("同步失败");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mDt = DBOperate.getE1DV30();

            if (mDt != null)
            {
                dataGridView1.DataSource = mDt;
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
    }
}
