using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ProductsModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ASIN { get; set; }
        public string SKU { get; set; }
        public int ProductTypeId { get; set; }
        public int ColumnCount { get; }

        public ProductsModel()
        {
            ColumnCount = 5;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    ProductId = int.Parse(record.ToString());
                    break;
                case 1:
                    Name = record.ToString();
                    break;
                case 2:
                    ASIN = record.ToString();
                    break;
                case 3:
                    SKU = record.ToString();
                    break;
                case 4:
                    ProductTypeId = int.Parse(record.ToString());
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return ProductId;
                    break;
                case 1:
                    return Name;
                    break;
                case 2:
                    return ASIN;
                    break;
                case 3:
                    return SKU;
                    break;
                case 4:
                    return ProductTypeId;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
