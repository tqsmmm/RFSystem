using System;
using System.Collections;
using System.Data;

namespace SapService
{
	/// <summary>
	/// ���ݿ��ֶ�����
	/// </summary>
	public class TDBObject
	{
		private static string CharToHex(int c)
		{
			return c >= 256 ? c.ToString("X") : "00" + c.ToString("X");
		}

		public static string ToDBStr(string source)
		{
			if (source == null) return null;
			string ret = "";
			for (int i = 0; i < source.Length; i++)
			{
				ret += CharToHex((int)source[i]);
			}

			return ret;
		}

		private static string CharToHex_New(int c)
		{
			if (c >= 0xFFF) 
			{
				return c.ToString("X");
			}
			else if (c >= 0xFF)
			{
				return "0" + c.ToString("X");
			}
			else if (c >= 0xF)
			{
				return "00" + c.ToString("X");
			}
			else
			{
				return "000" + c.ToString("X");
			}
		}

		public static string ToDBStr_New(string source)
		{
			if (source == null) return null;
			string ret = "";
			for (int i = 0; i < source.Length; i++)
			{
				ret += CharToHex_New((int)source[i]);
			}

			return ret;
		}

		public static string ToDBVal(object FieldVal)
		{
			string ret = "";
			if (FieldVal == null)
			{
				ret = "null";
			}
			else if (FieldVal is int || FieldVal is long || FieldVal is float || FieldVal is System.Decimal)
			{
				ret = FieldVal.ToString();
			}
			else if (FieldVal is string)
			{
				ret = (string)FieldVal;
				ret.Replace("'","''");
				ret = "'" + ret + "'";
			}
			else if (FieldVal is System.DateTime)
			{
				ret = ((System.DateTime)FieldVal).ToString("yyyy-MM-dd HH:mm:ss");
				//ret = "convert(datetime,'" + ret + "',120)";
				ret = "'" + ret + "'";
			}
			else if (FieldVal is bool)
			{
				ret = (bool)FieldVal ? "'T'" : "'F'";
			}
			else if (FieldVal is ArrayList)
			{
				ArrayList al = (ArrayList)FieldVal;

				ret = "";
				for (int i = 0; i < al.Count; i++)
				{
					ret += i == 0 ? (string)al[i] : "," + (string)al[i];
				}

				return ToDBVal(ToDBStr(ret));
			}
			else
			{
				throw new Exception("δ֪����������:" + FieldVal.GetType());
			}
			return ret;
		}
		

		/// <summary>
		/// �����ǽ�һ���ֶε�ֵ�����ڴ���
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="FieldName"></param>
		/// <param name="val"></param>
		public static void GetField(DataRow dr, string FieldName,ref int val)
		{
			val = dr[FieldName] == System.DBNull.Value ? 0 : System.Convert.ToInt32(dr[FieldName]);
		}
		public static void GetField(DataRow dr, string FieldName,ref float val)
		{
			val = dr[FieldName] == System.DBNull.Value ? 0 : (float)System.Convert.ToDouble(dr[FieldName]);
		}
		public static void GetField(DataRow dr, string FieldName,ref double val)
		{
			val = dr[FieldName] == System.DBNull.Value ? 0 : System.Convert.ToDouble(dr[FieldName]);
		}
		public static void GetField(DataRow dr, string FieldName,ref bool val)
		{
			Type a=dr[FieldName].GetType();
			
			if (dr[FieldName] is System.String)
			{
				string s = (string)dr[FieldName];
				s= s.Trim();
				if (s.Equals("T"))
				{val = true;}
				else
				{val = false;}
			}
			else
			{
				val = dr[FieldName] == System.DBNull.Value ? false : System.Convert.ToBoolean(dr[FieldName]);
			}
		}
		public static void GetField(DataRow dr, string FieldName,ref DateTime val)
		{
			val = dr[FieldName] == System.DBNull.Value ? DateTime.MinValue : System.Convert.ToDateTime(dr[FieldName]);
		}	
		public static void GetField(DataRow dr, string FieldName,ref string val)
		{
			val = dr[FieldName] == System.DBNull.Value ? "" : System.Convert.ToString(dr[FieldName]);
		}
		/// <summary>
		/// ���ӽ����ݿ��ֶ�ת��Ϊstring��arraylist
		/// �����ݿ��ֶ��е��ı���','�ָ�Ϊarraylist��һ��Ԫ��
		/// �޸�ʱ�䣺2004-12-10
		/// �޸��ˣ�Peng Yi
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="FieldName"></param>
		/// <param name="val"></param>
		public static void GetField(DataRow dr, string FieldName,ref ArrayList val)
		{
			string strval;
			string delimstr = ",";
			char [] delimch = delimstr.ToCharArray();
			string [] spilit = null;
			strval = System.Convert.ToString(dr[FieldName]);
			spilit = strval.Split(delimch);
			foreach(string tempstr in spilit)
			{
				val.Add(tempstr);
			}		
		}
	}
}
