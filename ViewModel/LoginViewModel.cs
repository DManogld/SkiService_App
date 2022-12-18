using ControlzEx.Standard;
using MahApps.Metro.Actions;
using MahApps.Metro.Controls.Dialogs;
using Sample3.Utility;
using SkiService_App.Db;
using SkiService_App.Model;
using SkiService_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows;

namespace SkiService_App.ViewModel
{   
    public class LoginViewModel : ViewModelBase
    {

        /// <summary>
        /// Variablen Inizialisieren
        /// </summary>
        public Action CloseAction { get; set; }
        public Mitarbeiter _curentMitarbeiter = new Mitarbeiter();
        private RelayCommand _cmdlogin { get; set; }


        /// <summary>
        /// Konstruktor welcher Command Binding instanziiert.
        /// </summary>
        public LoginViewModel()
        {
            _cmdlogin = new RelayCommand(param => Anmelden());
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand Login
        {
            get { return _cmdlogin; }
            set { _cmdlogin = value; }
        }


        /// <summary>
        /// CurentMitarbeiter Property mit INotifyPropertyChanged
        /// </summary>
        public Mitarbeiter CurentMitarbeiter
        {
            get { return _curentMitarbeiter; }
            set
            {
                SetProperty<Mitarbeiter>(ref _curentMitarbeiter, value);
            }
        }

        /// <summary>
        /// Methode um sich mit den Login daten Anmelden
        /// </summary>
        public void Anmelden()
        {
            AuftragVerwaltenView avw = new AuftragVerwaltenView();
            if (CurentMitarbeiter.Kürzel == "DMA" && CurentMitarbeiter.Passwort == "pw1234" || CurentMitarbeiter.Kürzel == "SST" && CurentMitarbeiter.Passwort == "pw5678")
            {                           
                 avw.Show();
                 CloseAction();
                
            }
            else
            {
                MessageBox.Show("Die Angaben sind Flasch", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);     
            }
        }
        
    }
}
