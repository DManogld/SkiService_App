using SkiService_App.ViewModel;
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

namespace SkiService_App.View
{
    /// <summary>
    /// Interaction logic for AuftragVerwaltenView.xaml
    /// </summary>
    public partial class AuftragVerwaltenView : Window
    {
        public AuftragVerwaltenView()
        {
            InitializeComponent();
        }
        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void item1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void item9_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }

        private void item5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void item5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void TextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
