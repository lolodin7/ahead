using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ImageModel
    {

        public int ImageId { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }

        public int ColumnCount { get; }

        public ImageModel()
        {
            ColumnCount = 4;
        }



        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    ImageId = int.Parse(record.ToString());
                    break;
                case 1:
                    FileName = record.ToString();    //record.GetDateTime(0);
                    break;
                case 2:
                    Title = record.ToString();
                    break;
                case 3:
                    ImageData = (byte[])record;
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return ImageId;
                    break;
                case 1:
                    return FileName;    //record.GetDateTime(0);
                    break;
                case 2:
                    return Title;
                    break;
                case 3:
                    return ImageData;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
