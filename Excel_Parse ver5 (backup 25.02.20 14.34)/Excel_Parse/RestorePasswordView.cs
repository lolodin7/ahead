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
    public partial class RestorePasswordView : Form
    {
        private LoginFormController lfController;
        private UserModel um;
        private LoginFormView controlLoginFormView;
        private ControlPanelView controlControlPanelView;
        private SecuredPasswordController spControl;

        private int phase;      //1 - ввод логина; 2 - ответ на вопрос; 3 - ввод нового пароля
        private bool ChangedSuccessfully;

        string message1 = "Для восстановления пароля введите свой логин в поле внизу.";
        string message2 = "Чтобы продолжить, дайте ответ на секретный вопрос.";
        string message3 = "Введите новый пароль.";

        public RestorePasswordView(LoginFormView _lf)
        {
            InitializeComponent();
            lfController = new LoginFormController(this);
            spControl = new SecuredPasswordController();
            controlLoginFormView = _lf;
            ChangedSuccessfully = false;
            label1.Text = message1;
            phase = 1;
        }

        public RestorePasswordView(ControlPanelView _cp, UserModel _um)
        {
            InitializeComponent();
            lfController = new LoginFormController(this);
            spControl = new SecuredPasswordController();
            controlControlPanelView = _cp;
            um = _um;

            ChangedSuccessfully = false;
            label1.Text = message2;
            phase = 2;
            tb_Input1.Visible = false;
            tb_Input2.Visible = true;
            label2.Visible = true;
            label1.Text = message2;
            label2.Text = um.SecretQuestion;
            this.Text = "Изменение пароля";
            tb_Input2.Focus();
        }

        /* Получаем данные пользователя из БД */
        public void GetUserDataFromDB(UserModel _um)
        {
            um = _um;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            Next();
        }

        /* Основная логика по восстановлению пароля */
        private void Next()
        {
            switch (phase)
            {
                case 1:
                    if (!tb_Input1.Text.Equals(""))     //если поле не пустое
                    {
                        string result = lfController.GetUserDataFromDB(tb_Input1.Text);
                        if (result.Contains("good"))      //получаем данные пользователя по логину
                        {
                            phase = 2;
                            tb_Input1.Visible = false;
                            tb_Input2.Visible = true;
                            label2.Visible = true;
                            label1.Text = message2;
                            label2.Text = um.SecretQuestion;
                            tb_Input2.Focus();
                        }
                        else if (result.Contains("error: 40 ")) { MessageBox.Show("Не удалось установить соединение с сервером. Попробуйте позже.", "Ошибка"); }
                        else if (result.Contains("fail")) { MessageBox.Show("Имя пользователя или пароль введены неверно.", "Ошибка"); }
                    }
                    else
                        MessageBox.Show("Введите логин пользователя.", "Ошибка");
                    break;
                case 2:
                    if (!tb_Input2.Text.Equals(""))  //если поле не пустое
                    {
                        if (spControl.VerifyHashedPassword(um.Answer, tb_Input2.Text))   //сравнивае ответ с хранимым овтетом
                        {
                            label2.Visible = false;
                            tb_Input1.Visible = true;
                            phase = 3;
                            tb_Input1.Text = "";
                            tb_Input2.Text = "";
                            tb_Input1.Focus();
                            label1.Text = message3;
                            tb_Input1.PasswordChar = '*';
                            tb_Input2.PasswordChar = '*';
                        }
                        else
                            MessageBox.Show("Вы дали неверный ответ на вопрос.", "Ошибка");
                    }
                    break;
                case 3:
                    if (tb_Input1.Text.Equals(""))   //если 1е поле пароля не пустое
                        MessageBox.Show("Введите пароль!", "Ошибка");
                    else
                    {
                        if (tb_Input2.Text.Equals(""))   //если 2е поле пароля не пустое
                            MessageBox.Show("Введите пароль повторно!", "Ошибка");
                        else
                            if (tb_Input1.Text.Equals(tb_Input2.Text))   //если пароли в полях совпадают
                            {
                                if (lfController.UpdateUserPassword(um.UserId, spControl.HashPassword(tb_Input1.Text)))  //обновляем пароль
                                {
                                    MessageBox.Show("Пароль был успешно изменен!", "Успех");
                                    ChangedSuccessfully = true;
                                }
                                else
                                    MessageBox.Show("Произошла ошибка при сохранении. Попробуйте ещё раз.", "Ошибка");

                                if (ChangedSuccessfully)    //если обновили успешно, возвращаемся на форму входа
                                    this.Close();
                            }
                            else
                                MessageBox.Show("Пароли не совпадают!", "Ошибка");
                    }
                    break;
            }
        }

        private void RestorePasswordView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlLoginFormView != null)
                controlLoginFormView.Visible = true;
            else if (controlControlPanelView != null)
                controlControlPanelView.Visible = true;
        }

        /* Продолжение по нажатию Enter в поле ввода */
        private void tb_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Next();
                e.SuppressKeyPress = true;
            }
        }

        /* Делаем фокус на поле ввода при отображении формы для удобства */
        private void RestorePasswordView_Shown(object sender, EventArgs e)
        {
            tb_Input1.Focus();
        }
    }
}
