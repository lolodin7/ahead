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
    public partial class ControlPanelView : Form
    {
        private const int NameLength = 3;       //минимальная длина имени пользователя

        private UserModel um;
        private MainFormView controlMainFormView;

        private LoginFormController loginFormController;

        public ControlPanelView(UserModel _um, MainFormView _mf)
        {
            InitializeComponent();
            controlMainFormView = _mf;
            um = _um;

            loginFormController = new LoginFormController(this);

            lb_Name.Text = um.Name;
            lb_Login.Text = um.Login;
            lb_Question.Text = um.SecretQuestion;
            lb_Role.Text = loginFormController.GetUserRoleName(um.UserRoleId);
        }

        private void ControlPanelView_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlMainFormView.Visible = true;
        }

        private void btn_ChangeName_Click(object sender, EventArgs e)
        {
            if (!btn_ChangeName.Text.Equals("Сохранить"))
            {
                tb_ChangeName.Visible = true;
                btn_ChangeName.Text = "Сохранить";
                tb_ChangeName.Text = lb_Name.Text;
                tb_ChangeName.Focus();
                btn_CancelChangeName.Visible = true;
            }
            else
            {
                if (tb_ChangeName.Text.Length > NameLength)
                {
                    tb_ChangeName.Visible = false;
                    btn_ChangeName.Text = "Изменить";
                    lb_Name.Text = tb_ChangeName.Text;
                    tb_ChangeName.Text = "";

                    //обновляем в БД
                    if (loginFormController.UpdateUserName(um.UserId, lb_Name.Text))
                        controlMainFormView.um.Name = lb_Name.Text;
                }
                else
                    MessageBox.Show("Длина имени не может быть меньше 5.", "Ошибка");
            }
        }

        private void btn_CancelChangeName_Click(object sender, EventArgs e)
        {
            tb_ChangeName.Visible = false;
            btn_ChangeName.Text = "Изменить";
            tb_ChangeName.Text = "";
            btn_CancelChangeName.Visible = false;
            tb_ChangeName.Focus();
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            RestorePasswordView rp = new RestorePasswordView(this, um);
            rp.Show();
            this.Visible = false;
        }

        private void btn_ChangeQuestion_Click(object sender, EventArgs e)
        {
            ChangeQuestionView cq = new ChangeQuestionView("question", this, um);
            cq.Show();
            this.Visible = false;
        }

        private void btn_ChangeAnswer_Click(object sender, EventArgs e)
        {
            ChangeQuestionView cq = new ChangeQuestionView("answer", this, um);
            cq.Show();
            this.Visible = false;
        }

        /* Обновляем значение поля в объекте после изменения этого поля пользователем */
        public void QuestionChanged(string _question, string _answer)
        {
            um.SecretQuestion = _question;
            um.Answer = _answer;
            lb_Question.Text = _question;
        }

        /* Обновляем значение поля в объекте после изменения этого поля пользователем */
        public void QuestionChanged(string _answer)
        {
            um.Answer = _answer;
        }
    }
}
