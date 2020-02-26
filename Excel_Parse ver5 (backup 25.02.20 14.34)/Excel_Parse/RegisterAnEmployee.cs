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
    public partial class RegisterAnEmployeeView : Form
    {
        private MainFormView mf;
        private LoginFormController lfController;
        private SecuredPasswordController spController;

        private List<UserModel> um;

        public RegisterAnEmployeeView(MainFormView _mf)
        {
            InitializeComponent();
            tb_Name.Focus();

            mf = _mf;
            lfController = new LoginFormController(this);
            spController = new SecuredPasswordController();
        }

        /* Главная логика */
        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (!tb_Name.Text.Equals("") && !tb_Login.Text.Equals("") && !tb_Pass.Text.Equals("") && !tb_PassRepeat.Text.Equals("") && !tb_Question.Text.Equals("") && !tb_Answer.Text.Equals(""))      //не пустые ли поля
            {
                if (tb_Pass.Text.Equals(tb_PassRepeat.Text))        //совпадают ли введенные пароли
                {
                    bool userIsExist = false;

                    lfController.GetAllUsers();     //получаем список всех пользователей

                    for (int i = 0; i < um.Count; i++)
                    {
                        if (tb_Login.Text.Equals(um[i].Login))
                            userIsExist = true;
                    }

                    if (!userIsExist)
                    {
                        int userRole = 2;

                        if (radioButton1.Checked)       //админ
                            userRole = 0;
                        else if (radioButton2.Checked)      //босс
                            userRole = 1;
                        else if (radioButton3.Checked)      //смертный
                            userRole = 2;

                        Random rn = new Random();

                        if (lfController.RegisterNewUser(tb_Login.Text, spController.HashPassword(tb_Pass.Text), tb_Name.Text, rn.Next(100000, 999999), rn.Next(100000, 999999), userRole, tb_Question.Text, spController.HashPassword(tb_Answer.Text), spController.GetMac()))        //создаем
                        {
                            MessageBox.Show("Пользователь был успешно создан!", "Успех");
                            this.Close();
                        }
                        else
                            MessageBox.Show("Во время создания произошла какая-то ошибка. Повторите позже.", "Ошибка");
                    }
                    else
                        MessageBox.Show("Пльзователь с таким логином уже существует.", "Ошибка");
                }
                else
                    MessageBox.Show("Введенные пароли не совпадают", "Ошибка");
            }
            else
                MessageBox.Show("Заполните все поля!", "Ошибка");
        }

        public void GetUserDataFromDB(List<UserModel> _um)
        {
            um = new List<UserModel> { };
            um = _um;
        }

        private void RegisterAnEmployeeView_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }
    }
}
