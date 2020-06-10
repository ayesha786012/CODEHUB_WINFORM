using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace webs
{
    public partial class perform : Form
    {
        public perform()
        {
            InitializeComponent();
        }

        private void perform_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NN9ENGI\SQLEXPRESS;Initial Catalog=SOURCE;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Remarks FROM Report",con);
                SqlDataReader reader = cmd.ExecuteReader();
                Series sr = new Series();
                while (reader.Read())
                {
                    chart1.Series[0].Points.AddY(reader.GetInt32(0));
                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                    chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    chart1.Legends[0].Enabled = true;
                    string seriesname = "MySeriesName";
                    chart1.Series.Add(seriesname);
                    //set the chart-type to "Pie"
                    chart1.Series[seriesname].ChartType = SeriesChartType.Pie;

                    //Add some datapoints so the series. in this case you can pass the values to this method
                    /*chart1.Series[seriesname].Points.AddXY("MyPointName", value1);
                    chart1.Series[seriesname].Points.AddXY("MyPointName1", value2);
                    chart1.Series[seriesname].Points.AddXY("MyPointName2", value3);
                    chart1.Series[seriesname].Points.AddXY("MyPointName3", value4);
                    chart1.Series[seriesname].Points.AddXY("MyPointName4", value5);*/
                }


            }
           /* if (dt.Rows[0][0] == DBNull.Value) //which is working properly

            {

                 //seqno = Convert.ToInt16(ds.Tables[0].Rows[0][0]) + 1;
               /* String[] x = new string[dt.Rows.Count];
                int[] y = new int[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    x[i] = dt.Rows[i][0].ToString();
                    y[i] = Convert.ToInt32(dt.Rows[i][1]);
                }
                chart1.Series[0].Points.DataBindXY(x, y);
                chart1.Series[0].ChartType = SeriesChartType.Pie;
                chart1.ChartAreas["chartarea1"].Area3DStyle.Enable3D = true;
                chart1.Legends[0].Enabled = true;
                
            }

            else

            {

              
            }*/
           
            
        }
        

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
