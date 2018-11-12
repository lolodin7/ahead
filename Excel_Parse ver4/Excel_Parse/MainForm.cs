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
            this.Visible = false;
        }

        private void btn_DoSemantics_Click(object sender, EventArgs e)
        {
            ChooseProduct cp = new ChooseProduct(this);
            cp.Show();
            this.Visible = false;
        }

        private void btn_DoProducts_Click(object sender, EventArgs e)
        {
            Products products = new Products(this);
            products.Show();
            this.Visible = false;
        }

        private void btn_DoProductType_Click(object sender, EventArgs e)
        {
            ProductTypes productTypes = new ProductTypes(this);
            productTypes.Show();
            this.Visible = false;
        }

        private void btn_DoKeywordCategory_Click(object sender, EventArgs e)
        {
            KeywordCategory keycat = new KeywordCategory(this);
            keycat.Show();
            this.Visible = false;
        }

        private void btn_DoRewriteSemCore_Click(object sender, EventArgs e)
        {
            SemCoreRebuild scr = new SemCoreRebuild(this);
            scr.Show();
            this.Visible = false;
        }

        private void btn_ShowAllKeywords_Click(object sender, EventArgs e)
        {
            FullSemCore fsc = new FullSemCore(this);
            fsc.Show();
            this.Visible = false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
