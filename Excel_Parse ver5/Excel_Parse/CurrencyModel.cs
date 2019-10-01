using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class CurrencyModel
    {
        private DateTime UpdateDate { get; set; }
        private int NumCode { get; set; }
        private string CharCode { get; set; }
        private int Nominal { get; set; }
        private string Name { get; set; }
        private double Value { get; set; }


        public int ColumnCount { get; }

        public CurrencyModel()
        {
            ColumnCount = 6;
        }


        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    UpdateDate = (DateTime)record;
                    break;
                case 1:
                    NumCode = int.Parse(record.ToString());
                    break;
                case 2:
                    CharCode = record.ToString();
                    break;
                case 3:
                    Nominal = int.Parse(record.ToString());
                    break;
                case 4:
                    Name = record.ToString();
                    break;
                case 5:
                    Value = GetDouble(record);
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return UpdateDate;
                    break;
                case 1:
                    return NumCode;
                    break;
                case 2:
                    return CharCode;
                    break;
                case 3:
                    return Nominal;
                    break;
                case 4:
                    return Name;
                    break;
                case 5:
                    return Value;
                    break;
                default:
                    return -1;
                    break;
            }
        }

        private double GetDouble(object _value)
        {
            double _amount = 0;
            if (!_value.ToString().Equals(""))
            {
                try
                {
                    _amount = double.Parse(_value.ToString());
                }
                catch (Exception ex)
                {
                    string s = _value.ToString();
                    string str = s.Substring(1, s.Length - 1);
                    _amount = double.Parse(str, CultureInfo.InvariantCulture);
                }
            }
            else
                _amount = 0;
            return _amount;
        }
    }
}
