using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class SemCoreRebuildView : Form
    {
        private KeywordCategoryController kcController;
        private List<KeywordCategoryModel> kcList;

        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;

        private SemCoreController scController;
        private List<SemCoreModel> scList;

        private List<SemCoreModel> scNewList;
        private List<SemCoreModel> scUpdateList;
        private List<SemCoreModel> scExistingFromDBList;

        private SqlConnection connection;
        private Form mf;

        private bool NewCategorywasAdded;               //Чтобы знать, была ли добавленна новая категория в btn_AddCategory_Click

        private string path = "";
            
        private string str_UploadedKeys = "Новые ключи";
        private string str_UpdatedKeys = "Обновленные ключи";
        
        string[,] myArr;

        private bool firstLaunch = true;       

        string urlAmazon = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=";

        public bool NoProdType { get; set; }
        public bool NoKeyCat { get; set; }



        /* Конструктор */
        public SemCoreRebuildView(Form _mf)
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            mf = _mf;
            lb_UpdatedKeys.Text = str_UpdatedKeys;
            lb_UploadedKeys.Text = str_UploadedKeys;

            NoProdType = false;
            NoKeyCat = false;

            GetStarted();
            firstLaunch = false;
        }

        /* Конструктор, вызываем в форме KeywordsAreExisted*/
        public SemCoreRebuildView()
        {
            InitializeComponent();
            connection = DBData.GetDBConnection();
            lb_UpdatedKeys.Text = str_UpdatedKeys;
            lb_UploadedKeys.Text = str_UploadedKeys;

            NoProdType = false;
            NoKeyCat = false;

            GetStarted();
            firstLaunch = false;
        }
        



        /* Выполняем в конструкторе */
        private void GetStarted()
        {
            ptController = new ProductTypesController(this);
            kcController = new KeywordCategoryController(this);
            scController = new SemCoreController(this);

            ptController.GetProductTypesAll();
            fill_cb_ProductTypes();
            kcController.GetKeywordCategoriesByProductId(GetProductTypeIdFromCB());
            fill_cb_KeywordCategory();
        }

        /* Метод загрузки нового файла */
        public void OpenNewFile()
        {
            bool isExcel = false;
            bool isCsv = false;

            openFileDialog1.Filter = "Неразмеченные файлы|*.csv;*.txt|Excel файлы (*.xlsx)|*.xlsx";
            openFileDialog1.Title = "Выбор файла для открытия";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                if (path.Contains(".xlsx"))
                    isExcel = true;
                else if (path.Contains(".csv"))
                    isCsv = true;

                dgv_Source.Rows.Clear();
                dgv_Target.Rows.Clear();

                if (isCsv)
                {
                    try
                    {
                        using (TextFieldParser parser = new TextFieldParser(@path))
                        {
                            parser.TextFieldType = FieldType.Delimited;
                            if (radioButton1.Checked)
                                parser.SetDelimiters(radioButton1.Text);
                            else if (radioButton2.Checked)
                                parser.SetDelimiters(radioButton2.Text);
                            else
                                parser.SetDelimiters(tb_OwnDelimiter.Text);

                            while (!parser.EndOfData)
                            {
                                //Process row
                                string[] fields = parser.ReadFields();

                                var index = dgv_Source.Rows.Add();
                                int i = 0;

                                foreach (string field in fields)
                                {
                                    if (i == 1)
                                        dgv_Source.Rows[index].Cells[i].Value = double.Parse(field);
                                    else
                                        dgv_Source.Rows[index].Cells[i].Value = field;
                                    i++;
                                }
                            }
                        }

                        label1.Visible = false;
                        dgv_Source.Visible = true;
                        dgv_Target.Visible = true;
                        btn_SelectAll.Visible = true;
                        btn_DeselectAll.Visible = true;
                        lb_UploadedKeys.Visible = true;
                        lb_UpdatedKeys.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                        dgv_Source.Rows.Clear();
                    }
                    
                    dgv_Source.Focus();
                }
                else if (isExcel)
                {
                    try
                    {
                        FileInfo existingFile = new FileInfo(@path);
                        using (ExcelPackage package = new ExcelPackage(existingFile))
                        {
                            //get the first worksheet in the workbook
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                            int colCount = worksheet.Dimension.End.Column;  //get Column Count
                            int rowCount = worksheet.Dimension.End.Row;     //get row count
                            for (int row = 1; row <= rowCount; row++)
                            {
                                var index = dgv_Source.Rows.Add();

                                for (int col = 1; col <= colCount; col++)
                                {
                                    if (col == 2)
                                        dgv_Source.Rows[index].Cells[col - 1].Value = double.Parse(worksheet.Cells[row, col].Value.ToString().Trim());
                                    else
                                        dgv_Source.Rows[index].Cells[col - 1].Value = worksheet.Cells[row, col].Value.ToString().Trim();
                                }
                            }
                        }

                        label1.Visible = false;
                        dgv_Source.Visible = true;
                        dgv_Target.Visible = true;
                        btn_SelectAll.Visible = true;
                        btn_DeselectAll.Visible = true;
                        lb_UploadedKeys.Visible = true;
                        lb_UpdatedKeys.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Проблема при открытии файла. Убедитесь, что Вы выбрали файл с нужны расширением. Возможно, разметка файла не поддерживается программой.", "Ошибка при открытии");
                        dgv_Source.Rows.Clear();
                    }
                    
                    dgv_Source.Focus();
                }
            }
        }

        private void tb_OwnDelimiter_TextChanged(object sender, EventArgs e)
        {
            if (tb_OwnDelimiter.Text.Length > 0)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            else
                radioButton1.Checked = true;
        }

        /* Загружаем новый файл */
        private void btn_UploadFile_Click(object sender, EventArgs e)
        {
            OpenNewFile();
        }

        /* Чтобы знать, была ли добавленна новая категория в btn_AddCategory_Click */
        public void NewCategoryWasAdded(bool _wasAdded)
        {
            NewCategorywasAdded = _wasAdded;
        }


        /* Выделяем/снимаем выделение с ключа по нажатию кнопки в dgv */
        private void dgv_Source_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                //Check
                dgv_Check((DataGridView)sender);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.X)
            {
                //Uncheck
                dgv_UnCheck((DataGridView)sender);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (dgv_Source.RowCount > 0)
                {
                    DataGridView send = (DataGridView)sender;
                    string str = dgv_Source.Rows[send.CurrentCellAddress.Y].Cells[send.CurrentCellAddress.X].Value.ToString();
                    System.Diagnostics.Process.Start(tb_Link.Text + dgv_Source.Rows[send.CurrentCellAddress.Y].Cells[send.CurrentCellAddress.X].Value.ToString());
                    e.Handled = true;
                }
            }
        }

        /* Помечаем ключ в таблице dgv_Source */
        private void dgv_Check(DataGridView sender)
        {
            if (sender.CurrentCellAddress.X == 0)
            {
                sender.Rows[sender.CurrentCellAddress.Y].Cells[sender.CurrentCellAddress.X].Style.ForeColor = Color.Red;
                Refresh_dgvTarget_Add();

                lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
            }
        }

        /* Снимает пометку ключа в таблице dgv_Source */
        private void dgv_UnCheck(DataGridView sender)
        {
            if (sender.CurrentCellAddress.X == 0)
            {
                sender.Rows[sender.CurrentCellAddress.Y].Cells[sender.CurrentCellAddress.X].Style.ForeColor = Color.Black;
                Refresh_dgvTarget_Del();
            }

            lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
        }

        /* Добавляем помеченный ключ в dgv_Target */
        private void Refresh_dgvTarget_Add()
        {
            bool flag = true;

            string str = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[dgv_Source.CurrentCellAddress.X].Value.ToString();
            for (int i = 0; i < dgv_Target.RowCount; i++)
            {
                if (dgv_Target.Rows[i].Cells[0].Value.ToString().Equals(str))
                {
                    flag = false;
                }
            }
            if (flag || dgv_Target.RowCount == 0)
            {
                var index = dgv_Target.Rows.Add();

                dgv_Target.Rows[index].Cells[0].Value = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[0].Value.ToString();
                dgv_Target.Rows[index].Cells[1].Value = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[1].Value.ToString();
            }
        }

        /* Удаляем ключ из dgv_Target при снятии его выделения в dgv_Source */
        private void Refresh_dgvTarget_Del()
        {
            string str = dgv_Source.Rows[dgv_Source.CurrentCellAddress.Y].Cells[dgv_Source.CurrentCellAddress.X].Value.ToString();
            for (int i = 0; i < dgv_Target.RowCount; i++)
            {
                if (dgv_Target.Rows[i].Cells[0].Value.ToString().Equals(str))
                {
                    dgv_Target.Rows.RemoveAt(i);
                }
            }
        }

        /* Закончить обрабатывание новых ключей */
        private void btn_KeysAreDone_Click(object sender, EventArgs e)
        {
            if (dgv_Target.RowCount > 0)
            {
                dgv_Source.Rows.Clear();

                for (int i = 0; i < dgv_Target.RowCount; i++)
                {
                    var index = dgv_Source.Rows.Add();
                    dgv_Source.Rows[index].Cells[0].Value = dgv_Target.Rows[i].Cells[0].Value;
                    dgv_Source.Rows[index].Cells[1].Value = dgv_Target.Rows[i].Cells[1].Value;
                }

                dgv_Target.Rows.Clear();

                lb_UploadedKeys.Text = str_UploadedKeys + " (" + dgv_Source.RowCount + ")";
                lb_UpdatedKeys.Text = str_UpdatedKeys;
            }
        }

        /* При переходе сюда с окна KeywordsAreExisted */
        private void SemCoreRebuild_VisibleChanged(object sender, EventArgs e)
        {
            SemCoreRefresh();                                                                                       //????????????????????????
        }

        /* Обновляемся после добавления категории */
        private void SemCoreRefresh()
        {
            if (NewCategorywasAdded)
            {
                kcController.GetKeywordCategoriesByProductId(GetProductTypeIdFromCB());
                fill_cb_KeywordCategory();

                NewCategorywasAdded = false;
                btn_Begin.Enabled = false;
            }
        }

        /* Закрытие окна */
        private void SemCoreRebuild_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Visible = true;
        }
        /* Получаем из контроллера KeywordCategories, полученные с БД */
        public void GetCategoriesFromDB(object _kcList)
        {
            kcList = (List<KeywordCategoryModel>)_kcList;
        }

        /* Получаем из контроллера ProductTypes, полученные с БД */
        public void GetProductTypesFromDB(object _ptList)
        {
            ptList = (List<ProductTypesModel>)_ptList;
        }

        /* Получаем из контроллера SemCore, полученные с БД */
        public void GetSemCoreFromDB(object _scList)
        {
            scList = (List<SemCoreModel>)_scList;
        }

        /* Получить ProductTypeId с CB */
        private int GetSelectedProductTypeId()
        {
            for (int i = 0; i < ptList.Count; i++)
            {
                if (ptList[i].TypeName.Equals(cb_ProductType.SelectedItem.ToString()))
                {
                    return ptList[i].ProductTypeId;
                }
            }
            return -1;
        }

        /* Получить CategoryId с CB */
        private int GetSelectedCategoryId()
        {
            for (int i = 0; i < kcList.Count; i++)
            {
                if (kcList[i].CategoryName.Equals(cb_KeywordCategory.SelectedItem.ToString()))
                {
                    return kcList[i].CategoryId;
                }
            }
            return -1;
        }

        //------------------------------------------------------------------------------------------------------

        /* Выделяем все ключи */
        private void btn_CheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Source.RowCount; i++)
            {
                dgv_Source.Rows[i].Cells[0].Style.ForeColor = Color.Red;

                bool flag = true;

                string str = dgv_Source.Rows[i].Cells[0].Value.ToString();
                for (int j = 0; j < dgv_Target.RowCount; j++)
                {
                    if (dgv_Target.Rows[j].Cells[0].Value.ToString().Equals(str))
                    {
                        flag = false;
                    }
                }
                if (flag || dgv_Target.RowCount == 0)
                {
                    var index = dgv_Target.Rows.Add();

                    dgv_Target.Rows[index].Cells[0].Value = dgv_Source.Rows[i].Cells[0].Value.ToString();
                    if (dgv_Source.Rows[i].Cells[1].Value != null)
                        dgv_Target.Rows[index].Cells[1].Value = dgv_Source.Rows[i].Cells[1].Value.ToString();
                }

            }
            if (dgv_Source.RowCount > 0)
                lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
        }

        /* Снимаем выделение всех ключей */
        private void btn_UnChekAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Source.RowCount; i++)
            {
                dgv_Source.Rows[i].Cells[0].Style.ForeColor = Color.Black;

                string str = dgv_Source.Rows[i].Cells[0].Value.ToString();
                for (int j = 0; j < dgv_Target.RowCount; j++)
                {
                    if (dgv_Target.Rows[j].Cells[0].Value.ToString().Equals(str))
                    {
                        dgv_Target.Rows.RemoveAt(j);
                    }
                }
            }

            if (dgv_Source.RowCount > 0)
                lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
        }

        /* Включаем/выключаем редактирование адреса по умолчанию на страницу Амазон с ключем */
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tb_Link.Enabled = true;
            }
            else
            {
                tb_Link.Enabled = false;
                //mf.AmazonLink = tb_Link.Text;
            }
        }

        /* Очищаем dgv и обновляем SemCore */
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            dgv_Source.Rows.Clear();
            dgv_Target.Rows.Clear();
            btn_Begin.Enabled = false;
            
            lb_UpdatedKeys.Text = str_UpdatedKeys;
            lb_UploadedKeys.Text = str_UploadedKeys;

            //GetKeywords();
        }

        /* Добавляем новую категорию */
        private void btn_AddCategory_Click(object sender, EventArgs e)
        {
            KeywordCategoryView keycat = new KeywordCategoryView(this);
            keycat.Show();
            this.Visible = false;
        }

        /* Проверяем, если dgv_Target не пустая, то выключаем кнопку для начала анализа */
        private void dgv_Target_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_Target.RowCount > 0)
            {
                btn_Begin.Enabled = false;
            }
            else
            {
                btn_Begin.Enabled = true;
            }
        }

        /* Проверяем, если dgv_Target не пустая, то выключаем кнопку для начала анализа */
        private void dgv_Target_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgv_Target.RowCount > 0)
            {
                btn_Begin.Enabled = false;
            }
            else
            {
                btn_Begin.Enabled = true;
            }
        }

        /* Проверяем, если dgv_Source не пустая, то выключаем кнопку для отметки ключей */
        private void dgv_Source_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgv_Source.RowCount > 0)
            {
                btn_KeysAreDone.Enabled = true;
            }
            else
            {
                btn_KeysAreDone.Enabled = false;
            }
        }

        /* Проверяем, если dgv_Source не пустая, то выключаем кнопку для отметки ключей */
        private void dgv_Source_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_Source.RowCount > 0)
            {
                btn_KeysAreDone.Enabled = true;
            }
            else
            {
                btn_KeysAreDone.Enabled = false;
            }
        }



















        /* Получаем ProductTypeId с cb_ProductType */
        private int GetProductTypeIdFromCB()
        {
            for (int i = 0; i < ptList.Count; i++)
            {
                if (ptList[i].TypeName.Equals(cb_ProductType.SelectedItem.ToString()))
                {
                    return ptList[i].ProductTypeId;
                }
            }
            return -1;
        }

        /* Получаем CategoryId с cb_KeywordCategory */
        private int GetKeywordCategoryIdFromCB()
        {
            for (int i = 0; i < kcList.Count; i++)
            {
                if (kcList[i].CategoryName.Equals(cb_KeywordCategory.SelectedItem.ToString()))
                {
                    return kcList[i].CategoryId;
                }
            }
            return -1;
        }

        /* Перезаполняем cb_KeywordCategory после смены вида товара */
        private void RefreshData()
        {
            kcController.GetKeywordCategoriesByProductId(GetProductTypeIdFromCB());
            fill_cb_KeywordCategory();
        }

        private void cb_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstLaunch)
                RefreshData();
        }

        /* Заполняем cb_ProductType */
        private void fill_cb_ProductTypes()
        {
            if (ptList.Count > 0)
            {
                cb_ProductType.Items.Clear();
                cb_KeywordCategory.Items.Clear();

                for (int i = 0; i < ptList.Count; i++)
                {
                    cb_ProductType.Items.Add(ptList[i].TypeName);
                }
                cb_ProductType.SelectedItem = cb_ProductType.Items[0];
            }
            else
            {
                MessageBox.Show("Видимо, в системе нет ни одного вида товара. Для работы в этом разделе, пожалуйста, сначала добавьте хотя бы один вид товара.", "Ошибка");
                NoProdType = true;
            }
        }

        /* Заполняем cb_KeywordCategory */
        private void fill_cb_KeywordCategory()
        {
            if (kcList.Count > 0)
            {
                cb_KeywordCategory.Items.Clear();

                for (int i = 0; i < kcList.Count; i++)
                {
                    cb_KeywordCategory.Items.Add(kcList[i].CategoryName);
                }
                if (kcList.Count > 0)
                    cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[0];
            }
            else
            {
                MessageBox.Show("Видимо, в системе нет ни одной категории ключей. Для работы в этом разделе, пожалуйста, сначала добавьте хотя бы одну категорию ключей.", "Ошибка");
                NoKeyCat = true;
            }
        }




        private void btn_Begin_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_Begin.Enabled)
            {
                btn_Begin.BackColor = Color.LightGray;
            }
            else
            {
                btn_Begin.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void btn_KeysAreDone_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_KeysAreDone.Enabled)
            {
                btn_KeysAreDone.BackColor = Color.LightGray;
            }
            else
            {
                btn_KeysAreDone.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }





















































































        //------------------------------------------------------------------------------------------------------------------------------------------

        /* Запуск основной логики */
        private void btn_Begin_Click(object sender, EventArgs e)
        {
            bool isExist = false;           //новый это ключ, или существует в БД, пусть и в другой категории
            scNewList = new List<SemCoreModel> { };
            scUpdateList = new List<SemCoreModel> { };
            List<SemCoreModel> scAddedList = new List<SemCoreModel> { };
            int newCnt = 0;

            if (MessageBox.Show("Вы уверены, что хотите начать процедуру сверки ключей?", "Начать", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                dgv_Target.Rows.Clear();

                this.Enabled = false;

                int val = 0;

                for (int i = 0; i < dgv_Source.RowCount; i++)
                {
                    scNewList.Add(new SemCoreModel());
                    scNewList[scNewList.Count - 1].Keyword = dgv_Source.Rows[i].Cells[0].Value.ToString();
                    try { val = int.Parse(dgv_Source.Rows[i].Cells[1].Value.ToString()); } catch (Exception exx) { val = 0; }           //это если вдруг ячейка с частотой будет пустая
                    scNewList[scNewList.Count - 1].Value = val;

                    if (scController.InsertNewKeyword(GetSelectedProductTypeId(), GetSelectedCategoryId(), scNewList[scNewList.Count - 1].Keyword, scNewList[scNewList.Count - 1].Value, DateTime.Now) != 1)
                    {
                        scUpdateList.Add(new SemCoreModel());
                        scUpdateList[scUpdateList.Count - 1].ProductTypeId = GetSelectedProductTypeId();
                        scUpdateList[scUpdateList.Count - 1].CategoryId = GetSelectedCategoryId();
                        scUpdateList[scUpdateList.Count - 1].Keyword = scNewList[scNewList.Count - 1].Keyword;
                        scUpdateList[scUpdateList.Count - 1].Value = scNewList[scNewList.Count - 1].Value;
                        scUpdateList[scUpdateList.Count - 1].LastUpdated = DateTime.Now;

                        isExist = true;
                    }
                    else
                    {
                        newCnt++;
                        scAddedList.Add(new SemCoreModel());
                        scAddedList[scAddedList.Count - 1].Keyword = scNewList[scNewList.Count - 1].Keyword;
                        scAddedList[scAddedList.Count - 1].Value = scNewList[scNewList.Count - 1].Value;
                    }
                }

                //обновляем существующие ключи
                if (isExist)
                    UpdateExistingKeywordsInDB(newCnt, scAddedList);
                else
                {
                    MessageBox.Show("Всего ключей было добавлено: " + newCnt + "\nКоличество обновленных ключей: 0", "Успех");
                    dgv_Source.Rows.Clear();
                    dgv_Target.Rows.Clear();
                    Fill_dgv_Source_ByAddedKeys(scAddedList);
                }

                label1.Visible = true;
                dgv_Source.Visible = false;
                dgv_Target.Visible = false;
                btn_SelectAll.Visible = false;
                btn_DeselectAll.Visible = false;
                lb_UploadedKeys.Visible = false;
                lb_UpdatedKeys.Visible = false;

                this.Enabled = true;
            }
        }

        /* Обновляем уже существующие ключи, которые лежат в dgv_Target */
        private void UpdateExistingKeywordsInDB(int _newKeysCount, List<SemCoreModel> _scAddedList)
        {
            bool error = false;     //признак того, что при обновлении ключей возникла ошибка(-и)
            int newKyesCount = _newKeysCount;
            int editedKeysCount = 0;
            int editedWrongKeysCount = 0;

            List<string[,]> errorKeys = new List<string[,]> { };          //список ключей, которые не были обновлены
            scExistingFromDBList = new List<SemCoreModel> { };
            IDataRecord dr;

            string wrongProdType = "";
            string wrongCategory = "";
            
            for (int i = 0; i < scUpdateList.Count; i++)
            {
                dr = scController.GetSemCoreByKeyword(scUpdateList[i].Keyword);

                if (dr != null)
                {
                    scExistingFromDBList.Add(new SemCoreModel());

                    scExistingFromDBList[scExistingFromDBList.Count - 1].ProductTypeId = int.Parse(dr[0].ToString());
                    scExistingFromDBList[scExistingFromDBList.Count - 1].CategoryId = int.Parse(dr[1].ToString());
                    scExistingFromDBList[scExistingFromDBList.Count - 1].Keyword = dr[2].ToString();
                    scExistingFromDBList[scExistingFromDBList.Count - 1].Value = scUpdateList[i].Value;
                    scExistingFromDBList[scExistingFromDBList.Count - 1].LastUpdated = scUpdateList[i].LastUpdated;
                    scExistingFromDBList[scExistingFromDBList.Count - 1].SemCoreId = int.Parse(dr[5].ToString());
                }
            }



            for (int i = 0; i < scExistingFromDBList.Count; i++)
            {
                if (scController.UpdateExistingKeywordBySemCoreId(scExistingFromDBList[i].ProductTypeId, scExistingFromDBList[i].CategoryId, scExistingFromDBList[i].Keyword, scExistingFromDBList[i].Value, DateTime.Now, scExistingFromDBList[i].SemCoreId) != 1)
                {
                    //some error
                }
                else
                {
                    editedKeysCount++;
                    if (scExistingFromDBList[i].ProductTypeId != GetSelectedProductTypeId())
                    {
                        wrongProdType += scExistingFromDBList[i].Keyword + "\n";
                        error = true;
                        editedWrongKeysCount++;
                        errorKeys.Add(new string[1, 2]);
                        errorKeys[errorKeys.Count - 1].SetValue(scExistingFromDBList[i].Keyword, 0, 0);
                        errorKeys[errorKeys.Count - 1].SetValue(scExistingFromDBList[i].Value.ToString(), 0, 1);
                    }
                    else if (scExistingFromDBList[i].CategoryId != GetSelectedCategoryId())
                    {
                        wrongCategory += scExistingFromDBList[i].Keyword + "\n";
                        error = true;
                        editedWrongKeysCount++;
                        errorKeys.Add(new string[1, 2]);
                        errorKeys[errorKeys.Count - 1].SetValue(scExistingFromDBList[i].Keyword, 0, 0);
                        errorKeys[errorKeys.Count - 1].SetValue(scExistingFromDBList[i].Value.ToString(), 0, 1);
                    }
                }                  
            }

            if (error)
            {
                MessageBox.Show("Добавлено новых ключей: " + newKyesCount + "\nОбновлено ключей: " + editedKeysCount + "\nИз них - " + editedWrongKeysCount + " - находятся не в заданной категории ключей/виде товаров. Эти ключи были помещены в таблицу \"Обновленные ключи\"");
                dgv_Source.Rows.Clear();
                dgv_Target.Rows.Clear();
                Fill_dgv_Source_ByExistingKeys(errorKeys);
                Fill_dgv_Source_ByAddedKeys(_scAddedList);
            }
            else
            {
                MessageBox.Show("Добавлено новых ключей: " + newKyesCount + "\nОбновлено ключей: " + editedKeysCount);
                dgv_Source.Rows.Clear();
                dgv_Target.Rows.Clear();
                Fill_dgv_Source_ByExistingKeys(errorKeys);
                Fill_dgv_Source_ByAddedKeys(_scAddedList);
            }
        }
        
        /* Заполняем dgv_Source ключами, которые не удалось обновить, т.к. они уже есть в БД */
        private void Fill_dgv_Source_ByExistingKeys(List<string[,]> _arr)
        {
            for (int i = 0; i < _arr.Count; i++)
            {
                var index = dgv_Target.Rows.Add();

                dgv_Target.Rows[index].Cells[0].Value = _arr[i].GetValue(0, 0);
                dgv_Target.Rows[index].Cells[1].Value = _arr[i].GetValue(0, 1);
            }
        }

        /* Заполняем dgv_Source ключами, которые не удалось обновить, т.к. они уже есть в БД */
        private void Fill_dgv_Source_ByAddedKeys(List<SemCoreModel> _arr)
        {
            for (int i = 0; i < _arr.Count; i++)
            {
                var index = dgv_Source.Rows.Add();

                dgv_Source.Rows[index].Cells[0].Value = _arr[i].Keyword;
                dgv_Source.Rows[index].Cells[1].Value = _arr[i].Value;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

            
        /* Получили список ключей после их ручного изменения в KeywordsAreExisted */
        public void GetKeywordsFromKeywordsAreExisted(string[,] _arr)
        {
            myArr = _arr;
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для начала откройте файл с ключевыми словами при помощи кнопки \"Загрузить файл\".\n\nИспользуйте клавишу \"C\" для выделения ключевого слова.\nИспользуйте клавишу \"X\" для снятия выделения ключевого слова.\n\nДважды клацните ЛКМ по ключевому слову, чтобы просмотреть его на Amazon.", "Помощь");
        }

        private void dgv_Source_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                System.Diagnostics.Process.Start(tb_Link.Text + dgv_Source.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void dgv_Target_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                System.Diagnostics.Process.Start(tb_Link.Text + dgv_Target.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }
    }
}








///* Обновляем оба CB и ключи по ним */
//private void Refresh_CB_AndKeywords()
//{
//    kcController.GetKeywordCategoriesAll();
//    ptController.GetProductTypesAll();

//    Fill_CB_ByKeywordCategories();
//    Fill_CB_ByProductTypes();

//    GetKeywords();
//}

///* Загружем все ключи с SemCore */
//private void GetKeywords()
//{
//    scList = null;
//    scController.GetSemCoreByProductAndCategoryId(GetSelectedProductTypeId(), GetSelectedCategoryId());

//    dgv_KeywordsInCategory.Rows.Clear();

//    if (scList != null)
//    {
//        for (int i = 0; i < scList.Count; i++)
//        {
//            var index = dgv_KeywordsInCategory.Rows.Add();

//            dgv_KeywordsInCategory.Rows[index].Cells[0].Value = scList[i].ReadData(2);
//            dgv_KeywordsInCategory.Rows[index].Cells[1].Value = scList[i].ReadData(3);
//            dgv_KeywordsInCategory.Rows[index].Cells[2].Value = scList[i].ReadData(4);

//        }
//    }
//}

///* Заполняем cb_ProductType данными с ptList */
//private void Fill_CB_ByProductTypes()
//{
//    cb_ProductType.Items.Clear();
//    for (int i = 0; i < ptList.Count; i++)
//    {
//        cb_ProductType.Items.Add(ptList[i].TypeName);
//    }
//    cb_ProductType.SelectedItem = cb_ProductType.Items[0];
//}

///* Заполняем cb_KeywordCategory данными с kcList */
//private void Fill_CB_ByKeywordCategories()
//{
//    cb_KeywordCategory.Items.Clear();
//    for (int i = 0; i < kcList.Count; i++)
//    {
//        cb_KeywordCategory.Items.Add(kcList[i].CategoryName);
//    }
//    cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[0];
//}

///* Очищаем все таблицы */
//private void RefreshDGVs()
//{
//    dgv_Source.Rows.Clear();
//    dgv_Target.Rows.Clear();
//    dgv_NewKeys.Rows.Clear();
//}












//private void btn_Begin_Click(object sender, EventArgs e)
//{
//    bool isExist;           //новый это ключ, или существует в БД, пусть и в другой категории

//    if (MessageBox.Show("Вы уверены, что хотите начать процедуру сверки ключей?", "Начать", MessageBoxButtons.OKCancel) == DialogResult.OK)
//    {
//        dgv_Target.Rows.Clear();
//        dgv_NewKeys.Rows.Clear();

//        this.Enabled = false;

//        for (int i = 0; i < dgv_Source.RowCount; i++)
//        {
//            isExist = false;

//            for (int j = 0; j < scList.Count; j++)
//            {
//                if (dgv_Source.Rows[i].Cells[0].Value.ToString().Equals(scList[j].Keyword))
//                {
//                    //пишем в dgv_Target
//                    var index = dgv_Target.Rows.Add();

//                    for (int k = 0; k < scList[j].ColumnCount; k++)
//                    {
//                        dgv_Target.Rows[index].Cells[k].Value = scList[j].ReadData(k);
//                    }
//                    dgv_Target.Rows[index].Cells[3].Value = dgv_Source.Rows[i].Cells[1].Value;              //обновляем частоту

//                    isExist = true;
//                }
//            }

//            if (!isExist)        //если ключа нет в выбранной категории, считае его новым
//            {
//                //пишем в dgv_NewKeys
//                var index = dgv_NewKeys.Rows.Add();

//                dgv_NewKeys.Rows[index].Cells[0].Value = GetSelectedProductTypeId();
//                dgv_NewKeys.Rows[index].Cells[1].Value = GetSelectedCategoryId();
//                dgv_NewKeys.Rows[index].Cells[2].Value = dgv_Source.Rows[i].Cells[0].Value;
//                dgv_NewKeys.Rows[index].Cells[3].Value = dgv_Source.Rows[i].Cells[1].Value;
//                dgv_NewKeys.Rows[index].Cells[4].Value = DateTime.Now;

//            }
//        }

//        //обновляем существующие ключи
//        UpdateExistingKeywordsInDB();

//        this.Enabled = true;
//    }
//}







//private void UpdateExistingKeywordsInDB()
//{
//    bool error = false;     //признак того, что при обновлении ключей возникла ошибка(-и)
//    List<string> errorKeys = new List<string> { };          //список ключей, которые не были обновлены

//    progressBar1.Maximum = dgv_NewKeys.RowCount + dgv_Target.RowCount;
//    progressBar1.Visible = true;

//    for (int i = 0; i < dgv_Target.RowCount; i++)
//    {
//        if (scController.UpdateExistingKeywordBySemCoreId(int.Parse(dgv_Target.Rows[i].Cells[0].Value.ToString()), int.Parse(dgv_Target.Rows[i].Cells[1].Value.ToString()), dgv_Target.Rows[i].Cells[2].Value.ToString(), int.Parse(dgv_Target.Rows[i].Cells[3].Value.ToString()), DateTime.Now, int.Parse(dgv_Target.Rows[i].Cells[5].Value.ToString())) == 1)
//        {
//            //progressBar1.Value++;
//        }
//        else
//        {
//            error = true;
//            errorKeys.Add(dgv_Target.Rows[i].Cells[2].Value.ToString());
//        }
//    }

//    if (error)
//    {
//        string tmp = "\n";
//        for (int k = 0; k < errorKeys.Count; k++)
//        {
//            tmp += errorKeys[k] + "\n";
//        }
//        MessageBox.Show("Возникла какая-то ошибка и не все ключи были обновлены. Ниже приведены не обновленные ключи:" + tmp, "Ошибка");
//    }

//    //теперь записываем "новые" ключи
//    CreateNewKeywordsInDB();
//}

///* Добавляем новые ключи в БД (ключи, которых нет в выбранной категории) */
//private void CreateNewKeywordsInDB()
//{
//    bool error = false;         //признак ошибки при записи нового ключа в БД; значит, такой ключ уже есть
//    int j = 0;
//    string[,] _alreadyExistedKeywords = new string[dgv_NewKeys.RowCount, 2];       //ключи, которые уже есть в БД, но в другой категории
//    List<int> forDeleting = new List<int> { };

//    for (int i = 0; i < dgv_NewKeys.RowCount; i++)
//    {
//        if (scController.InsertNewKeyword(int.Parse(dgv_NewKeys.Rows[i].Cells[0].Value.ToString()), int.Parse(dgv_NewKeys.Rows[i].Cells[1].Value.ToString()), dgv_NewKeys.Rows[i].Cells[2].Value.ToString(), int.Parse(dgv_NewKeys.Rows[i].Cells[3].Value.ToString()), DateTime.Now) == 1)
//        {
//            //progressBar1.Value++; 
//        }
//        else
//        {
//            _alreadyExistedKeywords[j, 0] = dgv_NewKeys.Rows[i].Cells[2].Value.ToString();
//            _alreadyExistedKeywords[j, 1] = dgv_NewKeys.Rows[i].Cells[3].Value.ToString();
//            j++;
//            error = true;
//            forDeleting.Add(i);
//            //progressBar1.Value++;
//        }
//    }

//    //удаляем ключи из dgv_NewKeys, т.к. они не новые, а просто есть в другой категории
//    for (int i = forDeleting.Count - 1; i >= 0; i--)
//    {
//        dgv_NewKeys.Rows.RemoveAt(forDeleting[i]);
//    }

//    lb_NewKeys.Text = str_NewKeys + " (" + dgv_NewKeys.RowCount + ")";
//    lb_UpdatedKeys.Text = str_UpdatedKeys + " (" + dgv_Target.RowCount + ")";
//    lb_UploadedKeys.Text = str_UploadedKeys + " (" + dgv_Source.RowCount + ")";

//    if (error)
//    {
//        if (MessageBox.Show("Некоторые ключи не были обновлены, т.к. они принадлежат другой категории. Обновить их всё равно? Если нет, автоматически откроется окно для редактирования всех необновленных ключей.", "Внимание", MessageBoxButtons.OKCancel) == DialogResult.OK)
//        {
//            //все равно обновляем эти ключи
//            for (int i = 0; i < _alreadyExistedKeywords.Length / 2; i++)
//            {
//                scController.UpdateExistingKeywordByKeyword(int.Parse(GetSelectedProductTypeId().ToString()), int.Parse(GetSelectedCategoryId().ToString()), _alreadyExistedKeywords[i, 0], int.Parse(_alreadyExistedKeywords[i, 1]), DateTime.Now);
//            }
//        }
//        else
//        {
//            //редактируем эти ключи, а потом передаем обратно сюда
//            KeywordsAreExistedView kae = new KeywordsAreExistedView(_alreadyExistedKeywords, cb_KeywordCategory.SelectedItem.ToString());
//            if (kae.ShowDialog() == DialogResult.OK)
//            {
//                Fill_dgv_Source_ByExistingKeys(_alreadyExistedKeywords);
//            }
//            dgv_NewKeys.ScrollBars = ScrollBars.Both;
//            progressBar1.Visible = false;
//            progressBar1.Value = 0;
//        }
//    }
//    else
//    {
//        MessageBox.Show("Все данные были обновлены успешно.", "Успех");
//        dgv_NewKeys.ScrollBars = ScrollBars.Both;
//        progressBar1.Visible = false;
//        progressBar1.Value = 0;
//    }
//}
