using Microsoft.EntityFrameworkCore;
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
        List<BillDetail> Billes;
        public delegate void Save(int flags);
        public event Save Handler;
        public UserControlCreateCakeBill(Grid grid,Bill bills)
        {
            InitializeComponent();
            main = grid;
            Billes = bills.BillDetails.ToList() as List<BillDetail>;
            Refresh();
        }

        
        public UserControlCreateCakeBill(List<BillDetail> data)
        {
            InitializeComponent();
            Billes= data;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BillDTG.ItemsSource = Billes;
        }

        

        private void Up_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            CakeShop_dbEntities db = new CakeShop_dbEntities();
            var dtbill = db.BillDetails.ToList();
            var selectedItem = BillDTG.SelectedItem as BillDetail;
            foreach (var item in dtbill)
            {
                if (item.CakeID == selectedItem.CakeID && item.IDBill == selectedItem.IDBill && selectedItem!=null)
                {
                    item.Quantity += 1;
                    item.Totality = item.Quantity * item.Cake.Price;
                }
            }
            db.SaveChanges();
            Refresh();
        }
        private void Down_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            CakeShop_dbEntities db = new CakeShop_dbEntities();
            var dtbill = db.BillDetails.ToList();
            var selectedItem = BillDTG.SelectedItem as BillDetail;
            foreach (var item in dtbill)
            {
                if (item.CakeID == selectedItem.CakeID && item.IDBill == selectedItem.IDBill && selectedItem != null && item.Quantity > 0)
                {
                    item.Quantity -= 1;
                    item.Totality = item.Quantity * item.Cake.Price;
                }
            }
            db.SaveChanges();
            Refresh();
        }
        private void DeleteBill_Click(object sender, RoutedEventArgs e)
        {
            //var item = BillDTG.SelectedItem as BillDetail;
            //
            //db.SaveChanges();

            ////refresh
            //var Bills = db.BillDetails.ToList();
            //BillDTG.ItemsSource = Bills;
            CakeShop_dbEntities db = new CakeShop_dbEntities();
            var dtbill = db.BillDetails.ToList();
            var selectedItem = BillDTG.SelectedItem as BillDetail;
            foreach (var item in dtbill)
            {
                if (item.CakeID == selectedItem.CakeID && item.IDBill == selectedItem.IDBill && selectedItem != null)
                    db.BillDetails.Remove(item);
            }
            db.SaveChanges();
            Refresh();
        }
        private void TotalCarts_Click(object sender, RoutedEventArgs e)
        {
            CakeShop_dbEntities db = new CakeShop_dbEntities();
            var bills = db.Bills.ToList();
            var currentBill = bills[bills.Count - 1];
            currentBill.Payed = true;
            db.SaveChanges();
            Handler?.Invoke(1);
            this.Visibility = Visibility.Collapsed;
        }


        private void Refresh()
        {
            var db = new CakeShop_dbEntities();
            var bills = db.Bills.ToList();
            var currentBill = bills[bills.Count - 1];
            var sum = 0;
            foreach (var item2 in currentBill.BillDetails)
            {
                if (item2.Totality != null)
                {
                    sum += (int)item2.Totality;
                }

            }
            currentBill.Totality = sum;
            TotalCartTextBlock.Text = sum.ToString() +"$";
            var billFillter = from item in db.BillDetails
                               where item.IDBill == currentBill.ID
                               select item;
            var data = billFillter.ToList();
            BillDTG.ItemsSource = data;

        }
    }
}
