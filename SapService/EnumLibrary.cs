using System;

namespace SapService
{
    /// <summary>
    /// 同SapDoWork中的Enumlibrary.cs 一样
    /// </summary>
    public class Enumlibrary
    {
    }

    public class StringConst
    {
        //public const int 一维条码长度 = 32;//一维条码长度 系统代码(R)+工厂号(4)+订单号(10)+物料编码(14)+交货次数序号(3)
        public const string xtdm = "R";//RF系统代码
        //public const int 原物料条码长度 = 28;//原系统一维条码长度 工厂号(4)+订单号(10)+物料编码(14)
    }

    public enum enumOpType
    {
        采购收货,
        验收入库,
        代管入库,
        上架,
        生产领料,
        移至报废库,
        报废出库,
        库存退货,   //即验收退货
        采购退货,   //冻结库退货
        代管出库,
        实时盘点,
        批处理盘点,
        实时移库,
        批量移库,
        批次查询
    }

    public enum enum条码类型
    {
        无 = -1,
        原物料条码 = 0,
        一维条码 = 1
    }

    public class clsYwtm
    {
        string _ywtm;
        /// <summary>
        /// 一维条码
        /// </summary>
        public string Ywtm
        {
            get { return _ywtm; }
            set { _ywtm = value; }
        }
        string _xtdm;
        /// <summary>
        /// 系统代码
        /// </summary>
        public string Xtdm
        {
            get { return _xtdm; }
            set { _xtdm = value; }
        }
        string _gch;
        /// <summary>
        /// 工厂号
        /// </summary>
        public string Gch
        {
            get { return _gch; }
            set { _gch = value; }
        }
        string _order_no;
        /// <summary>
        /// 订单号
        /// </summary>
        public string Order_no
        {
            get { return _order_no; }
            set { _order_no = value; }
        }
        string _product_no;
        /// <summary>
        /// 物料编码
        /// </summary>
        public string Product_no
        {
            get { return _product_no; }
            set { _product_no = value; }
        }
        string _jhsxh;
        /// <summary>
        /// 交货顺序号
        /// </summary>
        public string Jhsxh
        {
            get { return _jhsxh; }
            set { _jhsxh = value; }
        }
        enum条码类型 _tmlx;
        /// <summary>
        /// 条码类型
        /// </summary>
        public enum条码类型 Tmlx
        {
            get { return _tmlx; }
            set { _tmlx = value; }
        }
        string _pch;
        /// <summary>
        /// 批次号
        /// </summary>
        public string Pch
        {
            get { return _pch; }
            set { _pch = value; }
        }

        private int _tmlen;
        /// <summary>
        /// 条码长度
        /// </summary>
        public int Tmlen
        {
            get { return _tmlen; }
            set { _tmlen = value; }
        }
        private string  _h_no;
        public string H_no
        {
            get{return _h_no;}
            set{ _h_no = value;}
        }

        public clsYwtm()
        {
        }

        public clsYwtm(string ywtm)
        {
            ywtm = ywtm.Trim();
            if (ywtm == "") return;
            if (ywtm.Length == 36)
            {
                this._ywtm = ywtm;
                this._xtdm = ywtm.Substring(0, 1);
                this._gch = ywtm.Substring(1, 4);
                this._order_no = ywtm.Substring(5, 10);
                this._h_no = ywtm.Substring(15, 4);
                this._product_no = ywtm.Substring(19, 14);
                this._jhsxh = ywtm.Substring(23, 3);
                this._pch = "";
                this._tmlen = ywtm.Length;
                this._tmlx = enum条码类型.一维条码;
            }
            else if (ywtm.Trim().Length == 28)
            {
                this._ywtm = ywtm;
                this._xtdm = "";
                this._gch = ywtm.Substring(0, 4);
                this._order_no = "";
                this._product_no = ywtm.Substring(14);
                this._jhsxh = "";
                this._h_no = "";
                this._pch = ywtm.Substring(4, 10);
                this._tmlen = ywtm.Length;
                this._tmlx = enum条码类型.原物料条码;
            }
            else
            {
                this._ywtm = "";
                this._xtdm = "";
                this._gch = "";
                this._order_no = "";
                this._product_no = "";
                this._jhsxh = "";
                this._pch = "";
                this._tmlen = 0;
                this._h_no = "";
                this._tmlx = enum条码类型.无;
            }
        }

    }

}
