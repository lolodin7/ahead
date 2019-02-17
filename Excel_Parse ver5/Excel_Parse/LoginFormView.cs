using System;
using System.Windows.Forms;
using Excel_Parse;
using System.Configuration;
using System.Xml;
using System.Net.NetworkInformation;

namespace Bona_Fides
{
    public partial class LoginFormView : Form
    {
        public bool ReSignIn { get; set; }      //перелогинивание
        private bool firstLoad;                 //первый запуск системы

        /* Конструктор */
        public LoginFormView()
        {
            InitializeComponent();
            ReSignIn = false;       //если в главной формы хотим перезайти, а не закрыть программу
            firstLoad = true;

            //тут проверяем в конфиге, есть ли пометка, что "запомнить меня"
            //если есть, то запускаем отдельный метод для входа без окна логина
            //ищем юзера в БД с таким логином (логин берем из файла на компе)
            //сверяемся (по формелу считаем токена и сверяем с значением в файле), если всё хорошо - логин
        }

        /* Обновляем значение в конфиге */
        public void UpdateConfig(string val)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value.Equals("saveMe"))
                        {
                            node.Attributes[1].Value = val;
                        }
                    }
                }
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /* Хреновина для получение МАС, чтобы сохранить в БД для юзера для "запомнить меня" верификации */
        private string GetMac()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        /* Вход в систему */
        private void btn_SignIn_Click(object sender, EventArgs e)
        {

            if (!tb_Login.Text.Equals(""))      //если ввели логин
            {
                if (!tb_Password.Text.Equals(""))
                {
                    bool isLoginAndPassOk = false;

                    //ищем юзера с таким логином в базе, берем все данные. на месте тут сверяем пароли, если ок - логин


                    //если всё хорошо, то смотрим на галочку
                    if (cb_RememberMe.Checked)
                    {
                        UpdateConfig("true");
                        string MacAddress = GetMac();   //используем для идентификации пользователя на этом компьютере, чтобы низзя было скопировать файл на другой комп и залогиниться

                        //тут значения с токенов пишем в файл
                    }
                    else
                    {
                        UpdateConfig("false");

                        //удаляем файл
                    }

                    //if (isLoginAndPassOk)
                    //{
                        UserModel um = new UserModel();
                        //MainFormView mf = new MainFormView(um, this);  - окно логина
                        MainFormView mf = new MainFormView();
                        mf.Show();
                        this.Visible = false;
                        firstLoad = false;
                    //}
                }
                else
                    MessageBox.Show("Введите пароль!", "Ошибка");
            }
            else
                MessageBox.Show("Введите логин!", "Ошибка");
        }

        /* Закрываем приложение или перелогиниваемся в зависимости от действий в MainFormView */
        private void LoginFormView_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true && firstLoad == false && ReSignIn == true)
            {
                tb_Login.Text = "";
                tb_Password.Text = "";
                cb_RememberMe.Checked = false;
            }
            else if (this.Visible == true && firstLoad == false && ReSignIn == false)
            {
                this.Close();
            }
        }
    }
}
