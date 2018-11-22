using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics
{
    class TransactionType
    {
        public string OrderPayment { get; }
        public string Other { get; }
        public string Refund { get; }
        public string ServiceFees { get; }

        public int FieldCount { get; }

        public TransactionType()
        {
            FieldCount = 4;
            OrderPayment = "Order Payment";
            Other = "Other";
            Refund = "Refund";
            ServiceFees = "Service Fees";
        }

        public string GetField(string str)
        {
            switch (str)
            {
                case "Order Payment":
                    return OrderPayment;
                    break;
                case "Other":
                    return Other;
                    break;
                case "Refund":
                    return Refund;
                    break;
                case "Service Fees":
                    return ServiceFees;
                    break;
                default:
                    return "";
                    break;
            }
        }

        public enum Type
        {
            OrderPayment,
            Refund,
            ServiceFees,
            Other
        }
    }
}
