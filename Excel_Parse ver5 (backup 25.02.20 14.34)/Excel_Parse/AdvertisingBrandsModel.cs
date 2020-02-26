using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class AdvertisingBrandsModel
    {

        public DateTime UpdateDate { get; set; }
        public string CurrencyCharCode { get; set; }
        public string CampaignName { get; set; }
        public string Targeting { get; set; }
        public string MatchType { get; set; }
        public int Impressions { get; set; }
        public int Clicks { get; set; }
        public double CTR { get; set; }
        public double CPC { get; set; }
        public double Spend { get; set; }
        public double Sales { get; set; }
        public double ACoS { get; set; }
        public double RoAS { get; set; }
        public int Orders { get; set; }
        public int Units { get; set; }
        public double ConversionRate { get; set; }
        public int NewToBrandOrders { get; set; }
        public double NewToBrandSales { get; set; }
        public int NewToBrandUnits { get; set; }
        public double NewToBrandOrderRate { get; set; }
        public int CampaignTypeId { get; set; }
        public int MarketPlaceId { get; set; }
        public int CampaignId { get; set; }
        public int ProductId1 { get; set; }
        public int ProductId2 { get; set; }
        public int ProductId3 { get; set; }

        public int ColumnCount { get; }
        
        public AdvertisingBrandsModel()
        {
            ColumnCount = 26;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    UpdateDate = (DateTime)record;
                    break;
                case 1:
                    CurrencyCharCode = record.ToString();
                    break;
                case 2:
                    CampaignName = record.ToString();
                    break;
                case 3:
                    Targeting = record.ToString();
                    break;
                case 4:
                    MatchType = record.ToString();
                    break;
                case 5:
                    Impressions = int.Parse(record.ToString());
                    break;
                case 6:
                    Clicks = int.Parse(record.ToString());
                    break;
                case 7:
                    CTR = GetDouble(record);
                    break;
                case 8:
                    CPC = GetDouble(record);
                    break;
                case 9:
                    Spend = GetDouble(record);
                    break;
                case 10:
                    ACoS = GetDouble(record);
                    break;
                case 11:
                    RoAS = GetDouble(record);
                    break;
                case 12:
                    Sales = GetDouble(record);
                    break;
                case 13:
                    Orders = int.Parse(record.ToString());
                    break;
                case 14:
                    Units = int.Parse(record.ToString());
                    break;
                case 15:
                    ConversionRate = GetDouble(record);
                    break;
                case 16:
                    NewToBrandOrders = int.Parse(record.ToString());
                    break;
                case 17:
                    NewToBrandSales = GetDouble(record);
                    break;
                case 18:
                    NewToBrandUnits = int.Parse(record.ToString());
                    break;
                case 19:
                    NewToBrandOrderRate = GetDouble(record);
                    break;
                case 20:
                    CampaignTypeId = int.Parse(record.ToString());
                    break;
                case 21:
                    MarketPlaceId = int.Parse(record.ToString());
                    break;
                case 22:
                    CampaignId = int.Parse(record.ToString());
                    break;
                case 23:
                    ProductId1 = int.Parse(record.ToString());
                    break;
                case 24:
                    ProductId2 = int.Parse(record.ToString());
                    break;
                case 25:
                    ProductId3 = int.Parse(record.ToString());
                    break;
            }
        }


        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return UpdateDate;
                    break;
                case 1:
                    return CurrencyCharCode;
                    break;
                case 2:
                    return CampaignName;
                    break;
                case 3:
                    return Targeting;
                    break;
                case 4:
                    return MatchType;
                    break;
                case 5:
                    return Impressions;
                    break;
                case 6:
                    return Clicks;
                    break;
                case 7:
                    return CTR;
                    break;
                case 8:
                    return CPC;
                    break;
                case 9:
                    return Spend;
                    break;
                case 10:
                    return ACoS;
                    break;
                case 11:
                    return RoAS;
                    break;
                case 12:
                    return Sales;
                    break;
                case 13:
                    return Orders;
                    break;
                case 14:
                    return Units;
                    break;
                case 15:
                    return ConversionRate;
                    break;
                case 16:
                    return NewToBrandOrders;
                    break;
                case 17:
                    return NewToBrandSales;
                    break;
                case 18:
                    return NewToBrandUnits;
                    break;
                case 19:
                    return NewToBrandOrderRate;
                    break;
                case 20:
                    return CampaignTypeId;
                    break;
                case 21:
                    return MarketPlaceId;
                    break;
                case 22:
                    return CampaignId;
                    break;
                case 23:
                    return ProductId1;
                    break;
                case 24:
                    return ProductId2;
                    break;
                case 25:
                    return ProductId3;
                    break;
                default:
                    return -1;
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
    }
}
