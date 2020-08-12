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
    /// Interaction logic for UserControlCreateCakeBill.xaml
    /// </summary>
    public partial class UserControlCreateCakeBill : UserControl
    {
        Grid main;
        public UserControlCreateCakeBill(Grid grid)
        {
            InitializeComponent();
            main = grid;
            //Load();
        }

        public UserControlCreateCakeBill()
        {
        }

        private void Load()
        {
            //BillDTG.ItemsSource = DataProvider.Ins.DB.Bills.ToList();
        }
        private void setNull()
        {
            DisplayNameCustomer.SelectedIndex = 1;
            DisplayNameSale.SelectedIndex = 1;
            DisplayNameTransport.SelectedIndex = 1;
        }
        bool checkInput()
        {
            if (DisplayNameCustomer.SelectedIndex == -1 || DateBill.SelectedDate.HasValue == false)
            {
                return false;
            }
            return true;
        }
        private void btn_Add(object sender, RoutedEventArgs e)
        {

        }
        private void btn_Del(object sender, RoutedEventArgs e)
        {

        }
        private void btn_Edit(object sender, RoutedEventArgs e)
        {

        }
        private void btn_BillDetail(object sender, RoutedEventArgs e)
        {

        }
        private void BillDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void loadSale(object sender, RoutedEventArgs e)
        {

        }
        private void loadTransport(object sender, RoutedEventArgs e)
        {

        }
        private void loadCustomer(object sender, RoutedEventArgs e)
        {

        }
    }
}
