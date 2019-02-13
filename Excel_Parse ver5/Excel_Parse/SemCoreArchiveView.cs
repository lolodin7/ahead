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
        

        private List<DateTime> dtKeyList;
        private List<int> valKeyList;
        private List<DateTime> allDTKeyList;
        private List<DateTime> uniqueDTKeyList;

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

            dtKeyList = new List<DateTime> { };
            valKeyList = new List<int> { };
            allDTKeyList = new List<DateTime> { };
            uniqueDTKeyList = new List<DateTime> { };

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
        }

        /* Заполняем cb_ProductType */
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
            }
            else
            {
                MessageBox.Show("Видимо, в системе нет ни одного вида товара. Для работы в этом разделе, пожалуйста, сначала добавьте хотя бы один вид товара.", "Ошибка");
                NoProdType = true;
            }
        }

        /* Заполняем cb_KeywordCategory */
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


        /* Отобразить ключи (основная логика) */
        private void ShowKeywords()
        {
            dgv_Keywords.Rows.Clear();
            //получаем список ключей из БД
            scaController.GetSemCoreByProductAndCategory(GetProductTypeIdFromCB(), GetKeywordCategoryIdFromCB());

            //основная логика

            //получаем уникальные даты
            GetUniqueDates();
            //рисуем столбцы в таблице по уникальным датам
            DrawColumns();
            //заполняем построчно таблицу
            FillDgvByKeywords();


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

        /* Заполняем dgv_Keywords частотами ключей построчно */
        private void FillDgvByKeywords()
        {
            for (int i = 0; i < scaList.Count; i++)
            {
                var index = dgv_Keywords.Rows.Add();
                dgv_Keywords.Rows[index].Cells[0].Value = scaList[i].ProductTypeId;
                dgv_Keywords.Rows[index].Cells[1].Value = scaList[i].CategoryId;
                dgv_Keywords.Rows[index].Cells[2].Value = scaList[i].SemCoreId;
                dgv_Keywords.Rows[index].Cells[3].Value = scaList[i].CategoryName;
                dgv_Keywords.Rows[index].Cells[4].Value = scaList[i].TypeName;
                dgv_Keywords.Rows[index].Cells[5].Value = scaList[i].Keyword;

                for (int j = 6; j < dgv_Keywords.ColumnCount; j++)      //идем по каждому столбцу
                {
                    for (int k = 0; k < scaList[i].UpdateDate.Count; k++)       //идем по каждой дате ключа
                    {
                        if (dgv_Keywords.Columns[j].HeaderText.Equals(scaList[i].UpdateDate[k].ToShortDateString()))        //если дата и имя столбца совпадают, пишем сюда
                        {
                            dgv_Keywords.Rows[index].Cells[j].Value = scaList[i].Value[k];
                        }
                    }
                }
            }

            //считаем количество ключей
            int cnt = dgv_Keywords.RowCount;
            if (cnt == 1)
                this.Text = "История ключей  - " + cnt + " ключ - Bona Fides";
            else if (cnt == 2 || cnt == 3 || cnt == 4)
                this.Text = "История ключей  - " + cnt + " ключа - Bona Fides";
            else if (cnt >= 5 && cnt <= 19)
                this.Text = "История ключей  - " + cnt + " ключей - Bona Fides";
            else
            {
                if (cnt % 10 == 1)
                    this.Text = "История ключей  - " + cnt + " ключ - Bona Fides";
                else if (cnt % 10 == 2 || cnt % 10 == 3 || cnt % 10 == 4)
                    this.Text = "История ключей  - " + cnt + " ключа - Bona Fides";
                else if (cnt % 10 >= 5 || cnt % 10 <= 9 || cnt % 10 == 0)
                    this.Text = "История ключей  - " + cnt + " ключей - Bona Fides";
            }
        }

        /* Создаем столбцы в dgv_Keywords по уникальным датам */
        private void DrawColumns()
        {
            dgv_Keywords.Rows.Clear();
            dgv_Keywords.Columns.Clear();

            dgv_Keywords.Columns.Add("tpid", "tpid");
            dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].Visible = false;

            dgv_Keywords.Columns.Add("ctid", "ctid");
            dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].Visible = false;

            dgv_Keywords.Columns.Add("scid", "scid");
            dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].Visible = false;

            dgv_Keywords.Columns.Add("ctname", "Категория ключей");
            dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].Width = 200;
            dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv_Keywords.Columns.Add("tpname", "Вид товара");
            dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].Width = 200;
            dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv_Keywords.Columns.Add("keeey", "Ключ");
            dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].Width = 250;
            dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;


            //создаем колонки по уникальным датам
            for (int i = 0; i < uniqueDTKeyList.Count; i++)
            {
                dgv_Keywords.Columns.Add(uniqueDTKeyList[i].ToShortDateString(), uniqueDTKeyList[i].ToShortDateString());
                dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].Width = 75;
                dgv_Keywords.Columns[dgv_Keywords.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv_Keywords.Visible = true;
        }

        /* Получаем список уникальных дат */
        private void GetUniqueDates()
        {
            for (int i = 0; i < scaList.Count; i++)
            {
                scaController.TransformStringToValuesAndDates(scaList[i].ValuesAndDates);
                
                for (int j = 0; j < dtKeyList.Count; j++)
                {
                    allDTKeyList.Add(new DateTime(dtKeyList[j].Year, dtKeyList[j].Month, dtKeyList[j].Day));
                    scaList[i].Value.Add(valKeyList[j]);
                    scaList[i].UpdateDate.Add(dtKeyList[j]);
                }
            }

            uniqueDTKeyList = allDTKeyList.Distinct().ToList();
            uniqueDTKeyList.Sort((x, y) => y.CompareTo(x));     //сортируем в обратном порядке
        }

        /* Получаем список дат для ключа */
        public void GetDatesForKey(List<DateTime> _dtL)
        {
            dtKeyList = _dtL;
        }

        /* Получаем список частот для ключа */
        public void GetValuesForKey(List<int> _valL)
        {
            valKeyList = _valL;
        }







        /* Поиск ключа в таблице при наборе текста в tb_FindKeyword */
        private void rtb_FindKeyword_TextChanged(object sender, EventArgs e)
        {
            StartKeySearch();
        }

        /* Метод для поиска ключа в таблице */
        private void StartKeySearch()
        {
            int cnt = 0;
            //5 колонка - ключ
            for (int i = 0; i < dgv_Keywords.RowCount; i++)
            {
                if (dgv_Keywords.Rows[i].Cells[5].Value.ToString().ToLower().Contains(rtb_FindKeyword.Text.ToLower()) && !rtb_FindKeyword.Text.Equals(""))
                {
                    dgv_Keywords.Rows[i].Cells[5].Style.BackColor = foundedKeywordColor;
                    cnt++;
                }
                else
                    dgv_Keywords.Rows[i].Cells[5].Style.BackColor = Color.White;
            }
            if (rtb_FindKeyword.TextLength > 0 && dgv_Keywords.RowCount > 0)
            {
                label2.Text = "Найдено: " + cnt.ToString();
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }


        /* Экспорт в *.xlsx */
        private void btn_Export_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            label3.Visible = true;

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            
            for (int i = 3; i < dgv_Keywords.ColumnCount; i++)
            {
                ExcelApp.Cells[i - 2] = dgv_Keywords.Columns[i].HeaderText;
                ExcelWorkSheet.Columns[i + 1].ColumnWidth = 12;
                ExcelWorkSheet.Columns[i + 1].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            }


            for (int i = 0; i < dgv_Keywords.Rows.Count; i++)
            {
                for (int j = 3; j < dgv_Keywords.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 2, j - 2] = dgv_Keywords.Rows[i].Cells[j].Value;
                }
            }

            ExcelWorkSheet.get_Range("A1", "A1").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ExcelWorkSheet.get_Range("B1", "B1").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ExcelWorkSheet.get_Range("C1", "C1").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            ExcelWorkSheet.Columns[1].ColumnWidth = 30;
            ExcelWorkSheet.Columns[2].ColumnWidth = 30;
            ExcelWorkSheet.Columns[3].ColumnWidth = 50;

            saveFileDialog1.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";

            saveFileDialog1.FileName = "Keyword Book 1";

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

            label3.Visible = false;
            this.Enabled = true;
        }
    }
}
