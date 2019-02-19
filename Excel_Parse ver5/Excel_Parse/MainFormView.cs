using System;
using System.Configuration;
using System.Windows.Forms;
using Bona_Fides;

namespace Excel_Parse
{
    public partial class MainFormView : Form
    {
        public string AmazonLink { get; set; }
        public UserModel um;
        private LoginFormView lf;

        private bool JustExit;


        public MainFormView(UserModel _um, LoginFormView _lf)
        {
            InitializeComponent();
            um = _um;
            lf = _lf;
            AmazonLink = ConfigurationManager.AppSettings.Get("amzLink");
            JustExit = true;
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

        /* Закрытие формы */
        private void MainFormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (JustExit)
            {
                lf.SignInWithSaveMe = false;
                lf.ReSignIn = false;
                lf.Visible = true;
            }
            else
            {
                JustExit = true;
                lf.SignInWithSaveMe = false;
                lf.Visible = true;
            }
        }

        /* Завершение сеанса */
        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lf.ReSignIn = true;
            JustExit = false;
            lf.UpdateConfig("false");
            this.Close();
        }

        /* Выход из приложения по кнопке "Выход" */
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            JustExit = false;
            lf.ReSignIn = false;
            this.Close();
        }

        private void ShowPersonalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPanelView cp = new ControlPanelView(um, this);
            cp.Show();
            this.Visible = false;
        }

        /* Если вдруг имя было изменено, переписываем его на фомре при каждом появлении формы */
        private void MainFormView_VisibleChanged(object sender, EventArgs e)
        {
            label1.Text = "Привет, " + um.Name;
        }
    }
}
