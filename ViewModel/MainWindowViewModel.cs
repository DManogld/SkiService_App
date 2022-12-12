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
using System.Windows;

namespace SkiService_App.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        Database db = new Database();
        private Client _editClent = new Client();
    

        private RelayCommand _cmdaktualisieren { get; set; }
        private RelayCommand _cmdhinzufügen { get; set; }

        public ObservableCollection<Client> cli { get; set; } = new ObservableCollection<Client>();
        public Task<ObservableCollection<Client>> _client;

        public MainWindowViewModel()
        {
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

        private async void Refresh()
        {
            await (_client = db.ConGet());
            ClientModel = _client.Result;
        }


        private async void Insert()
        {
            NewClientsView newClient = new NewClientsView();         
            newClient.ShowDialog();

        }
    }
}
