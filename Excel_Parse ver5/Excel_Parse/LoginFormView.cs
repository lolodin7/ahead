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
using System.Collections.Generic;
using System.Diagnostics;

namespace Excel_Parse
{
    public partial class LoginFormView : Form
    {
        public bool ReSignIn { get; set; }      //перелогинивание
        private bool firstLoad;                 //первый запуск системы
        private bool LoadWithSaveMe;
        private UserModel um;
        private List<string> fileTxt;

        private SecuredPasswordController sp;
        private LoginFormController lfController;

        public bool SignInWithSaveMe { get; set; }


        string path = @"C:\Bona Fides\test.txt";


        /* Конструктор */
        public LoginFormView()
        {
            //показывает картинку при запуске программы
            //StartImage startImg = new StartImage();
            //startImg.Show();
            //this.Refresh();
            //startImg.Refresh();
            //System.Threading.Thread.Sleep(2000);
            //startImg.Close();
            //перестали показывать картинку при запуске программы

            int prC = 0;
            foreach (Process pr in Process.GetProcesses())
                if (pr.ProcessName == "Bona Fides") prC++;
            if (prC > 1)
            {
                MessageBox.Show("Приложение уже запущено!", "Ошибка");
                Process.GetCurrentProcess().Kill();
            }

            InitializeComponent();
            
            string UserName = Environment.UserName;
            path = @"C:\Users\" + Environment.UserName + @"\AppData\Local\secure.txt";

            ReSignIn = false;       //если хотим не закрыть программу, а перезайти с главной формы  
            firstLoad = true;
            SignInWithSaveMe = false;
            lfController = new LoginFormController(this);
            sp = new SecuredPasswordController();
            LoadLogin();
        }
        
        /* Проверка на галочку "SaveMe" */
        private void LoadLogin()
        {
            //тут проверяем в конфиге, есть ли пометка, что "запомнить меня"
            string saveMe = ConfigurationManager.AppSettings.Get("saveMe");
            Console.WriteLine(saveMe);
            if (saveMe.Equals("true"))
                LoadWithSaveMe = true;
            else
                LoadWithSaveMe = false;

            if (LoadWithSaveMe)
            {
                //здесь запуск проги без окна входа
                if (ReadFromFile())
                {

                    lfController.GetUserDataFromDB(fileTxt[0]);

                    if (sp.VerifyToken(int.Parse(fileTxt[1]), um.Token1, um.Token2, um.Login.Length) && sp.VerifyMac(fileTxt[2]))
                    {
                        SignInWithSaveMe = true;
                        MainFormView mf = new MainFormView(um, this);
                        mf.Show();
                        firstLoad = false;
                    }
                    else
                    {
                        UpdateConfig("false");

                        File.Delete(path);      //удаляем файл
                        LoadWithSaveMe = false;
                        this.Visible = true;
                    }
                }
                else
                {
                    UpdateConfig("false");

                    File.Delete(path);      //удаляем файл
                    LoadWithSaveMe = false;
                    this.Visible = true;
                }
            }
        }
        
        /* Записываем данные в файл */
        private void WriteToFile(int _storageToken, string _login, string _mac)
        {
            if (!File.Exists(path)) { using (var myFile = File.Create(path)) { } }      //делаем такое, чтобы после создания файл закрывался и потом можно было с ним работать
            
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    sw.WriteLine(_login);
                    sw.WriteLine(_storageToken);
                    sw.WriteLine(_mac);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /* Читаем данные из файла */
        private bool ReadFromFile()
        {
            fileTxt = new List<string>() { };
            try
            {                
                //считываем построчно
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        fileTxt.Add(line);
                        Console.WriteLine(line);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
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

                    isLoginAndPassOk = sp.VerifyHashedPassword(um.PassHash, tb_Password.Text);  //проверяем пароль на корректность
                    
                    if (isLoginAndPassOk)
                    {
                        //если всё хорошо, то смотрим на галочку
                        if (cb_RememberMe.Checked)
                        {
                            UpdateConfig("true");
                            string MacAddress = sp.GetMac();   //используем для идентификации пользователя на этом компьютере, чтобы низзя было скопировать файл на другой комп и залогиниться
                            int generatedToken = sp.GenerateToken(um.Token1, um.Token2, um.Login.Length);

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
        
        /* Закрываем приложение или перелогиниваемся в зависимости от действий в MainFormView */
        private void LoginFormView_VisibleChanged(object sender, EventArgs e)
        {
            if (!SignInWithSaveMe)
            {
                if (this.Visible == true && firstLoad == false && ReSignIn == true)
                {
                    tb_Login.Text = "";
                    tb_Password.Text = "";
                    cb_RememberMe.Checked = false;
                    SignInWithSaveMe = false;
                }
                else if (this.Visible == true && firstLoad == false && ReSignIn == false)
                {
                    this.Close();
                }
                else if (this.Visible == true && firstLoad == true && ReSignIn == false)
                {
                    tb_Login.Text = "";
                    tb_Password.Text = "";
                    cb_RememberMe.Checked = false;
                    SignInWithSaveMe = false;
                    this.Visible = true;
                }
            }
        }

        /* Если вход был по "запомнить меня", автоматически прячем форму входа */
        private void LoginFormView_Shown(object sender, EventArgs e)
        {
            if (LoadWithSaveMe)
                this.Visible = false;
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

        /* Вызываем форму восстановления пароля */
        private void lb_ResetPassword_Click(object sender, EventArgs e)
        {
            RestorePasswordView rp = new RestorePasswordView(this);
            rp.Show();
            this.Visible = false;
        }
    }
}
