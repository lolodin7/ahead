using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class CampaignTypesModel
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int ColumnCount { get; }

        public CampaignTypesModel()
        {
            ColumnCount = 2;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    CampaignId = int.Parse(record.ToString());
                    break;
                case 1:
                    CampaignName = record.ToString();
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return CampaignId;
                    break;
                case 1:
                    return CampaignName;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
