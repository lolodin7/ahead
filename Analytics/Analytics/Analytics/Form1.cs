using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace Analytics
{
    public partial class Form1 : Form
    {
        //private PaymentsController paymentsController;
        //private OrdersController ordersController;
        private ShipmentsController shipmentsController;

        public Form1()
        {
            InitializeComponent();
            //paymentsController = new PaymentsController();
            //ordersController = new OrdersController();            
            shipmentsController = new ShipmentsController();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //paymentsController.GetPaymentsFromExcel();
            //ordersController.GetOrdersFromExcel();
            shipmentsController.GetShipmentsFromExcel();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //paymentsController.SetPaymentsToDB();
            //ordersController.SetNewOrdersToDB();
            shipmentsController.SetNewShipmentsToDB();

        }

        private void btn_UpdateReportsInDB_Click(object sender, EventArgs e)
        {
            //ordersController.UpdateOrdersInDB();
            shipmentsController.UpdateShipmentsInDB();
        }
    }
}
