using Microsoft.VisualBasic.FileIO;
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
    class PaymentsController
    {
        private SqlConnection connection;
        private List<PaymentsModel> paymentsList;
        private List<PaymentsModel> newPaymentsList;
        private int allLines;
        private int addedLines;
        private int updatedLines;
        private AnalyticsForm form1;
        List<int> orderIdIndexesForDelete;
        List<string> alreadySeenOrderIds;
        List<string> alreadySeenDescriptions;

        public PaymentsController(AnalyticsForm _form1)
        {
            connection = DBData.GetDBConnection();
            paymentsList = new List<PaymentsModel> { };
            orderIdIndexesForDelete = new List<int> { };
            alreadySeenOrderIds = new List<string> { };
            alreadySeenDescriptions = new List<string> { };
            allLines = 0;
            addedLines = 0;
            updatedLines = 0;

            form1 = _form1;
        }

        /* Вытаскиваем строки из Excel */
        public void GetPaymentsFromExcel()
        {
            form1.openFileDialog1.Filter = "Выбери файл|*.xlsx";
            form1.openFileDialog1.Title = "Выбор файла для открытия";

            if (form1.openFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@form1.openFileDialog1.FileName)))
                {
                    paymentsList = new List<PaymentsModel> { };
                    allLines = 0;
                    addedLines = 0;
                    updatedLines = 0;
                    form1.lb_StatusText.Text = "Загрузка файла...";
                    form1.lb_StatusText.Visible = true;
                    form1.Refresh();
                    ExcelWorksheet workSheet = xlPackage.Workbook.Worksheets.First();
                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    PaymentsModel checkFields = new PaymentsModel();
                    if (end.Column != checkFields.FieldCount + 1)
                    {
                        MessageBox.Show("Выбранный файл не соответствует нужному формату отчета. Возможно, ошибочно был загружен некорректный файл. Приложение будет закрыто.", "Ошибка");
                        return;
                    }

                    form1.progressBar1.Maximum = end.Row;
                    form1.progressBar1.Value = 0;
                    form1.progressBar1.Visible = true;
                    form1.lb_StatusText.Text = "Обработка файла...";
                    form1.Refresh();
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        if (!workSheet.Cells[row, 1].Text.Equals(""))
                        {
                            PaymentsModel pm = new PaymentsModel();
                            paymentsList.Add(pm);

                            for (int col = start.Column; col <= end.Column; col++)
                            {
                                paymentsList[paymentsList.Count - 1].SetPayments(col - 1, workSheet.Cells[row, col].Text);
                            }
                            paymentsList[paymentsList.Count - 1].OrderIdHash = paymentsList[paymentsList.Count - 1].OrderId.GetHashCode();
                            allLines++;
                            form1.progressBar1.Value++;
                            form1.progressBar1.Refresh();
                        }
                        else { }
                    }
                    watch.Stop();
                    long i1 = watch.ElapsedMilliseconds / 1000;
                    Console.WriteLine("Обрабатывали " + i1 + " сек");

                    watch = System.Diagnostics.Stopwatch.StartNew();
                    form1.lb_StatusText.Text = "Удаление повторов...";
                    form1.Refresh();
                    CheckForDoubleOrders();
                    watch.Stop();
                    long i2 = watch.ElapsedMilliseconds / 1000;
                    Console.WriteLine("Удаляли " + i2 + " сек");


                    watch = System.Diagnostics.Stopwatch.StartNew();
                    form1.lb_StatusText.Text = "Сохранение в БД...";
                    form1.Refresh();
                    SetNewPaymentsToDB();
                    watch.Stop();
                    long i3 = watch.ElapsedMilliseconds / 1000;
                    Console.WriteLine("Сохраняли " + i3 + " сек");
                    form1.progressBar1.Visible = false;

                    Console.WriteLine("\n\n\n\n\nОбрабатывали " + i1 + " сек" + "\nУдаляли " + i2 + " сек" + "\nСохраняли " + i3 + " сек");
                    //Console.WriteLine("\n\n\n\n\nОбрабатывали " + i1 + " сек" + "\nСохраняли " + i3 + " сек");
                }
                
            }
        }

        public void CheckForDoubleOrders()
        {
            form1.progressBar1.Maximum = paymentsList.Count + 10;
            form1.progressBar1.Value = 0;
            form1.progressBar1.Visible = true;
            int i = 1;
            foreach (var val in paymentsList)
            {
                if (val.OrderId.Equals("") && val.Sku.Equals(""))
                {
                    //for (int j = i; j < paymentsList.Count; j++)
                    //{
                    //    if (val.Description.Equals(paymentsList[j].Description) && !alreadySeenDescriptions.Contains(paymentsList[j].Description))
                    //    {
                    //        val.Quantity += paymentsList[j].Quantity;
                    //        val.ProductSales += paymentsList[j].ProductSales;
                    //        val.ShippingCredits += paymentsList[j].ShippingCredits;
                    //        val.GiftWrapCredits += paymentsList[j].GiftWrapCredits;
                    //        val.PromotionalRebates += paymentsList[j].PromotionalRebates;
                    //        val.SaleTaxCollected += paymentsList[j].SaleTaxCollected;
                    //        val.MarketplaceFacilitatorTax += paymentsList[j].MarketplaceFacilitatorTax;
                    //        val.SellingFees += paymentsList[j].SellingFees;
                    //        val.FBAFees += paymentsList[j].FBAFees;
                    //        val.OtherTransactionFees += paymentsList[j].OtherTransactionFees;
                    //        val.Other += paymentsList[j].Other;
                    //        val.Total += paymentsList[j].Total;
                    //        orderIdIndexesForDelete.Add(j);
                    //    }
                    //}
                    //alreadySeenDescriptions.Add(val.Description);
                }
                else if (!val.OrderId.Equals("") || !val.Sku.Equals(""))
                {
                    for (int j = i; j < paymentsList.Count; j++)
                    {
                        if (val.OrderId.Equals(paymentsList[j].OrderId) && val.Sku.Equals(paymentsList[j].Sku) && !alreadySeenOrderIds.Contains(paymentsList[j].OrderId))
                        {
                            val.Quantity += paymentsList[j].Quantity;
                            val.ProductSales += paymentsList[j].ProductSales;
                            val.ShippingCredits += paymentsList[j].ShippingCredits;
                            val.GiftWrapCredits += paymentsList[j].GiftWrapCredits;
                            val.PromotionalRebates += paymentsList[j].PromotionalRebates;
                            val.SaleTaxCollected += paymentsList[j].SaleTaxCollected;
                            val.MarketplaceFacilitatorTax += paymentsList[j].MarketplaceFacilitatorTax;
                            val.SellingFees += paymentsList[j].SellingFees;
                            val.FBAFees += paymentsList[j].FBAFees;
                            val.OtherTransactionFees += paymentsList[j].OtherTransactionFees;
                            val.Other += paymentsList[j].Other;
                            val.Total += paymentsList[j].Total;
                            orderIdIndexesForDelete.Add(j);
                        }
                    }
                    alreadySeenOrderIds.Add(val.OrderId);
                }
                i++;
                form1.progressBar1.Value++;
                form1.progressBar1.Refresh();
            }

            foreach (var s in orderIdIndexesForDelete)
            {
                Console.WriteLine(s + 2);
            }

            Console.WriteLine("count = " + orderIdIndexesForDelete.Count);
            orderIdIndexesForDelete.Sort();
            for (int k = orderIdIndexesForDelete.Count - 1; k >= 0; k--)
            {
                paymentsList.RemoveAt(orderIdIndexesForDelete[k]);
                allLines--;
            }
        }

        /* Заливаем все строки в БД */
        public void SetNewPaymentsToDB()
        {
            string sqlStatement;
            string specifier = "G";
            connection.Open();

            form1.progressBar1.Maximum = paymentsList.Count;
            form1.progressBar1.Value = 0;

            for (int i = 0; i < paymentsList.Count; i++)
            {
                sqlStatement = "INSERT INTO [Payments] ([Date], [SettlementId], [Type], [OrderId], [Sku], [Description], [Quantity], [Marketplace], [Fullfilment], [OrderCity], [OrderState], [OrderPostal], [ProductSales], [ShippingCredits], [GiftWrapCredits], [PromotionalRebates], [SaleTaxCollected], [MarketplaceFacilitatorTax], [SellingFees], [FBAFees], [OtherTransactionFees], [Other], [Total]) VALUES ('" + paymentsList[i].Date.ToString("yyyy-MM-dd") + "', '" + paymentsList[i].SettlementId + "', '" + paymentsList[i].Type + "', '" + paymentsList[i].OrderId + "', '" + paymentsList[i].Sku + "', '" + paymentsList[i].Description + "', " + paymentsList[i].Quantity + ", '" + paymentsList[i].Marketplace + "', '" + paymentsList[i].Fullfilment + "', '" + paymentsList[i].OrderCity + "', '" + paymentsList[i].OrderState + "', '" + paymentsList[i].OrderPostal + "', " + paymentsList[i].ProductSales.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].ShippingCredits.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].GiftWrapCredits.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].PromotionalRebates.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].SaleTaxCollected.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].MarketplaceFacilitatorTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].SellingFees.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].FBAFees.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].OtherTransactionFees.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].Other.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].Total.ToString(specifier, CultureInfo.InvariantCulture) + ")";

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    command.ExecuteScalar();
                    addedLines++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(i);
                }

                form1.progressBar1.Value++;
                form1.progressBar1.Refresh();
            }
            form1.progressBar1.Visible = false;
            form1.lb_StatusText.Visible = false;
            connection.Close();
            MessageBox.Show("Добавление прошло успешно!\nВсего строк: " + allLines + "\nДобавлено новых строк: " + addedLines + "\nОбновлено строк: " + updatedLines);
        }

        /*
        public void UpdatePaymentsInDB()
        {
            GetPaymentsFromExcel();
            newPaymentsList = new List<PaymentsModel> { };

            string sqlStatement;
            string specifier = "G";
            connection.Open();

            for (int i = 0; i < paymentsList.Count; i++)
            {
                sqlStatement = "INSERT INTO [Payments] ([Date], [OrderId], [SKU], [TransactionType], [PaymentType], [PaymentDetail], [Amount], [Quantity], [ProductTitle]) VALUES ('" + paymentsList[i].Date.ToString("yyyy-MM-dd") + "', '" + paymentsList[i].OrderId + "', '" + paymentsList[i].Sku + "', '" + paymentsList[i].TransactionType + "', '" + paymentsList[i].PaymentType + "', '" + paymentsList[i].PaymentDetail + "', " + paymentsList[i].Amount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].Quantity + ", '" + paymentsList[i].ProductTitle + "')";
                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    PaymentsModel pm = new PaymentsModel();
                    newPaymentsList.Add(pm);
                    for (int j = 0; j < 5; j++)
                    {
                        newPaymentsList[newPaymentsList.Count - 1].SetPayments(j, paymentsList[i].GetPayments(j));
                    }
                }
            }
            connection.Close();

            if (newPaymentsList.Count > 0)
                UpdateExistingPaymentsInDB();
        }

        public void UpdateExistingPaymentsInDB()
        {
            string sqlStatement;
            string specifier = "G";
            connection.Open();

            for (int i = 0; i < paymentsList.Count; i++)
            {
                sqlStatement = "UPDATE [Payments] ([Date], [OrderId], [SKU], [TransactionType], [PaymentType], [PaymentDetail], [Amount], [Quantity], [ProductTitle]) VALUES ('" + paymentsList[i].Date.ToString("yyyy-MM-dd") + "', '" + paymentsList[i].OrderId + "', '" + paymentsList[i].Sku + "', '" + paymentsList[i].TransactionType + "', '" + paymentsList[i].PaymentType + "', '" + paymentsList[i].PaymentDetail + "', " + paymentsList[i].Amount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].Quantity + ", '" + paymentsList[i].ProductTitle + "')";

                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.ExecuteScalar();
            }
            connection.Close();
        }
        */
    }
}














