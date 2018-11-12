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
    public partial class KeywordsAreExisted : Form
    {
        private string[,] arr;
        private string choosenCategory;
        private string str = "В таблице далее представлены ключи, которые не были обновлены, поскольку они уже существуют в БД, но не принадлежат выбранной категории ";

        private string informationString = "Представленные в таблице ключи, вероятно, уже существуют в БД, но относятся к категории, отличной от указанной Вами. \nВы можете сохранить эти ключи путем экспорта их в *.xls файл (кнопка \"Экспорт\") или изменить их категорию и попробовать еще раз (кнопка \"Редактировать\").";

        public KeywordsAreExisted(string[,] _arr, string _category)
        {
            InitializeComponent();
            arr = _arr;
            choosenCategory = _category;
            lb_Information.Text = informationString;

            FillDGV();
            MessageBox.Show(str + "(категория: " + choosenCategory + ").", "Внимание");
        }

        private void FillDGV()
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                var index = dgv_Keywords.Rows.Add();

                for (int j = 0; j < 2; j++)
                {
                    dgv_Keywords.Rows[index].Cells[j].Value = arr[i, j];
                }
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {

        }

        private void KeywordsAreExisted_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            FullSemCore fsc = new FullSemCore(this);
            if (fsc.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btn_SetAndInsertKeys_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
