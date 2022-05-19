using BL;
using RFSystem.CommonClass;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RFSystem
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RF库存管理系统登录 rf库存管理系统登录 = new RF库存管理系统登录();

            if (DialogResult.No != rf库存管理系统登录.ShowDialog())
            {
                UserInfo userItem = new UserInfo();
                userItem.userID = ConstDefine.g_User;
                string input = ConstDefine.g_PassWord;
                userItem.passWord = RFdesOperator.getMd5Hash(input);
                userItem = User.GetUserByLogin(userItem, out bool flag, out DataTable table);

                ArrayList userRoles = new ArrayList();

                foreach (DataRow row in table.Rows)
                {
                    userRoles.Add(row["RoleID"].ToString());
                }

                if (flag)
                {
                    if (userItem.isEffect)
                    {
                        new RF库存管理系统(userItem, userRoles).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("用户已被删除");
                    }
                }
                else
                {
                    MessageBox.Show("用户或密码错误");
                }
            }
        }
    }
}
