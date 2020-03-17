using Excel_Parse.Properties;
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

namespace Excel_Parse
{
    public partial class LoggerNotification : Form
    {
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
