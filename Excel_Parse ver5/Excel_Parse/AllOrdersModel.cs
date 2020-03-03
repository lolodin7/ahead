using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class AllOrdersModel
    {
        public string AmazonOrderId { get; set; }
        public string MerchantOrderId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string OrderStatus { get; set; }
        public string FullfilmentChannel { get; set; }
        public string SalesChannel { get; set; }
        public string OrderChannel { get; set; }
        public string Url { get; set; }
        public string ShipServiceLevel { get; set; }
        public string ProductName { get; set; }
        public string Sku { get; set; }
        public string Asin { get; set; }
        public string ItemStatus { get; set; }
        public int Quantity { get; set; }
        public string Currency { get; set; }
        public double ItemPrice { get; set; }
        public double ItemTax { get; set; }
        public double ShippingPrice { get; set; }
        public double ShippingTax { get; set; }
        public double GiftWrapPrice { get; set; }
        public double GiftWrapTax { get; set; }
        public double ItemPromotionDiscount { get; set; }
        public double ShipPromotionDiscount { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string PromotionIds { get; set; }
        public string IsBusinessOrder { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PriceDesignation { get; set; }
        public int MarketPlaceId { get; set; }

        public int FieldCount { get; }

        public AllOrdersModel()
        {
            FieldCount = 32;
        }

        public void WriteData(int i, object _value)
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
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return AmazonOrderId;
                    break;
                case 1:
                    return MerchantOrderId;
                    break;
                case 2:
                    return PurchaseDate;
                    break;
                case 3:
                    return LastUpdatedDate;
                    break;
                case 4:
                    return OrderStatus;
                    break;
                case 5:
                    return FullfilmentChannel;
                    break;
                case 6:
                    return SalesChannel;
                    break;
                case 7:
                    return OrderChannel;
                    break;
                case 8:
                    return Url;
                    break;
                case 9:
                    return ShipServiceLevel;
                    break;
                case 10:
                    return ProductName;
                    break;
                case 11:
                    return Sku;
                    break;
                case 12:
                    return Asin;
                    break;
                case 13:
                    return ItemStatus;
                    break;
                case 14:
                    return Quantity;
                    break;
                case 15:
                    return Currency;
                    break;
                case 16:
                    return ItemPrice;
                    break;
                case 17:
                    return ItemTax;
                    break;
                case 18:
                    return ShippingPrice;
                    break;
                case 19:
                    return ShippingTax;
                case 20:
                    return GiftWrapPrice;
                    break;
                case 21:
                    return GiftWrapTax;
                    break;
                case 22:
                    return ItemPromotionDiscount;
                    break;
                case 23:
                    return ShipPromotionDiscount;
                    break;
                case 24:
                    return ShipCity;
                    break;
                case 25:
                    return ShipState;
                    break;
                case 26:
                    return ShipPostalCode;
                    break;
                case 27:
                    return ShipCountry;
                    break;
                case 28:
                    return PromotionIds;
                    break;
                case 29:
                    return IsBusinessOrder;
                    break;
                case 30:
                    return PurchaseOrderNumber;
                    break;
                case 31:
                    return PriceDesignation;
                    break;
                case 32:
                    return MarketPlaceId;
                    break;
                default:
                    return null;
                    break;
            }
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

        private string GetStringWithoutApostrophe(string _value)
        {
            string str = _value;
            string s = "";
            str = Regex.Replace(str, "\'", s);
            return str;
        }

        public void WriteDataForUpdates(int i, object _value)
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
                    PurchaseDate = (DateTime)_value;
                    break;
                case 3:
                    LastUpdatedDate = (DateTime)_value;
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
                case 32:
                    MarketPlaceId = int.Parse(_value.ToString());
                    break;
            }
        }
    }
}
