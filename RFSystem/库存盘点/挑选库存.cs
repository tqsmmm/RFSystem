using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 挑选库存 : Form
    {
        public 挑选库存()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("checkId", typeof(string));
                _dt.Columns["checkId"].Caption = "盘点单号";

                _dt.Columns.Add("transactionId", typeof(string));
                _dt.Columns["transactionId"].Caption = "库存明细交易号";

                DataRow _dr = _dt.NewRow();
                _dr[0] = txtCheckId.Text;
                _dr[1] = txtTransactionId.Text;

                _dt.Rows.Add(_dr);

                rfid2021Service.MessagePack pack = newService.sendMsg("DVE166", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

                if (pack.Result)
                {
                    CommonFunction.Sys_MsgBox("盘点单挑选库存请求成功！");
                    DialogResult = DialogResult.Yes;
                    Close();
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
}
