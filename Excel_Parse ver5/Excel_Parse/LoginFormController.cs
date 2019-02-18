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

namespace Bona_Fides
{
    class LoginFormController
    {

        private SqlConnection connection;
        private SqlCommand command;

        private UserModel um;

        private LoginFormView loginFormControl;

        public LoginFormController(LoginFormView _lf)
        {
            connection = DBData.GetDBConnection();
            loginFormControl = _lf;
        }





        public bool GetUserDataFromDB(string _login)
        {
            string sqlStatement = "SELECT * FROM [User] WHERE [Login] = '" + _login + "'";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
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

                loginFormControl.GetUserDataFromDB(um);

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
        private int Execute_INSERT_UPDATE_DELETE_Command(SqlCommand _command)
        {
            try
            {
                connection.Close();
                connection.Open();
                _command.ExecuteScalar();
                connection.Close();
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }
    }
}
