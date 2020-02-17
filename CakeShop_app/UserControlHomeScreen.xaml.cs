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
    /// Interaction logic for UserControlHomeScreen.xaml
    /// </summary>
    public partial class UserControlHomeScreen : UserControl
    {
        public UserControlHomeScreen()
        {
            InitializeComponent();
        }
        int Category = 0;
        public UserControlHomeScreen(int cat)
        {
            InitializeComponent();
            Category = cat;
        }
        private  CakeShop_dbEntities db = new CakeShop_dbEntities();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var Cakes = db.Cakes.ToList();
            if (Category == 0)
            {
                HomeListView.ItemsSource = Cakes;
                return;
            }

            var cakeFillered = from cake in db.Cakes
                               where cake.CatID == Category
                               select cake;
            var data = cakeFillered.ToList();
            HomeListView.ItemsSource = data;
        }

        private void HomeListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var Cakes = db.Cakes.ToList();
            var index = Cakes.IndexOf(HomeListView.SelectedItem as Cake);
            if (index <= Cakes.Count && index !=-1)
            {
                var item = HomeListView.SelectedItem as Cake;
                var screen = new UserControlShowDetail(item);
                screen.Handler += Status;
                screen.Handler_Bill += Bill_Status;
                GridMain.Children.Add(screen);
            }
        }

        private void Status(int flags)
        {
            if (flags == 1)
            {
                db.SaveChanges();
            }
        }
        
        private void Bill_Status(BillDetail Bill_item)
        {
            var bills = db.Bills.ToList();

            var currentBill = bills[bills.Count-1];
            Bill_item.Totality = Bill_item.Quantity * Bill_item.Cake.Price;

            var Dup_bill = from bill in db.BillDetails
                        where bill.CakeID == Bill_item.CakeID && bill.IDBill == currentBill.ID
                        select bill;
            var kt = Dup_bill.ToList();
            if (kt.Count > 0)
            {
                kt[0].Quantity += Bill_item.Quantity;
                kt[0].Totality =kt[0].Quantity * Bill_item.Cake.Price;
            }
            else
            {
                Bill_item.IDBill = currentBill.ID;
                Bill_item.Bill = currentBill;
                bills[bills.Count - 1].BillDetails.Add(Bill_item);
            }
            db.SaveChanges();
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var item = HomeListView.SelectedItem as Cake;
            db.Cakes.Remove(item);
            db.SaveChanges();

            //refresh
            var Cakes = db.Cakes.ToList();
            HomeListView.ItemsSource = Cakes;
        }
        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            var Cakes = db.Cakes.ToList();
            var index = Cakes.IndexOf(HomeListView.SelectedItem as Cake);
            if (index <= Cakes.Count && index != -1)
            {
                var item = HomeListView.SelectedItem as Cake;
                var screen = new UserControlShowDetail(item,0);
                screen.Handler += Status;
                GridMain.Children.Add(screen);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var categories = db.Categories.ToList();
            var screen = new UserControlAddScreen(categories);
            GridMain.Children.Add(screen);
            screen.Handler += Refresh;
        }

        private void Refresh(Cake item)
        {
            db.Cakes.Add(item);
            db.SaveChanges();
            var Cakes = db.Cakes.ToList();
            HomeListView.ItemsSource = Cakes;
        }
        
        
    }
}
