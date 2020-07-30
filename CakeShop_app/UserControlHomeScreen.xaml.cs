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
        CakeShop_dbEntities db = new CakeShop_dbEntities();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var Cakes = db.Cakes.ToList();
            HomeListView.ItemsSource = Cakes;
        }

        private void HomeListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var Cakes = db.Cakes.ToList();
            var item = HomeListView.SelectedItem as Cake;
            var index = Cakes.IndexOf(item);
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

        }

    }
}