//private void GetReportFromDB()
//{            
//    string sqlStatement = "SELECT * FROM Payments";
//    SqlCommand command = new SqlCommand(sqlStatement, connection);
//    connection.Open();
//    SqlDataReader reader = command.ExecuteReader();

//    if (reader.HasRows)
//    {
//        while (reader.Read())
//        {
//            SetInfo((IDataRecord)reader);
//        }
//    }
//    else
//    {
//        Console.WriteLine("No rows found.");
//    }
//    reader.Close();
//    connection.Close();

//}

//private void SetInfo(IDataRecord record)
//{
//    PaymentsModel pm = new PaymentsModel();
//    paymentsList.Add(pm);

//    for (int i = 0; i < record.FieldCount; i++)
//    {
//        paymentsList[paymentsList.Count - 1].SetPayments(i + 1, record[i]);
//    }
//}





/*
 public void GetPaymentsFromExcel()
        {
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"C:\temp\payments.xlsx")))
            {
                ExcelWorksheet workSheet = xlPackage.Workbook.Worksheets.First();
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;

                //System.Diagnostics.Stopwatch sw = new Stopwatch();
                //sw.Start();

                for (int row = start.Row + 1; row <= end.Row; row++)
                {
                    PaymentsModel pm = new PaymentsModel();
                    paymentsList.Add(pm);
                    //var index = dataGridView1.Rows.Add();
                    for (int col = start.Column; col <= end.Column; col++)
                    {
                        paymentsList[paymentsList.Count - 1].SetPayments(col - 1, workSheet.Cells[row, col].Text);
                        //dataGridView1.Rows[index].Cells[col - 1].Value = paymentsList[paymentsList.Count - 1].GetPayments(col - 1);
                    }
                    Console.WriteLine(row.ToString());
                }

                //sw.Stop();
                //MessageBox.Show((sw.ElapsedMilliseconds / 100.0).ToString() + "   строк: " + end.Row);
            }
        }

         Заливаем все строки в БД 
public void SetPaymentsToDB()
{
    string sqlStatement;
    string specifier = "G";
    connection.Open();
    //System.Diagnostics.Stopwatch sw = new Stopwatch();
    //sw.Start();
    for (int i = 0; i < paymentsList.Count; i++)
    {
        sqlStatement = "INSERT INTO [Payments] ([Date], [OrderId], [SKU], [TransactionType], [PaymentType], [PaymentDetail], [Amount], [Quantity], [ProductTitle]) VALUES ('" + paymentsList[i].Date.ToString("yyyy-MM-dd") + "', '" + paymentsList[i].OrderId + "', '" + paymentsList[i].Sku + "', '" + paymentsList[i].TransactionType + "', '" + paymentsList[i].PaymentType + "', '" + paymentsList[i].PaymentDetail + "', " + paymentsList[i].Amount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].Quantity + ", '" + paymentsList[i].ProductTitle + "')";
        SqlCommand command = new SqlCommand(sqlStatement, connection);

        command.ExecuteScalar();
    }
    connection.Close();
    //sw.Stop();
    //MessageBox.Show((sw.ElapsedMilliseconds / 100.0).ToString());
}
  */
