using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class SemCoreArchiveModel
    {
        public int ProductTypeId { get; set; }
        public int CategoryId { get; set; }
        public string Keyword { get; set; }
        public int SemCoreId { get; set; }
        public string ValuesAndDates { get; set; }
        public string CategoryName { get; set; }
        public string TypeName { get; set; }
        public List<int> Value { get; set; }
        public List<DateTime> UpdateDate { get; set; }

        public int ColumnCount { get; }


        public SemCoreArchiveModel()
        {
            ColumnCount = 7;
            Value = new List<int> { };
            UpdateDate = new List<DateTime> { };
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    ProductTypeId = int.Parse(record.ToString());
                    break;
                case 1:
                    CategoryId = int.Parse(record.ToString());
                    break;
                case 2:
                    Keyword = record.ToString();
                    break;
                case 3:
                    SemCoreId = int.Parse(record.ToString());
                    break;
                case 4:
                    ValuesAndDates = record.ToString();
                    break;
                case 5:
                    CategoryName = record.ToString();
                    break;
                case 6:
                    TypeName = record.ToString();
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return ProductTypeId;
                    break;
                case 1:
                    return CategoryId;
                    break;
                case 2:
                    return Keyword;
                    break;
                case 3:
                    return SemCoreId;
                    break;
                case 4:
                    return ValuesAndDates;
                    break;
                case 5:
                    return CategoryName;
                    break;
                case 6:
                    return TypeName;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}