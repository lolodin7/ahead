﻿using Microsoft.VisualBasic.FileIO;
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
    public partial class SemanticsView : Form
    {
        private int TitleLength, BulletsLength, BackendLength, DescriptionLength, SubjectMatterLength, OtherAttributesLength, IntendedUseLength;

        private string ProductName, ASIN, SKU;
        private int ProductTypeId;                  //это для заполнения таблицы ключей
        private static int ProductId;
        private List<SemanticsModel> smList;        //список всех семантик для выбранного продукта

        private List<string[]> usedK;               //храним все usedKeywords

        private KeywordCategoryController kcController;
        private List<KeywordCategoryModel> kcList;
        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;

        List<int> checkedCategories;
        private bool checkedCategoriesWasChanged = true;

        private SqlConnection connection;
        MainFormView controlMainFormView;
        IndexingView controlIndexingView;

        private DateTime CurrentDay;                //храним сегодняшнюю дату
        private bool DayCreated;                    //если сохраняем несколько раз изменений, чтобы не дублировать объекты и не создавать новые дни, просто указываем, что день уже создан и сохраняем все изменение в него
        

        private bool CheckForUnsavedChanges;        //чтобы не закрыть прогу без сохранения




        private bool reverseDescriptionTransform;

        /* Конструктор, если вызываем из формы индексации */
        public SemanticsView(IndexingView _mf, int _productId, string _productName, string _asin, string _sku, int _prodTypeId)
        {
            InitializeComponent();

            ProductId = _productId;
            ProductName = _productName;
            ASIN = _asin;
            SKU = _sku;
            ProductTypeId = _prodTypeId;

            lb_ProductName.Text = ProductName;
            lb_ASIN.Text = ASIN;
            lb_SKU.Text = SKU;

            this.Text = "Семантика - " + ProductName;

            controlIndexingView = _mf;
            connection = DBData.GetDBConnection();
            smList = new List<SemanticsModel> { };
            usedK = new List<string[]> { };
            checkedCategories = new List<int> { };

            kcController = new KeywordCategoryController(this);
            ptController = new ProductTypesController(this);

            DayCreated = false;
            CurrentDay = DateTime.Now;


            getStarted();
        }

        /* Конструктор, если вызываем из главной формы */
        public SemanticsView(MainFormView _mf, int _productId, string _productName, string _asin, string _sku, int _prodTypeId)
        {
            InitializeComponent();

            ProductId = _productId;
            ProductName = _productName;
            ASIN = _asin;
            SKU = _sku;
            ProductTypeId = _prodTypeId;

            lb_ProductName.Text = ProductName;
            lb_ASIN.Text = ASIN;
            lb_SKU.Text = SKU;

            this.Text = "Семантика - " + ProductName;

            controlMainFormView = _mf;
            connection = DBData.GetDBConnection();
            smList = new List<SemanticsModel> { };
            usedK = new List<string[]> { };
            checkedCategories = new List<int> { };

            kcController = new KeywordCategoryController(this);
            ptController = new ProductTypesController(this);

            DayCreated = false;
            CurrentDay = DateTime.Now;
            

            getStarted();
        }

        /* Первая загрузка формы */
        private void getStarted()
        {
            btn_TransformDescr.Text = "П\nр\nе\nо\nб\nр\nа\nз\nо\nв\nа\nт\nь\n";
            btn_ReplaceTexts.Text = "S\nw\na\np\n";
            reverseDescriptionTransform = true;
             
            getDBFieldsLength();
            getDBKeywords();
            getDBFields();

            CheckForUnsavedChanges = false;
        }

        /* Заполняем значения длин для полей с БД */
        private void getDBFieldsLength()
        {
            string sqlSemanticsIds = "SELECT * FROM FieldsLength WHERE ProductId = " + ProductId;
            SqlCommand command = new SqlCommand(sqlSemanticsIds, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetLengthToValues((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Записываем значения длин для полей в переменные */
        private void SetLengthToValues(IDataRecord record)
        {
            TitleLength = int.Parse(record[0].ToString());
            lb_TitleText.Text = "Title (" + TitleLength + ")";

            BulletsLength = int.Parse(record[1].ToString());
            lb_BulletsText.Text = "Bullets (" + BulletsLength + ")";

            BackendLength = int.Parse(record[2].ToString());
            lb_BackendText.Text = "Backend (" + BackendLength + ")";

            SubjectMatterLength = int.Parse(record[3].ToString());
            lb_SubjectMatterText.Text = "Subject Matter (" + SubjectMatterLength + ")";

            OtherAttributesLength = int.Parse(record[4].ToString());
            lb_OtherAttributesText.Text = "Other Attributes (" + OtherAttributesLength + ")";

            IntendedUseLength = int.Parse(record[5].ToString());
            lb_IntendedUseText.Text = "Intended Use (" + IntendedUseLength + ")";

            DescriptionLength = int.Parse(record[6].ToString());
            lb_DescriptionText.Text = "Description (" + DescriptionLength + ")";
        }

        /* Заполняем все поля на форме */
        private void getDBFields()
        {
            string sqlSemantics = "SELECT * FROM Semantics WHERE ProductId = " + ProductId;
            SqlCommand command = new SqlCommand(sqlSemantics, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetSemanticsToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
                Fill_CB_byDates();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Заполняем список семантиками данными, полученными с БД */
        private void SetSemanticsToList(IDataRecord record)
        {
            SemanticsModel sm = new SemanticsModel();
            smList.Add(sm);

            for (int i = 0; i < record.FieldCount; i++)
            {
                smList[smList.Count - 1].SetSemantics(i, record[i]);
            }
        }

        /* Заполняем ComboBox с датами и вызываем заполнение полей по дате */
        private void Fill_CB_byDates()
        {
            cb_LastUpdated.Items.Clear();

            for (int i = 0; i < smList.Count; i++)
            {
                cb_LastUpdated.Items.Add(smList[i].UpdateDate);
            }

            cb_LastUpdated.SelectedItem = cb_LastUpdated.Items[cb_LastUpdated.Items.Count - 1];
        }

        /* Заполнение основных полей данными конкретной версии семантики */
        private void FillFieldsBySemanticsValues(string value)
        {
            int index = -1;

            for (int i = 0; i < smList.Count; i++)
            {
                if (smList[i].UpdateDate.ToString().Equals(value))
                {
                    index = i;
                }
            }

            rtb_Title.Text = smList[index].Title;
            rtb_Bul1.Text = smList[index].Bullet1;
            rtb_Bul2.Text = smList[index].Bullet2;
            rtb_Bul3.Text = smList[index].Bullet3;
            rtb_Bul4.Text = smList[index].Bullet4;
            rtb_Bul5.Text = smList[index].Bullet5;
            rtb_Backend.Text = smList[index].Backend;
            rtb_Description.Text = smList[index].Description;
            rtb_OtherAttributes1.Text = smList[index].OtherAttributes1;
            rtb_OtherAttributes2.Text = smList[index].OtherAttributes2;
            rtb_OtherAttributes3.Text = smList[index].OtherAttributes3;
            rtb_OtherAttributes4.Text = smList[index].OtherAttributes4;
            rtb_OtherAttributes5.Text = smList[index].OtherAttributes5;
            rtb_IntendedUse1.Text = smList[index].IntendedUse1;
            rtb_IntendedUse2.Text = smList[index].IntendedUse2;
            rtb_IntendedUse3.Text = smList[index].IntendedUse3;
            rtb_IntendedUse4.Text = smList[index].IntendedUse4;
            rtb_IntendedUse5.Text = smList[index].IntendedUse5;
            rtb_SubjectMatter1.Text = smList[index].SubjectMatter1;
            rtb_SubjectMatter2.Text = smList[index].SubjectMatter2;
            rtb_SubjectMatter3.Text = smList[index].SubjectMatter3;
            rtb_SubjectMatter4.Text = smList[index].SubjectMatter4;
            rtb_SubjectMatter5.Text = smList[index].SubjectMatter5;
            rtb_Notes.Text = smList[index].Notes;
            rtb_UsedKeywords.Text = smList[index].UsedKeywords;

            ForcedTextBoxChanging();                    //Принудительно пересчитываем и перезаписываем фактическое значение длины поля
            
            UsedKeywordsAnalyser();
        }

        /* Обработчик изменения версии (даты) листинга */
        private void cb_LastUpdated_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            FillFieldsBySemanticsValues(cb.SelectedItem.ToString());
        }

        /* Принудительно пересчитываем и перезаписываем фактическое значение длины поля (lb_Title, lb_Backend...) */
        private void ForcedTextBoxChanging()
        {
            TextBoxChanged(rtb_Title);
            TextBoxChanged(rtb_Bul1);
            TextBoxChanged(rtb_Bul2);
            TextBoxChanged(rtb_Bul3);
            TextBoxChanged(rtb_Bul4);
            TextBoxChanged(rtb_Bul5);
            TextBoxChanged(rtb_Backend);
            TextBoxChanged(rtb_OtherAttributes1);
            TextBoxChanged(rtb_OtherAttributes2);
            TextBoxChanged(rtb_OtherAttributes3);
            TextBoxChanged(rtb_OtherAttributes4);
            TextBoxChanged(rtb_OtherAttributes5);
            TextBoxChanged(rtb_IntendedUse1);
            TextBoxChanged(rtb_IntendedUse2);
            TextBoxChanged(rtb_IntendedUse3);
            TextBoxChanged(rtb_IntendedUse4);
            TextBoxChanged(rtb_IntendedUse5);
            TextBoxChanged(rtb_SubjectMatter1);
            TextBoxChanged(rtb_SubjectMatter2);
            TextBoxChanged(rtb_SubjectMatter3);
            TextBoxChanged(rtb_SubjectMatter4);
            TextBoxChanged(rtb_SubjectMatter5);
        }

        /* Обработчик ввода текста в textbox'ы */
        private void tb_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(sender);
        }

        /* Окрашиваем текст поля, если он вне границы FieldLength */
        private void TextBoxChanged(object sender)
        {
            RichTextBox textBox = (RichTextBox)sender;

            switch (textBox.Name)
            {
                case "rtb_Title":
                    if (textBox.TextLength > TitleLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Title.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_Bul1":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet1.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_Bul2":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet2.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_Bul3":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet3.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_Bul4":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet4.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_Bul5":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet5.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_Backend":
                    if (textBox.TextLength > BackendLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Backend.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_OtherAttributes1":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes1.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_OtherAttributes2":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes2.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_OtherAttributes3":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes3.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_OtherAttributes4":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes4.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_OtherAttributes5":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes5.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_IntendedUse1":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse1.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_IntendedUse2":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse2.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_IntendedUse3":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse3.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_IntendedUse4":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse4.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_IntendedUse5":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse5.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_SubjectMatter1":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter1.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_SubjectMatter2":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter2.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_SubjectMatter3":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter3.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_SubjectMatter4":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter4.Text = textBox.TextLength.ToString();
                    break;
                case "rtb_SubjectMatter5":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter5.Text = textBox.TextLength.ToString();
                    break;
            }
            CheckForUnsavedChanges = true;
        }

        /* "Синтаксический" анализатор для маркировки used keywords в dgv_Keywords */
        private void UsedKeywordsAnalyser()
        {
            string str = rtb_UsedKeywords.Text;
            string[,] usedK = new string[dgv_Keywords.Rows.Count + 20, 2];         // 0 - title, 1 - bullets, 2 - description
            string tmp = "";
            int j = 0;
            bool key = true;

            for (int i = 0; i < str.Length; i++)
            {
                char g = str[i];
                if (str[i].Equals('|'))
                {
                    usedK[j, 0] = tmp;
                    i++;
                    usedK[j, 1] = str[i].ToString();
                    tmp = "";
                    j++;
                    i++;
                }
                else
                {
                    tmp += str[i];
                }
            }

            string[,] _arrUsedKeywords = new string[j, 2];

            for (int i = 0; i < j; i++)
            {
                _arrUsedKeywords[i, 0] = usedK[i, 0];
                _arrUsedKeywords[i, 1] = usedK[i, 1];
            }

            SetUsedKeywordsTo_List(_arrUsedKeywords);
            MarkUsedKeywords();
        }


        /* Вносим used keywords в UsedKeywordsList */
        private void SetUsedKeywordsTo_List(string[,] _arrUsedKeywords)
        {
            string[] tmp;
            usedK.Clear();
            for (int j = 0; j < _arrUsedKeywords.Length / 2; j++)
            {
                tmp = new string[2];
                usedK.Add(tmp);

                for (int i = 0; i < 2; i++)
                {
                    usedK[usedK.Count - 1].SetValue(_arrUsedKeywords[j, i], i);
                }

            }
        }

        /* Маркируем ключи в dgv_Keywords */
        private void MarkUsedKeywords()
        {
            for (int i = 0; i < dgv_Keywords.RowCount; i++)
            {
                dgv_Keywords.Rows[i].Cells[2].Style.BackColor = Color.White;
            }

            for (int i = 0; i < usedK.Count; i++)
            {
                for (int j = 0; j < dgv_Keywords.RowCount; j++)
                {
                    if (usedK[i].ElementAt(0).Equals(dgv_Keywords.Rows[j].Cells[2].Value.ToString()))
                    {
                        switch (usedK[i].ElementAt(1))
                        {
                            case "0":
                                //title
                                dgv_Keywords.Rows[j].Cells[2].Style.BackColor = Color.Coral;
                                break;
                            case "1":
                                //bullets
                                dgv_Keywords.Rows[j].Cells[2].Style.BackColor = Color.LightBlue;
                                break;
                            case "2":
                                //backend
                                dgv_Keywords.Rows[j].Cells[2].Style.BackColor = Color.LimeGreen;
                                break;
                            case "3":
                                //description
                                dgv_Keywords.Rows[j].Cells[2].Style.BackColor = Color.MistyRose;
                                break;
                        }
                    }
                }
            }
        }

        /* Заполняем таблицу с ключами из БД */
        private void getDBKeywords()
        {
            try
            {
                dgv_Keywords.Rows.Clear();
                string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + ProductTypeId;
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetKeywordsTodgv_Keywords((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Заполняем dgv_Keywords ключами (из getDBKeywords()) */
        private void SetKeywordsTodgv_Keywords(IDataRecord record)
        {
            var index = dgv_Keywords.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv_Keywords.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Заполняем поля последними внесенными значениями с dgv_Semantics */
        private void btn_Return_Click(object sender, EventArgs e)
        {
            FillFieldsBySemanticsValues(cb_LastUpdated.SelectedItem.ToString());
            UsedKeywordsAnalyser();
        }



        /* Заганяем данные с полей в объект */
        private void setSemanticsByFields()
        {
            int index = -1;

            bool newItem = false;

            if (!DayCreated)
            {
                SemanticsModel smModel = new SemanticsModel();
                smList.Add(smModel);

                index = smList.Count - 1;

                DayCreated = true;
                newItem = true;
                CurrentDay = DateTime.Now;
            }
            else
            {
                index = smList.Count - 1;
            }

            smList[index].ProductId = ProductId;
            smList[index].Title = rtb_Title.Text;
            smList[index].Bullet1 = rtb_Bul1.Text;
            smList[index].Bullet2 = rtb_Bul2.Text;
            smList[index].Bullet3 = rtb_Bul3.Text;
            smList[index].Bullet4 = rtb_Bul4.Text;
            smList[index].Bullet5 = rtb_Bul5.Text;
            smList[index].Backend = rtb_Backend.Text;
            smList[index].Description = rtb_Description.Text;
            smList[index].OtherAttributes1 = rtb_OtherAttributes1.Text;
            smList[index].OtherAttributes2 = rtb_OtherAttributes2.Text;
            smList[index].OtherAttributes3 = rtb_OtherAttributes3.Text;
            smList[index].OtherAttributes4 = rtb_OtherAttributes4.Text;
            smList[index].OtherAttributes5 = rtb_OtherAttributes5.Text;
            smList[index].IntendedUse1 = rtb_IntendedUse1.Text;
            smList[index].IntendedUse2 = rtb_IntendedUse2.Text;
            smList[index].IntendedUse3 = rtb_IntendedUse3.Text;
            smList[index].IntendedUse4 = rtb_IntendedUse4.Text;
            smList[index].IntendedUse5 = rtb_IntendedUse5.Text;
            smList[index].SubjectMatter1 = rtb_SubjectMatter1.Text;
            smList[index].SubjectMatter2 = rtb_SubjectMatter2.Text;
            smList[index].SubjectMatter3 = rtb_SubjectMatter3.Text;
            smList[index].SubjectMatter4 = rtb_SubjectMatter4.Text;
            smList[index].SubjectMatter5 = rtb_SubjectMatter5.Text;
            smList[index].UpdateDate = CurrentDay;
            smList[index].Notes = rtb_Notes.Text;
            smList[index].UsedKeywords = rtb_UsedKeywords.Text;

            if (newItem)
            {
                cb_LastUpdated.Items.Add(smList[index].UpdateDate);
                newItem = false;
            }

            cb_LastUpdated.SelectedItem = smList[index].UpdateDate;
        }

        /* Заносим used keywords из dgv_UsedKeywords в rtb_UsedKeywords по шаблону*/
        private void setUsedKeywordsTo_rtbUsedKeywords()
        {
            rtb_UsedKeywords.Text = "";
            for (int i = 0; i < usedK.Count; i++)
            {
                rtb_UsedKeywords.Text += usedK[i].ElementAt(0) + "|" + usedK[i].ElementAt(1) + "|";
            }
        }

        /* Изменяем размеры длинн полей */
        private void fieldsLengthToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (FieldsLength FieldsLength = new FieldsLength(TitleLength, BulletsLength, BackendLength, DescriptionLength, IntendedUseLength, SubjectMatterLength, OtherAttributesLength))
            {
                if (FieldsLength.ShowDialog() == DialogResult.OK)
                {
                    TitleLength = FieldsLength.TitleLength;
                    BulletsLength = FieldsLength.BulletsLength; ;
                    BackendLength = FieldsLength.BackendLength;
                    DescriptionLength = FieldsLength.DescriptionLength;
                    IntendedUseLength = FieldsLength.IntendedUseLength;
                    SubjectMatterLength = FieldsLength.SubjectMatterLength;
                    OtherAttributesLength = FieldsLength.OtherAttributesLength;

                    ForcedTextBoxChanging();

                    lb_TitleText.Text = "Title (" + TitleLength + ")";
                    lb_BulletsText.Text = "Bullets (" + BulletsLength + ")";
                    lb_BackendText.Text = "Backend (" + BackendLength + ")";
                    lb_DescriptionText.Text = "Description (" + DescriptionLength + ")";
                    lb_SubjectMatterText.Text = "Subject Matter (" + SubjectMatterLength + ")";
                    lb_OtherAttributesText.Text = "Other Attributes (" + OtherAttributesLength + ")";
                    lb_IntendedUseText.Text = "Intended Use (" + IntendedUseLength + ")";
                }
            }
        }




        //----------------------------------------------------------------ВЫБОР ВИДА ТОВАРА И КАТЕГОРИЙ КЛЮЧЕЙ----------------------------------------------------------------

        #region выбор вида товара и категорий ключей
        /* Выбираем вид товара, чтобы отобразить ключи для него */
        private void chooseKeysProductTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox1.Text = "Выбор вида товара";
            dgv_Keywords.Visible = false;
            checkedListBox1.Visible = false;
            btn_DecheckAll.Visible = false;
            btn_CheckAll.Visible = false;
            cb_ProductTypes.Visible = true;
            btn_AcceptGroupBox2.Visible = true;
            btn_AcceptGroupBox1.Visible = false;

            if (ptController.GetProductTypesAll())
            {
                cb_ProductTypes.Items.Clear();

                for (int i = 0; i < ptList.Count; i++)
                {
                    cb_ProductTypes.Items.Add(ptList[i].TypeName);
                }

                cb_ProductTypes.SelectedItem = cb_ProductTypes.Items[0];
            }

            cb_ProductTypes.Focus();
        }

        /* Выбираем категории ключей для отображения ключей */
        private void chooseKeysKeywordCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox1.Text = "Выбор категорий ключей";
            dgv_Keywords.Visible = false;
            checkedListBox1.Visible = true;
            btn_DecheckAll.Visible = true;
            btn_CheckAll.Visible = true;
            cb_ProductTypes.Visible = false;
            btn_AcceptGroupBox1.Visible = true;
            btn_AcceptGroupBox2.Visible = false;

            //отображаем список категорий
            if (checkedCategoriesWasChanged)
            {
                if (kcController.GetKeywordCategoriesByProductId(ProductTypeId))
                {
                    checkedListBox1.Items.Clear();
                    for (int i = 0; i < kcList.Count; i++)
                    {
                        checkedListBox1.Items.Add(kcList[i].CategoryName);
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    checkedCategoriesWasChanged = false;
                }
            }
            else
            {

            }

            checkedListBox1.Focus();
        }

        /* Отображаем ключи по виду товара */
        private void btn_AcceptGroupBox2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dgv_Keywords.Visible = true;

            ProductTypeId = int.Parse(tb_ProductTypeId.Text);
            checkedCategoriesWasChanged = true;

            //получаем ключи (все)
            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + ProductTypeId;

            try         //получаем ключи из БД по категориям и типу продукта
            {
                dgv_Keywords.Rows.Clear();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetKeywordsTodgv_Keywords((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
                UsedKeywordsAnalyser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Отображаем ключи по категориям ключей */
        private void btn_AcceptGroupBox1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dgv_Keywords.Visible = true;

            //получаем все отмеченные категории ключей

            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + ProductTypeId + " AND (CategoryId = ";
            string str = " OR CategoryId = ";

            if (checkedListBox1.CheckedItems.Count == checkedListBox1.Items.Count)  //если отмечены все элементы, то просто делаем select all
            {
                getDBKeywords();
                UsedKeywordsAnalyser();
            }
            else if (checkedListBox1.CheckedItems.Count > 0)        //если отмечена хотябы одна категория
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        checkedCategories.Add(i + 1);       //получаем список индексов категории, по которомым потом будет обращаться
                    }
                }

                sqlStatement += checkedCategories[0];       //формируем select запрос

                for (int i = 1; i < checkedCategories.Count; i++)
                {
                    sqlStatement += str + checkedCategories[i];
                }

                sqlStatement += ")";            //закончили формировать select запрос

                try         //получаем ключи из БД по категориям и типу продукта
                {
                    dgv_Keywords.Rows.Clear();

                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SetKeywordsTodgv_Keywords((IDataRecord)reader);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                    connection.Close();
                    UsedKeywordsAnalyser();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                    Environment.Exit(0);
                }
            }
            else
            {
                dgv_Keywords.Rows.Clear();
            }
        }


        public void GetCategoriesFromDB(object _kcList)
        {
            kcList = (List<KeywordCategoryModel>)_kcList;
        }

        public void GetProductTypesFromDB(object _ptList)
        {
            ptList = (List<ProductTypesModel>)_ptList;
        }

        /*  */
        private void btn_CloseGroupBox_Click(object sender, EventArgs e)
        {
            dgv_Keywords.Visible = true;
            groupBox1.Visible = false;
        }

        /* Держим актуальный ProductTypeId в tb_ProductTypeId при изменении выбора в cb_ProductTypes */
        private void cb_ProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ptList.Count; i++)
            {
                if (ptList[i].TypeName.Equals(cb_ProductTypes.SelectedItem.ToString()))
                    tb_ProductTypeId.Text = ptList[i].ProductTypeId.ToString();
            }
        }

        /* Выделить все элементы в checkedListBox1 */
        private void btn_CheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        /* Снять выделение со всех элементов в checkedListBox1 */
        private void btn_DecheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }
        #endregion

        //----------------------------------------------------------------конец ВЫБОР ВИДА ТОВАРА И КАТЕГОРИЙ КЛЮЧЕЙ----------------------------------------------------------




        //---------------------------------------------------------------ПОЛЬЗОВАТЕЛЬ ВЫДЕЛЯЕТ/СНИМАЕТ ВЫДЕЛЕНИЕ КЛЮЧЕЙ В dgv_Keywords----------------------------------------

        #region выделяем/снимание выделение ключей пользователем 

        /* Скрываем ключ из таблицы dgv_Keywords, попутно удаляя его из usedK */
        private void dgv_Keywords_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (dgv_Keywords.Rows[e.RowIndex].Cells[2].Style.BackColor != Color.White)
                    {
                        GetMarkedKeywords(sender, e);
                        dgv_Keywords.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                        dgv_Keywords.Rows.RemoveAt(e.RowIndex);
                }
            }
        }


        /* Копируем ключ из таблицы и сразу помечаем цветом, где мы его используем */
        private void dgv_Keywords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var str = dgv_Keywords.Rows[e.RowIndex].Cells[2].Value.ToString();

                    Clipboard.SetText(str);

                    if (rb_None.Checked)
                    {
                        dgv_Keywords.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.White;  //нигде не используем, т.е. снимаем выделение
                        GetMarkedKeywords(-1, sender, e);
                    }
                    else if (rb_Title.Checked)
                    {
                        dgv_Keywords.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Coral;  //title
                        GetMarkedKeywords(0, sender, e);
                    }
                    else if (rb_Bullets.Checked)
                    {
                        dgv_Keywords.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.LightBlue;  //bullets
                        GetMarkedKeywords(1, sender, e);
                    }
                    else if (rb_Backend.Checked)
                    {
                        dgv_Keywords.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.LimeGreen;  //backend
                        GetMarkedKeywords(2, sender, e);
                    }
                    else if (rb_Description.Checked)
                    {
                        dgv_Keywords.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.MistyRose;  //description
                        GetMarkedKeywords(3, sender, e);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Упс! Произошел какой-то сбой, попробуйте ещё раз", "Ошибка");
                }
            }
        }

        /* Изменяем used keywords в dgv_Keywords после изменения пользователем */
        private void GetMarkedKeywords(int val, object sender, DataGridViewCellEventArgs e)         // 0 - title, 1 - bullets, 2 - description
        {
            DataGridView dgv = (DataGridView)sender;

            string tmp = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (val != -1)
            {
                bool flag = false;
                for (int i = 0; i < usedK.Count; i++)
                {
                    if (usedK[i].ElementAt(0).Equals(tmp))
                    {
                        usedK[i].SetValue(val.ToString(), 1);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    string[] usedKModel = new string[2];
                    usedK.Add(usedKModel);
                    usedK[usedK.Count - 1].SetValue(tmp, 0);
                    usedK[usedK.Count - 1].SetValue(val.ToString(), 1);
                }
            }
            else
            {
                for (int i = 0; i < usedK.Count; i++)
                {
                    if (usedK[i].ElementAt(0).Equals(tmp))
                    {
                        usedK.RemoveAt(i);
                    }
                }
            }
        }

        /* Изменяем used keywords в dgv_Keywords после изменения пользователем */
        private void GetMarkedKeywords(object sender, DataGridViewCellMouseEventArgs e)         // 0 - title, 1 - bullets, 2 - description
        {
            DataGridView dgv = (DataGridView)sender;

            string tmp = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();

            for (int i = 0; i < usedK.Count; i++)
            {
                if (usedK[i].ElementAt(0).Equals(tmp))
                {
                    usedK.RemoveAt(i);
                }
            }

        }

        #endregion

        //---------------------------------------------------------------конец ПОЛЬЗОВАТЕЛЬ ВЫДЕЛЯЕТ/СНИМАЕТ ВЫДЕЛЕНИЕ КЛЮЧЕЙ В dgv_Keywords----------------------------------




        //---------------------------------------------------------------РАЗНЫЕ МЕТОДЫ ОБРАБОТКИ НАЖАТИЯ КНОПОК---------------------------------------------------------------

        #region разные методы обработки нажатия кнопок

        /*  Копируем ASIN в буфер по клику ЛКМ */
        private void lb_ASIN_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            Clipboard.SetText(label.Text);
        }

        /*  Копируем SKU в буфер по клику ЛКМ */
        private void lb_SKU_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            Clipboard.SetText(label.Text);
        }

        /* Показываем/скрываем дополнительные поля внизу формы */
        private void btn_ShowMore_Click(object sender, EventArgs e)
        {
            if (btn_ShowMore.Text.Equals("Показать больше..."))
            {
                btn_ShowMore.Text = "Показать меньше...";
                ShowMore(true);
                rtb_Notes.Focus();
                dgv_Keywords.Height = 1488;
            }
            else
            {
                btn_ShowMore.Text = "Показать больше...";
                ShowMore(false);
                dgv_Keywords.Height = 775;
            }
        }

        /* Вспомогательный метод для btn_ShowMore_Click() */
        private void ShowMore(bool value)
        {
            RichTextBox[] tb_Array = new RichTextBox[15] { rtb_IntendedUse1, rtb_IntendedUse2, rtb_IntendedUse3, rtb_IntendedUse4, rtb_IntendedUse5, rtb_OtherAttributes1, rtb_OtherAttributes2, rtb_OtherAttributes3, rtb_OtherAttributes4, rtb_OtherAttributes5, rtb_SubjectMatter1, rtb_SubjectMatter2, rtb_SubjectMatter3, rtb_SubjectMatter4, rtb_SubjectMatter5 };

            Label[] lb_Array = new Label[15] { lb_IntendedUse1, lb_IntendedUse2, lb_IntendedUse3, lb_IntendedUse4, lb_IntendedUse5, lb_OtherAttributes1, lb_OtherAttributes2, lb_OtherAttributes3, lb_OtherAttributes4, lb_OtherAttributes5, lb_SubjectMatter1, lb_SubjectMatter2, lb_SubjectMatter3, lb_SubjectMatter4, lb_SubjectMatter5 };

            for (int i = 0; i < 15; i++)
            {
                lb_Array[i].Visible = value;
                tb_Array[i].Visible = value;
            }

            lb_IntendedUseText.Visible = value;
            lb_OtherAttributesText.Visible = value;
            lb_SubjectMatterText.Visible = value;

            lb_Notes.Visible = value;
            rtb_Notes.Visible = value;
        }

        /* Кнопка "Помощь" с информацией об основных функциях системы */
        private void btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Двойной ЛКМ по ключу в таблице - пометить цветом + скопировать ключ в буфер / снять его выделение\n\nПКМ по ключу в таблице - скрыть его\n\n", "Помощь");
        }

        /* Выделение жирным или курсивом ключей в любом richTextBox */
        private void rtb_FontChanging(RichTextBox sender, string font)
        {
            if (sender.SelectionFont != null)
            {
                Font currentFont = sender.SelectionFont;
                FontStyle newFontStyle = FontStyle.Regular;
                switch (font)
                {
                    case "bold":
                        if (sender.SelectionFont.Bold == true)
                        {
                            newFontStyle = FontStyle.Regular;
                        }
                        else
                        {
                            newFontStyle = FontStyle.Bold;
                        }
                        break;
                    case "italic":
                        if (sender.SelectionFont.Italic == true)
                        {
                            newFontStyle = FontStyle.Regular;
                        }
                        else
                        {
                            newFontStyle = FontStyle.Italic;
                        }
                        break;
                }

                sender.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        /* Событие при нажатии Ctrl+B или Ctrl+U */
        private void rtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control)
            {
                rtb_FontChanging((RichTextBox)sender, "bold");
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.U && e.Control)
            {
                rtb_FontChanging((RichTextBox)sender, "italic");
                e.Handled = false;
            }
        }

        #endregion

        //---------------------------------------------------------------конец РАЗНЫЕ МЕТОДЫ ОБРАБОТКИ НАЖАТИЯ КНОПОК---------------------------------------------------------




        //---------------------------------------------------------------МЕТОДЫ ПО ЗАНЕСЕНИЕ ДАННЫХ В БД----------------------------------------------------------------------

        #region методы по занесению данных в БД

        /* Сохранияем изменения с полей в объект */
        private void btn_SaveCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                setUsedKeywordsTo_rtbUsedKeywords();
                setSemanticsByFields();
                CheckForUnsavedChanges = true;
            }
            catch (Exception exc) { MessageBox.Show("Упс! Что-то не так, проверьте корректность введенных данных", "Ошибка"); }
        }


        /* Cохранение новой версии семантики в БД */
        private void btn_UpdateSemantics_Click(object sender, EventArgs e)
        {
            if (CheckForUnsavedChanges)
            {
                if (MessageBox.Show("Имеются несохраненные изменения. Применить их перед сохранение в БД?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    setUsedKeywordsTo_rtbUsedKeywords();
                    setSemanticsByFields();
                    CheckForUnsavedChanges = true;
                    setDBFields();
                }
            }
            else
            {
                try
                {
                    setDBFields();
                    MessageBox.Show("Данные были сохранены успешно!", "Успешно");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Упс! Что-то пошло не так. Проблема с введенными данными или подключением к БД", "Ошибка");
                }
            }
        }

        /* Заганяем данные с dgvSemantics в БД */
        private void setDBFields()
        {
            int index = smList.Count - 1;

            smList[index].UpdateDate = DateTime.Now;

            string sqlStatements = "INSERT INTO [Semantics] ([ProductId], [Title], [Bullet1], [Bullet2], [Bullet3], [Bullet4], [Bullet5], [Backend], [Description], [OtherAttributes1], [OtherAttributes2], [OtherAttributes3], [OtherAttributes4], [OtherAttributes5], [IntendedUse1], [IntendedUse2], [IntendedUse3], [IntendedUse4], [IntendedUse5], [SubjectMatter1], [SubjectMatter2], [SubjectMatter3], [SubjectMatter4], [SubjectMatter5], [UpdateDate], [Notes], [UsedKeywords]) VALUES (" + ProductId + ", '" + smList[index].Title + "', '" + smList[index].Bullet1 + "', '" + smList[index].Bullet2 + "', '" + smList[index].Bullet3 + "', '" + smList[index].Bullet4 + "', '" + smList[index].Bullet5 + "', '" + smList[index].Backend + "', '" + smList[index].Description + "', '" + smList[index].OtherAttributes1 + "', '" + smList[index].OtherAttributes2 + "', '" + smList[index].OtherAttributes3 + "', '" + smList[index].OtherAttributes4 + "', '" + smList[index].OtherAttributes5 + "', '" + smList[index].IntendedUse1 + "', '" + smList[index].IntendedUse2 + "', '" + smList[index].IntendedUse3 + "', '" + smList[index].IntendedUse4 + "', '" + smList[index].IntendedUse5 + "', '" + smList[index].SubjectMatter1 + "', '" + smList[index].SubjectMatter2 + "', '" + smList[index].SubjectMatter3 + "', '" + smList[index].SubjectMatter4 + "', '" + smList[index].SubjectMatter5 + "', '" + smList[index].UpdateDate.ToString("yyyy-MM-dd HH':'mm':'ss") + "', '" + smList[index].Notes + "', '" + smList[index].UsedKeywords + "')";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlStatements, connection);
                command.ExecuteScalar();
                connection.Close();

                CheckForUnsavedChanges = false;
                setDBFieldsLength();
                MessageBox.Show("Данные были сохранены успешно!", "Успешно");
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Произошел какой-то сбой, попробуйте еще раз!", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Сохраняем новые значения длинн полей в БД */
        private void setDBFieldsLength()
        {
            //Try-catch отслеживаем в методе setDBFields()

            string sqlStatement = "UPDATE [FieldsLength] SET [TitleLength] = " + TitleLength + ", [BulletsLength] = " + BulletsLength + ", [BackendLength] = " + BackendLength + ", [SubjectMatterLength] = " + SubjectMatterLength + ", [OtherAttributesLength] = " + OtherAttributesLength + ", [IntendedUseLength] = " + IntendedUseLength + ", [DescriptionLength] = " + DescriptionLength + " WHERE [ProductId] = " + ProductId + "";

            connection.Open();
            SqlCommand command = new SqlCommand(sqlStatement, connection);
            command.ExecuteScalar();
            connection.Close();
        }




        /* Закрываем окно */
        private void Semantics_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlMainFormView != null)
            {
                if (CheckForUnsavedChanges)
                {
                    if (MessageBox.Show("Имеются несохраненные изменения. Сохранить?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            setDBFields();
                            controlMainFormView.Show();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Упс! Произошел какой-то сбой, приложение будет закрыто без сохранения", "Ошибка");
                            Environment.Exit(0);
                            controlMainFormView.Show();
                        }
                    }
                }
                CheckForUnsavedChanges = false;
                connection.Close();     //закрываем соединение с БД
                controlMainFormView.Show();
            }
            else
            {
                if (CheckForUnsavedChanges)
                {
                    if (MessageBox.Show("Имеются несохраненные изменения. Сохранить?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            setDBFields();
                            controlIndexingView.Show();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Упс! Произошел какой-то сбой, приложение будет закрыто без сохранения", "Ошибка");
                            Environment.Exit(0);
                            controlIndexingView.Show();
                        }
                    }
                }
                CheckForUnsavedChanges = false;
                connection.Close();     //закрываем соединение с БД
                controlIndexingView.Show();
            }
        }

        #endregion

        //---------------------------------------------------------------конец МЕТОДЫ ПО ЗАНЕСЕНИЕ ДАННЫХ В БД----------------------------------------------------------------




        //---------------------------------------------------------------МЕТОДЫ ДЛЯ РАБОТЫ С РАЗДЕЛОМ DESCRIPTION-------------------------------------------------------------

        #region работа с разделом description

        /* Функция преобразования дескрипшн из текста в код */
        private string DescToCode(string description)
        {
            string firstPart, secondPart;
            char tmp;
            for (int i = 0; i < description.Length; i++)
            {
                tmp = description[i];
                switch (tmp)
                {
                    case '\n':
                        firstPart = description.Substring(0, i);
                        secondPart = description.Substring(i);
                        description = firstPart + "<br>" + secondPart;
                        i += 4;
                        break;
                }
            }
            return description;
        }

        /* Функция преобразования дескрипшн из кода в текст */
        private string DescToText(string description)
        {
            string firstPart, secondPart;
            string tmp;
            for (int i = 0; i < description.Length; i++)
            {
                if (description[i].Equals('<'))
                {

                }
                else { }
            }
            return description;
        }

        /* Изменили текст в Description -> появились изменения и нужно сохранение */
        private void rtb_Description_TextChanged(object sender, EventArgs e)
        {
            CheckForUnsavedChanges = true;
        }

        /* Преобразовываем дескрипшн */
        private void btn_TransformDescr_Click(object sender, EventArgs e)
        {
            if (reverseDescriptionTransform == true)
                rtb_Description2.Text = DescToCode(rtb_Description.Text);
            else
                rtb_Description2.Text = DescToText(rtb_Description.Text);
        }

        /* Назначаем, во что трансформируем дескрипшн: в текст или в код */
        private void btn_ReverseDescTransform_Click(object sender, EventArgs e)
        {
            if (reverseDescriptionTransform == true)
            {
                reverseDescriptionTransform = false;
                btn_ReverseDescTransform.Text = "В текст";
            }
            else
            {
                reverseDescriptionTransform = true;
                btn_ReverseDescTransform.Text = "В код";
            }
        }

        /* Меняем текст в richTextBox'ах местами */
        private void btn_ReplaceTexts_Click(object sender, EventArgs e)
        {
            string tmp;
            tmp = rtb_Description.Text;
            rtb_Description.Text = rtb_Description2.Text;
            rtb_Description2.Text = tmp;
        }

        #endregion

        //---------------------------------------------------------------конец МЕТОДЫ ДЛЯ РАБОТЫ С РАЗДЕЛОМ DESCRIPTION-------------------------------------------------------
        
    }
}