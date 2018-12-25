using Microsoft.VisualBasic.FileIO;
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
        private int ProductTypeId;          //это для заполнения таблицы ключей
        private static int ProductId;
        private List<SemanticsModel> smList;

        private List<string[]> usedK;           //храним все usedKeywords






        private SqlConnection connection;
        private int SemanticsId;

        private int CurrentDay;             //дата загрузки семантики с БД для редактирования
        private bool isCurrentDay = false;

        private bool CheckForUnsavedChanges;        //чтобы не закрыть прогу без сохранения
        private bool reverseDescriptionTransform;
        MainFormView mf;

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

            mf = _mf;
            connection = DBData.GetDBConnection();
            smList = new List<SemanticsModel> { };
            usedK = new List<string[]> { };

            getStarted();
        }

        //------------------------------------------------------------------REGION----------------------------------------------------------------
        #region My Methods

        private void getStarted()
        {
            btn_TransformDescr.Text = "П\nр\nе\nо\nб\nр\nа\nз\nо\nв\nа\nт\nь\n";
            btn_ReplaceTexts.Text = "S\nw\na\np\n";
            reverseDescriptionTransform = true;
            CheckForUnsavedChanges = false;
            CurrentDay = DateTime.Today.Day;      //По этому признаку определяем версию семантики в течении одного сеанса


            getDBFieldsLength();
            getDBFields();
            getDBKeywords();            

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

        /* Заполняем "невидимую" dataGridView2 (dgv2), содержащую семантику */
        private void SetSemanticsToList(IDataRecord record)
        {
            //var index = dgvSemantics.Rows.Add();
            SemanticsModel sm = new SemanticsModel();
            smList.Add(sm);

            for (int i = 0; i < record.FieldCount; i++)
            {
                //dgvSemantics.Rows[index].Cells[i].Value = record[i];
                smList[smList.Count - 1].SetSemantics(i, record[i]);
            }
        }
        

        //----------------------ТУТА ПЕРЕДЕЛАТЬ, ЧТОБЫ МОЖНО БЫЛО ВЫБИРАТЬ КАТЕГОРИИ КЛЮЧЕЙ, КОТОРЫЕ ХОТИМ ВЫБРАТЬ. ПО УМОЛЧАНИЮ - ВЫБРАНЫ ВСЕ ВОЗМОЖНЫЕ КАТЕГОРИИ
        /* Заполняем таблицу с ключами из БД */
        private void getDBKeywords()
        {
            try
            {
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
                UsedKeywordsAnalyser();
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




        /* Заполняем ComboBox с датами и вызываем заполнение полей по дате */
        private void Fill_CB_byDates()
        {
            cb_LastUpdated.Items.Clear();

            for (int i = 0; i < smList.Count; i++)
            {
                cb_LastUpdated.Items.Add(smList[i].UpdateDate);
            }
            cb_LastUpdated.SelectedItem = cb_LastUpdated.Items[cb_LastUpdated.Items.Count - 1];

            try
            {
                FillFieldsBySemanticsValues(cb_LastUpdated.SelectedItem.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Заполнение основных полей данными конретной версии семантики */
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

            ForcedTextBoxChanging();
            
            UsedKeywordsAnalyser();
            MarkUsedKeywords();
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

            SetUsedKeywordsTo_dgv_UsedKeywords(_arrUsedKeywords);
            MarkUsedKeywords();
        }

        /* Вносим used keywords в dgv_UsedKeywords */
        private void SetUsedKeywordsTo_dgv_UsedKeywords(string[,] _arrUsedKeywords)
        {
            string[] tmp;

            //dgv_UsedKeywords.Rows.Clear();
            for (int j = 0; j < _arrUsedKeywords.Length / 2; j++)
            {
                tmp = new string[2];
                usedK.Add(tmp);
                //var index = dgv_UsedKeywords.Rows.Add();

                for (int i = 0; i < 2; i++)
                {
                    //dgv_UsedKeywords.Rows[index].Cells[i].Value = _arrUsedKeywords[j, i];
                    usedK[usedK.Count - 1].SetValue(_arrUsedKeywords[j, i], i);
                }

            }
        }

        /* Маркируем ключи в dgv_Keywords */
        private void MarkUsedKeywords()
        {
            for (int i = 0; i < dgv_Keywords.RowCount - 1; i++)
            {
                dgv_Keywords.Rows[i].Cells[2].Style.BackColor = Color.White;
            }

            for (int i = 0; i < dgv_UsedKeywords.RowCount - 1; i++)
            {
                for (int j = 0; j < dgv_Keywords.RowCount; j++)
                {
                    if (dgv_UsedKeywords.Rows[i].Cells[0].Value.ToString().Equals(dgv_Keywords.Rows[j].Cells[2].Value.ToString()))
                    {
                        switch (dgv_UsedKeywords.Rows[i].Cells[1].Value.ToString())
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
                                //description
                                dgv_Keywords.Rows[j].Cells[2].Style.BackColor = Color.MistyRose;
                                break;
                        }
                    }
                }
            }
        }


















































        //---------------------------------------МЕТОДЫ ДЛЯ РАБОТЫ С UsedKeywords ---------------------------------

        /* Заносим used keywords из dgv_UsedKeywords в rtb_UsedKeywords по шаблону*/
        private void setUsedKeywordsTo_rtbUsedKeywords()
        {
            rtb_UsedKeywords.Text = "";
            for (int i = 0; i < dgv_UsedKeywords.RowCount - 1; i++)
            {
                rtb_UsedKeywords.Text += dgv_UsedKeywords.Rows[i].Cells[0].Value.ToString() + "|" + dgv_UsedKeywords.Rows[i].Cells[1].Value.ToString() + "|";
            }
        }

        /* Изменяем used keywords в dgv_Keywords после изменения пользователем */
        private void GetMarkedKeywords(int val, object sender, DataGridViewCellEventArgs e)         // 0 - title, 1 - bullets, 2 - description
        {
            DataGridView dgv = (DataGridView)sender;

            string tmp = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            bool flag = false;
            for (int i = 0; i < dgv_UsedKeywords.RowCount - 1; i++)
            {
                if (dgv_UsedKeywords.Rows[i].Cells[0].Value.ToString().Equals(tmp))
                {
                    dgv_UsedKeywords.Rows[i].Cells[1].Value = val;
                    flag = true;
                }
            }
            if (!flag)
            {
                var index = dgv_UsedKeywords.Rows.Add();

                dgv_UsedKeywords.Rows[index].Cells[0].Value = tmp;
                dgv_UsedKeywords.Rows[index].Cells[1].Value = val;
            }
        }


        //--------------------------------КОНЕЦ ----------- МЕТОДЫ ДЛЯ РАБОТЫ С UsedKeywords -------- КОНЕЦ---------------------------------

            


       

        private void Rtb_Title_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /* Перекрашывает ключи в dgv_Keywords после изменения версии (даты) семантики */
        private void ChangeColorOf_dgvKeywords_afterChangingDate()
        {

        }

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

        /* Заганяем данные с dgvSemantics в БД */
        private void setDBFields()
        {
            int index = dgvSemantics.RowCount - 2;

            DateTime dt = new DateTime();
            dt = (DateTime)dgvSemantics.Rows[index].Cells[25].Value;

            string sqlStatements = "INSERT INTO [Semantics] ([ProductId], [Title], [Bullet1], [Bullet2], [Bullet3], [Bullet4], [Bullet5], [Backend], [Description], [OtherAttributes1], [OtherAttributes2], [OtherAttributes3], [OtherAttributes4], [OtherAttributes5], [IntendedUse1], [IntendedUse2], [IntendedUse3], [IntendedUse4], [IntendedUse5], [SubjectMatter1], [SubjectMatter2], [SubjectMatter3], [SubjectMatter4], [SubjectMatter5], [UpdateDate], [Notes], [UsedKeywords]) VALUES (" + ProductId + ", '" + dgvSemantics.Rows[index].Cells[2].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[3].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[4].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[5].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[6].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[7].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[8].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[9].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[10].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[11].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[12].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[13].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[14].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[15].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[16].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[17].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[18].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[19].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[20].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[21].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[22].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[23].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[24].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[25].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[26].Value.ToString() + "', '" + dgvSemantics.Rows[index].Cells[27].Value.ToString() + "')";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlStatements, connection);
                command.ExecuteScalar();
                connection.Close();

                CheckForUnsavedChanges = false;
                setDBFieldsLength();
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

        /* Заганяем данные с полей в dgvSemantics */
        private void setFieldsToDGVSemantics()
        {
            int index = -1;

            for (int i = 0; i < dgvSemantics.RowCount - 1; i++)
            {
                if (dgvSemantics.Rows[i].Cells[25].Value.ToString().Equals(cb_LastUpdated.SelectedItem.ToString()))
                {
                    index = i;
                }
            }
            if (DateTime.Now.Day == CurrentDay && !isCurrentDay)
            {
                index = dgvSemantics.Rows.Add();
                isCurrentDay = true;
            }

            dgvSemantics.Rows[index].Cells[1].Value = ProductId;
            dgvSemantics.Rows[index].Cells[2].Value = rtb_Title.Text;
            dgvSemantics.Rows[index].Cells[3].Value = rtb_Bul1.Text;
            dgvSemantics.Rows[index].Cells[4].Value = rtb_Bul2.Text;
            dgvSemantics.Rows[index].Cells[5].Value = rtb_Bul3.Text;
            dgvSemantics.Rows[index].Cells[6].Value = rtb_Bul4.Text;
            dgvSemantics.Rows[index].Cells[7].Value = rtb_Bul5.Text;
            dgvSemantics.Rows[index].Cells[8].Value = rtb_Backend.Text;
            dgvSemantics.Rows[index].Cells[9].Value = rtb_Description.Text;
            dgvSemantics.Rows[index].Cells[10].Value = rtb_OtherAttributes1.Text;
            dgvSemantics.Rows[index].Cells[11].Value = rtb_OtherAttributes2.Text;
            dgvSemantics.Rows[index].Cells[12].Value = rtb_OtherAttributes3.Text;
            dgvSemantics.Rows[index].Cells[13].Value = rtb_OtherAttributes4.Text;
            dgvSemantics.Rows[index].Cells[14].Value = rtb_OtherAttributes5.Text;
            dgvSemantics.Rows[index].Cells[15].Value = rtb_IntendedUse1.Text;
            dgvSemantics.Rows[index].Cells[16].Value = rtb_IntendedUse2.Text;
            dgvSemantics.Rows[index].Cells[17].Value = rtb_IntendedUse3.Text;
            dgvSemantics.Rows[index].Cells[18].Value = rtb_IntendedUse4.Text;
            dgvSemantics.Rows[index].Cells[19].Value = rtb_IntendedUse5.Text;
            dgvSemantics.Rows[index].Cells[20].Value = rtb_SubjectMatter1.Text;
            dgvSemantics.Rows[index].Cells[21].Value = rtb_SubjectMatter2.Text;
            dgvSemantics.Rows[index].Cells[22].Value = rtb_SubjectMatter3.Text;
            dgvSemantics.Rows[index].Cells[23].Value = rtb_SubjectMatter4.Text;
            dgvSemantics.Rows[index].Cells[24].Value = rtb_SubjectMatter5.Text;
            dgvSemantics.Rows[index].Cells[25].Value = DateTime.Now;
            dgvSemantics.Rows[index].Cells[26].Value = rtb_Notes.Text;
            dgvSemantics.Rows[index].Cells[27].Value = rtb_UsedKeywords.Text;

            cb_LastUpdated.Items.Add(dgvSemantics.Rows[index].Cells[25].Value.ToString());
            cb_LastUpdated.SelectedItem = dgvSemantics.Rows[dgvSemantics.RowCount - 2].Cells[25].Value.ToString();
        }

        #endregion
        //-----------------------------------------------------------------ENDREGION--------------------------------------------------------------



        //------------------------------------------------------------------REGION----------------------------------------------------------------
        #region Events Handlers

        /* Обработчик изменения версии (даты) листинга */
        private void cb_LastUpdated_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            FillFieldsBySemanticsValues(cb.SelectedItem.ToString());
        }

        

        /* Обработчик ввода текста в textbox'ы */
        private void tb_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(sender);
        }

        /* Копируем ключ из таблицы и сразу помечаем цветом, где мы его используем */
        private void dgv_Keywords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var str = dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Clipboard.SetText(str);

                if (rb_Title.Checked)
                {
                    dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Coral;  //title
                    GetMarkedKeywords(0, sender, e);
                }
                else if (rb_Bullets.Checked)
                {
                    dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightBlue;  //bullets
                    GetMarkedKeywords(1, sender, e);
                }
                else if (rb_Backend.Checked)
                {
                    //dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LimeGreen;  //backend

                }
                else if (rb_Description.Checked)
                {
                    dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.MistyRose;  //description
                    GetMarkedKeywords(2, sender, e);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Упс! Произошел какой-то сбой, попробуйте ещё раз", "Ошибка");
            }
        }

        /* Вставляем скопированый ключ в text_box средней кнопкой мыши */
        private void rtb_Title_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rtb_Title.Text = rtb_Title.Text + " " + Clipboard.GetText();
                rtb_Title.Select(rtb_Title.TextLength, 0);
            }
        }

        /* Закрываем окно */
        private void Semantics_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckForUnsavedChanges)
            {
                if (MessageBox.Show("Имеются несохраненные изменения. Сохранить?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        setFieldsToDGVSemantics();
                        setDBFields();
                        mf.Show();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Упс! Произошел какой-то сбой, приложение будет закрыто без сохранения", "Ошибка");
                        Environment.Exit(0);
                        mf.Show();
                    }
                }
            }
            CheckForUnsavedChanges = false;
            connection.Close();     //закрываем соединение с БД
            mf.Show();
        }

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


        #endregion
        //-----------------------------------------------------------------ENDREGION--------------------------------------------------------------



        //------------------------------------------------------------------REGION----------------------------------------------------------------
        #region Button Handlers
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

        /* Изменяем размеры длинн полей */
        private void tsMenu_fieldsLength_Click(object sender, EventArgs e)
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

        private void Semantics_Load(object sender, EventArgs e)
        {

        }

        /* Меняем текст в richTextBox'ах местами */
        private void btn_ReplaceTexts_Click(object sender, EventArgs e)
        {
            string tmp;
            tmp = rtb_Description.Text;
            rtb_Description.Text = rtb_Description2.Text;
            rtb_Description2.Text = tmp;
        }

        /* Показываем/скрываем дополнительные поля внизу формы */
        private void btn_ShowMore_Click(object sender, EventArgs e)
        {
            if (btn_ShowMore.Text.Equals("Показать больше..."))
            {
                btn_ShowMore.Text = "Показать меньше...";
                ShowMore(true);
                rtb_Notes.Focus();
                dgv_Keywords.Height = 1500;
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

        /* Cохранение новой версии семантики в БД */
        private void btn_UpdateSemantics_Click(object sender, EventArgs e)
        {
            try { setDBFields(); }
            catch (Exception exc) { MessageBox.Show("Упс! Что-то пошло не так. Проблема с введенными данными или подключением к БД", "Ошибка"); }
        }

        /* Сохранияем изменения с полей в таблицу dgv_Semantics */
        private void btn_SaveCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                setUsedKeywordsTo_rtbUsedKeywords();
                setFieldsToDGVSemantics();
            }
            catch (Exception exc) { MessageBox.Show("Упс! Что-то не так, проверьте корректность введенных данных", "Ошибка"); }
        }

        /* Заполняем поля последними внесенными значениями с dgv_Semantics */
        private void btn_Return_Click(object sender, EventArgs e)
        {
            FillFieldsBySemanticsValues(cb_LastUpdated.SelectedItem.ToString());
            UsedKeywordsAnalyser();
        }

        #endregion
        //-----------------------------------------------------------------ENDREGION--------------------------------------------------------------

    }
}




















