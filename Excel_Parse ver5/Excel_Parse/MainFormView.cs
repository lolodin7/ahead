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
    public partial class MainFormView : Form
    {
        private SqlConnection connection;
        public string AmazonLink { get; set; }
        public MainFormView()
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            AmazonLink = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=";
        }

        private void btn_DoSemCore_Click(object sender, EventArgs e)
        {
            SemCoreView semcore = new SemCoreView(this);
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
            ProductsView products = new ProductsView(this);
            products.Show();
            this.Visible = false;
        }

        private void btn_DoProductType_Click(object sender, EventArgs e)
        {
            ProductTypesView productTypes = new ProductTypesView(this);
            productTypes.Show();
            this.Visible = false;
        }

        private void btn_DoKeywordCategory_Click(object sender, EventArgs e)
        {
            //KeywordCategoryView keycat = new KeywordCategoryView(this);
            //keycat.Show();
            //this.Visible = false;
        }

        private void btn_DoRewriteSemCore_Click(object sender, EventArgs e)
        {
            SemCoreRebuildView scr = new SemCoreRebuildView(this);
            scr.Show();
            this.Visible = false;
        }

        private void btn_ShowAllKeywords_Click(object sender, EventArgs e)
        {
            FullSemCoreView fsc = new FullSemCoreView(this);
            fsc.Show();
            this.Visible = false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ShowSemStatistics_Click(object sender, EventArgs e)
        {
            SemStatistics ss = new SemStatistics();
            ss.Show();
            this.Visible = false;
        }
    }
}
