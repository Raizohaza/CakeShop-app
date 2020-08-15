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
        Cake _dataold = new Cake();

        public delegate void Save(int flags);
        public event Save Handler; 
        public UserControlShowDetail(Cake cake)
        {
            InitializeComponent();
            _dataold = cake;
            _data = cake;
            MainGrid.DataContext = _data;
        }
        public UserControlShowDetail(Cake cake,int kt)
        {
            InitializeComponent();
            _dataold = cake;
            _data = cake;
            MainGrid.DataContext = _data;

            nameTextBox.Visibility = Visibility.Hidden;
            nameText.Visibility = Visibility.Visible;

            PriceTextBox.Visibility = Visibility.Hidden;
            PriceText.Visibility = Visibility.Visible;

            DetalTextBox.Visibility = Visibility.Hidden;
            DetailTextBox.Visibility = Visibility.Visible;

            CartsClick.Visibility = Visibility.Hidden;
            Modifiy.Visibility = Visibility.Hidden;
            Done.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;
        }

        private void Button_CartsClick(object sender, RoutedEventArgs e)
        {

        }
        #region Modify
        private void Modifiy_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Visibility = Visibility.Hidden;
            nameText.Visibility = Visibility.Visible;

            PriceTextBox.Visibility = Visibility.Hidden;
            PriceText.Visibility = Visibility.Visible;

            DetalTextBox.Visibility = Visibility.Hidden;
            DetailTextBox.Visibility = Visibility.Visible;

            CartsClick.Visibility = Visibility.Hidden;
            Modifiy.Visibility = Visibility.Hidden;
            Done.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Handler?.Invoke(1);
            nameTextBox.Visibility = Visibility.Visible;
            nameText.Visibility = Visibility.Hidden;

            PriceTextBox.Visibility = Visibility.Visible;
            PriceText.Visibility = Visibility.Hidden;

            DetalTextBox.Visibility = Visibility.Visible;
            DetailTextBox.Visibility = Visibility.Hidden;

            CartsClick.Visibility = Visibility.Visible;
            Modifiy.Visibility = Visibility.Visible;
            Done.Visibility = Visibility.Hidden;
            Cancel.Visibility = Visibility.Hidden;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Visibility = Visibility.Visible;
            nameText.Visibility = Visibility.Hidden;

            PriceTextBox.Visibility = Visibility.Visible;
            PriceText.Visibility = Visibility.Hidden;

            DetalTextBox.Visibility = Visibility.Visible;
            DetailTextBox.Visibility = Visibility.Hidden;

            CartsClick.Visibility = Visibility.Visible;
            Modifiy.Visibility = Visibility.Visible;
            Done.Visibility = Visibility.Hidden;
            Cancel.Visibility = Visibility.Hidden;
        }
        #endregion

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
