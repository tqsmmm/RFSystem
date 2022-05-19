using System;

namespace SapService
{
	/// <summary>
	/// STStruct 的摘要说明。这里结尾为S的代表该字段起始位置是多少，该字段L代表为长度为多少
	/// </summary>
	public class STStruct
	{
		public static  int BarCodeS = 0;
		public static int BarCodeL = 32;
		public static int SLocationS = 32;
		public static int SLocationL = 4;
		public static int MDescS = 36;
		public static int MDescL = 40;
		public static int UNITS = 76;
		public static int UNITL = 10;
		public static int Bin1S = 86;
		public static int Bin1L = 15;
		public static int Bin2S = 101;
		public static int Bin2L = 15;
		public static int Bin3S = 116;
		public static int Bin3L = 15;
		public static int CheckedS = 131;
		public static int CheckedL = 1;
		//public static int STructL = 134;

		public static int Bin1CountS = 132;
		public static int Bin1CountL = 15;
		public static int Bin2CountS = 147;
		public static int Bin2CountL = 15;
		public static int Bin3CountS = 162;
		public static int Bin3CountL = 15;
		public static int STructL = 179;
		
	}
}
