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
    class OldSemCoreList
    {
        private int colcnt = 7;         //количество полей в таблице БД

        public int CategoryId { get; set; }
        public int ProductTypeId { get; set; }
        public string Keyword { get; set; } //width 250
        public int Value { get; set; }      //width 100
        public string Name { get; set; }
        public int SemCoreId { get; set; }
        public int ColumnCount { get; }

        private SqlConnection connection;
        private DataGridView dgv;
        private SqlCommand command;
        public List<OldSemCoreList> scl;

        public OldSemCoreList(DataGridView _dgv)
        {
            connection = DBData.GetDBConnection();
            ColumnCount = colcnt;
            dgv = _dgv;

            
        }

        public OldSemCoreList()
        {

        }

        public void AddColumns()
        {
            dgv.Columns.Add("categoryIdCl", "categoryIdCl");
            dgv.Columns.Add("productTypeIdCl", "productTypeIdCl");
            dgv.Columns.Add("keywordCl", "keywordCl");
            dgv.Columns.Add("valueCl", "valueCl");
            dgv.Columns.Add("LastUpdatedCl", "LastUpdatedCl");
            dgv.Columns.Add("semCoreIdCl", "semCoreIdCl");

            dgv.Columns[2].Width = 250;
            dgv.Columns[3].Width = 100;

            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[5].Visible = false;

            dgv.AutoSize = true;
        }

        public void GetDGVByProductId(int _prodTypeId)
        {
            RefreshTable(); //по умолчанию

            string sqlStatement = "SELECT * FROM SemCore WHERE ProductTypeId = " + _prodTypeId;
            command = new SqlCommand(sqlStatement, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataTo_dgv((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) { }
        }

        private void SetDataTo_dgv(IDataRecord record)
        {
            var index = dgv.Rows.Add();
            
            for (int i = 0; i < record.FieldCount; i++)
            {
                dgv.Rows[index].Cells[i].Value = record[i];
            }
        }
        
        private void SetDataToList(IDataRecord record)
        {
            OldSemCoreList tmp = new OldSemCoreList();
            scl.Add(tmp);
            scl[0].CategoryId = int.Parse(record[0].ToString());
        }

        public void GetByKeywordCategoryId(int _catId)
        {
            RefreshTable(); //по умолчанию

            string sqlStatement = "SELECT * FROM SemCore WHERE CategoryId = " + _catId;
            command = new SqlCommand(sqlStatement, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SetDataTo_dgv((IDataRecord)reader);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) { }

        }

        public void RefreshTable()
        {
            dgv.Columns.Clear();
            AddColumns();
        }
    }
}
