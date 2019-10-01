using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class LoggerShow : Form
    {
        private LoggerView loggerViewControl;
        private LoggerModel logModel;

        private LoggerController logController;
        private List<LoggerModel> logList;

        private List<ImageModel> imageList;

        private string userName;
        private string marketplaceName;
        private string productName;
        private string ASIN;
        private string SKU;
        private string editUserName;
        private int appUserId;

        private UserModel userModel;

        private bool editMode;

        private static readonly ImageConverter _imageConverter = new ImageConverter();
        private SqlConnection connection;

        /* Открываем на редактирование */
        public LoggerShow(LoggerView _lv, object _lm, string _userName, string _pName, string _asin, string _sku, string _mpName, string _eUserName)
        {
            InitializeComponent();

            loggerViewControl = _lv;
            logModel = (LoggerModel)_lm;
            logController = new LoggerController(this);

            imageList = new List<ImageModel> { };

            lb_Asin.Text = ASIN = _asin;
            lb_cUser.Text = userName = _userName;
            lb_editDate.Text = logModel.EditDate.ToString().Substring(0, 10);
            lb_editUser.Text = editUserName = _eUserName;
            lb_marketPlace.Text = marketplaceName = _mpName;
            lb_ProductName.Text = productName = _pName;
            lb_Sku.Text = SKU = _sku;
            _lbcDate.Text = logModel.CreationDate.ToString().Substring(0, 10);
            richTextBox1.Text = logModel.Text;

            this.Text = "Просмотр записи";
            editMode = false;

            LoadImages();
            DrawPictures();
        }

        public LoggerShow(object _lm, string _userName, string _pName, string _asin, string _sku, string _mpName, string _eUserName, int _appUserId)
        {
            InitializeComponent();

            logModel = (LoggerModel)_lm;
            logController = new LoggerController(this);

            imageList = new List<ImageModel> { };

            lb_Asin.Text = ASIN = _asin;
            lb_cUser.Text = userName = _userName;
            lb_editDate.Text = logModel.EditDate.ToString().Substring(0, 10);
            lb_editUser.Text = editUserName = _eUserName;
            lb_marketPlace.Text = marketplaceName = _mpName;
            lb_ProductName.Text = productName = _pName;
            lb_Sku.Text = SKU = _sku;
            _lbcDate.Text = logModel.CreationDate.ToString().Substring(0, 10);
            richTextBox1.Text = logModel.Text;
            appUserId = _appUserId;

            this.Text = "Просмотр записи";
            editMode = false;

            LoadImages();
            DrawPictures();
        }


        private void LoadImages()
        {
            List<int> recordsImages = logModel.GetImages();
            logController.GetImageById(recordsImages, recordsImages.Count);
        }

        public void GetImagesFromDB(object _imageList)
        {
            imageList = (List<ImageModel>)_imageList;
        }

        private void DrawPictures()
        {
            try
            {
                List<PictureBox> pbList = new List<PictureBox> { };
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

                if (imageList.Count == 1)
                {
                    pbList[0].Size = new Size(741, 484);
                    pbList[0].Image = GetImageFromByteArray(imageList[0].ImageData);
                    pbList[0].Visible = true;
                }
                else
                {
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        pbList[i].Image = GetImageFromByteArray(imageList[i].ImageData);
                        pbList[i].Visible = true;
                    }

                }
            } catch (Exception ex) { MessageBox.Show("При загрузке изображений произошла ошибка. Часть или все изображения не были загружены", "Ошибка"); }
        }
        
        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                               bm.VerticalResolution != (int)bm.VerticalResolution))
            {
                // Correct a strange glitch that has been observed in the test program when converting 
                //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                 (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
        }

        
        private void LoggerShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loggerViewControl != null)
                loggerViewControl.Show();
        }

        private void Btn_EditSave_Click(object sender, EventArgs e)
        {
            if (!editMode)
            {
                //тут включаем нужные плюшки для редактирования
                editMode = true;
                btn_EditSave.Text = "Сохранить";
                btn_Close.Text = "Отмена";
                richTextBox1.ReadOnly = false;
                richTextBox1.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            }
            else
            {
                int p;
                if (loggerViewControl != null)
                    p = logController.UpdateRecord(logModel.RecordId, richTextBox1.Text, DateTime.Now, loggerViewControl.userModel.UserId);
                else
                    p = logController.UpdateRecord(logModel.RecordId, richTextBox1.Text, DateTime.Now, appUserId);
                if (p == 1)
                {
                    //тут проверяем и сохраняем
                    btn_EditSave.Text = "Изменить";
                    btn_Close.Text = "Закрыть";
                    editMode = false;
                    richTextBox1.ReadOnly = true;
                    richTextBox1.BackColor = Color.FromKnownColor(KnownColor.Control);

                    if (p == 1)
                        MessageBox.Show("Изменения были успешно сохранены", "Успех");
                }
                else
                {
                    MessageBox.Show("Во время сохранения произошла ошибка. Данные не были сохранены", "Ошибка");
                }
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                btn_EditSave.Text = "Изменить";
                btn_Close.Text = "Закрыть";
                editMode = false;
                richTextBox1.ReadOnly = true;
                richTextBox1.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else
                this.Close();
        }

        /* Увеличиваем выбранное изображение */
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox _pb = (PictureBox)sender;
            pb_Main.Image = _pb.Image;
            pb_Main.Visible = true;
        }

        /* ЛКМ  - закрываем, ПКМ - соxраняем */
        private void Pb_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pb_Main.Visible = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                saveFileDialog1.Filter = "PNG (*.png)|*.png|JPEG (*.jpeg)|*.jpeg|BMP (*.bmp)|*.bmp";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Png;
                    string ext = System.IO.Path.GetExtension(saveFileDialog1.FileName);
                    switch (ext)
                    {
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    try
                    {
                        pictureBox1.Image.Save(saveFileDialog1.FileName, format);
                        MessageBox.Show("Изображение успешно сохранено", "Успех");
                    }
                    catch (Exception ex) { MessageBox.Show("Произошла ошибка при сохранении. Изображение не было сохранено", "Это крах"); }
                }
            }
        }

        private void LoggerShow_Load(object sender, EventArgs e)
        {

        }
    }
}
