using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class DetailedDisposition
    {
        public int DispositionId { get; set; }
        public int DispositionCode { get; set; }
        public int DispositionDescription { get; set; }

        public int ColumnCount { get; }

        public DetailedDisposition()
        {
            ColumnCount = 3;
        }
    }
}
