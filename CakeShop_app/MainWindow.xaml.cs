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
            CakeShop_dbEntities db = new CakeShop_dbEntities();
            Bill bill = new Bill();
            bill.Date = DateTime.Now;
            bill.Payed = false;
            InitializeComponent();
            db.Bills.Add(bill);
            db.SaveChanges();
            var d = db.Bills.ToList();
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
            TitleFunction.Text = "Trang chủ";
            var screen = new UserControlTypes();
            screen.Handler += Categories;
            GridMain.Children.Add(screen);
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

        private void ListViewMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    TitleFunction.Text = "Trang chủ";
                    var screen = new UserControlTypes();
                    screen.Handler += Categories;
                    GridMain.Children.Add(screen);
                    break;
                case "ItemProduct":
                    TitleFunction.Text = "Các sản phẩm";
                    usc = new UserControlHomeScreen();
                    GridMain.Children.Add(usc);
                    break;
                //case "ItemBill":
                //    CakeShop_dbEntities db = new CakeShop_dbEntities();
                //    TitleFunction.Text = "Thanh toán";
                //    var data = db.BillDetails.ToList();
                //    usc = new UserControlCreateCakeBill(GridMain,data);
                //    GridMain.Children.Add(usc);
                //    break;
                case "ItemStatistical":
                    TitleFunction.Text = "Thống kê";
                    usc = new UserControlCharts();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void Cart_Click_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CakeShop_dbEntities db = new CakeShop_dbEntities();
            GridMain.Children.Clear();
            
            TitleFunction.Text = "Thanh toán";
            var data = db.Bills.ToList();
            GridMain.Children.Add( new UserControlCreateCakeBill(GridMain,data[data.Count-1]));
        }
        private void Categories(int CatID)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            TitleFunction.Text = "Các sản phẩm";
            usc = new UserControlHomeScreen(CatID);
            GridMain.Children.Add(usc);
        }

        //Xoa cac bill chua thanh toan
        private void Window_Closed(object sender, EventArgs e)
        {
            CakeShop_dbEntities db = new CakeShop_dbEntities();
            
            var bd = db.BillDetails.ToList();
            foreach (var item in bd)
            {
                if (item.Bill.Payed == false)
                {
                    db.BillDetails.Remove(item);
                    db.SaveChanges();
                }
            }

            var d = db.Bills.ToList();
            foreach (var item in d)
            {
                if (item.Payed == false)
                {
                    db.Bills.Remove(item);
                    db.SaveChanges();
                }
            }
            Application.Current.Shutdown();
        }
    }
}
