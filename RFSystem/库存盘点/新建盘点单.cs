using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 新建盘点单 : Form
    {
        public 新建盘点单()
        {
            InitializeComponent();
        }

        private void btnCreatList_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("checkRemark", typeof(string));
                _dt.Columns["checkRemark"].Caption = "盘点备注";

                DataRow _dr = _dt.NewRow();
                _dr[0] = textBox1.Text;

                _dt.Rows.Add(_dr);

                rfid2021Service.MessagePack pack = newService.sendMsg("DVE159", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

                if (pack.Result)
                {
                    CommonFunction.Sys_MsgBox("新建盘点单成功！");
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

        private void 新建盘点单_Load(object sender, EventArgs e)
        {

        }
    }
}
