using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Analytics
{
    class PaymentsModel
    {
        private Month Month;

        public DateTime Date { get; set; }
        public string SettlementId { get; set; }
        public string Type { get; set; }
        public string OrderId { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Marketplace { get; set; }
        public string Fullfilment { get; set; }
        public string OrderCity { get; set; }
        public string OrderState { get; set; }
        public string OrderPostal { get; set; }
        public double ProductSales { get; set; }
        public double ShippingCredits { get; set; }
        public double GiftWrapCredits { get; set; }
        public double PromotionalRebates { get; set; }
        public double SaleTaxCollected { get; set; }
        public double MarketplaceFacilitatorTax { get; set; }
        public double SellingFees { get; set; }
        public double FBAFees { get; set; }
        public double OtherTransactionFees { get; set; }
        public double Other { get; set; }
        public double Total { get; set; }


        public int FieldCount { get; }

        public PaymentsModel()
        {
            FieldCount = 23;
            Month = new Month();
        }

        public object GetPayments(int i)
        {
            switch (i)
            {
                case 0:
                    return Date;
                    break;
                case 1:
                    return SettlementId;
                    break;
                case 2:
                    return Type;
                    break;
                case 3:
                    return OrderId;
                    break;
                case 4:
                    return Sku;
                    break;
                case 5:
                    return Description;
                    break;
                case 6:
                    return Quantity;
                    break;
                case 7:
                    return Marketplace;
                    break;
                case 8:
                    return Fullfilment;
                    break;
                case 9:
                    return OrderCity;
                    break;
                case 10:
                    return OrderState;
                    break;
                case 11:
                    return OrderPostal;
                    break;
                case 12:
                    return ProductSales;
                    break;
                case 13:
                    return ShippingCredits;
                    break;
                case 14:
                    return GiftWrapCredits;
                    break;
                case 15:
                    return PromotionalRebates;
                    break;
                case 16:
                    return SaleTaxCollected;
                    break;
                case 17:
                    return MarketplaceFacilitatorTax;
                    break;
                case 18:
                    return SellingFees;
                    break;
                case 19:
                    return FBAFees;
                    break;
                case 20:
                    return OtherTransactionFees;
                    break;
                case 21:
                    return Other;
                    break;
                case 22:
                    return Total;
                    break;
                default:
                    return null;
                    break;
            }
        }

        public void SetPayments(int i, object _value)
        {
            switch (i)
            {
                case 0:
                    Date = DateTransform(_value.ToString());
                    break;
                case 1:
                    Date = new DateTime(int.Parse(_value.ToString().Substring(1, 4)), Date.Month, Date.Day);
                    break;
                case 2:
                    SettlementId = _value.ToString();
                    break;
                case 3:
                    Type = _value.ToString();
                    break;
                case 4:
                    OrderId = _value.ToString();
                    break;
                case 5:
                    Sku = _value.ToString();
                    break;
                case 6:
                    Description = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 7:
                    if (!_value.ToString().Equals(""))
                        Quantity = int.Parse(_value.ToString());
                    else
                        Quantity = 0;
                    break;
                case 8:
                    Marketplace = _value.ToString();
                    break;
                case 9:
                    Fullfilment = _value.ToString();
                    break;
                case 10:
                    OrderCity = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 11:
                    OrderState = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 12:
                    OrderPostal = _value.ToString();
                    break;
                case 13:
                    ProductSales = GetDouble(_value);
                    break;
                case 14:
                    ShippingCredits = GetDouble(_value);
                    break;
                case 15:
                    GiftWrapCredits = GetDouble(_value);
                    break;
                case 16:
                    PromotionalRebates = GetDouble(_value);
                    break;
                case 17:
                    SaleTaxCollected = GetDouble(_value);
                    break;
                case 18:
                    MarketplaceFacilitatorTax = GetDouble(_value);
                    break;
                case 19:
                    SellingFees = GetDouble(_value);
                    break;
                case 20:
                    FBAFees = GetDouble(_value);
                    break;
                case 21:
                    OtherTransactionFees = GetDouble(_value);
                    break;
                case 22:
                    Other = GetDouble(_value);
                    break;
                case 23:
                    Total = GetDouble(_value);
                    break;
            }
        }

        public void SetPaymentsForUpdate(int i, object _value)
        {
            switch (i)
            {
                case 0:
                    Date = (DateTime)_value;
                    break;
                case 1:
                    SettlementId = _value.ToString();
                    break;
                case 2:
                    Type = _value.ToString();
                    break;
                case 3:
                    OrderId = _value.ToString();
                    break;
                case 4:
                    Sku = _value.ToString();
                    break;
                case 5:
                    Description = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 6:
                    if (!_value.ToString().Equals(""))
                        Quantity = int.Parse(_value.ToString());
                    else
                        Quantity = 0;
                    break;
                case 7:
                    Marketplace = _value.ToString();
                    break;
                case 8:
                    Fullfilment = _value.ToString();
                    break;
                case 9:
                    OrderCity = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 10:
                    OrderState = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 11:
                    OrderPostal = _value.ToString();
                    break;
                case 12:
                    ProductSales = GetDouble(_value);
                    break;
                case 13:
                    ShippingCredits = GetDouble(_value);
                    break;
                case 14:
                    GiftWrapCredits = GetDouble(_value);
                    break;
                case 15:
                    PromotionalRebates = GetDouble(_value);
                    break;
                case 16:
                    SaleTaxCollected = GetDouble(_value);
                    break;
                case 17:
                    MarketplaceFacilitatorTax = GetDouble(_value);
                    break;
                case 18:
                    SellingFees = GetDouble(_value);
                    break;
                case 19:
                    FBAFees = GetDouble(_value);
                    break;
                case 20:
                    OtherTransactionFees = GetDouble(_value);
                    break;
                case 21:
                    Other = GetDouble(_value);
                    break;
                case 22:
                    Total = GetDouble(_value);
                    break;
            }
        }

        /* Делаем правильный формат даты */
        private DateTime DateTransform(string _str)
        {
            string res = _str;
            if (_str.Length != 6)
            {
                string tmp1 = _str.Substring(0, 3);
                string tmp2 = _str.Substring(4, 1);
                res = tmp1 + " 0" + tmp2;
            }
            int year = DateTime.Now.Year; //int.Parse(_str.Substring(8, 4));
            int day = int.Parse(res.Substring(4, 2));
            int month = Month.GetMonthValue(res.Substring(0, 3));
            DateTime dt = new DateTime(year, month, day);
            return dt;
        }

        private double GetDouble(object _value)
        {
            double _amount = 0;
            if (!_value.ToString().Equals(""))
            {
                //try
                //{
                //    _amount = double.Parse(_value.ToString());
                //}
                //catch (Exception ex)
                //{
                    string s = _value.ToString();
                    string str = s.Replace(",", ".");
                    _amount = double.Parse(s, CultureInfo.InvariantCulture);
                //}
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
