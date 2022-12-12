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

namespace SkiService_App
{
    /// <summary>
    /// Interaction logic for FlowDokument.xaml
    /// </summary>
    public partial class FlowDokument : Window
    {
        public FlowDokument()
        {
            InitializeComponent();
        }

        private void Border_MousDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private bool IsMaximed = false;
        private void Border_MousLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if (IsMaximed)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximed = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximed = true ;
                }
            }

        }

    }
}
