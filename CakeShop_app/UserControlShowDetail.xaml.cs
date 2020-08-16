using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        BillDetail Bill_std = new BillDetail();
        public delegate void Save(int flags);
        public event Save Handler; 
        public UserControlShowDetail(Cake cake)
        {
            InitializeComponent();
            _data = cake;
            MainGrid.DataContext = _data;
        }

        public UserControlShowDetail(Cake cake,int kt)
        {
            InitializeComponent();
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

        public delegate void AddBill(BillDetail item);
        public event AddBill Handler_Bill;
        private void Button_CartsClick(object sender, RoutedEventArgs e)
        {
            if (QuantityTextBox.Text != "")
            {
                Bill_std.CakeID = _data.ID;
                Bill_std.Quantity = Int32.Parse(QuantityTextBox.Text);
                var today = DateTime.Today.ToString("MM/dd/yyyy");
                Bill_std.Cake = _data;
                Bill_std.Totality = Bill_std.Cake.Price * Bill_std.Quantity;
                //string dateFormat = Convert.ToString(Row["Date"]);
                Handler_Bill?.Invoke(Bill_std);
            }
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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
