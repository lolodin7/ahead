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
        private KeywordCategoryView ControlKeywordCategoryView;

        private FullSemCoreController fscController;
        private List<FullSemCoreModel> fscList;

        private KeywordCategoryController kcController;
        private List<KeywordCategoryModel> kcList;

        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;

        private SqlConnection connection;
        private SqlCommand command;

        private string AllProductTypesCBName = "Все виды товаров";
        private string AllKeywordCategoriesCBName = "Все категории ключей";

        private bool firstLaunch = true;

        private Color foundedKeywordColor = Color.DeepSkyBlue;

        private bool SaveEditTrigger;       //true - add keyword, false - edit keyword
        private int ProductTypeId, KeyCategoryId;

        private int CurrentSemCoreId;

        public bool NoProdType { get; set; }
        public bool NoKeyCat { get; set; }

        

        /* Вызываем из KeywordsAreExisted для редактирования ключей из таблицы */
        public FullSemCoreView(KeywordsAreExistedView _form, string[,] arr)
        {
            InitializeComponent();
            ControlFormKeywordsAreExisted = _form;
            connection = DBData.GetDBConnection();

            NoProdType = false;
            NoKeyCat = false;

            GetStarted();
            firstLaunch = false;
        }

        /* Вызываем из главной формы */
        public FullSemCoreView(MainFormView _mf)
        {
            InitializeComponent();
            ControlFormMF = _mf;

            NoProdType = false;
            NoKeyCat = false;

            GetStarted();
            firstLaunch = false;
        }

        /* Вызываем из FullSemCoreView */
        public FullSemCoreView(FullSemCoreView _mf)
        {
            InitializeComponent();
            ControlFullSemCoreView = _mf;

            NoProdType = false;
            NoKeyCat = false;

            GetStarted();
            firstLaunch = false;
        }

        /* Вызываем из KeywordCategoryView */
        public FullSemCoreView(KeywordCategoryView _mf, string _categoryName, string _prodTypeName)
        {
            InitializeComponent();
            ControlKeywordCategoryView = _mf;

            NoProdType = false;
            NoKeyCat = false;

            GetStarted(_categoryName, _prodTypeName);
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

        /* Выполняем в конструкторе */
        private void GetStarted(string _categoryName, string _prodTypeName)
        {
            ptController = new ProductTypesController(this);
            kcController = new KeywordCategoryController(this);
            fscController = new FullSemCoreController(this);

            ptController.GetProductTypesAll();
            fill_cb_ProductTypes();
            kcController.GetKeywordCategoriesByProductId(GetProductTypeIdFromCB());
            fill_cb_KeywordCategory();
            fscController.GetSemCoreByProductAndCategory(GetProductTypeIdFromCB(), GetKeywordCategoryIdFromCB());

            for (int i = 0; i < cb_ProductType.Items.Count; i++)
            {
                if (cb_ProductType.Items[i].ToString().Equals(_prodTypeName))
                    cb_ProductType.SelectedItem = cb_ProductType.Items[i];
            }

            for (int i = 0; i < cb_KeywordCategory.Items.Count; i++)
            {
                if (cb_KeywordCategory.Items[i].ToString().Equals(_categoryName))
                    cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[i];
            }

            ShowKeywords();
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
                else if (cnt % 10 >=5 || cnt % 10 <= 9 || cnt % 10 == 0)
                    this.Text = "Семантическая база - " + cnt + " ключей - Bona Fides";
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

        /* Получаем ProductTypeId при смене выбранного элемента в cb_ProductType2 */
        private void cb_ProductType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cb_ProductType2.SelectedItem.ToString();
            for (int i = 0; i < ptList.Count; i++)
            {
                if (ptList[i].TypeName.Equals(str))
                {
                    ProductTypeId = ptList[i].ProductTypeId;
                    return;
                }
                ProductTypeId = 0;
            }
        }

        /* Получаем CategoryId при смене выбранного элемента в cb_KeywordCategory2 */
        private void cb_KeywordCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cb_KeywordCategory2.SelectedItem.ToString();
            for (int i = 0; i < kcList.Count; i++)
            {
                if (kcList[i].CategoryName.Equals(str))
                {
                    KeyCategoryId = kcList[i].CategoryId;
                    return;
                }
                KeyCategoryId = 0;
            }
        }

        /* Получаем набор ключей по категории и виду товара после нажатия кнопки */
        private void btn_GetKeywords_Click(object sender, EventArgs e)
        {
            ShowKeywords();
        }

        private void ShowKeywords()
        {
            fscController.GetSemCoreByProductAndCategory(GetProductTypeIdFromCB(), GetKeywordCategoryIdFromCB());
            ReDrawKeywords();
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
            else if (ControlKeywordCategoryView != null)
            {
                ControlKeywordCategoryView.Visible = true;
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

        /* Ходим по результатам поиска в таблице по нажатию Enter */
        private void tb_FindKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (rtb_FindKeyword.Text != "" && e.KeyCode == Keys.Enter && dgv_Keywords.RowCount > 0)
            {
                if (dgv_Keywords.CurrentRow.Index + 1 < dgv_Keywords.Rows.Count)
                {
                    for (int i = dgv_Keywords.CurrentRow.Index + 1; i < dgv_Keywords.Rows.Count; i++)
                    {
                        if (dgv_Keywords.Rows[i].Cells[2].Style.BackColor == foundedKeywordColor)
                        {
                            dgv_Keywords.ClearSelection();
                            dgv_Keywords.Rows[i].Cells[2].Selected = true;
                            dgv_Keywords.CurrentCell = dgv_Keywords.Rows[i].Cells[2];
                            e.SuppressKeyPress = true;          //отключили системный звук, который возникал при нажатии Enter
                            return;
                        }
                    }
                    e.SuppressKeyPress = true;          //отключили системный звук, который возникал при нажатии Enter
                    MessageBox.Show("Достигнут последний результат поиска!", "Конец");
                }
                else
                    MessageBox.Show("Достигнут конец таблицы!", "Конец");
            }
            else if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;          //отключили системный звук, который возникал при нажатии Enter
        }

        /* Изменяем видимость label2, отображающей количество результатов поиска */
        private void label2_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(label2.Text.Substring(9)) > 0)
                label2.Visible = true;
            else
                label2.Visible = false;
        }

        /* Нажатие кнопки "Добавление нового ключа" */
        private void btn_StartAddingKey_Click(object sender, EventArgs e)
        {
            SaveEditTrigger = true;
            groupBox_Editing.Text = "Добавление нового ключа";
            groupBox_Editing.Enabled = true;

            rtb_KeyName.Text = "";
            rtb_KeyValue.Text = "";
            cb_KeywordCategory2.SelectedItem = cb_KeywordCategory2.Items[0];
            cb_ProductType2.SelectedItem = cb_ProductType2.Items[0];
        }

        /* Включаем редактирование ключа по двойному ЛКМ в таблице */
        private void dgv_Keywords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SaveEditTrigger = false;
                groupBox_Editing.Text = "Редактирование ключа";
                groupBox_Editing.Enabled = true;

                rtb_KeyName.Text = dgv_Keywords.Rows[e.RowIndex].Cells[2].Value.ToString();
                rtb_KeyValue.Text = dgv_Keywords.Rows[e.RowIndex].Cells[3].Value.ToString();

                for (int i = 0; i < cb_ProductType2.Items.Count; i++)
                {
                    if (cb_ProductType2.Items[i].ToString().Equals(dgv_Keywords.Rows[e.RowIndex].Cells[10].Value.ToString()))
                    {
                        cb_ProductType2.SelectedItem = cb_ProductType2.Items[i];
                    }
                }

                for (int i = 0; i < cb_KeywordCategory2.Items.Count; i++)
                {
                    if (cb_KeywordCategory2.Items[i].ToString().Equals(dgv_Keywords.Rows[e.RowIndex].Cells[7].Value.ToString()))
                    {
                        cb_KeywordCategory2.SelectedItem = cb_KeywordCategory2.Items[i];
                    }
                }

                CurrentSemCoreId = int.Parse(dgv_Keywords.Rows[e.RowIndex].Cells[5].Value.ToString());
            }
        }

        /* Сохраняем изменения/добавляем новый ключ в БД */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //сохраняем в БД в зависимости от триггера, add или edit
            if (!rtb_KeyName.Text.Equals("") && !rtb_KeyValue.Text.Equals(""))
            {
                int res;
                if (SaveEditTrigger)
                    res = fscController.SetNewKeywordToSemCore(ProductTypeId, KeyCategoryId, rtb_KeyName.Text, int.Parse(rtb_KeyValue.Text), DateTime.Now);
                else
                    res = fscController.SetEditedKeywordToSemCore(ProductTypeId, KeyCategoryId, rtb_KeyName.Text, int.Parse(rtb_KeyValue.Text), DateTime.Now, CurrentSemCoreId);
                
                if (res == -2146232060)
                {
                    MessageBox.Show("Такой ключ уже существует в системе.", "Ошибка");
                }
                else
                {
                    groupBox_Editing.Enabled = false;
                    rtb_KeyName.Text = "";
                    rtb_KeyValue.Text = "";
                    cb_KeywordCategory2.SelectedItem = cb_KeywordCategory2.Items[0];
                    cb_ProductType2.SelectedItem = cb_ProductType2.Items[0];

                    MessageBox.Show("Данные были успешно сохранены. Обновите таблицу, чтобы увидеть внесенные изменения.", "Успех");
                }
            }
            else
                MessageBox.Show("Заполните все поля!", "Ошибка");                
        }

        private void rtb_KeyValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void dgv_Keywords_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgv_Keywords.RowCount >= 0 && e.RowIndex >= 0)      //если таблица пустая, чтобы не было ошибки
                {
                    dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    if (MessageBox.Show("Ключ \"" + dgv_Keywords.Rows[e.RowIndex].Cells[2].Value.ToString() + "\" будет удален. Вы уверены?", "Удаление ключа", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        fscController.DeleteKeywordFromSemCore(int.Parse(dgv_Keywords.Rows[e.RowIndex].Cells[5].Value.ToString()));
                        MessageBox.Show("Ключ был успешно удален. Обновите таблицу, чтобы увидеть внесенные изменения.", "Успех");
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            groupBox_Editing.Enabled = false;
            rtb_KeyName.Text = "";
            rtb_KeyValue.Text = "";
            cb_KeywordCategory2.SelectedItem = cb_KeywordCategory2.Items[0];
            cb_ProductType2.SelectedItem = cb_ProductType2.Items[0];
        }

    }
}

