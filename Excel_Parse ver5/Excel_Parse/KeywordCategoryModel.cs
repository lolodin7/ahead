using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class KeywordCategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ProductTypeId { get; set; }

        public int ColumnCount { get; }

        public KeywordCategoryModel()
        {
            ColumnCount = 3;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    CategoryId = int.Parse(record.ToString());
                    break;
                case 1:
                    CategoryName = record.ToString();
                    break;
                case 2:
                    ProductTypeId = int.Parse(record.ToString());
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return CategoryId;
                    break;
                case 1:
                    return CategoryName;
                    break;
                case 2:
                    return ProductTypeId;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
