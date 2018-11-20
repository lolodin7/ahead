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
    public partial class FullSemCoreView : Form
    {
        private KeywordsAreExistedView ControlFormKeywordsAreExisted;
        private MainFormView ControlFormMF;
        private FullSemCoreView ControlFullSemCoreView;

        private FullSemCoreController fscController;
        private List<FullSemCoreModel> fscList;

        private KeywordCategoryController kcController;
        private List<KeywordCategoryModel> kcList;

        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;

        private string AllProductTypesCBName = "Все виды товаров";
        private string AllKeywordCategoriesCBName = "Все категории ключей";
        
        
        /* Вызываем из KeywordsAreExisted для редактирования ключей из таблицы */
        public FullSemCoreView(KeywordsAreExistedView _form, string[,] arr)
        {
            InitializeComponent();
            ControlFormKeywordsAreExisted = _form;

            GetStarted();
        }

        /* Вызываем из главной формы */
        public FullSemCoreView(MainFormView _mf)
        {
            InitializeComponent();
            ControlFormMF = _mf;

            GetStarted();
        }

        /* Пустой конструктор */
        public FullSemCoreView()
        {
            InitializeComponent();

            GetStarted();
        }

        /* Выполняем в конструкторе */
        private void GetStarted()
        {
            ptController = new ProductTypesController(this);
            kcController = new KeywordCategoryController(this);
            fscController = new FullSemCoreController(this);

            fscController.GetSemCoreAll();
            ptController.GetProductTypesAll();
            kcController.GetKeywordCategoriesAll();
            DrawKeywords();
            FillCB();
        }

        /* Перерисовываем таблицу новыми данными после изменения категории или вида продукта */
        private void ReDrawKeywords()
        {
            dgv_Keywords.Rows.Clear();
            DrawKeywords();
        }

        /* Перерисовываем таблицу новыми данными SemCore */
        private void DrawKeywords()
        {
            dgv_Keywords.Rows.Clear();

            for (int i = 0; i < fscList.Count; i++)
            {
                var index = dgv_Keywords.Rows.Add();

                for (int j = 0; j < fscList[0].ColumnCount; j++)
                {
                    dgv_Keywords.Rows[index].Cells[j].Value = fscList[i].ReadData(j);
                }
            }
        }

        /* Получаем ключи из БД */
        public void GetKeywordsFromDB(object _fscList)
        {
            fscList = (List<FullSemCoreModel>)_fscList;
        }

        /* Получаем ProducTypes из БД */
        public void GetProductTypesFromDB(object _ptList)
        {
            ptList = (List<ProductTypesModel>)_ptList;
        }

        /* Получаем KeywordCategories из БД */
        public void GetCategoriesFromDB(object _kcList)
        {
            kcList = (List<KeywordCategoryModel>)_kcList;
        }

        /* Заполняем cb_KeywordCategory и cb_ProductType */
        private void FillCB()
        {
            cb_KeywordCategory.Items.Clear();
            cb_ProductType.Items.Clear();
            cb_KeywordCategory.Items.Add(AllKeywordCategoriesCBName);
            cb_ProductType.Items.Add(AllProductTypesCBName);

            for (int i = 0; i < kcList.Count; i++)
            {
                cb_KeywordCategory.Items.Add(kcList[i].CategoryName);
            }
            cb_KeywordCategory.SelectedItem = cb_KeywordCategory.Items[0];

            for (int i = 0; i < ptList.Count; i++)
            {
                cb_ProductType.Items.Add(ptList[i].TypeName);
            }
            cb_ProductType.SelectedItem = cb_ProductType.Items[0];
        }


        /* Получаем набор ключей по категории и виду товара после нажатия кнопки */
        private void btn_GetKeywords_Click(object sender, EventArgs e)
        {
            if (!cb_ProductType.SelectedItem.ToString().Equals(AllProductTypesCBName) && cb_KeywordCategory.SelectedItem.ToString().Equals(AllKeywordCategoriesCBName))
            {
                fscController.GetSemCoreByProductId(GetSelectedProductTypeId());
                ReDrawKeywords();
            }
            else if (cb_ProductType.SelectedItem.ToString().Equals(AllProductTypesCBName) && !cb_KeywordCategory.SelectedItem.ToString().Equals(AllKeywordCategoriesCBName))
            {
                fscController.GetSemCoreByCategoryId(GetSelectedCategoryId());
                ReDrawKeywords();
            }
            else if (!cb_ProductType.SelectedItem.ToString().Equals(AllProductTypesCBName) && !cb_KeywordCategory.SelectedItem.ToString().Equals(AllKeywordCategoriesCBName))
            {
                fscController.GetSemCoreByProductAndCategory(GetSelectedProductTypeId(), GetSelectedCategoryId());
                ReDrawKeywords();
            }
            else if (cb_ProductType.SelectedItem.ToString().Equals(AllProductTypesCBName) && cb_KeywordCategory.SelectedItem.ToString().Equals(AllKeywordCategoriesCBName))
            {
                fscController.GetSemCoreAll();
                ReDrawKeywords();
            }
        }

        /* Получаем значение productTypeId по выбранному названию в cb_ProductType */
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

        /* Получаем значение keywordCategoryId по выбранному названию в cb_KeywordCategory */
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

        private void FullSemCore_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            //ControlFormKeywordsAreExisted.Visible = true;
        }        
    }
}
