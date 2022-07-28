using System.Collections;
using System.Data;

namespace RFSystem
{
    public class UserInfo
    {
        public bool isAdmin;
        public bool isEffect;
        public string passWord;
        public string userID;
        public string userName;
        public string JobID;

        public static UserInfo GetUserByLogin(UserInfo userItem, out bool ifExist, out DataTable dtUserRoles)
        {
            DataSet userByLogin = GetUserByLogin(userItem);
            DataTable table = userByLogin.Tables[0];
            dtUserRoles = userByLogin.Tables[1];

            if (table.Rows.Count == 0)
            {
                ifExist = false;
                return null;
            }

            ifExist = true;
            userItem = new UserInfo();

            foreach (DataRow row in table.Rows)
            {
                TDBObject.GetField(row, "User_ID", ref userItem.userID);
                TDBObject.GetField(row, "Post_ID", ref userItem.JobID);
                TDBObject.GetField(row, "User_Name", ref userItem.userName);
                TDBObject.GetField(row, "InEffect", ref userItem.isEffect);
                TDBObject.GetField(row, "IsAdmin", ref userItem.isAdmin);
            }

            return userItem;
        }

        public static DataSet GetUserByLogin(UserInfo userItem)
        {
            string param = $"{TDBObject.ToDBVal(userItem.userID)}, {TDBObject.ToDBVal(userItem.passWord)}";

            TDB.db.OpenProcedure("dbo.RF_User_GetByLogin", param, out DataSet ds);

            return ds;
        }

        public static int updateRF_Users()
        {
            TDB.db.BeginTrans();

            try
            {
                int updateCount = TDB.db.ExecSQL("INSERT INTO RF_Database_CZ.dbo.RF_Users(User_ID,Post_ID,User_Name,Password,SapRolePoint,InEffect,IsAdmin) SELECT userid,postid,userName,'','','True','False' from rfid2021.dbo.bx_E1DV30");
                TDB.db.Commit();
                return updateCount;
            }
            catch
            {
                TDB.db.RollBack();
                return -1;
            }
        }

        public static DataTable GetUserIDName(string userID)
        {
            string param = TDBObject.ToDBVal(userID);

            TDB.db.OpenProcedure("RF_User_GetIDName", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetUserList(string userID, string userName, bool InEffect)
        {
            string param = $"{TDBObject.ToDBVal(userID)}, {TDBObject.ToDBVal(userName)}, {TDBObject.ToDBVal(InEffect ? "T" : "F")}";

            TDB.db.OpenProcedure("RF_User_GetList", param, out DataTable dt);

            return dt;
        }

        public static DataTable GetUserRoles(string userID)
        {
            string param = $"{TDBObject.ToDBVal(userID)}";

            TDB.db.OpenProcedure("RF_UserRoles_Get", param, out DataTable dt);

            return dt;
        }

        public static int ModUser(ArrayList userItem)
        {
            string param = "";

            foreach (object obj2 in userItem)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return TDB.db.ExecProcedure("RF_User_Mod", param);
        }

        public static int ModUserRoles(string userID, string userRoles)
        {
            string param = TDBObject.ToDBVal(userID) + "," + TDBObject.ToDBVal(userRoles);
            return TDB.db.ExecProcedure("RF_UserRoles_Mod", param);
        }

        public static int RebornUser(string userID)
        {
            string param = TDBObject.ToDBVal(userID);
            return TDB.db.ExecProcedure("RF_User_Reborn", param);
        }

        public static int GetSTList(out DataSet ds, out string ErrMsg)
        {
            ErrMsg = "";
            string param = "";

            if (0 != TDB.db.OpenProcedure("RF_User_CanST", param, out ds))
            {
                ErrMsg = "获取操作员信息失败。";
                return -1;
            }

            return 0;
        }

        public static int AddUser(ArrayList userItem)
        {
            string param = "";

            foreach (object obj2 in userItem)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return TDB.db.ExecProcedure("RF_User_Add", param);
        }

        public static int DelUser(string userID)
        {
            string param = TDBObject.ToDBVal(userID);

            return TDB.db.ExecProcedure("RF_User_Del", param);
        }

        public static int DelUserRoles(string userID)
        {
            string param = TDBObject.ToDBVal(userID);

            return TDB.db.ExecProcedure("RF_UserRoles_Del", param);
        }
    }
}
