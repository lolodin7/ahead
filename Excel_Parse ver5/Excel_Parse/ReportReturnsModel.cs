using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ReportReturnsModel
    {
        public DateTime ReturnDate { get; set; }
        public string OrderId { get; set; }
        public string SKU { get; set; }
        public string ASIN { get; set; }
        public string FNSKU { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string FulfillmentCenterId { get; set; }
        public string DetailedDisposition { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string LicensePlateNumber { get; set; }
        public string CustomerComments { get; set; }
        public int MarketplaceId { get; set; }
        public int ProductId { get; set; }


        public int ColumnCount { get; }


        public ReportReturnsModel()
        {
            ColumnCount = 15;
        }

        public void WriteData(int index, object value)
        {
            switch (index)
            {
                case 0:
                    ReturnDate = (DateTime)value;
                    break;
                case 1:
                    OrderId = value.ToString();
                    break;
                case 2:
                    SKU = value.ToString();
                    break;
                case 3:
                    ASIN = value.ToString();
                    break;
                case 4:
                    FNSKU = value.ToString();
                    break;
                case 5:
                    ProductName = value.ToString();
                    break;
                case 6:
                    Quantity = int.Parse(value.ToString());
                    break;
                case 7:
                    FulfillmentCenterId = value.ToString();
                    break;
                case 8:
                    DetailedDisposition = value.ToString();
                    break;
                case 9:
                    Reason = value.ToString();
                    break;
                case 10:
                    Status = value.ToString();
                    break;
                case 11:
                    LicensePlateNumber = value.ToString();
                    break;
                case 12:
                    CustomerComments = value.ToString();
                    break;
                case 13:
                    MarketplaceId = int.Parse(value.ToString());
                    break;
                case 14:
                    ProductId = int.Parse(value.ToString());
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return ReturnDate;
                case 1:
                    return OrderId;
                case 2:
                    return SKU;
                case 3:
                    return ASIN;
                case 4:
                    return FNSKU;
                case 5:
                    return ProductName;
                case 6:
                    return Quantity;
                case 7:
                    return FulfillmentCenterId;
                case 8:
                    return DetailedDisposition;
                case 9:
                    return Reason;
                case 10:
                    return Status;
                case 11:
                    return LicensePlateNumber;
                case 12:
                    return CustomerComments;
                case 13:
                    return MarketplaceId;
                case 14:
                    return ProductId;
                default:
                    return null;
            }
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
