using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ReportReturnsModel
    {
        public int RecordId { get; set; }
        public int MarketplaceId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string OrderId { get; set; }
        public string SKU { get; set; }
        public string ASIN { get; set; }
        public string FNSKU { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string FulfillmentCenterId { get; set; }
        public int DetailedDisposition { get; set; }
        public int Reason { get; set; }
        public string Status { get; set; }
        public string LicensePlateNumber { get; set; }
        public string CustomerComments { get; set; }


        public int ColumnCount { get; }


        public ReportReturnsModel()
        {
            ColumnCount = 15;
        }
    }
}
