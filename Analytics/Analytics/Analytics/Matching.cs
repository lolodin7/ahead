using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analytics
{
    class Matching
    {
        AnalyticsForm af;
        private string path = "";

        private List<OrdersModel> ordersList;

        private OrdersController ordersController;

        private List<string> ordersListstring;

        private List<OrdersModel> resultList;


        public Matching(AnalyticsForm _af)
        {
            af = _af;
           
            ordersController = new OrdersController(this);
            ordersController.GetOrders();

            ordersController.GetOrders();

            ordersListstring = new List<string> { };
            resultList = new List<OrdersModel> { };
            OpenNewFile();

            StartMatching();
        }

        public void GetOrdersFromDB(List<OrdersModel> _ordersList)
        {
            ordersList = _ordersList;
        }

        /* Загружаем новые ключи из файла */
        public void OpenNewFile()
        {
            
            bool isExcel = false;

            af.openFileDialog1.Filter = "Excel файлы (*.xlsx)|*.xlsx";
            af.openFileDialog1.Title = "Выбор файла для открытия";
            af.openFileDialog1.FileName = "";

            if (af.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = af.openFileDialog1.FileName;

                if (path.Contains(".xlsx"))
                    isExcel = true;


                if (isExcel)
                {
                    try
                    {
                        FileInfo existingFile = new FileInfo(@path);
                        using (ExcelPackage package = new ExcelPackage(existingFile))
                        {
                            //get the first worksheet in the workbook
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                            int colCount = worksheet.Dimension.End.Column;  //get Column Count
                            int rowCount = worksheet.Dimension.End.Row;     //get row count
                            for (int row = 1; row <= rowCount; row++)
                            {
                                ordersListstring.Add(worksheet.Cells[row, 1].Value.ToString().Trim());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                    }
                }
            }
        }

        private void StartMatching()
        {
            for (int i = 0; i < ordersList.Count; i++)
            {
                for (int j = 0; j < ordersListstring.Count; j++)
                {
                    if (ordersList[i].AmazonOrderId.Equals(ordersListstring[j]))
                    {
                        resultList.Add(new OrdersModel());
                        resultList[resultList.Count - 1] = ordersList[i];
                        j = ordersListstring.Count;
                    }
                }
            }


            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);


            int row = 1;
            for (int i = 0; i < resultList.Count; i++)
            {
                for (int j = 0; j < resultList[i].FieldCount; j++)
                {
                    ExcelApp.Cells[row, j + 1] = resultList[i].GetOrders(j);
                }

                row++;
            }

            af.saveFileDialog1.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";

            af.saveFileDialog1.FileName = "Orders and Refunds Book 1";

            if (af.saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                ExcelWorkBook.Close(false);
            }
            else
            {
                // получаем выбранный файл
                string filename = af.saveFileDialog1.FileName;
                ExcelWorkBook.SaveAs(filename);
                ExcelWorkBook.Close(false);
                MessageBox.Show("Успешно сохранено!", "Успех");
            }
        }
    }

}
