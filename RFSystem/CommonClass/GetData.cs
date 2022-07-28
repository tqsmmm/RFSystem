using RFSystem.rfid2021Service;
using System;
using System.Data;

namespace RFSystem
{
    class GetData
    {
        public static DataSet Get_65(string ywtm)
        {
            try
            {
                rfidService newService = new rfidService();
                DataSet _sendDs = new DataSet();

                DataTable _dt = _sendDs.Tables.Add("BODY");

                _dt.Columns.Add("checkId", typeof(string));
                _dt.Columns["checkId"].Caption = "盘点单号";

                DataRow _dr = _dt.NewRow();

                _dr[0] = ywtm;

                _dt.Rows.Add(_dr);

                MessagePack pack = newService.sendMsg("DVE165", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

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
            catch (Exception Ex)
            {
                CommonFunction.Sys_MsgBox(Ex.Message);
                return null;
            }
            finally
            {

            }
        }

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

                MessagePack pack = newService.sendMsg("DVE117", AppSetter.g_bxuserid, AppSetter.g_bxusername, AppSetter.g_bxjobid, _sendDs, out DataSet _outDs);

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
            catch (Exception Ex)
            {
                CommonFunction.Sys_MsgBox(Ex.Message);
                return null;
            }
            finally
            {
                
            }
        }
    }
}
