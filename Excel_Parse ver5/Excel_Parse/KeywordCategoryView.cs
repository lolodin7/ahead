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
        private int CurrentColumnCount;

        private SemCoreRebuildView controlSemCoreRebuildView;
        private SqlConnection connection;

        private bool wasAdded = false;


        public KeywordCategoryView(SemCoreRebuildView _mf)
        {
            InitializeComponent();
            CurrentColumnCount = 0;

            kcController = new KeywordCategoryController(this);
            
            connection = DBData.GetDBConnection();
            controlSemCoreRebuildView = _mf;

            kcController.GetKeywordCategoriesAll();
            Draw();
        }

        public KeywordCategoryView()
        {
            InitializeComponent();
            CurrentColumnCount = 0;

            kcController = new KeywordCategoryController(this);

            connection = DBData.GetDBConnection();

            kcController.GetKeywordCategoriesAll();
            Draw();
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
            }
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetCategoriesFromDB(object _kcmList)
        {
            kcmList = (List<KeywordCategoryModel>)_kcmList;
        }

        /* Перерисовываем пустую таблицу на 2 столбцa */
        public void RefreshTable_2()
        {
            dgv_KeywordCategory.Columns.Clear();
            AddColumns_2();
        }


        /* Программно создаем столбцы в dataGridView */
        public void AddColumns_2()
        {
            dgv_KeywordCategory.Columns.Add("categoryIdCl", "categoryIdCl");
            dgv_KeywordCategory.Columns.Add("productTypeIdCl", "Название категории");

            dgv_KeywordCategory.Columns[1].Width = 263;

            dgv_KeywordCategory.Columns[0].Visible = false;

            dgv_KeywordCategory.Width = 293;
            dgv_KeywordCategory.ScrollBars = ScrollBars.Vertical;

            CurrentColumnCount = 2;
        }
       


        /* Добавить новую категори в БД */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (tb_CategoryName.Text != "")
            {
                if (!ChechForExisting())
                {
                    int result = kcController.SetNewKeywordCategory(tb_CategoryName.Text); //вызываем метод для записи в БД и проверяем сразу на успешность
                    if (result == 1)      
                    {
                        kcController.GetKeywordCategoriesAll();
                        Draw();
                        wasAdded = true;
                        MessageBox.Show("Категория \"" + tb_CategoryName.Text + "\" была добавлена успешно!", "Успешно");
                        tb_CategoryName.Text = "";
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

        private void KeywordCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlSemCoreRebuildView.NewCategoryWasAdded(wasAdded);
            this.DialogResult = DialogResult.Cancel;
            controlSemCoreRebuildView.Visible = true;
        }

        /* Закрыть окно */
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Скопировать название категории по двойному ЛКМ на ячейку */
        private void dgv_KeywordCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var str = dgv_KeywordCategory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Clipboard.SetText(str);
        }

        /* Обновляем dgv_KeywordCategory принудительно */
        private void btn_RefreshDGV_Click(object sender, EventArgs e)
        {
            kcController.GetKeywordCategoriesAll();
            Draw();
        }
    }
}
