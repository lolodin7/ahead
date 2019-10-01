using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class LoggerAddAsinSkuPairs
    {
        public string ASIN { get; set; }
        public List<string> skuList;
        public int productId { get; set; }
        public LoggerAddAsinSkuPairs()
        {
            skuList = new List<string> { };
        }
    }
}
