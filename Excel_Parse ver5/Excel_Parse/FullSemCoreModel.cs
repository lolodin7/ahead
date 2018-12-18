using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class FullSemCoreModel
    {
        public int ProductTypeIdSemCore { get; set; }
        public int CategoryIdSemCore { get; set; }
        public string Keyword { get; set; }
        public int Value { get; set; }
        public DateTime LastUpdated { get; set; }
        public int SemCoreId { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ProductTypeIdCategory { get; set; }

        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public int ColumnCount { get; }

        public FullSemCoreModel()
        {
            ColumnCount = 11;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    ProductTypeIdSemCore = int.Parse(record.ToString());
                    break;
                case 1:
                    CategoryIdSemCore = int.Parse(record.ToString());
                    break;
                case 2:
                    Keyword = record.ToString();
                    break;
                case 3:
                    Value = int.Parse(record.ToString());
                    break;
                case 4:
                    LastUpdated = (DateTime)record;   //record.GetDateTime(0);
                    //LastUpdated = DateTime.Parse(LastUpdated.ToShortDateString());
                    break;
                case 5:
                    SemCoreId = int.Parse(record.ToString());
                    break;
                case 6:
                    CategoryId = int.Parse(record.ToString());
                    break;
                case 7:
                    CategoryName = record.ToString();
                    break;
                case 8:
                    ProductTypeIdCategory = int.Parse(record.ToString());
                    break;
                case 9:
                    ProductTypeId = int.Parse(record.ToString());
                    break;
                case 10:
                    ProductTypeName = record.ToString();
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return ProductTypeIdSemCore;
                    break;
                case 1:
                    return CategoryIdSemCore;
                    break;
                case 2:
                    return Keyword;
                    break;
                case 3:
                    return Value;
                    break;
                case 4:
                    return LastUpdated;    //record.GetDateTime(0);
                    break;
                case 5:
                    return SemCoreId;
                    break;
                case 6:
                    return CategoryId;
                    break;
                case 7:
                    return CategoryName;
                    break;
                case 8:
                    return ProductTypeIdCategory;
                    break;
                case 9:
                    return ProductTypeId;
                    break;
                case 10:
                    return ProductTypeName;
                    break;
                default:
                    return -1;
                    break;
            }
        }

    }
}
