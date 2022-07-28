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
                AppSetter.User_Info.passWord = CommonFunction.getMd5Hash(AppSetter.User_Info.passWord);
                AppSetter.User_Info = UserInfo.GetUserByLogin(AppSetter.User_Info, out bool flag, out DataTable table);

                AppSetter.User_Roles = new ArrayList();

                foreach (DataRow row in table.Rows)
                {
                    AppSetter.User_Roles.Add(row["RoleID"].ToString());
                }

                if (flag)
                {
                    if (AppSetter.User_Info.isEffect)
                    {
                        new RF库存管理系统(AppSetter.User_Info, AppSetter.User_Roles).ShowDialog();
                    }
                    else
                    {
                        CommonFunction.Sys_MsgBox("用户已被删除");
                    }
                }
                else
                {
                    CommonFunction.Sys_MsgBox("用户或密码错误");
                }
            }
        }
    }
}