//string sqlTitle = "SELECT TitleLength FROM FieldsLength WHERE ProductId = " + ProductId;
//string sqlBullets = "SELECT BulletsLength FROM FieldsLength WHERE ProductId = " + ProductId;
//string sqlBackend = "SELECT BackendLength FROM FieldsLength WHERE ProductId = " + ProductId;
//string sqlDescription = "SELECT DescriptionLength FROM FieldsLength WHERE ProductId = " + ProductId;
//string sqlSubjectMatter = "SELECT SubjectMatterLength FROM FieldsLength WHERE ProductId = " + ProductId;
//string sqlOtherAttributes = "SELECT OtherAttributesLength FROM FieldsLength WHERE ProductId = " + ProductId;
//string sqlIntendedUse = "SELECT IntendedUseLength FROM FieldsLength WHERE ProductId = " + ProductId;

//connection.Open(); 

//SqlCommand command = new SqlCommand(sqlTitle, connection);
//TitleLength = int.Parse(command.ExecuteScalar().ToString());
//lb_TitleText.Text = "Title (" + TitleLength + ")";

//command = new SqlCommand(sqlBullets, connection);
//BulletsLength = int.Parse(command.ExecuteScalar().ToString());
//lb_BulletsText.Text = "Bullets (" + BulletsLength + ")";

//command = new SqlCommand(sqlBackend, connection);
//BackendLength = int.Parse(command.ExecuteScalar().ToString());
//lb_BackendText.Text = "Backend (" + BackendLength + ")";

//command = new SqlCommand(sqlDescription, connection);
//DescriptionLength = int.Parse(command.ExecuteScalar().ToString());
//lb_DescriptionText.Text = "Description (" + DescriptionLength + ")";

//command = new SqlCommand(sqlSubjectMatter, connection);
//SubjectMatterLength = int.Parse(command.ExecuteScalar().ToString());
//lb_SubjectMatterText.Text = "Subject Matter (" + SubjectMatterLength + ")";

//command = new SqlCommand(sqlOtherAttributes, connection);
//OtherAttributesLength = int.Parse(command.ExecuteScalar().ToString());
//lb_OtherAttributesText.Text = "Other Attributes (" + OtherAttributesLength + ")";

//command = new SqlCommand(sqlIntendedUse, connection);
//IntendedUseLength = int.Parse(command.ExecuteScalar().ToString());
//lb_IntendedUseText.Text = "Intended Use (" + IntendedUseLength + ")";

//connection.Close();