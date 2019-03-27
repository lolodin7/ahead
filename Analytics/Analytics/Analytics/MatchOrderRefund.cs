using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analytics
{
    class MatchOrderRefund
    {
        private List<OrdersModel> ordersList;
        private List<CustomerReturnsModel> returnsList;

        private OrdersController ordersController;
        private CustomerReturnsController returnsController;
        private AnalyticsForm af;

        public MatchOrderRefund(AnalyticsForm _af)
        {
            ordersController = new OrdersController(this);
            ordersController.GetOrders();

            returnsController = new CustomerReturnsController(this);
            returnsController.GetOrders();
            af = _af;
            MainLogic();
        }

        public void GetOrdersFromDB(List<OrdersModel> _ordersList)
        {
            ordersList = _ordersList;
        }

        public void GetReturnsFromDB(List<CustomerReturnsModel> _returnsList)
        {
            returnsList = _returnsList;
        }

        private void MainLogic()
        {
            af.progressBar1.Visible = true;
            af.progressBar1.Maximum = ordersList.Count * returnsList.Count + 1;
            af.progressBar1.Value = 0;
            for (int i = 0; i < ordersList.Count; i++)
            {
                for (int j = 0; j < returnsList.Count; j++)
                {
                    if (ordersList[i].AmazonOrderId.Equals(returnsList[j].OrderId))
                    {
                        ordersList[i].ReturnDate = returnsList[j].ReturnDate;
                    }
                    af.progressBar1.Value++;
                }
            }
            int raz;
            af.progressBar1.Maximum = ordersList.Count + 1;
            af.progressBar1.Value = 0;
            for (int i = 0; i < ordersList.Count; i++)
            {
                raz = (ordersList[i].ReturnDate - ordersList[i].PurchaseDate).Days;
                if (raz > 30)
                    Console.WriteLine(ordersList[i].AmazonOrderId + "   -   " + i + ", " + raz + " days\n");
                af.progressBar1.Value++;
            }

            //Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            //Workbook ExcelWorkBook;
            //Worksheet ExcelWorkSheet;

            //ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            ////Таблица.
            //ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);


            //int row = 1;
            //for (int i = 0; i < ordersList.Count; i++)
            //{
            //    //if (ordersList[i].ReturnDate > new DateTime(2015, 01, 01))
            //    //{
            //    //    for (int j = 0; j < ordersList[i].FieldCount; j++)
            //    //    {
            //    //        ExcelApp.Cells[row, j + 1] = ordersList[i].GetOrders(j);
            //    //    }
                    
            //    //    raz = (ordersList[i].ReturnDate - ordersList[i].PurchaseDate).Days;
            //    //    row++;
            //    //}

            //    raz = (ordersList[i].ReturnDate - ordersList[i].PurchaseDate).Days;
            //    if (raz > 0)
            //    {
            //        for (int j = 0; j < ordersList[i].FieldCount; j++)
            //        {
            //            ExcelApp.Cells[row, j + 1] = ordersList[i].GetOrders(j);
            //        }
            //        row++;
            //    }
            //}

            //af.saveFileDialog1.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";

            //af.saveFileDialog1.FileName = "Orders and Refunds Book 1";

            //if (af.saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            //{
            //    ExcelWorkBook.Close(false);
            //}
            //else
            //{
            //    // получаем выбранный файл
            //    string filename = af.saveFileDialog1.FileName;
            //    ExcelWorkBook.SaveAs(filename);
            //    ExcelWorkBook.Close(false);
            //    MessageBox.Show("Успешно сохранено!", "Успех");
            //}
        }
    }
}
