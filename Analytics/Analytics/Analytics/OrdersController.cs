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
        private List<OrdersModel> newOrdersList;
        private DataGridView dgv;

        public OrdersController()
        {
            connection = DBData.GetDBConnection();
            ordersList = new List<OrdersModel> { };
        }

        /* Вытаскиваем строки из Excel */
        public void GetOrdersFromExcel()
        {
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"C:\temp\orders.xlsx")))
            {
                ordersList = new List<OrdersModel> { };
                ExcelWorksheet workSheet = xlPackage.Workbook.Worksheets.First();
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;

                for (int row = start.Row + 1; row <= end.Row; row++)
                {
                    OrdersModel om = new OrdersModel();
                    ordersList.Add(om);

                    for (int col = start.Column; col <= end.Column; col++)
                    {
                        ordersList[ordersList.Count - 1].SetOrders(col - 1, workSheet.Cells[row, col].Text);
                    }
                }
            }
        }

        /* Заливаем все строки в БД */
        public void SetNewOrdersToDB()
        {
            string specifier = "G";
            string sqlStatement;
            connection.Open();

            for (int i = 0; i < ordersList.Count; i++)
            {
                sqlStatement = "INSERT INTO [Orders] ([AmazonOrderId], [MerchantOrderId], [PurchaseDate], [LastUpdatedDate], [OrderStatus], [FullfilmentChannel], [SalesChannel], [OrderChannel], [Url], [ShipServiceLevel], [ProductName], [Sku], [Asin], [ItemStatus], [Quantity], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ItemPromotionDiscount], [ShipPromotionDiscount], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [PromotionIds], [IsBusinessOrder], [PurchaseOrderNumber], [PriceDesignation]) VALUES ('" + ordersList[i].AmazonOrderId + "', '" + ordersList[i].MerchantOrderId + "', '" + ordersList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].LastUpdatedDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].OrderStatus + "', '" + ordersList[i].FullfilmentChannel + "', '" + ordersList[i].SalesChannel + "', '" + ordersList[i].OrderChannel + "', '" + ordersList[i].Url + "', '" + ordersList[i].ShipServiceLevel + "', '" + ordersList[i].ProductName + "', '" + ordersList[i].Sku + "', '" + ordersList[i].Asin + "', '" + ordersList[i].ItemStatus + "', " + ordersList[i].Quantity + ", '" + ordersList[i].Currency + "', " + ordersList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + ordersList[i].ShipCity + "', '" + ordersList[i].ShipState + "', '" + ordersList[i].ShipPostalCode + "', '" + ordersList[i].ShipCountry + "', '" + ordersList[i].PromotionIds + "', '" + ordersList[i].IsBusinessOrder + "', '" + ordersList[i].PurchaseOrderNumber + "', '" + ordersList[i].PriceDesignation + "')";

                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                }
                catch (Exception ex) { }
            }
            connection.Close();
        }

        /* Заливаем новые/обновляем старые строки в БД */
        public void UpdateOrdersInDB()
        {
            GetOrdersFromExcel();
            newOrdersList = new List<OrdersModel> { };

            string specifier = "G";
            string sqlStatement;
            connection.Open();

            for (int i = 0; i < ordersList.Count; i++)
            {
                sqlStatement = "INSERT INTO [Orders] ([AmazonOrderId], [MerchantOrderId], [PurchaseDate], [LastUpdatedDate], [OrderStatus], [FullfilmentChannel], [SalesChannel], [OrderChannel], [Url], [ShipServiceLevel], [ProductName], [Sku], [Asin], [ItemStatus], [Quantity], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ItemPromotionDiscount], [ShipPromotionDiscount], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [PromotionIds], [IsBusinessOrder], [PurchaseOrderNumber], [PriceDesignation]) VALUES ('" + ordersList[i].AmazonOrderId + "', '" + ordersList[i].MerchantOrderId + "', '" + ordersList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].LastUpdatedDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].OrderStatus + "', '" + ordersList[i].FullfilmentChannel + "', '" + ordersList[i].SalesChannel + "', '" + ordersList[i].OrderChannel + "', '" + ordersList[i].Url + "', '" + ordersList[i].ShipServiceLevel + "', '" + ordersList[i].ProductName + "', '" + ordersList[i].Sku + "', '" + ordersList[i].Asin + "', '" + ordersList[i].ItemStatus + "', " + ordersList[i].Quantity + ", '" + ordersList[i].Currency + "', " + ordersList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + ordersList[i].ShipCity + "', '" + ordersList[i].ShipState + "', '" + ordersList[i].ShipPostalCode + "', '" + ordersList[i].ShipCountry + "', '" + ordersList[i].PromotionIds + "', '" + ordersList[i].IsBusinessOrder + "', '" + ordersList[i].PurchaseOrderNumber + "', '" + ordersList[i].PriceDesignation + "')";

                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    OrdersModel om = new OrdersModel();
                    newOrdersList.Add(om);

                    for (int j = 0; j < om.FieldCount; j++)
                    {
                        newOrdersList[newOrdersList.Count - 1].SetOrdersForUpdate(j, ordersList[i].GetOrders(j));
                    }
                }
            }
            connection.Close();

            if (newOrdersList.Count > 0)
                UpdateExistingOrdersInDB();
        }

        /* Обновляем уже существующие строки в БД */
        private void UpdateExistingOrdersInDB()
        {
            string specifier = "G";
            string sqlStatement;
            connection.Open();

            for (int i = 0; i < newOrdersList.Count; i++)
            {
                sqlStatement = "UPDATE [Orders] SET [MerchantOrderId] = '" + newOrdersList[i].MerchantOrderId + "', [PurchaseDate] = '" + newOrdersList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', [LastUpdatedDate] = '" + newOrdersList[i].LastUpdatedDate.ToString("yyyy-MM-dd") + "', [OrderStatus] = '" + newOrdersList[i].OrderStatus + "', [FullfilmentChannel] = '" + newOrdersList[i].FullfilmentChannel + "', [SalesChannel] = '" + newOrdersList[i].SalesChannel + "', [OrderChannel] = '" + newOrdersList[i].OrderChannel + "', [Url] = '" + newOrdersList[i].Url + "', [ShipServiceLevel] = '" + newOrdersList[i].ShipServiceLevel + "', [ProductName] = '" + newOrdersList[i].ProductName + "', [Sku] = '" + newOrdersList[i].Sku + "', [Asin] = '" + newOrdersList[i].Asin + "', [ItemStatus] = '" + newOrdersList[i].ItemStatus + "', [Quantity] = '" + newOrdersList[i].Quantity + "', [Currency] = '" + newOrdersList[i].Currency + "', [ItemPrice] = " + newOrdersList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", [ItemTax] = " + newOrdersList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShippingPrice] = " + newOrdersList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShippingTax] = " + newOrdersList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", [GiftWrapPrice] = " + newOrdersList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", [GiftWrapTax] = " + newOrdersList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", [ItemPromotionDiscount] = " + newOrdersList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShipPromotionDiscount] = " + newOrdersList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShipCity] = '" + newOrdersList[i].ShipCity + "', [ShipState] = '" + newOrdersList[i].ShipState + "', [ShipPostalCode] = '" + newOrdersList[i].ShipPostalCode + "', [ShipCountry] = '" + newOrdersList[i].ShipCountry + "', [PromotionIds] = '" + newOrdersList[i].PromotionIds + "', [IsBusinessOrder] = '" + newOrdersList[i].IsBusinessOrder + "', [PurchaseOrderNumber] = '" + newOrdersList[i].PurchaseOrderNumber + "', [PriceDesignation] = '" + newOrdersList[i].PriceDesignation + "' WHERE [AmazonOrderId] = '" + newOrdersList[i].AmazonOrderId + "'";

                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                }
                catch (Exception ex) { }
            }
            connection.Close();
        }
    }
}
