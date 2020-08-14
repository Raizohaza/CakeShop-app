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

namespace CakeShop_app
{
    /// <summary>
    /// Interaction logic for UserControlTypes.xaml
    /// </summary>
    public partial class UserControlTypes : UserControl
    {
        public UserControlTypes()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            Cake_ava.Source = new BitmapImage(new Uri(folder+"Images\\cake_ava.jpg"));
            Fresh_Bread_ava.Source = new BitmapImage(new Uri(folder+ "Images\\bread_ava.jpg"));
            Sweet_Bread_ava.Source = new BitmapImage(new Uri(folder+ "Images\\Sweet_Bread_ava.jpg"));
            Gato_Bread_ava.Source = new BitmapImage(new Uri(folder+ "Images\\gato_ava.jpg"));
            trang_mieng_ava.Source = new BitmapImage(new Uri(folder+ "Images\\trang_mieng_ava.jpg"));
        }
    }
}
