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

        private MainFormView controlMainFormView;

        private bool renamingInProgress;        //указатель, что сейчас идет процесс переименования выбранной категории
        private int renamedProductTypeId;

        /* Конструктор */
        public ProductTypesView(MainFormView _mf)
        {
            InitializeComponent();

            ptController = new ProductTypesController(this);

            controlMainFormView = _mf;

            ptController.GetProductTypesAll();
            Draw();

            if (dgv_ProductTypes.RowCount > 0)
            {
                label1.Visible = false;
                dgv_ProductTypes.Visible = true;
            }
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

        /* Добавить/изменить вид товара по нажатию btn_Save */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        /* Добавить/изменить вид товара по нажатию Enter */
        private void tb_ProductType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyChanges();
        }

        /* Добавляем/изменяем вид товара */
        private void ApplyChanges()
        {
            if (rtb_ProductType.Text != "")
            {
                if (!renamingInProgress)
                {
                    if (!ChechForExisting())
                    {
                        int result = ptController.SetNewProductType(rtb_ProductType.Text);
                        if (result == 1)
                        {
                            ptController.GetProductTypesAll();
                            Draw();

                            MessageBox.Show("Marketplace \"" + rtb_ProductType.Text + "\" был добавлен успешно!", "Успех");
                            rtb_ProductType.Text = "";
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
                    int result = ptController.UpdateExistingProductType(rtb_ProductType.Text, renamedProductTypeId);
                    if (result == 1)
                    {
                        ptController.GetProductTypesAll();
                        Draw();

                        MessageBox.Show("Marketplace \"" + rtb_ProductType.Text + "\" был переименован успешно!", "Успех");
                        rtb_ProductType.Text = "";
                        RenamingProductTypeEnd();
                    }
                    else if (result == -2146232060)
                    {
                        MessageBox.Show("Во время сохранение произшла ошибка. Пожалуйста, повторите попытку позже.", "Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите название категории.", "Ошибка");
            }

            if (dgv_ProductTypes.RowCount > 0)
            {
                label1.Visible = false;
                dgv_ProductTypes.Visible = true;
            }
        }

        /* Проверка перед сохранение в БД на наличие существующей категории с таким же именем */
        private bool ChechForExisting()
        {
            bool flag = false;

            for (int i = 0; i < dgv_ProductTypes.RowCount; i++)
            {
                if (dgv_ProductTypes.Rows[i].Cells[1].Value.ToString().ToLower().Equals(rtb_ProductType.Text.ToLower()))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /* Закрываем форму */
        private void ProductTypes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlMainFormView != null)
                controlMainFormView.Visible = true;
        }

        /* Закрыть окно */
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            if (renamingInProgress)
                RenamingProductTypeEnd();
            else
                this.Close();
        }

        /* Скопировать название категории по двойному ЛКМ на ячейку */
        private void dgv_ProductTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ProductTypes.RowCount > 0)
            {
                var str = dgv_ProductTypes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Clipboard.SetText(str);
            }
        }

        /* Обновляем dgv_KeywordCategory принудительно */
        private void btn_RefreshDGV_Click(object sender, EventArgs e)
        {
            ptController.GetProductTypesAll();
            Draw();
        }
        
        /* Изменяем UI под редактирование Marketplace */
        private void RenamingProductTypeBegin(string name)
        {
            groupBox1.Text = "Изменение названия вида товара";
            btn_Close.Text = "Отмена";
            renamingInProgress = true;
            rtb_ProductType.Text = name;
            rtb_ProductType.Focus();
        }

        /* Возвращаем UI к созданию Marketplace */
        private void RenamingProductTypeEnd()
        {
            groupBox1.Text = "Добавление нового вида товара";
            btn_Close.Text = "Закрыть";
            renamingInProgress = false;
            rtb_ProductType.Text = "";
        }

        /* При ПКМ по названию вида товара в dgv включаем режим редактирования */
        private void dgv_ProductTypes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    dgv_ProductTypes.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    renamedProductTypeId = int.Parse(dgv_ProductTypes.Rows[e.RowIndex].Cells[0].Value.ToString());
                    RenamingProductTypeBegin(dgv_ProductTypes.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
        }
    }
}
