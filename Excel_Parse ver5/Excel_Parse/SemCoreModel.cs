using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class SemCoreModel
    {
        public int ProductTypeId { get; set; }
        public int CategoryId { get; set; }
        public string Keyword { get; set; }
        public int Value { get; set; }
        public DateTime LastUpdated { get; set; }
        public int SemCoreId { get; set; }

        public int ColumnCount { get; }

        public SemCoreModel()
        {
            ColumnCount = 6;
        }

        public void SetModelData(int index, object record)
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
                    Value = int.Parse(record.ToString());
                    break;
                case 4:
                    LastUpdated = (DateTime)record;    //record.GetDateTime(0);
                    break;
                case 5:
                    SemCoreId = int.Parse(record.ToString());
                    break;
            }
        }

        public object GetModelData(int index)
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
                    return Value;
                    break;
                case 4:
                    return LastUpdated;    //record.GetDateTime(0);
                    break;
                case 5:
                    return SemCoreId;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
