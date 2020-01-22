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
                    MarketPlaceId = GetInt(record);
                    break;
                case 2:
                    SKU = record.ToString();
                    break;
                case 3:
                    Sessions = GetInt(record);
                    break;
                case 4:
                    SessionPercentage = GetDoubleFromPrecentage(record);
                    break;
                case 5:
                    PageViews = GetInt(record);
                    break;
                case 6:
                    PageViewsPercentage = GetDoubleFromPrecentage(record);
                    break;
                case 8:
                    UnitsOrdered = GetInt(record);
                    break;
                case 9:
                    UnitsOrderedB2B = GetInt(record);
                    break;
                case 10:
                    UnitSessionPercentage = GetDoubleFromPrecentage(record);
                    break;
                case 11:
                    UnitSessionPercentageB2B = GetDoubleFromPrecentage(record);
                    break;
                case 12:
                    OrderedProductSales = GetDouble(record);
                    break;
                case 13:
                    OrderedProductSalesB2B = GetDouble(record);
                    break;
                case 14:
                    TotalOrderItems = GetInt(record);
                    break;
                case 15:
                    TotalOrderItemsB2B = GetInt(record);
                    break;
                case 16:
                    ProductId = GetInt(record);
                    break;
            }
        }


        public void WriteDataFromDB(int index, object record)
        {
            switch (index)
            {
                case 0:
                    UpdateDate = (DateTime)record;
                    break;
                case 1:
                    MarketPlaceId = GetInt(record);
                    break;
                case 2:
                    SKU = record.ToString();
                    break;
                case 3:
                    Sessions = GetInt(record);
                    break;
                case 4:
                    SessionPercentage = GetDoubleFromPrecentage(record);
                    break;
                case 5:
                    PageViews = GetInt(record);
                    break;
                case 6:
                    PageViewsPercentage = GetDoubleFromPrecentage(record);
                    break;
                case 7:
                    UnitsOrdered = GetInt(record);
                    break;
                case 8:
                    UnitsOrderedB2B = GetInt(record);
                    break;
                case 9:
                    UnitSessionPercentage = GetDoubleFromPrecentage(record);
                    break;
                case 10:
                    UnitSessionPercentageB2B = GetDoubleFromPrecentage(record);
                    break;
                case 11:
                    OrderedProductSales = GetDouble(record);
                    break;
                case 12:
                    OrderedProductSalesB2B = GetDouble(record);
                    break;
                case 13:
                    TotalOrderItems = GetInt(record);
                    break;
                case 14:
                    TotalOrderItemsB2B = GetInt(record);
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
                    return MarketPlaceId;
                    break;
                case 2:
                    return SKU;
                    break;
                case 3:
                    return Sessions;
                    break;
                case 4:
                    return SessionPercentage;
                    break;
                case 5:
                    return PageViews;
                    break;
                case 6:
                    return PageViewsPercentage;
                    break;
                case 7:
                    return UnitsOrdered;
                    break;
                case 8:
                    return UnitsOrderedB2B;
                    break;
                case 9:
                    return UnitSessionPercentage;
                    break;
                case 10:
                    return UnitSessionPercentageB2B;
                    break;
                case 11:
                    return OrderedProductSales;
                    break;
                case 12:
                    return OrderedProductSalesB2B;
                    break;
                case 13:
                    return TotalOrderItems;
                    break;
                case 14:
                    return TotalOrderItemsB2B;
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
                    int op = s.IndexOf('$');
                    string str = s.Substring(op + 1, s.Length - op - 1);
                    _amount = double.Parse(str, CultureInfo.InvariantCulture);
                }
            }
            else
                _amount = 0;
            return _amount;
        }

        private double GetDoubleFromPrecentage(object _value)
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
                    string str = s.Substring(0, s.Length - 1);
                    _amount = double.Parse(str, CultureInfo.InvariantCulture);
                }
            }
            else
                _amount = 0;
            return _amount;
        }
    }
}
