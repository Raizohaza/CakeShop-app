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
using System.Windows.Shapes;

namespace CakeShop_app
{
    /// <summary>
    /// Interaction logic for Sp.xaml
    /// </summary>
    public partial class Sp : Window
    {
        public Sp()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            var screen = new MainWindow();
            this.Hide();
            screen.ShowDialog();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
