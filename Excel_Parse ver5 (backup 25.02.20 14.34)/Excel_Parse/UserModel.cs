using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string PassHash { get; set; }
        public string Name { get; set; }
        public int Token1 { get; set; }
        public int Token2 { get; set; }
        public int UserRoleId { get; set; }
        public string SecretQuestion { get; set; }
        public string Answer { get; set; }
        public string Mac { get; set; }

        public int ColumnCount { get; }

        public UserModel()
        {
            ColumnCount = 10;
        }


        public void WriteData(int index, object record)
        {
            switch (index)
            {
                case 0:
                    UserId = int.Parse(record.ToString());
                    break;
                case 1:
                    Login = record.ToString();
                    break;
                case 2:
                    PassHash = record.ToString();
                    break;
                case 3:
                    Name = record.ToString();
                    break;
                case 4:
                    Token1 = int.Parse(record.ToString());
                    break;
                case 5:
                    Token2 = int.Parse(record.ToString());
                    break;
                case 6:
                    UserRoleId = int.Parse(record.ToString());
                    break;
                case 7:
                    SecretQuestion = record.ToString();
                    break;
                case 8:
                    Answer = record.ToString();
                    break;
                case 9:
                    Mac = record.ToString();
                    break;
            }
        }

        public object ReadData(int index)
        {
            switch (index)
            {
                case 0:
                    return UserId;
                    break;
                case 1:
                    return Login; 
                    break;
                case 2:
                    return PassHash;
                    break;
                case 3:
                    return Name;
                    break;
                case 4:
                    return Token1;
                    break;
                case 5:
                    return Token2;
                    break;
                case 6:
                    return UserRoleId;
                    break;
                case 7:
                    return SecretQuestion;
                    break;
                case 8:
                    return Answer;
                    break;
                case 9:
                    return Mac;                       
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
