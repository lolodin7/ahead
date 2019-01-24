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

        public int ColumnCount { get; }


        public SemCoreArchiveModel()
        {
            ColumnCount = 5;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    Keyword = record.ToString();
                    break;
                case 1:
                    SemCoreId = int.Parse(record.ToString());
                    break;
                case 2:
                    CategoryId = int.Parse(record.ToString());
                    break;
                case 3:
                    ProductTypeId = int.Parse(record.ToString());
                    break;
                case 4:
                    ValuesAndDates = record.ToString();
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return Keyword;
                    break;
                case 1:
                    return SemCoreId;
                    break;
                case 2:
                    return CategoryId;
                    break;
                case 3:
                    return ProductTypeId;
                    break;
                case 4:
                    return ValuesAndDates;
                    break;
                default:
                    return -1;
                    break;
            }
        }

        public void SetValues(int _prodTypeId, int _categoryId, string _keyword, int _value, DateTime _dt)
        {
            ProductTypeId = _prodTypeId;
            CategoryId = _categoryId;
            Keyword = _keyword;

            ValuesAndDates = _value + _dt.ToString(); 
        }

    }
}