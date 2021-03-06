﻿using System;
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


        /* Конструктор */
        public SemCoreView(MainFormView _mf)
        {
            InitializeComponent();
            CurrentColumnCount = 0;
            
            mf = _mf;

            scController = new SemCoreController(this);
            kcController = new KeywordCategoryController(this);
            ptController = new ProductTypesController(this);

            kcController.GetKeywordCategoriesAll();
            ptController.GetProductTypesAll();
            Fill_CB_ByKeywordCategories();
            Fill_CB_ByProductTypes();

            tb_Link.Text = mf.AmazonLink;
        }


        /* Конструктор */
        public SemCoreView()
        {
            InitializeComponent();
            CurrentColumnCount = 0;

            scController = new SemCoreController(this);
            kcController = new KeywordCategoryController(this);
            ptController = new ProductTypesController(this);

            kcController.GetKeywordCategoriesAll();
            ptController.GetProductTypesAll();
            Fill_CB_ByKeywordCategories();
            Fill_CB_ByProductTypes();            
        }

        /* Загружаем новые ключи из файла */
        public void OpenNewFile()
        {
            openFileDialog1.Filter = "Выбери файл|*.csv;*.txt";
            openFileDialog1.Title = "Выбор файла для открытия";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                tb_AddCategory.Text = "";
                rb_ExistingCategory.Checked = true;
                dgv_Source.Rows.Clear();
                dgv_Target.Rows.Clear();

                try
                {
                    using (TextFieldParser parser = new TextFieldParser(@path))
                    {

                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                }
                SavedStatus = true;
                dgv_Source.Focus();
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
            cb_ProductType.Items.Clear();
            for (int i = 0; i < ptList.Count; i++)
            {
                cb_ProductType.Items.Add(ptList[i].TypeName);
            }
            cb_ProductType.SelectedItem = cb_ProductType.Items[0];
        }

        /* Заполняем cb_KeywordCategory данными с kcList */
        private void Fill_CB_ByKeywordCategories()
        {
            cb_KeywordCategory.Items.Clear();
            for (int i = 0; i < kcList.Count; i++)
            {
                cb_KeywordCategory.Items.Add(kcList[i].CategoryName);
            }
            cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[0];
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

        /* Изменяем метод ввода имени */
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ExistingCategory.Checked)
            {
                tb_AddCategory.Enabled = false;
                cb_KeywordCategory.Enabled = true;
            }
            else
            {
                tb_AddCategory.Enabled = true;
                cb_KeywordCategory.Enabled = false;
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
                setDataToDB();
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
            int categoryId = -1;
            bool categoryCreated = true;

            if (rb_NewCategory.Checked)        //сохраняем в новой categoryId
            {
                int result = kcController.SetNewKeywordCategory(tb_AddCategory.Text);
                if (result == 1)
                {
                    kcController.GetKeywordCategoriesAll();
                    Fill_CB_ByKeywordCategories();
                    cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[cb_KeywordCategory.Items.Count - 1];
                }
                else if (result == -2146232060)
                {
                    MessageBox.Show("Вы пытаетесь создать категорию ключей, которая уже существует. Пожалуйста, выберите категорию со списка или введите другое название.", "Ошибка");
                    categoryCreated = false;
                }
            }

            if (categoryCreated)                            //проверяем на то, что при создании категории всё было ок и можно продолжать
            {
                for (int i = 0; i < ptList.Count; i++)     //находим productTypeId по выбранному в cb_ProductType
                {
                    if (ptList[i].TypeName.Equals(cb_ProductType.SelectedItem.ToString()))
                    {
                        productType = ptList[i].ProductTypeId;
                    }
                }

                for (int i = 0; i < kcList.Count; i++)     //находим productTypeId по выбранному в cb_ProductType
                {
                    if (kcList[i].CategoryName.Equals(cb_KeywordCategory.SelectedItem.ToString()))
                    {
                        categoryId = kcList[i].CategoryId;
                    }
                }

                int index = -1;

                for (int i = 0; i < dgv_Target.RowCount; i++)
                {
                    index = i;
                    //если ключ уже есть в БД, БД выдаст ошибку -2146232060. Сверяем и записываем ключи в массив недобавленных ключей
                    if (scController.InsertNewKeyword(productType, categoryId, dgv_Target.Rows[i].Cells[0].Value.ToString(), int.Parse(dgv_Target.Rows[i].Cells[1].Value.ToString()), DateTime.Now) == -2146232060)
                    {
                        errors += dgv_Target.Rows[index].Cells[0].Value.ToString() + "\n";
                    }
                }

                if (!errors.Equals(""))
                    MessageBox.Show("Следующие ключи не были добавлены, т.к. они уже есть в БД:\n\n" + errors, "Не всё прошло гладко");
                else
                    MessageBox.Show("Все ключи были успешно добавлены!", "Успех");

                SavedStatus = true;
            }
        }

        /* Выделяем все ключи */
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Source.RowCount; i++)
            {
                dgv_Source.Rows[i].Cells[0].Style.ForeColor = Color.Red;

                var index = dgv_Target.Rows.Add();
                dgv_Target.Rows[index].Cells[0].Value = dgv_Source.Rows[i].Cells[0].Value.ToString();
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
    }
}
