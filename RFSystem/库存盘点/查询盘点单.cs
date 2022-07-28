using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 查询盘点单 : Form
    {
        public 查询盘点单()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
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

        private void 查询盘点单_Load(object sender, EventArgs e)
        {
            
        }
    }
}
