using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ProductTypesModel
    {
        public int ProductTypeId { get; set; }
        public string TypeName { get; set; }

        public int ColumnCount { get; }

        public ProductTypesModel()
        {
            ColumnCount = 2;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    ProductTypeId = int.Parse(record.ToString());
                    break;
                case 1:
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
                    return TypeName;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
