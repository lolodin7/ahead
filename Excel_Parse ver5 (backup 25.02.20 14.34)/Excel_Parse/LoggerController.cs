using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class LoggerController
    {
        private List<LoggerModel> logList;
        private List<ImageModel> imageList;

        private SqlConnection connection;
        private SqlCommand command;

        private LoggerView controlFormLoggerView;
        private LoggerShow controlFormLoggerShow;
        private LoggerAdd controlFormLoggerAdd;
        private MainFormView controlMainFormView;

        public LoggerController(LoggerView _mf)
        {
            connection = DBData.GetDBConnection();
            controlFormLoggerView = _mf;
        }

        public LoggerController(LoggerShow _mf)
        {
            connection = DBData.GetDBConnection();
            controlFormLoggerShow = _mf;
        }

        public LoggerController(LoggerAdd _mf)
        {
            connection = DBData.GetDBConnection();
            controlFormLoggerAdd = _mf;
        }

        public LoggerController(MainFormView _mf)
        {
            connection = DBData.GetDBConnection();
            controlMainFormView = _mf;
        }



        public int GetAllRecords()
        {
            string sqlStatement = "SELECT * FROM Logger";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public int GetAllRecordsByDate(DateTime _startDate, DateTime _endDate)
        {
            string sqlStatement = "SELECT * FROM [Logger] Where [CreationDate] between '" + _startDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + _endDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public int GetRecordsByFilters(string _sqlStatement)
        {
            command = new SqlCommand(_sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

        public int UpdateRecord(int _recId, string _text, DateTime _edate, int _euser)
        {
            string sqlStatement = "UPDATE [Logger] SET [Text] = '" + _text + "', [EditDate] = '" + _edate.ToString("yyyy-MM-dd HH:mm:ss") + "', [EditUserId] = " + _euser + " WHERE [RecordId] = " + _recId;
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }

        public int GetImageById(List<int> _idsList, int cnt)
        {
            string sqlStatement = "";
            switch (cnt)
            {
                case 0:
                    return -1;
                    break;
                case 1:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0];
                    break;
                case 2:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0] + " or [ImageId] = " + _idsList[1];
                    break;
                case 3:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0] + " or [ImageId] = " + _idsList[1] + " or [ImageId] = " + _idsList[2];
                    break;
                case 4:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0] + " or [ImageId] = " + _idsList[1] + " or [ImageId] = " + _idsList[2] + " or [ImageId] = " + _idsList[3];
                    break;
                case 5:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0] + " or [ImageId] = " + _idsList[1] + " or [ImageId] = " + _idsList[2] + " or [ImageId] = " + _idsList[3] + " or [ImageId] = " + _idsList[4];
                    break;
                case 6:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0] + " or [ImageId] = " + _idsList[1] + " or [ImageId] = " + _idsList[2] + " or [ImageId] = " + _idsList[3] + " or [ImageId] = " + _idsList[4] + " or [ImageId] = " + _idsList[5];
                    break;
                case 7:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0] + " or [ImageId] = " + _idsList[1] + " or [ImageId] = " + _idsList[2] + " or [ImageId] = " + _idsList[3] + " or [ImageId] = " + _idsList[4] + " or [ImageId] = " + _idsList[5] + " or [ImageId] = " + _idsList[6];
                    break;
                case 8:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0] + " or [ImageId] = " + _idsList[1] + " or [ImageId] = " + _idsList[2] + " or [ImageId] = " + _idsList[3] + " or [ImageId] = " + _idsList[4] + " or [ImageId] = " + _idsList[5] + " or [ImageId] = " + _idsList[6] + " or [ImageId] = " + _idsList[7];
                    break;
                case 9:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0] + " or [ImageId] = " + _idsList[1] + " or [ImageId] = " + _idsList[2] + " or [ImageId] = " + _idsList[3] + " or [ImageId] = " + _idsList[4] + " or [ImageId] = " + _idsList[5] + " or [ImageId] = " + _idsList[6] + " or [ImageId] = " + _idsList[7] + " or [ImageId] = " + _idsList[8];
                    break;
                case 10:
                    sqlStatement = "SELECT * FROM [Images] Where [ImageId] = " + _idsList[0] + " or [ImageId] = " + _idsList[1] + " or [ImageId] = " + _idsList[2] + " or [ImageId] = " + _idsList[3] + " or [ImageId] = " + _idsList[4] + " or [ImageId] = " + _idsList[5] + " or [ImageId] = " + _idsList[6] + " or [ImageId] = " + _idsList[7] + " or [ImageId] = " + _idsList[8] + " or [ImageId] = " + _idsList[9];
                    break;
            }

            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_IMAGE_Command(command);
        }

        private int Execute_SELECT_IMAGE_Command(SqlCommand _command)
        {
            imageList = new List<ImageModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetImageToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlFormLoggerShow != null)          //вызывает нужный метод в зависимости, из какой формы нас вызывают
                    controlFormLoggerShow.GetImagesFromDB(imageList);
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        /* Заносим данные в List<ImageModel> */
        private void SetImageToList(IDataRecord record)
        {
            ImageModel imgModel = new ImageModel();
            imageList.Add(imgModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                imageList[imageList.Count - 1].WriteData(i, record[i]);
            }
        }



        public int InserRecordIntoDB(DateTime _creationDate, int _creationUserId, int _productId, string _text, DateTime _editDate, int _editUserId, string _imageId, string _sku)
        {
            string sqlStatement = "INSERT INTO [Logger] ([CreationDate], [CreationUserId], [ProductId], [Text], [EditDate], [EditUserId], [ImageId], [SKU]) VALUES ('" + _creationDate.ToString("yyyy-MM-dd HH:mm:ss") + "', " + _creationUserId + ", " + _productId + ", '" + _text + "', '" + _editDate.ToString("yyyy-MM-dd HH:mm:ss") + "', " + _editUserId + ", '" + _imageId + "', '" + _sku + "')";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }

        public int InsertImagesInDB(string _fileName)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"INSERT INTO Images Output Inserted.ImageId VALUES (@FileName, @Title, @ImageData)";
            //command.CommandText = @"INSERT INTO Images VALUES (@FileName, @Title, @ImageData)";
            command.Parameters.Add("@FileName", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@Title", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@ImageData", SqlDbType.Image, 2000000000);

            // путь к файлу для загрузки
            string filename = @_fileName;
            // заголовок файла
            string title = filename.Substring(filename.LastIndexOf('\\') + 1);
            // получаем короткое имя файла для сохранения в бд
            string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // cats.jpg
                                                                                       // массив для хранения бинарных данных файла
            byte[] imageData;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                //fs.Read(imageData, 0, imageData.Length);
                fs.Read(imageData, 0, Convert.ToInt32(imageData.Length));
                fs.Close(); 
            }
            // передаем данные в команду через параметры
            command.Parameters["@FileName"].Value = shortFileName;
            command.Parameters["@Title"].Value = title;
            command.Parameters["@ImageData"].Value = imageData;


            connection.Open();

            int result = (int)command.ExecuteScalar();
            //command.ExecuteScalar();

            connection.Close();

            return result;
        }









        private int Execute_SELECT_Command(SqlCommand _command)
        {
            logList = new List<LoggerModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlFormLoggerView != null)          //вызывает нужный метод в зависимости, из какой формы нас вызывают
                    controlFormLoggerView.GetRecordsFromDB(logList);
                else if (controlMainFormView != null)
                    controlMainFormView.GetRecordsFromDB(logList);
                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }



        /* Заносим данные в List<ProductsModel> */
        private void SetDataToList(IDataRecord record)
        {
            LoggerModel lModel = new LoggerModel();
            logList.Add(lModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                logList[logList.Count - 1].WriteData(i, record[i]);
            }
        }


        /* Выполняем запрос UPDATE/INSERT/DELETE к БД */
        private int Execute_UPDATE_DELETE_INSERT_Command(SqlCommand _command)
        {
            try
            {
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
