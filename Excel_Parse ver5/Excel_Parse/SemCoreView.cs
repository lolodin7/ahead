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
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;

namespace Excel_Parse
{
    public partial class SemCoreView : Form
    {
        private SemCoreController scController;
        private List<SemCoreModel> scmList;     //список всех объектов (записей из БД)

        private KeywordCategoryController kcController;
        private List<KeywordCategoryModel> kcList;

        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;

        private int CurrentColumnCount;
        
        private MainFormView mf;
        private bool SavedStatus = true;
        private string path = "";

        private int currentProductTypeId = -1;

        public bool NoProdType { get; set; }
        public bool NoKeyCat { get; set; }


        /* Конструктор */
        public SemCoreView(MainFormView _mf)
        {
            InitializeComponent();
            CurrentColumnCount = 0;
            
            mf = _mf;

            scController = new SemCoreController(this);
            kcController = new KeywordCategoryController(this);
            ptController = new ProductTypesController(this);

            NoProdType = false;
            NoKeyCat = false;

                ptController.GetProductTypesAll();
            Fill_CB_ByProductTypes();
            kcController.GetKeywordCategoriesByProductId(currentProductTypeId);
            Fill_CB_ByKeywordCategories();

            tb_Link.Text = mf.AmazonLink;
        }


        public void RefreshKeywordCategories()
        {
            kcController.GetKeywordCategoriesByProductId(currentProductTypeId);
            Fill_CB_ByKeywordCategories();
        }

        /* Загружаем новые ключи из файла */
        public void OpenNewFile()
        {
            bool isExcel = false;
            bool isCsv = false;

            openFileDialog1.Filter = "Неразмеченные файлы|*.csv;*.txt|Excel файлы (*.xlsx)|*.xlsx";
            openFileDialog1.Title = "Выбор файла для открытия";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                if (path.Contains(".xlsx"))
                    isExcel = true;
                else if (path.Contains(".csv"))
                    isCsv = true;

                dgv_Source.Rows.Clear();
                dgv_Target.Rows.Clear();

                if (isCsv)
                {
                    try
                    {
                        using (TextFieldParser parser = new TextFieldParser(@path))
                        {
                            parser.TextFieldType = FieldType.Delimited;
                            if (radioButton1.Checked)
                                parser.SetDelimiters(radioButton1.Text);
                            else if (radioButton2.Checked)
                                parser.SetDelimiters(radioButton2.Text);
                            else
                                parser.SetDelimiters(tb_OwnDelimiter.Text);

                            while (!parser.EndOfData)
                            {
                                //Process row
                                string[] fields = parser.ReadFields();

                                var index = dgv_Source.Rows.Add();
                                int i = 0;

                                foreach (string field in fields)
                                {
                                    if (i == 1)
                                        dgv_Source.Rows[index].Cells[i].Value = double.Parse(field);
                                    else
                                        dgv_Source.Rows[index].Cells[i].Value = field;
                                    i++;
                                }
                            }
                        }

                        SavedStatus = true;
                        label3.Visible = false;
                        dgv_Source.Visible = true;
                        dgv_Target.Visible = true;
                        btn_SelectAll.Visible = true;
                        btn_DeselectAll.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                        dgv_Source.Rows.Clear();
                    }
                    dgv_Source.Focus();
                } 
                else if (isExcel)
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
                                var index = dgv_Source.Rows.Add();

                                for (int col = 1; col <= colCount; col++)
                                {
                                    if (col == 2)
                                        dgv_Source.Rows[index].Cells[col - 1].Value = double.Parse(worksheet.Cells[row, col].Value.ToString().Trim());
                                    else
                                        dgv_Source.Rows[index].Cells[col - 1].Value = worksheet.Cells[row, col].Value.ToString().Trim();
                                }
                            }
                        }

