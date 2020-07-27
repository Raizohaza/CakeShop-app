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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new CakeShop_dbEntities();

            var Cakes = db.Cakes.ToList();
            HomeListView.ItemsSource = Cakes;
        }
    }
}
