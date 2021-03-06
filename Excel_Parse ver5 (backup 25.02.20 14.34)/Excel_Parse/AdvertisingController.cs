﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class AdvertisingController
    {
        private SqlConnection connection;
        private SqlCommand command;


        private List<AdvertisingProductsModel> advprodList;
        private List<AdvertisingProductsModel> advprodListOriginal;
        private List<AdvertisingBrandsModel> advbrandList;

        private ReportAdvertisingUploadView controlAdvertisingUploadReportView;
        private ReportAdvertisingFilterView controlAdvertisingReportFilterView;
        private ReportSessionsView controlReportSessionsView;
        private EveryDayReportsUpdate controlEveryDayReportsUpdate;

        private struct listElement
        {
            public string key { get; set; }
            public double val { get; set; }
        }


        public AdvertisingController(EveryDayReportsUpdate _mf)
        {
            connection = DBData.GetDBConnection();
            controlEveryDayReportsUpdate = _mf;
        }

        public AdvertisingController(ReportAdvertisingUploadView _mf)
        {
            connection = DBData.GetDBConnection();
            controlAdvertisingUploadReportView = _mf;
        }

        public AdvertisingController(ReportSessionsView _mf)
        {
            connection = DBData.GetDBConnection();
            controlReportSessionsView = _mf;
        }

        public AdvertisingController(ReportAdvertisingFilterView _mf)
        {
            connection = DBData.GetDBConnection();
            controlAdvertisingReportFilterView = _mf;
        }


        public int GetIdFromString(string t)
        {
            int MUST_BE_LESS_THAN = 100000000; // 8 decimal digits

            uint hash = 0;
            foreach (byte b in System.Text.Encoding.Unicode.GetBytes(t))
            {
                hash += b;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }

            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);               

            return (int)(hash % MUST_BE_LESS_THAN);
        }







        public int GetFinalAdvertisingProductsReport(DateTime _dt1, DateTime _dt2, List<int> _mpList, List<int> _prodList, List<int> _campList, List<string> _adgroupList)
        {
            string sqlStatement = "";

            sqlStatement = "SELECT * FROM [AdvertisingProducts] WHERE [UpdateDate] between '" + _dt1.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + _dt2.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            
            if (_mpList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([MarketPlaceId] = " + _mpList[0] + ")";
            }
            else if (_mpList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([MarketPlaceId] = " + _mpList[0];

                for (int i = 1; i < _mpList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [MarketPlaceId] = " + _mpList[i];
                }

                sqlStatement = sqlStatement + ")";
            }

            if (_prodList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([ProductId] = " + _prodList[0] + ")";
            }
            else if (_prodList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([ProductId] = " + _prodList[0];

                for (int i = 1; i < _prodList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [ProductId] = " + _prodList[i];
                }

                sqlStatement = sqlStatement + ")";
            }

            if (_campList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([CampaignId] = " + _campList[0] + ")";
            }
            else if (_campList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([CampaignId] = " + _campList[0];

                for (int i = 1; i < _campList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [CampaignId] = " + _campList[i];
                }

                sqlStatement = sqlStatement + ")";
            }
            //-------
            if (_adgroupList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([AdGroupName] = '" + _adgroupList[0] + "')";
            }
            else if (_adgroupList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([AdGroupName] = '" + _adgroupList[0] + "'";

                for (int i = 1; i < _adgroupList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [AdGroupName] = '" + _adgroupList[i] + "'";
                }

                sqlStatement = sqlStatement + ")";
            }

            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command_ProductsBrands(command, "p");
        }


        public int GetFinalAdvertisingBrandsReport(DateTime _dt1, DateTime _dt2, List<int> _mpList, List<int> _prodList, List<int> _campList)
        {
            string sqlStatement = "";

            sqlStatement = "SELECT * FROM [AdvertisingBrands] WHERE [UpdateDate] between '" + _dt1.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + _dt2.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            if (_mpList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([MarketPlaceId] = " + _mpList[0] + ")";
            }
            else if (_mpList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([MarketPlaceId] = " + _mpList[0];

                for (int i = 1; i < _mpList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [MarketPlaceId] = " + _mpList[i];
                }

                sqlStatement = sqlStatement + ")";
            }

            if (_prodList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([ProductId1] = " + _prodList[0] + " or [ProductId2] = " + _prodList[0] + " or [ProductId3] = " + _prodList[0] + ")";
            }
            else if (_prodList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "(([ProductId1] = " + _prodList[0] + " or [ProductId2] = " + _prodList[0] + " or [ProductId3] = " + _prodList[0] + ")";

                for (int i = 1; i < _prodList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or ([ProductId1] = " + _prodList[i] + " or [ProductId2] = " + _prodList[i] + " or [ProductId3] = " + _prodList[i] + ")";
                }

                sqlStatement = sqlStatement + ")";
            }

            if (_campList.Count == 1)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([CampaignId] = " + _campList[0] + ")";
            }
            else if (_campList.Count >= 2)
            {
                sqlStatement = sqlStatement + " and ";
                sqlStatement = sqlStatement + "([CampaignId] = " + _campList[0];

                for (int i = 1; i < _campList.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [CampaignId] = " + _campList[i];
                }

                sqlStatement = sqlStatement + ")";
            }

            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command_ProductsBrands(command, "b");
        }



        public int GetAdvertisingProducts()
        {
            string sqlStatement = "SELECT * FROM [AdvertisingProducts]";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command_ProductsBrands(command, "p");
        }

        public int GetAdvertisingBrands()
        {
            string sqlStatement = "SELECT * FROM [AdvertisingBrands]";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command_ProductsBrands(command, "b");
        }


        public int GetAdvertisingProductsCampaignAndCampId(List<int> _id)
        {
            string sqlStatement = "";
            if (_id.Count == 0)
                return 0;
            else if (_id.Count == 1)
                sqlStatement = "SELECT CampaignName, CampaignId FROM [AdvertisingProducts] WHERE [ProductId] = " + _id[0];
            else if (_id.Count >= 2)
            {
                sqlStatement = "SELECT CampaignName, CampaignId FROM [AdvertisingProducts] WHERE ([ProductId] = " + _id[0];

                for (int i = 1; i < _id.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [ProductId] = " + _id[i];
                }

                sqlStatement = sqlStatement + ")";
            }

            //List<listElement> campList = new List<listElement> { };
            List<CmapaignAndIdStruct> campList = new List<CmapaignAndIdStruct> { };
            command = new SqlCommand(sqlStatement, connection);
            List<MapNameId> nameIdList = new List<MapNameId> { };
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDataRecord record = (IDataRecord)reader;
                        campList.Add(new CmapaignAndIdStruct());
                        campList[campList.Count - 1].Key = record[0].ToString();
                        campList[campList.Count - 1].Val = int.Parse(record[1].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlAdvertisingReportFilterView != null)
                    controlAdvertisingReportFilterView.GetCampaignsAndIds(campList);
                else if (controlReportSessionsView != null)
                    controlReportSessionsView.GetCampaignsAndIds(campList);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }


        public int GetAdvertisingProductsAdgroups(List<int> _id, List<string> _checkedCampaigns)
        {
            string sqlStatement = "";
            if (_id.Count == 0)
                return 0;
            else if (_id.Count == 1)
                sqlStatement = "SELECT AdGroupName FROM [AdvertisingProducts] WHERE [ProductId] = " + _id[0];
            else if (_id.Count >= 2)
            {
                sqlStatement = "SELECT AdGroupName FROM [AdvertisingProducts] WHERE ([ProductId] = " + _id[0];

                for (int i = 1; i < _id.Count; i++)
                {
                    sqlStatement = sqlStatement + " or [ProductId] = " + _id[i];
                }

                sqlStatement = sqlStatement + ")";
            }
            if (_checkedCampaigns.Count > 0)
            {
                if (_checkedCampaigns.Count == 1)
                    sqlStatement = sqlStatement + " and [CampaignName] = '" + _checkedCampaigns[0] + "'";
                else
                {
                    sqlStatement = sqlStatement + " and ([CampaignName] = '" + _checkedCampaigns[0] + "'";

                    for (int i = 1; i < _checkedCampaigns.Count; i++)
                    {
                        sqlStatement = sqlStatement + " or [CampaignName] = '" + _checkedCampaigns[i] + "'";
                    }

                    sqlStatement = sqlStatement + ")";
                }
            }
            

            List<string> adGroups = new List<string> { };
            
            command = new SqlCommand(sqlStatement, connection);
            
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDataRecord record = (IDataRecord)reader;
                        adGroups.Add(record[0].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlAdvertisingReportFilterView != null)
                    controlAdvertisingReportFilterView.GetAdGroups(adGroups);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        public int GetAdvertisingProductsAdgroups(int _id, string _checkedCampaign)
        {
            string sqlStatement = "";
            
            sqlStatement = "SELECT AdGroupName FROM [AdvertisingProducts] WHERE [ProductId] = " + _id + " and [CampaignName] = '" + _checkedCampaign + "'";
            
            List<string> adGroups = new List<string> { };

            command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDataRecord record = (IDataRecord)reader;
                        adGroups.Add(record[0].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlAdvertisingReportFilterView != null)
                    controlAdvertisingReportFilterView.GetAdGroups(adGroups);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        public int GetAdvertisingBrandsCampaignAndCampId(List<int> _id)
        {
            string sqlStatement = "";
            if (_id.Count == 0)
                return 0;
            else if (_id.Count == 1)
                sqlStatement = "SELECT CampaignName, CampaignId FROM [AdvertisingBrands] WHERE [ProductId1] = " + _id[0] + "or [ProductId2] = " + _id[0] + "or [ProductId3] = " + _id[0];
            else if (_id.Count >= 2)
            {
                sqlStatement = "SELECT CampaignName, CampaignId FROM [AdvertisingBrands] WHERE (([ProductId1] = " + _id[0] + "or [ProductId2] = " + _id[0] + "or [ProductId3] = " + _id[0] + ")";

                for (int i = 1; i < _id.Count; i++)
                {
                    sqlStatement = sqlStatement + " or ([ProductId1] = " + _id[i] + "or [ProductId2] = " + _id[i] + "or [ProductId3] = " + _id[i] + ")";
                }

                sqlStatement = sqlStatement + ")";
            }

            //List<listElement> campList = new List<listElement> { };
            List<CmapaignAndIdStruct> campList = new List<CmapaignAndIdStruct> { };
            command = new SqlCommand(sqlStatement, connection);
            List<MapNameId> nameIdList = new List<MapNameId> { };
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDataRecord record = (IDataRecord)reader;
                        campList.Add(new CmapaignAndIdStruct());
                        campList[campList.Count - 1].Key = record[0].ToString();
                        campList[campList.Count - 1].Val = int.Parse(record[1].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlAdvertisingReportFilterView != null)
                    controlAdvertisingReportFilterView.GetCampaignsAndIds(campList);
                else if (controlReportSessionsView != null)
                    controlReportSessionsView.GetCampaignsAndIds(campList);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }


        public int GetAP_CampaignIds()
        {
            string sqlStatement = "SELECT * FROM [AP_CampaignIds]";

            command = new SqlCommand(sqlStatement, connection);
            List<MapNameId> nameIdList = new List<MapNameId> { };
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDataRecord record = (IDataRecord)reader;

                        MapNameId nameIdModel = new MapNameId();
                        nameIdList.Add(nameIdModel);
                        for (int i = 0; i < record.FieldCount; i++)
                        {
                            nameIdList[nameIdList.Count - 1].WriteData(i, record[i]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlAdvertisingUploadReportView != null)
                    controlAdvertisingUploadReportView.GetAP_CampaignIdsFromDB(nameIdList);
                else if (controlReportSessionsView != null)
                    controlReportSessionsView.GetAP_CampaignIdsFromDB(nameIdList);
                else if (controlAdvertisingReportFilterView != null)
                    controlAdvertisingReportFilterView.GetAP_CampaignIdsFromDB(nameIdList);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }
        
        public int GetAB_CampaignIds()
        {
            string sqlStatement = "SELECT * FROM [AB_CampaignIds]";

            command = new SqlCommand(sqlStatement, connection);
            List<MapNameId> nameIdList = new List<MapNameId> { };
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDataRecord record = (IDataRecord)reader;

                        MapNameId nameIdModel = new MapNameId();
                        nameIdList.Add(nameIdModel);
                        for (int i = 0; i < record.FieldCount; i++)
                        {
                            nameIdList[nameIdList.Count - 1].WriteData(i, record[i]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (controlAdvertisingUploadReportView != null)
                    controlAdvertisingUploadReportView.GetAB_CampaignIdsFromDB(nameIdList);
                else if (controlReportSessionsView != null)
                    controlReportSessionsView.GetAB_CampaignIdsFromDB(nameIdList);

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }

        public int UpdateAdvertising_Product_Report(List<AdvertisingProductsModel> _apm)
        {
            string specifier = "G";
            List<AdvertisingProductsModel> apm = _apm;

            for (int i = 0; i < apm.Count; i++)
            {
                string sqlStatement = "UPDATE [AdvertisingProducts] SET [Impressions] = " + apm[i].Impressions + ", [Clicks] = " + apm[i].Clicks + ", [CTR] = " + apm[i].CTR.ToString(specifier, CultureInfo.InvariantCulture) + ", [CPC] = " + apm[i].CPC.ToString(specifier, CultureInfo.InvariantCulture) + ", [Spend] = " + apm[i].Spend.ToString(specifier, CultureInfo.InvariantCulture) + ", [ACoS] = " + apm[i].ACoS.ToString(specifier, CultureInfo.InvariantCulture) + ", [RoAS] = " + apm[i].RoAS.ToString(specifier, CultureInfo.InvariantCulture) + ", [Sales] = " + apm[i].Sales.ToString(specifier, CultureInfo.InvariantCulture) + ", [Orders] = " + apm[i].Orders + ", [Units] = " + apm[i].Units + ", [ConversionRate] = " + apm[i].ConversionRate.ToString(specifier, CultureInfo.InvariantCulture) + ", [AdvSKUUnits] = " + apm[i].AdvSKUUnits + ", [OtherSKUUnits] = " + apm[i].OtherSKUUnits + ", [AdvSKUSales] = " + apm[i].AdvSKUSales.ToString(specifier, CultureInfo.InvariantCulture) + ", [OtherSKUSales] = " + apm[i].OtherSKUSales.ToString(specifier, CultureInfo.InvariantCulture) + " WHERE [UpdateDate] = '" + apm[i].UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND [CampaignId] = " + apm[i].CampaignId + " AND [AdGroupName] = '" + apm[i].AdGroupName + "' AND [MatchType] = '" + apm[i].MatchType + "' AND [Targeting] = '" + apm[i].Targeting + "'";
                command = new SqlCommand(sqlStatement, connection);
                if (Execute_UPDATE_DELETE_INSERT_Command(command) != 1)
                    return -1;
            }
            return 1;
        }

        public int UpdateAdvertising_Brands_Report(List<AdvertisingBrandsModel> _abm)
        {
            string specifier = "G";
            List<AdvertisingBrandsModel> abm = _abm;

            for (int i = 0; i < abm.Count; i++)
            {
                string sqlStatement = "UPDATE [AdvertisingBrands] SET [Impressions] = " + abm[i].Impressions + ", [Clicks] = " + abm[i].Clicks + ", [CTR] = " + abm[i].CTR.ToString(specifier, CultureInfo.InvariantCulture) + ", [CPC] = " + abm[i].CPC.ToString(specifier, CultureInfo.InvariantCulture) + ", [Spend] = " + abm[i].Spend.ToString(specifier, CultureInfo.InvariantCulture) + ", [ACoS] = " + abm[i].ACoS.ToString(specifier, CultureInfo.InvariantCulture) + ", [RoAS] = " + abm[i].RoAS.ToString(specifier, CultureInfo.InvariantCulture) + ", [Sales] = " + abm[i].Sales.ToString(specifier, CultureInfo.InvariantCulture) + ", [Orders] = " + abm[i].Orders + ", [Units] = " + abm[i].Units + ", [ConversionRate] = " + abm[i].ConversionRate.ToString(specifier, CultureInfo.InvariantCulture) + ", [NewToBrandOrders] = " + abm[i].NewToBrandOrders + ", [NewToBrandSales] = " + abm[i].NewToBrandSales.ToString(specifier, CultureInfo.InvariantCulture) + ", [NewToBrandUnits] = " + abm[i].NewToBrandUnits + ", [NewToBrandOrderRate] = " + abm[i].NewToBrandOrderRate.ToString(specifier, CultureInfo.InvariantCulture) + " WHERE [UpdateDate] = '" + abm[i].UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND [CampaignId] = " + abm[i].CampaignId + " AND [MatchType] = '" + abm[i].MatchType + "' AND [Targeting] = '" + abm[i].Targeting + "'";
                command = new SqlCommand(sqlStatement, connection);
                if (Execute_UPDATE_DELETE_INSERT_Command(command) != 1)
                    return -1;
            }
            return 1;
        }

        public int InsertAdvertising_Product_Report(List<AdvertisingProductsModel> _apm)
        {
            string specifier = "G";
            List<AdvertisingProductsModel> apm = _apm;

            for (int i = 0; i < apm.Count; i++)
            {
                string sqlStatement = "INSERT INTO [AdvertisingProducts] ([UpdateDate], [CurrencyCharCode], [CampaignName], [AdGroupName], [Targeting], [MatchType], [Impressions], [Clicks], [CTR], [CPC], [Spend], [ACoS], [RoAS], [Sales], [Orders], [Units], [ConversionRate], [AdvSKUUnits], [OtherSKUUnits], [AdvSKUSales], [OtherSKUSales], [CampaignTypeId], [MarketPlaceId], [CampaignId], [ProductId]) VALUES ('" + apm[i].UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + apm[i].CurrencyCharCode + "', '" + apm[i].CampaignName + "', '" + apm[i].AdGroupName + "', '" + apm[i].Targeting + "', '" + apm[i].MatchType + "', " + apm[i].Impressions + ", " + apm[i].Clicks + ", " + apm[i].CTR.ToString(specifier, CultureInfo.InvariantCulture) + ", " + apm[i].CPC.ToString(specifier, CultureInfo.InvariantCulture) + ", " + apm[i].Spend.ToString(specifier, CultureInfo.InvariantCulture) + ", " + apm[i].ACoS.ToString(specifier, CultureInfo.InvariantCulture) + ", " + apm[i].RoAS.ToString(specifier, CultureInfo.InvariantCulture) + ", " + apm[i].Sales.ToString(specifier, CultureInfo.InvariantCulture) + ", " + apm[i].Orders + ", " + apm[i].Units + ", " + apm[i].ConversionRate.ToString(specifier, CultureInfo.InvariantCulture) + ", " + apm[i].AdvSKUUnits + ", " + apm[i].OtherSKUUnits + ", " + apm[i].AdvSKUSales.ToString(specifier, CultureInfo.InvariantCulture) + ", " + apm[i].OtherSKUSales.ToString(specifier, CultureInfo.InvariantCulture) + ", " + apm[i].CampaignTypeId + ", " + apm[i].MarketPlaceId + ", " + apm[i].CampaignId + ", " + apm[i].ProductId + ")";
                command = new SqlCommand(sqlStatement, connection);
                if (Execute_UPDATE_DELETE_INSERT_Command(command) != 1)
                    return 0;
            }
            return 1;
        }


        public int InsertAdvertising_Brand_Report(List<AdvertisingBrandsModel> _abm)
        {
            string specifier = "G";
            List<AdvertisingBrandsModel> abm = _abm;

            for (int i = 0; i < abm.Count; i++)
            {
                string sqlStatement = "INSERT INTO [AdvertisingBrands] ([UpdateDate], [CurrencyCharCode], [CampaignName], [Targeting], [MatchType], [Impressions], [Clicks], [CTR], [CPC], [Spend], [ACoS], [RoAS], [Sales], [Orders], [Units], [ConversionRate], [NewToBrandOrders], [NewToBrandSales], [NewToBrandUnits], [NewToBrandOrderRate], [CampaignTypeId], [MarketPlaceId], [CampaignId], [ProductId1], [ProductId2], [ProductId3]) VALUES ('" + abm[i].UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + abm[i].CurrencyCharCode + "', '" + abm[i].CampaignName + "', '" + abm[i].Targeting + "', '" + abm[i].MatchType + "', " + abm[i].Impressions + ", " + abm[i].Clicks + ", " + abm[i].CTR.ToString(specifier, CultureInfo.InvariantCulture) + ", " + abm[i].CPC.ToString(specifier, CultureInfo.InvariantCulture) + ", " + abm[i].Spend.ToString(specifier, CultureInfo.InvariantCulture) + ", " + abm[i].ACoS.ToString(specifier, CultureInfo.InvariantCulture) + ", " + abm[i].RoAS.ToString(specifier, CultureInfo.InvariantCulture) + ", " + abm[i].Sales.ToString(specifier, CultureInfo.InvariantCulture) + ", " + abm[i].Orders + ", " + abm[i].Units + ", " + abm[i].ConversionRate.ToString(specifier, CultureInfo.InvariantCulture) + ", " + abm[i].NewToBrandOrders + ", " + abm[i].NewToBrandSales.ToString(specifier, CultureInfo.InvariantCulture) + ", " + abm[i].NewToBrandUnits + ", " + abm[i].NewToBrandOrderRate.ToString(specifier, CultureInfo.InvariantCulture) + ", " + abm[i].CampaignTypeId + ", " + abm[i].MarketPlaceId + ", " + abm[i].CampaignId + ", " + abm[i].ProductId1 + ", " + abm[i].ProductId2 + ", " + abm[i].ProductId3 + ")";
                command = new SqlCommand(sqlStatement, connection);
                if (Execute_UPDATE_DELETE_INSERT_Command(command) != 1)
                    return 0;
            }
            return 1;
        }

        public int InsertAP_CampaignId(int _id, string _name)
        {
            string sqlStatement = "INSERT INTO [AP_CampaignIds] ([CampaignId], [CampaignName]) VALUES (" + _id + ", '" + _name + "')";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
        }

        public int InsertAB_CampaignId(int _id, string _name)
        {
            string sqlStatement = "INSERT INTO [AB_CampaignIds] ([CampaignId], [CampaignName]) VALUES (" + _id + ", '" + _name + "')";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_UPDATE_DELETE_INSERT_Command(command);
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



        /* Выполняем запрос к БД и заносим полученные данные в  */
        private int Execute_SELECT_Command_ProductsBrands(SqlCommand _command, string s)
        {
            advprodList = new List<AdvertisingProductsModel> { };
            advprodListOriginal = new List<AdvertisingProductsModel> { };
            advbrandList = new List<AdvertisingBrandsModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (s.Equals("p"))
                    {
                        while (reader.Read())
                        {
                            SetSponsoredProductsToList((IDataRecord)reader);
                        }
                    }
                    else if (s.Equals("b"))
                    {
                        while (reader.Read())
                        {
                            SetSponsoredBrandsToList((IDataRecord)reader);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (s.Equals("p"))
                {
                    if (controlAdvertisingReportFilterView != null)
                    {
                        controlAdvertisingReportFilterView.GetAdvertisingProductsFromDBOriginalValues(advprodListOriginal);
                        controlAdvertisingReportFilterView.GetAdvertisingProductsFromDBwithSummary(advprodList);
                    }
                    else if (controlReportSessionsView != null)
                        controlReportSessionsView.GetAdvertisingProductsFromDB(advprodList);
                }
                else if (s.Equals("b"))
                {
                    if (controlAdvertisingReportFilterView != null)
                        controlAdvertisingReportFilterView.GetAdvertisingBrandsFromDB(advbrandList);
                    else if (controlReportSessionsView != null)
                        controlReportSessionsView.GetAdvertisingBrandsFromDB(advbrandList);
                }

                return 1;
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.HResult;
            }
        }


        /* Заносим данные в List<AdvertisingProductsModel> */
        private void SetSponsoredProductsToList(IDataRecord record)
        {
            AdvertisingProductsModel adprModel = new AdvertisingProductsModel();
            advprodList.Add(adprModel);
            advprodListOriginal.Add(adprModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                advprodList[advprodList.Count - 1].WriteData(i, record[i]);
                advprodListOriginal[advprodListOriginal.Count - 1].WriteData(i, record[i]);
            }
        }

        /* Заносим данные в List<AdvertisingBrandsModel> */
        private void SetSponsoredBrandsToList(IDataRecord record)
        {
            AdvertisingBrandsModel adbrandModel = new AdvertisingBrandsModel();
            advbrandList.Add(adbrandModel);
            for (int i = 0; i < record.FieldCount; i++)
            {
                advbrandList[advbrandList.Count - 1].WriteData(i, record[i]);
            }
        }        
    }
}






/* Получаем уникальный индентификатор типа INT с названия кампании/группы*/
/*
           
private int GetIdFromString(string t)
{

    //List<string> testList = new List<string> { "PDW - AUTO", "PDW - exact_HIGH", "Y-Connector Research", "PDW - Broad", "YouMic - exact", "Y-Connector - AUTO - start 16.11.2017", "Youmic - AUTO 16.11.2017 start", "PDW - copy Royal Voice", "Youmic - Phrase", "PDW - Phrase", "Dual P - Phrase", "Dual Y - AUTO", "Dual Y - Phrase", "Android - Broad", "Dual Y - High", "Y-connector - Exact high", "PDW - Target Manual", "Youmic - high", "Dual P - High", "Dual P  - Broad", "Dual Y - MEDIUM", "PDW - exact_LOW", "Type-C - AUTO", "Dual Y - Broad", "PDW - Categories", "Dual Y - Target Manual", "Dual P - Categories", "Dual P - Target Manual", "Android - Phrase", "Android - Auto", "Type-C - Broad", "Video Mic - Broad", "Video Mic - AUTO", "Dual P - Display", "Vloger Kit - AUTO", "Vloger Kit - Phrase", "Video Mic - Phrase", "Vloger Kit - Broad", "Youmic - Display", "Vlogger Kit - Display", "Video Mic - Target manual", "Video Mic - Target Auto", "Dual P - Target Auto", "Type-C - Phrase", "Youmic Lightning - Phrase", "Youmic Lightning - AUTO", "Youmic Lightning - Broad" };

    int MUST_BE_LESS_THAN = 100000000; // 8 decimal digits

    uint hash = 0;
    // if you care this can be done much faster with unsafe 
    // using fixed char* reinterpreted as a byte*
    foreach (byte b in System.Text.Encoding.Unicode.GetBytes(t))
    {
        hash += b;
        hash += (hash << 10);
        hash ^= (hash >> 6);
    }
    // final avalanche
    hash += (hash << 3);
    hash ^= (hash >> 11);
    hash += (hash << 15);
    // helpfully we only want positive integer < MUST_BE_LESS_THAN
    // so simple truncate cast is ok if not perfect                

    return (int)(hash % MUST_BE_LESS_THAN);
}



  */
