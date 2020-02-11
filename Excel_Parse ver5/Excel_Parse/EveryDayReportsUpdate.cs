using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class EveryDayReportsUpdate : Form
    {
        private MainFormView mf;
        private string path;
        private string adv_path, bus_path, inventory_path;

        public EveryDayReportsUpdate(MainFormView _mf)
        {
            InitializeComponent();
            mf = _mf;

            path = @ConfigurationManager.AppSettings.Get("reportsPath");
            adv_path = path + "\\Advertising";
            bus_path = path + "\\Business-Reports";
            inventory_path = path + "\\Amazon-check-stock";
        }

        private void EveryDayReportsUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
            this.Enabled = false;
        }
    }
}
