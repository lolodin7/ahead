using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class TestForm : Form
    {
        SemCoreController smc;
        List<SemCoreModel> scmList;     //список всех объектов (записей из БД)
        private int CurrentColumnCount;

        public TestForm()
        {
            InitializeComponent();
            CurrentColumnCount = 0;

            smc = new SemCoreController(this);
        }

        /* Перерисовываем таблицу новыми данными */
        private void Draw()
        {
            if (CurrentColumnCount == 6)
                RefreshTable_6();
            else if (CurrentColumnCount == 10)
                RefreshTable_10();

            for (int i = 0; i < scmList.Count; i++)
            {
                var index = dataGridView1.Rows.Add();

                for (int j = 0; j < scmList[0].ColumnCount; j++)
                {
                    dataGridView1.Rows[index].Cells[j].Value = scmList[i].ReadData(j);
                }
            }
        }
        
        /* Получаем из контроллера данные полученные с БД */
        public void RefreshData(object _scmList)
        {
            scmList = (List<SemCoreModel>)_scmList;
        }

        /* Перерисовываем пустую таблицу на 6 столбцов */
        public void RefreshTable_6()
        {
            dataGridView1.Columns.Clear();
            AddColumns_6();
        }

        /* Перерисовываем пустую таблицу на 10 столбцов */
        public void RefreshTable_10()
        {
            dataGridView1.Columns.Clear();
            AddColumns_10();
        }

        /* Программно создаем столбцы в dataGridView */
        public void AddColumns_10()
        {
            dataGridView1.Columns.Add("categoryIdCl", "categoryIdCl");
            dataGridView1.Columns.Add("productTypeIdCl", "productTypeIdCl");
            dataGridView1.Columns.Add("keywordCl", "Ключ");
            dataGridView1.Columns.Add("valueCl", "Частота");
            dataGridView1.Columns.Add("LastUpdatedCl", "Обновлено");
            dataGridView1.Columns.Add("semCoreIdCl", "semCoreIdCl");
            dataGridView1.Columns.Add("categIdCl", "categIdCl");
            dataGridView1.Columns.Add("categNameCl", "Название категории");
            dataGridView1.Columns.Add("prodTypeIdCl", "prodTypeIdCl");
            dataGridView1.Columns.Add("prodTypeNameCl", "Вид товара");

            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[9].Width = 150;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            dataGridView1.Width = 860;
            dataGridView1.ScrollBars = ScrollBars.Vertical;

            CurrentColumnCount = 10;
        }

        /* Программно создаем столбцы в dataGridView */
        public void AddColumns_6()
        {
            dataGridView1.Columns.Add("categoryIdCl", "categoryIdCl");
            dataGridView1.Columns.Add("productTypeIdCl", "productTypeIdCl");
            dataGridView1.Columns.Add("keywordCl", "Ключ");
            dataGridView1.Columns.Add("valueCl", "Частота");
            dataGridView1.Columns.Add("LastUpdatedCl", "Обновлено");
            dataGridView1.Columns.Add("semCoreIdCl", "semCoreIdCl");

            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;

            dataGridView1.Width = 545;
            dataGridView1.ScrollBars = ScrollBars.Vertical;

            CurrentColumnCount = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            smc.GetSemCoreByProductId(1);
            Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            smc.GetSemCoreByProductId(2);
            Draw();
        }
    }
}
