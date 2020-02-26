using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ReturnReason
    {
        public int ReasonId { get; set; }
        public int ReasonCode { get; set; }
        public int ReasonDescription { get; set; }

        public int ColumnCount { get; }


        public ReturnReason()
        {
            ColumnCount = 3;
        }
    }
}
