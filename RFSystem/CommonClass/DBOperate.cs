using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace RFSystem
{
    public class DBOperate
    {
        private static string m_ConnStr;
        private static TDB m_db;

        public static int AddAmountArriveStoreDeal(string arriveListID, decimal addAmount)
        {
            string param = $"{TDBObject.ToDBVal(arriveListID)}, {TDBObject.ToDBVal(addAmount)}";

            return db.ExecProcedure("RF_ArriveStoreDeal_AddAmount", param);
        }

        public static int AddArriveStoreExceptionInfo(ArrayList exceptionInfo)
        {
            string param = "";

            foreach (object obj2 in exceptionInfo)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_ArriveStoreExceptionInfo_Add", param);
        }

        public static int AddCompare(decimal stSerial)
        {
            string param = $"{TDBObject.ToDBVal(stSerial)}";

            return db.ExecProcedure("RF_ST_CompareAdd", param);
        }

        public static int AddNewSTOrigin(ArrayList stOriginList)
        {
            string param = "";

            foreach (object obj2 in stOriginList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_ST_STOriginAddNew", param);
        }

        public static int AddPlant(string plantID, string plantDescription)
        {
            string param = $"{TDBObject.ToDBVal(plantID)}, {TDBObject.ToDBVal(plantDescription)}";

            return db.ExecProcedure("RF_Plant_Add", param);
        }

        public static int AddPrinter(ArrayList printerItem)
        {
            string param = "";

            foreach (object obj2 in printerItem)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_Printer_Add", param);
        }

        public static int AddSapUser(string sapUserID, string sapPassword)
        {
            string param = $"{TDBObject.ToDBVal(sapUserID)}, {TDBObject.ToDBVal(sapPassword)}";

            return db.ExecProcedure("RF_SapUser_Add", param);
        }

        public static int AddStorageExceptionInfo(ArrayList exceptionStorageInfo)
        {
            string param = "";

            foreach (object obj2 in exceptionStorageInfo)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_StorageExceptionInfo_Add", param);
        }

        public static int AddStoreLocus(string storeLocusID, string plantID, string storeLocusDescription)
        {
            string param = $"{TDBObject.ToDBVal(storeLocusID)}, {TDBObject.ToDBVal(plantID)}, {TDBObject.ToDBVal(storeLocusDescription)}";

            return db.ExecProcedure("RF_StoreLocus_Add", param);
        }

        public static int AddUser(ArrayList userItem)
        {
            string param = "";

            foreach (object obj2 in userItem)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_User_Add", param);
        }

        public static DataSet ApplyRFNum(string userID, string moduleKey)
        {
            DataSet ds = null;
            string param = TDBObject.ToDBVal(userID) + "," + TDBObject.ToDBVal(moduleKey);
            db.OpenProcedure("RF_ApplyRFNum", param, out ds);

            return ds;
        }

        public static string ArriveStoreExceptionInfoAdd(ArrayList demurralList, DataTable demurralInfoList)
        {
            db.BeginTrans();

            try
            {
                int num = AddArriveStoreExceptionInfo(demurralList);

                foreach (DataRow row in demurralInfoList.Rows)
                {
                    string str = Guid.NewGuid().ToString();
                    ArrayList exceptionStorageInfo = new ArrayList();
                    exceptionStorageInfo.Add(demurralList[0].ToString());
                    exceptionStorageInfo.Add(str);
                    exceptionStorageInfo.Add((string)row[0]);
                    exceptionStorageInfo.Add(Convert.ToInt32(row[1]));
                    exceptionStorageInfo.Add((string)row[2]);

                    if (AddStorageExceptionInfo(exceptionStorageInfo) == -1)
                    {
                        db.RollBack();
                        return "-1";
                    }
                }

                db.Commit();

                return "0";
            }
            catch
            {
                db.RollBack();

                return "-1";
            }
        }

        public static string ArriveStoreMod(ArrayList billInfo, DataTable storageInfoList)
        {
            db.BeginTrans();
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();

            try
            {
                OleDbParameter[] arParams = new OleDbParameter[billInfo.Count];

                for (int i = 0; i < arParams.Length; i++)
                {
                    arParams[i] = new OleDbParameter(billInfo[i].ToString(), billInfo[i]);
                }

                db.Excute("RF_ArriveStoreInfo_Mod", arParams, 1);

                if (DelStorageInfo(billInfo[0].ToString()) != -1)
                {
                    foreach (DataRow row in storageInfoList.Rows)
                    {
                        ArrayList list5 = new ArrayList();
                        list.Add(billInfo[0].ToString());
                        list2.Add((string)row[0]);
                        list3.Add(Convert.ToInt32(row[1]));
                        list4.Add((string)row[2]);
                    }

                    for (int j = 0; j < list.Count; j++)
                    {
                        OleDbParameter[] parameterArray2 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[j]) };
                        db.Excute(SqlManager.ARRIVESTORE_SPLIT_ADDZERO, parameterArray2, 0);
                        OleDbParameter[] parameterArray3 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[j]), new OleDbParameter("StorePosition", (string)list2[j]), new OleDbParameter("Amount", list3[j].ToString()), new OleDbParameter("Remark", (string)list4[j]), new OleDbParameter("ArriveListID", (string)list[j]) };
                        db.Excute(SqlManager.ARRIVESTORE_SPLIT, parameterArray3, 0);
                        OleDbParameter[] parameterArray4 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[j]) };
                        db.Excute(SqlManager.ARRIVESTORE_SPLIT_DELZERO, parameterArray4, 0);
                    }
                }
                else
                {
                    db.RollBack();

                    return "-1";
                }

                db.Commit();

                return "0";
            }
            catch
            {
                db.RollBack();

                return "-1";
            }
        }

        public static string ArriveStoreNewBill(string userID, string MODULEKEY_ARRIVESTORE, ArrayList billInfo, DataTable storageInfoList)
        {
            db.BeginTrans();
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();

            try
            {
                OleDbParameter[] arParams = new OleDbParameter[billInfo.Count + 1];
                string name = (string)ApplyRFNum(userID, MODULEKEY_ARRIVESTORE).Tables[0].Rows[0][0];

                if (name != "-1")
                {
                    arParams[0] = new OleDbParameter(name, name);

                    for (int i = 1; i < arParams.Length; i++)
                    {
                        arParams[i] = new OleDbParameter(billInfo[i - 1].ToString(), billInfo[i - 1]);
                    }

                    db.Excute("RF_ArriveStoreInfo_Add", arParams, 1);

                    foreach (DataRow row in storageInfoList.Rows)
                    {
                        ArrayList list5 = new ArrayList();
                        list.Add(name);
                        list2.Add((string)row[0]);
                        list3.Add(Convert.ToInt32(row[1]));
                        list4.Add((string)row[2]);
                    }

                    for (int j = 0; j < list.Count; j++)
                    {
                        OleDbParameter[] parameterArray2 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[j]) };
                        db.Excute(SqlManager.ARRIVESTORE_SPLIT_ADDZERO, parameterArray2, 0);
                        OleDbParameter[] parameterArray3 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[j]), new OleDbParameter("StorePosition", (string)list2[j]), new OleDbParameter("Amount", list3[j].ToString()), new OleDbParameter("Remark", (string)list4[j]), new OleDbParameter("ArriveListID", (string)list[j]) };
                        db.Excute(SqlManager.ARRIVESTORE_SPLIT, parameterArray3, 0);
                        OleDbParameter[] parameterArray4 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[j]) };
                        db.Excute(SqlManager.ARRIVESTORE_SPLIT_DELZERO, parameterArray4, 0);
                    }

                    db.Commit();

                    return name;
                }

                db.RollBack();

                return "-1";
            }
            catch
            {
                db.RollBack();

                return "-1";
            }
        }

        public static int BlankOutSTOrigin(int itemNo)
        {
            string param = $"{TDBObject.ToDBVal(itemNo)}";

            return db.ExecProcedure("RF_ST_STOriginBlankOut", param);
        }

        public static int CancelSTItem(string STSerial, string User_ID, out string ErrMsg)
        {
            ErrMsg = "";
            DataTable dt = new DataTable();

            if (0 != db.OpenDataSet("select * from STOrder where STSerial=" + STSerial + " and STStatus =0 and STCreateUser='" + User_ID + "'", out dt))
            {
                ErrMsg = "获取盘点单号状态失败";
                return -1;
            }

            if (dt.Rows.Count <= 0)
            {
                ErrMsg = "该单据所处的状态不能够被作废，有可能你已经在别的机器上面操作了该单据，建议重新查询";
                return -1;
            }

            switch (db.ExecSQL("update STOrder set STStatus=-1 where STSerial=" + STSerial + " and STStatus=0"))
            {
                case -1:
                    ErrMsg = "作废单据时出现失败";
                    return -1;

                case 0:
                    ErrMsg = "该单据所处的状态不能够被作废，有可能你已经在别的机器上面操作了该单据，建议重新查询";
                    return -1;
            }

            return 0;
        }

        public static DataTable CheckCompare(string stSerial)
        {
            string param = $"{TDBObject.ToDBVal(stSerial)}";

            db.OpenProcedure("RF_ST_CompareCheck", param, out DataTable dt);

            return dt;
        }

        public static DataSet CompareInfo(ArrayList stOriginList)
        {
            string param = "";

            foreach (object obj2 in stOriginList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            db.OpenProcedure("RF_ST_CompareInfo", param, out DataSet ds);

            return ds;
        }

        public static DataTable CompareOther(ArrayList stOriginList)
        {
            string param = "";

            foreach (object obj2 in stOriginList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            db.OpenProcedure("RF_ST_CompareOther", param, out DataTable dt);

            return dt;
        }

        public static DataTable CompareSum(ArrayList stOriginList)
        {
            string param = "";

            foreach (object obj2 in stOriginList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            db.OpenProcedure("RF_ST_CompareSum", param, out DataTable dt);

            return dt;
        }

        public static int DelArriveStoreExceptionInfo(string exceptionID)
        {
            string param = $"{TDBObject.ToDBVal(exceptionID)}";

            return db.ExecProcedure("RF_ArriveStoreExceptionInfo_Del", param);
        }

        public static int DelBill(string arriveListID)
        {
            string param = $"{TDBObject.ToDBVal(arriveListID)}";

            return db.ExecProcedure("RF_ArriveStoreInfo_Del", param);
        }

        public static int DelPlant(string plantID)
        {
            string param = TDBObject.ToDBVal(plantID);

            return db.ExecProcedure("RF_Plant_Del", param);
        }

        public static int DelPrinter(string printerName)
        {
            string param = TDBObject.ToDBVal(printerName);

            return db.ExecProcedure("RF_Printer_Del", param);
        }

        public static int DelSapUser(string sapUserID)
        {
            string param = TDBObject.ToDBVal(sapUserID);

            return db.ExecProcedure("RF_SapUser_Del", param);
        }

        public static int DelStorageInfo(string arriveListID)
        {
            string param = $"{TDBObject.ToDBVal(arriveListID)}";

            return db.ExecProcedure("RF_StorageInfo_Del", param);
        }

        public static int DelStoreLocus(string storeLocusID, string plantID)
        {
            string param = $"{TDBObject.ToDBVal(storeLocusID)}, {TDBObject.ToDBVal(plantID)}";

            return db.ExecProcedure("RF_StoreLocus_Del", param);
        }

        public static int DelUser(string userID)
        {
            string param = TDBObject.ToDBVal(userID);

            return db.ExecProcedure("RF_User_Del", param);
        }

        public static int DelUserRoles(string userID)
        {
            string param = TDBObject.ToDBVal(userID);

            return db.ExecProcedure("RF_UserRoles_Del", param);
        }

        public static string ExcelUpdateStock(DataTable stockInfoList)
        {
            db.BeginTrans();

            try
            {
                foreach (DataRow row in stockInfoList.Rows)
                {
                    OleDbParameter[] arParams = new OleDbParameter[] { new OleDbParameter("工厂", row["工厂"].ToString()), new OleDbParameter("物料代码", row["物料代码"].ToString()), new OleDbParameter("批号", row["批号"].ToString()) };
                    db.Excute(SqlManager.EXCELSTOCK_DELETE, arParams, 0);
                    OleDbParameter[] parameterArray2 = new OleDbParameter[] { 
                        new OleDbParameter("工厂", Convert.ToString(row["工厂"])), new OleDbParameter("库存地", Convert.ToString(row["库存地"])), new OleDbParameter("物料代码", Convert.ToString(row["物料代码"])), new OleDbParameter("物料描述", Convert.ToString(row["物料描述"])), new OleDbParameter("详细描述", Convert.ToString(row["详细描述"])), new OleDbParameter("物料类型", Convert.ToString(row["物料类型"])), new OleDbParameter("    数量", Convert.ToDecimal(row["    数量"])), new OleDbParameter("收货数量", Convert.ToDecimal(row["收货数量"])), new OleDbParameter("支出数量", Convert.ToDecimal(row["支出数量"])), new OleDbParameter("批号", Convert.ToString(row["批号"])), new OleDbParameter("       金额", Convert.ToDecimal(row["       金额"])), new OleDbParameter("  单重", Convert.ToDecimal(row["  单重"])), new OleDbParameter("产线代码", Convert.ToString(row["产线代码"])), new OleDbParameter("产线描述", Convert.ToString(row["产线描述"])), new OleDbParameter("保管员", Convert.ToString(row["保管员"])), new OleDbParameter("入库日期", Convert.ToDateTime(row["入库日期"])), 
                        new OleDbParameter("货位1", Convert.ToString(row["货位1"])), new OleDbParameter("货位1数量", Convert.ToDecimal(row["货位1数量"])), new OleDbParameter("货位2", Convert.ToString(row["货位2"])), new OleDbParameter("货位2数量", Convert.ToDecimal(row["货位2数量"])), new OleDbParameter("货位3", Convert.ToString(row["货位3"])), new OleDbParameter("货位3数量", Convert.ToDecimal(row["货位3数量"])), new OleDbParameter("备件类别", Convert.ToString(row["备件类别"])), new OleDbParameter("点检员", Convert.ToString(row["点检员"])), new OleDbParameter("采购申请", Convert.ToString(row["采购申请"])), new OleDbParameter("采购申请行项目", Convert.ToString(row["采购申请行项目"])), new OleDbParameter("计划号", Convert.ToString(row["计划号"])), new OleDbParameter("计划行项目", Convert.ToString(row["计划行项目"])), new OleDbParameter("采购订单号", Convert.ToString(row["采购订单号"])), new OleDbParameter("订单行项目", Convert.ToString(row["订单行项目"]))
                     };
                    db.Excute(SqlManager.EXCELSTOCK_INSERT, parameterArray2, 0);
                }

                db.Commit();

                return "0";
            }
            catch
            {
                db.RollBack();

                return "-1";
            }
        }

        public static DataTable GetArriveListArriveStoreExceptionInfo(string userID, int userRole)
        {
            string param = $"{TDBObject.ToDBVal(userID)}, {TDBObject.ToDBVal(userRole)}";

            db.OpenProcedure("RF_ArriveStoreExceptionInfo_GetArriveList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetArriveListArriveStoreInfo()
        {
            string param = "";

            db.OpenProcedure("RF_ArriveStoreInfo_GetArriveList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetArriveStoreExceptionInfoList(ArrayList exceptionInfo)
        {
            string param = "";

            foreach (object obj2 in exceptionInfo)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            db.OpenProcedure("RF_ArriveStoreExceptionInfo_GetList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetMRoles()
        {
            string param = "";

            db.OpenProcedure("RF_M_Roles_Get", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetNewIDArriveStoreInfoSplit(string arriveListID)
        {
            string param = $"{TDBObject.ToDBVal(arriveListID)}";

            db.OpenProcedure("RF_ArriveStoreInfoSplit_GetNewID", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetPlant()
        {
            string param = "";

            db.OpenProcedure("RF_Plant_Get", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetPlantList(string plantID)
        {
            string param = $"{TDBObject.ToDBVal(plantID)}";

            db.OpenProcedure("RF_Plant_GetList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetPrinterList(string printerName, string printerAddress)
        {
            string param = $"{TDBObject.ToDBVal(printerName)}, {TDBObject.ToDBVal(printerAddress)}";

            db.OpenProcedure("RF_Printer_GetList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetSapInfoBySapID(string sapRolePoint)
        {
            string param = $"{TDBObject.ToDBVal(sapRolePoint)}";

            db.OpenProcedure("RF_User_GetSapInfo", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetSapUser()
        {
            string param = "";

            db.OpenProcedure("RF_SapUser_Get", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetSapUserList(string sapUserID)
        {
            string param = $"{TDBObject.ToDBVal(sapUserID)}";

            db.OpenProcedure("RF_SapUser_GetList", param, out DataTable dt);

            return dt;
        }

        public static int GetSTItem(string Type, DateTime dTime, out DataTable dt, out string ErrMsg)
        {
            ErrMsg = "";
            dt = new DataTable();

            if (0 != db.OpenDataSet("select * from STOrder where STStatus<>-1 order by STSerial", out dt))
            {
                ErrMsg = "获取盘点列表失败";
                return -1;
            }

            return 0;
        }

        public static int GetSTItemDetail(string STSerial, out DataTable dt, out string ErrMsg)
        {
            ErrMsg = "";
            dt = new DataTable();

            if (0 != db.OpenDataSet("select * from STOrderDetail where STSerial=" + STSerial, out dt))
            {
                ErrMsg = "获取盘点单详细盘点人失败";
                return -1;
            }

            return 0;
        }

        public static int GetSTList(out DataSet ds, out string ErrMsg)
        {
            ErrMsg = "";
            string param = "";

            if (0 != db.OpenProcedure("RF_User_CanST", param, out ds))
            {
                ErrMsg = "获取操作员信息失败。";
                return -1;
            }

            return 0;
        }

        public static int GetSTNumber(out string STNumber, out string ErrMsg)
        {
            ErrMsg = "";
            STNumber = "";
            string param = "";

            if (0 != db.OpenProcedure("POS_RFINF_ApplyRFNum", param, out DataSet ds))
            {
                ErrMsg = "获取盘点号信息失败。";
                return -1;
            }

            if (ds.Tables[0].Rows.Count != 0)
            {
                STNumber = ds.Tables[0].Rows[0][0].ToString();
                return 0;
            }

            ErrMsg = "获取盘点号信息失败。";

            return -1;
        }

        public static DataTable GetStorageExceptionInfoList(string exceptionID)
        {
            string param = TDBObject.ToDBVal(exceptionID);

            db.OpenProcedure("RF_StorageExceptionInfo_GetList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetStoreLocusList(string storeLocusID, string plantID)
        {
            string param = $"{TDBObject.ToDBVal(storeLocusID)}, {TDBObject.ToDBVal(plantID)}";

            db.OpenProcedure("RF_StoreLocus_GetList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetStoreLocusWithPlant(string plantID)
        {
            string param = $"{TDBObject.ToDBVal(plantID)}";

            db.OpenProcedure("RF_StoreLocus_GetWithPlant", param, out DataTable dt);

            return dt;
        }

        public static DataSet GetUserByLogin(UserInfo userItem)
        {
            string param = $"{TDBObject.ToDBVal(userItem.userID)}, {TDBObject.ToDBVal(userItem.passWord)}";
            
            db.OpenProcedure("rfid2021.dbo.RF_User_GetByLogin", param, out DataSet ds);

            return ds;
        }

        public static DataTable GetUserIDName(string userID)
        {
            string param = TDBObject.ToDBVal(userID);

            db.OpenProcedure("RF_User_GetIDName", param, out DataTable dt);

            return dt;
        }

        public static void clearE1DV11(string bxJobId)
        {
            //db.SqlType = TDB.ESQL_TYPE.NonQuery;
            db.Excute("DELETE bx_transaction_E1DV11 WHERE custodianJobId = '" + bxJobId + "'");

            db.Excute("DELETE bx_transaction_E1DV12 WHERE custodianJobId = '" + bxJobId + "'");
        }

        public static void clearbx_transaction(string bxJobId)
        {
            //db.SqlType = TDB.ESQL_TYPE.NonQuery;
            db.Excute("delete bx_transaction where custodianJobId = '" + bxJobId + "'");
        }

        public static DataTable getE1DV11(string bxJobId)
        {
            db.OpenDataSet("select * from bx_transaction_E1DV11 where custodianJobId = '" + bxJobId + "'", out DataTable dt);

            return dt;
        }

        public static int updateTransaction(string bxJobId)
        {
            db.BeginTrans();

            try
            {
                int updateCount = db.ExecSQL("insert into bx_transaction select * from bx_transaction_E1DV11 where custodianJobId = '" + bxJobId + "'");
                db.Commit();
                return updateCount;
            }
            catch
            {
                db.RollBack();
                return -1;
            }
        }

        public static DataTable GetUserList(string userID, string userName, bool InEffect)
        {
            string param = $"{TDBObject.ToDBVal(userID)}, {TDBObject.ToDBVal(userName)}, {TDBObject.ToDBVal(InEffect ? "T" : "F")}";
            
            db.OpenProcedure("RF_User_GetList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetUserRoles(string userID)
        {
            string param = $"{TDBObject.ToDBVal(userID)}";

            db.OpenProcedure("RF_UserRoles_Get", param, out DataTable dt);

            return dt;
        }

        public static int InSertSTOrder(DataTable DtUserID, string CreateUser, string STType, string STDesc, string STNumber, string DocumentID, string Plant, out string ErrMsg)
        {
            ErrMsg = "";

            OleDbParameter parameter = new OleDbParameter();
            parameter.DbType = DbType.String;
            parameter.SourceColumn = "User_ID";
            parameter.ParameterName = "@User_ID";
            parameter.Size = 100;

            OleDbParameter parameter2 = new OleDbParameter();
            parameter2.DbType = DbType.String;
            parameter2.ParameterName = "@STSerial";
            parameter2.Value = STNumber;

            OleDbParameter parameter3 = new OleDbParameter();
            parameter3.DbType = DbType.String;
            parameter3.Value = CreateUser;
            parameter3.ParameterName = "@STCreateUser";

            OleDbParameter parameter4 = new OleDbParameter();
            parameter4.DbType = DbType.String;
            parameter4.Size = 100;
            parameter4.Value = STDesc;
            parameter4.ParameterName = "@STDesc";

            OleDbParameter parameter5 = new OleDbParameter();
            parameter5.DbType = DbType.String;
            parameter5.Value = "0";
            parameter5.ParameterName = "@STStatus";

            OleDbParameter parameter6 = new OleDbParameter();
            parameter6.DbType = DbType.Int32;
            parameter6.Value = STNumber;
            parameter6.ParameterName = "@STSerial";

            OleDbParameter parameter7 = new OleDbParameter();
            parameter7.DbType = DbType.String;
            parameter7.Value = STType;
            parameter7.ParameterName = "@STType";

            OleDbParameter parameter8 = new OleDbParameter();
            parameter8.DbType = DbType.String;
            parameter8.Value = DocumentID;
            parameter8.ParameterName = "@DocumentID";

            OleDbParameter parameter9 = new OleDbParameter();
            parameter9.DbType = DbType.String;
            parameter9.Value = Plant;
            parameter9.ParameterName = "@Plant";

            OleDbCommand command = new OleDbCommand();
            command.CommandText = "insert into STOrder (STSerial,STType,STStatus,STDesc,STCreateUser,DocumentID,Plant) values(?,?,?,?,?,?,?)";
            command.Parameters.Add(parameter6);
            command.Parameters.Add(parameter7);
            command.Parameters.Add(parameter5);
            command.Parameters.Add(parameter4);
            command.Parameters.Add(parameter3);
            command.Parameters.Add(parameter8);
            command.Parameters.Add(parameter9);

            OleDbCommand command2 = new OleDbCommand();
            command2.CommandText = "insert into STOrderDetail (STSerial,OperatorUser) values(" + STNumber + ",?)";
            command2.Parameters.Add(parameter);

            DictionaryEntry entry = new DictionaryEntry();
            entry.Key = command;
            entry.Value = null;
            ArrayList arrList = new ArrayList();
            arrList.Add(entry);

            if (0 != db.ExcuteInsertCommand(arrList))
            {
                ErrMsg = "插入盘点单号头信息到数据库失败";
                return -1;
            }

            return 0;
        }

        public static int MaintainDetailAddCount(ArrayList alParams)
        {
            string param = "";

            foreach (object obj2 in alParams)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_Maintain_Detail_AddCount", param);
        }

        public static DataTable MaintainGetDetail(string maintainNo)
        {
            string param = $"{TDBObject.ToDBVal(maintainNo)}";

            db.OpenProcedure("RF_Maintain_SelectDetail", param, out DataTable dt);

            return dt;
        }

        public static DataTable MaintainGetHead(ArrayList arriveList)
        {
            string param = "";

            foreach (object obj2 in arriveList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            db.OpenProcedure("RF_Maintain_SelectMaster", param, out DataTable dt);

            return dt;
        }
        
        public static int MaintainModState(string maintainNo, string oldState, string state)
        {
            string param = "";
            param = ((param + TDBObject.ToDBVal(maintainNo) + ",") + TDBObject.ToDBVal(oldState) + ",") + TDBObject.ToDBVal(state);

            return db.ExecProcedure("RF_Maintain_ModState", param);
        }

        public static string MaintainNewPlan(string userID, string MODULEKEY_MAINTAIN, ArrayList billInfo, DataTable storageInfoList)
        {
            db.BeginTrans();

            try
            {
                OleDbParameter[] arParams = new OleDbParameter[billInfo.Count + 1];
                string name = (string)ApplyRFNum(userID, MODULEKEY_MAINTAIN).Tables[0].Rows[0][0];

                if (name != "-1")
                {
                    arParams[0] = new OleDbParameter(name, name);

                    for (int i = 1; i < arParams.Length; i++)
                    {
                        arParams[i] = new OleDbParameter(billInfo[i - 1].ToString(), billInfo[i - 1]);
                    }

                    db.Excute(SqlManager.MAINTAIN_INSERTMAIN, arParams, 0);

                    foreach (DataRow row in storageInfoList.Rows)
                    {
                        OleDbParameter[] parameterArray2 = new OleDbParameter[] { new OleDbParameter("MAINTAIN_NO", name), new OleDbParameter("BARCODE", (string)row[0]), new OleDbParameter("FACT_NO", (string)row[1]), new OleDbParameter("PRODUCT_NO", (string)row[2]), new OleDbParameter("PATCH_NO", (string)row[3]), new OleDbParameter("PRODUCT_NAME", row[4]), new OleDbParameter("UNIT", (string)row[5]), new OleDbParameter("BIN", (string)row[6]), new OleDbParameter("BIN_NUM", Convert.ToDecimal(row[7])), new OleDbParameter("PLAN_NUM", Convert.ToDecimal(row[8])), new OleDbParameter("MAINTAINNUM", Convert.ToDecimal(row[9])), new OleDbParameter("SUPPLIER_NO", (string)row[10]), new OleDbParameter("WEIGHT", (string)row[11]) };
                        db.Excute(SqlManager.MAINTAIN_INSERTLIST, parameterArray2, 0);
                    }

                    db.Commit();

                    return name;
                }

                db.RollBack();

                return "-1";
            }
            catch
            {
                db.RollBack();
                return "-1";
            }
        }

        public static bool MaintainReMaintain(DataTable dtMaintainDetail)
        {
            db.BeginTrans();

            try
            {
                string param = "";
                param = ((param + TDBObject.ToDBVal(dtMaintainDetail.Rows[0]["MAINTAIN_NO"].ToString()) + ",") + TDBObject.ToDBVal("2") + ",") + TDBObject.ToDBVal("1");

                if (db.ExecProcedure("RF_Maintain_ModState", param) == 1)
                {
                    foreach (DataRow row in dtMaintainDetail.Rows)
                    {
                        if (row.Equals(dtMaintainDetail.Rows[dtMaintainDetail.Rows.Count - 1]))
                        {
                            break;
                        }

                        OleDbParameter[] arParams = new OleDbParameter[] { new OleDbParameter("MAINTAINNUM", Convert.ToDecimal(row["MAINTAINNUM"])), new OleDbParameter("MAINTAIN_NO", (string)row["MAINTAIN_NO"]), new OleDbParameter("BARCODE", (string)row["BARCODE"]), new OleDbParameter("BIN", (string)row["BIN"]) };
                        db.Excute(SqlManager.MAINTAIN_REMAINTAIN, arParams, 0);
                    }

                    db.Commit();

                    return true;
                }

                db.RollBack();

                return false;
            }
            catch
            {
                db.RollBack();
                return false;
            }
        }

        public static string MergeArriveStore(ArrayList billInfo, DataTable storageInfoList)
        {
            db.BeginTrans();
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();

            try
            {
                OleDbParameter[] arParams = new OleDbParameter[billInfo.Count];

                for (int i = 0; i < arParams.Length; i++)
                {
                    arParams[i] = new OleDbParameter(billInfo[i].ToString(), billInfo[i]);
                }

                db.Excute("RF_ArriveStoreInfo_Merge", arParams, 1);

                foreach (DataRow row in storageInfoList.Rows)
                {
                    ArrayList list5 = new ArrayList();
                    list.Add(billInfo[0].ToString());
                    list2.Add((string)row[0]);
                    list3.Add(Convert.ToInt32(row[1]));
                    list4.Add((string)row[2]);
                }

                for (int j = 0; j < list.Count; j++)
                {
                    OleDbParameter[] parameterArray2 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[j]) };
                    db.Excute(SqlManager.ARRIVESTORE_SPLIT_ADDZERO, parameterArray2, 0);
                    OleDbParameter[] parameterArray3 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[j]), new OleDbParameter("StorePosition", (string)list2[j]), new OleDbParameter("Amount", list3[j].ToString()), new OleDbParameter("Remark", (string)list4[j]), new OleDbParameter("ArriveListID", (string)list[j]) };
                    db.Excute(SqlManager.ARRIVESTORE_SPLIT, parameterArray3, 0);
                    OleDbParameter[] parameterArray4 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[j]) };
                    db.Excute(SqlManager.ARRIVESTORE_SPLIT_DELZERO, parameterArray4, 0);
                }

                db.Commit();

                return "1";
            }
            catch
            {
                db.RollBack();
                return "-1";
            }
        }

        public static int ModArriveStoreDeal(ArrayList dealInfo)
        {
            string param = "";

            foreach (object obj2 in dealInfo)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_ArriveStoreDeal_Mod", param);
        }

        public static int ModPlant(string plantID, string plantDescription)
        {
            string param = $"{TDBObject.ToDBVal(plantID)}, {TDBObject.ToDBVal(plantDescription)}";

            return db.ExecProcedure("RF_Plant_Mod", param);
        }

        public static int ModPrinter(ArrayList printerItem)
        {
            string param = "";

            foreach (object obj2 in printerItem)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_Printer_Mod", param);
        }

        public static int ModReport(ArrayList reportList)
        {
            string param = "";

            foreach (object obj2 in reportList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_ST_ReportMod", param);
        }

        public static int ModReportCausation(string reportID, string reportSation)
        {
            string param = $"{TDBObject.ToDBVal(reportID)}, {TDBObject.ToDBVal(reportSation)}";

            return db.ExecProcedure("RF_ST_ReportCausation", param);
        }

        public static int ModSapUser(string sapUserID, string sapPassword)
        {
            string param = $"{TDBObject.ToDBVal(sapUserID)}, {TDBObject.ToDBVal(sapPassword)}";

            return db.ExecProcedure("RF_SapUser_Mod", param);
        }

        public static int ModStoreLocus(string storeLocusID, string plantID, string storeLocusDescription)
        {
            string param = $"{TDBObject.ToDBVal(storeLocusID)}, {TDBObject.ToDBVal(plantID)}, {TDBObject.ToDBVal(storeLocusDescription)}";

            return db.ExecProcedure("RF_StoreLocus_Mod", param);
        }

        public static int ModSTOrigin(ArrayList stOriginList)
        {
            string param = "";

            foreach (object obj2 in stOriginList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_ST_STOriginMod", param);
        }

        public static int ModUser(ArrayList userItem)
        {
            string param = "";

            foreach (object obj2 in userItem)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_User_Mod", param);
        }

        public static int ModUserRoles(string userID, string userRoles)
        {
            string param = TDBObject.ToDBVal(userID) + "," + TDBObject.ToDBVal(userRoles);
            return db.ExecProcedure("RF_UserRoles_Mod", param);
        }

        public static int RebornUser(string userID)
        {
            string param = TDBObject.ToDBVal(userID);
            return db.ExecProcedure("RF_User_Reborn", param);
        }

        public static DataTable SelectArriveStoreInfo(ArrayList goodsInfo)
        {
            string param = "";

            foreach (object obj2 in goodsInfo)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            db.OpenProcedure("RF_ArriveStoreInfo_Select", param, out DataTable dt);

            return dt;
        }

        public static DataTable SelectArriveStoreStorageInfo(string arriveListID)
        {
            DataTable dt = null;
            string param = "";
            param = param + TDBObject.ToDBVal(arriveListID);
            db.OpenProcedure("RF_ArriveStoreStorageInfo_Select", param, out dt);

            return dt;
        }

        public static DataTable SelectReport(ArrayList stReportList)
        {
            string param = "";

            foreach (object obj2 in stReportList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            db.OpenProcedure("RF_ST_ReportSelect", param, out DataTable dt);

            return dt;
        }

        public static string SplitArriveStore(string arriveID, ArrayList billInfo, DataTable storageInfoListF, DataTable storageInfoListS)
        {
            db.BeginTrans();
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();

            try
            {
                OleDbParameter[] arParams = new OleDbParameter[] { new OleDbParameter("@ArriveListID", (string)billInfo[0]), new OleDbParameter("@ConsignmentAmount", Convert.ToInt32(billInfo[1])), new OleDbParameter("@AcceptAmount", Convert.ToInt32(billInfo[2])), new OleDbParameter("@AcceptWeight", Convert.ToInt32(billInfo[3])) };
                db.Excute("RF_ArriveStoreInfo_Split", arParams, 1);
                DataTable newIDArriveStoreInfoSplit = GetNewIDArriveStoreInfoSplit(billInfo[0].ToString());

                if (newIDArriveStoreInfoSplit.Rows[0][0].ToString() != "-1")
                {
                    ArrayList list5;

                    foreach (DataRow row in storageInfoListF.Rows)
                    {
                        list5 = new ArrayList();
                        list.Add(arriveID);
                        list2.Add((string)row[0]);
                        list3.Add(Convert.ToInt32(row[1]));
                        list4.Add((string)row[2]);
                    }

                    foreach (DataRow row in storageInfoListS.Rows)
                    {
                        list5 = new ArrayList();
                        list.Add(newIDArriveStoreInfoSplit.Rows[0][0].ToString());
                        list2.Add((string)row[0]);
                        list3.Add(Convert.ToInt32(row[1]));
                        list4.Add((string)row[2]);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        OleDbParameter[] parameterArray2 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[i]) };
                        db.Excute(SqlManager.ARRIVESTORE_SPLIT_ADDZERO, parameterArray2, 0);
                        OleDbParameter[] parameterArray3 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[i]), new OleDbParameter("StorePosition", (string)list2[i]), new OleDbParameter("Amount", list3[i].ToString()), new OleDbParameter("Remark", (string)list4[i]), new OleDbParameter("ArriveListID", (string)list[i]) };
                        db.Excute(SqlManager.ARRIVESTORE_SPLIT, parameterArray3, 0);
                        OleDbParameter[] parameterArray4 = new OleDbParameter[] { new OleDbParameter("ArriveListID", (string)list[i]) };
                        db.Excute(SqlManager.ARRIVESTORE_SPLIT_DELZERO, parameterArray4, 0);
                    }

                    db.Commit();

                    return newIDArriveStoreInfoSplit.Rows[0][0].ToString();
                }

                db.RollBack();

                return "-1";
            }
            catch
            {
                db.RollBack();

                return "-1";
            }
        }

        public static int STOrderChangeState(int STSerial, int STStatus)
        {
            string param = $"{TDBObject.ToDBVal(STSerial)}, {TDBObject.ToDBVal(STStatus)}";

            return db.ExecProcedure("RF_ST_STOrderChangeState", param);
        }

        public static DataTable STOrigin(ArrayList stOriginList)
        {
            string param = "";

            foreach (object obj2 in stOriginList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            db.OpenProcedure("RF_ST_STOrigin", param, out DataTable dt);

            return dt;
        }

        public static DataTable STSapStockInfo(ArrayList stList)
        {
            string param = "";

            foreach (object obj2 in stList)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);
            db.OpenProcedure("RF_ST_SapStockInfo", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetContractorList(string conNo)
        {
            string param = TDBObject.ToDBVal(conNo);

            db.OpenProcedure("RF_Contractor_GetList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetLocationList(string locNo)
        {
            string param = TDBObject.ToDBVal(locNo);

            db.OpenProcedure("RF_Location_GetList", param, out DataTable dt);

            return dt;
        }

        public static string UpdateStock(DataTable stockInfoList, string keyWord, bool updateKind)
        {
            //db.BeginTrans();
            try
            {
                OleDbParameter[] parameterArray;

                if (updateKind)
                {
                    parameterArray = new OleDbParameter[] { new OleDbParameter("storeman", keyWord) };
                    db.Excute(SqlManager.STATISTIC_DELETE_STOREMAN, parameterArray, 0);
                }
                else
                {
                    parameterArray = new OleDbParameter[] { new OleDbParameter("bin", keyWord), new OleDbParameter("bin", keyWord), new OleDbParameter("bin", keyWord) };
                    db.Excute(SqlManager.STATISTIC_DELETE_BIN, parameterArray, 0);
                }
                //db.Commit();

                for (int i = 0; i < stockInfoList.Rows.Count; i++)
                {

                    string sqlstr = "insert into t_stock(gch, product_barcode, product_no, patch, SL, product_desc, unit, bin1, bin1_qty, bin2, bin2_qty, bin3, bin3_qty, storeman, ejc, order_no, supplier, weight, amount, stock_qty)";
                    sqlstr += " values ('" + (string)stockInfoList.Rows[i]["Werks"] + "','" + ((string)stockInfoList.Rows[i]["Werks"]) + ((string)stockInfoList.Rows[i]["Charg"]) + ((string)stockInfoList.Rows[i]["Matnr"]) + "','" + (string)stockInfoList.Rows[i]["Matnr"] + "','" + (string)stockInfoList.Rows[i]["Charg"] + "','" + (string)stockInfoList.Rows[i]["Lgort"] + "','" + stockInfoList.Rows[i]["Maktx"] + "','" + stockInfoList.Rows[i]["Meins"] + "','" + (string)stockInfoList.Rows[i]["Bct50"] + "','" + Convert.ToDecimal(stockInfoList.Rows[i]["Bct51"]) + "','" + (string)stockInfoList.Rows[i]["Bct60"] + "','" + Convert.ToDecimal(stockInfoList.Rows[i]["Bct61"]) + "','" + (string)stockInfoList.Rows[i]["Bct70"] + "','" + Convert.ToDecimal(stockInfoList.Rows[i]["Bct71"]) + "','" + (string)stockInfoList.Rows[i]["Bct10"] + "','" + (string)stockInfoList.Rows[i]["Bct20"] + "','" + (string)stockInfoList.Rows[i]["Ebeln"] + "','" + (string)stockInfoList.Rows[i]["Name1"] + "','" + Convert.ToDecimal(stockInfoList.Rows[i]["Ntgew"]) + "','" + Convert.ToDecimal(stockInfoList.Rows[i]["Verpr"]) + "','" + Convert.ToDecimal(stockInfoList.Rows[i]["Menge"]) + "')";

                    try
                    {
                        db.Excute(sqlstr, null, 0);
                    }
                    catch
                    {

                    }
                }

                return "0";
            }
            catch
            {
                return "-1";
            }
        }

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
    }
}

