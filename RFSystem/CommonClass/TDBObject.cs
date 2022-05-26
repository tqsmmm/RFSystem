using System;
using System.Collections;
using System.Data;

namespace RFSystem
{
    public class TDBObject
    {
        private static string CharToHex(int c)
        {
            return ((c >= 0x100) ? c.ToString("X") : ("00" + c.ToString("X")));
        }

        public static void GetField(DataRow dr, string FieldName, ref bool val)
        {
            Type type = dr[FieldName].GetType();

            if (dr[FieldName] is string)
            {
                string str = (string)dr[FieldName];

                if (str.Trim().Equals("T"))
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }
            else
            {
                val = (dr[FieldName] != DBNull.Value) && Convert.ToBoolean(dr[FieldName]);
            }
        }

        public static void GetField(DataRow dr, string FieldName, ref string val)
        {
            val = (dr[FieldName] == DBNull.Value) ? "" : Convert.ToString(dr[FieldName]);
        }

        public static string ToDBStr(string source)
        {
            if (source == null)
            {
                return null;
            }

            string str = "";

            for (int i = 0; i < source.Length; i++)
            {
                str = str + CharToHex(source[i]);
            }

            return str;
        }

        public static string ToDBVal(object FieldVal)
        {
            string source;

            if (FieldVal == null)
            {
                source = "null";
            }
            else
            {
                if ((FieldVal is int) || (FieldVal is long) || (FieldVal is float) || (FieldVal is decimal))
                {
                    return FieldVal.ToString();
                }

                if (FieldVal is string)
                {
                    source = (string)FieldVal;
                    source.Replace("'", "''");
                    return ("'" + source + "'");
                }

                if (FieldVal is DateTime)
                {
                    source = ((DateTime)FieldVal).ToString("yyyy-MM-dd HH:mm:ss");
                    return ("'" + source + "'");
                }

                if (FieldVal is bool)
                {
                    source = ((bool)FieldVal) ? "'T'" : "'F'";
                }
                else
                {
                    if (!(FieldVal is ArrayList))
                    {
                        throw new Exception("未知的数据类型:" + FieldVal.GetType());
                    }

                    ArrayList list = (ArrayList)FieldVal;
                    source = "";

                    for (int i = 0; i < list.Count; i++)
                    {
                        source = source + ((i == 0) ? ((string)list[i]) : ("," + ((string)list[i])));
                    }

                    return ToDBVal(ToDBStr(source));
                }
            }

            return source;
        }
    }
}
