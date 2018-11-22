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

namespace Analytics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetReport();
        }

        private void GetReport()
        {
            //string path;
            //openFileDialog1.Filter = "Выбери файл|*.csv;*.txt;*.xlsx";
            //openFileDialog1.Title = "Выбор файла для открытия";

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    path = openFileDialog1.FileName;
            //    using (TextFieldParser parser = new TextFieldParser(@path))
            //    {

            //        parser.TextFieldType = FieldType.Delimited;
            //        parser.SetDelimiters(",");                                                                                    //?????????????

            //        while (!parser.EndOfData)
            //        {
            //            //Process row
            //            string[] fields = parser.ReadFields();

            //            // var index = dgv_Source.Rows.Add();
            //            int i = 0;

            //            foreach (string field in fields)
            //            {
            //                //if (i == 1)
            //                //    dgv_Source.Rows[index].Cells[i].Value = double.Parse(field);
            //                //else
            //                //    dgv_Source.Rows[index].Cells[i].Value = field;
            //                //i++;
            //            }
            //        }

            //    }
            //}

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"C:\temp\payments.xlsx")))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                var sb = new StringBuilder(); //this is your your data
                for (int rowNum = 1; rowNum <= totalRows; rowNum++) //select starting row here
                {
                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    sb.AppendLine(string.Join(",", row));
                }
            }

        }
    }
}
