using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Excel_Parse
{
    public partial class KeywordsAreExistedView : Form
    {
        private string[,] arr;
        private string choosenCategory;
        private string str = "В таблице далее представлены ключи, которые не были обновлены, поскольку они уже существуют в БД, но не принадлежат выбранной категории ";

        private string informationString = "Представленные в таблице ключи, вероятно, уже существуют в БД, но относятся к категории, отличной от указанной Вами. \nВы можете сохранить эти ключи путем экспорта их в *.xlsx файл (кнопка \"Экспорт\") или изменить их категорию и попробовать еще раз (кнопка \"Редактировать\").";

        private SemCoreRebuildView semCoreRebuild;

        public KeywordsAreExistedView(string[,] _arr, string _category)
        {
            InitializeComponent();
            arr = _arr;
            choosenCategory = _category;
            lb_Information.Text = informationString;

            FillDGV();
            lb_KeysCount.Text = "Всего ключей: " + dgv_Keywords.RowCount;
            MessageBox.Show(str + "(категория: " + choosenCategory + ").", "Внимание");

            semCoreRebuild = new SemCoreRebuildView();
        }

        public KeywordsAreExistedView()
        {
            InitializeComponent();
            lb_Information.Text = informationString;

            FillDGV();
            lb_KeysCount.Text = "Всего ключей: " + dgv_Keywords.RowCount;
            MessageBox.Show(str + "(категория: " + choosenCategory + ").", "Внимание");
        }

        private void FillDGV()
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                var index = dgv_Keywords.Rows.Add();

                for (int j = 0; j < 2; j++)
                {
                    dgv_Keywords.Rows[index].Cells[j].Value = arr[i, j];
                }
            }
        }

        /* Экспорт ключей в *.xls */
        private void btn_Export_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = dgv_Keywords.RowCount;
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            ExcelApp.Cells[1, 1] = "KEYWORD";
            ExcelApp.Cells[1, 2] = "VALUE";

            for (int i = 0; i < dgv_Keywords.Rows.Count; i++)
            {
                for (int j = 0; j < dgv_Keywords.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 2, j + 1] = dgv_Keywords.Rows[i].Cells[j].Value;
                }
                progressBar1.Value++;
            }
            //Вызываем нашу созданную эксельку.
            //ExcelApp.Visible = true;
            //ExcelApp.UserControl = true;

            saveFileDialog1.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                ExcelWorkBook.SaveAs(filename);
                ExcelWorkBook.Close(false);
                MessageBox.Show("Успешно сохранено!", "Успех");
            }
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void KeywordsAreExisted_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        /* Редактировать */
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            FullSemCoreView fsc = new FullSemCoreView(this, arr);
            if (fsc.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /* Загрузить и обновить */
        private void btn_SetAndInsertKeys_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Keywords.RowCount; i++)
            {
                arr[i, 0] = dgv_Keywords.Rows[i].Cells[0].Value.ToString();
                arr[i, 1] = dgv_Keywords.Rows[i].Cells[1].Value.ToString();
            }

            semCoreRebuild.GetKeywordsFromKeywordsAreExisted(arr);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}


/* wb_New = exApp_New.Workbooks.Add(System.Reflection.Missing.Value);
            ws_New = (Microsoft.Office.Interop.Excel.Worksheet)wb_New.Worksheets.get_Item(1);
            ws_New.Cells.Locked = false;
 
            //Объединение ячеек
            Excel1.Range rangeGroup1 = (Excel1.Range)ws_New.get_Range("A1", "C2").Cells;
            rangeGroup1.Merge(Type.Missing);
            rangeGroup1.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rangeGroup1.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rangeGroup1.Font.Name = "Times New Roman";
            rangeGroup1.Font.Size = 16;
            rangeGroup1.Locked = false;
            Excel1.Range rangeGroup2 = (Excel1.Range)ws_New.get_Range("A3", "C3").Cells;
            rangeGroup2.Merge(Type.Missing);
            rangeGroup2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangeGroup2.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rangeGroup2.Font.Name = "Times New Roman";
            rangeGroup2.Font.Size = 12;
 
            //Ширина столбцов
            Excel1.Range rangeWidth1 = ws_New.Range["A1", System.Type.Missing];
            rangeWidth1.EntireColumn.ColumnWidth = 60;
            Excel1.Range rangeWidth2 = ws_New.Range["B1", System.Type.Missing];
            rangeWidth2.EntireColumn.ColumnWidth = 16;
            Excel1.Range rangeWidth3 = ws_New.Range["C1", System.Type.Missing];
            rangeWidth3.EntireColumn.ColumnWidth = 16;
            //Оформление листа + печать
            ws_New.PageSetup.Orientation = XlPageOrientation.xlPortrait;
            ws_New.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
            ws_New.PageSetup.TopMargin = 1;
            ws_New.PageSetup.RightMargin = 0.75;
            ws_New.PageSetup.LeftMargin = 0.75;
            ws_New.PageSetup.BottomMargin = 1;
            ws_New.PageSetup.CenterHorizontally = true;
            //Шапка таблицы
            Excel1.Range rangeHeader1 = ws_New.get_Range("A5", "C5").Cells;
            rangeHeader1.Font.Name = "Times New Roman";
            rangeHeader1.Font.Size = 10;
            rangeHeader1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangeHeader1.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rangeHeader1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            rangeHeader1.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            ws_New.Cells[1, 1] = "КГБУЗ Богучанская РБ";
            ws_New.Cells[3, 1] = "Заправка и ремонт картриджей";
            ws_New.Cells[5, 1] = "Наименование картриджа";
            ws_New.Cells[5, 2] = "Количество";
            ws_New.Cells[5, 3] = "Дата";
            //Из dataGridView1 в Excel
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    ws_New.Cells[j + 6, i + 1] = (dataGridView1[i, j].Value).ToString();
                    Excel1.Range rangeBord1 = ws_New.Cells[j + 6, i + 1];
                    rangeBord1.Font.Name = "Times New Roman";
                    rangeBord1.Font.Size = 10;
                    rangeBord1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    rangeBord1.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    Excel1.Range rangeBJ = ws_New.Cells[j + 6, i + 2];
                    rangeBJ.HorizontalAlignment = XlHAlign.xlHAlignRight;
                    rangeBJ.VerticalAlignment = XlVAlign.xlVAlignCenter;
 
                }
            }
            int lastRow = ws_New.Cells.SpecialCells(Excel1.XlCellType.xlCellTypeLastCell).Row;
            ws_New.Cells[lastRow + 2, 1] = "ИТОГО:";
            ws_New.Cells[lastRow + 2, 2] = label7.Text;
            Excel1.Range rangeTotal1 = ws_New.Cells[lastRow + 2, 1];
            rangeTotal1.HorizontalAlignment = XlHAlign.xlHAlignRight;
            rangeTotal1.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rangeTotal1.Font.Name = "Times New Roman";
            rangeTotal1.Font.Size = 10;
            Excel1.Range rangeTotal2 = ws_New.Cells[lastRow + 2, 2];
            rangeTotal2.HorizontalAlignment = XlHAlign.xlHAlignRight;
            rangeTotal2.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rangeTotal2.Font.Name = "Times New Roman";
            rangeTotal2.Font.Size = 10; */
