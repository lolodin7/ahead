using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Analytics
{
    class CustomerReturnsModel
    {
        public DateTime ReturnDate { get; set; }
        public string OrderId { get; set; }
        public string SKU { get; set; }
        public string ASIN { get; set; }
        public string FNSKU { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string FullfilmentCenterId { get; set; }
        public string DetailedDisposition { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string LicensePlateNumber { get; set; }
        public string CustomerComments { get; set; }

        public int FieldCount { get; }

        public string[] dgvColumnsHeadersText { get; }

        public CustomerReturnsModel()
        {
            FieldCount = 13;

            dgvColumnsHeadersText = new string[] { "ReturnDate", "OrderId", "SKU", "ASIN", "FNSKU", "ProductName", "Quantity", "FullfilmentCenterId", "DetailedDisposition", "Reason", "Status", "LicensePlateNumber", "CustomerComments" };
        }

        public object GetCustomerReturns(int i)
        {
            switch (i)
            {
                case 0:
                    return ReturnDate;
                    break;
                case 1:
                    return OrderId;
                    break;
                case 2:
                    return SKU;
                    break;
                case 3:
                    return ASIN;
                    break;
                case 4:
                    return FNSKU;
                    break;
                case 5:
                    return ProductName;
                    break;
                case 6:
                    return Quantity;
                    break;
                case 7:
                    return FullfilmentCenterId;
                    break;
                case 8:
                    return DetailedDisposition;
                    break;
                case 9:
                    return Reason;
                    break;
                case 10:
                    return Status;
                    break;
                case 11:
                    return LicensePlateNumber;
                    break;
                case 12:
                    return CustomerComments;
                    break;
                default:
                    return null;
                    break;
            }
        }

        public void SetCustomerReturns(int i, object _value)
        {
            switch (i)
            {
                case 0:
                    string str = _value.ToString();
                    int year = int.Parse(str.Substring(0, 4));
                    int month = int.Parse(str.Substring(5, 2));
                    int day = int.Parse(str.Substring(8, 2));
                    ReturnDate = new DateTime(year, month, day);
                    break;
                case 1:
                    OrderId = _value.ToString();
                    break;
                case 2:
                    SKU = _value.ToString();
                    break;
                case 3:
                    ASIN = _value.ToString();
                    break;
                case 4:
                    FNSKU = _value.ToString();
                    break;
                case 5:
                    ProductName = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 6:
                    Quantity = int.Parse(_value.ToString());
                    break;
                case 7:
                    FullfilmentCenterId = _value.ToString();
                    break;
                case 8:
                    DetailedDisposition = _value.ToString();
                    break;
                case 9:
                    Reason = _value.ToString();
                    break;
                case 10:
                    Status = _value.ToString();
                    break;
                case 11:
                    LicensePlateNumber = _value.ToString();
                    break;
                case 12:
                    CustomerComments = GetStringWithoutApostrophe(_value.ToString());
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

        public void SetCustomerReturnsForUpdate(int i, object _value)
        {
            switch (i)
            {
                case 0:
                    ReturnDate = (DateTime)_value;
                    break;
                case 1:
                    OrderId = _value.ToString();
                    break;
                case 2:
                    SKU = _value.ToString();
                    break;
                case 3:
                    ASIN = _value.ToString();
                    break;
                case 4:
                    FNSKU = _value.ToString();
                    break;
                case 5:
                    ProductName = GetStringWithoutApostrophe(_value.ToString());
                    break;
                case 6:
                    Quantity = int.Parse(_value.ToString());
                    break;
                case 7:
                    FullfilmentCenterId = _value.ToString();
                    break;
                case 8:
                    DetailedDisposition = _value.ToString();
                    break;
                case 9:
                    Reason = _value.ToString();
                    break;
                case 10:
                    Status = _value.ToString();
                    break;
                case 11:
                    LicensePlateNumber = _value.ToString();
                    break;
                case 12:
                    CustomerComments = GetStringWithoutApostrophe(_value.ToString());
                    break;
            }
        }
    }
}
