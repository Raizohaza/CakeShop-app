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

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var item = new Cake()
            {
                CatID = CakeCategory.SelectedIndex+1,
                Name = CakeName.Text.ToString(),
                Price = Int32.Parse(CakePrice.Text.ToString()),
                Image = imagelink
            };
            Handler?.Invoke(item);
            this.Visibility = Visibility.Collapsed;
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
