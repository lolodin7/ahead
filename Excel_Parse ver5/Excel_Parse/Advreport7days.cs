using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    class Advreport7days
    {
        private SqlConnection connection;
        private SqlCommand command;

        private List<AdvertisingProductsModel> advProductsListNew;
        private List<AdvertisingProductsModel> summaryAdvProductsListNew;

        private List<AdvertisingProductsModel> advProductsListOld;
        private List<AdvertisingProductsModel> summaryAdvProductsListOld;

        private List<AdvertisingProductsModel> advProductsListTmp;
        private List<AdvertisingProductsModel> advProductsListFinal;

        private ProductsController prodControl;
        private MarketplaceController marketplaceControl;

        private List<string> resultString;
        private List<ReportObject> resultList;

        private DateTime startNew, endNew, startOld, endOld;
        private List<MarketplaceModel> mpList;
        private List<ProductsModel> pList;
        SaveFileDialog saveFileDialog1;

        private List<AdvertisingProductsModel> advprodList;

        private struct listElement
        {
            public string key { get; set; }
            public double val { get; set; }
        }

        public Advreport7days()
        {
            connection = DBData.GetDBConnection();

            advProductsListNew = new List<AdvertisingProductsModel> { };
            summaryAdvProductsListNew = new List<AdvertisingProductsModel> { };

            advProductsListOld = new List<AdvertisingProductsModel> { };
            summaryAdvProductsListOld = new List<AdvertisingProductsModel> { };

            advProductsListTmp = new List<AdvertisingProductsModel> { };
            resultString = new List<string> { };

            mpList = new List<MarketplaceModel> { };
            pList = new List<ProductsModel> { };

            resultList = new List<ReportObject> { };

            prodControl = new ProductsController(this);
            prodControl.GetProductsAllJOIN();

            marketplaceControl = new MarketplaceController(this);
            marketplaceControl.GetMarketplaces();

            saveFileDialog1 = new SaveFileDialog();

            PrepareDatesList();
            GetAdvertisingData();
            GetDiffValues();
            GetUniqueValues();

            //for (int i = 0; i < resultList.Count; i++)
            //{
            //    Console.Write(resultList[i].prodName+ "," + resultList[i].marketplace + "," + resultList[i].campName + "," + resultList[i].adGroup + "," + resultList[i].targeting + ", " + resultList[i].matchType + "," + resultList[i].valOld + "," + resultList[i].valNew + "," + resultList[i].diff + "," + resultList[i].diffPerc + "\n");
            //}
            CreateExcelFile();
        }

        private void CreateExcelFile()
        {
            bool okData = false;
            string path = "D:\\";
            string fileName = "";

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);


            ExcelApp.Cells[1, 1] = "Товар";
            ExcelApp.Cells[1, 2] = "Маркетплейс";
            ExcelApp.Cells[1, 3] = "Campaign";
            ExcelApp.Cells[1, 4] = "AdGroup";
            ExcelApp.Cells[1, 5] = "Targeting";
            ExcelApp.Cells[1, 6] = "Match Type";
            ExcelApp.Cells[1, 7] = "Позапрошлая неделя";
            ExcelApp.Cells[1, 8] = "Прошлая неделя";
            ExcelApp.Cells[1, 9] = "Разница";
            ExcelApp.Cells[1, 10] = "Разница %";

            if (resultList.Count > 0)
            {
                for (int i = 0; i < resultList.Count; i++)
                {
                    for (int j = 0; j < resultList[0].ColumnCount; j++)
                    {
                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 5)
                            ExcelApp.Cells[i + 2, j + 1] = resultList[i].GetVal(j).ToString();
                        else if (j == 6 || j == 7 || j == 8)
                            ExcelApp.Cells[i + 2, j + 1] = (int)resultList[i].GetVal(j);
                        else if (j == 9)
                            ExcelApp.Cells[i + 2, j + 1] = Math.Round((double)resultList[i].GetVal(j), 2);
                    }
                }

                //fileName = startNew + "-" + endNew + " Advertising Alarm Report";
                fileName = "Advertising Alarm Report - " + startNew.ToString("dd-MM-yyyy") + "-" + endNew.ToString("dd-MM-yyyy") +  " (" + DateTime.Now.ToString("HH-mm-ss") + ")";

                okData = true;
            }

            if (okData)
            {
                //if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                //{
                //    ExcelWorkBook.Close(false);
                //}
                //else
                //{
                    path = path + fileName;
                    //получаем выбранный файл
                    //string filename = saveFileDialog1.FileName;
                    ExcelWorkBook.SaveAs(@path);
                    ExcelWorkBook.Close(false);
                //}
            }
        }

        public int Generate()
        {
            return 1;
        }

        private void GetAdvertisingData()
        {
            string sqlStatement = "";

            sqlStatement = "SELECT * FROM [AdvertisingProducts] WHERE [UpdateDate] between '" + startNew.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endNew.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            command = new SqlCommand(sqlStatement, connection);
            Execute_SELECT_Command_ProductsBrands(command, "new");

            sqlStatement = "SELECT * FROM [AdvertisingProducts] WHERE [UpdateDate] between '" + startOld.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + endOld.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            command = new SqlCommand(sqlStatement, connection);
            Execute_SELECT_Command_ProductsBrands(command, "old");
        }

        private void GetDiffValues()
        {
            int imprNew = 0;
            int imprOld = 0;
            int imprDiff = 0;
            double percDiff = 0;

            for (int i = 0; i < advProductsListNew.Count; i++)
            {
                for (int j = 0; j < advProductsListOld.Count; j++)
                {
                    if (advProductsListNew[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListNew[i].Targeting.Equals(advProductsListOld[j].Targeting) && advProductsListNew[i].MatchType.Equals(advProductsListOld[j].MatchType))
                    {
                        imprNew = advProductsListNew[i].Impressions;
                        imprOld = advProductsListOld[j].Impressions;
                        imprDiff = advProductsListNew[i].Impressions - advProductsListOld[j].Impressions;
                        if (advProductsListOld[j].Impressions != 0)
                            percDiff = ((double) imprDiff / advProductsListOld[j].Impressions) * 100;
                        else
                            percDiff = (double)advProductsListNew[i].Impressions;
                        if (percDiff >= 20 || percDiff <= -20)
                        {
                            ReportObject tmp = new ReportObject();
                            tmp.prodName = GetProductNameById(advProductsListNew[i].ProductId);
                            tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId);
                            tmp.campName = advProductsListNew[i].CampaignName;
                            tmp.adGroup = advProductsListNew[i].AdGroupName;
                            tmp.targeting = advProductsListNew[i].Targeting;
                            tmp.matchType = advProductsListNew[i].MatchType;
                            tmp.valOld = advProductsListOld[j].Impressions;
                            tmp.valNew = advProductsListNew[i].Impressions;
                            tmp.diff = imprDiff;
                            tmp.diffPerc = percDiff;

                            resultList.Add(tmp);



                            //resultString.Add("Товар: " + GetProductNameById(advProductsListNew[i].ProductId) + ", Кампания: " + advProductsListNew[i].CampaignName + ", AdGroup: " + advProductsListNew[i].AdGroupName + ", Targeting: " + advProductsListNew[i].Targeting + ", Match Type: " + advProductsListNew[i].MatchType + ", Разница: " + imprDiff + " (" + percDiff + "%), Маркетплейс: " + GetMarketplaceNameByMarketplaceId(advProductsListNew[i].MarketPlaceId) + "\n");
                        }
                        imprNew = 0;
                        imprOld = 0;
                        imprDiff = 0;
                        percDiff = 0;
                    }
                }
            }

            for (int i = 0; i < advProductsListOld.Count; i++)
            {
                for (int j = 0; j < advProductsListNew.Count; j++)
                {
                    if (advProductsListOld[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListOld[i].Targeting.Equals(advProductsListNew[j].Targeting) && advProductsListOld[i].MatchType.Equals(advProductsListNew[j].MatchType))
                    {
                        imprNew = advProductsListNew[j].Impressions;
                        imprOld = advProductsListOld[i].Impressions;
                        imprDiff = advProductsListNew[j].Impressions - advProductsListOld[i].Impressions;
                        if (advProductsListOld[i].Impressions != 0)
                            percDiff = ((double) imprDiff / advProductsListOld[i].Impressions) * 100;
                        else
                            percDiff = (double)advProductsListNew[j].Impressions;
                        if (percDiff >= 20 || percDiff <= -20)
                        {
                            ReportObject tmp = new ReportObject();
                            tmp.prodName = GetProductNameById(advProductsListNew[j].ProductId);
                            tmp.marketplace = GetMarketplaceNameByMarketplaceId(advProductsListNew[j].MarketPlaceId);
                            tmp.campName = advProductsListNew[j].CampaignName;
                            tmp.adGroup = advProductsListNew[j].AdGroupName;
                            tmp.targeting = advProductsListNew[j].Targeting;
                            tmp.matchType = advProductsListNew[j].MatchType;
                            tmp.valOld = advProductsListOld[i].Impressions;
                            tmp.valNew = advProductsListNew[j].Impressions;
                            tmp.diff = imprDiff;
                            tmp.diffPerc = percDiff;

                            resultList.Add(tmp);
                        }
                        imprNew = 0;
                        imprOld = 0;
                        imprDiff = 0;
                        percDiff = 0;
                    }
                }
            }
        }

        private void GetUniqueValues()
        {
            for (int i = 0; i < resultList.Count - 1; i++)
            {
                for (int j = 1; j < resultList.Count; j++)
                {
                    if (resultList[i].campName.Equals(resultList[j].campName) && resultList[i].adGroup.Equals(resultList[j].adGroup) && resultList[i].targeting.Equals(resultList[j].targeting) && resultList[i].matchType.Equals(resultList[j].matchType) && resultList[i].marketplace.Equals(resultList[j].marketplace) && resultList[i].valOld == resultList[j].valOld && resultList[i].valNew == resultList[j].valNew && resultList[i].diff == resultList[j].diff)
                    {
                        resultList.RemoveAt(j);
                    }
                }
            }
        }

        private void PrepareDatesList()
        {
            DateTime today = DateTime.Today;
            DateTime tmp = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);

            startNew = tmp.AddDays(-7);
            endNew = tmp.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);

            startOld = startNew.AddDays(-7);
            endOld = endNew.AddDays(-7);
        }


        /* Выполняем запрос к БД и заносим полученные данные в  */
        private int Execute_SELECT_Command_ProductsBrands(SqlCommand _command, string _mode)
        {
            advprodList = new List<AdvertisingProductsModel> { };
            try
            {
                connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetSponsoredProductsToList((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();

                if (_mode.Equals("new"))
                {
                    advProductsListNew = advprodList;
                    MakeSummaryAdvProductListNew();
                }
                else if (_mode.Equals("old"))
                {
                    advProductsListOld = advprodList;
                    MakeSummaryAdvProductListOld();
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
            for (int i = 0; i < record.FieldCount; i++)
            {
                advprodList[advprodList.Count - 1].WriteData(i, record[i]);
            }
        }

        /* Удаляем все повторы с advProductsListNew, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListNew()
        {
            List<int> alreadyUsed = new List<int> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsListNew.Count; i++)
            {
                if (i == advProductsListNew.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsListNew[i].Impressions;
                    Clicks = advProductsListNew[i].Clicks;
                    Spend = advProductsListNew[i].Spend;
                    Sales = advProductsListNew[i].Sales;
                    Orders = advProductsListNew[i].Orders;
                    Units = advProductsListNew[i].Units;
                    AdvSKUUnits = advProductsListNew[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsListNew[i].OtherSKUUnits;
                    AdvSKUSales = advProductsListNew[i].AdvSKUSales;
                    OtherSKUSales = advProductsListNew[i].OtherSKUSales;

                    if (i < (advProductsListNew.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsListNew.Count; j++)
                        {
                            if (advProductsListNew[i].CampaignName.Equals(advProductsListNew[j].CampaignName) && advProductsListNew[i].AdGroupName.Equals(advProductsListNew[j].AdGroupName) && advProductsListNew[i].Targeting.Equals(advProductsListNew[j].Targeting) && advProductsListNew[i].MatchType.Equals(advProductsListNew[j].MatchType))
                            {
                                Impressions += advProductsListNew[j].Impressions;
                                Clicks += advProductsListNew[j].Clicks;
                                Spend += advProductsListNew[j].Spend;
                                Sales += advProductsListNew[j].Sales;
                                Orders += advProductsListNew[j].Orders;
                                Units += advProductsListNew[j].Units;
                                AdvSKUUnits += advProductsListNew[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsListNew[j].OtherSKUUnits;
                                AdvSKUSales += advProductsListNew[j].AdvSKUSales;
                                OtherSKUSales += advProductsListNew[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }
                    //else
                    //{
                    //    Impressions += advProductsList[i].Impressions;
                    //    Clicks += advProductsList[i].Clicks;
                    //    Spend += advProductsList[i].Spend;
                    //    Sales += advProductsList[i].Sales;
                    //    Orders += advProductsList[i].Orders;
                    //    Units += advProductsList[i].Units;
                    //    AdvSKUUnits += advProductsList[i].AdvSKUUnits;
                    //    OtherSKUUnits += advProductsList[i].OtherSKUUnits;
                    //    AdvSKUSales += advProductsList[i].AdvSKUSales;
                    //    OtherSKUSales += advProductsList[i].OtherSKUSales;
                    //    alreadyUsed.Add(i);
                    //}
                    //summaryAdvProductsList.Add(ТО, ШО ПОЛУЧИЛОСЬ ОТ СУММИРОВАНИЯ + ДОПОЛНИТЕЛЬНО СЧИТАЕМ ТО, ЧТО НАДО ПОСЧИТАТЬ);

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsListNew.Add(new AdvertisingProductsModel());

                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].UpdateDate = advProductsListNew[i].UpdateDate;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CurrencyCharCode = advProductsListNew[i].CurrencyCharCode;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignName = advProductsListNew[i].CampaignName;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdGroupName = advProductsListNew[i].AdGroupName;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Targeting = advProductsListNew[i].Targeting;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].MatchType = advProductsListNew[i].MatchType;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Impressions = Impressions;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Clicks = Clicks;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Orders = Orders;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].Units = Units;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignTypeId = advProductsListNew[i].CampaignTypeId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].MarketPlaceId = advProductsListNew[i].MarketPlaceId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].CampaignId = advProductsListNew[i].CampaignId;
                    summaryAdvProductsListNew[summaryAdvProductsListNew.Count - 1].ProductId = advProductsListNew[i].ProductId;
                }
            }
            advProductsListNew.Clear();
            foreach (var t in summaryAdvProductsListNew)
            {
                advProductsListNew.Add(t);
            }
        }

        /* Удаляем все повторы с advProductsListOld, при этом создавая новый список с суммарными значениями */
        private void MakeSummaryAdvProductListOld()
        {
            List<int> alreadyUsed = new List<int> { };
            int Impressions;
            int Clicks;
            double Spend;
            double Sales;
            int Orders;
            int Units;
            int AdvSKUUnits;
            int OtherSKUUnits;
            double AdvSKUSales;
            double OtherSKUSales;
            double CTR = 0;
            double CPC = 0;
            double ACoS = 0;
            double RoAS = 0;
            double ConversionRate = 0;

            for (int i = 0; i < advProductsListOld.Count; i++)
            {
                if (i == advProductsListOld.Count - 1)
                {

                }
                if (!alreadyUsed.Contains(i))
                {
                    Impressions = advProductsListOld[i].Impressions;
                    Clicks = advProductsListOld[i].Clicks;
                    Spend = advProductsListOld[i].Spend;
                    Sales = advProductsListOld[i].Sales;
                    Orders = advProductsListOld[i].Orders;
                    Units = advProductsListOld[i].Units;
                    AdvSKUUnits = advProductsListOld[i].AdvSKUUnits;
                    OtherSKUUnits = advProductsListOld[i].OtherSKUUnits;
                    AdvSKUSales = advProductsListOld[i].AdvSKUSales;
                    OtherSKUSales = advProductsListOld[i].OtherSKUSales;

                    if (i < (advProductsListOld.Count - 1))
                    {
                        for (int j = i + 1; j < advProductsListOld.Count; j++)
                        {
                            if (advProductsListOld[i].CampaignName.Equals(advProductsListOld[j].CampaignName) && advProductsListOld[i].AdGroupName.Equals(advProductsListOld[j].AdGroupName) && advProductsListOld[i].Targeting.Equals(advProductsListOld[j].Targeting) && advProductsListOld[i].MatchType.Equals(advProductsListOld[j].MatchType))
                            {
                                Impressions += advProductsListOld[j].Impressions;
                                Clicks += advProductsListOld[j].Clicks;
                                Spend += advProductsListOld[j].Spend;
                                Sales += advProductsListOld[j].Sales;
                                Orders += advProductsListOld[j].Orders;
                                Units += advProductsListOld[j].Units;
                                AdvSKUUnits += advProductsListOld[j].AdvSKUUnits;
                                OtherSKUUnits += advProductsListOld[j].OtherSKUUnits;
                                AdvSKUSales += advProductsListOld[j].AdvSKUSales;
                                OtherSKUSales += advProductsListOld[j].OtherSKUSales;
                                alreadyUsed.Add(j);
                            }
                        }
                    }

                    if (Impressions != 0)
                        CTR = (double)Clicks / Impressions * 100;
                    else CTR = 0;

                    if (Clicks != 0)
                        CPC = Spend / Clicks;
                    else CPC = 0;

                    if (Sales != 0)
                        ACoS = (Spend / Sales) * 100;
                    else ACoS = 0;

                    if (Spend != 0)
                        RoAS = (Sales / Spend);
                    else RoAS = 0;

                    if (Clicks != 0)
                        ConversionRate = ((double)Orders / Clicks) * 100;
                    else ConversionRate = 0;


                    summaryAdvProductsListOld.Add(new AdvertisingProductsModel());

                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].UpdateDate = advProductsListOld[i].UpdateDate;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CurrencyCharCode = advProductsListOld[i].CurrencyCharCode;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignName = advProductsListOld[i].CampaignName;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdGroupName = advProductsListOld[i].AdGroupName;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Targeting = advProductsListOld[i].Targeting;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].MatchType = advProductsListOld[i].MatchType;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Impressions = Impressions;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Clicks = Clicks;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CTR = Math.Round(CTR, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CPC = Math.Round(CPC, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Spend = Math.Round(Spend, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Sales = Math.Round(Sales, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ACoS = Math.Round(ACoS, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].RoAS = Math.Round(RoAS, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Orders = Orders;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].Units = Units;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ConversionRate = Math.Round(ConversionRate, 2);
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdvSKUUnits = AdvSKUUnits;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].OtherSKUUnits = OtherSKUUnits;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].AdvSKUSales = AdvSKUSales;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].OtherSKUSales = OtherSKUSales;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignTypeId = advProductsListOld[i].CampaignTypeId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].MarketPlaceId = advProductsListOld[i].MarketPlaceId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].CampaignId = advProductsListOld[i].CampaignId;
                    summaryAdvProductsListOld[summaryAdvProductsListOld.Count - 1].ProductId = advProductsListOld[i].ProductId;
                }
            }
            advProductsListOld.Clear();
            foreach (var t in summaryAdvProductsListOld)
            {
                advProductsListOld.Add(t);
            }
        }

        private string GetMarketplaceNameByMarketplaceId(int _mpId)
        {
            int marketplaceId = (int)_mpId;

            foreach (var t in mpList)
            {
                if (t.MarketPlaceId == marketplaceId)
                    return t.MarketPlaceName;
            }
            return "NOT_FOUND";
        }

        private string GetProductNameById(int _productId)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ProductId == _productId)
                    return pList[i].Name;
            }
            return "";
        }

        /* Получаем из контроллера данные, полученные с БД */
        public void GetProductsFromDB(object _pList)
        {
            pList = (List<ProductsModel>)_pList;
        }

        /* Получаем из контроллера Marketplaces, полученные с БД */
        public void GetMarketPlacesFromDB(object _mpList)
        {
            mpList = (List<MarketplaceModel>)_mpList;
        }
    }

    class ReportObject
    {
        public string prodName { get; set; }
        public string marketplace { get; set; }
        public string campName { get; set; }
        public string adGroup { get; set; }
        public string targeting { get; set; }
        public string matchType { get; set; }
        public int valOld { get; set; }
        public int valNew { get; set; }
        public int diff { get; set; }
        public double diffPerc { get; set; }
        public int ColumnCount { get; set; }

        public ReportObject()
        {
            ColumnCount = 10;
        }

        public object GetVal(int id)
        {
            switch (id)
            {
                case 0:
                    return prodName;
                case 1:
                    return marketplace;
                case 2:
                    return campName;
                case 3:
                    return adGroup;
                case 4:
                    return targeting;
                case 5:
                    return matchType;
                case 6:
                    return valOld;
                case 7:
                    return valNew;
                case 8:
                    return diff;
                case 9:
                    return diffPerc;
                default:
                    return "NOT FOUND";
            }
        }
    }
}
