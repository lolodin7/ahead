using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class SemCoreArchiveView : Form
    {
        private SemCoreArchiveController scaController;
        private List<SemCoreArchiveModel> scaList;

        private MainFormView controlMainFormView;

        private KeywordCategoryController kcController;
        private List<KeywordCategoryModel> kcList;

        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;

        private List<DateTime> uniqueDatesList;     //список уникальных дат



        private string AllProductTypesCBName = "Все виды товаров";
        private string AllKeywordCategoriesCBName = "Все категории ключей";

        private bool firstLaunch = true;

        private Color foundedKeywordColor = Color.DeepSkyBlue;

        private bool SaveEditTrigger;       //true - add keyword, false - edit keyword
        private int ProductTypeId, KeyCategoryId;

        private int CurrentSemCoreId;

        public bool NoProdType { get; set; }
        public bool NoKeyCat { get; set; }




        /* Конструктор */
        public SemCoreArchiveView(MainFormView _form)
        {
            InitializeComponent();
            controlMainFormView = _form;


            GetStarted();
            firstLaunch = false;
        }


        /* Выполняем в конструкторе */
        private void GetStarted()
        {
            ptController = new ProductTypesController(this);
            kcController = new KeywordCategoryController(this);
            scaController = new SemCoreArchiveController(this);

            ptController.GetProductTypesAll();
            fill_cb_ProductTypes();
            kcController.GetKeywordCategoriesByProductId(GetProductTypeIdFromCB());
            fill_cb_KeywordCategory();

            scaController.GetSemCoreByProductAndCategory(GetProductTypeIdFromCB(), GetKeywordCategoryIdFromCB());
            //scaController.TransformStringToValuesAndDates(scaList[0].ValuesAndDates);
        }

        /* Заполняем cb_ProductType и cb_ProductType2 */
        private void fill_cb_ProductTypes()
        {
            if (ptList.Count > 0)
            {
                cb_ProductType.Items.Clear();
                cb_ProductType.Items.Add(AllProductTypesCBName);

                for (int i = 0; i < ptList.Count; i++)
                {
                    cb_ProductType.Items.Add(ptList[i].TypeName);
                }
                cb_ProductType.SelectedItem = cb_ProductType.Items[0];

                cb_ProductType2.Items.Clear();

                for (int i = 0; i < ptList.Count; i++)
                {
                    cb_ProductType2.Items.Add(ptList[i].TypeName);
                }
                cb_ProductType2.SelectedItem = cb_ProductType2.Items[0];
            }
            else
            {
                MessageBox.Show("Видимо, в системе нет ни одного вида товара. Для работы в этом разделе, пожалуйста, сначала добавьте хотя бы один вид товара.", "Ошибка");
                NoProdType = true;
            }
        }

        /* Заполняем cb_KeywordCategory и cb_KeywordCategory2 */
        private void fill_cb_KeywordCategory()
        {
            if (kcList.Count > 0)
            {
                cb_KeywordCategory.Enabled = true;
                cb_KeywordCategory.Items.Clear();
                cb_KeywordCategory.Items.Add(AllKeywordCategoriesCBName);

                for (int i = 0; i < kcList.Count; i++)
                {
                    cb_KeywordCategory.Items.Add(kcList[i].CategoryName);
                }
                cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[0];

                cb_KeywordCategory2.Items.Clear();

                for (int i = 0; i < kcList.Count; i++)
                {
                    cb_KeywordCategory2.Items.Add(kcList[i].CategoryName);
                }
                cb_KeywordCategory2.SelectedItem = cb_KeywordCategory2.Items[0];
            }
            else if (ptList.Count > 0)
            {
                MessageBox.Show("В системе нет ни одной категории ключей для этого вида товара. Пожалуйста, добавьте хотя бы одну категорию ключей для продолжения.", "Ошибка");
                label5.Text = "Упс, похоже, не найдено ни одного ключа :(";

                dgv_Keywords.Visible = false;
                label5.Visible = true;
                cb_KeywordCategory.Enabled = false;

                NoKeyCat = true;
            }
            else
            {
                MessageBox.Show("Видимо, в системе нет ни одной категории ключей. Для работы в этом разделе, пожалуйста, сначала добавьте хотя бы одну категорию ключей.", "Ошибка");
            }
        }

        /* Получаем ProductTypeId с cb_ProductType */
        private int GetProductTypeIdFromCB()
        {
            for (int i = 0; i < ptList.Count; i++)
            {
                if (ptList[i].TypeName.Equals(cb_ProductType.SelectedItem.ToString()))
                {
                    return ptList[i].ProductTypeId;
                }
            }
            return -1;
        }

        /* Получаем CategoryId с cb_KeywordCategory */
        private int GetKeywordCategoryIdFromCB()
        {
            for (int i = 0; i < kcList.Count; i++)
            {
                if (kcList[i].CategoryName.Equals(cb_KeywordCategory.SelectedItem.ToString()))
                {
                    return kcList[i].CategoryId;
                }
            }
            return -1;
        }
        
        /* Получаем категории ключей из БД */
        public void GetCategoriesFromDB(object _kcList)
        {
            kcList = (List<KeywordCategoryModel>)_kcList;
        }

        /* Получаем виды товаров из БД */
        public void GetProductTypesFromDB(object _ptList)
        {
            ptList = (List<ProductTypesModel>)_ptList;
        }

        /* Получаем ключи из БД */
        public void GetKeywordsFromDB(object _scaList)
        {
            scaList = (List<SemCoreArchiveModel>)_scaList;
        }

        /* Закрытие формы */
        private void SemCoreArchiveView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlMainFormView != null)
                controlMainFormView.Visible = true;
        }


        /* Получаем набор ключей по категории и виду товара после нажатия кнопки */
        private void btn_GetKeywords_Click(object sender, EventArgs e)
        {
            ShowKeywords();
        }

        private void ShowKeywords()
        {
            scaController.GetSemCoreByProductAndCategory(GetProductTypeIdFromCB(), GetKeywordCategoryIdFromCB());
            //ReDrawKeywords();
            //основная логика

            //получаем уникальные даты
            GetUniqueDates();
            //рисуем столбцы в таблице
            //заполняем построчно таблицу

            StartKeySearch();

            if (dgv_Keywords.RowCount > 0)
            {
                label5.Visible = false;
                dgv_Keywords.Visible = true;
            }
            else
            {
                label5.Text = "Упс, похоже, не найдено ни одного ключа :(";
                dgv_Keywords.Visible = false;
                label5.Visible = true;
            }
        }

        private void GetUniqueDates()
        {
            for (int i = 0; i < scaList.Count; i++)
            {

            }
        }

        /* Перерисовываем таблицу новыми данными после изменения категории или вида продукта */
        private void ReDrawKeywords()
        {
            dgv_Keywords.Rows.Clear();
            FillKeywordsInDGV();
        }

        /* Перерисовываем таблицу новыми данными SemCore */
        private void FillKeywordsInDGV()
        {
            dgv_Keywords.Rows.Clear();

            for (int i = 0; i < scaList.Count; i++)
            {
                var index = dgv_Keywords.Rows.Add();

                for (int j = 0; j < scaList[0].ColumnCount; j++)
                {
                    dgv_Keywords.Rows[index].Cells[j].Value = scaList[i].ReadData(j);
                }
            }

            int cnt = dgv_Keywords.RowCount;
            if (cnt == 1)
                this.Text = "Семантическая база - " + cnt + " ключ - Bona Fides";
            else if (cnt == 2 || cnt == 3 || cnt == 4)
                this.Text = "Семантическая база - " + cnt + " ключа - Bona Fides";
            else if (cnt >= 5 && cnt <= 19)
                this.Text = "Семантическая база - " + cnt + " ключей - Bona Fides";
            else
            {
                if (cnt % 10 == 1)
                    this.Text = "Семантическая база - " + cnt + " ключ - Bona Fides";
                else if (cnt % 10 == 2 || cnt % 10 == 3 || cnt % 10 == 4)
                    this.Text = "Семантическая база - " + cnt + " ключа - Bona Fides";
                else if (cnt % 10 >= 5 || cnt % 10 <= 9 || cnt % 10 == 0)
                    this.Text = "Семантическая база - " + cnt + " ключей - Bona Fides";
            }
        }

        /* Поиск ключа в таблице при наборе текста в tb_FindKeyword */
        private void rtb_FindKeyword_TextChanged(object sender, EventArgs e)
        {
            StartKeySearch();
        }

        /* Экспорт в *.xlsx */
        private void btn_Export_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            ExcelApp.Cells[1] = dgv_Keywords.Columns[2].HeaderText;
            ExcelApp.Cells[2] = dgv_Keywords.Columns[3].HeaderText;
            ExcelApp.Cells[3] = dgv_Keywords.Columns[4].HeaderText;
            ExcelApp.Cells[4] = dgv_Keywords.Columns[7].HeaderText;
            ExcelApp.Cells[5] = dgv_Keywords.Columns[10].HeaderText;

            for (int i = 0; i < dgv_Keywords.Rows.Count; i++)
            {
                ExcelApp.Cells[i + 2, 1] = dgv_Keywords.Rows[i].Cells[2].Value;
                ExcelApp.Cells[i + 2, 2] = dgv_Keywords.Rows[i].Cells[3].Value;
                ExcelApp.Cells[i + 2, 3] = dgv_Keywords.Rows[i].Cells[4].Value;
                ExcelApp.Cells[i + 2, 4] = dgv_Keywords.Rows[i].Cells[7].Value;
                ExcelApp.Cells[i + 2, 5] = dgv_Keywords.Rows[i].Cells[10].Value;
            }

            ExcelWorkSheet.get_Range("B1", "B10000").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ExcelWorkSheet.get_Range("C1", "C10000").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ExcelWorkSheet.get_Range("A1", "N1").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ExcelWorkSheet.Columns[1].ColumnWidth = 42.14;
            ExcelWorkSheet.Columns[2].ColumnWidth = 18;
            ExcelWorkSheet.Columns[3].ColumnWidth = 23.57;
            ExcelWorkSheet.Columns[4].ColumnWidth = 35;
            ExcelWorkSheet.Columns[5].ColumnWidth = 42.14;

            saveFileDialog1.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                ExcelWorkBook.Close(false);
            }
            else
            {
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                ExcelWorkBook.SaveAs(filename);
                ExcelWorkBook.Close(false);
                MessageBox.Show("Успешно сохранено!", "Успех");
            }
        }

        /* Метод для поиска ключа в таблице */
        private void StartKeySearch()
        {
            int cnt = 0;
            //2 колонка - ключ
            for (int i = 0; i < dgv_Keywords.RowCount; i++)
            {
                if (dgv_Keywords.Rows[i].Cells[2].Value.ToString().ToLower().Contains(rtb_FindKeyword.Text.ToLower()) && !rtb_FindKeyword.Text.Equals(""))
                {
                    dgv_Keywords.Rows[i].Cells[2].Style.BackColor = foundedKeywordColor;
                    cnt++;
                }
                else
                    dgv_Keywords.Rows[i].Cells[2].Style.BackColor = Color.White;
            }
            label2.Text = "Найдено: " + cnt.ToString();
        }


    }
}
