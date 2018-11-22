using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics
{
    class PaymentsModel
    {
        public string Date { get; set; }
        public string OrderId { get; set; }
        public string Sku { get; set; }
        public string TransactionType { get; set; }
        public string PaymentType { get; set; }
        public string PaymentDetail { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public string ProductTitle { get; set; }

        public int FieldCount { get; }

        public PaymentsModel()
        {
            FieldCount = 9;
        }

        public object GetPayments(int i)
        {
            switch (i)
            {
                case 0:
                    return Date;
                    break;
                case 1:
                    return OrderId;
                    break;
                case 2:
                    return Sku;
                    break;
                case 3:
                    return TransactionType;
                    break;
                case 4:
                    return PaymentType;
                    break;
                case 5:
                    return PaymentDetail;
                    break;
                case 6:
                    return Amount;
                    break;
                case 7:
                    return Quantity;
                    break;
                case 8:
                    return ProductTitle;
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
                    Date = _value.ToString();
                    break;
                case 1:
                    OrderId = _value.ToString();
                    break;
                case 2:
                    Sku = _value.ToString();
                    break;
                case 3:
                    TransactionType = _value.ToString();
                    break;
                case 4:
                    PaymentType = _value.ToString();
                    break;
                case 5:
                    PaymentDetail = _value.ToString();
                    break;
                case 6:
                    if (!_value.ToString().Equals(""))
                    {
                        bool success = false;
                        try
                        {
                            Amount = double.Parse(_value.ToString());
                            success = true;
                        }
                        catch (Exception ex) { }
                        if (!success)
                        {
                            string s = _value.ToString();
                            string str = s.Substring(1, s.Length - 1);
                            Amount = double.Parse(str, CultureInfo.InvariantCulture);
                        }
                    }
                    else
                        Amount = 0;
                    break;
                case 7:
                    if (!_value.ToString().Equals(""))
                        Quantity = int.Parse(_value.ToString());
                    else
                        Quantity = 0;
                    break;
                case 8:
                    ProductTitle = _value.ToString();
                    break;
            }
        }
    }
}
