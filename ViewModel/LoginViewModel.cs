using ControlzEx.Standard;
using MahApps.Metro.Actions;
using Sample3.Utility;
using SkiService_App.Model;
using SkiService_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkiService_App.ViewModel
{
    
    public class LoginViewModel : ViewModelBase
    {
        
        public bool CanGetData = false;
        Mitarbeiter _curentMitarbeiter = new Mitarbeiter();
        private RelayCommand _cmdlogin { get; set; }
       

        public LoginViewModel()
        {
            _cmdlogin = new RelayCommand(param => Anmelden());
        }


        public Mitarbeiter CurentMitarbeiter
        {
            get { return _curentMitarbeiter; }
            set
            {
                SetProperty<Mitarbeiter>(ref _curentMitarbeiter, value);
            }
        }

        public RelayCommand Login
        {
            get { return _cmdlogin; }
            set { _cmdlogin = value; }
        }


        private void Anmelden()
        {
            if (CurentMitarbeiter.Kürzel == "DMA" && CurentMitarbeiter.ApiKey == "hL4bA4nB4yI0vI0fC8fH7eT6" || CurentMitarbeiter.Kürzel == "SST" && CurentMitarbeiter.ApiKey == "hL4bA4nB4yI0vI0fC8fH7eT6")
            {
                if (MessageBox.Show("Erfolgreich Angemeldet", "Anmelden?", MessageBoxButton.OK,
                  MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    CanGetData = true;
                }                                                
            }
            else
            {
                MessageBox.Show("Die Angaben sind Flasch", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);      
            }
        }
    }
}
