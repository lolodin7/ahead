using System;
using System.Configuration;
using System.Windows.Forms;
using Bona_Fides;

namespace Excel_Parse
{
    public partial class MainFormView : Form
    {
        public string AmazonLink { get; set; }
        private UserModel um;
        private LoginFormView lf;

        //public MainFormView(UserModel _um, LoginFormView _lf)
        public MainFormView()
        {
            //показывает картинку при запуске программы
            //StartImage startImg = new StartImage();
            //startImg.Show();
            //this.Refresh();
            //startImg.Refresh();
            //System.Threading.Thread.Sleep(2000);
            //startImg.Close();
            //перестали показывать картинку при запуске программы

            InitializeComponent();
            //um = _um; - окно логина
            //lf = _lf; - окно логина

            AmazonLink = ConfigurationManager.AppSettings.Get("amzLink");
        }
        

        private void btn_DoSemCore_Click(object sender, EventArgs e)
        {
            SemCoreView semcore = new SemCoreView(this);
            if (!semcore.NoProdType && !semcore.NoKeyCat)
            {
                semcore.Show();
                this.Visible = false;
            }
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
            KeywordCategoryView keycat = new KeywordCategoryView(this);
            if (!keycat.HardClose)
            {
                keycat.Show();
                this.Visible = false;
            }
        }

        private void btn_DoRewriteSemCore_Click(object sender, EventArgs e)
        {
            SemCoreRebuildView scr = new SemCoreRebuildView(this);
            if (!scr.NoKeyCat && !scr.NoProdType)
            {
                scr.Show();
                this.Visible = false;
            }
        }

        private void btn_ShowAllKeywords_Click(object sender, EventArgs e)
        {
            FullSemCoreView fsc = new FullSemCoreView(this);
            if (!fsc.NoProdType && !fsc.NoKeyCat)
            {
                fsc.Show();
                this.Visible = false;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //lf.ReSignIn = false;  - окно логина
            this.Close();
        }

        private void btn_ShowIndexing_Click(object sender, EventArgs e)
        {
            IndexingView iv = new IndexingView(this);
            iv.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseProduct cp = new ChooseProduct(this, true);
            cp.Show();
            this.Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About(this);
            ab.Show();
            this.Visible = false;
        }

        private void btn_DoMarketplaces_Click(object sender, EventArgs e)
        {
            MarketplaceView mp = new MarketplaceView(this);
            mp.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SemCoreArchiveView sca = new SemCoreArchiveView(this);
            sca.Show();
            this.Visible = false;
        }

        private void MainFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            //lf.Visible = true;  - окно логина
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lf.ReSignIn = true;
            lf.UpdateConfig("false");
            this.Close();
        }
    }
}
