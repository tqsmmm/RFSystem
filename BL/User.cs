using System.Data;

namespace BL
{
    public class User
    {
        public static UserInfo GetUserByLogin(UserInfo userItem, out bool ifExist, out DataTable dtUserRoles)
        {
            DataSet userByLogin = DBOperate.GetUserByLogin(userItem);
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
                TDBObject.GetField(row, "User_Name", ref userItem.userName);
                TDBObject.GetField(row, "InEffect", ref userItem.isEffect);
                TDBObject.GetField(row, "IsAdmin", ref userItem.isAdmin);
            }

            return userItem;
        }
    }
}
