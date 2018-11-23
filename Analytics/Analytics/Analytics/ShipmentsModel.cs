using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Analytics
{
    class ShipmentsModel
    {
        public string AmazonOrderId { get; set; }
        public string MerchantOrderId { get; set; }
        public string ShipmentId { get; set; }
        public string ShipmentItemId { get; set; }
        public string AmazonOrderItemId { get; set; }
        public string MerchantOrderItemId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime PaymentsDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime ReportingDate { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerName { get; set; }
        public string BuyerPhoneNumber { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public int QuantityShipped { get; set; }
        public string Currency { get; set; }
        public double ItemPrice { get; set; }
        public double ItemTax { get; set; }
        public double ShippingPrice { get; set; }
        public double ShippingTax { get; set; }
        public double GiftWrapPrice { get; set; }
        public double GiftWrapTax { get; set; }
        public string ShipServiceLevel { get; set; }
        public string RecipientName { get; set; }
        public string ShipAddress1 { get; set; }
        public string ShipAddress2 { get; set; }
        public string ShipAddress3 { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPhoneNumber { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillAddress3 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillPostalCode { get; set; }
        public string BillCountry { get; set; }
        public double ItemPromotionDiscount { get; set; }
        public double ShipPromotionDiscount { get; set; }
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public string FullfilmentCenterId { get; set; }
        public string FullfilmentChannel { get; set; }
        public string SalesChannel { get; set; }



        public int FieldCount { get; }


        public ShipmentsModel()
        {
            FieldCount = 48;
        }

        public object GetShipments(int i)
        {
            switch (i)
            {
                case 0:
                    return AmazonOrderId;                                               
                    break;
                case 1:
                    return MerchantOrderId;
                    break;
                case 2:
                    return ShipmentId;
                    break;
                case 3:
                    return ShipmentItemId;
                    break;
                case 4:
                    return AmazonOrderItemId;
                    break;
                case 5:
                    return MerchantOrderItemId;
                    break;
                case 6:
                    return PurchaseDate;
                    break;
                case 7:
                    return PaymentsDate;
                    break;
                case 8:
                    return ShipmentDate;
                    break;
                case 9:
                    return ReportingDate;
                    break;
                case 10:
                    return BuyerEmail;
                    break;
                case 11:
                    return BuyerName;
                    break;
                case 12:
                    return BuyerPhoneNumber;
                    break;
                case 13:
                    return Sku;
                    break;
                case 14:
                    return ProductName;
                    break;
                case 15:
                    return QuantityShipped;
                    break;
                case 16:
                    return Currency;
                    break;
                case 17:
                    return ItemPrice;
                    break;
                case 18:
                    return ItemTax;
                    break;
                case 19:
                    return ShippingPrice;
                    break;
                case 20:
                    return ShippingTax;
                    break;
                case 21:
                    return GiftWrapPrice;
                    break;
                case 22:
                    return GiftWrapTax;
                    break;
                case 23:
                    return ShipServiceLevel;
                    break;
                case 24:
                    return RecipientName;
                    break;
                case 25:
                    return ShipAddress1;
                    break;
                case 26:
                    return ShipAddress2;
                    break;
                case 27:
                    return ShipAddress3;
                    break;
                case 28:
                    return ShipCity;
                    break;
                case 29:
                    return ShipState;
                    break;
                case 30:
                    return ShipPostalCode;
                    break;
                case 31:
                    return ShipCountry;
                    break;
                case 32:
                    return ShipPhoneNumber;
                    break;
                case 33:
                    return BillAddress1;
                    break;
                case 34:
                    return BillAddress2;
                    break;
                case 35:
                    return BillAddress3;
                    break;
                case 36:
                    return BillCity;
                    break;
                case 37:
                    return BillState;
                    break;
                case 38:
                    return BillPostalCode;
                    break;
                case 39:
                    return BillCountry;
                    break;
                case 40:
                    return ItemPromotionDiscount;
                    break;
                case 41:
                    return ShipPromotionDiscount;
                    break;
                case 42:
                    return Carrier;
                    break;
                case 43:
                    return TrackingNumber;
                    break;
                case 44:
                    return EstimatedArrivalDate;
                    break;
                case 45:
                    return FullfilmentCenterId;
                    break;
                case 46:
                    return FullfilmentChannel;
                    break;
                case 47:
                    return SalesChannel;
                    break;
                default:
                    return null;
                    break;
            }
        }

        public void SetShipments(int i, object _value)
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
                    ShipmentId = _value.ToString();
                    break;
                case 3:
                    ShipmentItemId = _value.ToString();
                    break;
                case 4:
                    AmazonOrderItemId = _value.ToString();
                    break;
                case 5:
                    MerchantOrderItemId = _value.ToString();
                    break;
                case 6:
                    if (!_value.ToString().Equals(""))
                    {
                        int year = int.Parse(_value.ToString().Substring(0, 4));
                        int month = int.Parse(_value.ToString().Substring(5, 2));
                        int day = int.Parse(_value.ToString().Substring(8, 2));
                        PurchaseDate = new DateTime(year, month, day);
                    }
                    else
                        PurchaseDate = new DateTime();
                    break;
                case 7:
                    if (!_value.ToString().Equals(""))
                    {
                        int year2 = int.Parse(_value.ToString().Substring(0, 4));
                        int month2 = int.Parse(_value.ToString().Substring(5, 2));
                        int day2 = int.Parse(_value.ToString().Substring(8, 2));
                        PaymentsDate = new DateTime(year2, month2, day2);
                    }
                    else
                        PaymentsDate = new DateTime();
                    break;
                case 8:
                    if (!_value.ToString().Equals(""))
                    {
                        int year3 = int.Parse(_value.ToString().Substring(0, 4));
                        int month3 = int.Parse(_value.ToString().Substring(5, 2));
                        int day3 = int.Parse(_value.ToString().Substring(8, 2));
                        ShipmentDate = new DateTime(year3, month3, day3);
                    }
                    else
                        ShipmentDate = new DateTime();
                    break;
                case 9:
                    if (!_value.ToString().Equals(""))
                    {
                        int year4 = int.Parse(_value.ToString().Substring(0, 4));
                        int month4 = int.Parse(_value.ToString().Substring(5, 2));
                        int day4 = int.Parse(_value.ToString().Substring(8, 2));
                        ReportingDate = new DateTime(year4, month4, day4);
                    }
                    else
                        ReportingDate = new DateTime();
                    break;
                case 10:
                    BuyerEmail = _value.ToString();
                    break;
                case 11:
                    BuyerName = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 12:
                    BuyerPhoneNumber = _value.ToString();
                    break;
                case 13:
                    Sku = _value.ToString();
                    break;
                case 14:
                    ProductName = _value.ToString();
                    break;
                case 15:
                    if (!_value.ToString().Equals(""))
                        QuantityShipped = int.Parse(_value.ToString());
                    else
                        QuantityShipped = 0;
                    break;
                case 16:
                    Currency = _value.ToString();
                    break;
                case 17:
                    ItemPrice = GetDouble(_value);
                    break;
                case 18:
                    ItemTax = GetDouble(_value);
                    break;
                case 19:
                    ShippingPrice = GetDouble(_value);
                    break;
                case 20:
                    ShippingTax = GetDouble(_value);
                    break;
                case 21:
                    GiftWrapPrice = GetDouble(_value);
                    break;
                case 22:
                    GiftWrapTax = GetDouble(_value);
                    break;
                case 23:
                    ShipServiceLevel = _value.ToString();
                    break;
                case 24:
                    RecipientName = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 25:
                    ShipAddress1 = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 26:
                    ShipAddress2 = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 27:
                    ShipAddress3 = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 28:
                    ShipCity = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 29:
                    ShipState = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 30:
                    ShipPostalCode = _value.ToString();
                    break;
                case 31:
                    ShipCountry = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 32:
                    ShipPhoneNumber = _value.ToString();
                    break;
                case 33:
                    BillAddress1 = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 34:
                    BillAddress2 = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 35:
                    BillAddress3 = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 36:
                    BillCity = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 37:
                    BillState = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 38:
                    BillPostalCode = _value.ToString();
                    break;
                case 39:
                    BillCountry = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 40:
                    ItemPromotionDiscount = GetDouble(_value);
                    break;
                case 41:
                    ShipPromotionDiscount = GetDouble(_value);
                    break;
                case 42:
                    Carrier = _value.ToString();
                    break;
                case 43:
                    TrackingNumber = _value.ToString();
                    break;
                case 44:
                    int year5 = int.Parse(_value.ToString().Substring(0, 4));
                    int month5 = int.Parse(_value.ToString().Substring(5, 2));
                    int day5 = int.Parse(_value.ToString().Substring(8, 2));
                    EstimatedArrivalDate = new DateTime(year5, month5, day5); ;
                    break;
                case 45:
                    FullfilmentCenterId = _value.ToString();
                    break;
                case 46:
                    FullfilmentChannel = _value.ToString();
                    break;
                case 47:
                    SalesChannel = _value.ToString();
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
    }
}
