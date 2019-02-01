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
    public partial class MarketplaceView : Form
    {
        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;     //список всех объектов (записей из БД)

        private MainFormView controlMainFormView;

        private bool renamingInProgress;        //указатель, что сейчас идет процесс переименования выбранной категории
        private int renamedMarketplaceId;


        /* Конструктор */
        public MarketplaceView(MainFormView _mf)
        {
            InitializeComponent();

            label1.Text = "Marketplace\n\nотсутствуют";

            mpController = new MarketplaceController(this);
            
            controlMainFormView = _mf;

            mpController.GetMarketplaces();
            Draw();

            if (dgv_Marketplaces.RowCount > 0)
            {
                label1.Visible = false;
                dgv_Marketplaces.Visible = true;
            }
        }

        /* Перерисовываем таблицу новыми данными */
        private void Draw()
        {
            dgv_Marketplaces.Rows.Clear();

            for (int i = 0; i < mpList.Count; i++)
            {
                var index = dgv_Marketplaces.Rows.Add();

                for (int j = 0; j < mpList[0].ColumnCount; j++)
                {
                    dgv_Marketplaces.Rows[index].Cells[j].Value = mpList[i].ReadData(j);
                }
            }
        }

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

        /* Закрываем форму */
        private void MarketplaceView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlMainFormView != null)
                controlMainFormView.Visible = true;
        }

        /* Обновляем dgv_KeywordCategory принудительно */
        private void btn_RefreshDGV_Click(object sender, EventArgs e)
        {
            mpController.GetMarketplaces();
            Draw();
        }

        /* Закрыть окно */
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            if (renamingInProgress)
                RenamingMarketplaceEnd();
            else
                this.Close();
        }

        /* Добавить/изменить Marketplace по нажатию btn_Save */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        /* Добавить/изменить Marketplace по нажатию Enter */
        private void tb_MarketplaceName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                ApplyChanges();
        }

        /* Добавляем/изменяем Marketplace */
        private void ApplyChanges()
        {
            if (tb_MarketplaceName.Text != "")
            {
                if (!renamingInProgress)
                {
                    if (!ChechForExisting())
                    {
                        int result = mpController.SetNewMarketplace(tb_MarketplaceName.Text);

                        if (result == 1)
                        {
                            mpController.GetMarketplaces();
                            Draw();

                            MessageBox.Show("Marketplace \"" + tb_MarketplaceName.Text + "\" был добавлен успешно!", "Успешно");
                            tb_MarketplaceName.Text = "";
                        }
                        else if (result == -2146232060)
                        {
                            MessageBox.Show("Такой Marketplace уже существует. Нажмите \"Обновить\" для просмотра.", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такой Marketplace уже существует!", "Ошибка");
                    }
                }
                else
                {
                    if (mpController.UpdateExistingMarketplace(tb_MarketplaceName.Text, renamedMarketplaceId) == 1)
                    {
                        mpController.GetMarketplaces();
                        Draw();

                        MessageBox.Show("Marketplace \"" + tb_MarketplaceName.Text + "\" был переименован успешно!", "Успешно");
                        tb_MarketplaceName.Text = "";
                        RenamingMarketplaceEnd();
                    }
                    else
                    {
                        MessageBox.Show("Во время сохранение произшла ошибка. Пожалуйста, повторите попытку позже.", "Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите название Marketplace.", "Ошибка");
            }

            if (dgv_Marketplaces.RowCount > 0)
            {
                label1.Visible = false;
                dgv_Marketplaces.Visible = true;
            }
        }

        /* Проверка перед сохранение в БД на наличие существующей категории с таким же именем */
        private bool ChechForExisting()
        {
            bool flag = false;

            for (int i = 0; i < dgv_Marketplaces.RowCount; i++)
            {
                if (dgv_Marketplaces.Rows[i].Cells[1].Value.ToString().ToLower().Equals(tb_MarketplaceName.Text.ToLower()))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /* Начать редактирование Marketplace по двойному ЛКМ на ячейку */
        private void dgv_Marketplaces_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Marketplaces.RowCount > 0)
            {
                var str = dgv_Marketplaces.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Clipboard.SetText(str);
            }
        }

        /* Изменяем UI под редактирование Marketplace */
        private void RenamingMarketplaceBegin(string name)
        {
            groupBox1.Text = "Изменение названия Marketplace";
            btn_Close.Text = "Отмена";
            renamingInProgress = true;
            tb_MarketplaceName.Text = name;
            tb_MarketplaceName.Focus();
        }

        /* Возвращаем UI к созданию Marketplace */
        private void RenamingMarketplaceEnd()
        {
            groupBox1.Text = "Добавление нового Marketplace";
            btn_Close.Text = "Закрыть";
            renamingInProgress = false;
            tb_MarketplaceName.Text = "";
        }

        /* При ПКМ по названию Marketplace в dgv включаем режим редактирования */
        private void dgv_Marketplaces_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    dgv_Marketplaces.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    renamedMarketplaceId = int.Parse(dgv_Marketplaces.Rows[e.RowIndex].Cells[0].Value.ToString());
                    RenamingMarketplaceBegin(dgv_Marketplaces.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
        }
    }
}
