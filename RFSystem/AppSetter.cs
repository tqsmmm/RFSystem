using System.Collections;
using System.Data.SqlClient;

namespace RFSystem
{
    internal static class AppSetter
    {
        public static UserInfo User_Info = null;

        public static ArrayList User_Roles = null;

        public static string AppName = "RF-PSCS库存管理系统";

        public static string REGEX_NUM = @"^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$";
        public static string g_bxuserid = "";
        public static string g_bxusername = "";
        public static string g_bxjobid = "";
    }
}
