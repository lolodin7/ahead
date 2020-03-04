using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class StockModel
    {
        private DateTime _updateDate;
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = (DateTime)value; }
        }

        private int _productId;
        public int ProductId { get { return _productId; } set { _productId = int.Parse(value.ToString()); } }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = GetStringWithoutApostrophe(value); }
        }

        public string ASIN { get; set; }
        public string SKU { get; set; }
        public string FNSKU { get; set; }
        public int MarketPlaceId { get; set; }
        public int FulfillableItems { get; set; }
        public int ReservedItems { get; set; }
        public int InboundShipped { get; set; }
        public int InboundWorking { get; set; }
        public double DaysLeft { get; set; }
        public int Sales30Days { get; set; }
        public double Average { get; set; }

        public int FieldCount { get; }

        public StockModel()
        {
            FieldCount = 14;
        }

        public void WriteData(int index, object value)
        {
            switch (index)
            {
                case 0:
                    UpdateDate = (DateTime)value;
                    break;
                case 1:
                    ProductId = int.Parse(value.ToString());
                    break;
                case 2:
                    Name = value.ToString();
                    break;
                case 3:
                    ASIN = value.ToString();
                    break;
                case 4:
                    SKU = value.ToString();
                    break;
                case 5:
                    FNSKU = value.ToString();
                    break;
                case 6:
                    MarketPlaceId = int.Parse(value.ToString());
                    break;
                case 7:
                    FulfillableItems = int.Parse(value.ToString());
                    break;
                case 8:
                    ReservedItems = int.Parse(value.ToString());
                    break;
                case 9:
                    InboundShipped = int.Parse(value.ToString());
                    break;
                case 10:
                    InboundWorking = int.Parse(value.ToString());
                    break;
                case 11:
                    DaysLeft = GetDouble(value);
                    break;
                case 12:
                    Sales30Days = int.Parse(value.ToString());
                    break;
                case 13:
                    Average = GetDouble(value);
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return UpdateDate;
                    break;
                case 1:
                    return ProductId;
                    break;
                case 2:
                    return Name;
                    break;
                case 3:
                    return ASIN;
                    break;
                case 4:
                    return SKU;
                    break;
                case 5:
                    return FNSKU;
                    break;
                case 6:
                    return MarketPlaceId;
                    break;
                case 7:
                    return FulfillableItems;
                    break;
                case 8:
                    return ReservedItems;
                    break;
                case 9:
                    return InboundShipped;
                    break;
                case 10:
                    return InboundWorking;
                    break;
                case 11:
                    return DaysLeft;
                    break;
                case 12:
                    return Sales30Days;
                    break;
                case 13:
                    return Average;
                    break;
                default:
                    return null;
                    break;
            }
        }

        private string GetStringWithoutApostrophe(string _value)
        {
            string str = _value;
            string s = "";
            str = Regex.Replace(str, "\'", s);
            return str;
        }

        private double GetDouble(object _value)
        {
            double _amount = 0;
            if (!_value.ToString().Equals(""))
            {
                try
                {
                    _amount = double.Parse(_value.ToString());
                }
                catch (Exception ex)
                {
                    string s = _value.ToString();
                    string str = s.Substring(1, s.Length - 1);
                    _amount = double.Parse(str, CultureInfo.InvariantCulture);
                }
            }
            else
                _amount = 0;
            return _amount;
        }
    }
}