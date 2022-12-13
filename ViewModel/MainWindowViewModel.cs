using Sample3.Utility;
using SkiService_App.Db;
using SkiService_App.Model;
using SkiService_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using LoginView = SkiService_App.View.LoginView;

namespace SkiService_App.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
       
        Database db = new Database();
        private Client _editClent = new Client();
        Mitarbeiter _curentMitarbeiter = new Mitarbeiter();

        private RelayCommand _cmdaktualisieren { get; set; }
        private RelayCommand _cmdhinzufügen { get; set; }
        private RelayCommand _cmdlogin { get; set; }

        public bool CanGetData = false;

        public ObservableCollection<Client> cli { get; set; } = new ObservableCollection<Client>();
        public Task<ObservableCollection<Client>> _client;
       

        public MainWindowViewModel()
        {

            _cmdlogin = new RelayCommand(param => Anmelden());
            _cmdhinzufügen = new RelayCommand(param => Insert());
            _cmdaktualisieren = new RelayCommand(param => Refresh());
        }


        public RelayCommand Aktualisieren
        {
            get { return _cmdaktualisieren; }
            set { _cmdaktualisieren = value; }
        }

        public RelayCommand Hinzufügen
        {
            get { return _cmdhinzufügen; }
            set { _cmdhinzufügen = value; }
        }

        public RelayCommand Login
        {
            get { return _cmdlogin; }
            set { _cmdlogin = value; }
        }

        public ObservableCollection<Client> ClientModel
        {
            get { return cli; }
            set
            {
                cli = value;
                OnPropertyChanged(nameof(cli));
            }
        }

        public Client EditClient
        {
            get { return _editClent; }
            set
            {
                SetProperty<Client>(ref _editClent, value);
            }
        }

        public Mitarbeiter CurentMitarbeiter
        {
            get { return _curentMitarbeiter; }
            set
            {
                SetProperty<Mitarbeiter>(ref _curentMitarbeiter, value);
            }
        }

        private async void Refresh()
        {
            if (CanGetData == true)
            {
                await (_client = db.ConGet());
                ClientModel = _client.Result;
            }
            else
            {
               if( MessageBox.Show("Sie müssen sich zerst anmelden", "Anmelden?", MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
               {
                    OpenWindow();
               }
            }
        }



        private async void Insert()
        {
                NewClientsView newClient = new NewClientsView();
                newClient.ShowDialog();
        }


        private void Anmelden()
        {

            if (CurentMitarbeiter.Kürzel == "DMA" || CurentMitarbeiter.Kürzel == "SST" && CurentMitarbeiter.ApiKey == "hL4bA4nB4yI0vI0fC8fH7eT6")
            {             
                CanGetData = true;
                OpenWindow();
            }
            else
            {
                MessageBox.Show("Die Angaben sind Flasch");
            }
        }

        private void OpenWindow()
        {
            LoginView lw = new LoginView();

            if (lw.IsActive)
            {
                lw.Close();
            }
            else
            lw.ShowDialog();
        }
    }
}
