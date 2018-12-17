using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class MarketplaceModel
    {
        public int MarketPlaceId { get; set; }
        public string MarketPlaceName { get; set; }
        public int ColumnCount { get; }

        public MarketplaceModel()
        {
            ColumnCount = 2;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    MarketPlaceId = int.Parse(record.ToString());
                    break;
                case 1:
                    MarketPlaceName = record.ToString();
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return MarketPlaceId;
                    break;
                case 1:
                    return MarketPlaceName;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }

}

