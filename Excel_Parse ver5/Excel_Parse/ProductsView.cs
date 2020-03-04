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
    public partial class ProductsView : Form
    {
        private SqlConnection connection;
        
        private ProductsController pController;
        private List<ProductsModel> pList;     //список всех объектов (записей из БД)

        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private List<string> activeProducts;
        private bool ActiveStatus;

        private MainFormView mf;

        private bool firstStart;

        /* Конструктор */
        public ProductsView(MainFormView _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            mf = _mf;

            firstStart = true;

            pController = new ProductsController(this);
            ptController = new ProductTypesController(this);
            mpController = new MarketplaceController(this);

            FillAllFields();
            

            if (dgv_Products.RowCount > 0)
            {
                label2.Visible = false;
                dgv_Products.Visible = true;
            }

            firstStart = false;
        }

        /* Заполняем (перезаполняем после изменений) все поля на форме данными с БД */
        private void FillAllFields()
        {
            if (!firstStart)
                if (checkbox_ActiveStatus.Checked == true)
                    pController.GetProductsAllJOIN();
                else
                    pController.GetActiveProductsJOIN();
            else
                pController.GetActiveProductsJOIN();

            DrawProducts();
            DrawProductTypes();
            DrawMarketPlaces();

            //if (mf.um.UserRoleId == 0 || mf.um.UserRoleId == 1)
            //{
            //    ptController.GetProductTypesAll();
            //    Fill_CB_ByProductTypes();

            //    mpController.GetMarketplaces();
            //    Fill_CB_ByMarketplaces();
            //}

            ptController.GetProductTypesAll();
            Fill_CB_ByProductTypes();

            mpController.GetMarketplaces();
            Fill_CB_ByMarketplaces();

        }

        /* Перерисовываем таблицу новыми данными Products */
        private void DrawProducts()
        {
            dgv_Products.Rows.Clear();

            for (int i = 0; i < pList.Count; i++)
            {
                var index = dgv_Products.Rows.Add();

                for (int j = 0; j < pList[0].ColumnCount; j++)
                {
                    if (j != pList[0].ColumnCount - 1)
                        dgv_Products.Rows[index].Cells[j].Value = pList[i].ReadData(j);
                    else
                        dgv_Products.Rows[index].Cells[11].Value = pList[i].ReadData(j);
                }
            }
        }

        /* Добавляем в таблицу данные с ProductTypes */
        private void DrawProductTypes()
        {
            for (int i = 0; i < dgv_Products.RowCount; i++)
            {
                for (int j = 0; j < ptList.Count; j++)
                {
                    if (dgv_Products.Rows[i].Cells[4].Value.Equals(ptList[j].ProductTypeId))
                    {
                        dgv_Products.Rows[i].Cells[7].Value = dgv_Products.Rows[i].Cells[4].Value;
                        dgv_Products.Rows[i].Cells[8].Value = ptList[j].TypeName.ToString();
                    }
                }
            }
        }

        /* Добавляем в таблицу данные с Marketplace */
        private void DrawMarketPlaces()
        {
            for (int i = 0; i < dgv_Products.RowCount; i++)
            {
                for (int j = 0; j < mpList.Count; j++)
                {
                    if (dgv_Products.Rows[i].Cells[5].Value.Equals(mpList[j].MarketPlaceId))
                    {
                        dgv_Products.Rows[i].Cells[9].Value = dgv_Products.Rows[i].Cells[5].Value;
                        dgv_Products.Rows[i].Cells[10].Value = mpList[j].MarketPlaceName.ToString();
                    }
                }
            }
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера ProductTypes, полученные с БД */
        public void GetProductTypesFromDB(object _ptList)
        {
            ptList = (List<ProductTypesModel>)_ptList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

        /* Делает активной ячейку под курсором */
        private void dgv_Products_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dgv_Products.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

        /* Включаем режим редактировани выбранного в таблице товара */
        private void dgv_Products_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (mf.um.UserRoleId == 0 || mf.um.UserRoleId == 1)     //редактировать могут только админы и боссы
            //{
            if (dgv_Products.RowCount > 0)
            {
                //tb_editing_ProductName.Enabled = true;
                //tb_editing_ASIN.Enabled = true;
                //tb_editing_SKU.Enabled = true;
                //cb_editing_ProductTypes.Enabled = true;
                //cb_editing_Marketplace.Enabled = true;
                //btn_SaveEditing.Enabled = true;
                //btn_CancelEditing.Enabled = true;
                //btn_ActivateProduct.Enabled = true;



                tb_editing_ProductId.Text = dgv_Products.Rows[e.RowIndex].Cells[0].Value.ToString();
                tb_editing_ProductName.Text = dgv_Products.Rows[e.RowIndex].Cells[1].Value.ToString();
                tb_editing_ASIN.Text = dgv_Products.Rows[e.RowIndex].Cells[2].Value.ToString();
                tb_editing_SKU.Text = dgv_Products.Rows[e.RowIndex].Cells[3].Value.ToString();
                tb_editing_ProductTypeId.Text = dgv_Products.Rows[e.RowIndex].Cells[4].Value.ToString();
                tb_editingShortName.Text = dgv_Products.Rows[e.RowIndex].Cells[11].Value.ToString();
                ActiveStatus = (bool)dgv_Products.Rows[e.RowIndex].Cells[6].Value;

                for (int i = 0; i < cb_editing_ProductTypes.Items.Count; i++)
                {
                    if (dgv_Products.Rows[e.RowIndex].Cells[8].Value.ToString().Equals(cb_editing_ProductTypes.Items[i].ToString()))
                    {
                        cb_editing_ProductTypes.SelectedItem = cb_editing_ProductTypes.Items[i];
                    }
                }

                for (int i = 0; i < cb_editing_Marketplace.Items.Count; i++)
                {
                    if (dgv_Products.Rows[e.RowIndex].Cells[10].Value.ToString().Equals(cb_editing_Marketplace.Items[i].ToString()))
                    {
                        cb_editing_Marketplace.SelectedItem = cb_editing_Marketplace.Items[i];
                    }
                }

                //groupBox2.Enabled = false;

                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            //}
        }

        /* Удаление товара по клику ПКМ в dgv_Products */
        private void dgv_Products_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (mf.um.UserRoleId == 0 || mf.um.UserRoleId == 1)     //редактировать могут только админы и боссы
            //{
            if (e.Button == MouseButtons.Right)
            {
                if (dgv_Products.RowCount > 0 && dgv_Products.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGray)      //если таблица пустая, чтобы не было ошибки
                {
                    dgv_Products.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    if (MessageBox.Show("Товар \"" + dgv_Products.Rows[e.RowIndex].Cells[1].Value.ToString() + "\" будет отключен. Вы уверены?", "Отключение товара", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //SetDeletedProductToDB(e.RowIndex);

                        //if (checkbox_ActiveStatus.Checked == true)
                        //    pController.GetProductsAllJOIN();
                        //else
                        //    pController.GetActiveProductsJOIN();

                        RefreshFieldsAfterEditing();

                        //тут метод для обновлений в базе активстатуса
                        pController.UpdateProductActiveStatus(int.Parse(dgv_Products.Rows[e.RowIndex].Cells[0].Value.ToString()), false);

                        dgv_Products.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
            //}
        }

        /* Сохраняем удаленный товар в БД */
        private void SetDeletedProductToDB(int row)
        {
            pController.DeleteProductFromSemantics(int.Parse(dgv_Products.Rows[row].Cells[0].Value.ToString()));
            pController.DeleteProductFromFieldsLength(int.Parse(dgv_Products.Rows[row].Cells[0].Value.ToString()));
            pController.DeleteProductFromProducts(int.Parse(dgv_Products.Rows[row].Cells[0].Value.ToString()));
        }

        /* Заполняем cb_ProductTypes данными с ptList */
        private void Fill_CB_ByProductTypes()
        {
            cb_editing_ProductTypes.Items.Clear();
            cb_adding_ProductTypes.Items.Clear();

            for (int i = 0; i < ptList.Count; i++)
            {
                cb_editing_ProductTypes.Items.Add(ptList[i].TypeName);
                cb_adding_ProductTypes.Items.Add(ptList[i].TypeName);
            }
            if (ptList.Count > 0)
            {
                cb_editing_ProductTypes.SelectedItem = cb_editing_ProductTypes.Items[0];
                cb_adding_ProductTypes.SelectedItem = cb_adding_ProductTypes.Items[0];
            }
        }

        /* Заполняем cb_Marketplace данными с mpList */
        private void Fill_CB_ByMarketplaces()
        {
            cb_editing_Marketplace.Items.Clear();
            cb_adding_Marketplace.Items.Clear();

            for (int i = 0; i < mpList.Count; i++)
            {
                cb_editing_Marketplace.Items.Add(mpList[i].MarketPlaceName);
                cb_adding_Marketplace.Items.Add(mpList[i].MarketPlaceName);
            }
            if (mpList.Count > 0)
            {
                cb_editing_Marketplace.SelectedItem = cb_editing_Marketplace.Items[0];
                cb_adding_Marketplace.SelectedItem = cb_adding_Marketplace.Items[0];
            }
        }

        /* Вызов справка */
        private void btn_Help_Click(object sender, EventArgs e)
        {
            string str1 = "Дважды ЛКМ по товару в таблице, чтобы перейти в режим его редактирования.\n";
            string str2 = "\nПКМ по товару для его удаления.\n";
            MessageBox.Show(str1 + str2, "Справка");
        }

        /* Закрываем форму */
        private void Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            mf.Show();
        }

        /* Отменяем изменения */
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            RefreshFieldsAfterEditing();
        }

        /* Очищаем поля после отмены редактирования товара */
        private void RefreshFieldsAfterEditing()
        {
            //tb_editing_ProductName.Enabled = false;
            //tb_editing_ASIN.Enabled = false;
            //tb_editing_SKU.Enabled = false;
            //cb_editing_ProductTypes.Enabled = false;
            //cb_editing_Marketplace.Enabled = false;
            //btn_SaveEditing.Enabled = false;
            //btn_CancelEditing.Enabled = false;
            //btn_ActivateProduct.Enabled = false;

            tb_editing_ProductId.Text = "";
            tb_editing_ProductName.Text = "";
            tb_editing_ASIN.Text = "";
            tb_editing_SKU.Text = "";
            tb_editing_ProductTypeId.Text = "";
            tb_editingShortName.Text = "";

            //groupBox2.Enabled = true;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        /* Чтобы при изменении в tb_editing_ProductTypeId появлялся корректный Id */
        private void cb_editing_ProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ptList.Count; i++)
            {
                if (cb_editing_ProductTypes.SelectedItem.ToString().Equals(ptList[i].TypeName))
                {
                    tb_editing_ProductTypeId.Text = ptList[i].ProductTypeId.ToString();
                }
            }
        }

        /* Чтобы при изменении в tb_editing_MarketPlaceId появлялся корректный Id */
        private void cb_editing_Marketplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                if (cb_editing_Marketplace.SelectedItem.ToString().Equals(mpList[i].MarketPlaceName))
                {
                    tb_editing_MarketPlaceId.Text = mpList[i].MarketPlaceId.ToString();
                }
            }
        }

        /* Очищаем поля с данными нового товара */
        private void btn_ClearAdding_Click(object sender, EventArgs e)
        {
            tb_adding_ASIN.Text = "";
            tb_adding_ProductName.Text = "";
            tb_adding_SKU.Text = "";
            tb_AddingShortName.Text = "";
        }

        /* Чтобы при изменении в tb_adding_ProductTypeId появлялся корректный Id */
        private void cb_adding_ProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ptList.Count; i++)
            {
                if (cb_adding_ProductTypes.SelectedItem.ToString().Equals(ptList[i].TypeName))
                {
                    tb_adding_ProductTypeId.Text = ptList[i].ProductTypeId.ToString();
                }
            }
        }

        /* Чтобы при изменении в tb_adding_marketPlaceId появлялся корректный Id */
        private void cb_adding_Marketplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                if (cb_adding_Marketplace.SelectedItem.ToString().Equals(mpList[i].MarketPlaceName))
                {
                    tb_adding_MarketPlaceId.Text = mpList[i].MarketPlaceId.ToString();
                }
            }
        }

        /* Сохраняем изменения */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!tb_editing_ProductName.Text.Equals("") && !tb_editing_ASIN.Text.Equals("") && !tb_editing_SKU.Text.Equals("") && !tb_editingShortName.Text.Equals(""))
            {
                pController.UpdateExistingProduct(tb_editing_ProductName.Text, tb_editing_ASIN.Text, tb_editing_SKU.Text, int.Parse(tb_editing_ProductTypeId.Text), int.Parse(tb_editing_ProductId.Text), int.Parse(tb_editing_MarketPlaceId.Text), ActiveStatus, tb_editingShortName.Text);

                RefreshFieldsAfterEditing();
                //FillAllFields();
                checkbox_ActiveStatus.Checked = !checkbox_ActiveStatus.Checked;
                checkbox_ActiveStatus.Checked = !checkbox_ActiveStatus.Checked;
            }
            else
                MessageBox.Show("Не все поля заполнены. Пожалуйста, заполните все поля чтобы продолжить.", "Ошибка");
        }

        /* Сохраняем новый товар в БД */
        private void btn_SaveAdding_Click(object sender, EventArgs e)
        {
            string errorsList = "";
            bool errorMade = false;

            if (!tb_adding_ProductName.Text.Equals("") && !tb_adding_ASIN.Text.Equals("") && !tb_adding_SKU.Text.Equals(""))
            {
                int prodTypeId, marketPlcId;

                try { prodTypeId = int.Parse(tb_adding_ProductTypeId.Text); } catch (Exception ex) { errorsList += "Выберите вид товара!\n"; errorMade = true; }
                try { marketPlcId = int.Parse(tb_adding_MarketPlaceId.Text); } catch (Exception ex) { errorsList += "Выберите маркетплейс для товара!"; errorMade = true; }

                if (!errorMade)
                {
                    int result = -1;
                    result = pController.InsertNewProduct(tb_adding_ProductName.Text, tb_adding_ASIN.Text, tb_adding_SKU.Text, int.Parse(tb_adding_ProductTypeId.Text), int.Parse(tb_adding_MarketPlaceId.Text), true, tb_AddingShortName.Text);

                    if (result == 1)
                    {
                        tb_adding_ASIN.Text = "";
                        tb_adding_ProductName.Text = "";
                        tb_adding_SKU.Text = "";
                        tb_AddingShortName.Text = "";

                        //FillAllFields();
                        checkbox_ActiveStatus.Checked = !checkbox_ActiveStatus.Checked;
                        checkbox_ActiveStatus.Checked = !checkbox_ActiveStatus.Checked;
                    }
                    else
                        MessageBox.Show("Произошла ошибка при сохранении.", "Ошибка");
                }
                else
                    MessageBox.Show(errorsList, "Ошибка");

                if (dgv_Products.RowCount > 0)
                {
                    label2.Visible = false;
                    dgv_Products.Visible = true;
                }
            }
            else
                MessageBox.Show("Не все поля заполнены. Пожалуйста, заполните все поля чтобы продолжить.", "Ошибка");
        }

        /* Отображаем/скрываем неактивные, закрытые товары */
        private void checkbox_ActiveStatus_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAllFieldsDependOnActivation();
        }

        /* Перерисовываем таблицу при вкл/выкл флажка на отображение закрытых товаров */
        private void RefreshAllFieldsDependOnActivation()
        {
            if (checkbox_ActiveStatus.Checked)
            {
                activeProducts = new List<string> { };

                List<string> tmp = new List<string> { };

                for (int i = 0; i < pList.Count; i++)
                {
                    activeProducts.Add(pList[i].ASIN);
                }

                FillAllFields();

                for (int i = 0; i < pList.Count; i++)
                {
                    if (!activeProducts.Contains(pList[i].ASIN))
                        tmp.Add(pList[i].ASIN);
                }

                for (int i = 0; i < dgv_Products.RowCount; i++)
                {
                    for (int j = 0; j < tmp.Count; j++)
                    {
                        if (dgv_Products.Rows[i].Cells[2].Value.ToString().Equals(tmp[j]))
                        {
                            dgv_Products.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                        }
                    }
                }

                //if (mf.um.UserRoleId == 0 || mf.um.UserRoleId == 1)
                if (tmp.Count == 0)
                    RefreshFieldsAfterEditing();
            }
            else
            {
                FillAllFields();
            }
        }

        private void btn_ActivateProduct_Click(object sender, EventArgs e)
        {
            ActiveStatus = true;
        }

        /* Поиск товаров */
        private void tb_FindNameField_TextChanged(object sender, EventArgs e)
        {
            string findStr = rtb_FindFieldName.Text;
            for (int i = 0; i < dgv_Products.RowCount - 1; i++)
            {
                for (int j = 0; j < dgv_Products.ColumnCount; j++)
                {
                    if (dgv_Products.Rows[i].Cells[j].Value.ToString().ToLower().Contains(findStr) && findStr != "")
                        dgv_Products.Rows[i].Cells[j].Style.BackColor = Color.DeepSkyBlue;
                    else if (dgv_Products.Rows[i].DefaultCellStyle.BackColor == Color.LightGray)
                        dgv_Products.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    else
                        dgv_Products.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }
    }
}
