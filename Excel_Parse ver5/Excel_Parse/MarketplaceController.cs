﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class MarketplaceController
    {
        private SqlConnection connection;
        private SqlCommand command;

        private List<MarketplaceModel> mpList;

        private ProductsView controlProductsView;
        private MarketplaceView controlMarketPlaceView;
        private SemCoreView controlSemCoreView;
        private ReportBusinessUploadView controlReportBusinessUploadView;
        private ReportAdvertisingUploadView controlAdvertisingUploadReport;
        private ReportAdvertisingFilterView controlAdvertisingReportFilterView;
        private ReportBusinessFilterView controlReportBusinessFilterView;
        private ReportSessionsView controlReportSessionsView;
        private Advreport7days controlAdvreport7days;
        private ReportAdvertisingView controlReportAdvertisingView;
        private AnalyzeAdvertisingReport controlAnalyzeAdvertisingReport;
        private ReportStockUploadView controlReportStockUploadView;
        private ReportStockView controlReportStockView;
        private AllOrdersView controlAllOrdersView;
        private ReportSalesView controlReportSalesView;
        //private MarketplaceView


        public MarketplaceController(ReportSalesView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportSalesView = _mf;
        }

        public MarketplaceController(AllOrdersView _mf)
        {
            connection = DBData.GetDBConnection();
            controlAllOrdersView = _mf;
        }

        public MarketplaceController(ReportStockView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportStockView = _mf;
        }

        public MarketplaceController(ReportStockUploadView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportStockUploadView = _mf;
        }

        public MarketplaceController(AnalyzeAdvertisingReport _mf)
        {
            connection = DBData.GetDBConnection();
            controlAnalyzeAdvertisingReport = _mf;
        }
        
        public MarketplaceController(ReportAdvertisingView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportAdvertisingView = _mf;
        }
        
        public MarketplaceController(Advreport7days _mf)
        {
            connection = DBData.GetDBConnection();
            controlAdvreport7days = _mf;
        }

        public MarketplaceController(ProductsView _mf)
        {
            connection = DBData.GetDBConnection();
            controlProductsView = _mf;
        }

        public MarketplaceController(ReportSessionsView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportSessionsView = _mf;
        }

        public MarketplaceController(ReportBusinessFilterView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportBusinessFilterView = _mf;
        }

        public MarketplaceController(ReportBusinessUploadView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportBusinessUploadView = _mf;
        }

        public MarketplaceController(MarketplaceView _mf)
        {
            connection = DBData.GetDBConnection();
            controlMarketPlaceView = _mf;
        }

        public MarketplaceController(SemCoreView _mf)
        {
            connection = DBData.GetDBConnection();
            controlSemCoreView = _mf;
        }
        
        public MarketplaceController(ReportAdvertisingUploadView _mf)
        {
            connection = DBData.GetDBConnection();
            controlAdvertisingUploadReport = _mf;
        }

        public MarketplaceController(ReportAdvertisingFilterView _mf)
        {
            connection = DBData.GetDBConnection();
            controlAdvertisingReportFilterView = _mf;
        }


        public int GetMarketplaces()
        {
            string sqlStatement = "SELECT * FROM Marketplace WHERE MarketPlaceId > 0";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }


        public int SetNewMarketplace(string name)
        {
            string sqlStatement = "INSERT INTO [Marketplace] ([MarketPlaceName]) VALUES ('" + name + "')";
            command = new SqlCommand(sqlStatement, connection);
            return (Execute_INSERT_Command(command));
        }


        public int UpdateExistingMarketplace(string name, int id)
        {
            string sqlStatement = "UPDATE [Marketplace] SET [MarketPlaceName] = '" + name + "' WHERE [MarketPlaceId] = " + id;
            command = new SqlCommand(sqlStatement, connection);
            return (Execute_INSERT_Command(command));
        }





        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
        private int Execute_INSERT_Command(SqlCommand _command)
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

        /* Выполняем запрос к БД и заносим полученные данные в List<SemCoreModel> */
        private int Execute_SELECT_Command(SqlCommand _command)
        {
            mpList = new List<MarketplaceModel> { };
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

                if (controlProductsView != null)
                    controlProductsView.GetMarketPlacesFromDB(mpList);
                else if (controlMarketPlaceView != null)
                    controlMarketPlaceView.GetMarketPlacesFromDB(mpList);
                else if (controlSemCoreView != null)
                    controlSemCoreView.GetMarketPlacesFromDB(mpList);
                else if (controlAdvertisingReportFilterView != null)
                    controlAdvertisingReportFilterView.GetMarketPlacesFromDB(mpList);
                else if (controlReportBusinessUploadView != null)
                    controlReportBusinessUploadView.GetMarketPlacesFromDB(mpList);
                else if (controlReportBusinessFilterView != null)
                    controlReportBusinessFilterView.GetMarketPlacesFromDB(mpList);
                else if (controlReportSessionsView != null)
                    controlReportSessionsView.GetMarketPlacesFromDB(mpList);
                else if (controlAdvreport7days != null)
                    controlAdvreport7days.GetMarketPlacesFromDB(mpList);
                else if (controlAdvertisingUploadReport != null)
                    controlAdvertisingUploadReport.GetMarketPlacesFromDB(mpList);
                else if (controlAnalyzeAdvertisingReport != null)
                    controlAnalyzeAdvertisingReport.GetMarketPlacesFromDB(mpList);
                else if (controlReportStockUploadView != null)
                    controlReportStockUploadView.GetMarketPlacesFromDB(mpList);
                else if (controlReportStockView != null)
                    controlReportStockView.GetMarketPlacesFromDB(mpList);
                else if (controlReportSalesView != null)
                    controlReportSalesView.GetMarketPlacesFromDB(mpList);
                else if (controlReportAdvertisingView != null)
                {
                    controlReportAdvertisingView.GetMarketPlacesFromDB1(mpList);
                    controlReportAdvertisingView.GetMarketPlacesFromDB2(mpList);
                    controlReportAdvertisingView.GetMarketPlacesFromDB3(mpList);
                }

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
            MarketplaceModel mpModel = new MarketplaceModel();
            mpList.Add(mpModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                mpList[mpList.Count - 1].WriteData(i, record[i]);
            }
        }
    }
}
