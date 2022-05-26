using RFSystem.AnSteel;
using System;
using System.Configuration;
using System.Text;

namespace RFSystem
{
    public class Serivce
    {
        private Authentication auth = new Authentication();
        private string m_Connstring = "";
        private string pwd = "";
        private AnSteelInterFace steel = new AnSteelInterFace();
        private string user = "";

        public Serivce(string User, string Pwd, string Conn)
        {
            user = User;
            pwd = Pwd;
            m_Connstring = Conn;
        }

        private string getConnStr()
        {
            AppSettingsReader reader = new AppSettingsReader();
            return reader.GetValue("RFSystem_localhost_AnSteelInterFace", Type.GetType("System.String")).ToString();
        }

        public AnSteelInterFace ServiceS
        {
            get
            {
                byte[] bytes = Encoding.Unicode.GetBytes(user);
                Array.Reverse(bytes, 0, bytes.Length);
                string str = Convert.ToBase64String(bytes, 0, bytes.Length);

                if (str.Length < 10)
                {
                    str += "YeT+=fue";
                }

                auth.Username = user;
                auth.Password = str;
                steel.Url = m_Connstring;
                steel.AuthenticationValue = auth;

                return steel;
            }
        }
    }
}
