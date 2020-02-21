using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Excel_Parse
{
    public partial class ReportAdvertisingViewFixed : Form
    {
        private List<AdvertisingProductsModel> advProductsListOriginal;
        private List<tmpObj> dgvRowsList;
        


        public ReportAdvertisingViewFixed(DateTime _startDate, DateTime _endDate, object _advProductsListOriginal)
        {
            InitializeComponent();
            lb_StartDate.Text = _startDate.ToString().Substring(0, 10);
            lb_EndDate.Text = _endDate.ToString().Substring(0, 10);
            advProductsListOriginal = (List<AdvertisingProductsModel>)_advProductsListOriginal;
            dgvRowsList = new List<tmpObj> { };
            cb_ChartSource.SelectedIndex = 0;
            cb_ChartSource.Focus();

            AdvertisingProductsModel tmpObj;
            for (int i = 1; i < advProductsListOriginal.Count; i++)
            {
                for (int j = 0; j < advProductsListOriginal.Count - i; j++)
                {
                    if (advProductsListOriginal[j].UpdateDate > advProductsListOriginal[j + 1].UpdateDate)
                    {
                        tmpObj = advProductsListOriginal[j];
                        advProductsListOriginal[j] = advProductsListOriginal[j + 1];
                        advProductsListOriginal[j + 1] = tmpObj;
                    }
                }
            }
        }

        public void UpdateDGV(DataGridView _dgv)
        {
            foreach (DataGridViewColumn c in _dgv.Columns)
            {
                dgv_AdvProducts.Columns.Add(c.Clone() as DataGridViewColumn);

            }
            string str = "";
            //then you can copy the rows values one by one (working on the selectedrows collection)
            foreach (DataGridViewRow r in _dgv.Rows)
            {
                int index = dgv_AdvProducts.Rows.Add(r.Clone() as DataGridViewRow);

                foreach (DataGridViewCell o in r.Cells)
                {
                    dgv_AdvProducts.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                }
            }

            for (int i = 1; i < dgv_AdvProducts.Rows.Count; i++)
            {
                str = dgv_AdvProducts.Rows[i].Cells[2].Value.ToString() + " -- " + dgv_AdvProducts.Rows[i].Cells[3].Value.ToString() + " -- " + dgv_AdvProducts.Rows[i].Cells[4].Value.ToString();

                dgvRowsList.Add(new tmpObj(dgv_AdvProducts.Rows[i].Cells[2].Value.ToString(), dgv_AdvProducts.Rows[i].Cells[3].Value.ToString(), dgv_AdvProducts.Rows[i].Cells[4].Value.ToString(), i));
                cb_dgvRows.Items.Add(str);

            }
            if (cb_dgvRows.Items.Count > 0)
                cb_dgvRows.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            string name = "Area " + DateTime.Now.ToString();
            //chart1.ChartAreas.Add(new ChartArea(name));

            int index = cb_dgvRows.SelectedIndex;
           
            if (cb_ChartSource.SelectedIndex == 0)
            {
                Series mySeriesOfPoint = new Series("Impressions");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                //mySeriesOfPoint.ChartArea = name;

                for (int i = 0; i < advProductsListOriginal.Count; i++)
                {
                    if (advProductsListOriginal[i].CampaignName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Campaign) && advProductsListOriginal[i].AdGroupName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].AdGroup) && advProductsListOriginal[i].Targeting.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Targeting))
                        mySeriesOfPoint.Points.AddXY(advProductsListOriginal[i].UpdateDate, advProductsListOriginal[i].Impressions);
                }
                chart1.Series.Add(mySeriesOfPoint);
            }
            else if (cb_ChartSource.SelectedIndex == 1)
            {
                Series mySeriesOfPoint = new Series("Clicks");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                //mySeriesOfPoint.ChartArea = name;

                for (int i = 0; i < advProductsListOriginal.Count; i++)
                {
                    if (advProductsListOriginal[i].CampaignName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Campaign) && advProductsListOriginal[i].AdGroupName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].AdGroup) && advProductsListOriginal[i].Targeting.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Targeting))
                        mySeriesOfPoint.Points.AddXY(advProductsListOriginal[i].UpdateDate, advProductsListOriginal[i].Clicks);
                }
                chart1.Series.Add(mySeriesOfPoint);
            }
            else if (cb_ChartSource.SelectedIndex == 2)
            {
                Series mySeriesOfPoint = new Series("CTR");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                //mySeriesOfPoint.ChartArea = name;

                for (int i = 0; i < advProductsListOriginal.Count; i++)
                {
                    if (advProductsListOriginal[i].CampaignName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Campaign) && advProductsListOriginal[i].AdGroupName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].AdGroup) && advProductsListOriginal[i].Targeting.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Targeting))
                        mySeriesOfPoint.Points.AddXY(advProductsListOriginal[i].UpdateDate, advProductsListOriginal[i].CTR);
                }
                chart1.Series.Add(mySeriesOfPoint);
            }
            else if (cb_ChartSource.SelectedIndex == 3)
            {
                Series mySeriesOfPoint = new Series("CPC");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                //mySeriesOfPoint.ChartArea = name;

                for (int i = 0; i < advProductsListOriginal.Count; i++)
                {
                    if (advProductsListOriginal[i].CampaignName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Campaign) && advProductsListOriginal[i].AdGroupName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].AdGroup) && advProductsListOriginal[i].Targeting.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Targeting))
                        mySeriesOfPoint.Points.AddXY(advProductsListOriginal[i].UpdateDate, advProductsListOriginal[i].CPC);
                }
                chart1.Series.Add(mySeriesOfPoint);
            }
            else if (cb_ChartSource.SelectedIndex == 4)
            {
                Series mySeriesOfPoint = new Series("Spend");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                //mySeriesOfPoint.ChartArea = name;

                for (int i = 0; i < advProductsListOriginal.Count; i++)
                {
                    if (advProductsListOriginal[i].CampaignName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Campaign) && advProductsListOriginal[i].AdGroupName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].AdGroup) && advProductsListOriginal[i].Targeting.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Targeting))
                        mySeriesOfPoint.Points.AddXY(advProductsListOriginal[i].UpdateDate, advProductsListOriginal[i].Spend);
                }
                chart1.Series.Add(mySeriesOfPoint);
            }
            else if (cb_ChartSource.SelectedIndex == 5)
            {
                Series mySeriesOfPoint = new Series("Sales");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                //mySeriesOfPoint.ChartArea = name;

                for (int i = 0; i < advProductsListOriginal.Count; i++)
                {
                    if (advProductsListOriginal[i].CampaignName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Campaign) && advProductsListOriginal[i].AdGroupName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].AdGroup) && advProductsListOriginal[i].Targeting.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Targeting))
                        mySeriesOfPoint.Points.AddXY(advProductsListOriginal[i].UpdateDate, advProductsListOriginal[i].Sales);
                }
                chart1.Series.Add(mySeriesOfPoint);
            }
            else if (cb_ChartSource.SelectedIndex == 6)
            {
                Series mySeriesOfPoint = new Series("ACoS");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                //mySeriesOfPoint.ChartArea = name;

                for (int i = 0; i < advProductsListOriginal.Count; i++)
                {
                    if (advProductsListOriginal[i].CampaignName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Campaign) && advProductsListOriginal[i].AdGroupName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].AdGroup) && advProductsListOriginal[i].Targeting.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Targeting))
                        mySeriesOfPoint.Points.AddXY(advProductsListOriginal[i].UpdateDate, advProductsListOriginal[i].ACoS);
                }
                chart1.Series.Add(mySeriesOfPoint);
            }
            else if (cb_ChartSource.SelectedIndex == 7)
            {
                Series mySeriesOfPoint = new Series("Orders");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                //mySeriesOfPoint.ChartArea = name;

                for (int i = 0; i < advProductsListOriginal.Count; i++)
                {
                    if (advProductsListOriginal[i].CampaignName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Campaign) && advProductsListOriginal[i].AdGroupName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].AdGroup) && advProductsListOriginal[i].Targeting.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Targeting))
                        mySeriesOfPoint.Points.AddXY(advProductsListOriginal[i].UpdateDate, advProductsListOriginal[i].Orders);
                }
                chart1.Series.Add(mySeriesOfPoint);
            }
            else if (cb_ChartSource.SelectedIndex == 8)
            {
                Series mySeriesOfPoint = new Series("Units");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                //mySeriesOfPoint.ChartArea = name;

                for (int i = 0; i < advProductsListOriginal.Count; i++)
                {
                    if (advProductsListOriginal[i].CampaignName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Campaign) && advProductsListOriginal[i].AdGroupName.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].AdGroup) && advProductsListOriginal[i].Targeting.Equals(dgvRowsList[cb_dgvRows.SelectedIndex].Targeting))
                        mySeriesOfPoint.Points.AddXY(advProductsListOriginal[i].UpdateDate, advProductsListOriginal[i].Units);
                }
                chart1.Series.Add(mySeriesOfPoint);
            }
        }

        private void ReportAdvertisingViewFixed_SizeChanged(object sender, EventArgs e)
        {
            dgv_AdvProducts.Width = this.Width - 30;

            chart1.Width = this.Width - 30;

            button1.Location = new System.Drawing.Point(this.Width - button1.Size.Width - 40, button1.Location.Y);
        }
    }

    class tmpObj
    {
        public string Campaign { get; set; }
        public string AdGroup { get; set; }
        public string Targeting { get; set; }
        public int Index { get; set; }
        public tmpObj(string _campaign, string _adgroup, string _targeting, int _index)
        {
            Campaign = _campaign;
            AdGroup = _adgroup;
            Targeting = _targeting;
            Index = _index;
        }
    }
}
