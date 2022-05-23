using System;
using System.Data;
using System.Collections;
using DL;

namespace BL
{
    /// <summary>
    /// 系统升级（增加一维条码）后，新增加的类
    /// </summary>
    public class ClsCommon
    {
        private static string m_ConnStr;
        private static TDB m_db;

        public static string ConnStr
        {
            get
            {
                return m_ConnStr;
            }
            set
            {
                m_ConnStr = value;
            }
        }

        private static TDB db
        {
            get
            {
                if (m_db == null)
                {
                    m_db = new TDB(m_ConnStr);
                }

                return m_db;
            }
            set
            {

            }
        }

        #region 保养货物、查询保养单

        public static DataTable MaintainGetList_New(ArrayList arriveList)
        {
            DataTable dt = null;
            string param = "";

            foreach (object obj2 in arriveList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            //db.OpenProcedure("RF_Maintain_GetList", param, out dt);
            db.OpenProcedure("RF_Maintain_GetList_New", param, out dt);

            return dt;
        }

        //转移至历史库
        public static int MaintainItemToHis(DateTime dTime1, DateTime dTime2,string czr)
        {
            try
            {
                db.BeginTrans();
                string param = "";
                //param = (param + TDBObject.ToDBVal(dTime1.ToString("yyyy-MM-dd")) + ",") + TDBObject.ToDBVal(dTime2.ToString("yyyy-MM-dd 23:59:59"));
                param = (param + TDBObject.ToDBVal(dTime1.ToString("yyyy-MM-dd")) + ",")
                    + TDBObject.ToDBVal(dTime2.ToString("yyyy-MM-dd 23:59:59")) + ","
                    + TDBObject.ToDBVal(czr);
                db.ExecProcedure("RF_Maintain_ToHis", param);
                db.Commit();

                return 0;
            }
            catch
            {
                db.RollBack();

                return -1;
            }
        }
        #endregion

        //本地数据库查询
        public static DataTable LocalStockGetList_New(ArrayList alParams)
        {
            string param = "";

            foreach (object obj2 in alParams)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            //db.OpenProcedure("RF_LocalStock_GetList", param, out dt);
            db.OpenProcedure("RF_LocalStock_GetList_New", param, out DataTable dt);

            return dt;
        }

        public static DataTable LocalStockGetList(ArrayList alParams)
        {
            string param = "";

            foreach (object obj2 in alParams)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            //db.OpenProcedure("RF_LocalStock_GetList", param, out dt);
            db.OpenProcedure("rfid2021.dbo.RF_LocalStock_GetList", param, out DataTable dt);

            return dt;
        }

        //工作日志统计
        public static DataSet StatisticInfo_New(string storeMan, string operatorDateFrom, string operatorDateTo)
        {
            string param = TDBObject.ToDBVal(storeMan) + "," + TDBObject.ToDBVal(operatorDateFrom) + "," + TDBObject.ToDBVal(operatorDateTo);
            db.OpenProcedure("RF_Statistic_GetList_New", param, out DataSet ds);

            return ds;
        }

        #region 盘点清单列表
        //查询
        public static int GetSTItem_New(DateTime dTime1, DateTime dTime2, out DataTable dt, out string ErrMsg)
        {
            ErrMsg = "";
            dt = new DataTable();

            if (0 != db.OpenDataSet("select * from STOrder where STStatus<>-1 "
                + " and STCreateDate>='" + dTime1.ToString("yyyy-MM-dd") + "' "
                + " and STCreateDate<='" + dTime2.ToString("yyyy-MM-dd 23:59:59") + "' "
                + " order by STSerial", out dt))
            {
                ErrMsg = "获取盘点列表失败";
                return -1;
            }

            return 0;
        }

        //转移至历史库
        public static int STItemToHis(DateTime dTime1, DateTime dTime2,string czr)
        {
            try
            {
                db.BeginTrans();
            
                string param = TDBObject.ToDBVal(dTime1.ToString("yyyy-MM-dd")) + ","
                    + TDBObject.ToDBVal(dTime2.ToString("yyyy-MM-dd 23:59:59")) + ","
                    + TDBObject.ToDBVal(czr);

                db.ExecProcedure("STItem_ToHis", param);
                db.Commit();

                return 0;
            }
            catch
            {
                db.RollBack();

                return -1;
            }

            //ErrMsg = "";
            //try
            //{
            //    string strsql = "delete from STOrder where STStatus<>-1 "
            //        + " and STCreateDate>='" + dTime1.ToString("yyyy-MM-dd") + "' "
            //        + " and STCreateDate<='" + dTime2.ToString("yyyy-MM-dd 23:59:59") + "'";
            //    db.Excute(strsql);

            //    return 0;
            //}
            //catch (Exception ex)
            //{
            //    ErrMsg = ex.Message;
            //    return -1;
            //}

        }


        //转移至历史库-单条
        public static int STItemToHis_s(string STSerial, string czr)
        {
            try
            {
                db.BeginTrans();
                db.ExecSQL("insert into STOrderdetail_His(OperatorUser,STSerial,czr,czrq) select OperatorUser,STSerial,'"+czr+"',czrq=getdate() from STOrderdetail where stserial = '" + STSerial + "'");
                db.ExecSQL("insert into STOrder_His(STSerial,STType,STCreateDate,STStatus,STDesc,STCreateUser,Plant,DocumentID,czr,czrq) select STSerial,STType,STCreateDate,STStatus,STDesc,STCreateUser,Plant,DocumentID,'" + czr + "',czrq=getdate() from STOrder where STStatus<>-1 and STSerial = '" + STSerial + "'");
                db.ExecSQL("delete from STOrderDetail where stserial = '" + STSerial + "'");
                db.ExecSQL("delete from STOrder where STStatus<>-1 and STSerial = '" + STSerial + "'");
                db.Commit();

                return 0;
            }
            catch
            {
                db.RollBack();

                return -1;
            }
        }
        #endregion
    }
}
