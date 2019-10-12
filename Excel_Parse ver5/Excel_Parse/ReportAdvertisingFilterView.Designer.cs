namespace Excel_Parse
{
    partial class ReportAdvertisingFilterView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAdvertisingFilterView));
            this.clb_Marketplace = new System.Windows.Forms.CheckedListBox();
            this.btn_Montly = new System.Windows.Forms.Button();
            this.clb_Campaign = new System.Windows.Forms.CheckedListBox();
            this.btn_Weekly = new System.Windows.Forms.Button();
            this.clb_Product = new System.Windows.Forms.CheckedListBox();
            this.mc_StartDate = new System.Windows.Forms.MonthCalendar();
            this.mc_EndDate = new System.Windows.Forms.MonthCalendar();
            this.cb_CampaignType = new System.Windows.Forms.ComboBox();
            this.btn_Show = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_EndDate = new System.Windows.Forms.Label();
            this.lb_StartDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Clear_clb_Campaigns = new System.Windows.Forms.Button();
            this.btn_Clear_clb_Products = new System.Windows.Forms.Button();
            this.btn_Clear_clb_Marketplace = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Impressions = new System.Windows.Forms.TextBox();
            this.tb_Clicks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_CTR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_ACoS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_Spend = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_CPC = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_Units = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_Orders = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_Sales = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_Go = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_SearchBy = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_SearchByCampaign = new System.Windows.Forms.TextBox();
            this.tb_SearchByTargeting = new System.Windows.Forms.TextBox();
            this.tb_SearchByAdGroup = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_LastMonth = new System.Windows.Forms.Button();
            this.btn_LastHalfYear = new System.Windows.Forms.Button();
            this.btn_lastYear = new System.Windows.Forms.Button();
            this.btn_LastDay = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.cb_MatchType = new System.Windows.Forms.ComboBox();
            this.btn_FilterByMatchType = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // clb_Marketplace
            // 
            this.clb_Marketplace.BackColor = System.Drawing.SystemColors.Control;
            this.clb_Marketplace.CheckOnClick = true;
            this.clb_Marketplace.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.clb_Marketplace.FormattingEnabled = true;
            this.clb_Marketplace.Location = new System.Drawing.Point(12, 105);
            this.clb_Marketplace.Name = "clb_Marketplace";
            this.clb_Marketplace.Size = new System.Drawing.Size(194, 112);
            this.clb_Marketplace.TabIndex = 0;
            this.clb_Marketplace.SelectedIndexChanged += new System.EventHandler(this.clb_Marketplace_SelectedIndexChanged);
            // 
            // btn_Montly
            // 
            this.btn_Montly.Enabled = false;
            this.btn_Montly.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Montly.Location = new System.Drawing.Point(583, 4);
            this.btn_Montly.Name = "btn_Montly";
            this.btn_Montly.Size = new System.Drawing.Size(27, 27);
            this.btn_Montly.TabIndex = 19;
            this.btn_Montly.Text = "M";
            this.btn_Montly.UseVisualStyleBackColor = true;
            this.btn_Montly.Click += new System.EventHandler(this.btn_Montly_Click);
            // 
            // clb_Campaign
            // 
            this.clb_Campaign.BackColor = System.Drawing.SystemColors.Control;
            this.clb_Campaign.CheckOnClick = true;
            this.clb_Campaign.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.clb_Campaign.FormattingEnabled = true;
            this.clb_Campaign.Location = new System.Drawing.Point(216, 284);
            this.clb_Campaign.Name = "clb_Campaign";
            this.clb_Campaign.Size = new System.Drawing.Size(394, 310);
            this.clb_Campaign.TabIndex = 0;
            this.clb_Campaign.SelectedIndexChanged += new System.EventHandler(this.clb_Campaign_SelectedIndexChanged);
            // 
            // btn_Weekly
            // 
            this.btn_Weekly.Enabled = false;
            this.btn_Weekly.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Weekly.Location = new System.Drawing.Point(550, 4);
            this.btn_Weekly.Name = "btn_Weekly";
            this.btn_Weekly.Size = new System.Drawing.Size(27, 27);
            this.btn_Weekly.TabIndex = 11;
            this.btn_Weekly.Text = "W";
            this.btn_Weekly.UseVisualStyleBackColor = true;
            this.btn_Weekly.Click += new System.EventHandler(this.btn_Weekly_Click);
            // 
            // clb_Product
            // 
            this.clb_Product.BackColor = System.Drawing.SystemColors.Control;
            this.clb_Product.CheckOnClick = true;
            this.clb_Product.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.clb_Product.FormattingEnabled = true;
            this.clb_Product.Location = new System.Drawing.Point(12, 251);
            this.clb_Product.Name = "clb_Product";
            this.clb_Product.Size = new System.Drawing.Size(194, 238);
            this.clb_Product.TabIndex = 0;
            this.clb_Product.SelectedIndexChanged += new System.EventHandler(this.clb_Product_SelectedIndexChanged);
            // 
            // mc_StartDate
            // 
            this.mc_StartDate.BackColor = System.Drawing.SystemColors.Control;
            this.mc_StartDate.Location = new System.Drawing.Point(217, 86);
            this.mc_StartDate.MaxSelectionCount = 1;
            this.mc_StartDate.Name = "mc_StartDate";
            this.mc_StartDate.ShowToday = false;
            this.mc_StartDate.ShowWeekNumbers = true;
            this.mc_StartDate.TabIndex = 25;
            this.mc_StartDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_StartDate_DateChanged);
            // 
            // mc_EndDate
            // 
            this.mc_EndDate.BackColor = System.Drawing.SystemColors.Control;
            this.mc_EndDate.Location = new System.Drawing.Point(422, 86);
            this.mc_EndDate.MaxSelectionCount = 1;
            this.mc_EndDate.Name = "mc_EndDate";
            this.mc_EndDate.ShowToday = false;
            this.mc_EndDate.ShowWeekNumbers = true;
            this.mc_EndDate.TabIndex = 15;
            this.mc_EndDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_EndDate_DateChanged);
            // 
            // cb_CampaignType
            // 
            this.cb_CampaignType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CampaignType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.cb_CampaignType.FormattingEnabled = true;
            this.cb_CampaignType.Location = new System.Drawing.Point(12, 35);
            this.cb_CampaignType.Name = "cb_CampaignType";
            this.cb_CampaignType.Size = new System.Drawing.Size(194, 25);
            this.cb_CampaignType.TabIndex = 3;
            this.cb_CampaignType.SelectedIndexChanged += new System.EventHandler(this.cb_CampaignType_SelectedIndexChanged);
            // 
            // btn_Show
            // 
            this.btn_Show.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_Show.FlatAppearance.BorderSize = 0;
            this.btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Show.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Show.Location = new System.Drawing.Point(12, 502);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(194, 92);
            this.btn_Show.TabIndex = 30;
            this.btn_Show.Text = "Применить фильтр";
            this.btn_Show.UseVisualStyleBackColor = false;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(217, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 23);
            this.label2.TabIndex = 31;
            this.label2.Text = "Кампании";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "Маркетплейсы";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 23);
            this.label4.TabIndex = 33;
            this.label4.Text = "Товары";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_EndDate
            // 
            this.lb_EndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_EndDate.Location = new System.Drawing.Point(422, 2);
            this.lb_EndDate.Name = "lb_EndDate";
            this.lb_EndDate.Size = new System.Drawing.Size(119, 29);
            this.lb_EndDate.TabIndex = 34;
            this.lb_EndDate.Text = "lb_EndDate";
            this.lb_EndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_StartDate
            // 
            this.lb_StartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lb_StartDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_StartDate.Location = new System.Drawing.Point(217, 2);
            this.lb_StartDate.Name = "lb_StartDate";
            this.lb_StartDate.Size = new System.Drawing.Size(188, 29);
            this.lb_StartDate.TabIndex = 35;
            this.lb_StartDate.Text = "lb_StartDate";
            this.lb_StartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 23);
            this.label1.TabIndex = 36;
            this.label1.Text = "Вид рекламы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(407, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 29);
            this.label5.TabIndex = 37;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Clear_clb_Campaigns
            // 
            this.btn_Clear_clb_Campaigns.Font = new System.Drawing.Font("Segoe UI Semibold", 7.5F, System.Drawing.FontStyle.Bold);
            this.btn_Clear_clb_Campaigns.Location = new System.Drawing.Point(583, 261);
            this.btn_Clear_clb_Campaigns.Name = "btn_Clear_clb_Campaigns";
            this.btn_Clear_clb_Campaigns.Size = new System.Drawing.Size(27, 21);
            this.btn_Clear_clb_Campaigns.TabIndex = 38;
            this.btn_Clear_clb_Campaigns.Text = "-";
            this.btn_Clear_clb_Campaigns.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Clear_clb_Campaigns.UseVisualStyleBackColor = true;
            this.btn_Clear_clb_Campaigns.Click += new System.EventHandler(this.btn_Clear_clb_Campaigns_Click);
            // 
            // btn_Clear_clb_Products
            // 
            this.btn_Clear_clb_Products.Font = new System.Drawing.Font("Segoe UI Semibold", 7.5F, System.Drawing.FontStyle.Bold);
            this.btn_Clear_clb_Products.Location = new System.Drawing.Point(179, 228);
            this.btn_Clear_clb_Products.Name = "btn_Clear_clb_Products";
            this.btn_Clear_clb_Products.Size = new System.Drawing.Size(27, 21);
            this.btn_Clear_clb_Products.TabIndex = 39;
            this.btn_Clear_clb_Products.Text = "-";
            this.btn_Clear_clb_Products.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Clear_clb_Products.UseVisualStyleBackColor = true;
            this.btn_Clear_clb_Products.Click += new System.EventHandler(this.btn_Clear_clb_Products_Click);
            // 
            // btn_Clear_clb_Marketplace
            // 
            this.btn_Clear_clb_Marketplace.Font = new System.Drawing.Font("Segoe UI Semibold", 7.5F, System.Drawing.FontStyle.Bold);
            this.btn_Clear_clb_Marketplace.Location = new System.Drawing.Point(179, 82);
            this.btn_Clear_clb_Marketplace.Name = "btn_Clear_clb_Marketplace";
            this.btn_Clear_clb_Marketplace.Size = new System.Drawing.Size(27, 21);
            this.btn_Clear_clb_Marketplace.TabIndex = 40;
            this.btn_Clear_clb_Marketplace.Text = "-";
            this.btn_Clear_clb_Marketplace.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Clear_clb_Marketplace.UseVisualStyleBackColor = true;
            this.btn_Clear_clb_Marketplace.Click += new System.EventHandler(this.btn_Clear_clb_Marketplace_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(22, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 23);
            this.label6.TabIndex = 41;
            this.label6.Text = "Impressions";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Impressions
            // 
            this.tb_Impressions.Location = new System.Drawing.Point(22, 59);
            this.tb_Impressions.Name = "tb_Impressions";
            this.tb_Impressions.Size = new System.Drawing.Size(92, 25);
            this.tb_Impressions.TabIndex = 42;
            // 
            // tb_Clicks
            // 
            this.tb_Clicks.Location = new System.Drawing.Point(22, 115);
            this.tb_Clicks.Name = "tb_Clicks";
            this.tb_Clicks.Size = new System.Drawing.Size(92, 25);
            this.tb_Clicks.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(22, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 23);
            this.label7.TabIndex = 43;
            this.label7.Text = "Clicks";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_CTR
            // 
            this.tb_CTR.Location = new System.Drawing.Point(22, 171);
            this.tb_CTR.Name = "tb_CTR";
            this.tb_CTR.Size = new System.Drawing.Size(92, 25);
            this.tb_CTR.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(22, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 23);
            this.label8.TabIndex = 45;
            this.label8.Text = "CTR";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_ACoS
            // 
            this.tb_ACoS.Location = new System.Drawing.Point(22, 339);
            this.tb_ACoS.Name = "tb_ACoS";
            this.tb_ACoS.Size = new System.Drawing.Size(92, 25);
            this.tb_ACoS.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(22, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 23);
            this.label9.TabIndex = 51;
            this.label9.Text = "ACoS";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Spend
            // 
            this.tb_Spend.Location = new System.Drawing.Point(22, 283);
            this.tb_Spend.Name = "tb_Spend";
            this.tb_Spend.Size = new System.Drawing.Size(92, 25);
            this.tb_Spend.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(22, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 23);
            this.label10.TabIndex = 49;
            this.label10.Text = "Spend";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_CPC
            // 
            this.tb_CPC.Location = new System.Drawing.Point(22, 227);
            this.tb_CPC.Name = "tb_CPC";
            this.tb_CPC.Size = new System.Drawing.Size(92, 25);
            this.tb_CPC.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(22, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 23);
            this.label11.TabIndex = 47;
            this.label11.Text = "CPC";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Units
            // 
            this.tb_Units.Location = new System.Drawing.Point(22, 507);
            this.tb_Units.Name = "tb_Units";
            this.tb_Units.Size = new System.Drawing.Size(92, 25);
            this.tb_Units.TabIndex = 58;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(22, 481);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 23);
            this.label12.TabIndex = 57;
            this.label12.Text = "Units";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Orders
            // 
            this.tb_Orders.Location = new System.Drawing.Point(22, 451);
            this.tb_Orders.Name = "tb_Orders";
            this.tb_Orders.Size = new System.Drawing.Size(92, 25);
            this.tb_Orders.TabIndex = 56;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(22, 425);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 23);
            this.label13.TabIndex = 55;
            this.label13.Text = "Orders";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Sales
            // 
            this.tb_Sales.Location = new System.Drawing.Point(22, 395);
            this.tb_Sales.Name = "tb_Sales";
            this.tb_Sales.Size = new System.Drawing.Size(92, 25);
            this.tb_Sales.TabIndex = 54;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(22, 369);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 23);
            this.label14.TabIndex = 53;
            this.label14.Text = "Sales";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Go
            // 
            this.btn_Go.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_Go.FlatAppearance.BorderSize = 0;
            this.btn_Go.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Go.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Go.Location = new System.Drawing.Point(131, 33);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(40, 499);
            this.btn_Go.TabIndex = 59;
            this.btn_Go.Text = "GO";
            this.btn_Go.UseVisualStyleBackColor = false;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 601);
            this.splitter1.TabIndex = 60;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_FilterByMatchType);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cb_MatchType);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_Reset);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_Impressions);
            this.groupBox1.Controls.Add(this.btn_Go);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tb_Units);
            this.groupBox1.Controls.Add(this.tb_Clicks);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tb_Orders);
            this.groupBox1.Controls.Add(this.tb_CTR);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tb_Sales);
            this.groupBox1.Controls.Add(this.tb_CPC);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tb_ACoS);
            this.groupBox1.Controls.Add(this.tb_Spend);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(616, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 590);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с таблицей";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_SearchBy);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.tb_SearchByCampaign);
            this.groupBox2.Controls.Add(this.tb_SearchByTargeting);
            this.groupBox2.Controls.Add(this.tb_SearchByAdGroup);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(193, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 205);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поиск по";
            // 
            // btn_SearchBy
            // 
            this.btn_SearchBy.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_SearchBy.FlatAppearance.BorderSize = 0;
            this.btn_SearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SearchBy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_SearchBy.Location = new System.Drawing.Point(277, 19);
            this.btn_SearchBy.Name = "btn_SearchBy";
            this.btn_SearchBy.Size = new System.Drawing.Size(40, 165);
            this.btn_SearchBy.TabIndex = 68;
            this.btn_SearchBy.Text = "GO";
            this.btn_SearchBy.UseVisualStyleBackColor = false;
            this.btn_SearchBy.Click += new System.EventHandler(this.btn_SearchBy_Click);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(6, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(254, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Campaign";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(6, 133);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(254, 23);
            this.label18.TabIndex = 65;
            this.label18.Text = "Targeting";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_SearchByCampaign
            // 
            this.tb_SearchByCampaign.Location = new System.Drawing.Point(6, 47);
            this.tb_SearchByCampaign.Name = "tb_SearchByCampaign";
            this.tb_SearchByCampaign.Size = new System.Drawing.Size(254, 25);
            this.tb_SearchByCampaign.TabIndex = 62;
            // 
            // tb_SearchByTargeting
            // 
            this.tb_SearchByTargeting.Location = new System.Drawing.Point(6, 159);
            this.tb_SearchByTargeting.Name = "tb_SearchByTargeting";
            this.tb_SearchByTargeting.Size = new System.Drawing.Size(254, 25);
            this.tb_SearchByTargeting.TabIndex = 66;
            // 
            // tb_SearchByAdGroup
            // 
            this.tb_SearchByAdGroup.Enabled = false;
            this.tb_SearchByAdGroup.Location = new System.Drawing.Point(6, 103);
            this.tb_SearchByAdGroup.Name = "tb_SearchByAdGroup";
            this.tb_SearchByAdGroup.Size = new System.Drawing.Size(254, 25);
            this.tb_SearchByAdGroup.TabIndex = 64;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(6, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(254, 23);
            this.label16.TabIndex = 63;
            this.label16.Text = "AdGroup Name";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_Reset.FlatAppearance.BorderSize = 0;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Reset.Location = new System.Drawing.Point(535, 481);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(126, 52);
            this.btn_Reset.TabIndex = 60;
            this.btn_Reset.Text = "Сброс";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_LastMonth
            // 
            this.btn_LastMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_LastMonth.Location = new System.Drawing.Point(325, 51);
            this.btn_LastMonth.Name = "btn_LastMonth";
            this.btn_LastMonth.Size = new System.Drawing.Size(78, 27);
            this.btn_LastMonth.TabIndex = 62;
            this.btn_LastMonth.Text = "Месяц";
            this.btn_LastMonth.UseVisualStyleBackColor = true;
            this.btn_LastMonth.Click += new System.EventHandler(this.btn_LastMonth_Click);
            // 
            // btn_LastHalfYear
            // 
            this.btn_LastHalfYear.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_LastHalfYear.Location = new System.Drawing.Point(428, 51);
            this.btn_LastHalfYear.Name = "btn_LastHalfYear";
            this.btn_LastHalfYear.Size = new System.Drawing.Size(78, 27);
            this.btn_LastHalfYear.TabIndex = 63;
            this.btn_LastHalfYear.Text = "Полгода";
            this.btn_LastHalfYear.UseVisualStyleBackColor = true;
            this.btn_LastHalfYear.Click += new System.EventHandler(this.btn_LastHalfYear_Click);
            // 
            // btn_lastYear
            // 
            this.btn_lastYear.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_lastYear.Location = new System.Drawing.Point(532, 51);
            this.btn_lastYear.Name = "btn_lastYear";
            this.btn_lastYear.Size = new System.Drawing.Size(78, 27);
            this.btn_lastYear.TabIndex = 64;
            this.btn_lastYear.Text = "Год";
            this.btn_lastYear.UseVisualStyleBackColor = true;
            this.btn_lastYear.Click += new System.EventHandler(this.btn_lastYear_Click);
            // 
            // btn_LastDay
            // 
            this.btn_LastDay.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_LastDay.Location = new System.Drawing.Point(217, 51);
            this.btn_LastDay.Name = "btn_LastDay";
            this.btn_LastDay.Size = new System.Drawing.Size(78, 27);
            this.btn_LastDay.TabIndex = 81;
            this.btn_LastDay.Text = "Вчера";
            this.btn_LastDay.UseVisualStyleBackColor = true;
            this.btn_LastDay.Click += new System.EventHandler(this.btn_LastDay_Click);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(199, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(254, 23);
            this.label17.TabIndex = 83;
            this.label17.Text = "Match Type";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_MatchType
            // 
            this.cb_MatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MatchType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.cb_MatchType.FormattingEnabled = true;
            this.cb_MatchType.Items.AddRange(new object[] {
            "AUTO",
            "EXACT",
            "PHRASE",
            "BROAD"});
            this.cb_MatchType.Location = new System.Drawing.Point(203, 59);
            this.cb_MatchType.Name = "cb_MatchType";
            this.cb_MatchType.Size = new System.Drawing.Size(250, 25);
            this.cb_MatchType.TabIndex = 82;
            // 
            // btn_FilterByMatchType
            // 
            this.btn_FilterByMatchType.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_FilterByMatchType.FlatAppearance.BorderSize = 0;
            this.btn_FilterByMatchType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FilterByMatchType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_FilterByMatchType.Location = new System.Drawing.Point(470, 51);
            this.btn_FilterByMatchType.Name = "btn_FilterByMatchType";
            this.btn_FilterByMatchType.Size = new System.Drawing.Size(40, 39);
            this.btn_FilterByMatchType.TabIndex = 69;
            this.btn_FilterByMatchType.Text = "GO";
            this.btn_FilterByMatchType.UseVisualStyleBackColor = false;
            this.btn_FilterByMatchType.Click += new System.EventHandler(this.btn_FilterByMatchType_Click);
            // 
            // ReportAdvertisingFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 601);
            this.Controls.Add(this.btn_LastDay);
            this.Controls.Add(this.btn_lastYear);
            this.Controls.Add(this.btn_LastHalfYear);
            this.Controls.Add(this.btn_LastMonth);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btn_Clear_clb_Marketplace);
            this.Controls.Add(this.btn_Clear_clb_Products);
            this.Controls.Add(this.btn_Clear_clb_Campaigns);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_StartDate);
            this.Controls.Add(this.lb_EndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Show);
            this.Controls.Add(this.clb_Marketplace);
            this.Controls.Add(this.btn_Montly);
            this.Controls.Add(this.cb_CampaignType);
            this.Controls.Add(this.clb_Campaign);
            this.Controls.Add(this.mc_EndDate);
            this.Controls.Add(this.btn_Weekly);
            this.Controls.Add(this.mc_StartDate);
            this.Controls.Add(this.clb_Product);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportAdvertisingFilterView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фильтр - Sponsored Products";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdvertisingReportFilterView_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckedListBox clb_Marketplace;
        private System.Windows.Forms.Button btn_Montly;
        private System.Windows.Forms.CheckedListBox clb_Campaign;
        private System.Windows.Forms.Button btn_Weekly;
        private System.Windows.Forms.CheckedListBox clb_Product;
        private System.Windows.Forms.MonthCalendar mc_StartDate;
        private System.Windows.Forms.MonthCalendar mc_EndDate;
        private System.Windows.Forms.ComboBox cb_CampaignType;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_EndDate;
        private System.Windows.Forms.Label lb_StartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Clear_clb_Campaigns;
        private System.Windows.Forms.Button btn_Clear_clb_Products;
        private System.Windows.Forms.Button btn_Clear_clb_Marketplace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Impressions;
        private System.Windows.Forms.TextBox tb_Clicks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_CTR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_ACoS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_Spend;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_CPC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_Units;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_Orders;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_Sales;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_SearchBy;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_SearchByCampaign;
        private System.Windows.Forms.TextBox tb_SearchByTargeting;
        private System.Windows.Forms.TextBox tb_SearchByAdGroup;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_LastMonth;
        private System.Windows.Forms.Button btn_LastHalfYear;
        private System.Windows.Forms.Button btn_lastYear;
        private System.Windows.Forms.Button btn_LastDay;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cb_MatchType;
        private System.Windows.Forms.Button btn_FilterByMatchType;
    }
}