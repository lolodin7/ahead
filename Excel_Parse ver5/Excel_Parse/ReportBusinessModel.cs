using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ReportBusinessModel
    {
        public int MarketPlaceId { get; set; }
        public int SKU { get; set; }
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

        public int ColumnCount { get; }


        public ReportBusinessModel()
        {
            ColumnCount = 14;
        }
    }
}
