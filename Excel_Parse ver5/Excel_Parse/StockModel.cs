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




/*public void WriteData(int i, object _value)
{
    switch (i)
    {
        case 0:
            AmazonOrderId = _value.ToString();
            break;
        case 1:
            MerchantOrderId = _value.ToString();
            break;
        case 2:
            //2019-10-03T06:19:55+00:00
            string str = _value.ToString();
            int year = int.Parse(str.Substring(0, 4));
            int month = int.Parse(str.Substring(5, 2));
            int day = int.Parse(str.Substring(8, 2));
            int hour = int.Parse(str.Substring(11, 2));
            int minutes = int.Parse(str.Substring(14, 2));
            int seconds = int.Parse(str.Substring(17, 2));
            PurchaseDate = new DateTime(year, month, day, hour, minutes, seconds);
            break;
        case 3:
            //2019-10-03T06:19:55+00:00
            string str2 = _value.ToString();
            int year2 = int.Parse(str2.Substring(0, 4));
            int month2 = int.Parse(str2.Substring(5, 2));
            int day2 = int.Parse(str2.Substring(8, 2));
            int hour2 = int.Parse(str2.Substring(11, 2));
            int minutes2 = int.Parse(str2.Substring(14, 2));
            int seconds2 = int.Parse(str2.Substring(17, 2));
            LastUpdatedDate = new DateTime(year2, month2, day2, hour2, minutes2, seconds2);
            break;
        case 4:
            OrderStatus = _value.ToString();
            break;
        case 5:
            FullfilmentChannel = _value.ToString();
            break;
        case 6:
            SalesChannel = _value.ToString();
            break;
        case 7:
            OrderChannel = _value.ToString();
            break;
        case 8:
            Url = _value.ToString();
            break;
        case 9:
            ShipServiceLevel = _value.ToString();
            break;
        case 10:
            ProductName = GetStringWithoutApostrophe(_value.ToString());
            break;
        case 11:
            Sku = _value.ToString();
            break;
        case 12:
            Asin = _value.ToString();
            break;
        case 13:
            ItemStatus = _value.ToString();
            break;
        case 14:
            if (!_value.ToString().Equals(""))
                Quantity = int.Parse(_value.ToString());
            else
                Quantity = 0;
            break;
        case 15:
            Currency = _value.ToString();
            break;
        case 16:
            ItemPrice = GetDouble(_value);
            break;
        case 17:
            ItemTax = GetDouble(_value);
            break;
        case 18:
            ShippingPrice = GetDouble(_value);
            break;
        case 19:
            ShippingTax = GetDouble(_value);
            break;
        case 20:
            GiftWrapPrice = GetDouble(_value);
            break;
        case 21:
            GiftWrapTax = GetDouble(_value);
            break;
        case 22:
            ItemPromotionDiscount = GetDouble(_value);
            break;
        case 23:
            ShipPromotionDiscount = GetDouble(_value);
            break;
        case 24:
            ShipCity = GetStringWithoutApostrophe(_value.ToString());
            break;
        case 25:
            ShipState = GetStringWithoutApostrophe(_value.ToString());
            break;
        case 26:
            ShipPostalCode = _value.ToString();
            break;
        case 27:
            ShipCountry = GetStringWithoutApostrophe(_value.ToString());
            break;
        case 28:
            PromotionIds = _value.ToString();
            break;
        case 29:
            IsBusinessOrder = _value.ToString();
            break;
        case 30:
            PurchaseOrderNumber = GetStringWithoutApostrophe(_value.ToString());
            break;
        case 31:
            PriceDesignation = _value.ToString();
            break;
    }
}*/
