﻿using System;
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
    public partial class ChooseProduct : Form
    {
        private SqlConnection connection;
        public int ProductId { get; set; }
        private MainFormView mf;
        private List<ProductsModel> pmList;
        private List<ProductsModel> pmUniqueList;

        private bool OpenSuccess;

        public ChooseProduct(MainFormView _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            pmList = new List<ProductsModel> { };
            mf = _mf;
            OpenSuccess = false;

            getDBProductSKUInfo();
            getUniquesASIN();
            SetDataToDGV();
        }

        /* Заносим инфо о продуктах в dgv */
        private void SetDataToDGV()
        {
            for (int i = 0; i < pmUniqueList.Count; i++)
            {
                var index = dgv_Products.Rows.Add();
                for (int j = 0; j < pmUniqueList[0].ColumnCount; j++)
                {
                    dgv_Products.Rows[index].Cells[j].Value = pmUniqueList[i].ReadData(j);
                }
            }
        }
        
        /* Заполняем поля на форме инфо о продукте */
        private void getDBProductSKUInfo()
        {
            dgv_Products.Columns[3].Visible = true;
            string sqlSemanticsIds = "SELECT * FROM Products WHERE [ProductId] > 0";
            SqlCommand command = new SqlCommand(sqlSemanticsIds, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //SetProductsToDataGrid((IDataRecord)reader);
                        SetProductsToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /*  */
        private void SetProductsToList(IDataRecord record)
        {
            ProductsModel pmModel = new ProductsModel();
            pmList.Add(pmModel);

            for (int i = 0; i < record.FieldCount; i++)
            {
                pmList[pmList.Count - 1].WriteData(i, record[i]);
            }
        }

        /* Выделяем уникальные ASIN с разных SKU */
        private void getUniquesASIN()
        {
            List<string> tmp = new List<string> { };
            pmUniqueList = new List<ProductsModel> { };

            if (pmList != null)
            {
                for (int i = 0; i < pmList.Count; i++)
                {
                    if (!tmp.Contains(pmList[i].SKU))
                    {
                        ProductsModel pmModel = new ProductsModel();
                        pmUniqueList.Add(pmModel);

                        for (int k = 0; k < pmUniqueList[0].ColumnCount; k++)
                        {
                            pmUniqueList[pmUniqueList.Count - 1].WriteData(k, pmList[i].ReadData(k));
                        }
                        tmp.Add(pmList[i].SKU);
                    }

                }
            }
        }

        /* Открываем семантику для выбранного товара */
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (mf != null)                //если вызвали из MainForm
            {
                ProductId = int.Parse(dgv_Products.Rows[dgv_Products.CurrentCellAddress.Y].Cells[0].Value.ToString());
                string _productName = dgv_Products.Rows[dgv_Products.CurrentCellAddress.Y].Cells[1].Value.ToString();
                string _asin = dgv_Products.Rows[dgv_Products.CurrentCellAddress.Y].Cells[2].Value.ToString();
                string _sku = dgv_Products.Rows[dgv_Products.CurrentCellAddress.Y].Cells[3].Value.ToString();
                int _prodTypeId = int.Parse(dgv_Products.Rows[dgv_Products.CurrentCellAddress.Y].Cells[4].Value.ToString());

                string sqlSemanticsIds = "SELECT * FROM Semantics WHERE [ProductId] = " + ProductId;
                SqlCommand command = new SqlCommand(sqlSemanticsIds, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        SemanticsView semantics = new SemanticsView(mf, ProductId, _productName, _asin, _sku, _prodTypeId);
                        OpenSuccess = true;
                        semantics.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("У данного товара пока что нет ни одной семантики", "Ошибка");
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                    Environment.Exit(0);
                }
            }
        }

        /* Закрытие формы */
        private void ChooseProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OpenSuccess)
            {
                if (mf != null)
                    mf.Show();
            }
        }

        /* Поиск по таблице */
        private void tb_FindNameField_TextChanged(object sender, EventArgs e)
        {
            string findStr = tb_FindNameField.Text;
            for (int i = 0; i < dgv_Products.RowCount - 1; i++)
            {
                for (int j = 0; j < dgv_Products.ColumnCount; j++)
                {
                    if (dgv_Products.Rows[i].Cells[j].Value.ToString().ToLower().Contains(findStr) && findStr != "")
                        dgv_Products.Rows[i].Cells[j].Style.BackColor = Color.Aqua;
                    else
                        dgv_Products.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            mf.Show();
            this.Close();
        }
    }
}
