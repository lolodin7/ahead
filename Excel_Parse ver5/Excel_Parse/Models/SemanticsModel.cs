using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class SemanticsModel
    {
        public int SemanticsId { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Bullet1 { get; set; }
        public string Bullet2 { get; set; }
        public string Bullet3 { get; set; }
        public string Bullet4 { get; set; }
        public string Bullet5 { get; set; }
        public string Backend { get; set; }
        public string Description { get; set; }
        public string OtherAttributes1 { get; set; }
        public string OtherAttributes2 { get; set; }
        public string OtherAttributes3 { get; set; }
        public string OtherAttributes4 { get; set; }
        public string OtherAttributes5 { get; set; }
        public string IntendedUse1 { get; set; }
        public string IntendedUse2 { get; set; }
        public string IntendedUse3 { get; set; }
        public string IntendedUse4 { get; set; }
        public string IntendedUse5 { get; set; }
        public string SubjectMatter1 { get; set; }
        public string SubjectMatter2 { get; set; }
        public string SubjectMatter3 { get; set; }
        public string SubjectMatter4 { get; set; }
        public string SubjectMatter5 { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Notes { get; set; }
        public string UsedKeywords { get; set; }

        public int ColumnCount { get; }

        public SemanticsModel()
        {
            ColumnCount = 28;
        }

        public void SetSemantics(int index, object _value)
        {
            switch (index)
            {
                case 0:
                    SemanticsId = int.Parse(_value.ToString());
                    break;
                case 1:
                    ProductId = int.Parse(_value.ToString());
                    break;
                case 2:
                    Title = _value.ToString();
                    break;
                case 3:
                    Bullet1 = _value.ToString();
                    break;
                case 4:
                    Bullet2 = _value.ToString();
                    break;
                case 5:
                    Bullet3 = _value.ToString();
                    break;
                case 6:
                    Bullet4 = _value.ToString();
                    break;
                case 7:
                    Bullet5 = _value.ToString();
                    break;
                case 8:
                    Backend = _value.ToString();
                    break;
                case 9:
                    Description = _value.ToString();
                    break;
                case 10:
                    OtherAttributes1 = _value.ToString();
                    break;
                case 11:
                    OtherAttributes2 = _value.ToString();
                    break;
                case 12:
                    OtherAttributes3 = _value.ToString();
                    break;
                case 13:
                    OtherAttributes4 = _value.ToString();
                    break;
                case 14:
                    OtherAttributes5 = _value.ToString();
                    break;
                case 15:
                    IntendedUse1 = _value.ToString();
                    break;
                case 16:
                    IntendedUse2 = _value.ToString();
                    break;
                case 17:
                    IntendedUse3 = _value.ToString();
                    break;
                case 18:
                    IntendedUse4 = _value.ToString();
                    break;
                case 19:
                    IntendedUse5 = _value.ToString();
                    break;
                case 20:
                    SubjectMatter1 = _value.ToString();
                    break;
                case 21:
                    SubjectMatter2 = _value.ToString();
                    break;
                case 22:
                    SubjectMatter3 = _value.ToString();
                    break;
                case 23:
                    SubjectMatter4 = _value.ToString();
                    break;
                case 24:
                    SubjectMatter5 = _value.ToString();
                    break;
                case 25:
                    //string str = _value.ToString();
                    //int day = int.Parse(str.Substring(0, 2));
                    //int month = int.Parse(str.Substring(3, 2));
                    //int year = int.Parse(str.Substring(6, 4));
                    //UpdateDate = new DateTime(year, month, day);
                    UpdateDate = (DateTime)_value;
                    break;
                case 26:
                    Notes = _value.ToString();
                    break;
                case 27:
                    UsedKeywords = _value.ToString();
                    break;
            }
        }

        public object GetSemantics(int index)
        {
            switch (index)
            {
                case 0:
                    return SemanticsId;
                    break;
                case 1:
                    return ProductId;
                    break;
                case 2:
                    return Title;
                    break;
                case 3:
                    return Bullet1;
                    break;
                case 4:
                    return Bullet2;
                    break;
                case 5:
                    return Bullet3;
                    break;
                case 6:
                    return Bullet4;
                    break;
                case 7:
                    return Bullet5;
                    break;
                case 8:
                    return Backend;
                    break;
                case 9:
                    return Description;
                    break;
                case 10:
                    return OtherAttributes1;
                    break;
                case 11:
                    return OtherAttributes2;
                    break;
                case 12:
                    return OtherAttributes3;
                    break;
                case 13:
                    return OtherAttributes4;
                    break;
                case 14:
                    return OtherAttributes5;
                    break;
                case 15:
                    return IntendedUse1;
                    break;
                case 16:
                    return IntendedUse2;
                    break;
                case 17:
                    return IntendedUse3;
                    break;
                case 18:
                    return IntendedUse4;
                    break;
                case 19:
                    return IntendedUse5;
                    break;
                case 20:
                    return SubjectMatter1;
                    break;
                case 21:
                    return SubjectMatter2;
                    break;
                case 22:
                    return SubjectMatter3;
                    break;
                case 23:
                    return SubjectMatter4;
                    break;
                case 24:
                    return SubjectMatter5;
                    break;
                case 25:
                    return UpdateDate;
                    break;
                case 26:
                    return Notes;
                    break;
                case 27:
                    return UsedKeywords;
                    break;
                default:
                    return -1;
                    break;
            }
            return null;
        }
    }
}
