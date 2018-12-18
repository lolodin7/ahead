using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class FullSemCoreView : Form
    {
        private KeywordsAreExistedView ControlFormKeywordsAreExisted;
        private MainFormView ControlFormMF;
        private FullSemCoreView ControlFullSemCoreView;

        private FullSemCoreController fscController;
        private List<FullSemCoreModel> fscList;

        private KeywordCategoryController kcController;
        private List<KeywordCategoryModel> kcList;

        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;

        private string AllProductTypesCBName = "Все виды товаров";
        private string AllKeywordCategoriesCBName = "Все категории ключей";

        private bool firstLaunch = true;


        /* Вызываем из KeywordsAreExisted для редактирования ключей из таблицы */
        public FullSemCoreView(KeywordsAreExistedView _form, string[,] arr)
        {
            InitializeComponent();
            ControlFormKeywordsAreExisted = _form;

            GetStarted();
            firstLaunch = false;
        }

        /* Вызываем из главной формы */
        public FullSemCoreView(MainFormView _mf)
        {
            InitializeComponent();
            ControlFormMF = _mf;

            GetStarted();
            firstLaunch = false;
        }

        /* Вызываем из FullSemCoreView */
        public FullSemCoreView(FullSemCoreView _mf)
        {
            InitializeComponent();
            ControlFullSemCoreView = _mf;

            GetStarted();
            firstLaunch = false;
        }

        /* Выполняем в конструкторе */
        private void GetStarted()
        {
            ptController = new ProductTypesController(this);
            kcController = new KeywordCategoryController(this);
            fscController = new FullSemCoreController(this);

            ptController.GetProductTypesAll();
            fill_cb_ProductTypes();
            kcController.GetKeywordCategoriesByProductId(GetProductTypeIdFromCB());
            fill_cb_KeywordCategory();
            fscController.GetSemCoreByProductAndCategory(GetProductTypeIdFromCB(), GetKeywordCategoryIdFromCB());
        }

        /* Перезаполняем cb_KeywordCategory после смены вида товара */
        private void RefreshData()
        {
            kcController.GetKeywordCategoriesByProductId(GetProductTypeIdFromCB());
            fill_cb_KeywordCategory();
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

            for (int i = 0; i < fscList.Count; i++)
            {
                var index = dgv_Keywords.Rows.Add();

                for (int j = 0; j < fscList[0].ColumnCount; j++)
                {
                    dgv_Keywords.Rows[index].Cells[j].Value = fscList[i].ReadData(j);
                }
            }
        }

        /* Получаем ключи из БД */
        public void GetKeywordsFromDB(object _fscList)
        {
            fscList = (List<FullSemCoreModel>)_fscList;
        }

        /* Получаем ProducTypes из БД */
        public void GetProductTypesFromDB(object _ptList)
        {
            ptList = (List<ProductTypesModel>)_ptList;
        }

        /* Получаем KeywordCategories из БД */
        public void GetCategoriesFromDB(object _kcList)
        {
            kcList = (List<KeywordCategoryModel>)_kcList;
        }

        /* Заполняем cb_ProductType */
        private void fill_cb_ProductTypes()
        {
            cb_ProductType.Items.Clear();
            cb_ProductType.Items.Add(AllProductTypesCBName);

            for (int i = 0; i < ptList.Count; i++)
            {
                cb_ProductType.Items.Add(ptList[i].TypeName);
            }
            cb_ProductType.SelectedItem = cb_ProductType.Items[0];
        }

        /* Заполняем cb_KeywordCategory */
        private void fill_cb_KeywordCategory()
        {
            cb_KeywordCategory.Items.Clear();
            cb_KeywordCategory.Items.Add(AllKeywordCategoriesCBName);

            for (int i = 0; i < kcList.Count; i++)
            {
                cb_KeywordCategory.Items.Add(kcList[i].CategoryName);
            }
            cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[0];
        }

        /* Получаем набор ключей по категории и виду товара после нажатия кнопки */
        private void btn_GetKeywords_Click(object sender, EventArgs e)
        {
            fscController.GetSemCoreByProductAndCategory(GetProductTypeIdFromCB(), GetKeywordCategoryIdFromCB());
            ReDrawKeywords();
        }

        /* Закрытие формы */
        private void FullSemCore_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ControlFormKeywordsAreExisted != null)
            {
                this.DialogResult = DialogResult.OK;
                ControlFormKeywordsAreExisted.Visible = true;
            }
            else if (ControlFormMF != null)
            {
                ControlFormMF.Visible = true;
            }
            else if (ControlFullSemCoreView != null)
            {
                ControlFullSemCoreView.Visible = true;
            }
        }

        /* При смене выбранного вида товара, получаем список соответствующих ему категорий ключей */
        private void cb_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstLaunch)
                RefreshData();
        }

        /* Поиск ключа в таблице при наборе текста в tb_FindKeyword */
        private void tb_FindKeyword_TextChanged(object sender, EventArgs e)
        {
            StartKeySearch();
        }

        /* Метод для поиска ключа в таблице */
        private void StartKeySearch()
        {
            //2 колонка - ключ
            for (int i = 0; i < dgv_Keywords.RowCount; i++)
            {
                if (dgv_Keywords.Rows[i].Cells[2].Value.ToString().Contains(tb_FindKeyword.Text) && !tb_FindKeyword.Text.Equals(""))
                {
                    dgv_Keywords.Rows[i].Cells[2].Style.BackColor = Color.LightGray;
                }
                else
                    dgv_Keywords.Rows[i].Cells[2].Style.BackColor = Color.White;
            }
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
    }
}

