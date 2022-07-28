using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RFSystem
{
    internal class CommonFunction
    {
        public static void Sys_MsgBox(string strMsg)
        {
            MessageBox.Show(strMsg, AppSetter.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Sys_MsgYN(string strMsg)
        {
            if (MessageBox.Show(strMsg, AppSetter.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string getMd5Hash(string input)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public static bool IfHasData(DataTable dataList)
        {
            bool flag = false;

            if (dataList != null)
            {
                flag = true;
            }

            if (flag && (dataList.Rows.Count == 0))
            {
                flag = false;
            }

            return flag;
        }
    }
}
