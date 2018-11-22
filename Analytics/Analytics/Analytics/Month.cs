using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics
{
    class Month
    {
        public string Jan { get; }
        public string Feb { get; }
        public string Mar { get; }
        public string Apr { get; }
        public string May { get; }
        public string Jun { get; }
        public string Jul { get; }
        public string Aug { get; }
        public string Sep { get; }
        public string Oct { get; }
        public string Nov { get; }
        public string Dec { get; }

        public Month()
        {
            Jan = "Jan";
            Feb = "Feb";
            Mar = "Mar";
            Apr = "Apr";
            May = "May";
            Jun = "Jun";
            Jul = "Jul";
            Aug = "Aug";
            Sep = "Sep";
            Oct = "Oct";
            Nov = "Nov";
            Dec = "Dec";
        }

        public int GetMonthValue(string _month)
        {
            switch (_month)
            {
                case "Jan":
                    return 1;
                    break;
                case "Feb":
                    return 2;
                    break;
                case "Mar":
                    return 3;
                    break;
                case "Apr":
                    return 4;
                    break;
                case "May":
                    return 5;
                    break;
                case "Jun":
                    return 6;
                    break;
                case "Jul":
                    return 7;
                    break;
                case "Aug":
                    return 8;
                    break;
                case "Sep":
                    return 9;
                    break;
                case "Oct":
                    return 10;
                    break;
                case "Nov":
                    return 11;
                    break;
                case "Dec":
                    return 12;
                    break;
                default:
                    return 0;
            }
        }
    }
}
