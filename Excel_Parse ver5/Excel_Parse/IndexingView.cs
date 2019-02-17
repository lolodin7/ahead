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
    public partial class IndexingView : Form
    {
        private MainFormView controlMainFormView;

        private List<SemanticsModel> smList;

        private SqlConnection connection;
        private SqlCommand command;

        private List<ProductsModel> pList;
        private List<ProductsModel> pmUniqueList;
        private List<IndexingModel> imList;     //список индексаций, который получаем из БД
        private List<IndexingModel> imNEWList;  //список индексаций товаров для сегодняшнего дня, которые нужно добавить в БД

        private DateTime todayDate;         //храним сегодняшнюю дату

        string AmazonLink;

        private string helpString = "Дважды ЛКМ по сегодняшней дате - запуск проверки индексации.\n\n";

        /* Конструктор */
        public IndexingView(MainFormView _mf)
        {
            InitializeComponent();

            controlMainFormView = _mf;
            connection = DBData.GetDBConnection();
            imNEWList = new List<IndexingModel> { };
            todayDate = DateTime.Now;
            smList = new List<SemanticsModel> { };
            AmazonLink = _mf.AmazonLink;

            GetStarted();
        }


        /* Метод при первом запуске формы */
        private void GetStarted()
        {
            Add6ColumnsToDGV();

            GetProductFromDB();
            getUniquesASIN();
            SetProductsListToDGV();

            GetDatesFromDB();
            SetDatesToDGV();
        }

        /* Выделяем уникальные ASIN с разных SKU (работа с товарами, у которых ещё нет семантики) */
        private void getUniquesASIN()
        {
            List<string> tmp = new List<string> { };
            pList = new List<ProductsModel> { };

            if (pmUniqueList != null)
            {
                for (int i = 0; i < pmUniqueList.Count; i++)
                {
                    if (!tmp.Contains(pmUniqueList[i].ASIN))
                    {
                        ProductsModel pmModel = new ProductsModel();
                        pList.Add(pmModel);

                        pList[pList.Count - 1] = pmUniqueList[i];
                        tmp.Add(pmUniqueList[i].ASIN);
                    }

                }
            }
        }

        /* Добавляем 6 столбцов в начало dgv */
        private void Add6ColumnsToDGV()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("1", "1");
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;

            dataGridView1.Columns.Add("proNameColmn", "Название товара");
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = 250;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add("asinColmn", "ASIN");
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = 125;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns.Add("skuColmn", "SKU");
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = 125;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;

            dataGridView1.Columns.Add("5", "5");
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;

            dataGridView1.Columns.Add("6", "6");
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;

            dataGridView1.Columns.Add("7", "7");
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
        }

        /* Получаем товары из БД */
        private void GetProductFromDB()
        {
            pmUniqueList = new List<ProductsModel> { };

            string sqlStatement = "SELECT * FROM Products WHERE ProductId > 0";

            command = new SqlCommand(sqlStatement, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
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

        /* Заносим данные в List<ProductsModel> */
        private void SetProductsToList(IDataRecord record)
        {
            ProductsModel pModel = new ProductsModel();
            pmUniqueList.Add(pModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                pmUniqueList[pmUniqueList.Count - 1].WriteData(i, record[i]);
            }
        }

        /* Заносим все продукты в dgv */
        private void SetProductsListToDGV()
        {
            for (int i = 0; i < pList.Count; i++)
            {                
                var index = dataGridView1.Rows.Add();

                for (int j = 0; j < pList[0].ColumnCount; j++)
                {
                    dataGridView1.Rows[index].Cells[j].Value = pList[i].ReadData(j);
                    dataGridView1.Rows[index].Resizable = DataGridViewTriState.False;
                }
            }
        }


        /* Для каждого товара в таблице по очереди получаем списки дат его индексации из БД */
        private void GetDatesFromDB()
        {
            imList = new List<IndexingModel> { };

            connection.Open();
            for (int i = 0; i < pList.Count; i++)
            {
                imList.Add(new IndexingModel());

                string sqlStatement = "SELECT * FROM Indexing WHERE ProductId = " + pList[i].ProductId;

                command = new SqlCommand(sqlStatement, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDataRecord record = (IDataRecord)reader;

                        imList[imList.Count - 1].WriteIndexing(0, record[0]);       //чтобы не дублировать productId и ASIN, их пишем раз для объекта
                        imList[imList.Count - 1].WriteIndexing(1, record[1]);

                        SetDatesToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
            connection.Close();
        }

        /* Заносим данные в List<DateTime> */
        private void SetDatesToList(IDataRecord record)
        {
            for (int i = 2; i < record.FieldCount; i++)
            {
                imList[imList.Count - 1].WriteIndexing(i, record[i]);
            }
        }

        /* Заносим Dates в dgv */
        private void SetDatesToDGV()
        {
            PrepareDGVColumns();

            int _prodId;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                _prodId = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());

                for (int j = 0; j < imList.Count; j++)
                {
                    if (_prodId == imList[j].ProductId)
                    {
                        DrawDatesInDGV(j, i);
                    }

                }
            }
        }

        /* Заносим даты по столбцам для каждого товара */
        private void DrawDatesInDGV(int index, int row)
        {
            for (int i = 6; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < imList[index].DateList.Count; j++)
                {
                    if (imList[index].DateList[j].ToShortDateString().Equals(dataGridView1.Columns[i].HeaderText))
                    {
                        dataGridView1.Rows[row].Cells[i].Value = imList[index].Status[j];
                        if (imList[index].Status[j].Equals("Not Ok"))
                        {
                            dataGridView1.Rows[row].Cells[i].Style.BackColor = Color.Coral;
                        }
                    }
                }
            }
        }

        /* Добавляем колонки дат в dgv */
        private void PrepareDGVColumns()
        {
            List<DateTime> tmpListDateTime = new List<DateTime> { };
            List<DateTime> ListDateTime = new List<DateTime> { };

            //получаем список дублирующихся дат для всех товаров
            for (int i = 0; i < imList.Count; i++)
            {
                for (int j = 0; j < imList[i].DateList.Count; j++)
                {
                    tmpListDateTime.Add(new DateTime());
                    tmpListDateTime[tmpListDateTime.Count - 1] = imList[i].DateList[j];
                }
            }

            //удаляем дубликаты дат, оставляем только уникальные даты
            for (int i = 0; i < tmpListDateTime.Count; i++)
            {
                if (!ListDateTime.Contains(tmpListDateTime[i]))
                {
                    ListDateTime.Add(tmpListDateTime[i]);
                }                
            }

            //сортируем, чтобы не было вразброс
            ListDateTime.Sort();

            if (ListDateTime.Count > 0) {
                //добавляем сегодняшний день
                if (!ListDateTime[ListDateTime.Count - 1].ToShortDateString().Equals(todayDate.ToShortDateString()))      //если сегодня еще не добавляли индексации
                    ListDateTime.Add(todayDate);
            } else
            {
                ListDateTime.Add(todayDate);
            }

            //создаем колонки по уникальным датам
            for (int i = ListDateTime.Count - 1; i >= 0; i--)
            {
                dataGridView1.Columns.Add(ListDateTime[i].ToShortDateString(), ListDateTime[i].ToShortDateString());
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = 70;
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        
        /* Отметить новый день как Closed */
        private void markAsClosedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int col = dataGridView1.CurrentCell.ColumnIndex - 7;

            int _productId = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());

            if (col == 0)       //если это текущий день
            {
                for (int i = 0; i < imList.Count; i++)
                {
                    if (_productId == pList[i].ProductId)
                    {
                        dataGridView1.Rows[row].Cells[col + 7].Value = "Closed";

                        string sqlStatement = "INSERT INTO [Indexing] ([ProductId], [ASIN], [Date], [Status], [Notes]) VALUES (" + pList[i].ProductId + ", '" + pList[i].ASIN + "', '" + todayDate.ToString("yyyy-MM-dd") + "', 'Closed', '')";

                        command = new SqlCommand(sqlStatement, connection);

                        connection.Open();
                        command.ExecuteScalar();
                        connection.Close();
                    }
                }
            }
        }

        /* Открыть семантику товара */
        private void showSemanticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;

            int _ProductId = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
            string _ProductName = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string _ASIN = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string _SKU = dataGridView1.Rows[row].Cells[3].Value.ToString();
            int _ProductTypeId = int.Parse(dataGridView1.Rows[row].Cells[4].Value.ToString());


            try
            {
                SemanticsView sv = new SemanticsView(this, _ProductId, _ProductName, _ASIN, _SKU, _ProductTypeId);
                sv.Show();
                this.Visible = false;
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.HResult);
                MessageBox.Show("Возникли проблемы с отображением семантики для выбранного товара, либо для этого товара ещё нет семантики.", "Ошибка");
            }
        }

        /* Показать Notes для выбранного дня */
        private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int col = dataGridView1.CurrentCell.ColumnIndex;

            if (dataGridView1.Rows[row].Cells[col].Value != null && dataGridView1.Rows[row].Cells[col].Value.ToString().Equals("Not Ok"))
            {
                int proId = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
                string asin = dataGridView1.Rows[row].Cells[2].Value.ToString();
                string prodName = dataGridView1.Rows[row].Cells[1].Value.ToString();
                string sku = dataGridView1.Rows[row].Cells[3].Value.ToString();
                string dt = dataGridView1.Columns[col].HeaderText;


                using (IndexingDetails indStatus = new IndexingDetails(proId, asin, sku, prodName, this, getDT(dt)))
                {
                    indStatus.ShowDialog();
                }
            }
        }

        private DateTime getDT(string dt)
        {
            int day = int.Parse(dt.Substring(0, 2));
            int month = int.Parse(dt.Substring(3, 2));
            int year = int.Parse(dt.Substring(6, 4));

            return new DateTime(year, month, day);
        }
        

        /* Закрытие формы */
        private void IndexingView_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlMainFormView.Visible = true;
        }
        
        /* Выделяем ячейку под укуазателем мыши */
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }
    
        /* Запускаем индексацию, получаем поля семантики из БД и открываем с их помощью вкладки поиска на Амазон */
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 7 && (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("")))
            {
                int row = dataGridView1.CurrentCell.RowIndex;
                int col = dataGridView1.CurrentCell.ColumnIndex;


                int proId = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
                string asin = dataGridView1.Rows[row].Cells[2].Value.ToString();
                string prodName = dataGridView1.Rows[row].Cells[1].Value.ToString();
                string sku = dataGridView1.Rows[row].Cells[3].Value.ToString();
                DateTime dt = DateTime.Now;

                //IndexingStatus indst = new IndexingStatus(proId, asin, sku, prodName, this, dt);

                //indst.Show();
                //this.Visible = false;

                //getSemanticsFromDBAndOpenURL(proId);

                string sqlSemantics = "SELECT * FROM Semantics WHERE ProductId = " + proId;
                SqlCommand command = new SqlCommand(sqlSemantics, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SetSemanticsToList((IDataRecord)reader);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Упс! Возникла проблема с подключением к БД.", "Ошибка");
                    return;
                }
                if (smList.Count > 0)
                {
                    IndexingStatus indst = new IndexingStatus(proId, asin, sku, prodName, this, dt);

                    indst.Show();
                    this.Visible = false;

                    System.Diagnostics.Process.Start(AmazonLink + smList[smList.Count - 1].Title.Replace(' ', '+'));
                    System.Threading.Thread.Sleep(200);
                    System.Diagnostics.Process.Start(AmazonLink + smList[smList.Count - 1].Bullet1.Replace(' ', '+'));
                    System.Threading.Thread.Sleep(200);
                    System.Diagnostics.Process.Start(AmazonLink + smList[smList.Count - 1].Bullet2.Replace(' ', '+'));
                    System.Threading.Thread.Sleep(200);
                    System.Diagnostics.Process.Start(AmazonLink + smList[smList.Count - 1].Bullet3.Replace(' ', '+'));
                    System.Threading.Thread.Sleep(200);
                    System.Diagnostics.Process.Start(AmazonLink + smList[smList.Count - 1].Bullet4.Replace(' ', '+'));
                    System.Threading.Thread.Sleep(200);
                    System.Diagnostics.Process.Start(AmazonLink + smList[smList.Count - 1].Bullet5.Replace(' ', '+'));
                    System.Threading.Thread.Sleep(200);
                    System.Diagnostics.Process.Start(AmazonLink + smList[smList.Count - 1].Backend.Replace(' ', '+'));

                    smList.RemoveAt(0);
                }
                else
                {
                    MessageBox.Show("Семантики для выбранного товара не найдено.", "Ошибка");
                }
            }
        }
        
        /* Заполняем список семантиками данными, полученными с БД */
        private void SetSemanticsToList(IDataRecord record)
        {
            SemanticsModel sm = new SemanticsModel();
            smList.Add(sm);

            for (int i = 0; i < record.FieldCount; i++)
            {
                smList[smList.Count - 1].SetSemantics(i, record[i]);
            }
        }


        /* Чтобы обновлялись данные в dgv после проверки индексации товара */
        private void IndexingView_VisibleChanged(object sender, EventArgs e)
        {
            GetStarted();
        }

        /* Тест, проверяем, корректен ли наш адрес на амазоне */
        private void checkAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AmazonLink + "lavalier+microphone");
        }

        /* При открытии контекстного меню, включаем/выключаем кликабельность определенных пунктов меню */
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.RowCount > 0 && dataGridView1.ColumnCount > 0)
            {
                contextMenuStrip1.Enabled = true;
                int row = dataGridView1.CurrentCell.RowIndex;
                int col = dataGridView1.CurrentCell.ColumnIndex;

                if (col == 7)
                {
                    if (dataGridView1.Rows[row].Cells[col].Value != null)
                    {
                        if (dataGridView1.Rows[row].Cells[col].Value.ToString().Equals("Not Ok"))
                        {
                            markAsClosedToolStripMenuItem.Enabled = false;
                            showHistoryToolStripMenuItem.Enabled = true;
                        }
                        else if (dataGridView1.Rows[row].Cells[col].Value.ToString().Equals("Ok") || dataGridView1.Rows[row].Cells[col].Value.ToString().Equals("Closed"))
                        {
                            markAsClosedToolStripMenuItem.Enabled = false;
                            showHistoryToolStripMenuItem.Enabled = false;
                        }
                    }
                    else
                    {
                        markAsClosedToolStripMenuItem.Enabled = true;
                        showHistoryToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    if (dataGridView1.Rows[row].Cells[col].Value != null && dataGridView1.Rows[row].Cells[col].Value.ToString().Equals("Not Ok"))
                    {
                        markAsClosedToolStripMenuItem.Enabled = false;
                        showHistoryToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        markAsClosedToolStripMenuItem.Enabled = false;
                        showHistoryToolStripMenuItem.Enabled = false;
                    }
                }
            }
            else
            {
                contextMenuStrip1.Enabled = false;
            }
        }

        /* Изменить url из контекстного меню */
        private void changeURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tb_URL.Text = AmazonLink;
            tb_URL.Visible = true;
            btn_SaveUrl.Visible = true;

            dataGridView1.Size = new Size(1255, 612);
            dataGridView1.Location = new Point(13, 26);
        }

        /* Сохранить новый url */
        private void btn_SaveUrl_Click(object sender, EventArgs e)
        {
            AmazonLink = tb_URL.Text;
            tb_URL.Visible = false;
            btn_SaveUrl.Visible = false;

            dataGridView1.Size = new Size(1255, 635);
            dataGridView1.Location = new Point(13, 3);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(helpString, "Помощь");
        }        
    }
}
