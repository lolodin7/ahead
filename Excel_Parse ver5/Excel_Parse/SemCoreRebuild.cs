﻿using Microsoft.VisualBasic.FileIO;
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
    public partial class SemCoreRebuild : Form
    {
        private SqlConnection connection;
        private Form mf;
        private bool SavedStatus = true;
        private string path = "";
        private bool firstLoad = true;
        private bool AddCat = false;
        private string str_NewKeys = "Новые добавленные ключи";
        private string str_UploadedKeys = "Загруженные ключи";
        private string str_UpdatedKeys = "Обновленные ключи";

        string[,] myArr;

        string urlAmazon = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=";

        public SemCoreRebuild(Form _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            mf = _mf;
            lb_NewKeys.Text = str_NewKeys;
            lb_UpdatedKeys.Text = str_UpdatedKeys;
            lb_UploadedKeys.Text = str_UploadedKeys;

            GetProductTypes();
            GetCategories();
            GetKeywords();
            firstLoad = false;
        }

        public SemCoreRebuild()
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            lb_NewKeys.Text = str_NewKeys;
            lb_UpdatedKeys.Text = str_UpdatedKeys;
            lb_UploadedKeys.Text = str_UploadedKeys;

            GetProductTypes();
            GetCategories();
            GetKeywords();
            firstLoad = false;
        }

        private void RefreshDGVs()
        {
            dgv_Source.Rows.Clear();
            dgv_Target.Rows.Clear();
            dgv_NewKeys.Rows.Clear();
            dgv_DBSource.Rows.Clear();
            dgv_ProductTypes.Rows.Clear();
            dgv_Categories.Rows.Clear();
        }

        /* Получили список ключей после их ручного изменения в KeywordsAreExisted */
        public void GetKeywordsFromKeywordsAreExisted(string[,] _arr)
        {
            myArr = _arr;
        }





        public void OpenNewFile()
        {
            firstLoad = true;
            openFileDialog1.Filter = "Выбери файл|*.csv;*.txt";
            openFileDialog1.Title = "Выбор файла для открытия";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                RefreshDGVs();

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
                    btn_Begin.Enabled = true;

                    SavedStatus = true;
                    GetProductTypes();
                    GetCategories();
                    GetKeywords();
                    firstLoad = false;

                    lb_UploadedKeys.Text = str_UploadedKeys + " (" + dgv_Source.RowCount + ")";
                    lb_NewKeys.Text = str_NewKeys;
                    lb_UpdatedKeys.Text = str_UpdatedKeys;

                    dgv_Source.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                }
            }
        }

        private void btn_UploadFile_Click(object sender, EventArgs e)
        {
            if (SavedStatus)
            {
                OpenNewFile();
            }
            else
            {
                if (MessageBox.Show("Имеются несохраненные изменения. Сохранить?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SetDataToDB();
                    OpenNewFile();
                }
                else
                {
                    OpenNewFile();
                }
            }
        }

        /*  */
        private void SetDataToDB()
        {

        }

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
            }
            else if (e.KeyCode == Keys.Space)
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

        /* Помечаем ключ в таблице dgv_Source */
        private void dgv_Check(DataGridView sender)
        {
            if (sender.CurrentCellAddress.X == 0)
            {
                sender.Rows[sender.CurrentCellAddress.Y].Cells[sender.CurrentCellAddress.X].Style.ForeColor = Color.Red;
                Refresh_dgvTarget_Add();

                lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
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
            
            lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
        }

        /* Добавляем помеченный ключ в dgv_Target */
        private void Refresh_dgvTarget_Add()
        {
            bool flag = true;

            string str = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[dgv_Source.CurrentCellAddress.X].Value.ToString();
            for (int i = 0; i < dgv_Target.RowCount; i++)
            {
                if (dgv_Target.Rows[i].Cells[2].Value.ToString().Equals(str))
                {
                    flag = false;
                }
            }
            if (flag || dgv_Target.RowCount == 0)
            {
                var index = dgv_Target.Rows.Add();

                dgv_Target.Rows[index].Cells[2].Value = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[0].Value.ToString();
                dgv_Target.Rows[index].Cells[3].Value = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[1].Value.ToString();
            }
        }

        /* Удаляем ключ из dgv_Target при снятии его выделения в dgv_Source */
        private void Refresh_dgvTarget_Del()
        {
            string str = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[dgv_Source.CurrentCellAddress.X].Value.ToString();
            for (int i = 0; i < dgv_Target.RowCount; i++)
            {
                if (dgv_Target.Rows[i].Cells[2].Value.ToString().Equals(str))
                {
                    dgv_Target.Rows.RemoveAt(i);
                }
            }
        }

        /* Закончить обрабатывание новых ключей */
        private void btn_KeysAreDone_Click(object sender, EventArgs e)
        {
            if (dgv_Target.RowCount > 0)
            {
                dgv_Source.Rows.Clear();

                for (int i = 0; i < dgv_Target.RowCount; i++)
                {
                    var index = dgv_Source.Rows.Add();
                    dgv_Source.Rows[index].Cells[0].Value = dgv_Target.Rows[i].Cells[2].Value;
                    dgv_Source.Rows[index].Cells[1].Value = dgv_Target.Rows[i].Cells[3].Value;
                }

                dgv_Target.Rows.Clear();
                
                lb_UploadedKeys.Text = str_UploadedKeys + " (" + dgv_Source.RowCount + ")";
                lb_UpdatedKeys.Text = str_UpdatedKeys;
            }
        }

        //------------------------------

        /* Загружем список типов продуктов из ProductTypes */
        private void GetProductTypes()
        {
            string sqlStatement = "SELECT * FROM ProductTypes WHERE [ProductTypeId] > 0";
            SqlCommand command = new SqlCommand(sqlStatement, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataTo_dgv_ProductTypes((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                SetDataTo_cb_ProductType();
            }
            catch (Exception ex) { }
        }

        /* Заполняем dgv_ProductTypes */
        private void SetDataTo_dgv_ProductTypes(IDataRecord record)
        {
            var index = dgv_ProductTypes.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_ProductTypes.Rows[index].Cells[i].Value = record[i];
            }
        }

        /*  */
        private void SetDataTo_cb_ProductType()
        {
            cb_ProductType.Items.Clear();

            for (int i = 0; i < dgv_ProductTypes.RowCount - 1; i++)
            {
                cb_ProductType.Items.Add(dgv_ProductTypes.Rows[i].Cells[1].Value.ToString());
            }

            cb_ProductType.SelectedItem = cb_ProductType.Items[0];
        }


        /* Загружем список категорий ключей из KeywordCategories */
        private void GetCategories()
        {
            string sqlStatement = "SELECT * FROM KeywordCategory WHERE CategoryId > 0";
            SqlCommand command = new SqlCommand(sqlStatement, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataTo_dgv_Categories((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                SetDataTo_cb_KeywordCategory();
            }
            catch (Exception ex) { }
        }

        /* Заполняем dgv_Categories */
        private void SetDataTo_dgv_Categories(IDataRecord record)
        {
            var index = dgv_Categories.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_Categories.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Заполняем cb_KeywordCategory */
        private void SetDataTo_cb_KeywordCategory()
        {
            cb_KeywordCategory.Items.Clear();

            for (int i = 0; i < dgv_Categories.RowCount - 1; i++)
            {
                cb_KeywordCategory.Items.Add(dgv_Categories.Rows[i].Cells[1].Value.ToString());
            }

            cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[0];
        }

        //--------------------------------

        private int GetSelectedProductTypeId()
        {
            for (int i = 0; i < dgv_ProductTypes.RowCount - 1; i++)
            {
                if (dgv_ProductTypes.Rows[i].Cells[1].Value.ToString().Equals(cb_ProductType.SelectedItem.ToString()))
                {
                    return int.Parse(dgv_ProductTypes.Rows[i].Cells[0].Value.ToString());
                }
            }
            return -1;
        }

        private int GetSelectedCategoryId()
        {
            for (int i = 0; i < dgv_Categories.RowCount - 1; i++)
            {
                if (dgv_Categories.Rows[i].Cells[1].Value.ToString().Equals(cb_KeywordCategory.SelectedItem.ToString()))
                {
                    return int.Parse(dgv_Categories.Rows[i].Cells[0].Value.ToString());
                }
            }
            return -1;
        }

        /* Загружем все ключи в dgv_DBSource */
        private void GetKeywords()
        {
            dgv_DBSource.Rows.Clear();
            dgv_Target.Rows.Clear();
            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + GetSelectedProductTypeId() + " AND CategoryId = " + GetSelectedCategoryId();
            SqlCommand command = new SqlCommand(sqlStatement, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataTo_dgv_DBSource((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) { }
        }

        /* Заполняем dgv_DBSource */
        private void SetDataTo_dgv_DBSource(IDataRecord record)
        {
            var index = dgv_DBSource.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_DBSource.Rows[index].Cells[i].Value = record[i];
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!firstLoad)
                GetKeywords();
        }

        /* Запуск основной логики */
        private void btn_Begin_Click(object sender, EventArgs e)
        {
            int prID = GetSelectedProductTypeId();
            int catId = GetSelectedCategoryId();
            
            bool isExist;
            if (MessageBox.Show("Вы уверены, что хотите начать процедуру сверки ключей?", "Начать", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                dgv_Target.Rows.Clear();
                dgv_NewKeys.Rows.Clear();

                this.Enabled = false;

                for (int i = 0; i < dgv_Source.RowCount; i++)
                {
                    dgv_Source.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                    isExist = false;

                    for (int j = 0; j < dgv_DBSource.RowCount - 1; j++)
                    {
                        if (dgv_Source.Rows[i].Cells[0].Value.ToString().Equals(dgv_DBSource.Rows[j].Cells[2].Value.ToString()))
                        {
                            //пишем в dgv_Target
                            var index = dgv_Target.Rows.Add();

                            for (int k = 0; k < dgv_Target.ColumnCount; k++)
                            {
                                dgv_Target.Rows[index].Cells[k].Value = dgv_DBSource.Rows[j].Cells[k].Value;
                            }
                            dgv_Target.Rows[index].Cells[3].Value = dgv_Source.Rows[i].Cells[1].Value;
                            isExist = true;
                        }
                    }
                    if (!isExist)        //если это новый ключ
                    {
                        //пишем в dgv_NewKeys
                        var index = dgv_NewKeys.Rows.Add();

                        dgv_NewKeys.Rows[index].Cells[0].Value = prID;
                        dgv_NewKeys.Rows[index].Cells[1].Value = catId;
                        dgv_NewKeys.Rows[index].Cells[2].Value = dgv_Source.Rows[i].Cells[0].Value;
                        dgv_NewKeys.Rows[index].Cells[3].Value = dgv_Source.Rows[i].Cells[1].Value;
                        dgv_NewKeys.Rows[index].Cells[4].Value = DateTime.Now;

                    }
                }
                UpdateDB();
                //
                this.Enabled = true;
            }            
        }

        private void UpdateDB()
        {
            try { connection.Open(); }
            catch (Exception e) { MessageBox.Show("Ошибка подключения к БД", "Ошибка"); }

            string sqlStatements = "";
            bool error = false;
            bool isEmpty = false;

            progressBar1.Maximum = dgv_NewKeys.RowCount + dgv_Target.RowCount;
            progressBar1.Visible = true;

            for (int i = 0; i < dgv_Target.RowCount; i++)
            {
                try
                {
                    sqlStatements = "UPDATE [SemCore] SET [ProductTypeId] = " + dgv_Target.Rows[i].Cells[0].Value + ", [CategoryId] = " + dgv_Target.Rows[i].Cells[1].Value + ", [Keyword] = '" + dgv_Target.Rows[i].Cells[2].Value.ToString() + "', [Value] = " + dgv_Target.Rows[i].Cells[3].Value + ", [LastUpdated] = '" + dgv_Target.Rows[i].Cells[4].Value.ToString() + "' WHERE [SemCoreId] = " + dgv_Target.Rows[i].Cells[5].Value;

                    SqlCommand command = new SqlCommand(sqlStatements, connection);
                    command.ExecuteScalar();
                    isEmpty = true;
                    progressBar1.Value++;
                }
                catch (Exception ex)
                {
                    error = true;
                    progressBar1.Value++;
                }
            }
            if (error)
                MessageBox.Show("Данные не были обновлены. Попробуйте ещё раз.", "Ошибка");
            connection.Close();
            InsertDB(isEmpty);
        }

        private void InsertDB(bool isEmpty)
        {
            try { connection.Open(); }
            catch (Exception e) { MessageBox.Show("Ошибка подключения к БД", "Ошибка"); }

            bool error = false;
            string sqlStatements = "";
            int j = 0;
            string[,] _arr = new string[dgv_NewKeys.RowCount, 2];       //ключи, которые уже есть в БД
            List<int> forDeleting = new List<int> { };

            for (int i = 0; i < dgv_NewKeys.RowCount; i++)
            {
                try
                {
                    sqlStatements = "INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [LastUpdated]) VALUES (" + dgv_NewKeys.Rows[i].Cells[0].Value + ", '" + dgv_NewKeys.Rows[i].Cells[1].Value + "', '" + dgv_NewKeys.Rows[i].Cells[2].Value.ToString() + "', '" + dgv_NewKeys.Rows[i].Cells[3].Value + "', '" + dgv_NewKeys.Rows[i].Cells[4].Value.ToString() + "')";

                    SqlCommand command = new SqlCommand(sqlStatements, connection);
                    command.ExecuteScalar();
                    progressBar1.Value++;
                }
                catch (Exception ex)
                {
                    _arr[j, 0] = dgv_NewKeys.Rows[i].Cells[2].Value.ToString();
                    _arr[j, 1] = dgv_NewKeys.Rows[i].Cells[3].Value.ToString();
                    j++;
                    error = true;
                    forDeleting.Add(i);
                    progressBar1.Value++;
                }
            }

            int h = dgv_NewKeys.RowCount;
            for (int i = forDeleting.Count - 1; i >= 0; i--)
            {
                dgv_NewKeys.Rows.RemoveAt(forDeleting[i]);
            }

            if (!isEmpty)
                MessageBox.Show("Никаких новых ключей не было добавлено.", "Внимание");

            lb_NewKeys.Text = str_NewKeys + " (" + dgv_NewKeys.RowCount + ")";
            lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
            lb_UploadedKeys.Text = str_UploadedKeys + " (" + dgv_Source.RowCount + ")";

            if (error)
            {
                KeywordsAreExistedView kae = new KeywordsAreExistedView(_arr, cb_KeywordCategory.SelectedItem.ToString());
                if (kae.ShowDialog() == DialogResult.OK)
                {
                    Fill_dgv_Source_ByExistingKeys(_arr);
                }
                dgv_NewKeys.ScrollBars = ScrollBars.Both;
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }
            else
            {
                MessageBox.Show("Все данные были обновлены успешно.", "Успех");
                dgv_NewKeys.ScrollBars = ScrollBars.Both;
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }

            connection.Close();
        }

        /* Заполняем dgv_Source ключами, которые не удалось обновить, т.к. они уже есть в БД */
        private void Fill_dgv_Source_ByExistingKeys(string[,] _arr)
        {
            dgv_Source.Rows.Clear();
            dgv_Target.Rows.Clear();
            dgv_NewKeys.Rows.Clear();

            for (int i = 0; i < _arr.Length / 2; i++)
            {
                var index = dgv_Source.Rows.Add();

                for (int k = 0; k < dgv_Source.ColumnCount; k++)
                {
                    dgv_Source.Rows[index].Cells[k].Value = _arr[i,k];
                }
            }
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            dgv_Source.Rows.Clear();
            dgv_Target.Rows.Clear();
            dgv_NewKeys.Rows.Clear();
            btn_Begin.Enabled = false;

            lb_NewKeys.Text = str_NewKeys;
            lb_UpdatedKeys.Text = str_UpdatedKeys;
            lb_UploadedKeys.Text = str_UploadedKeys;

            GetKeywords();
        }

        private void btn_AddCategory_Click(object sender, EventArgs e)
        {
            KeywordCategoryView kc = new KeywordCategoryView(this);
            if (kc.ShowDialog() == DialogResult.Cancel)
            { AddCat = true; }
            AddCat = true;
            SemCoreRefresh();
        }

        private void SemCoreRefresh()
        {
            if (AddCat)
            {
                RefreshDGVs();
                GetProductTypes();
                GetCategories();
                GetKeywords();

                AddCat = false;
                btn_Begin.Enabled = false;
            }
        }

        private void SemCoreRebuild_VisibleChanged(object sender, EventArgs e)
        {
            SemCoreRefresh();
        }

        private void SemCoreRebuild_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }

        private void btn_CheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Source.RowCount; i++)
            {
                dgv_Source.Rows[i].Cells[0].Style.ForeColor = Color.Red;

                bool flag = true;

                string str = dgv_Source.Rows[i].Cells[0].Value.ToString();
                for (int j = 0; j < dgv_Target.RowCount; j++)
                {
                    if (dgv_Target.Rows[j].Cells[2].Value.ToString().Equals(str))
                    {
                        flag = false;
                    }
                }
                if (flag || dgv_Target.RowCount == 0)
                {
                    var index = dgv_Target.Rows.Add();

                    dgv_Target.Rows[index].Cells[2].Value = dgv_Source.Rows[i].Cells[0].Value.ToString();
                    dgv_Target.Rows[index].Cells[3].Value = dgv_Source.Rows[i].Cells[1].Value.ToString();
                }

            }
            if (dgv_Source.RowCount > 0)
                lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
        }

        private void btn_UnChekAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Source.RowCount; i++)
            {
                dgv_Source.Rows[i].Cells[0].Style.ForeColor = Color.Black;

                string str = dgv_Source.Rows[i].Cells[0].Value.ToString();
                for (int j = 0; j < dgv_Target.RowCount; j++)
                {
                    if (dgv_Target.Rows[j].Cells[2].Value.ToString().Equals(str))
                    {
                        dgv_Target.Rows.RemoveAt(j);
                    }
                }
            }

            if (dgv_Source.RowCount > 0)
                lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tb_Link.Enabled = true;
            }
            else
            {
                tb_Link.Enabled = false;
                //mf.AmazonLink = tb_Link.Text;
            }

        }
    }
}
