using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ReportBusinessModel
    {
        public DateTime UpdateDate { get; set; }
        public string SKU { get; set; }
        public int Sessions { get; set; }
        public double SessionPercentage { get; set; }
        public int PageViews { get; set; }
        public double PageViewsPercentage { get; set; }
        public int UnitsOrdered { get; set; }
        public int UnitsOrderedB2B { get; set; }
        public double UnitSessionPercentage { get; set; }
        public double UnitSessionPercentageB2B { get; set; }
        public double OrderedProductSales { get; set; }
        public double OrderedProductSalesB2B { get; set; } 
        public int TotalOrderItems { get; set; }
        public int TotalOrderItemsB2B { get; set; }
        public int MarketPlaceId { get; set; }
        public int ProductId { get; set; }

        public int ColumnCount { get; }


        public ReportBusinessModel()
        {
            ColumnCount = 16;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    UpdateDate = (DateTime)record;
                    break;
                case 1:
                    SKU = record.ToString();
                    break;
                case 2:
                    Sessions = GetInt(record);
                    break;
                case 3:
                    SessionPercentage = GetDouble(record);
                    break;
                case 4:
                    PageViews = GetInt(record);
                    break;
                case 5:
                    PageViewsPercentage = GetDouble(record);
                    break;
                case 6:
                    UnitsOrdered = GetInt(record);
                    break;
                case 7:
                    UnitsOrderedB2B = GetInt(record);
                    break;
                case 8:
                    UnitSessionPercentage = GetDouble(record);
                    break;
                case 9:
                    UnitSessionPercentageB2B = GetDouble(record);
                    break;
                case 10:
                    OrderedProductSales = GetDouble(record);
                    break;
                case 11:
                    OrderedProductSalesB2B = GetDouble(record);
                    break;
                case 12:
                    TotalOrderItems = GetInt(record);
                    break;
                case 13:
                    TotalOrderItemsB2B = GetInt(record);
                    break;
                case 14:
                    MarketPlaceId = GetInt(record);
                    break;
                case 15:
                    ProductId = GetInt(record);
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
                    return SKU;
                    break;
                case 2:
                    return Sessions;
                    break;
                case 3:
                    return SessionPercentage;
                    break;
                case 4:
                    return PageViews;
                    break;
                case 5:
                    return PageViewsPercentage;
                    break;
                case 6:
                    return UnitsOrdered;
                    break;
                case 7:
                    return UnitsOrderedB2B;
                    break;
                case 8:
                    return UnitSessionPercentage;
                    break;
                case 9:
                    return UnitSessionPercentageB2B;
                    break;
                case 10:
                    return OrderedProductSales;
                    break;
                case 11:
                    return OrderedProductSalesB2B;
                    break;
                case 12:
                    return TotalOrderItems;
                    break;
                case 13:
                    return TotalOrderItemsB2B;
                    break;
                case 14:
                    return MarketPlaceId;
                    break;
                case 15:
                    return ProductId;
                    break;
                default:
                    return -1;
                    break;
            }
        }

        private int GetInt(object _value)
        {
            int _amount = 0;
            if (!_value.ToString().Equals(""))
            {
                try
                {
                    _amount = int.Parse(_value.ToString());
                }
                catch (Exception ex)
                {
                    string s = _value.ToString();
                    int ind = s.IndexOf(',');
                    string str = s.Remove(ind, 1);
                    _amount = int.Parse(str);
                }
            }
            else
                _amount = 0;
            return _amount;
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
