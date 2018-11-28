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
    public partial class ProductTypesView : Form
    {
        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;     //список всех объектов (записей из БД)
        private int CurrentColumnCount;

        private Form mf;
        private SqlConnection connection;


        public ProductTypesView(MainFormView _mf)
        {
            InitializeComponent();
            CurrentColumnCount = 0;

            ptController = new ProductTypesController(this);

            connection = DBData.GetDBConnection();
            mf = _mf;

            ptController.GetProductTypesAll();
            Draw();
        }

        public ProductTypesView()
        {
            InitializeComponent();
            CurrentColumnCount = 0;

            ptController = new ProductTypesController(this);

            connection = DBData.GetDBConnection();

            ptController.GetProductTypesAll();
            Draw();
        }


        /* Перерисовываем таблицу новыми данными */
        private void Draw()
        {
            dgv_ProductTypes.Rows.Clear();

            for (int i = 0; i < ptList.Count; i++)
            {
                var index = dgv_ProductTypes.Rows.Add();

                for (int j = 0; j < ptList[0].ColumnCount; j++)
                {
                    dgv_ProductTypes.Rows[index].Cells[j].Value = ptList[i].ReadData(j);
                }
            }
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductTypesFromDB(object _ptList)
        {
            ptList = (List<ProductTypesModel>)_ptList;
        }     
        
        /* Добавить новый тип товара в БД */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (tb_ProductType.Text != "")
            {
                if (!ChechForExisting())
                {
                    int result = ptController.SetNewProductType(tb_ProductType.Text);
                    if (result == 1)
                    {
                        tb_ProductType.Text = "";
                        ptController.GetProductTypesAll();
                        Draw();
                    }
                    else if (result == -2146232060)
                    {
                        MessageBox.Show("Такой вид товаров уже существует. Нажмите \"Обновить\" для просмотра.", "Ошибка");
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

            for (int i = 0; i < dgv_ProductTypes.RowCount; i++)
            {
                if (dgv_ProductTypes.Rows[i].Cells[1].Value.ToString().ToLower().Equals(tb_ProductType.Text.ToLower()))
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void ProductTypes_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }

        /* Закрыть окно */
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Скопировать название категории по двойному ЛКМ на ячейку */
        private void dgv_ProductTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var str = dgv_ProductTypes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Clipboard.SetText(str);
        }

        /* Обновляем dgv_KeywordCategory принудительно */
        private void btn_RefreshDGV_Click(object sender, EventArgs e)
        {
            ptController.GetProductTypesAll();
            Draw();
        }
    }
}
