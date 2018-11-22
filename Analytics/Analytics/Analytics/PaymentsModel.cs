using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics
{
    class PaymentsModel
    {
        public DateTime date { get; set; }
        public string OrderId { get; set; }
        public string Sku { get; set; }
        public string[,] PaymentInfo { get; set; } 
        public float Amount { get; set; }
        public int Quantity { get; set; }
        public string ProductTitle { get; set; }

        public PaymentsModel(int _rowCount)
        {
            PaymentInfo = new string[_rowCount, 4];
        }
    }
}
