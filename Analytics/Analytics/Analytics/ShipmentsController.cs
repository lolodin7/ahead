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

        public ShipmentsController()
        {
            connection = DBData.GetDBConnection();
            shipmentsList = new List<ShipmentsModel> { };
        }


        /* Вытаскиваем строки из Excel */
        public void GetShipmentsFromExcel(DataGridView dgv)
        {
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"C:\temp\shipments.xlsx")))
            {
                ExcelWorksheet workSheet = xlPackage.Workbook.Worksheets.First();
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int rowcntreal = 0;
                for (int row = start.Row + 1; row <= end.Row; row++)
                //for (int row = 28; row <= 32; row++)
                {
                    ShipmentsModel sm = new ShipmentsModel();
                    shipmentsList.Add(sm);
                    var index = dgv.Rows.Add();
                    for (int col = start.Column; col <= end.Column; col++)
                    {
                        shipmentsList[shipmentsList.Count - 1].SetShipments(col - 1, workSheet.Cells[row, col].Text);
                        dgv.Rows[index].Cells[col - 1].Value = shipmentsList[shipmentsList.Count - 1].GetShipments(col - 1);
                    }
                    rowcntreal++;
                }

                sw.Stop();
                MessageBox.Show((sw.ElapsedMilliseconds / 1000.0).ToString() + "   строк: " + rowcntreal);
            }
        }

        /* Заливаем все строки в БД */
        public void SetShipmentsToDB()
        {
            string specifier = "G";
            string sqlStatement;
            connection.Open();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < shipmentsList.Count; i++)
            {
                sqlStatement = "INSERT INTO[Shipments] ([AmazonOrderId], [MerchantOrderId], [ShipmentId], [ShipmentItemId], [AmazonOrderItemId], [MerchantOrderItemId], [PurchaseDate], [PaymentsDate], [ShipmentDate], [ReportingDate], [BuyerEmail], [BuyerName], [BuyerPhoneNumber], [Sku], [ProductName], [QuantityShipped], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ShipServiceLevel], [RecipientName], [ShipAddress1], [ShipAddress2], [ShipAddress3], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [ShipPhoneNumber], [BillAddress1], [BillAddress2], [BillAddress3], [BillCity], [BillState], [BillPostalCode], [BillCountry], [ItemPromotionDiscount], [ShipPromotionDiscount], [Carrier], [TrackingNumber], [EstimatedArrivalDate], [FullfilmentCenterId], [FullfilmentChannel], [SalesChannel]) VALUES ('" + shipmentsList[i].AmazonOrderId + "', '" + shipmentsList[i].MerchantOrderId + "','" + shipmentsList[i].ShipmentId + "', '" + shipmentsList[i].ShipmentItemId + "', '" + shipmentsList[i].AmazonOrderItemId + "', '" + shipmentsList[i].MerchantOrderItemId + "', '" + shipmentsList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].PaymentsDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].ShipmentDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].ReportingDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].BuyerEmail + "', '" + shipmentsList[i].BuyerName + "', '" + shipmentsList[i].BuyerPhoneNumber + "', '" + shipmentsList[i].Sku + "', '" + shipmentsList[i].ProductName + "', " + shipmentsList[i].QuantityShipped + ", '" + shipmentsList[i].Currency + "', " + shipmentsList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + shipmentsList[i].ShipServiceLevel + "', '" + shipmentsList[i].RecipientName + "', '" + shipmentsList[i].ShipAddress1 + "', '" + shipmentsList[i].ShipAddress2 + "', '" + shipmentsList[i].ShipAddress3 + "', '" + shipmentsList[i].ShipCity + "', '" + shipmentsList[i].ShipState + "', '" + shipmentsList[i].ShipPostalCode + "', '" + shipmentsList[i].ShipCountry + "', '" + shipmentsList[i].ShipPhoneNumber + "', '" + shipmentsList[i].BillAddress1 + "', '" + shipmentsList[i].BillAddress2 + "', '" + shipmentsList[i].BillAddress3 + "', '" + shipmentsList[i].BillCity + "', '" + shipmentsList[i].BillState + "', '" + shipmentsList[i].BillPostalCode + "', '" + shipmentsList[i].BillCountry + "', " + shipmentsList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + shipmentsList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + shipmentsList[i].Carrier + "', '" + shipmentsList[i].TrackingNumber + "', '" + shipmentsList[i].EstimatedArrivalDate.ToString("yyyy-MM-dd") + "', '" + shipmentsList[i].FullfilmentCenterId + "', '" + shipmentsList[i].FullfilmentChannel + "', '" + shipmentsList[i].SalesChannel + "')";
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.ExecuteScalar();
            }
            connection.Close();
            sw.Stop();
            MessageBox.Show((sw.ElapsedMilliseconds / 1000.0).ToString());
        }
    }
}
