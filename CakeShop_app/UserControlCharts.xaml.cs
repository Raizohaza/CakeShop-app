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
                    MonthRevenue[MM] += (int)item.Totality;
                }

            }
            
            var columnChart = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };
        }

        private void CartesianChart_DataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {

        }
    }
}
