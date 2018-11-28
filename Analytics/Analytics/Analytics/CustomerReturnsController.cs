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
    class CustomerReturnsController
    {
        private SqlConnection connection;
        private List<CustomerReturnsModel> customerReturnsList;
        private List<CustomerReturnsModel> newCustomerReturnsList;
        private int allLines;
        private int addedLines;
        private int updatedLines;
        private AnalyticsForm form1;
        private string[] dgvColumnsHeadersText;

        public CustomerReturnsController(AnalyticsForm _form1)
        {
            connection = DBData.GetDBConnection();
            customerReturnsList = new List<CustomerReturnsModel> { };
            allLines = 0;
            addedLines = 0;
            updatedLines = 0;

            form1 = _form1;
        }

        /* Вытаскиваем строки из Excel */
        public void GetCustomerReturnsFromExcel(bool update)
        {
            form1.openFileDialog1.Filter = "Выбери файл|*.csv;*.txt;*.xlsx";
            form1.openFileDialog1.Title = "Выбор файла для открытия";

            if (form1.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@form1.openFileDialog1.FileName)))
                {
                    customerReturnsList = new List<CustomerReturnsModel> { };
                    allLines = 0;
                    addedLines = 0;
                    updatedLines = 0;

                    ExcelWorksheet workSheet = xlPackage.Workbook.Worksheets.First();
                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    CustomerReturnsModel checkFields = new CustomerReturnsModel();
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
                        CustomerReturnsModel crm = new CustomerReturnsModel();
                        customerReturnsList.Add(crm);

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            customerReturnsList[customerReturnsList.Count - 1].SetCustomerReturns(col - 1, workSheet.Cells[row, col].Text);
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

            form1.progressBar1.Maximum = customerReturnsList.Count;
            form1.progressBar1.Value = 0;
            form1.progressBar1.Visible = true;

            for (int i = 0; i < customerReturnsList.Count; i++)
            {
                sqlStatement = "INSERT INTO [CustomerReturns] ([ReturnDate], [OrderId], [SKU], [ASIN], [FNSKU], [ProductName], [Quantity], [FullfilmentCenterId], [DetailedDisposition], [Reason], [Status], [LicensePlateNumber], [CustomerComments]) VALUES('" + customerReturnsList[i].ReturnDate.ToString("yyyy-MM-dd") + "', '" + customerReturnsList[i].OrderId + "', '" + customerReturnsList[i].SKU + "', '" + customerReturnsList[i].ASIN + "', '" + customerReturnsList[i].FNSKU + "', '" + customerReturnsList[i].ProductName + "', " + customerReturnsList[i].Quantity + ", '" + customerReturnsList[i].FullfilmentCenterId + "', '" + customerReturnsList[i].DetailedDisposition + "', '" + customerReturnsList[i].Reason + "', '" + customerReturnsList[i].Status + "', '" + customerReturnsList[i].LicensePlateNumber  + "', '" + customerReturnsList[i].CustomerComments + "')";

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
            MessageBox.Show("Добавление прошло успешно!\nВсего записей: " + allLines + "\nДобавлено новых записей: " + addedLines + "\nОбновлено записей: " + updatedLines);
        }

        /* Заливаем новые/обновляем старые строки в БД */
        public void UpdateCustomerReturnsInDB()
        {
            GetCustomerReturnsFromExcel(true);
            newCustomerReturnsList = new List<CustomerReturnsModel> { };
            
            string sqlStatement;
            connection.Open();

            form1.progressBar1.Maximum = customerReturnsList.Count;
            form1.progressBar1.Value = 0;
            form1.progressBar1.Visible = true;

            for (int i = 0; i < customerReturnsList.Count; i++)
            {
                sqlStatement = "INSERT INTO [CustomerReturns] ([ReturnDate], [OrderId], [SKU], [ASIN], [FNSKU], [ProductName], [Quantity], [FullfilmentCenterId], [DetailedDisposition], [Reason], [Status], [LicensePlateNumber], [CustomerComments]) VALUES('" + customerReturnsList[i].ReturnDate.ToString("yyyy-MM-dd") + "', '" + customerReturnsList[i].OrderId + "', '" + customerReturnsList[i].SKU + "', '" + customerReturnsList[i].ASIN + "', '" + customerReturnsList[i].FNSKU + "', '" + customerReturnsList[i].ProductName + "', " + customerReturnsList[i].Quantity + ", '" + customerReturnsList[i].FullfilmentCenterId + "', '" + customerReturnsList[i].DetailedDisposition + "', '" + customerReturnsList[i].Reason + "', '" + customerReturnsList[i].Status + "', '" + customerReturnsList[i].LicensePlateNumber + "', '" + customerReturnsList[i].CustomerComments + "')";

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
                        CustomerReturnsModel crm = new CustomerReturnsModel();
                        newCustomerReturnsList.Add(crm);

                        for (int j = 0; j < crm.FieldCount; j++)
                        {
                            newCustomerReturnsList[newCustomerReturnsList.Count - 1].SetCustomerReturnsForUpdate(j, customerReturnsList[i].GetCustomerReturns(j));
                        }
                    }
                }

                form1.progressBar1.Value++;
                form1.progressBar1.Refresh();
            }

            form1.progressBar1.Visible = false;
            connection.Close();

            if (newCustomerReturnsList.Count > 0)
                UpdateExistingCustomerReturnsInDB();

            MessageBox.Show("Всего записей: " + allLines + "\nДобавлено новых записей: " + addedLines + "\nОбновлено записей: " + updatedLines);
        }


        /* Обновляем уже существующие строки в БД */
        private void UpdateExistingCustomerReturnsInDB()
        {
            string sqlStatement;
            connection.Open();

            form1.progressBar1.Maximum = newCustomerReturnsList.Count;
            form1.progressBar1.Value = 0;
            form1.progressBar1.Visible = true;

            for (int i = 0; i < newCustomerReturnsList.Count; i++)
            {
                sqlStatement = "UPDATE [CustomerReturns] SET [ReturnDate] = '" + newCustomerReturnsList[i].ReturnDate.ToString("yyyy-MM-dd") + "', [SKU] = '" + newCustomerReturnsList[i].SKU + "', [ASIN] = '" + newCustomerReturnsList[i].ASIN + "', [FNSKU] = '" + newCustomerReturnsList[i].FNSKU + "', [ProductName] = '" + newCustomerReturnsList[i].ProductName + "', [Quantity] = " + newCustomerReturnsList[i].Quantity + ", [FullfilmentCenterId] = '" + newCustomerReturnsList[i].FullfilmentCenterId + "', [DetailedDisposition] = '" + newCustomerReturnsList[i].DetailedDisposition + "', [Reason] = '" + newCustomerReturnsList[i].Reason + "', [Status] = '" + newCustomerReturnsList[i].Status + "', [LicensePlateNumber] = '" + newCustomerReturnsList[i].LicensePlateNumber + "', [CustomerComments] = '" + newCustomerReturnsList[i].CustomerComments + "' WHERE [OrderId] = '" + newCustomerReturnsList[i].OrderId + "'";

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











        public void GetCustomerReturnsByDateRange(DateTime start, DateTime end)
        {
            string sqlStatement = "SELECT * FROM CustomerReturns WHERE ReturnDate BETWEEN '" + start.ToString("yyyy-MM-dd") + "' AND '" + end.ToString("yyyy-MM-dd") + "'";

            try
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command = new SqlCommand(sqlStatement, connection);
                Execute_SELECT_Command(command);
            }
            catch (Exception ex) { }
        }

        /* Выполняем SELECT и заливаем в dataGridView */
        private int Execute_SELECT_Command(SqlCommand _command)
        {
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    fillDGVHeaders();
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
                
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        private void fillDGVHeaders()
        {
            form1.dataGridView1.Rows.Clear();
            form1.dataGridView1.Columns.Clear();
            CustomerReturnsModel crm = new CustomerReturnsModel();
            for (int i = 0; i < crm.dgvColumnsHeadersText.Length; i++)
            {
                form1.dataGridView1.Columns.Add(crm.dgvColumnsHeadersText[i], crm.dgvColumnsHeadersText[i]);
            }
        }
        
        /* Заносим данные в dataGridView */
        private void SetProductsToList(IDataRecord record)
        {
            int index = form1.dataGridView1.Rows.Add();
            for (int i = 0; i < record.FieldCount; i++)
            {
                if (i == 0)
                    form1.dataGridView1.Rows[index].Cells[i].Value = record[i].ToString().Substring(0, 10);
                else
                    form1.dataGridView1.Rows[index].Cells[i].Value = record[i];
            }

            form1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
