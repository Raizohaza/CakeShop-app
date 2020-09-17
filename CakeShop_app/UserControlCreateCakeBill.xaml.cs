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
        public UserControlCreateCakeBill(Grid grid,Bill bills)
        {
            InitializeComponent();
            main = grid;
            Billes = bills.BillDetails.ToList() as List<BillDetail>;

            
        }
        
        public UserControlCreateCakeBill(List<BillDetail> data)
        {
            InitializeComponent();
            Billes= data;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BillDTG.ItemsSource = Billes;
            var cakes = new List<Cake>();
        }

        private void BillDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }
        
        //private void Refresh(Bill item)
        //{
        //    db.Bills.Add(item);
        //    db.SaveChanges();
        //    var Bills = db.Cakes.ToList();
        //    BillDTG.ItemsSource = Bills;
        //}
    }
}
