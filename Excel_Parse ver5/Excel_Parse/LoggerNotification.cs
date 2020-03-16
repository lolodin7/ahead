using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using Excel_Parse.Properties;

namespace Excel_Parse
{
    public partial class LoggerNotification : Form
    {
        private LoggerView loggerViewForm;
        private MainFormView mainFormViewForm;


        private LoggerModel logModel;
        private string userName;
        private string productName;
        private string ASIN;
        private string SKU;
        private string marketPlaceName;
        private string editUserName;
        private string text;
        private int appUserId;

        private bool FromMainForm;


        /* Фоновый процесс при свернутом окне логгера */
        public LoggerNotification(LoggerView _lv, object _lm, string _userName, string _pName, string _asin, string _sku, string _mpName, string _eUserName, string _text, int _AppUserId)
        {
            InitializeComponent();

            loggerViewForm = _lv;
            logModel = (LoggerModel)_lm;
            userName = _userName;
            productName = _pName;
            ASIN = _asin;
            SKU = _sku;
            marketPlaceName = _mpName;
            editUserName = _eUserName;
            text = _text;
            appUserId = _AppUserId;

            FromMainForm = false;

            label1.Text = userName + " к товару \"" + productName + "\":";
            label3.Text = text;

            this.TopMost = true;

            this.Height = label3.Location.Y + label3.Height + 10;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);

            try
            {
                SoundPlayer audio = new SoundPlayer(Resources.notification2);
                audio.Stream.Position = 0;
                audio.Play();
            } catch (Exception ex) { }

            timer1.Start();
        }

        /* Фоновый процесс, работающий через главную форму */
        public LoggerNotification(MainFormView _lv, object _lm, string _userName, string _pName, string _text)
        {
            InitializeComponent();
            
            mainFormViewForm = _lv;
            logModel = (LoggerModel)_lm;
            userName = _userName;
            productName = _pName;
            text = _text;

            FromMainForm = true;

            label1.Text = userName + " к товару \"" + productName + "\":";
            label3.Text = text;

            this.TopMost = true;

            this.Height = label3.Location.Y + label3.Height + 10;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            
            try
            {
                SoundPlayer audio = new SoundPlayer(Resources.notification2);
                audio.Stream.Position = 0;
                audio.Play();
            }
            catch (Exception ex) { }

            

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Stop();
            //this.Close();
        }
        
        private void LoggerNotification_Click(object sender, EventArgs e)
        {
            //if (!FromMainForm)
            //{
            //    LoggerShow ls = new LoggerShow(logModel, userName, productName, ASIN, SKU, marketPlaceName, editUserName, appUserId);
            //    ls.Show();
            //    this.Close();
            //}
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            //if (!FromMainForm)
            //{
            //    LoggerShow ls = new LoggerShow(logModel, userName, productName, ASIN, SKU, marketPlaceName, editUserName, appUserId);
            //    ls.Show();
            //    this.Close();
            //}
        }


        /* Фоновый процесс, работающий через главную форму */
        public LoggerNotification(string _fileName)
        {
            InitializeComponent();
            
            label3.Text = _fileName;

            this.TopMost = true;

            this.Height = label3.Location.Y + label3.Height + 10;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);

            try
            {
                SoundPlayer audio = new SoundPlayer(Resources.notification2);
                audio.Stream.Position = 0;
                audio.Play();
            }
            catch (Exception ex) { }
        }
    }
}
