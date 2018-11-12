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
    public partial class Semantics : Form
    {
        private int TitleLength, BulletsLength, BackendLength, DescriptionLength, SubjectMatterLength, OtherAttributesLength, IntendedUseLength;

        private SqlConnection connection;
        private static int ProductId;
        private int ProductTypeId;          //это для заполнения таблицы ключей
        private int SemanticsId;

        private int CurrentDay;             //дата загрузки семантики с БД для редактирования
        private bool isCurrentDay = false; 

        private bool CheckForUnsavedChanges;        //чтобы не закрыть прогу без сохранения
        private bool reverseDescriptionTransform;

        public Semantics(int _productId)
        {
            InitializeComponent();

            ProductId = _productId;

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
            connection = DBData.GetDBConnection();

            getDBFieldsLength();            
            getDBFields();
            getDBProductInfo();
            getDBKeywords();

            CheckForUnsavedChanges = false;
        }


        /* Заполняем таблицу с ключами из БД */
        private void getDBKeywords()
        {
            string sqlStatement = "SELECT ProductTypeId FROM Products WHERE ProductId = " + ProductId;
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                ProductTypeId = int.Parse(command.ExecuteScalar().ToString());

                sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + ProductTypeId;
                command = new SqlCommand(sqlStatement, connection);
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

        /* Заполняем поля на форме инфо о продукте */
        private void getDBProductInfo()
        {
            string sqlSemanticsIds = "SELECT * FROM Products WHERE ProductId = " + ProductId;
            SqlCommand command = new SqlCommand(sqlSemanticsIds, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetProductsToDataGrid((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                lb_ASIN.Text = dgvProducts.Rows[0].Cells[1].Value.ToString();
                lb_SKU.Text = dgvProducts.Rows[0].Cells[2].Value.ToString();
                lb_ProductName.Text = dgvProducts.Rows[0].Cells[3].Value.ToString();
                ProductTypeId = int.Parse(dgvProducts.Rows[0].Cells[4].Value.ToString());

                this.Text = "Семантика - " + lb_ProductName.Text;
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Заполняем "невидимую" dataGridView3 (dgv4), содержащую инфо о продукте */
        private void SetProductsToDataGrid(IDataRecord record)
        {
            var index = dgvProducts.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgvProducts.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Заполняем все поля на форме */
        private void getDBFields()
        {
            string sqlSemanticsIds = "SELECT * FROM Semantics WHERE ProductId = " + ProductId;
            SqlCommand command = new SqlCommand(sqlSemanticsIds, connection);
            
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetSemanticsToDataGrid((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
                FillDates();
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Заполняем "невидимую" dataGridView2 (dgv2), содержащую семантику */
        private void SetSemanticsToDataGrid(IDataRecord record)
        {
            var index = dgvSemantics.Rows.Add();

            for (int i = 0; i < record.FieldCount; i++)
            {
                dgvSemantics.Rows[index].Cells[i].Value = record[i];
            }
        }

        /* Заполняем ComboBox с датами и вызываем заполнение полей по дате */
        private void FillDates()
        {
            cb_LastUpdated.Items.Clear();

            for (int i = 0; i < dgvSemantics.RowCount - 1; i++)
            {
                cb_LastUpdated.Items.Add(dgvSemantics.Rows[i].Cells[25].Value.ToString());
            }

            cb_LastUpdated.SelectedItem = dgvSemantics.Rows[dgvSemantics.RowCount - 2].Cells[25].Value.ToString();
            try
            {
                FillFields(dgvSemantics.Rows[dgvSemantics.RowCount - 2].Cells[25].Value.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Упс! Возникла проблема с подключением к БД :( Приложение будет закрыто", "Ошибка");
                Environment.Exit(0);
            }
        }

        /* Заполнение основных полей по дате */
        private void FillFields(string value)
        {
            int index = -1;
            
            for (int i = 0; i < dgvSemantics.RowCount - 1; i++)
            {
                if (dgvSemantics.Rows[i].Cells[25].Value.ToString().Equals(value))
                {
                    index = i;
                }
            }

            tb_Title.Text = dgvSemantics.Rows[index].Cells[2].Value.ToString();
            tb_Bul1.Text = dgvSemantics.Rows[index].Cells[3].Value.ToString();
            tb_Bul2.Text = dgvSemantics.Rows[index].Cells[4].Value.ToString();
            tb_Bul3.Text = dgvSemantics.Rows[index].Cells[5].Value.ToString();
            tb_Bul4.Text = dgvSemantics.Rows[index].Cells[6].Value.ToString();
            tb_Bul5.Text = dgvSemantics.Rows[index].Cells[7].Value.ToString();
            tb_Backend.Text = dgvSemantics.Rows[index].Cells[8].Value.ToString();
            rtb_Description.Text = dgvSemantics.Rows[index].Cells[9].Value.ToString();
            tb_OtherAttributes1.Text = dgvSemantics.Rows[index].Cells[10].Value.ToString();
            tb_OtherAttributes2.Text = dgvSemantics.Rows[index].Cells[11].Value.ToString();
            tb_OtherAttributes3.Text = dgvSemantics.Rows[index].Cells[12].Value.ToString();
            tb_OtherAttributes4.Text = dgvSemantics.Rows[index].Cells[13].Value.ToString();
            tb_OtherAttributes5.Text = dgvSemantics.Rows[index].Cells[14].Value.ToString();
            tb_IntendedUse1.Text = dgvSemantics.Rows[index].Cells[15].Value.ToString();
            tb_IntendedUse2.Text = dgvSemantics.Rows[index].Cells[16].Value.ToString();
            tb_IntendedUse3.Text = dgvSemantics.Rows[index].Cells[17].Value.ToString();
            tb_IntendedUse4.Text = dgvSemantics.Rows[index].Cells[18].Value.ToString();
            tb_IntendedUse5.Text = dgvSemantics.Rows[index].Cells[19].Value.ToString();
            tb_SubjectMatter1.Text = dgvSemantics.Rows[index].Cells[20].Value.ToString();
            tb_SubjectMatter2.Text = dgvSemantics.Rows[index].Cells[21].Value.ToString();
            tb_SubjectMatter3.Text = dgvSemantics.Rows[index].Cells[22].Value.ToString();
            tb_SubjectMatter4.Text = dgvSemantics.Rows[index].Cells[23].Value.ToString();
            tb_SubjectMatter5.Text = dgvSemantics.Rows[index].Cells[24].Value.ToString();
            rtb_Notes.Text = dgvSemantics.Rows[index].Cells[26].Value.ToString();
            rtb_UsedKeywords.Text = dgvSemantics.Rows[index].Cells[27].Value.ToString();

            //СЮДА ВПИСАТЬ ОБРАБОТЧИК ДЛЯ ПЕРЕКРАШИВАНИЯ ИСПОЛЬЗОВАННЫЙ КЛЮЧЕЙ В ТАБЛИЦЕ
            ChangeColorOf_dgvKeywords_afterChangingDate();
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
                else {  }
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
                dgvSemantics.Rows[index].Cells[2].Value = tb_Title.Text;
                dgvSemantics.Rows[index].Cells[3].Value = tb_Bul1.Text;
                dgvSemantics.Rows[index].Cells[4].Value = tb_Bul2.Text;
                dgvSemantics.Rows[index].Cells[5].Value = tb_Bul3.Text;
                dgvSemantics.Rows[index].Cells[6].Value = tb_Bul4.Text;
                dgvSemantics.Rows[index].Cells[7].Value = tb_Bul5.Text;
                dgvSemantics.Rows[index].Cells[8].Value = tb_Backend.Text;
                dgvSemantics.Rows[index].Cells[9].Value = rtb_Description.Text;
                dgvSemantics.Rows[index].Cells[10].Value = tb_OtherAttributes1.Text;
                dgvSemantics.Rows[index].Cells[11].Value = tb_OtherAttributes2.Text;
                dgvSemantics.Rows[index].Cells[12].Value = tb_OtherAttributes3.Text;
                dgvSemantics.Rows[index].Cells[13].Value = tb_OtherAttributes4.Text;
                dgvSemantics.Rows[index].Cells[14].Value = tb_OtherAttributes5.Text;
                dgvSemantics.Rows[index].Cells[15].Value = tb_IntendedUse1.Text;
                dgvSemantics.Rows[index].Cells[16].Value = tb_IntendedUse2.Text;
                dgvSemantics.Rows[index].Cells[17].Value = tb_IntendedUse3.Text;
                dgvSemantics.Rows[index].Cells[18].Value = tb_IntendedUse4.Text;
                dgvSemantics.Rows[index].Cells[19].Value = tb_IntendedUse5.Text;
                dgvSemantics.Rows[index].Cells[20].Value = tb_SubjectMatter1.Text;
                dgvSemantics.Rows[index].Cells[21].Value = tb_SubjectMatter2.Text;
                dgvSemantics.Rows[index].Cells[22].Value = tb_SubjectMatter3.Text;
                dgvSemantics.Rows[index].Cells[23].Value = tb_SubjectMatter4.Text;
                dgvSemantics.Rows[index].Cells[24].Value = tb_SubjectMatter5.Text;
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
            FillFields(cb.SelectedItem.ToString());
        }
        
        private void TextBoxChanged(object sender)
        {
            TextBox textBox = (TextBox)sender;

            switch (textBox.Name)
            {
                case "tb_Title":
                    if (textBox.TextLength > TitleLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Title.Text = textBox.TextLength.ToString();
                    break;
                case "tb_Bul1":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet1.Text = textBox.TextLength.ToString();
                    break;
                case "tb_Bul2":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet2.Text = textBox.TextLength.ToString();
                    break;
                case "tb_Bul3":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet3.Text = textBox.TextLength.ToString();
                    break;
                case "tb_Bul4":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet4.Text = textBox.TextLength.ToString();
                    break;
                case "tb_Bul5":
                    if (textBox.TextLength > BulletsLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Bullet5.Text = textBox.TextLength.ToString();
                    break;
                case "tb_Backend":
                    if (textBox.TextLength > BackendLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_Backend.Text = textBox.TextLength.ToString();
                    break;
                case "tb_OtherAttributes1":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes1.Text = textBox.TextLength.ToString();
                    break;
                case "tb_OtherAttributes2":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes2.Text = textBox.TextLength.ToString();
                    break;
                case "tb_OtherAttributes3":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes3.Text = textBox.TextLength.ToString();
                    break;
                case "tb_OtherAttributes4":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes4.Text = textBox.TextLength.ToString();
                    break;
                case "tb_OtherAttributes5":
                    if (textBox.TextLength > OtherAttributesLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_OtherAttributes5.Text = textBox.TextLength.ToString();
                    break;
                case "tb_IntendedUse1":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse1.Text = textBox.TextLength.ToString();
                    break;
                case "tb_IntendedUse2":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse2.Text = textBox.TextLength.ToString();
                    break;
                case "tb_IntendedUse3":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse3.Text = textBox.TextLength.ToString();
                    break;
                case "tb_IntendedUse4":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse4.Text = textBox.TextLength.ToString();
                    break;
                case "tb_IntendedUse5":
                    if (textBox.TextLength > IntendedUseLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_IntendedUse5.Text = textBox.TextLength.ToString();
                    break;
                case "tb_SubjectMatter1":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter1.Text = textBox.TextLength.ToString();
                    break;
                case "tb_SubjectMatter2":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter2.Text = textBox.TextLength.ToString();
                    break;
                case "tb_SubjectMatter3":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter3.Text = textBox.TextLength.ToString();
                    break;
                case "tb_SubjectMatter4":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter4.Text = textBox.TextLength.ToString();
                    break;
                case "tb_SubjectMatter5":
                    if (textBox.TextLength > SubjectMatterLength)
                        textBox.ForeColor = Color.Red;
                    else
                        textBox.ForeColor = Color.Black;
                    lb_SubjectMatter5.Text = textBox.TextLength.ToString();
                    break;
            }
            CheckForUnsavedChanges = true;
        }

        /* Обработчик ввода текста в textbox'ы */
        private void tb_TextChanged(object sender, EventArgs e)
        {
            TextBoxChanged(sender);
        }

        /* Копируем ключ из таблицы и сразу помечаем цветом, где мы его используем */
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var str = dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Clipboard.SetText(str);
                if (rb_Title.Checked)
                    dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Coral;  //title
                else if (rb_Bullets.Checked)
                    dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightBlue;  //bullets
                else if (rb_Backend.Checked)
                    dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LimeGreen;  //backend
                else
                    dgv_Keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.MistyRose;  //Title
            }
            catch (Exception exc)
            {
                MessageBox.Show("Упс! Произошел какой-то сбой, попробуйте ещё раз", "Ошибка");
            }
        }

        /* Вставляем скопированый ключ в text_box средней кнопкой мыши */
        private void tb_Title_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tb_Title.Text = tb_Title.Text + " " + Clipboard.GetText();
                tb_Title.Select(tb_Title.TextLength, 0);
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
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Упс! Произошел какой-то сбой, приложение будет закрыто без сохранения", "Ошибка");
                        Environment.Exit(0);
                    }
                }
            }
            CheckForUnsavedChanges = false;
            connection.Close();     //закрываем соединение с БД
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
            using (FieldsLength FieldsLength = new FieldsLength(TitleLength, BulletsLength, BackendLength, DescriptionLength, IntendedUseLength,SubjectMatterLength, OtherAttributesLength))
            {
                if (FieldsLength.ShowDialog() == DialogResult.OK)
                {
                    TitleLength = FieldsLength.TitleLength;
                    BulletsLength = FieldsLength.BulletsLength;;
                    BackendLength = FieldsLength.BackendLength;
                    DescriptionLength = FieldsLength.DescriptionLength;
                    IntendedUseLength = FieldsLength.IntendedUseLength;
                    SubjectMatterLength = FieldsLength.SubjectMatterLength;
                    OtherAttributesLength = FieldsLength.OtherAttributesLength;
                    
                    TextBoxChanged(tb_Title);
                    TextBoxChanged(tb_Bul1);
                    TextBoxChanged(tb_Bul2);
                    TextBoxChanged(tb_Bul3);
                    TextBoxChanged(tb_Bul4);
                    TextBoxChanged(tb_Bul5);
                    TextBoxChanged(tb_Backend);
                    TextBoxChanged(tb_OtherAttributes1);
                    TextBoxChanged(tb_OtherAttributes2);
                    TextBoxChanged(tb_OtherAttributes3);
                    TextBoxChanged(tb_OtherAttributes4);
                    TextBoxChanged(tb_OtherAttributes5);
                    TextBoxChanged(tb_IntendedUse1);
                    TextBoxChanged(tb_IntendedUse2);
                    TextBoxChanged(tb_IntendedUse3);
                    TextBoxChanged(tb_IntendedUse4);
                    TextBoxChanged(tb_IntendedUse5);
                    TextBoxChanged(tb_SubjectMatter1);
                    TextBoxChanged(tb_SubjectMatter2);
                    TextBoxChanged(tb_SubjectMatter3);
                    TextBoxChanged(tb_SubjectMatter4);
                    TextBoxChanged(tb_SubjectMatter5);

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (rtb_Description.SelectionFont != null)
            {
                Font currentFont = rtb_Description.SelectionFont;
                FontStyle newFontStyle;

                if (rtb_Description.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                rtb_Description.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
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

        /* Показываем/скрываем дополнительные поля внизу формы */
        private void btn_ShowMore_Click(object sender, EventArgs e)
        {
            if (btn_ShowMore.Text.Equals("Показать больше..."))
            {
                btn_ShowMore.Text = "Показать меньше...";
                ShowMore(true);
                rtb_Notes.Focus();
                dgv_Keywords.Height = 1500;
            } else
            {
                btn_ShowMore.Text = "Показать больше...";
                ShowMore(false);
                dgv_Keywords.Height = 775;
            }
        }

        /* Вспомогательный метод для btn_ShowMore_Click() */
        private void ShowMore(bool value)
        {
            TextBox[] tb_Array = new TextBox[15] { tb_IntendedUse1, tb_IntendedUse2, tb_IntendedUse3, tb_IntendedUse4, tb_IntendedUse5, tb_OtherAttributes1, tb_OtherAttributes2, tb_OtherAttributes3, tb_OtherAttributes4, tb_OtherAttributes5, tb_SubjectMatter1, tb_SubjectMatter2, tb_SubjectMatter3, tb_SubjectMatter4, tb_SubjectMatter5};

            Label[] lb_Array = new Label[15] { lb_IntendedUse1, lb_IntendedUse2, lb_IntendedUse3, lb_IntendedUse4, lb_IntendedUse5, lb_OtherAttributes1, lb_OtherAttributes2, lb_OtherAttributes3, lb_OtherAttributes4, lb_OtherAttributes5, lb_SubjectMatter1, lb_SubjectMatter2, lb_SubjectMatter3, lb_SubjectMatter4, lb_SubjectMatter5};
            
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
            try { setFieldsToDGVSemantics(); }
            catch (Exception exc) { MessageBox.Show("Упс! Что-то не так, проверьте корректность введенных данных", "Ошибка"); }
        }

        /* Заполняем поля последними внесенными значениями с dgv_Semantics */
        private void btn_Return_Click(object sender, EventArgs e)
        {
            FillFields(cb_LastUpdated.SelectedItem.ToString());
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