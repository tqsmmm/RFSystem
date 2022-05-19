using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();
            string hostname = this.dataGridViewPrinterList.SelectedRows[0].Cells["columnPAddress"].Value.ToString();
            int port = int.Parse(this.dataGridViewPrinterList.SelectedRows[0].Cells["columnSocket"].Value.ToString());
            try
            {
                client.Connect(hostname, port);
                for (int i = 0; i < dgvr.Count; i++)
                {
                    string s = string.Empty;
                    string f = dgvr[i].Cells["columnSupplier"].Value.ToString();
                    string proName = dgvr[i].Cells["columnProduct"].Value.ToString();
                    string proNo = dgvr[i].Cells["columnPNo"].Value.ToString();
                    ////string patch = dgvr[i].Cells["columnPatch"].Value.ToString();
                    string wareNo = dgvr[i].Cells["columnFactory"].Value.ToString();
                    ////string deNo = this.txtPatch.Text.Trim();
                    ////string ckDate = dgvr[i].Cells["columnDate"].Value.ToString();
                    string manu = "";
                    string pC = "";
                    string cert = "";
                    string pL = "";   //赋值成保管员
                    ////string supp = dgvr[i].Cells["ColumnPro"].Value.ToString();
                    string loca = "";
                    string q = "";
                    string r = "";
                    string u = dgvr[i].Cells["columnUnit"].Value.ToString();
                    string w = dgvr[i].Cells["ColumnNtgew"].Value.ToString();
                    string p = dgvr[i].Cells["columnAmount"].Value.ToString();
                    string cop = Math.Truncate(Convert.ToDecimal(dgvr[i].Cells["ColumnPrintCount"].Value)).ToString();


                    string ywtm = dgvr[i].Cells["C_N_ywtm"].Value.ToString().Trim();
                    string patch = dgvr[i].Cells["columnPatch"] == null || dgvr[i].Cells["columnPatch"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_pch"].Value.ToString().Trim() : dgvr[i].Cells["columnPatch"].Value.ToString().Trim();
                    string deNo = this.txtPatch.Text.Trim() == "" ? dgvr[i].Cells["C_N_pzh"].Value.ToString() : this.txtPatch.Text.Trim();
                    string ckDate = dgvr[i].Cells["columnDate"] == null || dgvr[i].Cells["columnDate"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_rkrq"].Value.ToString().Trim() : dgvr[i].Cells["columnDate"].Value.ToString().Trim();
                    string supp = dgvr[i].Cells["ColumnPro"] == null || dgvr[i].Cells["ColumnPro"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_ghdw"].Value.ToString().Trim() : dgvr[i].Cells["ColumnPro"].Value.ToString().Trim();
                    string baoguanyuan = dgvr[i].Cells["C_Bct10"] == null || dgvr[i].Cells["C_Bct10"].Value.ToString().Trim() == "" ? dgvr[i].Cells["C_N_storeman"].Value.ToString().Trim() : dgvr[i].Cells["C_Bct10"].Value.ToString().Trim();
                    s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop, ywtm, baoguanyuan);

                    //s = this.dealData(f, proName, proNo, patch, wareNo, deNo, ckDate, manu, pC, cert, pL, supp, loca, q, u, w, r, p, cop);
                    client.GetStream().Write(Encoding.GetEncoding("gb2312").GetBytes(s), 0, Encoding.GetEncoding("gb2312").GetBytes(s).Length);
                    client.GetStream().Flush();
                }
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

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
            if (ywtm != "")
            {
                str = str + "POINT;285;345;15;15;'" + ywtm + "'\r\n";
                str = (((((((((((((((((((((((((((((str + "POINT;490;350;15;15;'" + str7 + "'\r\n") + "POINT;490;1150;15;15;'" + str4 + "'\r\n") + "POINT;585;350;15;15;'" + str5 + "'\r\n") + "POINT;585;1150;15;15;'" + str8 + "'\r\n") + "POINT;965;350;15;15;'" + str14 + "'\r\n") + "POINT;965;930;15;15;'" + str15 + "'\r\n") + "POINT;1060;930;15;15;'" + str17 + "'\r\n") + "POINT;1060;1370;15;15;'" + str19 + "'\r\n") + "POINT;775;1150;15;15;'" + str12 + "'\r\n") + "POINT;690;350;15;15;'" + str9 + "'\r\n") + "POINT;680;1150;15;15;'" + str10 + "'\r\n") + "POINT;775;350;15;15;'" + str11 + "'\r\n") + "STOP\r\n" + "FONT;FACE 92250;BOLD ON;SLANT OFF;SYMSET 0\r\n") + "TWOBYTE\r\n" + "POINT;110;500;18;18;'鞍钢股份设备处备件卡'\r\n") + "POINT;195;90;10;8;'二级厂'\r\n" + "POINT;205;590;10;8;'物料描述'\r\n") + "POINT;205;810;12;10;'" + str3 + "'\r\n") + "POINT;345;90;10;8;'设备代码'\r\n" + "POINT;490;90;10;8;'采购订单号'\r\n") + "POINT;490;900;10;8;'物料号'\r\n" + "POINT;585;90;10;8;'批次号'\r\n") + "POINT;585;900;10;8;'入库日期'\r\n" + "POINT;680;90;10;8;'说明书'\r\n") + "POINT;680;900;10;8;'产品证书'\r\n" + "POINT;775;90;10;8;'合格证'\r\n") + "POINT;775;900;10;8;'装箱单'\r\n" + "POINT;870;90;10;8;'供货单位'\r\n") + "POINT;880;340;15;15;'" + str13 + "'\r\n") + "POINT;965;90;10;8;'货  位'\r\n") + "POINT;965;730;10;8;'货位数量'\r\n" + "POINT;965;1180;10;8;'货位备注'\r\n") + "POINT;965;1370;10;8;'" + str18 + "'\r\n") + "POINT;1060;90;10;8;'单  位'\r\n") + "POINT;1070;350;15;15;'" + str16 + "'\r\n") + "POINT;1060;730;10;8;'单  重'\r\n") + "POINT;1060;1180;10;8;'单　价'\r\n" + "STOP\r\n") + "BARCODE\r\n" + "C128C;H4.55;DARK;265;345\r\n";
                str = str + "*" + ywtm + "*\r\n";
            }
            else
            {
                //原先的物料条码
                if ((str5 == null) || str5.Equals(""))
                {
                    str = str + "POINT;285;345;15;15;'" + str4 + "'\r\n";
                }
                else
                {
                    str = str + "POINT;285;345;15;15;'" + str6 + str5 + str4 + "'\r\n";
                }
                str = (((((((((((((((((((((((((((((str + "POINT;490;350;15;15;'" + str7 + "'\r\n") + "POINT;490;1150;15;15;'" + str4 + "'\r\n") + "POINT;585;350;15;15;'" + str5 + "'\r\n") + "POINT;585;1150;15;15;'" + str8 + "'\r\n") + "POINT;965;350;15;15;'" + str14 + "'\r\n") + "POINT;965;930;15;15;'" + str15 + "'\r\n") + "POINT;1060;930;15;15;'" + str17 + "'\r\n") + "POINT;1060;1370;15;15;'" + str19 + "'\r\n") + "POINT;775;1150;15;15;'" + str12 + "'\r\n") + "POINT;690;350;15;15;'" + str9 + "'\r\n") + "POINT;680;1150;15;15;'" + str10 + "'\r\n") + "POINT;775;350;15;15;'" + str11 + "'\r\n") + "STOP\r\n" + "FONT;FACE 92250;BOLD ON;SLANT OFF;SYMSET 0\r\n") + "TWOBYTE\r\n" + "POINT;110;500;18;18;'鞍钢股份设备处备件卡'\r\n") + "POINT;195;90;10;8;'二级厂'\r\n" + "POINT;205;590;10;8;'物料描述'\r\n") + "POINT;205;810;12;10;'" + str3 + "'\r\n") + "POINT;345;90;10;8;'设备代码'\r\n" + "POINT;490;90;10;8;'采购订单号'\r\n") + "POINT;490;900;10;8;'物料号'\r\n" + "POINT;585;90;10;8;'批次号'\r\n") + "POINT;585;900;10;8;'入库日期'\r\n" + "POINT;680;90;10;8;'说明书'\r\n") + "POINT;680;900;10;8;'产品证书'\r\n" + "POINT;775;90;10;8;'合格证'\r\n") + "POINT;775;900;10;8;'保管员'\r\n" + "POINT;870;90;10;8;'供货单位'\r\n") + "POINT;880;340;15;15;'" + str13 + "'\r\n") + "POINT;965;90;10;8;'货  位'\r\n") + "POINT;965;730;10;8;'货位数量'\r\n" + "POINT;965;1180;10;8;'货位备注'\r\n") + "POINT;965;1370;10;8;'" + str18 + "'\r\n") + "POINT;1060;90;10;8;'单  位'\r\n") + "POINT;1070;350;15;15;'" + str16 + "'\r\n") + "POINT;1060;730;10;8;'单  重'\r\n") + "POINT;1060;1180;10;8;'单　价'\r\n" + "STOP\r\n") + "BARCODE\r\n" + "C128C;H4.55;DARK;265;345\r\n";
                if ((str5 == null) || str5.Equals(""))
                {
                    str = str + "*" + str4 + "*\r\n";
                }
                else
                {
                    str = str + "*" + str6 + str5 + str4 + "*\r\n";
                }
            }



            str = str + "PDF;S\r\n" + "STOP\r\n";
            string old = "";
            if (this.cmbLabelType.Text.Equals("RFID标签"))
            {
                if (ywtm != "")
                {
                    old = ywtm;
                }
                else
                {
                    if ((str5 == null) || str5.Equals(""))
                    {
                        old = str4;
                    }
                    else
                    {
                        old = str6 + str5 + str4;
                    }
                }
                string str22 = (this.Data_Hex(old) + "000000000000000000000000000000000000").Substring(0, 0x44);
                str = ((((str + "RFWTAG;272;USR\r\n") + "128;H;*" + str22.Substring(0, 0x20) + "*\r\n") + "128;H;*" + str22.Substring(0x20, 0x20) + "*\r\n") + "16;H;*" + str22.Substring(0x40, 4) + "*\r\n") + "STOP\r\n";
            }
            return (((str + "END\r\n") + "@EXECUTE;ANSTEELLAB;" + str20 + "\r\n") + "@NORMAL\r\n");
        }

        private string dealDataOld(string f, string proName, string proNo, string Patch, string wareNo, string deNo, string ckDate, string manu, string pC, string cert, string pL, string supp, string loca, string q, string u, string w, string r, string p, string cop)
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
            string str12 = pL;
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
            if ((str5 == null) || str5.Equals(""))
            {
                str = str + "POINT;285;345;15;15;'" + str4 + "'\r\n";
            }
            else
            {
                str = str + "POINT;285;345;15;15;'" + str6 + str5 + str4 + "'\r\n";
            }
            str = (((((((((((((((((((((((((((((str + "POINT;490;350;15;15;'" + str7 + "'\r\n") + "POINT;490;1150;15;15;'" + str4 + "'\r\n") + "POINT;585;350;15;15;'" + str5 + "'\r\n") + "POINT;585;1150;15;15;'" + str8 + "'\r\n") + "POINT;965;350;15;15;'" + str14 + "'\r\n") + "POINT;965;930;15;15;'" + str15 + "'\r\n") + "POINT;1060;930;15;15;'" + str17 + "'\r\n") + "POINT;1060;1370;15;15;'" + str19 + "'\r\n") + "POINT;775;1150;15;15;'" + str12 + "'\r\n") + "POINT;690;350;15;15;'" + str9 + "'\r\n") + "POINT;680;1150;15;15;'" + str10 + "'\r\n") + "POINT;775;350;15;15;'" + str11 + "'\r\n") + "STOP\r\n" + "FONT;FACE 92250;BOLD ON;SLANT OFF;SYMSET 0\r\n") + "TWOBYTE\r\n" + "POINT;110;500;18;18;'鞍钢股份设备处备件卡'\r\n") + "POINT;195;90;10;8;'二级厂'\r\n" + "POINT;205;590;10;8;'物料描述'\r\n") + "POINT;205;810;12;10;'" + str3 + "'\r\n") + "POINT;345;90;10;8;'设备代码'\r\n" + "POINT;490;90;10;8;'凭证号'\r\n") + "POINT;490;900;10;8;'物料号'\r\n" + "POINT;585;90;10;8;'批次号'\r\n") + "POINT;585;900;10;8;'入库日期'\r\n" + "POINT;680;90;10;8;'说明书'\r\n") + "POINT;680;900;10;8;'产品证书'\r\n" + "POINT;775;90;10;8;'合格证'\r\n") + "POINT;775;900;10;8;'保管员'\r\n" + "POINT;870;90;10;8;'供货单位'\r\n") + "POINT;880;340;15;15;'" + str13 + "'\r\n") + "POINT;965;90;10;8;'货  位'\r\n") + "POINT;965;730;10;8;'货位数量'\r\n" + "POINT;965;1180;10;8;'货位备注'\r\n") + "POINT;965;1370;10;8;'" + str18 + "'\r\n") + "POINT;1060;90;10;8;'单  位'\r\n") + "POINT;1070;350;15;15;'" + str16 + "'\r\n") + "POINT;1060;730;10;8;'单  重'\r\n") + "POINT;1060;1180;10;8;'单　价'\r\n" + "STOP\r\n") + "BARCODE\r\n" + "C128C;H4.55;DARK;265;345\r\n";
            if ((str5 == null) || str5.Equals(""))
            {
                str = str + "*" + str4 + "*\r\n";
            }
            else
            {
                str = str + "*" + str6 + str5 + str4 + "*\r\n";
            }
            str = str + "PDF;S\r\n" + "STOP\r\n";
            string old = "";
            if (this.Text.Equals("RFID标签"))
            {
                if ((str5 == null) || str5.Equals(""))
                {
                    old = str4;
                }
                else
                {
                    old = str6 + str5 + str4;
                }
                string str22 = (this.Data_Hex(old) + "000000000000000000000000000000000000").Substring(0, 0x44);
                str = ((((str + "RFWTAG;272;USR\r\n") + "128;H;*" + str22.Substring(0, 0x20) + "*\r\n") + "128;H;*" + str22.Substring(0x20, 0x20) + "*\r\n") + "16;H;*" + str22.Substring(0x40, 4) + "*\r\n") + "STOP\r\n";
            }
            return (((str + "END\r\n") + "@EXECUTE;ANSTEELLAB;" + str20 + "\r\n") + "@NORMAL\r\n");
        }


    }
}
