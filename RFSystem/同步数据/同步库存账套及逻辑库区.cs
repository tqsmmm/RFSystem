using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 同步物理库区 : Form
    {
        DataTable mDt = null;
        int rC = 0;
        int recC = 0;

        public 同步物理库区()
        {
            InitializeComponent();
        }

        private void 同步物理库区_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("auth", typeof(string));
                _dt.Columns["auth"].Caption = "随便传";

                DataRow _dr = _dt.NewRow();
                _dr[0] = "getUsers";

                _dt.Rows.Add(_dr);

                rfid2021Service.MessagePack pack = newService.sendMsgNotOut("DVE131", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs);

                if (pack.Result)
                {
                    mDt = DBOperate.get_E1DV31();

                    if (mDt != null)
                    {
                        rC = mDt.Rows.Count;
                        textBox1.Text = rC.ToString();

                        dataGridView1.DataSource = mDt;
                        textBox2.Text = mDt.Rows.Count.ToString();
                        recC = mDt.Rows.Count;

                        if (rC == recC)
                        {
                            btnUpdate.Enabled = true;
                        }
                    }
                    else
                    {
                        textBox2.Text = "0";
                    }
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
            DBOperate.update_E1DV31_BillTo();

            DBOperate.update_E1DV31_Logic();

            CommonFunction.Sys_MsgBox("同步成功！");
        }
    }
}
