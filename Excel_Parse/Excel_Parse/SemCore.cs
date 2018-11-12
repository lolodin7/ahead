using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace Excel_Parse
{
    public partial class SemCore : Form
    {
        public SemCore()
        {
            InitializeComponent();
            getStarted();
        }

        public void getStarted()
        {
            using (TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv"))
            {

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();

                    var index = dataGridView1.Rows.Add();
                    int i = 0;

                    foreach (string field in fields)
                    {
                        if (i == 1)
                            dataGridView1.Rows[index].Cells[i].Value = double.Parse(field);
                        else
                            dataGridView1.Rows[index].Cells[i].Value = field;
                        i++;
                    }
                }

            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var str = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            Clipboard.SetText(str);
            label1.Visible = true;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
            timer1.Stop();
        }
    }
}
