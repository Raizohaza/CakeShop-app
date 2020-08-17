using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CakeShop_app
{
    /// <summary>
    /// Interaction logic for Sp.xaml
    /// </summary>
    public partial class Sp : Window
    {
        private Random _rng = new Random();
        static List<string> Img = new List<string>();
        static List<string> Desc = new List<string>();

        DispatcherTimer temp = new DispatcherTimer();
        string dataFile = "";
        string dataImg = "";
        public Sp()
        {
            InitializeComponent();
           


            string file = AppDomain.CurrentDomain.BaseDirectory;
            dataFile = $"{file}SplashWindow.txt";
            var data = File.ReadAllText(dataFile);
            if (data == "true")
            {
                var screen = new MainWindow();
                screen.Show();
                this.Close();
            }
            else
            {
                temp.Tick += new EventHandler(temp_Tick);
                temp.Interval = new TimeSpan(0, 0, 60);
                temp.Start();
            }
        }

        
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory;
            dataFile = $"{file}SplashWindow.txt";
            File.AppendAllText(dataFile, "true");
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory;
            dataFile = $"{file}SplashWindow.txt";
            File.Create(dataFile).Close();
        }
        bool check = true;

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            check = false;
            var screen = new MainWindow();
            screen.Show();
            this.Close();

        }

    

       

        
       
        
        private void temp_Tick(object sender, EventArgs e)
        {
            if (check == true)
            {
                var screen = new MainWindow();
                screen.Show();
                temp.Stop();
                this.Close();
            }
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new CakeShop_dbEntities();
            var Cakes = db.Cakes.ToList();
            var temp = _rng.Next(Cakes.Count);
            //
            var file = AppDomain.CurrentDomain.BaseDirectory;
            dataImg = $"{file}Images\\{Cakes[temp].Image}";
            _CakeAva.Source = new BitmapImage(new Uri(dataImg));
            //
            _CakeDetail.Text = Cakes[temp].Detail;
            _CakeName.Text = Cakes[temp].Name;
        }
    }
    
}
