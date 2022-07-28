using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 盘点单录入 : Form
    {
        public 盘点单录入()
        {
            InitializeComponent();
        }

        private void 盘点单录入_Load(object sender, EventArgs e)
        {

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

                _dt.Columns.Add("checkLineId", typeof(string));
                _dt.Columns["checkLineId"].Caption = "盘点单行号";

                _dt.Columns.Add("checkQty", typeof(string));
                _dt.Columns["checkQty"].Caption = "核定数量";

                _dt.Columns.Add("checkRemark", typeof(string));
                _dt.Columns["checkRemark"].Caption = "盘点备注";

                DataRow _dr = _dt.NewRow();
                _dr[0] = txtCheckId.Text;
                _dr[1] = txtCheckLineId.Text;
                _dr[2] = txtCheckQty.Text;
                _dr[3] = txtCheckRemark.Text;

                _dt.Rows.Add(_dr);

                rfid2021Service.MessagePack pack = newService.sendMsg("DVE162", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

                if (pack.Result)
                {
                    CommonFunction.Sys_MsgBox("盘点单录入库存请求成功！");
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
