using System.Collections.Generic;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using LiveCharts;
using LiveCharts.Wpf;
using System.Net;
using LiveCharts.Helpers;

namespace AIO_Game_Assistant.Modular_Windows.User_Control_Forms.Games.World_of_Warcraft
{
    public partial class Tokens : UserControl
    {

        private static Tokens _instance;

        public static Tokens Instance {
            get {
                if (_instance == null)
                    _instance = new Tokens();
                return _instance;
        
            }
        }


        public dynamic jss = new JavaScriptSerializer(); //JSON Deserializer

        public Tokens()
        {
            InitializeComponent();

            var wowTokenPrices = new WebClient().DownloadString("http://wowtokenprices.com/history_prices_7_day.json");
            //A dictionary where all values for the deserialized JSON is stored
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(wowTokenPrices);

            int[] USToken = new int[dict["US"].Count];
            int[] EUToken = new int[dict["EU"].Count];
            int[] ChinaToken = new int[dict["China"].Count];
            int[] KoreaToken = new int[dict["Korea"].Count];

            string[] tokenPriceDate = new string[dict["US"].Count];

            for (int i = 0; i < dict["US"].Count; i++)
            {
                string[] tokens = dict["US"][i]["timestamp_utc_timezone"].Split(' ');
                tokenPriceDate[i] = tokens[0];
            }

            for (int i = 0; i < dict["US"].Count; i++)
            {
                USToken[i] = dict["US"][i]["price"];
            }
            for (int i = 0; i < dict["EU"].Count; i++)
            {
                EUToken[i] = dict["EU"][i]["price"];
            }
            for (int i = 0; i < dict["China"].Count; i++)
            {
                ChinaToken[i] = dict["China"][i]["price"];
            }
            for (int i = 0; i < dict["Korea"].Count; i++)
            {
                KoreaToken[i] = dict["Korea"][i]["price"];
            }

            int number = 1840800000;
            int gold = number / 10000; //this will give you the whole part because of the int type
            number = number % 10000; //this will make 'number' 3123
            int silver = number / 100; //this will get the silver
            int copper = number % 100; //this will get the copper
                                       //label2.Text = gold + "G " + silver + "S " + copper + "C ";



            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "US",

                    Values = USToken.AsChartValues(),
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "EU",
                    Values = EUToken.AsChartValues(),
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "China",
                    Values = ChinaToken.AsChartValues(),
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Korea",
                    Values = KoreaToken.AsChartValues(),
                    PointGeometry = null
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "WoW Token Prices",
                Labels = tokenPriceDate.AsChartValues()
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Price of Tokens over 30 days.",
                LabelFormatter = value => value.ToString() + "G"
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            //modifying the series collection will animate and update the chart
            //cartesianChart1.Series.Add();

            //modifying any series values will also animate and update the chart
            //cartesianChart1.Series[2].Values.Add(5d);


            cartesianChart1.DataClick += CartesianChart1OnDataClick;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ") +\n" +
                "");
        }
    }
}
