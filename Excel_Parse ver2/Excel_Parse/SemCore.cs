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

namespace Excel_Parse
{
    public partial class SemCore : Form
    {
        private SqlConnection connection;
        private MainForm mf;
        private bool SavedStatus = true;
        private string path = "";


        public SemCore(MainForm _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            mf = _mf;

            GetProductTypes();
            GetCategories();
            tb_Link.Text = mf.AmazonLink;
        }

        public void OpenNewFile()
        {
            openFileDialog1.Filter = "Выбери файл|*.csv;*.txt";
            openFileDialog1.Title = "Выбор файла для открытия";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                tb_AddCategory.Text = "";
                tb_CoreName.Text = "";
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
            }
        }

        /* Загружем список типов продуктов из ProductTypes */
        private void GetProductTypes()
        {
            string sqlStatement = "SELECT * FROM ProductTypes";
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
            string sqlStatement = "SELECT * FROM KeywordCategory";
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

        /* Помечаем ключ в таблице dgv_Source */
        private void dgv_Check(DataGridView sender)
        {
            if (sender.CurrentCellAddress.X == 0)
            {
                sender.Rows[sender.CurrentCellAddress.Y].Cells[sender.CurrentCellAddress.X].Style.ForeColor = Color.Red;
                Refresh_dgvTarget_Add();
            }
        }

        /* Снимает пометку ключа в таблице dgv_Source */
        private void dgv_UnCheck(DataGridView sender)
        {
            if (sender.CurrentCellAddress.X == 0)
                sender.Rows[sender.CurrentCellAddress.Y].Cells[sender.CurrentCellAddress.X].Style.ForeColor = Color.Black;
            Refresh_dgvTarget_Del();
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
            }
        }

        /* Добавляем помеченный ключ в dgv_Target */
        private void Refresh_dgvTarget_Add()
        {
            bool flag = true;

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

        /* Удаляем ключ из dgv_Target при снятии его выделения в dgv_Source */
        private void Refresh_dgvTarget_Del()
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

        /* Кнопка "Сохранить" */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (tb_CoreName.Text.Equals("") || dgv_Target.RowCount == 0)
            {
                if (dgv_Target.RowCount == 0)
                    MessageBox.Show("Нет данных для сохранения", "Нет данных");
                else
                    MessageBox.Show("Для продолжение укажите название ядра", "Укажите название");
            }
            else
            {
                setDataToDB();
            }
        }

        /* Загрузка изменений в БД */
        private void setDataToDB()
        {
            int productType = -1;
            string errors = "";
            string sqlStatements = "";
            int categoryId = -1;

            for (int i = 0; i < dgv_ProductTypes.RowCount - 1; i++)
            {
                if (dgv_ProductTypes.Rows[i].Cells[1].Value.ToString().Equals(cb_ProductType.SelectedItem.ToString()))
                {
                    productType = int.Parse(dgv_ProductTypes.Rows[i].Cells[0].Value.ToString());
                }
            }

            if (rb_NewCategory.Checked)        //сохраняем в новой categoryId
            {
                connection.Open();
                sqlStatements = "INSERT INTO [KeywordCategory] ([CategoryName]) VALUES ('" + tb_AddCategory.Text + "')";
                SqlCommand command = new SqlCommand(sqlStatements, connection);
                command.ExecuteScalar();
                connection.Close();

                dgv_Categories.Rows.Clear();
                GetCategories();
            }

            for (int i = 0; i < dgv_Categories.RowCount - 1; i++)
            {
                for (int j = 0; j < cb_KeywordCategory.Items.Count; j++)
                {
                    if (dgv_Categories.Rows[i].Cells[1].Value.ToString().Equals(cb_KeywordCategory.Items[j].ToString()))
                    {
                        categoryId = int.Parse(dgv_Categories.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }

            int index = -1;

            try { connection.Open(); }
            catch (Exception e) { MessageBox.Show("Ошибка подключения к БД", "Ошибка"); }

            for (int i = 0; i < dgv_Target.RowCount; i++)
            {
                try
                {
                    sqlStatements = "INSERT INTO [SemCore] ([ProductTypeId], [CategoryId], [Keyword], [Value], [Name]) VALUES (" + productType + ", '" + categoryId + "', '" + dgv_Target.Rows[i].Cells[0].Value.ToString() + "', '" + dgv_Target.Rows[i].Cells[1].Value.ToString() + "', '" + tb_CoreName.Text + "')";
                    index = i;

                    SqlCommand command = new SqlCommand(sqlStatements, connection);
                    command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    if (ex.HResult.Equals(int.Parse("-2146232060")))
                    {
                        errors += dgv_Target.Rows[index].Cells[0].Value.ToString() + "\n";
                    }
                }
            }
            if (!errors.Equals(""))
                MessageBox.Show("Следующие ключи не были добавлены, т.к. они уже есть в БД:\n\n" + errors, "Не всё прошло гладко");
            else
                MessageBox.Show("Все ключи были успешно добавлены!", "Успех");
            connection.Close();

            SavedStatus = true;
        }

        /* Кнопка "Отмена" */
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
                    if (tb_CoreName.Text.Equals(""))
                    {
                        MessageBox.Show("Для продолжение укажите название ядра", "Укажите название");
                    }
                    else
                    {
                        setDataToDB();
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        /* Отслеживание несохраненных изменений */
        private void dgv_Target_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgv_Target_RowsChanged();
        }

        /* Отслеживание несохраненных изменений */
        private void dgv_Target_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgv_Target_RowsChanged();
        }

        /* Изменяем статус, чтобы прога отслеживала необходимость сохранения */
        private void dgv_Target_RowsChanged()
        {
            SavedStatus = false;
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
                    if (tb_CoreName.Text.Equals(""))
                    {
                        MessageBox.Show("Для продолжение укажите название ядра", "Укажите название");
                    }
                    else
                    {
                        setDataToDB();
                        OpenNewFile();
                    }
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
                this.Close();
            }
            else
            {
                if (MessageBox.Show("Имеются несохраненные изменения. Сохранить?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (tb_CoreName.Text.Equals(""))
                    {
                        MessageBox.Show("Для продолжение укажите название ядра", "Укажите название");
                        e.Cancel = true;
                    }
                    else
                    {
                        setDataToDB();
                        this.Close();
                    }
                }
                else
                {
                    SavedStatus = true;
                    this.Close();
                }
            }
        }

        /* Вызываем Help */
        private void btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для начала откройте файл с ключевыми словами при помощи кнопки \"Загрузить другой файл\".\n\nИспользуйте клавишу \"C\" для выделения ключевого слова.\nИспользуйте клавишу \"X\" для снятия выделения ключевого слова.\n\nДважды клацните ЛКМ по ключевому слову, чтобы просмотреть его на Amazon.", "Помощь");
        }

        /* Ищем на амазоне товары по ключу, на который дважды ЛКМ */
        private void dgv_Source_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                System.Diagnostics.Process.Start(tb_Link.Text + dgv_Source.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        /* Ищем на амазоне товары по ключу, на который дважды ЛКМ */
        private void dgv_Target_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                System.Diagnostics.Process.Start(tb_Link.Text + dgv_Target.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tb_Link.Enabled = true;
            } else
            {
                tb_Link.Enabled = false;
                mf.AmazonLink = tb_Link.Text;
            }
        }
    }
}