                        SavedStatus = true;
                        label3.Visible = false;
                        dgv_Source.Visible = true;
                        dgv_Target.Visible = true;
                        btn_SelectAll.Visible = true;
                        btn_DeselectAll.Visible = true;
                        dgv_Source.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                        dgv_Source.Rows.Clear();
                    }
                }
            }
        }
        
        /* Получаем из контроллера данные, полученные с БД */
        public void GetDataFromDB(object _scmList)
        {
            scmList = (List<SemCoreModel>)_scmList;
        }

        /* Получаем из контроллера KeywordCategories, полученные с БД */
        public void GetCategoriesFromDB(object _kcList)
        {
            kcList = (List<KeywordCategoryModel>)_kcList;
        }

        /* Получаем из контроллера ProductTypes, полученные с БД */
        public void GetProductTypesFromDB(object _ptList)
        {
            ptList = (List<ProductTypesModel>)_ptList;
        }

        /* Заполняем cb_ProductType данными с ptList */
        private void Fill_CB_ByProductTypes()
        {
            if (ptList.Count > 0)
            {
                cb_ProductType.Items.Clear();
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

        /* Заполняем cb_KeywordCategory данными с kcList */
        private void Fill_CB_ByKeywordCategories()
        {
            if (kcList.Count > 0)
            {
                cb_KeywordCategory.Items.Clear();
                for (int i = 0; i < kcList.Count; i++)
                {
                    cb_KeywordCategory.Items.Add(kcList[i].CategoryName);
                }
                if (kcList.Count > 0)
                    cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[0];
            }
            else
            {
                MessageBox.Show("Видимо, в системе нет ни одной категории ключей. Для работы в этом разделе, пожалуйста, сначала добавьте хотя бы одну категорию ключей.", "Ошибка");
                NoKeyCat = true;
            }
        }
        
        /* Обработчик нажатия клавиши в dgv_Source */
        private void dgv_Source_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                //Check
                dgv_Check((DataGridView)sender);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.X)
            {
                //Uncheck
                dgv_UnCheck((DataGridView)sender);
                e.Handled = true;
            } else if (e.KeyCode == Keys.Space)
            {
                if (dgv_Source.RowCount > 0)
                {
                    DataGridView send = (DataGridView)sender;
                    string str = dgv_Source.Rows[send.CurrentCellAddress.Y].Cells[send.CurrentCellAddress.X].Value.ToString();
                    System.Diagnostics.Process.Start(tb_Link.Text + dgv_Source.Rows[send.CurrentCellAddress.Y].Cells[send.CurrentCellAddress.X].Value.ToString());
                    e.Handled = true;
                }
            }
        }

        /* Ищем на амазоне товары по ключу, на который дважды ЛКМ */
        private void dgv_Source_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                System.Diagnostics.Process.Start(tb_Link.Text + dgv_Source.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        /* Помечаем ключ в таблице dgv_Source */
        private void dgv_Check(DataGridView sender)
        {
            if (sender.CurrentCellAddress.X == 0)
            {
                sender.Rows[sender.CurrentCellAddress.Y].Cells[sender.CurrentCellAddress.X].Style.ForeColor = Color.Red;
                Refresh_dgvTarget_Add();
            }
        }

        /* Добавляем помеченный ключ в dgv_Target */
        private void Refresh_dgvTarget_Add()
        {
            bool flag = true;
            if (dgv_Target.RowCount > 0)
            {
                string str = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[dgv_Source.CurrentCellAddress.X].Value.ToString();
                for (int i = 0; i < dgv_Target.RowCount; i++)
                {
                    if (dgv_Target.Rows[i].Cells[0].Value.ToString().Equals(str))
                    {
                        flag = false;
                    }
                }
                if (flag || dgv_Target.RowCount == 0)
                {
                    var index = dgv_Target.Rows.Add();

                    dgv_Target.Rows[index].Cells[0].Value = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[0].Value.ToString();
                    dgv_Target.Rows[index].Cells[1].Value = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[1].Value.ToString();
                }
            } else
            {
                var index = dgv_Target.Rows.Add();

                dgv_Target.Rows[index].Cells[0].Value = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[0].Value.ToString();
                dgv_Target.Rows[index].Cells[1].Value = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[1].Value.ToString();
            }
        }

        /* Снимает пометку ключа в таблице dgv_Source */
        private void dgv_UnCheck(DataGridView sender)
        {
            if (sender.CurrentCellAddress.X == 0)
            {
                sender.Rows[sender.CurrentCellAddress.Y].Cells[sender.CurrentCellAddress.X].Style.ForeColor = Color.Black;
                Refresh_dgvTarget_Del();
            }
        }

        /* Удаляем ключ из dgv_Target при снятии его выделения в dgv_Source */
        private void Refresh_dgvTarget_Del()
        {
            if (dgv_Target.RowCount > 0)
            {
                string str = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[dgv_Source.CurrentCellAddress.X].Value.ToString();
                for (int i = 0; i < dgv_Target.RowCount; i++)
                {
                    if (dgv_Target.Rows[i].Cells[0].Value.ToString().Equals(str))
                    {
                        dgv_Target.Rows.RemoveAt(i);
                    }
                }
            }
        }

        /* Отслеживание несохраненных изменений */
        private void dgv_Target_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SavedStatus = false;
        }

        /* Отслеживание несохраненных изменений */
        private void dgv_Target_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SavedStatus = false;
        }

        /* Вызываем Help */
        private void btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для начала откройте файл с ключевыми словами при помощи кнопки \"Загрузить другой файл\".\n\nИспользуйте клавишу \"C\" для выделения ключевого слова.\nИспользуйте клавишу \"X\" для снятия выделения ключевого слова.\n\nДважды клацните ЛКМ по ключевому слову, чтобы просмотреть его на Amazon.", "Помощь");
        }

        /* Ищем на амазоне товары по ключу, на который дважды ЛКМ */
        private void dgv_Target_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                System.Diagnostics.Process.Start(tb_Link.Text + dgv_Target.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        /* Включаем/выключаем возможность редактирования ссылки для перехода на Амазон */
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tb_Link.Enabled = true;
            }
            else
            {
                tb_Link.Enabled = false;
                mf.AmazonLink = tb_Link.Text;
            }
        }

        /* Загрузить другой файл */
        private void btn_UploadAnotherFile_Click(object sender, EventArgs e)
        {
            if (SavedStatus)
            {
                OpenNewFile();
            }
            else
            {
                if (MessageBox.Show("Имеются несохраненные изменения. Сохранить?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    setDataToDB();
                    OpenNewFile();
                }
                else
                {
                    OpenNewFile();
                }
            }
        }

        /* Закрытие формы */
        private void SemCore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SavedStatus)
            {
                mf.Show();
            }
            else
            {
                if (MessageBox.Show("Имеются несохраненные изменения. Сохранить?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    setDataToDB();
                    mf.Show();
                }
                else
                {
                    SavedStatus = true;
                    mf.Show();
                }
            }
        }

        /* Кнопка "Сохранить" */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (dgv_Target.RowCount == 0)
            {
                MessageBox.Show("Нет данных для сохранения", "Нет данных");
            }
            else
            {
                if (MessageBox.Show("Сохранить выбранные ключи в категорию " + cb_KeywordCategory.SelectedItem.ToString() + "?", "Подтвердите действие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    setDataToDB();
                }
            }
        }

        /* Кнопка "Закрыть" */
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (SavedStatus)
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("Имеются несохраненные изменения. Сохранить?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    setDataToDB();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        /* Загрузка изменений в БД */
        private void setDataToDB()
        {
            int productType = -1;
            string errors = "";
            string errorsToCopy = "";
            int categoryId = -1;

            //находим productTypeId по выбранному в cb_ProductType 
            productType = currentProductTypeId;


            for (int i = 0; i < kcList.Count; i++)     //находим keywordCategoryId по выбранному в cb_CategoryId
            {
                if (kcList[i].CategoryName.Equals(cb_KeywordCategory.SelectedItem.ToString()))
                {
                    categoryId = kcList[i].CategoryId;
                }
            }

            if (productType == -1 || categoryId == -1)
            {
                MessageBox.Show("Выберите вид продукта и категорию ключей.", "Ошибка");
                return;
            }
            int index = -1;

            for (int i = 0; i < dgv_Target.RowCount; i++)
            {
                index = i;
                int val = 0;
                try { val = int.Parse(dgv_Target.Rows[i].Cells[1].Value.ToString());  } catch (Exception exx) { val = 0; }
                //если ключ уже есть в БД, БД выдаст ошибку -2146232060. Сверяем и записываем ключи в массив недобавленных ключей
                if (scController.InsertNewKeyword(productType, categoryId, dgv_Target.Rows[i].Cells[0].Value.ToString(), val, DateTime.Now) == -2146232060)
                {
                    errors += dgv_Target.Rows[index].Cells[0].Value.ToString() + "\n";
                    errorsToCopy += dgv_Target.Rows[index].Cells[0].Value.ToString() + "\t" + val + "\n";
                }
            }

            if (!errors.Equals(""))
            {
                MessageBox.Show("Следующие ключи не были добавлены, т.к. они уже есть в БД. Эти ключи были скопированы и сейчас находятся в буфере обмена. Можете вставить их в Excel или любой текстовый редактор. Ниже приведен список этих ключей:\n\n" + errors, "Не всё прошло гладко");
                Clipboard.SetText(errorsToCopy);
            }
            else
                MessageBox.Show("Все ключи были успешно добавлены!", "Успех");

            SavedStatus = true;
        }

        /* Выделяем все ключи */
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Source.RowCount; i++)
            {
                dgv_Source.Rows[i].Cells[0].Style.ForeColor = Color.Red;

                var index = dgv_Target.Rows.Add();
                dgv_Target.Rows[index].Cells[0].Value = dgv_Source.Rows[i].Cells[0].Value.ToString();
                if (dgv_Source.Rows[i].Cells[1].Value != null)
                    dgv_Target.Rows[index].Cells[1].Value = dgv_Source.Rows[i].Cells[1].Value.ToString();
            }  
        }

        /* Снимаем выделение со всех ключей */
        private void btn_DeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Source.RowCount; i++)
            {
                dgv_Source.Rows[i].Cells[0].Style.ForeColor = Color.Black;
            }
            dgv_Target.Rows.Clear();
        }

        /* Меняем вид товара и получаем соответствующий список категорий ключей */
        private void cb_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ptList.Count; i++)
            {
                if (cb_ProductType.SelectedItem.ToString().Equals(ptList[i].TypeName))
                {
                    tb_ProductTypeId.Text = ptList[i].ProductTypeId.ToString();
                    currentProductTypeId = int.Parse(ptList[i].ProductTypeId.ToString());
                }
            }

            kcController.GetKeywordCategoriesByProductId(currentProductTypeId);
            Fill_CB_ByKeywordCategories();
        }

        /* Добавить новую категорию ключей */
        private void btn_addKeywordCategory_Click(object sender, EventArgs e)
        {
            KeywordCategoryView keycat = new KeywordCategoryView(this);
            keycat.Show();
            this.Visible = false;
        }

        /* Добавляем новый ключ вручную */
        private void btn_AddCustomKeyword_Click(object sender, EventArgs e)
        {
            bool isExist = false;

            if (!tb_CustomKey.Text.Equals("") && !tb_CustomValue.Text.Equals(""))
            {
                for (int i = 0; i < dgv_Target.RowCount; i++)
                {
                    if (dgv_Target.Rows[i].Cells[0].Value.ToString().Equals(tb_CustomKey.Text))
                        isExist = true;
                }

                if (!isExist)
                {
                    var index = dgv_Target.Rows.Add();

                    dgv_Target.Rows[index].Cells[0].Value = tb_CustomKey.Text;
                    dgv_Target.Rows[index].Cells[1].Value = tb_CustomValue.Text;
                }

                tb_CustomKey.Text = "";
                tb_CustomValue.Text = "";
            }
        }

        /* Проверяем символ на цифру при вводе в поле tb_CustomValue */
        private void tb_CustomValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void dgv_Target_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X)
            {
                //Check
                dgv_UnCheck2((DataGridView)sender);
                e.Handled = true;
            }
        }


        /* Снимает пометку ключа в таблице dgv_Source */
        private void dgv_UnCheck2(DataGridView sender)
        {
            if (sender.CurrentCellAddress.X == 0)
            {
                Refresh_dgvTarget_Del2();
            }
        }

        /* Удаляем ключ из dgv_Target при снятии его выделения в dgv_Source */
        private void Refresh_dgvTarget_Del2()
        {
            if (dgv_Source.RowCount > 0)
            {
                string str = dgv_Target.Rows[dgv_Target.CurrentCellAddress.Y].Cells[dgv_Target.CurrentCellAddress.X].Value.ToString();
                for (int i = 0; i < dgv_Source.RowCount; i++)
                {
                    if (dgv_Source.Rows[i].Cells[0].Value.ToString().Equals(str))
                    {
                        //dgv_Source.Rows.RemoveAt(i);
                        dgv_Source.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                    }
                }
                dgv_Target.Rows.RemoveAt(dgv_Target.CurrentCellAddress.Y);
            }
        }

        private void tb_OwnDelimiter_TextChanged(object sender, EventArgs e)
        {
            if (tb_OwnDelimiter.Text.Length > 0)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            else
                radioButton1.Checked = true;
        }
    }
}
