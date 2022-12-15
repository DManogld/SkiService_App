using ControlzEx.Standard;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
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
        bool isLogin = false;
        Database db = new Database();
        private Client _editClent = new Client();
        private Client _curentClient = new Client();

        Mitarbeiter _curentMitarbeiter = new Mitarbeiter();

        private RelayCommand _cmdaktualisieren { get; set; }
        private RelayCommand _cmdhinzufügen { get; set; }
        public RelayCommand _cmddelete { get; set; }
        public RelayCommand _cmdedit { get; set; }
        public RelayCommand _cmdsave { get; set; }
        
        public bool CanGetData = false;

        public ObservableCollection<Client> cli { get; set; } = new ObservableCollection<Client>();
        public Task<ObservableCollection<Client>> _client;
       

        public MainWindowViewModel()
        {
            _cmdedit = new RelayCommand(param => Edit());
            _cmdsave = new RelayCommand(param => Save(), param => CantChange());
            _cmdhinzufügen = new RelayCommand(param => Insert());
            _cmdaktualisieren = new RelayCommand(param => Refresh());
            _cmddelete = new RelayCommand(param => Delete(), param => CantChange()) ;
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

        public RelayCommand CmdDelete
        {
            get { return _cmddelete; }
            set { _cmddelete = value; }
        }

        public RelayCommand CmdEdit
        {
            get { return _cmdedit; }
            set { _cmdedit = value; }
        }

        public RelayCommand CmdSave
        {
            get { return _cmdsave; }
            set { _cmdsave = value; }
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


        public Client CurentClient
        {
            get { return _curentClient; }
            set
            {
                SetProperty<Client>(ref _curentClient, value);
                EditClient = _curentClient;
            }
        }


        private async void Refresh()
        {
            LoginView lv = new LoginView();
            if (isLogin == true)
            {
                await (_client = db.ConGet());
                ClientModel = _client.Result;
            }
            else
            {
               if( MessageBox.Show("Sie müssen sich zerst anmelden", "Anmelden?", MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
               {                                      
                    lv.ShowDialog();        
                    isLogin = true;
                 
               }
            }
        }

        private async void Insert()
        {
                NewClientsView newClient = new NewClientsView();
                newClient.ShowDialog();
        }

        private void Edit()
        {
      
           
        }
      
        private async void Save()
        {
            
            if (CurentClient.ClientID != 0)
            {
                if (MessageBox.Show($"Wollen sie deisen Client:{CurentClient.Name} wüglich ändern?", "Ändern?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                   
                    string url = $"https://localhost:7113/Registration/{CurentClient.ClientID}";
                    var client = new RestClient(url);
                    var request = new RestRequest().AddBody(CurentClient);
                    request.AddHeader("apiKey", "hL4bA4nB4yI0vI0fC8fH7eT6");
                    var response = await client.PutAsync(request);

                    MessageBox.Show($"Eintrag mit der id {CurentClient.ClientID} wurde geeändert", "Änderung", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
            }
        }

        private async void Delete()
        {
            
            if (CurentClient.ClientID != 0)
            {
                if (MessageBox.Show("Wollen sie deisen Client wüglich löschen?", "Löschen?", MessageBoxButton.YesNo,
                  MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string url = $"https://localhost:7113/Registration/{CurentClient.ClientID}";
                    var client = new RestClient(url);
                    var request = new RestRequest();
                    request.AddHeader("apiKey", "hL4bA4nB4yI0vI0fC8fH7eT6");
                    var response = await client.DeleteAsync(request);
                    MessageBox.Show($"Eintrag mit der id {CurentClient.ClientID} wurde gelöscht", "Löschen", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
            }
            else
            {
                
            }
        }

        private bool CantChange()
        {
            return CurentClient != null;
        }
    }
}
