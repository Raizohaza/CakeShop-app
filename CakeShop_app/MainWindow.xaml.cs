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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn_ButtonOpenMenu(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
        private void btn_ButtonCloseMenu(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(new UserControlHomeScreen());
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    TitleFunction.Text = "Trang chủ";
                    usc = new UserControlHomeScreen();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemBill":
                    TitleFunction.Text = "Thanh toán";
                    usc = new UserControlCreateCakeBill(GridMain);
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }

        }
        private void btn_Aboutme(object sender, RoutedEventArgs e)
        {

        }
        private void btn_Source(object sender, RoutedEventArgs e)

        {

        }
        private void btn_Demo(object sender, RoutedEventArgs e)

        {

        }
        private void btn_Exit(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
