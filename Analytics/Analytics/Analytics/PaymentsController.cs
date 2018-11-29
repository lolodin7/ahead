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

        public PaymentsController(AnalyticsForm _form1)
        {
            connection = DBData.GetDBConnection();
            paymentsList = new List<PaymentsModel> { };
            allLines = 0;
            addedLines = 0;
            updatedLines = 0;

            form1 = _form1;
        }

        /* Вытаскиваем строки из Excel */
        public void GetPaymentsFromExcel()
        {
            form1.openFileDialog1.Filter = "Выбери файл|*.csv";
            form1.openFileDialog1.Title = "Выбор файла для открытия";

            if (form1.openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                using (TextFieldParser parser = new TextFieldParser(@form1.openFileDialog1.FileName))
                {

                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(new string[] { "," });                                     //?????????????
                    parser.HasFieldsEnclosedInQuotes = false;                                                                              

                    while (!parser.EndOfData)
                    {
                        PaymentsModel pm = new PaymentsModel();
                        paymentsList.Add(pm);
                        //Process row
                        string[] fields = parser.ReadFields();
                        //first
                        string tmp1 = fields[0];
                        paymentsList[paymentsList.Count - 1].SetPayments(0, fields[0].ToString());
                        //last
                        string tmp = fields[fields.Length - 1];
                        string res = tmp.Substring(0, tmp.Length - 2);
                        paymentsList[paymentsList.Count - 1].SetPayments(fields.Length - 1, fields[fields.Length - 1].ToString());

                        for (int j = 1; j < fields.Length - 2; j++)
                        {
                            paymentsList[paymentsList.Count - 1].SetPayments(j, fields[j].ToString());
                        }
                    }

                }

                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@form1.openFileDialog1.FileName)))
                {
                    paymentsList = new List<PaymentsModel> { };
                    allLines = 0;
                    addedLines = 0;
                    updatedLines = 0;

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

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        PaymentsModel pm = new PaymentsModel();
                        paymentsList.Add(pm);

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            paymentsList[paymentsList.Count - 1].SetPayments(col - 1, workSheet.Cells[row, col].Text);
                        }
                        allLines++;
                        form1.progressBar1.Value++;
                        form1.progressBar1.Refresh();
                    }
                    form1.progressBar1.Visible = false;

                    CheckForDoubleOrders();
                    SetNewPaymentsToDB();
                }
            }
        }

        public void CheckForDoubleOrders()
        {
            for (int i = 0; i < paymentsList.Count; i++)
            {
                for (int j = i + 1; j < paymentsList.Count; j++)
                {
                    if (paymentsList[i].OrderId.Equals(paymentsList[j].OrderId))
                    {
                        paymentsList[i].Quantity += paymentsList[j].Quantity;
                        paymentsList[i].ProductSales += paymentsList[j].ProductSales;
                        paymentsList[i].ShippingCredits += paymentsList[j].ShippingCredits;
                        paymentsList[i].GiftWrapCredits += paymentsList[j].GiftWrapCredits;
                        paymentsList[i].PromotionalRebates += paymentsList[j].PromotionalRebates;
                        paymentsList[i].SaleTaxCollected += paymentsList[j].SaleTaxCollected;
                        paymentsList[i].MarketplaceFacilitatorTax += paymentsList[j].MarketplaceFacilitatorTax;
                        paymentsList[i].SellingFees += paymentsList[j].SellingFees;
                        paymentsList[i].FBAFees += paymentsList[j].FBAFees;
                        paymentsList[i].OtherTransactionFees += paymentsList[j].OtherTransactionFees;
                        paymentsList[i].Other += paymentsList[j].Other;
                        paymentsList[i].Total += paymentsList[j].Total;
                        paymentsList.RemoveAt(j);
                    }
                }
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
            form1.progressBar1.Visible = true;

            for (int i = 0; i < paymentsList.Count; i++)
            {
                sqlStatement = "INSERT INTO [Payments] ([Date], [SettlementId], [Type], [OrderId], [Sku], [Description], [Quantity], [Marketplace], [Fullfilment], [OrderCity], [OrderState], [OrderPostal], [ProductSales], [ShippingCredits], [GiftWrapCredits], [PromotionalRebates], [SaleTaxCollected], [MarketplaceFacilitatorTax], [SellingFees], [FBAFees], [OtherTransactionFees], [Other], [Total]) VALUES (" + paymentsList[i].Date.ToString("yyyy-MM-dd") + ", " + paymentsList[i].SettlementId + ", " + paymentsList[i].Type + ", " + paymentsList[i].OrderId + ", " + paymentsList[i].Sku + ", " + paymentsList[i].Description + ", " + paymentsList[i].Quantity + ", " + paymentsList[i].Marketplace + ", " + paymentsList[i].Fullfilment + ", " + paymentsList[i].OrderCity + ", " + paymentsList[i].OrderState + ", " + paymentsList[i].OrderPostal + ", " + paymentsList[i].ProductSales.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].ShippingCredits.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].GiftWrapCredits.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].PromotionalRebates.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].SaleTaxCollected.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].MarketplaceFacilitatorTax.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].SellingFees.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].FBAFees.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].OtherTransactionFees.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].Other.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].Total.ToString(specifier, CultureInfo.InvariantCulture) + ")";

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
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
