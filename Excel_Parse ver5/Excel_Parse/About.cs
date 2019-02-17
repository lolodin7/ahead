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
    public partial class About : Form
    {
        private MainFormView controlMainForm;

        public About(MainFormView _mf)
        {
            InitializeComponent();

            controlMainForm = _mf;
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlMainForm.Visible = true;
        }
    }
}
