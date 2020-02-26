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
    public partial class ShowUsersView : Form
    {
        private MainFormView mf;
        private LoginFormController lfController;

        private List<UserModel> um;

        private bool dbSuccess;

        public ShowUsersView(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;

            lfController = new LoginFormController(this);
            dbSuccess = false;

            GetStarted();
        }

        private void GetStarted()
        {
            if (lfController.GetAllUsers())
            {
                dbSuccess = true;

                for (int i = 0; i < um.Count; i++)
                {
                    var index = dataGridView1.Rows.Add();

                    for (int j = 0; j < um[0].ColumnCount; j++)
                    {
                        dataGridView1.Rows[index].Cells[j].Value = um[i].ReadData(j);
                    }
                }

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = lfController.GetUserRoleName(int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()));
                }

            }
            else
            {
                MessageBox.Show("При загрузке произошла какая-то ошибка. Попробуйте ещё раз позже.", "Ошибка");
            }

        }

        private void ShowUsersView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }

        public void GetUserDataFromDB(List<UserModel> _um)
        {
            um = new List<UserModel> { };
            um = _um;
        }

        private void ShowUsersView_Shown(object sender, EventArgs e)
        {
            //if (!dbSuccess)
            //    this.Close();
        }
    }
}
