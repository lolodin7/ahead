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
    public partial class IndexingView : Form
    {
        private MainFormView controlMainFormView;

        public IndexingView()
        {
            InitializeComponent();
        }

        public IndexingView(MainFormView _mf)
        {
            InitializeComponent();

            controlMainFormView = _mf;
        }

        private void IndexingView_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlMainFormView.Visible = true;
        }
    }
}
