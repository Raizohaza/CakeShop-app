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
        public static CakeShop_dbEntities2 db = new CakeShop_dbEntities2();

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
                GridMain.Children.Add(screen);
            }
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new UserControlAddScreen();
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
