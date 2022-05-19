using RFSystem.CommonClass;
using RFSystem.rfid2021Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    class GetData
    {
        public static DataSet Get_17(string ywtm)
        {
            try
            {
                rfidService newService = new rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("deliveryLineId", typeof(string));
                _dt.Columns["deliveryLineId"].Caption = "送货单行号";

                DataRow _dr = _dt.NewRow();

                _dr[0] = ywtm;

                _dt.Rows.Add(_dr);

                DataSet _outDs;

                MessagePack pack = newService.sendMsg("DVE117", ConstDefine.g_bxuserid, ConstDefine.g_bxusername, ConstDefine.g_bxjobid, _sendDs, out _outDs);

                if (!pack.Result)
                {
                    _outDs = null;
                    return null;
                }
                else
                {
                    return _outDs;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return null;
            }
            finally
            {
                
            }
        }
    }
}
