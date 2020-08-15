using System;
using System.Collections.Generic;
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
using Microsoft.Win32;

namespace CakeShop_app
{
    /// <summary>
    /// Interaction logic for UserControlAddScreen.xaml
    /// </summary>
    public partial class UserControlAddScreen : UserControl
    {
        public UserControlAddScreen()
        {
            InitializeComponent();
        }
        string imagelink = "";
        public delegate void AddItem(Cake item);
        public event AddItem Handler;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = UserControlHomeScreen.db.Categories.ToList();
            CakeCategory.ItemsSource = categories;
        }

        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                imagelink = screen.FileName.ToString();
                CakeImage.Source = new BitmapImage(new Uri(screen.FileName));
            }
        }

        private bool CheckData()
        {

            if (CakeName.Text == "" || CakePrice.Text== "" || imagelink == "")
            {
                if (CakeName.Text == "")
                    CakeName.SetValue(Border.BorderBrushProperty, Brushes.Red);

                if (CakePrice.Text == "")
                    CakePrice.SetValue(Border.BorderBrushProperty, Brushes.Red);

                if (imagelink == "")
                    CakeImage.SetValue(Border.BorderBrushProperty, Brushes.Red);
                if (CakeCategory.SelectedIndex == -1)
                    CakeCategory.SetValue(Border.BorderBrushProperty, Brushes.Red);
                return false;
            }
            return true;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckData())
            {
                var categories = UserControlHomeScreen.db.Categories.ToList();
                var item = new Cake()
                {
                    CatID = categories[CakeCategory.SelectedIndex].ID,
                    Name = CakeName.Text.ToString(),
                    Price = Int32.Parse(CakePrice.Text.ToString()),
                    Image = imagelink
                };
                Handler?.Invoke(item);
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
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
