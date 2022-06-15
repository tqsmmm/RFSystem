using RFSystem.rfid2021Service;
using System;
using System.Data;

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

                MessagePack pack = newService.sendMsg("DVE117", ConstDefine.g_bxuserid, ConstDefine.g_bxusername, ConstDefine.g_bxjobid, _sendDs, out DataSet _outDs);

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
                CommonFunction.Sys_MsgBox(ee.Message);
                return null;
            }
            finally
            {
                
            }
        }
    }
}
