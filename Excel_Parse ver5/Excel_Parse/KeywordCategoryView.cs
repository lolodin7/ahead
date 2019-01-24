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
    public partial class KeywordCategoryView : Form
    {
        private KeywordCategoryController kcController;
        private List<KeywordCategoryModel> kcmList;     //список всех объектов (записей из БД)

        private ProductTypesController ptController;

        private SemCoreRebuildView controlSemCoreRebuildView;
        private MainFormView controlMainFormView;
        private SemCoreView controlSemCoreView;

        private SqlConnection connection;

        private bool wasAdded = false;

        private List<ProductTypesModel> ptList;
        private List<ProductTypesModel> fullPTList;

        /* Конструктор */
        public KeywordCategoryView(SemCoreRebuildView _mf)
        {
            InitializeComponent();

            kcController = new KeywordCategoryController(this);
            ptController = new ProductTypesController(this);

            connection = DBData.GetDBConnection();
            controlSemCoreRebuildView = _mf;

            kcController.GetKeywordCategoriesJOINProductTypes();
            Draw();

            ptController.GetProductTypesAll();
            fill_cb_ProductTypes();
        }

        /* Конструктор */
        public KeywordCategoryView(MainFormView _mf)
        {
            InitializeComponent();

            kcController = new KeywordCategoryController(this);
            ptController = new ProductTypesController(this);

            connection = DBData.GetDBConnection();
            controlMainFormView = _mf;

            kcController.GetKeywordCategoriesJOINProductTypes();
            Draw();

            ptController.GetProductTypesAll();
            fill_cb_ProductTypes();
        }

        /* Конструктор */
        public KeywordCategoryView(SemCoreView _mf)
        {
            InitializeComponent();

            kcController = new KeywordCategoryController(this);
            ptController = new ProductTypesController(this);

            connection = DBData.GetDBConnection();
            controlSemCoreView = _mf;

            kcController.GetKeywordCategoriesJOINProductTypes();
            Draw();

            ptController.GetProductTypesAll();
            fill_cb_ProductTypes();
        }

        /* Заполняем cb_ProductTypes */
        private void fill_cb_ProductTypes()
        {
            cb_ShownProductType.Items.Clear();
            cb_ShownProductType.Items.Add("Все");
            cb_ProductType.Items.Clear();

            for (int i = 0; i < fullPTList.Count; i++)
            {
                cb_ProductType.Items.Add(fullPTList[i].TypeName);
                cb_ShownProductType.Items.Add(fullPTList[i].TypeName);
            }
            cb_ProductType.SelectedItem = cb_ProductType.Items[0];
            cb_ShownProductType.SelectedItem = cb_ShownProductType.Items[0];
        }

        /* Перерисовываем таблицу новыми данными */
        private void Draw()
        {
            dgv_KeywordCategory.Rows.Clear();

            for (int i = 0; i < kcmList.Count; i++)
            {
                var index = dgv_KeywordCategory.Rows.Add();

                for (int j = 0; j < kcmList[0].ColumnCount; j++)
                {
                    dgv_KeywordCategory.Rows[index].Cells[j].Value = kcmList[i].ReadData(j);
                }

                dgv_KeywordCategory.Rows[index].Cells[3].Value = ptList[i].ReadData(0);
                dgv_KeywordCategory.Rows[index].Cells[4].Value = ptList[i].ReadData(1);

            }
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetCategoriesFromDB(object _kcmList)
        {
            kcmList = (List<KeywordCategoryModel>)_kcmList;
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductTypesFromDB(object _ptList)
        {
            ptList = (List<ProductTypesModel>)_ptList;
        }

        /* Получаем список всех существующих видов товара */
        public void GettFullProductTypesFromDB(object _ptList)
        {
            fullPTList = (List<ProductTypesModel>)_ptList;
        }

        /* Добавить новую категори в БД */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (tb_CategoryName.Text != "")
            {
                if (!ChechForExisting())
                {
                    int result = kcController.SetNewKeywordCategory(tb_CategoryName.Text, int.Parse(tb_ProductTypeId.Text)); //вызываем метод для записи в БД и проверяем сразу на успешность
                    if (result == 1)      
                    {
                        kcController.GetKeywordCategoriesJOINProductTypes();
                        Draw();
                        ptController.GetProductTypesAll();
                        //fill_cb_ProductTypes();
                        wasAdded = true;
                        MessageBox.Show("Категория \"" + tb_CategoryName.Text + "\" была добавлена успешно!", "Успешно");
                        tb_CategoryName.Text = "";
                        tb_CategoryName.Focus();
                    }
                    else if (result == -2146232060)
                    {
                        MessageBox.Show("Такая категория уже существует. Нажмите \"Обновить\" для просмотра.", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Такая категория уже существует!", "Ошибка");           
                }
            }
            else
            {
                MessageBox.Show("Введите название новой категории.", "Ошибка");
            }
        }

        /* Проверка перед сохранение в БД на наличие существующей категории с таким же именем */
        private bool ChechForExisting()
        {
            bool flag = false;

            for (int i = 0; i < dgv_KeywordCategory.RowCount; i++)
            {
                if (dgv_KeywordCategory.Rows[i].Cells[1].Value.ToString().ToLower().Equals(tb_CategoryName.Text.ToLower()))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /* Закрытие формы */
        private void KeywordCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlSemCoreRebuildView != null)
            {
                controlSemCoreRebuildView.NewCategoryWasAdded(wasAdded);
                this.DialogResult = DialogResult.Cancel;
                controlSemCoreRebuildView.Visible = true;
            }
            else if (controlMainFormView != null)
            {
                controlMainFormView.Visible = true;
            }
            else if (controlSemCoreView != null)
            {
                controlSemCoreView.Visible = true;
                controlSemCoreView.RefreshKeywordCategories();
            }
        }

        /* Закрыть окно */
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Скопировать название категории по двойному ЛКМ на ячейку */
        private void dgv_KeywordCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                FullSemCoreView scv = new FullSemCoreView(this, dgv_KeywordCategory.Rows[e.RowIndex].Cells[1].Value.ToString(), dgv_KeywordCategory.Rows[e.RowIndex].Cells[4].Value.ToString());
                scv.Show();
                this.Visible = false;
            }
        }

        /* Обновляем dgv_KeywordCategory принудительно */
        private void btn_RefreshDGV_Click(object sender, EventArgs e)
        {
            kcController.GetKeywordCategoriesJOINProductTypes();
            Draw();
            ptController.GetProductTypesAll();
            fill_cb_ProductTypes();
        }

        /* Изменение ProductTypeId для сохранения при смене вида товара */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < fullPTList.Count; i++)
            {
                if (cb_ProductType.SelectedItem.ToString().Equals(fullPTList[i].TypeName))
                {
                    tb_ProductTypeId.Text = fullPTList[i].ProductTypeId.ToString();
                }
            }
        }

        /* Перерисовка таблицы при изменении выбранного вида товара */
        private void cb_ShownProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 1; i < cb_ShownProductType.Items.Count; i++)       //находим ProductTypeId
            {
                if (cb_ShownProductType.SelectedItem.ToString().Equals(fullPTList[i - 1].TypeName))
                {
                    tb_ShownProductTypes.Text = fullPTList[i - 1].ProductTypeId.ToString();
                    found = true;
                }
            }
            if (found)      //нашли
            {
                kcController.GetKeywordCategoriesJOINProductTypesByProductTypeId(int.Parse(tb_ShownProductTypes.Text));
                Draw();
            }
            else        //не нашли, значит установлено "отобразить всё"
            {
                kcController.GetKeywordCategoriesJOINProductTypes();
                Draw();
            }
        }

        /* Добавляем категорию по нажатию Enter в поле вводе */
        private void tb_CategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_CategoryName.Text != "")
                {
                    if (!ChechForExisting())
                    {
                        int result = kcController.SetNewKeywordCategory(tb_CategoryName.Text, int.Parse(tb_ProductTypeId.Text)); //вызываем метод для записи в БД и проверяем сразу на успешность
                        if (result == 1)
                        {
                            kcController.GetKeywordCategoriesJOINProductTypes();
                            Draw();
                            ptController.GetProductTypesAll();
                            //fill_cb_ProductTypes();
                            wasAdded = true;
                            MessageBox.Show("Категория \"" + tb_CategoryName.Text + "\" была добавлена успешно!", "Успешно");
                            tb_CategoryName.Text = "";
                            tb_CategoryName.Focus();
                        }
                        else if (result == -2146232060)
                        {
                            MessageBox.Show("Такая категория уже существует. Нажмите \"Обновить\" для просмотра.", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такая категория уже существует!", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Введите название новой категории.", "Ошибка");
                }
            }
        }
    }
}
