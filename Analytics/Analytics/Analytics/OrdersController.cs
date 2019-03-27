using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
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
        private int allLines;
        private int addedLines;
        private int updatedLines;
        private AnalyticsForm form1;
        private MatchOrderRefund form2;
        private Matching form3;
        private SqlCommand command;


        public OrdersController(AnalyticsForm _form1)
        {
            connection = DBData.GetDBConnection();
            ordersList = new List<OrdersModel> { };
            allLines = 0;
            addedLines = 0;
            updatedLines = 0;

            form1 = _form1;
        }

        public OrdersController(Matching _form1)
        {
            connection = DBData.GetDBConnection();
            ordersList = new List<OrdersModel> { };
            allLines = 0;
            addedLines = 0;
            updatedLines = 0;

            form3 = _form1;
        }

        public OrdersController(MatchOrderRefund _form2)
        {
            connection = DBData.GetDBConnection();
            ordersList = new List<OrdersModel> { };
            allLines = 0;
            addedLines = 0;
            updatedLines = 0;

            form2 = _form2;
        }

        /* Вытаскиваем строки из Excel */
        public void GetOrdersFromExcel(bool update)
        {
            form1.openFileDialog1.Filter = "Выбери файл|*.csv;*.txt;*.xlsx";
            form1.openFileDialog1.Title = "Выбор файла для открытия";
            
            if (form1.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@form1.openFileDialog1.FileName)))
                {
                    ordersList = new List<OrdersModel> { };
                    allLines = 0;
                    addedLines = 0;
                    updatedLines = 0;
                    
                    ExcelWorksheet workSheet = xlPackage.Workbook.Worksheets.First();
                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    OrdersModel checkFields = new OrdersModel();
                    if (end.Column != checkFields.FieldCount)
                    {
                        MessageBox.Show("Выбранный файл не соответствует нужному формату отчета. Возможно, ошибочно был загружен некорректный файл. Попробуйте загрузить корректный файл.", "Ошибка");
                        return;
                    }

                    form1.progressBar1.Maximum = end.Row;
                    form1.progressBar1.Value = 0;
                    form1.progressBar1.Visible = true;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        OrdersModel om = new OrdersModel();
                        ordersList.Add(om);

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            ordersList[ordersList.Count - 1].SetOrders(col - 1, workSheet.Cells[row, col].Text);
                        }
                        allLines++;
                        form1.progressBar1.Value++;
                        form1.progressBar1.Refresh();
                    }
                    form1.progressBar1.Visible = false;

                    if (!update)
                        SetNewOrdersToDB();
                }
            }
        }

        /* Заливаем все строки в БД */
        public void SetNewOrdersToDB()
        {
            string specifier = "G";
            string sqlStatement;
            connection.Open();

            form1.progressBar1.Maximum = ordersList.Count;
            form1.progressBar1.Value = 0;
            form1.progressBar1.Visible = true;
            
            for (int i = 0; i < ordersList.Count; i++)
            {
                sqlStatement = "INSERT INTO [Orders] ([AmazonOrderId], [MerchantOrderId], [PurchaseDate], [LastUpdatedDate], [OrderStatus], [FullfilmentChannel], [SalesChannel], [OrderChannel], [Url], [ShipServiceLevel], [ProductName], [Sku], [Asin], [ItemStatus], [Quantity], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ItemPromotionDiscount], [ShipPromotionDiscount], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [PromotionIds], [IsBusinessOrder], [PurchaseOrderNumber], [PriceDesignation], [ReturnDate]) VALUES ('" + ordersList[i].AmazonOrderId + "', '" + ordersList[i].MerchantOrderId + "', '" + ordersList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].LastUpdatedDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].OrderStatus + "', '" + ordersList[i].FullfilmentChannel + "', '" + ordersList[i].SalesChannel + "', '" + ordersList[i].OrderChannel + "', '" + ordersList[i].Url + "', '" + ordersList[i].ShipServiceLevel + "', '" + ordersList[i].ProductName + "', '" + ordersList[i].Sku + "', '" + ordersList[i].Asin + "', '" + ordersList[i].ItemStatus + "', " + ordersList[i].Quantity + ", '" + ordersList[i].Currency + "', " + ordersList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + ordersList[i].ShipCity + "', '" + ordersList[i].ShipState + "', '" + ordersList[i].ShipPostalCode + "', '" + ordersList[i].ShipCountry + "', '" + ordersList[i].PromotionIds + "', '" + ordersList[i].IsBusinessOrder + "', '" + ordersList[i].PurchaseOrderNumber + "', '" + ordersList[i].PriceDesignation + "', '" + ordersList[i].ReturnDate.ToString("yyyy-MM-dd") + "')";

                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                    addedLines++;
                }
                catch (Exception ex) { }

                form1.progressBar1.Value++;
                form1.progressBar1.Refresh();
            }
            form1.progressBar1.Visible = false;
            connection.Close();
            MessageBox.Show("Добавление прошло успешно!\nВсего строк: " + allLines + "\nДобавлено новых строк: " + addedLines + "\nОбновлено строк: " + updatedLines);
        }

        /* Заливаем новые/обновляем старые строки в БД */
        public void UpdateOrdersInDB()
        {
            GetOrdersFromExcel(true);
            newOrdersList = new List<OrdersModel> { };

            string specifier = "G";
            string sqlStatement;
            connection.Open();

            form1.progressBar1.Maximum = ordersList.Count;
            form1.progressBar1.Value = 0;
            form1.progressBar1.Visible = true;

            for (int i = 0; i < ordersList.Count; i++)
            {
                sqlStatement = "INSERT INTO [Orders] ([AmazonOrderId], [MerchantOrderId], [PurchaseDate], [LastUpdatedDate], [OrderStatus], [FullfilmentChannel], [SalesChannel], [OrderChannel], [Url], [ShipServiceLevel], [ProductName], [Sku], [Asin], [ItemStatus], [Quantity], [Currency], [ItemPrice], [ItemTax], [ShippingPrice], [ShippingTax], [GiftWrapPrice], [GiftWrapTax], [ItemPromotionDiscount], [ShipPromotionDiscount], [ShipCity], [ShipState], [ShipPostalCode], [ShipCountry], [PromotionIds], [IsBusinessOrder], [PurchaseOrderNumber], [PriceDesignation], [ReturnDate]) VALUES ('" + ordersList[i].AmazonOrderId + "', '" + ordersList[i].MerchantOrderId + "', '" + ordersList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].LastUpdatedDate.ToString("yyyy-MM-dd") + "', '" + ordersList[i].OrderStatus + "', '" + ordersList[i].FullfilmentChannel + "', '" + ordersList[i].SalesChannel + "', '" + ordersList[i].OrderChannel + "', '" + ordersList[i].Url + "', '" + ordersList[i].ShipServiceLevel + "', '" + ordersList[i].ProductName + "', '" + ordersList[i].Sku + "', '" + ordersList[i].Asin + "', '" + ordersList[i].ItemStatus + "', " + ordersList[i].Quantity + ", '" + ordersList[i].Currency + "', " + ordersList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + ordersList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", '" + ordersList[i].ShipCity + "', '" + ordersList[i].ShipState + "', '" + ordersList[i].ShipPostalCode + "', '" + ordersList[i].ShipCountry + "', '" + ordersList[i].PromotionIds + "', '" + ordersList[i].IsBusinessOrder + "', '" + ordersList[i].PurchaseOrderNumber + "', '" + ordersList[i].PriceDesignation + "', '" + ordersList[i].ReturnDate.ToString("yyyy-MM-dd") + "')";

                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                    addedLines++;
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146232060)
                    {
                        OrdersModel om = new OrdersModel();
                        newOrdersList.Add(om);

                        for (int j = 0; j < om.FieldCount; j++)
                        {
                            newOrdersList[newOrdersList.Count - 1].SetOrdersForUpdate(j, ordersList[i].GetOrders(j));
                        }
                    }
                }

                form1.progressBar1.Value++;
                form1.progressBar1.Refresh();
            }

            form1.progressBar1.Visible = false;
            connection.Close();

            if (newOrdersList.Count > 0)
                UpdateExistingOrdersInDB();

            MessageBox.Show("Всего записей: " + allLines + "\nДобавлено новых записей: " + addedLines + "\nОбновлено записей: " + updatedLines);
        }

        /* Обновляем уже существующие строки в БД */
        private void UpdateExistingOrdersInDB()
        {
            string specifier = "G";
            string sqlStatement;
            connection.Open();

            form1.progressBar1.Maximum = newOrdersList.Count;
            form1.progressBar1.Value = 0;
            form1.progressBar1.Visible = true;

            for (int i = 0; i < newOrdersList.Count; i++)
            {
                sqlStatement = "UPDATE [Orders] SET [MerchantOrderId] = '" + newOrdersList[i].MerchantOrderId + "', [PurchaseDate] = '" + newOrdersList[i].PurchaseDate.ToString("yyyy-MM-dd") + "', [LastUpdatedDate] = '" + newOrdersList[i].LastUpdatedDate.ToString("yyyy-MM-dd") + "', [OrderStatus] = '" + newOrdersList[i].OrderStatus + "', [FullfilmentChannel] = '" + newOrdersList[i].FullfilmentChannel + "', [SalesChannel] = '" + newOrdersList[i].SalesChannel + "', [OrderChannel] = '" + newOrdersList[i].OrderChannel + "', [Url] = '" + newOrdersList[i].Url + "', [ShipServiceLevel] = '" + newOrdersList[i].ShipServiceLevel + "', [ProductName] = '" + newOrdersList[i].ProductName + "', [Sku] = '" + newOrdersList[i].Sku + "', [Asin] = '" + newOrdersList[i].Asin + "', [ItemStatus] = '" + newOrdersList[i].ItemStatus + "', [Quantity] = '" + newOrdersList[i].Quantity + "', [Currency] = '" + newOrdersList[i].Currency + "', [ItemPrice] = " + newOrdersList[i].ItemPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", [ItemTax] = " + newOrdersList[i].ItemTax.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShippingPrice] = " + newOrdersList[i].ShippingPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShippingTax] = " + newOrdersList[i].ShippingTax.ToString(specifier, CultureInfo.InvariantCulture) + ", [GiftWrapPrice] = " + newOrdersList[i].GiftWrapPrice.ToString(specifier, CultureInfo.InvariantCulture) + ", [GiftWrapTax] = " + newOrdersList[i].GiftWrapTax.ToString(specifier, CultureInfo.InvariantCulture) + ", [ItemPromotionDiscount] = " + newOrdersList[i].ItemPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShipPromotionDiscount] = " + newOrdersList[i].ShipPromotionDiscount.ToString(specifier, CultureInfo.InvariantCulture) + ", [ShipCity] = '" + newOrdersList[i].ShipCity + "', [ShipState] = '" + newOrdersList[i].ShipState + "', [ShipPostalCode] = '" + newOrdersList[i].ShipPostalCode + "', [ShipCountry] = '" + newOrdersList[i].ShipCountry + "', [PromotionIds] = '" + newOrdersList[i].PromotionIds + "', [IsBusinessOrder] = '" + newOrdersList[i].IsBusinessOrder + "', [PurchaseOrderNumber] = '" + newOrdersList[i].PurchaseOrderNumber + "', [PriceDesignation] = '" + newOrdersList[i].PriceDesignation + "', [ReturnDate] = '" + ordersList[i].ReturnDate.ToString("yyyy-MM-dd") + "' WHERE [AmazonOrderId] = '" + newOrdersList[i].AmazonOrderId + "'";

                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                    updatedLines++;
                }
                catch (Exception ex) { }

                form1.progressBar1.Value++;
                form1.progressBar1.Refresh();
            }

            form1.progressBar1.Visible = false;
            connection.Close();
        }


        public int GetOrders()
        {
            string sqlStatement = "SELECT * FROM [Orders]";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        private int Execute_SELECT_Command(SqlCommand _command)
        {
            ordersList = new List<OrdersModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetProductsToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
                //вызывает нужный метод в зависимости, из какой формы нас вызывают
                if (form2 != null)
                    form2.GetOrdersFromDB(ordersList);
                else if (form3 != null)
                    form3.GetOrdersFromDB(ordersList);
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* Заносим данные в List<ProductsModel> */
        private void SetProductsToList(IDataRecord record)
        {
            OrdersModel fscModel = new OrdersModel();
            ordersList.Add(fscModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                ordersList[ordersList.Count - 1].SetOrders(i, record[i]);
            }
        }
    }
}
