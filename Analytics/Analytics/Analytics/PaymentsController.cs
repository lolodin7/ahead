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
            form1.openFileDialog1.Filter = "Выбери файл|*.csv;*.txt;*.xlsx";
            form1.openFileDialog1.Title = "Выбор файла для открытия";

            if (form1.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
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
                    if (end.Column != checkFields.FieldCount)
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

                    SetNewPaymentsToDB();
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
                sqlStatement = "INSERT INTO [Payments] ([Date], [OrderId], [SKU], [TransactionType], [PaymentType], [PaymentDetail], [Amount], [Quantity], [ProductTitle]) VALUES ('" + paymentsList[i].Date.ToString("yyyy-MM-dd") + "', '" + paymentsList[i].OrderId + "', '" + paymentsList[i].Sku + "', '" + paymentsList[i].TransactionType + "', '" + paymentsList[i].PaymentType + "', '" + paymentsList[i].PaymentDetail + "', " + paymentsList[i].Amount.ToString(specifier, CultureInfo.InvariantCulture) + ", " + paymentsList[i].Quantity + ", '" + paymentsList[i].ProductTitle + "')";
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
            MessageBox.Show("Добавление прошло успешно!\nВсего записей: " + allLines + "\nДобавлено новых записей: " + addedLines + "\nОбновлено записей: " + updatedLines);
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
