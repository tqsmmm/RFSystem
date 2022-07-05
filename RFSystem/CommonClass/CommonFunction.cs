using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    internal class CommonFunction
    {
        public static void Sys_MsgBox(string strMsg)
        {
            MessageBox.Show(strMsg, "RF-PSCS库存管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Sys_MsgYN(string strMsg)
        {
            if (MessageBox.Show(strMsg, "RF-PSCS库存管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
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
