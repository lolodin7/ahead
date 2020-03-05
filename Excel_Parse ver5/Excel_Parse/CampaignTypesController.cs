using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class CampaignTypesController
    {
        private SqlConnection connection;
        private SqlCommand command;

        private List<CampaignTypesModel> campTList;

        private ReportAdvertisingUploadView controlAdvertisingUploadReportView;
        private ReportAdvertisingFilterView controlAdvertisingReportFilterView;
        private EveryDayReportsUpdate controlEveryDayReportsUpdate;

        public CampaignTypesController(EveryDayReportsUpdate _mf)
        {
            connection = DBData.GetDBConnection();
            controlEveryDayReportsUpdate = _mf;
        }

        public CampaignTypesController(ReportAdvertisingUploadView _mf)
        {
            connection = DBData.GetDBConnection();
            controlAdvertisingUploadReportView = _mf;
        }

        public CampaignTypesController(ReportAdvertisingFilterView _mf)
        {
            connection = DBData.GetDBConnection();
            controlAdvertisingReportFilterView = _mf;
        }

        public int GetCampaignTypes()
        {
            string sqlStatement = "SELECT * FROM CampaignType";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }
        
        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
        private int Execute_SELECT_Command(SqlCommand _command)
        {
            campTList = new List<CampaignTypesModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetProductsToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
                
                if (controlAdvertisingReportFilterView != null)
                    controlAdvertisingReportFilterView.GetCampaignTypesFromDB(campTList);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }


        /* Заносим данные в List<ProductsModel> */
        private void SetProductsToList(IDataRecord record)
        {
            CampaignTypesModel campTModel = new CampaignTypesModel();
            campTList.Add(campTModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                campTList[campTList.Count - 1].WriteData(i, record[i]);
            }
        }
    }
}
