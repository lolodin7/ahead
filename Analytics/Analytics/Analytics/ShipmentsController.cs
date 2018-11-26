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
    class ShipmentsController
    {
        private SqlConnection connection;
        private List<ShipmentsModel> shipmentsList;
        private List<ShipmentsModel> newShipmentsList;

        public ShipmentsController()
        {
            connection = DBData.GetDBConnection();
            shipmentsList = new List<ShipmentsModel> { };
        }


        /* Вытаскиваем строки из Excel */
        public void GetShipmentsFromExcel()
        {
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"C:\temp\shipments.xlsx")))
            {
                shipmentsList = new List<ShipmentsModel> { };
                ExcelWorksheet workSheet = xlPackage.Workbook.Worksheets.First();
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;
                
                for (int row = start.Row + 1; row <= end.Row; row++)
                {
                    ShipmentsModel sm = new ShipmentsModel();
                    shipmentsList.Add(sm);
                    for (int col = start.Column; col <= end.Column; col++)
                    {
                        shipmentsList[shipmentsList.Count - 1].SetShipments(col - 1, workSheet.Cells[row, col].Text);
                    }
                }
            }
        }

        /* Заливаем все строки в БД */
        public void SetNewShipmentsToDB()
        {
            string specifier = "G";
            string sqlStatement;
            connection.Open();

            for (int i = 0; i < shipmentsList.Count; i++)
            {
                sqlStatement = "INSERT INTO[Shipments] ([AmazonOrderId], [MerchantOrderId], [ShipmentId], [ShipmentItemId], [AmazonOrderItemId], [MerchantOrderItemId], [PurchaseDate], [PaymentsDate], [ShipmentDate], [ReportingDate], [BuyerEmail], [BuyerName], [BuyerPhoneNumber], [Sku], [ProductName], [QuantityShipped], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ShipServiceLevel], [RecipientName], [ShipAddress1], [ShipAddress2], [ShipAddress3], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [ShipPhoneNumber], [BillAddress1], [BillAddress2], [BillAddress3], [BillCity], [BillState], [BillPostalCode], [BillCountry], [ItemPromotionDiscount], [ShipPromotionDiscount], [Carrier], [TrackingNumber], [EstimatedArrivalDate], [FullfilmentCenterId], [FullfilmentChannel], [SalesChannel]) VALUES ('" + shipmentsList[i].AmazonOrderId + "', '" + shipmentsList[i].MerchantOrderId + "','" + shipmentsList[i].ShipmentId + "', '" + shipmentsList[i].ShipmentItemId + "', '" + shipmentsList[i].AmazonOrderItemId + "', '" + shipmentsList[i].MerchantOrderItemId + "', '" + shipmentsList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].PaymentsDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].ShipmentDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].ReportingDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].BuyerEmail + "', '" + shipmentsList[i].BuyerName + "', '" + shipmentsList[i].BuyerPhoneNumber + "', '" + shipmentsList[i].Sku + "', '" + shipmentsList[i].ProductName + "', " + shipmentsList[i].QuantityShipped + ", '" + shipmentsList[i].Currency + "', " + shipmentsList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + shipmentsList[i].ShipServiceLevel + "', '" + shipmentsList[i].RecipientName + "', '" + shipmentsList[i].ShipAddress1 + "', '" + shipmentsList[i].ShipAddress2 + "', '" + shipmentsList[i].ShipAddress3 + "', '" + shipmentsList[i].ShipCity + "', '" + shipmentsList[i].ShipState + "', '" + shipmentsList[i].ShipPostalCode + "', '" + shipmentsList[i].ShipCountry + "', '" + shipmentsList[i].ShipPhoneNumber + "', '" + shipmentsList[i].BillAddress1 + "', '" + shipmentsList[i].BillAddress2 + "', '" + shipmentsList[i].BillAddress3 + "', '" + shipmentsList[i].BillCity + "', '" + shipmentsList[i].BillState + "', '" + shipmentsList[i].BillPostalCode + "', '" + shipmentsList[i].BillCountry + "', " + shipmentsList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + shipmentsList[i].Carrier + "', '" + shipmentsList[i].TrackingNumber + "', '" + shipmentsList[i].EstimatedArrivalDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].FullfilmentCenterId + "', '" + shipmentsList[i].FullfilmentChannel + "', '" + shipmentsList[i].SalesChannel + "')";
                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                }
                catch (Exception ex) { }
            }
        }

        public void UpdateShipmentsInDB()
        {
            GetShipmentsFromExcel();
            newShipmentsList = new List<ShipmentsModel> { };

            string specifier = "G";
            string sqlStatement;
            connection.Open();

            for (int i = 0; i < shipmentsList.Count; i++)
            {
                sqlStatement = "INSERT INTO[Shipments] ([AmazonOrderId], [MerchantOrderId], [ShipmentId], [ShipmentItemId], [AmazonOrderItemId], [MerchantOrderItemId], [PurchaseDate], [PaymentsDate], [ShipmentDate], [ReportingDate], [BuyerEmail], [BuyerName], [BuyerPhoneNumber], [Sku], [ProductName], [QuantityShipped], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ShipServiceLevel], [RecipientName], [ShipAddress1], [ShipAddress2], [ShipAddress3], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [ShipPhoneNumber], [BillAddress1], [BillAddress2], [BillAddress3], [BillCity], [BillState], [BillPostalCode], [BillCountry], [ItemPromotionDiscount], [ShipPromotionDiscount], [Carrier], [TrackingNumber], [EstimatedArrivalDate], [FullfilmentCenterId], [FullfilmentChannel], [SalesChannel]) VALUES ('" + shipmentsList[i].AmazonOrderId + "', '" + shipmentsList[i].MerchantOrderId + "','" + shipmentsList[i].ShipmentId + "', '" + shipmentsList[i].ShipmentItemId + "', '" + shipmentsList[i].AmazonOrderItemId + "', '" + shipmentsList[i].MerchantOrderItemId + "', '" + shipmentsList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].PaymentsDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].ShipmentDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].ReportingDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].BuyerEmail + "', '" + shipmentsList[i].BuyerName + "', '" + shipmentsList[i].BuyerPhoneNumber + "', '" + shipmentsList[i].Sku + "', '" + shipmentsList[i].ProductName + "', " + shipmentsList[i].QuantityShipped + ", '" + shipmentsList[i].Currency + "', " + shipmentsList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + shipmentsList[i].ShipServiceLevel + "', '" + shipmentsList[i].RecipientName + "', '" + shipmentsList[i].ShipAddress1 + "', '" + shipmentsList[i].ShipAddress2 + "', '" + shipmentsList[i].ShipAddress3 + "', '" + shipmentsList[i].ShipCity + "', '" + shipmentsList[i].ShipState + "', '" + shipmentsList[i].ShipPostalCode + "', '" + shipmentsList[i].ShipCountry + "', '" + shipmentsList[i].ShipPhoneNumber + "', '" + shipmentsList[i].BillAddress1 + "', '" + shipmentsList[i].BillAddress2 + "', '" + shipmentsList[i].BillAddress3 + "', '" + shipmentsList[i].BillCity + "', '" + shipmentsList[i].BillState + "', '" + shipmentsList[i].BillPostalCode + "', '" + shipmentsList[i].BillCountry + "', " + shipmentsList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + shipmentsList[i].Carrier + "', '" + shipmentsList[i].TrackingNumber + "', '" + shipmentsList[i].EstimatedArrivalDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].FullfilmentCenterId + "', '" + shipmentsList[i].FullfilmentChannel + "', '" + shipmentsList[i].SalesChannel + "')";

                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();

                } catch (Exception ex)
                {
                    ShipmentsModel sm = new ShipmentsModel();
                    newShipmentsList.Add(sm);

                    for (int j = 0; j < sm.FieldCount; j++)
                    {
                        newShipmentsList[newShipmentsList.Count - 1].SetShipmentsForUpdate(j, shipmentsList[i].GetShipments(j));
                    }
                }
            }
            connection.Close();

            if (newShipmentsList.Count > 0)
                UpdateExistingShipmentsInDB();
        }

        private void UpdateExistingShipmentsInDB()
        {
            string specifier = "G";
            string sqlStatement;
            connection.Open();

            for (int i = 0; i < newShipmentsList.Count; i++)
            {
                sqlStatement = "UPDATE [Shipments] SET [MerchantOrderId] = '" + newShipmentsList[i].MerchantOrderId + "', [ShipmentId] = '" + newShipmentsList[i].ShipmentId + "', [ShipmentItemId] = '" + newShipmentsList[i].ShipmentItemId + "', [AmazonOrderItemId] = '" + newShipmentsList[i].AmazonOrderItemId + "', [MerchantOrderItemId] = '" + newShipmentsList[i].MerchantOrderItemId + "', [PurchaseDate] = '" + newShipmentsList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', [PaymentsDate] = '" + newShipmentsList[i].PaymentsDate.ToString("yyyy-MM-dd") + "', [ShipmentDate] = '" + newShipmentsList[i].ShipmentDate.ToString("yyyy-MM-dd") + "', [ReportingDate] = '" + newShipmentsList[i].ReportingDate.ToString("yyyy-MM-dd") + "', [BuyerEmail] = '" + newShipmentsList[i].BuyerEmail + "', [BuyerName] = '" + newShipmentsList[i].BuyerName + "', [BuyerPhoneNumber] = '" + newShipmentsList[i].BuyerPhoneNumber + "', [Sku] = '" + newShipmentsList[i].Sku + "', [ProductName] = '" + newShipmentsList[i].ProductName + "', [QuantityShipped] = " + newShipmentsList[i].QuantityShipped + ", [Currency] = '" + newShipmentsList[i].Currency + "', [ItemPrice] = " + newShipmentsList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", [ItemTax] = " + newShipmentsList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShippingPrice] = " + newShipmentsList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShippingTax] = " + newShipmentsList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", [GiftWrapPrice] = " + newShipmentsList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", [GiftWrapTax] = " + newShipmentsList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShipServiceLevel] = '" + newShipmentsList[i].ShipServiceLevel + "', [RecipientName] = '" + newShipmentsList[i].RecipientName + "', [ShipAddress1] = '" + newShipmentsList[i].ShipAddress1 + "', [ShipAddress2] = '" + newShipmentsList[i].ShipAddress2 + "', [ShipAddress3] = '" + newShipmentsList[i].ShipAddress3 + "', [ShipCity] = '" + newShipmentsList[i].ShipCity + "', [ShipState] = '" + newShipmentsList[i].ShipState + "', [ShipPostalCode] = '" + newShipmentsList[i].ShipPostalCode + "', [ShipCountry] = '" + newShipmentsList[i].ShipCountry + "', [ShipPhoneNumber] = '" + newShipmentsList[i].ShipPhoneNumber + "', [BillAddress1] = '" + newShipmentsList[i].BillAddress1 + "', [BillAddress2] = '" + newShipmentsList[i].BillAddress2 + "', [BillAddress3] = '" + newShipmentsList[i].BillAddress3 + "', [BillCity] = '" + newShipmentsList[i].BillCity + "', [BillState] = '" + newShipmentsList[i].BillState + "', [BillPostalCode] = '" + newShipmentsList[i].BillPostalCode + "', [BillCountry] = '" + newShipmentsList[i].BillCountry + "', [ItemPromotionDiscount] = " + newShipmentsList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShipPromotionDiscount] = " + newShipmentsList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", [Carrier] = '" + newShipmentsList[i].Carrier + "', [TrackingNumber] = '" + newShipmentsList[i].TrackingNumber + "', [EstimatedArrivalDate] = '" + newShipmentsList[i].EstimatedArrivalDate.ToString("yyyy-MM-dd") + "', [FullfilmentCenterId] = '" + newShipmentsList[i].FullfilmentCenterId + "', [FullfilmentChannel] = '" + newShipmentsList[i].FullfilmentChannel + "', [SalesChannel] = '" + newShipmentsList[i].SalesChannel + "' WHERE [AmazonOrderId] = '" + newShipmentsList[i].AmazonOrderId + "'";

                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                } catch (Exception ex) { }
            }
            connection.Close();
        }
    }
}
