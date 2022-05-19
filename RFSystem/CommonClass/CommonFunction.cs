using System.Data;
using System.Windows.Forms;

namespace RFSystem.CommonClass
{
    internal class CommonFunction
    {
        public static DialogResult AskMBox(string text, string caption, bool ynOroc, bool onYes)
        {
            return MessageBox.Show(text, caption, ynOroc ? MessageBoxButtons.YesNo : MessageBoxButtons.OKCancel, MessageBoxIcon.Question, onYes ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2);
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
