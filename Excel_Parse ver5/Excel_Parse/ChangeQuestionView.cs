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
    public partial class ChangeQuestionView : Form
    {
        private UserModel um;

        private ControlPanelView controlControlPanelView;
        private SecuredPasswordController controlSecuredPasswordController;
        private LoginFormController controlLoginFormController;

        private string message1 = "Введите новый ответ";
        private string message2 = "Введите новый вопрос и ответ на него";

        private int phaseChangingAnswer;
        private int phaseChangingQuestion;

        public ChangeQuestionView(string _value, ControlPanelView _cp, UserModel _um)
        {
            InitializeComponent();

            if (_value.Equals("question"))
            {
                panel2.Visible = true;
                this.Text = "Изменение секретного вопроса";
            }
            else
            {
                panel1.Visible = true;
                this.Text = "Изменение ответа";
            }

            phaseChangingAnswer = 1;
            phaseChangingQuestion = 1;

            controlControlPanelView = _cp;
            um = _um;
            controlSecuredPasswordController = new SecuredPasswordController();
            controlLoginFormController = new LoginFormController(this);            
        }


        private void ChangeQuestionView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlControlPanelView != null)
                controlControlPanelView.Visible = true;
        }

        /* Обновляем ответ на вопрос */
        private void btn_Next_Click(object sender, EventArgs e)
        {
            switch (phaseChangingAnswer)
            {
                case 1:
                    if (!tb_Answer.Text.Equals(""))      
                    {
                        if (controlSecuredPasswordController.VerifyHashedPassword(um.Answer, tb_Answer.Text))   //проверяем текущий ответ
                        {
                            lb_AnswerTxt.Text = message1;
                            phaseChangingAnswer = 2;
                            tb_Answer.Text = "";
                        }
                        else { MessageBox.Show("Вы ввели неверный ответ!", "Ошибка"); }
                    }
                    else { MessageBox.Show("Введите текущий ответ для продолжения.", "Ошибка"); }
                    break;
                case 2:
                    if (!tb_Answer.Text.Equals(""))     //обновляем ответ
                    {
                        string newAnswer = controlSecuredPasswordController.HashPassword(tb_Answer.Text);

                        if (controlLoginFormController.UpdateAnswer(um.UserId, newAnswer))      //обновляем
                            MessageBox.Show("Ответ был успешно обновлен!", "Успех");

                        controlControlPanelView.QuestionChanged(newAnswer);
                        this.Close();
                    }
                    else { MessageBox.Show("Введите новый ответ!", "Ошибка"); }
                    break;
            }
        }

        /* Обновляем секретный вопрос и ответ на него */
        private void btn_ChangeQuestion_Click(object sender, EventArgs e)
        {
            switch (phaseChangingQuestion)
            {
                case 1:
                    if (!tb_NewAnswer.Text.Equals(""))      
                    {
                        if (controlSecuredPasswordController.VerifyHashedPassword(um.Answer, tb_NewAnswer.Text))    //проверяем текущий ответ
                        {
                            lb_Panel2.Text = message2;
                            phaseChangingQuestion = 2;
                            tb_NewAnswer.Text = "";
                            tb_NewQuestion.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                        }
                        else { MessageBox.Show("Вы ввели неверный ответ!", "Ошибка"); }
                    }
                    else { MessageBox.Show("Введите текущий ответ для продолжения.", "Ошибка"); }
                    break;
                case 2:
                    if (!tb_NewQuestion.Text.Equals(""))
                    {
                        if (!tb_NewAnswer.Text.Equals(""))      //обновляем данные 
                        {
                            string newQuestion = tb_NewQuestion.Text;
                            string newAnswer = controlSecuredPasswordController.HashPassword(tb_NewAnswer.Text);

                            if (controlLoginFormController.UpdateQuestionAndAnswer(um.UserId, newQuestion, newAnswer))      //обновляем
                            {
                                MessageBox.Show("Секретный вопрос и ответ были успешно обновлены.", "Успех");
                                controlControlPanelView.QuestionChanged(newQuestion, newAnswer);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Произошла ошибка при обновлении. Повторите позже.", "Ошибка");
                        }
                        else
                            MessageBox.Show("Введите ответ на новый вопрос!", "Ошибка");
                    }
                    else
                        MessageBox.Show("Введите новый вопрос!", "Ошибка");
                    break;
            }
        }
    }
}
