using ControlzEx.Standard;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Sample3.Utility;
using SkiService_App.Db;
using SkiService_App.Model;
using SkiService_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using LoginView = SkiService_App.View.LoginView;

namespace SkiService_App.ViewModel
{
    
    public class MainWindowViewModel : ViewModelBase
    {

        /// <summary>
        /// Initialisieren der RelayComand Button
        /// </summary>
        public RelayCommand _cmderstellen { get; set; }
        public RelayCommand _cmdverwalten { get; set; }

        /// <summary>
        ///  Konstruktor welcher Command Binding instanziiert.
        /// </summary>
        public MainWindowViewModel()
        {
            _cmderstellen = new RelayCommand(param => OpenErstellen());
            _cmdverwalten = new RelayCommand(param => OpenVerwalten());
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand CmdErstellen
        {
            get { return _cmderstellen; }
            set { _cmderstellen = value; }
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand CmdVerwalten
        {
            get { return _cmdverwalten; }
            set { _cmdverwalten = value; }
        }

        /// <summary>
        /// Methode um das Fenster zu öffnen welche für eine neuen Auftrag ermöglicht
        /// </summary>
        public void OpenErstellen()
        {
            NewClientsView ncv = new NewClientsView();
            ncv.Show();
        }

        /// <summary>
        ///  Methode um das Fenster zu öffnen welche für die Anmeldung zuständig ist
        /// </summary>
        public void OpenVerwalten()
        {
            LoginView lv = new LoginView();
            if (lv.ShowDialog() == true)
            {
                lv.Close();
            }           
        }
    }
}
