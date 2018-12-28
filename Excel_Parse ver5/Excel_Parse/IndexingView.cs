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

        private SqlConnection connection;
        private SqlCommand command;

        private List<ProductsModel> pList;

        private List<IndexingModel> imList;     //список индексаций, который получаем из БД

        private List<IndexingModel> imNEWList;  //список индексаций товаров для сегодняшнего дня, которые нужно добавить в БД

        private DateTime todayDate;         //храним сегодняшнюю дату

        public IndexingView()
        {
            InitializeComponent();
        }

        public IndexingView(MainFormView _mf)
        {
            InitializeComponent();

            controlMainFormView = _mf;
            connection = DBData.GetDBConnection();
            imNEWList = new List<IndexingModel> { };
            todayDate = DateTime.Now;

            GetStarted();
        }


        /* Метод при первом запуске формы */
        private void GetStarted()
        {
            GetProductFromDB();
            SetProductsListToDGV();

            GetDatesFromDB();
            SetDatesToDGV();
        }


        /* Получаем товары из БД */
        private void GetProductFromDB()
        {
            pList = new List<ProductsModel> { };

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
            pList.Add(pModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                pList[pList.Count - 1].WriteData(i, record[i]);
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
            List<int> tmp = new List<int> { };

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
            for (int i = 0; i < tmpListDateTime.Count - 1; i++)
            {
                for (int j = i + 1; j < tmpListDateTime.Count; j++)
                {
                    if (tmpListDateTime[i] == tmpListDateTime[j])
                        //tmpListDateTime.RemoveAt(j);
                        tmp.Add(j);
                }
            }


            //добавляем сегодняшний день
            if (!tmpListDateTime[tmpListDateTime.Count - 1].ToShortDateString().Equals(todayDate.ToShortDateString()))      //если сегодня еще не добавляли индексации
                tmpListDateTime.Add(todayDate);

            //сортируем, чтобы не было вразброс
            tmpListDateTime.Sort();

            //создаем колонки по уникальным датам
            for (int i = tmpListDateTime.Count - 1; i >= 0; i--)
            {
                dataGridView1.Columns.Add(tmpListDateTime[i].ToShortDateString(), tmpListDateTime[i].ToShortDateString());
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = 70;
            }
        }




        /* Отметить новый день как Closed */
        private void markAsClosedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int col = dataGridView1.CurrentCell.ColumnIndex - 6;

            int _productId = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());

            if (col == 0)       //если это текущий день
            {
                //dataGridView1.Rows[row].Cells[col + 6].Style.BackColor = Color.Cyan;

                for (int i = 0; i < imList.Count; i++)
                {
                    if (_productId == pList[i].ProductId)
                    {
                        //imNEWList.Add(new IndexingModel());

                        //imNEWList[imNEWList.Count - 1].WriteIndexing(0, imList[i].ProductId);
                        //imNEWList[imNEWList.Count - 1].WriteIndexing(1, imList[i].ASIN);
                        //imNEWList[imNEWList.Count - 1].WriteIndexing(2, todayDate);
                        //imNEWList[imNEWList.Count - 1].WriteIndexing(3, "Closed");
                        //imNEWList[imNEWList.Count - 1].WriteIndexing(4, "");

                        dataGridView1.Rows[row].Cells[col + 6].Value = "Closed";

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

            SemanticsView sv = new SemanticsView(this, _ProductId, _ProductName, _ASIN, _SKU, _ProductTypeId);
            sv.Show();
            this.Visible = false;
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
                string sku = dataGridView1.Rows[row].Cells[3].Value.ToString();
                string dt = dataGridView1.Columns[col].HeaderText;            


                using (IndexingDetails indStatus = new IndexingDetails(proId, asin, sku, this, getDT(dt)))
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

        private void button2_Click(object sender, EventArgs e)
        {
            IndexingStatus indst = new IndexingStatus(1, "asfsF3f", "Product Name", this);
            indst.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IndexingDetails indd = new IndexingDetails(1, "asfsF3f", "Product Name", this, DateTime.Now);
            indd.Show();
            this.Visible = false;
        }

        /* Выделяем ячейку под укуазателем мыши */
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

    }
}
