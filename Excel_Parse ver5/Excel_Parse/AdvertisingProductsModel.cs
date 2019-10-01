using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class AdvertisingProductsModel
    {
        public DateTime UpdateDate { get; set; }
        public string CurrencyCharCode { get; set; }
        public string CampaignName { get; set; }
        public string AdGroupName { get; set; }
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
        public int AdvSKUUnits { get; set; }
        public int OtherSKUUnits { get; set; }
        public double AdvSKUSales { get; set; }
        public double OtherSKUSales { get; set; }
        public int CampaignTypeId { get; set; }
        public int MarketPlaceId { get; set; }
        public int CampaignId { get; set; }
        public int ProductId { get; set; }

        public int ColumnCount { get; }

        public AdvertisingProductsModel()
        {
            ColumnCount = 25;
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
                    AdGroupName = record.ToString();
                    break;
                case 4:
                    Targeting = record.ToString();
                    break;
                case 5:
                    MatchType = record.ToString();
                    break;
                case 6:
                    Impressions = int.Parse(record.ToString());
                    break;
                case 7:
                    Clicks = int.Parse(record.ToString());
                    break;
                case 8:
                    CTR = GetDouble(record);
                    break;
                case 9:
                    CPC = GetDouble(record);
                    break;
                case 10:
                    Spend = GetDouble(record);
                    break;
                case 11:
                    Sales = GetDouble(record);
                    break;
                case 12:
                    ACoS = GetDouble(record);
                    break;
                case 13:
                    RoAS = GetDouble(record);
                    break;
                case 14:
                    Orders = int.Parse(record.ToString());
                    break;
                case 15:
                    Units = int.Parse(record.ToString());
                    break;
                case 16:
                    ConversionRate = GetDouble(record);
                    break;
                case 17:
                    AdvSKUUnits = int.Parse(record.ToString());
                    break;
                case 18:
                    OtherSKUUnits = int.Parse(record.ToString());
                    break;
                case 19:
                    AdvSKUSales = GetDouble(record);
                    break;
                case 20:
                    OtherSKUSales = GetDouble(record);
                    break;
                case 21:
                    CampaignTypeId = int.Parse(record.ToString());
                    break;
                case 22:
                    MarketPlaceId = int.Parse(record.ToString());
                    break;
                case 23:
                    CampaignId = int.Parse(record.ToString());
                    break;
                case 24:
                    ProductId = int.Parse(record.ToString());
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
                    return AdGroupName;
                    break;
                case 4:
                    return Targeting;
                    break;
                case 5:
                    return MatchType;
                    break;
                case 6:
                    return Impressions;
                    break;
                case 7:
                    return Clicks;
                    break;
                case 8:
                    return CTR;
                    break;
                case 9:
                    return CPC;
                    break;
                case 10:
                    return Spend;
                    break;
                case 11:
                    return Sales;
                    break;
                case 12:
                    return ACoS;
                    break;
                case 13:
                    return RoAS;
                    break;
                case 14:
                    return Orders;
                    break;
                case 15:
                    return Units;
                    break;
                case 16:
                    return ConversionRate;
                    break;
                case 17:
                    return AdvSKUUnits;
                    break;
                case 18:
                    return OtherSKUUnits;
                    break;
                case 19:
                    return AdvSKUSales;
                    break;
                case 20:
                    return OtherSKUSales;
                    break;
                case 21:
                    return CampaignTypeId;
                    break;
                case 22:
                    return MarketPlaceId;
                    break;
                case 23:
                    return CampaignId;
                    break;
                case 24:
                    return ProductId;
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
