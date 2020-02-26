using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class LoggerModel
    {
        public int RecordId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUserId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; }
        public DateTime EditDate { get; set; }
        public int EditUserId { get; set; }
        public string ImageId { get; set; }
        public string SKU { get; set; }

        public int ColumnCount { get; }

        public LoggerModel()
        {
            ColumnCount = 9;
        }


        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    RecordId = int.Parse(record.ToString());
                    break;
                case 1:
                    CreationDate = (DateTime)record;    //record.GetDateTime(0);
                    break;
                case 2:
                    CreationUserId = int.Parse(record.ToString());
                    break;
                case 3:
                    ProductId = int.Parse(record.ToString());
                    break;
                case 4:
                    Text = record.ToString();
                    break;
                case 5:
                    EditDate = (DateTime)record;    //record.GetDateTime(0);
                    break;
                case 6:
                    EditUserId = int.Parse(record.ToString());
                    break;
                case 7:
                    ImageId = record.ToString();
                    break;
                case 8:
                    SKU = record.ToString();
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return RecordId;
                    break;
                case 1:
                    return CreationDate;    //record.GetDateTime(0);
                    break;
                case 2:
                    return CreationUserId;
                    break;
                case 3:
                    return ProductId;
                    break;
                case 4:
                    return Text;    
                    break;
                case 5:
                    return EditDate;        //record.GetDateTime(0);
                    break;
                case 6:
                    return EditUserId;
                    break;
                case 7:
                    return ImageId;
                    break;
                case 8:
                    return SKU;
                    break;
                default:
                    return -1;
                    break;
            }
        }


        public List<int> GetImages()
        {
            List<int> idList = new List<int> { };
            int startpos = 0, endpos = 0;

            for (int i = 0; i < ImageId.Length; i++)
            {
                if (ImageId[i].Equals('|'))
                {
                    endpos = i;
                    idList.Add(int.Parse(ImageId.Substring(startpos, endpos - startpos)));
                    startpos = i + 1;
                }
            }
            return idList;
        }

        public string SetImages(List<int> _imgList)
        {
            string result = "";
            for (int i = 0; i < _imgList.Count; i++)
            {
                result = result + _imgList[i] + "|";
            }
            return result;
        }
    }
}
