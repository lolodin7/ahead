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
    public partial class IndexingStatus : Form
    {
        private string ProductName;
        private int ProductId;
        private string ASIN;

        private IndexingView controlIndexingView;

        private bool firstLoad;     //первая запуск формы, или нет

        public IndexingStatus(int _productId, string _asin, string _productName, IndexingView _mf)
        {
            InitializeComponent();

            ProductId = _productId;
            ASIN = _asin;
            ProductName = _productName;

            controlIndexingView = _mf;
            firstLoad = true;

            this.Text = ProductName + " : " + ASIN;
        }



        /* Статус Ок (всё хорошо) */
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //сохраняем в БД со статусом Ок без каких-либо Notes



            //если всё хорошо, то
            this.Close();
        }

        /* Статус Closed (листинг закрыт) */
        private void btn_Closed_Click(object sender, EventArgs e)
        {
            //сохраняем в БД со статусом Closed без каких-либо Notes



            //если всё хорошо, то
            this.Close();
        }





        /* Закрытие формы */
        private void IndexingStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlIndexingView.Visible = true;
        }

        /* Статус Not Ok (не всё хорошо, открываем форму для внесения пометок) */
        private void btn_NotOk_Click(object sender, EventArgs e)
        {
            IndexingDetails id = new IndexingDetails(ProductId, ASIN, ProductName, this);
            id.Show();
            this.Visible = false;
        }

        /* Изменение видимости формы */
        private void IndexingStatus_VisibleChanged(object sender, EventArgs e)
        {
            if (!firstLoad)     //если не первый запуск формы
            {
                if (this.Visible == true)       //если из "невидимого" изменились на "видимого"
                {
                    this.Close();
                }
            } 
            else            //если первый запуск формы
            {
                firstLoad = false;
            }
        }
    }
}
