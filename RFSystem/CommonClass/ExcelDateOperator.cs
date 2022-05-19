using System;

namespace RFSystem.CommonClass
{
    public class ExcelDateOperator
    {
        private static readonly TimeSpan after1stMarchAdjustment = new TimeSpan(1, 0, 0, 0);
        private static readonly DateTime december31st1899 = new DateTime(0x76b, 12, 0x1f);
        private static readonly DateTime march1st1900 = new DateTime(0x76c, 3, 1);

        public static DateTime ConvertExcelDateToDate(string excelDate)
        {
            TimeSpan span = TimeSpan.Parse(excelDate);
            DateTime time = december31st1899 + span;

            if (time >= march1st1900)
            {
                return (time - after1stMarchAdjustment);
            }

            return time;
        }
    }
}
