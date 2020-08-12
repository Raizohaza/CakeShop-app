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
    /// Interaction logic for UserControlShowDetail.xaml
    /// </summary>
    public partial class UserControlShowDetail : UserControl
    {
        Cake _data = new Cake();
        public UserControlShowDetail(Cake cake)
        {
            InitializeComponent();
            _data = cake;
            this.DataContext = _data;
        }
        private void window_loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Load()
        {

        }

        private void Button_CartsClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
