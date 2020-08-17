using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts.Wpf;


namespace CakeShop_app
{
    /// <summary>
    /// Interaction logic for UserControlCharts.xaml
    /// </summary>
    public partial class UserControlCharts : UserControl
    {
        public UserControlCharts()
        {
            InitializeComponent();
            var db = new CakeShop_dbEntities();
            var bills = db.Bills.ToList();
            var billdetails = db.BillDetails.ToList();
            var MonthRevenue = new List<int>()
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            };
            foreach (var item in bills)
            {
                var date = item.Date.ToString().Split('/');
                var MM = Int32.Parse(date[1]);
                var sum = 0;
                foreach (var item2 in item.BillDetails)
                {
                    if (item2.Totality != null)
                    {
                         sum += (int) item2.Totality;
                    }
                    
                }
                item.Totality = sum;
                if (item.Totality != null)
                {
                    MonthRevenue[MM-1] += (int)item.Totality;
                }

            }

            var columnChart = new SeriesCollection();
            for (int i = 0; i < 12; i++)
            {
                var data = new ColumnSeries() { Title = $"Tháng {i + 1}", Values = new ChartValues<int> { MonthRevenue[i] } };
                columnChart.Add(data);
            }
            
           CartesianChart.Series = columnChart;

            var PieChart = new SeriesCollection();
            var CakeLoai = new List<int>()
            {
                0, 0, 0, 0, 0, 
            };
            foreach (var item in billdetails)
            {
                int catID = item.Cake.CatID != null ? (int)item.Cake.CatID : 0;
                if (item.Totality != null)
                {
                    CakeLoai[catID-1] += (int)item.Totality;
                }
            }
            var category = db.Categories.ToList();
            for (int i = 0; i < CakeLoai.Count; i++)
            {
                var data = new PieSeries() { Title = $"{category[i].CatName}", Values = new ChartValues<int> {CakeLoai[i]} };
                PieChart.Add(data);
            }
            PieChartBabyIReal.Series = PieChart;
        }

        private void CartesianChart_DataClick(object sender, ChartPoint chartPoint)
        {

        }
        int flag = 0;
        private void PieChart_click(object sender, RoutedEventArgs e)
        {
            if (flag == 0)
            {
                CartesianChart.Visibility = Visibility.Hidden;
                PieChartBabyIReal.Visibility = Visibility.Visible;
                flag = 1;
            }
            else
            {
                flag = 0;
                CartesianChart.Visibility = Visibility.Visible;
                PieChartBabyIReal.Visibility = Visibility.Hidden;
            }

        }
    }
}
