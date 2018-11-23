using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analytics
{
    class OrdersController
    {
        private SqlConnection connection;
        private List<OrdersModel> ordersList;
        private DataGridView dgv;

        public OrdersController(DataGridView _dgv)
        {
            connection = DBData.GetDBConnection();
            ordersList = new List<OrdersModel> { };
            dgv = _dgv;
        }

        /* Вытаскиваем строки из Excel */
        public void GetOrdersFromExcel()
        {
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"C:\temp\orders.xlsx")))
            {
                ExcelWorksheet workSheet = xlPackage.Workbook.Worksheets.First();
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int row = start.Row + 1; row <= end.Row; row++)
                //for (int row = 28; row <= 32; row++)
                {
                    OrdersModel om = new OrdersModel();
                    ordersList.Add(om);
                    var index = dgv.Rows.Add();
                    for (int col = start.Column; col <= end.Column; col++)
                    {
                        ordersList[ordersList.Count - 1].SetOrders(col - 1, workSheet.Cells[row, col].Text);
                        dgv.Rows[index].Cells[col - 1].Value = ordersList[ordersList.Count - 1].GetOrders(col - 1);
                    }
                }

                sw.Stop();
                MessageBox.Show((sw.ElapsedMilliseconds / 1000.0).ToString() + "   строк: " + end.Row);
            }
        }

        /* Заливаем все строки в БД */
        public void SetOrdersToDB()
        {
            string specifier = "G";
            string sqlStatement;
            connection.Open();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < ordersList.Count; i++)
            {
                sqlStatement = "INSERT INTO [Orders] ([AmazonOrderId], [MerchantOrderId], [PurchaseDate], [LastUpdatedDate], [OrderStatus], [FullfilmentChannel], [SalesChannel], [OrderChannel], [Url], [ShipServiceLevel], [ProductName], [Sku], [Asin], [ItemStatus], [Quantity], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ItemPromotionDiscount], [ShipPromotionDiscount], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [PromotionIds], [IsBusinessOrder], [PurchaseOrderNumber], [PriceDesignation]) VALUES ('" + ordersList[i].AmazonOrderId + "', '" + ordersList[i].MerchantOrderId + "', '" + ordersList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].LastUpdatedDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].OrderStatus + "', '" + ordersList[i].FullfilmentChannel + "', '" + ordersList[i].SalesChannel + "', '" + ordersList[i].OrderChannel + "', '" + ordersList[i].Url + "', '" + ordersList[i].ShipServiceLevel + "', '" + ordersList[i].ProductName + "', '" + ordersList[i].Sku + "', '" + ordersList[i].Asin + "', '" + ordersList[i].ItemStatus + "', " + ordersList[i].Quantity + ", '" + ordersList[i].Currency + "', " + ordersList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + ordersList[i].ShipCity + "', '" + ordersList[i].ShipState + "', '" + ordersList[i].ShipPostalCode + "', '" + ordersList[i].ShipCountry + "', '" + ordersList[i].PromotionIds + "', '" + ordersList[i].IsBusinessOrder + "', '" + ordersList[i].PurchaseOrderNumber + "', '" + ordersList[i].PriceDesignation + "')";
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.ExecuteScalar();
            }
            connection.Close();
            sw.Stop();
            MessageBox.Show((sw.ElapsedMilliseconds / 1000.0).ToString());
        }
    }
}
