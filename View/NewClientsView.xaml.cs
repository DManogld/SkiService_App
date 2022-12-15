using SkiService_App.Model;
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
using System.Windows.Shapes;

namespace SkiService_App.View
{
    /// <summary>
    /// Interaction logic for NewClientsView.xaml
    /// </summary>
    public partial class NewClientsView : Window
    {

        public NewClientsView()
        {
            InitializeComponent();
        }

        private void Expander_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void Expander_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Window_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void Label_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginView lv = new LoginView();
            lv.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
