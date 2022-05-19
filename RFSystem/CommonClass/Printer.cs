using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace RFSystem.CommonClass
{
    internal class Printer
    {
        private string printerIP;
        private int printerSocket;
        private ReturnMsg returnMsg;
        private string socketMsg;
        private TcpClient tc;

        public Printer()
        {
            tc = null;
            printerIP = string.Empty;
            printerSocket = 0;
            socketMsg = string.Empty;
            returnMsg = new ReturnMsg();
        }

        public Printer(string printerIP, int printerSocket, string socketMsg)
        {
            tc = null;
            this.printerIP = string.Empty;
            this.printerSocket = 0;
            this.socketMsg = string.Empty;
            returnMsg = new ReturnMsg();
            this.printerIP = printerIP;
            this.printerSocket = printerSocket;
            this.socketMsg = socketMsg;
            tc = new TcpClient();
        }

        public ReturnMsg DoClose()
        {
            try
            {
                tc.Close();
                returnMsg.ifSuccessful = true;
                returnMsg.erroyMsg = string.Empty;
                return returnMsg;
            }
            catch (Exception exception)
            {
                returnMsg.ifSuccessful = false;
                returnMsg.erroyMsg = exception.Message;
                return returnMsg;
            }
        }

        public ReturnMsg DoConnect()
        {
            try
            {
                if (tc == null)
                {
                    tc = new TcpClient();
                }

                if (tc.Connected)
                {
                    tc.Connect(printerIP, printerSocket);
                }

                returnMsg.ifSuccessful = true;
                returnMsg.erroyMsg = string.Empty;

                return returnMsg;
            }
            catch (Exception exception)
            {
                returnMsg.ifSuccessful = false;
                returnMsg.erroyMsg = exception.Message;

                return returnMsg;
            }
        }

        public ReturnMsg PushSocketMsg()
        {
            try
            {
                tc.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(socketMsg), 0, Encoding.GetEncoding("gb2312").GetBytes(socketMsg).Length);
                tc.GetStream().Flush();
                returnMsg.ifSuccessful = true;
                returnMsg.erroyMsg = string.Empty;

                return returnMsg;
            }
            catch (Exception exception)
            {
                returnMsg.ifSuccessful = false;
                returnMsg.erroyMsg = exception.Message;

                return returnMsg;
            }
        }

        public string PrinterIP
        {
            get
            {
                return printerIP;
            }
            set
            {
                printerIP = value;
            }
        }

        public int PrinterSocket
        {
            get
            {
                return printerSocket;
            }
            set
            {
                printerSocket = value;
            }
        }

        public string SocketMsg
        {
            get
            {
                return socketMsg;
            }
            set
            {
                socketMsg = value;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ReturnMsg
        {
            public bool ifSuccessful;
            public string erroyMsg;
        }
    }
}
