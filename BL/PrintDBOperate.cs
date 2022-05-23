using DL;
using System.Collections;
using System.Data;

namespace BL
{
    public class PrintDBOperate
    {
        private static string m_ConnStr;
        private static TDB m_db;

        public static int AddLocation(ArrayList locItem)
        {
            string param = "";

            foreach (object obj2 in locItem)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_Location_Add", param);
        }

        public static int DelLocation(string locNo)
        {
            string param = TDBObject.ToDBVal(locNo);

            return db.ExecProcedure("RF_Location_Del", param);
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

        public static int ModLocation(ArrayList locItem)
        {
            string param = "";

            foreach (object obj2 in locItem)
            {
                param = param + TDBObject.ToDBVal(obj2) + ",";
            }

            param = param.Remove(param.Length - 1);

            return db.ExecProcedure("RF_Location_Mod", param);
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
