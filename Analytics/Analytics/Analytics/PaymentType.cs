using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics
{
    class PaymentType
    {
        public string AmazonFees { get; }
        public string FBAInventoryReimbursementCustomerReturn { get; }
        public string Other { get; }
        public string ProductCharges { get; }
        public string PromoRebates { get; }
        public string TransactionDetails { get; }

        public int FieldCount { get; }

        public PaymentType()
        {
            FieldCount = 6;
            AmazonFees = "Amazon Fees";
            FBAInventoryReimbursementCustomerReturn = "FBA Inventory Reimbursement - Customer Return";
            Other = "Other";
            ProductCharges = "Product Charges";
            PromoRebates = "Promo Rebates";
            TransactionDetails = "Transaction Details";
        }


        public string GetField(string str)
        {
            switch (str)
            {
                case "Amazon Fees":
                    return AmazonFees;
                    break;
                case "FBA Inventory Reimbursement - Customer Return":
                    return FBAInventoryReimbursementCustomerReturn;
                    break;
                case "Other":
                    return Other;
                    break;
                case "Product Charges":
                    return ProductCharges;
                    break;
                case "Promo Rebates":
                    return PromoRebates;
                    break;
                case "Transaction Details":
                    return TransactionDetails;
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}
