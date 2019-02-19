using Excel_Parse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    class LoginFormController
    {

        private SqlConnection connection;
        private SqlCommand command;

        private UserModel um;

        private LoginFormView controlLoginFormControl;
        private RestorePasswordView controlRestorePasswordViewControl;
        private ControlPanelView controlControlPanelView;
        private ChangeQuestionView controlChangeQuestionView;

        public LoginFormController(LoginFormView _lf)
        {
            connection = DBData.GetDBConnection();
            controlLoginFormControl = _lf;
        }

        
        public LoginFormController(RestorePasswordView _lf)
        {
            connection = DBData.GetDBConnection();
            controlRestorePasswordViewControl = _lf;
        }

        public LoginFormController(ControlPanelView _cp)
        {
            connection = DBData.GetDBConnection();
            controlControlPanelView = _cp;
        }        

        public LoginFormController(ChangeQuestionView _cp)
        {
            connection = DBData.GetDBConnection();
            controlChangeQuestionView = _cp;
        }




        public bool GetUserDataFromDB(string _login)
        {
            string sqlStatement = "SELECT * FROM [User] WHERE [Login] = '" + _login + "'";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }



        public bool UpdateUserPassword(int _userId, string _password)
        {
            string sqlStatement = "UPDATE [User] Set [PassHash] = '" + _password + "' where [UserId] = " + _userId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_INSERT_UPDATE_DELETE_Command(command);
        }

        public bool UpdateUserName(int _userId, string _name)
        {
            string sqlStatement = "UPDATE [User] Set [Name] = '" + _name + "' where [UserId] = " + _userId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_INSERT_UPDATE_DELETE_Command(command);
        }

        public bool UpdateAnswer(int _userId, string asnwer)
        {
            string sqlStatement = "UPDATE [User] Set [Answer] = '" + asnwer + "' where [UserId] = " + _userId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_INSERT_UPDATE_DELETE_Command(command);
        }

        public bool UpdateQuestionAndAnswer(int _userId, string question, string asnwer)
        {
            string sqlStatement = "UPDATE [User] Set [SecretQuestion] = '" + question + "', [Answer] = '" + asnwer + "' where [UserId] = " + _userId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_INSERT_UPDATE_DELETE_Command(command);
        }








        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
        private bool Execute_SELECT_Command(SqlCommand _command)
        {
            bool result = false;
            um = new UserModel();
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetData((IDataRecord)reader);
                        result = true;
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlLoginFormControl != null)
                    controlLoginFormControl.GetUserDataFromDB(um);
                else if (controlRestorePasswordViewControl != null)
                    controlRestorePasswordViewControl.GetUserDataFromDB(um);

                return result;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
        }

        /* Заносим данные в List<SemCoreModel> */
        private void SetData(IDataRecord record)
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                um.WriteData(i, record[i]);
            }
        }





        /* Записываем данные в БД */
        private bool Execute_INSERT_UPDATE_DELETE_Command(SqlCommand _command)
        {
            try
            {
                connection.Close();
                connection.Open();
                _command.ExecuteScalar();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
        }
    }
}
