using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class MainForm : Form
    {
        private SqlConnection connection;
        public string AmazonLink { get; set; }
        public MainForm()
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            AmazonLink = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=";
        }

        private void btn_DoSemCore_Click(object sender, EventArgs e)
        {
            SemCore semcore = new SemCore(this);
            semcore.Show();
        }

        private void btn_DoSemantics_Click(object sender, EventArgs e)
        {
            using (ChooseProduct cp = new ChooseProduct())
            {
                if (cp.ShowDialog() == DialogResult.OK)
                {
                    Semantics semantics = new Semantics(cp.ProductId);
                    semantics.Show();
                }

            }            
        }
    }
}
