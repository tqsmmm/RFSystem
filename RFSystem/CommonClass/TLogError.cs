using System;
using System.Data.OleDb;
using System.IO;

namespace RFSystem
{
    public class TLogError
    {
        public const int CONNECTIONFAIL = -20;
        public const int DATAEMPTY = -9;
        public const int DATAHASBEENDELETED = -30;
        private string des;
        private Exception E;
        public const int FILEERROR = -100;
        public const int KEYDUPLICATE = -10;
        public static string LogFileName = @"E:\log\logerror.txt";
        public const int NULLVALUE = -11;
        public const int REMOTING_CONNECT = -1000;

        public TLogError(Exception E)
        {
            this.E = null;
            des = null;
            this.E = E;
        }

        public TLogError(string des)
        {
            E = null;
            this.des = null;
            this.des = des;
        }

        public TLogError(Exception E, string des)
        {
            this.E = null;
            this.des = null;
            this.E = E;
            this.des = des;
        }

        public static int GetDBErrorType(OleDbException E)
        {
            int num = -1;

            for (int i = 0; i < E.Errors.Count; i++)
            {
                switch (E.Errors[i].NativeError)
                {
                    case 0xa43:
                    case 0xe14:
                    case 0xa29:
                        num = -10;
                        break;

                    case 0x203:
                        num = -11;
                        break;

                    case 0x11:
                    case 0x4818:
                        num = -20;
                        break;
                }
            }

            return num;
        }

        public int SaveExceptionInfo()
        {
            StreamWriter writer;
            int num = -1;

            try
            {
                FileInfo info = new FileInfo(LogFileName);

                if (info.Length >= 0x500000L)
                {
                    try
                    {
                        new FileInfo(@"c:\pfpslog_.txt").Delete();
                    }
                    catch
                    {

                    }

                    info.CopyTo(@"c:\pfpslog_.txt");
                    info.Delete();
                }
            }
            catch
            {

            }

            if (E != null)
            {
                try
                {
                    writer = File.AppendText(LogFileName);
                    writer.WriteLine();
                    writer.WriteLine("-------------------------------------------------------------------");
                    writer.WriteLine("时间：" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                    writer.WriteLine("错误堆栈信息：");
                    writer.WriteLine(E.StackTrace.ToString());
                    writer.WriteLine("错误信息：");
                    writer.WriteLine(E.Message);

                    if (des != null)
                    {
                        writer.WriteLine();
                        writer.WriteLine("附加信息：");
                        writer.WriteLine("    " + des);
                    }

                    writer.Close();
                    num = 0;
                }
                catch
                {

                }
                return num;
            }

            if (des != null)
            {
                try
                {
                    writer = File.AppendText(LogFileName);
                    writer.WriteLine();
                    writer.WriteLine("-------------------------------------------------------------------");
                    writer.WriteLine("时间：" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    writer.WriteLine("调试信息：");
                    writer.WriteLine("    " + des);
                    writer.Close();
                    num = 0;
                }
                catch
                {

                }
            }

            return num;
        }
    }
}
