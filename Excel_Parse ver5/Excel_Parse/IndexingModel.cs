using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class IndexingModel
    {
        public int ProductId { get; set; }
        public string ASIN { get; set; }
        public List<DateTime> DateList { get; set; }
        public List<string> Status { get; set; }
        public List<string> Notes { get; set; }

        public IndexingModel()
        {
            DateList = new List<DateTime> { };
            Status = new List<string> { };
            Notes = new List<string> { };
        }

        public void WriteIndexing(int index, object _value)
        {
            switch (index)
            {
                case 0:
                    ProductId = int.Parse(_value.ToString());
                    break;
                case 1:
                    ASIN = _value.ToString();
                    break;
                case 2:
                    DateList.Add(new DateTime());
                    DateList[DateList.Count - 1] = (DateTime)_value;
                    break;
                case 3:
                    Status.Add("");
                    Status[Status.Count - 1] = _value.ToString();
                    break;
                case 4:
                    Notes.Add("");
                    Notes[Notes.Count - 1] = _value.ToString();
                    break;
            }
        }

        public object ReadIndexing(int index)
        {
            switch (index)
            {
                case 0:
                    return ProductId;
                    break;
                case 1:
                    return ASIN;
                    break;
                case 2:
                    return DateList;
                    break;
                case 3:
                    return Status;
                    break;
                case 4:
                    return Notes;
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
