using System;
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

        public MarketplaceController(ProductsView _mf)
        {
            connection = DBData.GetDBConnection();
            controlProductsView = _mf;
        }

        public int GetMarketplaces()
        {
            string sqlStatement = "SELECT * FROM Marketplace WHERE MarketPlaceId > 0";
            command = new SqlCommand(sqlStatement, connection);
            return Execute_SELECT_Command(command);
        }

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
