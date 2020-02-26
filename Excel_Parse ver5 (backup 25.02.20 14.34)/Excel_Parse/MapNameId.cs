using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class MapNameId
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int ColumnCount { get; }
        public MapNameId()
        {
            ColumnCount = 2;
        }

        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    ID = int.Parse(record.ToString());
                    break;
                case 1:
                    Name = record.ToString();
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return ID;
                    break;
                case 1:
                    return Name;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
