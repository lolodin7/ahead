using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ReportDataAnalyzer
    {

        public ReportDataAnalyzer()
        {

        }

        /*  */
        public void SponsoredProductReport(string[] _columnsToAnalyze)
        {
            int columnCount = 23;
            string[] reportColumns = new string[columnCount];

            reportColumns[0] = "Start Date";
            reportColumns[1] = "End Date";
            reportColumns[2] = "Portfolio name";
            reportColumns[3] = "Currency";
            reportColumns[4] = "Campaign Name";
            reportColumns[5] = "Ad Group Name";
            reportColumns[6] = "Advertised SKU";
            reportColumns[7] = "Advertised ASIN";
            reportColumns[8] = "Impressions";
            reportColumns[9] = "Clicks";
            reportColumns[10] = "Click-Thru Rate (CTR)";
            reportColumns[11] = "Cost Per Click (CPC)";
            reportColumns[12] = "Spend";
            reportColumns[13] = "7 Day Total Sales";
            reportColumns[14] = "Total Advertising Cost of Sales (ACoS)";
            reportColumns[15] = "Total Return on Advertising Spend (RoAS)";
            reportColumns[16] = "7 Day Total Orders (#)";
            reportColumns[17] = "7 Day Total Units (#)";
            reportColumns[18] = "7 Day Conversion Rate";
            reportColumns[19] = "7 Day Advertised SKU Units (#)";
            reportColumns[20] = "7 Day Other SKU Units (#)";
            reportColumns[21] = "7 Day Advertised SKU Sales";
            reportColumns[22] = "7 Day Other SKU Sales";

            AnalyzeColumns(reportColumns, _columnsToAnalyze);
        }

        /*  */
        public void SponsoredBrandReport(string[] _columnsToAnalyze)
        {
            int columnCount = 25;
            string[] reportColumns = new string[columnCount];

            reportColumns[0] = "Start Date";
            reportColumns[1] = "End Date";
            reportColumns[2] = "Portfolio name";
            reportColumns[3] = "Currency";
            reportColumns[4] = "Campaign Name";
            reportColumns[5] = "Targeting";
            reportColumns[6] = "Match Type";
            reportColumns[7] = "Impressions";
            reportColumns[8] = "Clicks";
            reportColumns[9] = "Click-Thru Rate (CTR)";
            reportColumns[10] = "Cost Per Click (CPC)";
            reportColumns[11] = "Spend";
            reportColumns[12] = "Total Advertising Cost of Sales (ACoS)";
            reportColumns[13] = "Total Return on Advertising Spend (RoAS)";
            reportColumns[14] = "14 Day Total Sales";
            reportColumns[15] = "14 Day Total Orders (#)";
            reportColumns[16] = "14 Day Total Units (#)";
            reportColumns[17] = "14 Day Conversion Rate";
            reportColumns[18] = "14 Day New-to-brand Orders (#)";
            reportColumns[19] = "14 Day % of Orders New-to-brand";
            reportColumns[20] = "14 Day New-to-brand Sales";
            reportColumns[21] = "14 Day % of Sales New-to-brand";
            reportColumns[22] = "14 Day New-to-brand Units (#)";
            reportColumns[23] = "14 Day % of Units New-to-brand";
            reportColumns[24] = "14 Day New-to-brand Order Rate";

            AnalyzeColumns(reportColumns, _columnsToAnalyze);
        }

        /* Анализ Business Report */
        public void BusinessReport(string[] _columnsToAnalyze)
        {
            int columnCount = 17;
            string[] reportColumns = new string[columnCount];

            reportColumns[0] = "(Parent) ASIN";
            reportColumns[1] = "(Child) ASIN";
            reportColumns[2] = "Title";
            reportColumns[3] = "SKU";
            reportColumns[4] = "Sessions";
            reportColumns[5] = "Session Percentage";
            reportColumns[6] = "Page Views";
            reportColumns[7] = "Page Views Percentage";
            reportColumns[8] = "Buy Box Percentage";
            reportColumns[9] = "Units Ordered";
            reportColumns[10] = "Units Ordered - B2B";
            reportColumns[11] = "Unit Session Percentage";
            reportColumns[12] = "Unit Session Percentage - B2B";
            reportColumns[13] = "Ordered Product Sales";
            reportColumns[14] = "Ordered Product Sales - B2B";
            reportColumns[15] = "Total Order Items";
            reportColumns[16] = "Total Order Items - B2B";

            AnalyzeColumns(reportColumns, _columnsToAnalyze);
        }

        /* Анализ FBA customer returns */
        public void ReturnsReport(string[] _columnsToAnalyze)
        {
            int columnCount = 13;
            string[] reportColumns = new string[columnCount];

            reportColumns[0] = "return-date";
            reportColumns[1] = "order-id";
            reportColumns[2] = "sku";
            reportColumns[3] = "asin";
            reportColumns[4] = "fnsku";
            reportColumns[5] = "product-name";
            reportColumns[6] = "quantity";
            reportColumns[7] = "fulfillment-center-id";
            reportColumns[8] = "detailed-disposition";
            reportColumns[9] = "reason";
            reportColumns[10] = "status";
            reportColumns[11] = "license-plate-number";
            reportColumns[12] = "customer-comments";

            AnalyzeColumns(reportColumns, _columnsToAnalyze);
        }

        /* Анализатор */
        private void AnalyzeColumns(string[] _reportColumns, string[] _columnsToAnalyze)
        {
            for (int i = 0; i < _reportColumns.Length; i++)
            {

            }

        }
    }
}
