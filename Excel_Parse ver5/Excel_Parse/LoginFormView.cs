using System;
using System.Windows.Forms;
using Excel_Parse;
using System.Configuration;
using System.Xml;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.IO;

namespace Bona_Fides
{
    public partial class LoginFormView : Form
    {
        public bool ReSignIn { get; set; }      //перелогинивание
        private bool firstLoad;                 //первый запуск системы
        private bool LoadWithSaveMe;
        private UserModel um;

        private SecuredPassword sp;
        private LoginFormController lfController;


        string path = @"C:\Bona Fides\test.txt";


        /* Конструктор */
        public LoginFormView()
        {
            InitializeComponent();
            ReSignIn = false;       //если хотим не закрыть программу, а перезайти с главной формы  
            firstLoad = true;
            lfController = new LoginFormController(this);
        }














        /* Генерируем хранимый токен */
        private int GenerateToken(int _token1, int _token2)
        {
            return _token1 + _token2 + um.Login.Length;
        }

        /* Проверяем хранимый токен на соответсвие */
        private bool VerifyToken(int _storedToken)
        {
            return _storedToken == um.Token1 + um.Token2 + um.Login.Length;
        }

        /* Записываем данные в файл */
        private void WriteToFile(int _storageToken, string _login, string _mac)
        {
            if (!File.Exists(path))
            {
                using (var myFile = File.Create(path))
                {
                    // interact with myFile here, it will be disposed automatically
                }
            }
            
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    sw.WriteLine(_storageToken);
                    sw.WriteLine(_login);
                    sw.WriteLine(_mac);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /* Читаем данные из файла */
        private void ReadFromFile()
        {
            try
            {
                Console.WriteLine("******считываем весь файл********");
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }

                Console.WriteLine();
                Console.WriteLine("******считываем построчно********");
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("******считываем блоками********");
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    char[] array = new char[4];
                    // считываем 4 символа
                    sr.Read(array, 0, 4);

                    Console.WriteLine(array);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /* Вход в систему */
        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            lb_WrongPassword.Visible = false;
            if (!tb_Login.Text.Equals(""))      //если ввели логин
            {
                if (!tb_Password.Text.Equals(""))   //если ввели пароль
                {
                    bool isLoginAndPassOk = false;

                    //ищем юзера с таким логином в базе, берем все данные. на месте тут сверяем пароли, если ок - логин
                    if (!lfController.GetUserDataFromDB(tb_Login.Text))
                    {
                        MessageBox.Show("Пользователь с таким логином не найден.", "Ошибка");
                        return;
                    }

                    sp = new SecuredPassword();
                    isLoginAndPassOk = sp.VerifyHashedPassword(um.PassHash, tb_Password.Text);  //проверяем пароль на корректность


                    if (isLoginAndPassOk)
                    {
                        //если всё хорошо, то смотрим на галочку
                        if (cb_RememberMe.Checked)
                        {
                            UpdateConfig("true");
                            string MacAddress = GetMac();   //используем для идентификации пользователя на этом компьютере, чтобы низзя было скопировать файл на другой комп и залогиниться
                            int generatedToken = GenerateToken(um.Token1, um.Token2);

                            //тут значения с токенов пишем в файл
                            WriteToFile(generatedToken, um.Login, um.Mac);
                        }
                        else
                        {
                            UpdateConfig("false");

                            File.Delete(path);      //удаляем файл
                        }

                        MainFormView mf = new MainFormView(um, this);
                        mf.Show();
                        this.Visible = false;
                        firstLoad = false;
                    }
                    else
                        lb_WrongPassword.Visible = true;
                }
                else
                    MessageBox.Show("Введите пароль!", "Ошибка");
            }
            else
                MessageBox.Show("Введите логин!", "Ошибка");
        }

        /* Получаем данные пользователя из БД */
        public void GetUserDataFromDB(UserModel _um)
        {
            um = _um;
        }

        /* Проверка на галочку "SaveMe" */
        private void LoginFormView_Load(object sender, EventArgs e)
        {            
            //тут проверяем в конфиге, есть ли пометка, что "запомнить меня"
            string saveMe = ConfigurationManager.AppSettings.Get("saveMe");

            if (saveMe.Equals("true"))
                LoadWithSaveMe = true;
            else
                LoadWithSaveMe = false;

            if (LoadWithSaveMe)
            {
                //здесь запуск проги без окна
                
                //ищем юзера в БД с таким логином (логин берем из файла на компе)
                //сверяемся (по формелу считаем токена и сверяем с значением в файле), если всё хорошо - логин

            }
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

    }
}
