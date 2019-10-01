using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class LoggerAdd : Form
    {
        private LoggerView loggerViewControl;

        private ProductsController pController;
        private List<ProductsModel> pList;

        private MarketplaceController mpController;
        private List<MarketplaceModel> mpList;

        private LoggerController logController;
        private List<LoggerModel> logList;

        private DateTime creationDate;

        private UserModel uList;

        private List<string> uniqueProductNames;
        private List<string> imageNamesForSave;
        List<PictureBox> pbList;
        List<string[]> pbNamesWithImagenames = new List<string[]> { };
        private List<LoggerAddAsinSkuPairs> asinSkuPairs;

        public LoggerAdd(LoggerView _mf, UserModel _um)
        {
            InitializeComponent();
            loggerViewControl = _mf;

            creationDate = DateTime.Now;

            uList = _um;

            pList = new List<ProductsModel> { };
            mpList = new List<MarketplaceModel> { };
            logList = new List<LoggerModel> { };
            uniqueProductNames = new List<string> { };
            imageNamesForSave = new List<string> { };
            asinSkuPairs = new List<LoggerAddAsinSkuPairs> { };

            pController = new ProductsController(this);
            mpController = new MarketplaceController(this);
            logController = new LoggerController(this);

            lb_creationDate.Text = creationDate.ToString().Substring(0, 10);
            lb_CreationUserName.Text = uList.Name;


            mpController.GetMarketplaces();

            pController.GetProductsAllJOIN();
            pList = pList.Distinct().ToList<ProductsModel>();
            Fill_CB_ByProducts();



            pbList = new List<PictureBox> { };
            pbList.Add(pictureBox1);
            pbList.Add(pictureBox2);
            pbList.Add(pictureBox3);
            pbList.Add(pictureBox4);
            pbList.Add(pictureBox5);
            pbList.Add(pictureBox6);
            pbList.Add(pictureBox7);
            pbList.Add(pictureBox8);
            pbList.Add(pictureBox9);
            pbList.Add(pictureBox10);
        }


        /* Заполняем cb_Products данными с pList */
        private void Fill_CB_ByProducts()
        {
            if (pList.Count > 0)
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    if (!uniqueProductNames.Contains(pList[i].Name))
                        uniqueProductNames.Add(pList[i].Name);
                }

                cb_Products.Items.Clear();
                cb_Products.Items.Add("Пометка");

                for (int i = 0; i < uniqueProductNames.Count; i++)
                {
                    cb_Products.Items.Add(uniqueProductNames[i]);
                }
                cb_Products.SelectedItem = cb_Products.Items[0];
            }
            else
            {
                MessageBox.Show("Видимо, в системе нет ни одного товара. Для работы в этом разделе, пожалуйста, сначала добавьте хотя бы один товар.", "Ошибка");
            }

            Fill_CB_BySKU();
        }

        private void Fill_CB_BySKU()
        {
            if (cb_Products.SelectedIndex == 0)
            {
                cb_SKU.Items.Clear();
                cb_SKU.Enabled = false;
            }
            else
            {
                cb_SKU.Enabled = true;
                cb_SKU.Items.Clear();

                List<string> skuList = new List<string> { };

                for (int i = 0; i < pList.Count; i++)
                {
                    if (pList[i].Name.Equals(cb_Products.SelectedItem.ToString()))
                        skuList.Add(pList[i].SKU);
                }

                if (skuList.Count > 1)
                {
                    cb_SKU.Items.Add("Все");
                    for (int i = 0; i < skuList.Count; i++)
                    {
                        cb_SKU.Items.Add(skuList[i]);
                    }
                }
                else
                    cb_SKU.Items.Add(skuList[0]);

                cb_SKU.SelectedItem = cb_SKU.Items[0];
            }
        }


        private void CheckForCorrectMarketplace(string _var)
        {
            if (cb_Products.SelectedIndex == 0)
            {
                lb_MarketPlace.Text = "Отсутствует";
            }
            else
            {
                switch (_var)
                {
                    case "sku":
                        for (int i = 0; i < pList.Count; i++)
                        {
                            if (cb_SKU.SelectedItem.ToString().Equals(pList[i].SKU))
                            {
                                lb_MarketPlace.Text = GetProductMarketPlaceNameById(pList[i].MarketPlaceId); //GetProductMarketPlaceNameByIdAndSKU(pList[i].MarketPlaceId, pList[i].SKU);
                            }
                        }
                        break;
                    case "prodName":
                        for (int i = 0; i < pList.Count; i++)
                        {
                            if (cb_Products.SelectedItem.ToString().Equals(pList[i].Name))
                            {
                                lb_MarketPlace.Text = GetProductMarketPlaceNameById(pList[i].MarketPlaceId);
                                break;
                            }
                        }
                        break;
                }
            }
        }




        private void Cb_Products_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cb_SKU_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private string GetProductNameById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].Name;
            }
            return "";
        }

        private int GetProductIdByName(string _productName)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].Name.Equals(_productName))
                    return pList[i].ProductId;
            }
            return -1;
        }

        private int GetProductIdByASIN(string _asin)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ASIN.Equals(_asin))
                    return pList[i].ProductId;
            }
            return -1;
        }

        private int GetProductIdBySKU(string _sku)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].SKU.Equals(_sku))
                    return pList[i].ProductId;
            }
            return -1;
        }

        private string GetProductAsinById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].ASIN;
            }
            return "";
        }

        private string GetProductSkuById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].SKU;
            }
            return "";
        }

        private string GetProductMarketPlaceNameById(int _marketPlaceId)
        {
            for (int i = 0; i < mpList.Count; i++)
            {
                if (mpList[i].MarketPlaceId == _marketPlaceId)
                    return mpList[i].MarketPlaceName;
            }
            return "";
        }

        private string GetProductMarketPlaceNameByIdAndSKU(int _productId, string _sku)
        {
            int marketPlaceId = -1;
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId && pList[i].SKU.Equals(_sku))
                    marketPlaceId = pList[i].MarketPlaceId;
            }
            if (marketPlaceId != -1)
            {
                for (int i = 0; i < mpList.Count; i++)
                {
                    if (mpList[i].MarketPlaceId == marketPlaceId)
                        return mpList[i].MarketPlaceName;
                }
            }
            return "";
        }







        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cb_Products_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Fill_CB_BySKU();
            CheckForCorrectMarketplace("prodName");
        }

        private void Cb_SKU_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CheckForCorrectMarketplace("sku");
        }

        private void Btn_AttachImages_Click(object sender, EventArgs e)
        {
            foreach (var pbox in pbList)
            {
                pbox.Visible = false;
            }
            string[] FileNames;
            openFileDialog1.Filter = "Все (*.PNG; *.JPG; *.JPEG; *.BMP)| *.PNG; *.JPG; *.JPEG; *.BMP";
            openFileDialog1.FileName = "";
            imageNamesForSave = new List<string> { };


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileNames = openFileDialog1.FileNames;

                if (FileNames.Length > 0 && FileNames.Length <= 10)
                {
                    for (int i = 0; i < FileNames.Length; i++)
                    {
                        imageNamesForSave.Add(FileNames[i]);
                    }

                    DrawMiniImages();
                } 
                else if (FileNames.Length > 10)
                {
                    MessageBox.Show("К одной записи можно прикрепить не более 10 изображений", "Ошибка");
                }

            }
        }


        private void DrawMiniImages()
        {
            pbNamesWithImagenames = new List<string[]> { };
            string[] tmpStringArr = new string[2];

            foreach (var pbox in pbList)
            {
                pbox.Image = null;
                //pbox.Visible = false;
            }
            if (imageNamesForSave.Count >= 1 && imageNamesForSave.Count <= 4)
            {
                label9.Visible = true;
                label11.Visible = false;
                label4.Visible = false;
            }
            else if (imageNamesForSave.Count >= 5 && imageNamesForSave.Count <= 8)
            {
                label9.Visible = false;
                label11.Visible = true;
                label4.Visible = false;
            }
            else if (imageNamesForSave.Count == 9 || imageNamesForSave.Count == 10)
            {
                label9.Visible = false;
                label11.Visible = false;
                label4.Visible = true;
            }

            for (int i = 0; i < imageNamesForSave.Count; i++)
            {
                tmpStringArr = new string[2];

                using (var file = new FileStream(imageNamesForSave[i], FileMode.Open, FileAccess.Read, FileShare.Inheritable))
                {
                    pbList[i].Image = Image.FromStream(file);
                }

                pbList[i].Visible = true;
                tmpStringArr[0] = pbList[i].Name;
                tmpStringArr[1] = imageNamesForSave[i];
                pbNamesWithImagenames.Add(tmpStringArr);
            }


            for (int i = 9; i >= imageNamesForSave.Count; i--)
            {
                pbList[i].Visible = false;
            }

        }



        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                if (imageNamesForSave.Count > 0)
                {
                    int imgResult = 1;
                    List<int> savedImageIds = new List<int> { };

                    for (int i = 0; i < imageNamesForSave.Count; i++)
                    {
                        try
                        {
                            savedImageIds.Add(logController.InsertImagesInDB(imageNamesForSave[i]));
                        }
                        catch (Exception ex) { imgResult = -1; MessageBox.Show("Произошла ошибка при сохранении изображений", "Ошибка"); }
                    }

                    string imageResultString = "";
                    for (int i = 0; i < savedImageIds.Count; i++)
                    {
                        imageResultString = imageResultString + savedImageIds[i] + "|";
                    }

                    List<int> result = new List<int> { };

                    if (imgResult == 1)
                    {
                        if (cb_Products.SelectedIndex == 0)
                        {
                            result.Add(logController.InserRecordIntoDB(creationDate, uList.UserId, 0, richTextBox1.Text, creationDate, uList.UserId, imageResultString, "Товары отсутствуют"));
                        }
                        else
                        {
                            FormAsinSkuPair();
                            FillAsinAndSkusInfo();

                            int prodId = GetProductIdByName(cb_Products.SelectedItem.ToString());
                            for (int i = 0; i < asinSkuPairs.Count; i++)
                            {
                                //result.Add(logController.InserRecordIntoDB(creationDate, uList.UserId, prodId, richTextBox1.Text, creationDate, uList.UserId, imageResultString, GetProductSkuById(prodId)));
                                for (int j = 0; j < asinSkuPairs[i].skuList.Count; j++)
                                {
                                    result.Add(logController.InserRecordIntoDB(creationDate, uList.UserId, asinSkuPairs[i].productId, richTextBox1.Text, creationDate, uList.UserId, imageResultString, asinSkuPairs[i].skuList[j]));
                                }
                            }
                        }

                        bool success = true;

                        foreach (var t in result)
                        {
                            if (t != 1)
                                success = false;
                        }

                        if (success)
                            MessageBox.Show("Новая запись сохранена успешно", "Успех");
                        else
                            MessageBox.Show("При сохранении записи произошел сбой", "Провал");
                    }
                }
                else
                {
                    List<int> result = new List<int> { };

                    if (cb_Products.SelectedIndex == 0)
                    {
                        result.Add(logController.InserRecordIntoDB(creationDate, uList.UserId, 0, richTextBox1.Text, creationDate, uList.UserId, "", "Товары отсутствуют"));
                    }
                    else
                    {
                        FormAsinSkuPair();
                        FillAsinAndSkusInfo();

                        int prodId = GetProductIdByName(cb_Products.SelectedItem.ToString());
                        for (int i = 0; i < asinSkuPairs.Count; i++)
                        {
                            for (int j = 0; j < asinSkuPairs[i].skuList.Count; j++)
                            {
                                result.Add(logController.InserRecordIntoDB(creationDate, uList.UserId, asinSkuPairs[i].productId, richTextBox1.Text, creationDate, uList.UserId, "", asinSkuPairs[i].skuList[j]));
                            }
                        }
                    }

                    bool success = true;

                    foreach (var t in result)
                    {
                        if (t != 1)
                            success = false;
                    }

                    if (success)
                        MessageBox.Show("Новая запись сохранена успешно", "Успех");
                    else
                        MessageBox.Show("При сохранении записи произошел сбой", "Провал");
                }
            }
            else { MessageBox.Show("Введите текст записи. Поле с текстом не должно быть пустым. Даешь информативность!", "Ошибка"); }
        }

        private void LoggerAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            loggerViewControl.Show();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            for (int i = 0; i < pbNamesWithImagenames.Count; i++)
            {
                if (pb.Name.Equals(pbNamesWithImagenames[i].GetValue(0).ToString()))
                {
                    imageNamesForSave.Remove(pbNamesWithImagenames[i].GetValue(1).ToString());
                }
            }
            DrawMiniImages();
        }

        private void Btn_AddAsinSkuPair_Click(object sender, EventArgs e)
        {
            if (cb_Products.SelectedIndex != 0)
            {
                FormAsinSkuPair();
                FillAsinAndSkusInfo();
            }
        }

        private void FormAsinSkuPair()
        {
            LoggerAddAsinSkuPairs asp = new LoggerAddAsinSkuPairs();
            asinSkuPairs.Add(asp);

            int prodId = GetProductIdByName(cb_Products.SelectedItem.ToString());

            asinSkuPairs[asinSkuPairs.Count - 1].ASIN = GetProductAsinById(prodId);
            asinSkuPairs[asinSkuPairs.Count - 1].productId = prodId;
            if (cb_Products.SelectedIndex != 0)
            {
                if (cb_SKU.SelectedIndex == 0)
                {
                    if (cb_SKU.SelectedItem.Equals("Все"))
                    {
                        for (int i = 1; i < cb_SKU.Items.Count; i++)
                        {
                            asinSkuPairs[asinSkuPairs.Count - 1].skuList.Add(cb_SKU.Items[i].ToString());
                        }
                    }
                    else
                    {
                        asinSkuPairs[asinSkuPairs.Count - 1].skuList.Add(cb_SKU.SelectedItem.ToString());
                    }
                }
                else
                {
                    asinSkuPairs[asinSkuPairs.Count - 1].skuList.Add(cb_SKU.SelectedItem.ToString());
                }
            }
        }

        private void FillAsinAndSkusInfo()
        {
            lb_asins.Text = "";
            lb_skus.Text = "";

            for (int i = 0; i < asinSkuPairs.Count; i++)
            {
                lb_asins.Text = lb_asins.Text + asinSkuPairs[i].ASIN + ";\n";
                for (int j = 0; j < asinSkuPairs[i].skuList.Count; j++)
                {
                    lb_skus.Text = lb_skus.Text + asinSkuPairs[i].skuList[j] + ";\n";
                }
                //lb_skus.Text = lb_skus.Text + ";";
            }
        }
    }
}
