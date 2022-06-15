using System;
using System.Configuration;
using System.Text;

namespace RFSystem
{
    public class Serivce
    {
        private string m_Connstring = "";
        private string pwd = "";
        private string user = "";

        public Serivce(string User, string Pwd, string Conn)
        {
            user = User;
            pwd = Pwd;
            m_Connstring = Conn;
        }
    }
}
