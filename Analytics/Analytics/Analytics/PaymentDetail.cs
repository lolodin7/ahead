using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics
{
    class PaymentDetail
    {
        public string FBPickPackFee { get; }
        public string GiftWrapChargeback { get; }
        public string ReferralFeeOnItemPrice { get; }
        public string ShippingChargeback { get; }
        public string GiftWrap { get; }
        public string ProductTax { get; }
        public string Shipping { get; }
        public string ShippingTax { get; }
        public string CouponRedemption { get; }
        public string CostOfAdvertising { get; }
        public string RefundAdministrationFee { get; }

        public int FieldCount { get; }

        public PaymentDetail()
        {
            FieldCount = 11;
            FBPickPackFee = "FBA Pick & Pack Fee";
            GiftWrapChargeback = "Gift Wrap Chargeback";
            ReferralFeeOnItemPrice = "Referral Fee on Item Price";
            ShippingChargeback = "Shipping Chargeback";
            GiftWrap = "Gift Wrap";
            ProductTax = "Product tax";
            Shipping = "Shipping";
            ShippingTax = "Shipping Tax";
            CouponRedemption = "Coupon Redemption";
            CostOfAdvertising = "Cost of Advertising";
            RefundAdministrationFee = "Refund Administration Fee";

        }
        public string GetField(string str)
        {
            switch (str)
            {
                case "FBA Pick & Pack Fee":
                    return FBPickPackFee;
                    break;
                case "Gift Wrap Chargeback":
                    return GiftWrapChargeback;
                    break;
                case "Referral Fee on Item Price":
                    return ReferralFeeOnItemPrice;
                    break;
                case "Shipping Chargeback":
                    return ShippingChargeback;
                    break;
                case "Gift Wrap":
                    return GiftWrap;
                    break;
                case "Product tax":
                    return ProductTax;
                    break;
                case "Shipping":
                    return Shipping;
                    break;
                case "Shipping Tax":
                    return ShippingTax;
                    break;
                case "Coupon Redemption":
                    return CouponRedemption;
                    break;
                case "Cost of Advertising":
                    return CostOfAdvertising;
                    break;
                case "Refund Administration Fee":
                    return RefundAdministrationFee;
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}
