using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    public partial class 同步物理库区 : Form
    {
        public 同步物理库区()
        {
            InitializeComponent();
        }

        private void 同步物理库区_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
            DataSet _sendDs = new DataSet();

            DataTable _dt = _sendDs.Tables.Add("BODY");

            _dt.Columns.Add("auth", typeof(string));
            _dt.Columns["auth"].Caption = "随便传";

            DataRow _dr = _dt.NewRow();
            _dr[0] = "getUsers";

            _dt.Rows.Add(_dr);

            rfid2021Service.MessagePack pack = newService.sendMsgNotOut("DVE131", ConstDefine.g_bxuserid, ConstDefine.g_bxusername, ConstDefine.g_bxjobid, _sendDs);

            if (pack.Result)
            {
                CommonFunction.Sys_MsgBox("同步成功");
            }
            else
            {
                CommonFunction.Sys_MsgBox(pack.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
