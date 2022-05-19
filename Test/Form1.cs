using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Test
{
    public partial class Form1 : Form
    {
        string hostName = "192.1.77.12";
        int Port = 9100;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintContractorLabel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.PrintLocationLabel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.PrintProductLabelNew_Patch();
        }

        /// <summary>
        /// 保管员标签
        /// </summary>
        private void PrintContractorLabel()
        {
            string s = "";
            string con = this.textBox4.Text;//打印内容
            string copy = "1";
            string xx = "4";
            string xz = "10";
            TcpClient client = new TcpClient();
            string hostname = this.hostName;
            int port = this.Port;
            try
            {
                client.Connect(hostname, port);

                con = "con";
                xx = "4";
                xz = "10";
                s = this.dealPrintData_ConLabel(con, xx, xz, copy);
                client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                client.GetStream().Flush();

                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private string dealPrintData_ConLabel(string con, string xx, string xz, string copy)
        {
            string str = "";
            str = ((((str + "@CREATE;LOC\r\n" + "BARCODE\r\n") + "C128C;VSCAN;X2;H4.65;DARK;" + xx + ";1\r\n") + "*" + con + "*\r\n") + "PDF;S\r\n" + "STOP\r\n") + "FONT;FACE 92250;BOLD OFF;SLANT OFF;SYMSET 0\r\n" + "ALPHA\r\n";
            return ((((str + "CCW;POINT;" + xz + ";7;15;15;'" + con + "'\r\n") + "STOP\r\n" + "END\r\n") + "@EXECUTE;LOC;" + copy + "\r\n") + "@NORMAL\r\n");
        }

        /// <summary>
        /// 货位标签
        /// </summary>
        private void PrintLocationLabel()
        {
            //string s = "";
            //string loc = "";
            //string copy = "1";
            //string xx = "2";
            //string xz = "12";
            //TcpClient client = new TcpClient();
            //string hostname = this.hostName;
            //int port = this.Port;
            //try
            //{
            //    client.Connect(hostname, port);
            //    loc = this.textBox1.Text;
            //    xx = "5.5";
            //    xz = "13";
            //    s = this.dealPrintData_LocLabel(loc, xx, xz, copy);
            //    client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
            //    client.GetStream().Flush();
            //    client.Close();
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message);
            //}
        }

        private string dealPrintData_LocLabel(string loc, string xx, string xz, string copy)
        {
            string str = "";
            str = ((((str + "@CREATE;LOC\r\n" + "BARCODE\r\n") + "C128C;VSCAN;X1.5;H4.65;DARK;" + xx + ";1\r\n") + "*" + loc + "*\r\n") + "PDF;S\r\n" + "STOP\r\n") + "FONT;FACE 92250;BOLD OFF;SLANT OFF;SYMSET 0\r\n" + "ALPHA\r\n";
            return ((((str + "CCW;POINT;" + xz + ";7;15;15;'" + loc + "'\r\n") + "STOP\r\n" + "END\r\n") + "@EXECUTE;LOC;" + copy + "\r\n") + "@NORMAL\r\n");
        }

        /// <summary>
        /// 打印物料标签
        /// </summary>
        private void PrintProductLabelNew_Patch()
        {
            TcpClient client = new TcpClient();
            string hostname = this.hostName;
            int port = this.Port;
            try
            {
                client.Connect(hostname, port);
                #region 定义
                string s = string.Empty;
                string f = "1-f";//二级厂
                string proName = "2-proName";//物料描述
                string proNo = "3-proNo";//物料号
                string patch = "4-patch";//批次号
                string wareNo = "5-wareNo";//工厂号
                string deNo = "6-deNo";//凭证号
                string ckDate = "7-ckDate";//入库日期
                string manu = "8-manu";//说明书
                string pC = "9-pC";//产品证书
                string cert = "10cert";//合格证
                string pL = "11-pL";//装箱单
                string supp = "12-supp";//供货单位
                string loca = "13-loca";//货位
                string q = "14-q";//货位数量
                string r = "15-r";//货位备注
                string u = "16-u";//单位
                string w = "17-w";//单重
                string p = "18-p";//单价
                string cop = "1";
                string ywtm = "";//一维条码
                string baoguanyuan = "BS02";//保管员
                #endregion

                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                //client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                //client.GetStream().Flush();
                //// R 2000 4500001556 202B0702077977 001
                //proNo = "202B0702077977001";
                //patch = "4500001556";
                //wareNo = "R2000";

                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                //client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                //client.GetStream().Flush();

                f = "241032";
                proName = "升降机-SWL20-1-A-IV-131";
                proNo = this.txt_ywtm.Text.Trim().Substring(15, 14);// "20000401030814";
                patch = "1101375210";
                wareNo = "2000";
                deNo = "5001667090";
                ckDate = "20150910";
                manu = "";
                pC = "";
                cert = "";
                pL = "";
                supp = "辽宁巨刚传动机械有限公司";
                loca = "0301020100";
                q = "2.000";
                r = "备注";
                u = "PC";
                w = "303.000";
                p = "6000.00";
                ywtm = this.txt_ywtm.Text.Trim();
                baoguanyuan = "BS02";
                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan);
                s = RFSystem.ClsCommon.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan, "RFID标签0");
                client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                client.GetStream().Flush();
                //f = "241032";
                //proName = "升降机-SWL20-1-A-IV-130";
                //proNo = "2000A505998001001";
                //patch = "1101375209";
                //wareNo = "R2000";
                //deNo = "5001667094";
                //ckDate = "20150210";
                //manu = "";
                //pC = "";
                //cert = "";
                //pL = "BS02";
                //supp = "辽宁巨刚传动机械有限公司";
                //loca = "0301020100";
                //q = "2.000";
                //r = "";
                //u = "PC";
                //w = "303.000";
                //p = "6000.00";
                //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                //client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                //client.GetStream().Flush();


                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }




        public string Data_Hex(string old)
        {
            string str = "";
            try
            {
                int num = 0;
                string str2 = "";
                foreach (char ch in old)
                {
                    num = ch;
                    string str3 = string.Format("{0:x2}", Convert.ToUInt32(num.ToString()));
                    str2 = str2 + str3;
                }
                str = str2;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed to convert!!! Please check your input format!" + exception.Message);
            }
            return str;
        }

        #region 不用了
        private string dealData(string f, string proName, string proNo, string Patch, string wareNo, string deNo, string ckDate, string manu, string pC, string cert, string pL, string supp, string loca, string q, string u, string w, string r, string p, string cop, string ywtm, string baoguanyuan)
        {
            string str = "";
            string str2 = f;
            string str3 = proName;
            string str4 = proNo;
            string str5 = Patch;
            string str6 = wareNo;
            string str7 = deNo;
            string str8 = ckDate;
            string str9 = manu;
            string str10 = pC;
            string str11 = cert;
            string str12 = baoguanyuan;// pL;
            string str13 = supp;
            string str14 = loca;
            string str15 = q;
            string str16 = u;
            string str17 = w;
            string str18 = r;
            string str19 = p;
            string str20 = cop;
            if (str3.Length > 20)
            {
                str3 = str3.Substring(0, 20);
            }
            str = ((((((((((((((((((str + "@NORMAL\r\n") + "@PAPER;WIDTH 50;LENGTH 99;SPEED IPS 2;INTENSITY 0;LANDSCAPE\r\n" + "@CREATE;ANSTEELLAB\r\n") + "SCALE;DOT;300;300\r\n" + "LOGO\r\n") + "43;380;ANGANG;DISK\r\n" + "STOP\r\n") + "BOX\r\n" + "12;20;22;1100;1740\r\n") + "STOP\r\n" + "HORZ\r\n") + "5;136;22;1740\r\n" + "5;232;22;1740\r\n") + "5;424;22;1740\r\n" + "5;528;22;1740\r\n") + "5;616;22;1740\r\n" + "5;712;22;1740\r\n") + "5;808;22;1740\r\n" + "5;904;22;1740\r\n") + "5;1000;22;1740\r\n" + "5;1096;22;1740\r\n") + "STOP\r\n" + "VERT\r\n") + "5;290;136;1100\r\n" + "5;550;136;232\r\n") + "5;850;424;808\r\n" + "5;710;904;1100\r\n") + "5;750;136;232\r\n" + "5;1100;424;808\r\n") + "5;900;904;1100\r\n" + "5;1150;904;1100\r\n") + "5;1350;904;1100\r\n" + "STOP\r\n") + "FONT;FACE 92250;BOLD OFF;SLANT OFF;SYMSET 0\r\n" + "ALPHA\r\n") + "POINT;205;350;15;15;'" + str2 + "'\r\n";

            //条码
            string _s_tm = ywtm;
            if (ywtm == "")
            {
                //原先的物料条码
                if ((str5 == null) || str5.Equals(""))
                    _s_tm = str4;
                else
                    _s_tm = str6 + str5 + str4;
            }
            str = str + "POINT;285;345;15;15;'" + _s_tm + "'\r\n";
            str = (((((((((((((((((((((((((((((str + "POINT;490;350;15;15;'" + str7 + "'\r\n") + "POINT;490;1150;15;15;'" + str4 + "'\r\n") + "POINT;585;350;15;15;'" + str5 + "'\r\n") + "POINT;585;1150;15;15;'" + str8 + "'\r\n") + "POINT;965;350;15;15;'" + str14 + "'\r\n") + "POINT;965;930;15;15;'" + str15 + "'\r\n") + "POINT;1060;930;15;15;'" + str17 + "'\r\n") + "POINT;1060;1370;15;15;'" + str19 + "'\r\n") + "POINT;775;1150;15;15;'" + str12 + "'\r\n") + "POINT;690;350;15;15;'" + str9 + "'\r\n") + "POINT;680;1150;15;15;'" + str10 + "'\r\n") + "POINT;775;350;15;15;'" + str11 + "'\r\n") + "STOP\r\n" + "FONT;FACE 92250;BOLD ON;SLANT OFF;SYMSET 0\r\n") + "TWOBYTE\r\n" + "POINT;110;500;18;18;'鞍钢股份设备处备件卡'\r\n") + "POINT;195;90;10;8;'二级厂'\r\n" + "POINT;205;590;10;8;'物料描述'\r\n") + "POINT;205;810;12;10;'" + str3 + "'\r\n") + "POINT;345;90;10;8;'设备代码'\r\n" + "POINT;490;90;10;8;'凭证号'\r\n") + "POINT;490;900;10;8;'物料号'\r\n" + "POINT;585;90;10;8;'批次号'\r\n") + "POINT;585;900;10;8;'入库日期'\r\n" + "POINT;680;90;10;8;'说明书'\r\n") + "POINT;680;900;10;8;'产品证书'\r\n" + "POINT;775;90;10;8;'合格证'\r\n") + "POINT;775;900;10;8;'保管员'\r\n" + "POINT;870;90;10;8;'供货单位'\r\n") + "POINT;880;340;15;15;'" + str13 + "'\r\n") + "POINT;965;90;10;8;'货  位'\r\n") + "POINT;965;730;10;8;'货位数量'\r\n" + "POINT;965;1180;10;8;'货位备注'\r\n") + "POINT;965;1370;10;8;'" + str18 + "'\r\n") + "POINT;1060;90;10;8;'单  位'\r\n") + "POINT;1070;350;15;15;'" + str16 + "'\r\n") + "POINT;1060;730;10;8;'单  重'\r\n") + "POINT;1060;1180;10;8;'单　价'\r\n" + "STOP\r\n") + "BARCODE\r\n" + "C128C;H4.55;DARK;265;345\r\n";
            str = str + "*" + _s_tm + "*\r\n";

            str = str + "PDF;S\r\n" + "STOP\r\n";
            string old = "";
            if (this.Text.Equals("RFID标签"))
            {
                //if ((str5 == null) || str5.Equals(""))
                //{
                //    old = str4;
                //}
                //else
                //{
                //    old = str6 + str5 + str4;
                //}
                old = _s_tm;
                string str22 = (this.Data_Hex(old) + "000000000000000000000000000000000000").Substring(0, 0x44);
                str = ((((str + "RFWTAG;272;USR\r\n") + "128;H;*" + str22.Substring(0, 0x20) + "*\r\n") + "128;H;*" + str22.Substring(0x20, 0x20) + "*\r\n") + "16;H;*" + str22.Substring(0x40, 4) + "*\r\n") + "STOP\r\n";
            }
            return (((str + "END\r\n") + "@EXECUTE;ANSTEELLAB;" + str20 + "\r\n") + "@NORMAL\r\n");
        }

        //private string dealDataold(string f, string proName, string proNo, string Patch, string wareNo, string deNo, string ckDate, string manu, string pC, string cert, string pL, string supp, string loca, string q, string u, string w, string r, string p, string cop)
        //{
        //    string str = "";
        //    string str2 = f;
        //    string str3 = proName;
        //    string str4 = proNo;
        //    string str5 = Patch;
        //    string str6 = wareNo;
        //    string str7 = deNo;
        //    string str8 = ckDate;
        //    string str9 = manu;
        //    string str10 = pC;
        //    string str11 = cert;
        //    string str12 = pL;
        //    string str13 = supp;
        //    string str14 = loca;
        //    string str15 = q;
        //    string str16 = u;
        //    string str17 = w;
        //    string str18 = r;
        //    string str19 = p;
        //    string str20 = cop;
        //    if (str3.Length > 20)
        //    {
        //        str3 = str3.Substring(0, 20);
        //    }
        //    str = ((((((((((((((((((str + "@NORMAL\r\n") + "@PAPER;WIDTH 50;LENGTH 99;SPEED IPS 2;INTENSITY 0;LANDSCAPE\r\n" + "@CREATE;ANSTEELLAB\r\n") + "SCALE;DOT;300;300\r\n" + "LOGO\r\n") + "43;380;ANGANG;DISK\r\n" + "STOP\r\n") + "BOX\r\n" + "12;20;22;1100;1740\r\n") + "STOP\r\n" + "HORZ\r\n") + "5;136;22;1740\r\n" + "5;232;22;1740\r\n") + "5;424;22;1740\r\n" + "5;528;22;1740\r\n") + "5;616;22;1740\r\n" + "5;712;22;1740\r\n") + "5;808;22;1740\r\n" + "5;904;22;1740\r\n") + "5;1000;22;1740\r\n" + "5;1096;22;1740\r\n") + "STOP\r\n" + "VERT\r\n") + "5;290;136;1100\r\n" + "5;550;136;232\r\n") + "5;850;424;808\r\n" + "5;710;904;1100\r\n") + "5;750;136;232\r\n" + "5;1100;424;808\r\n") + "5;900;904;1100\r\n" + "5;1150;904;1100\r\n") + "5;1350;904;1100\r\n" + "STOP\r\n") + "FONT;FACE 92250;BOLD OFF;SLANT OFF;SYMSET 0\r\n" + "ALPHA\r\n") + "POINT;205;350;15;15;'" + str2 + "'\r\n";
        //    if ((str5 == null) || str5.Equals(""))
        //    {
        //        str = str + "POINT;285;345;15;15;'" + str4 + "'\r\n";
        //    }
        //    else
        //    {
        //        str = str + "POINT;285;345;15;15;'" + str6 + str5 + str4 + "'\r\n";
        //    }
        //    str = (((((((((((((((((((((((((((((str + "POINT;490;350;15;15;'" + str7 + "'\r\n") + "POINT;490;1150;15;15;'" + str4 + "'\r\n") + "POINT;585;350;15;15;'" + str5 + "'\r\n") + "POINT;585;1150;15;15;'" + str8 + "'\r\n") + "POINT;965;350;15;15;'" + str14 + "'\r\n") + "POINT;965;930;15;15;'" + str15 + "'\r\n") + "POINT;1060;930;15;15;'" + str17 + "'\r\n") + "POINT;1060;1370;15;15;'" + str19 + "'\r\n") + "POINT;775;1150;15;15;'" + str12 + "'\r\n") + "POINT;690;350;15;15;'" + str9 + "'\r\n") + "POINT;680;1150;15;15;'" + str10 + "'\r\n") + "POINT;775;350;15;15;'" + str11 + "'\r\n") + "STOP\r\n" + "FONT;FACE 92250;BOLD ON;SLANT OFF;SYMSET 0\r\n") + "TWOBYTE\r\n" + "POINT;110;500;18;18;'鞍钢股份设备处备件卡'\r\n") + "POINT;195;90;10;8;'二级厂'\r\n" + "POINT;205;590;10;8;'物料描述'\r\n") + "POINT;205;810;12;10;'" + str3 + "'\r\n") + "POINT;345;90;10;8;'设备代码'\r\n" + "POINT;490;90;10;8;'凭证号'\r\n") + "POINT;490;900;10;8;'物料号'\r\n" + "POINT;585;90;10;8;'批次号'\r\n") + "POINT;585;900;10;8;'入库日期'\r\n" + "POINT;680;90;10;8;'说明书'\r\n") + "POINT;680;900;10;8;'产品证书'\r\n" + "POINT;775;90;10;8;'合格证'\r\n") + "POINT;775;900;10;8;'保管员'\r\n" + "POINT;870;90;10;8;'供货单位'\r\n") + "POINT;880;340;15;15;'" + str13 + "'\r\n") + "POINT;965;90;10;8;'货  位'\r\n") + "POINT;965;730;10;8;'货位数量'\r\n" + "POINT;965;1180;10;8;'货位备注'\r\n") + "POINT;965;1370;10;8;'" + str18 + "'\r\n") + "POINT;1060;90;10;8;'单  位'\r\n") + "POINT;1070;350;15;15;'" + str16 + "'\r\n") + "POINT;1060;730;10;8;'单  重'\r\n") + "POINT;1060;1180;10;8;'单　价'\r\n" + "STOP\r\n") + "BARCODE\r\n" + "C128C;H4.55;DARK;265;345\r\n";
        //    if ((str5 == null) || str5.Equals(""))
        //    {
        //        str = str + "*" + str4 + "*\r\n";
        //    }
        //    else
        //    {
        //        str = str + "*" + str6 + str5 + str4 + "*\r\n";
        //    }
        //    str = str + "PDF;S\r\n" + "STOP\r\n";
        //    string old = "";
        //    if (this.Text.Equals("RFID标签"))
        //    {
        //        if ((str5 == null) || str5.Equals(""))
        //        {
        //            old = str4;
        //        }
        //        else
        //        {
        //            old = str6 + str5 + str4;
        //        }
        //        string str22 = (this.Data_Hex(old) + "000000000000000000000000000000000000").Substring(0, 0x44);
        //        str = ((((str + "RFWTAG;272;USR\r\n") + "128;H;*" + str22.Substring(0, 0x20) + "*\r\n") + "128;H;*" + str22.Substring(0x20, 0x20) + "*\r\n") + "16;H;*" + str22.Substring(0x40, 4) + "*\r\n") + "STOP\r\n";
        //    }
        //    return (((str + "END\r\n") + "@EXECUTE;ANSTEELLAB;" + str20 + "\r\n") + "@NORMAL\r\n");
        //}
        
        #endregion
    }
}
