using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace SapService
{
	public class Authentication: System.Web.Services.Protocols.SoapHeader
　  {
　　	public string Username;
　　	public string Password;
　　	public bool ValidUser(string in_Username,
　　					string in_Password)
　　		{
		string conpass = "";
		if(in_Username.Length == 0)
		{
			return false;
		}
		string ip = HttpContext.Current.Request.UserHostAddress;
		
		byte[] password = System.Text.Encoding.Unicode.GetBytes(Username );
		Array.Reverse( password );
		string pass64 = Convert.ToBase64String( password );
		if(pass64.Length < 10)
		{
			pass64 += "YeT+=fue";
		}
		conpass = pass64;
　　　			if(conpass == Password)
　　　　		{
　　　　　			return true;
　　　　		}
　　　			else
　　　			{
				Log log = new Log();
				log.WriteLog("ValidUser","密码验证未通过，有可能有非法用户在尝试登录:" + ip);  
　　　　			return false;
　　　			}
　　		}
		public Authentication()
		{
		}
	}
}
