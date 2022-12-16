using Newtonsoft.Json;
using RestSharp;
using Sample3.Utility;
using SkiService_App.Db;
using SkiService_App.Model;
using SkiService_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkiService_App.ViewModel
{
    public class AuftragVerwaltenViewModel : ViewModelBase
    {
        #region "Variablen Inizialisieren"
        public Database db = new Database();
        public Client _editClent = new Client();
        public Client _curentClient = new Client();
        private Filter _filter = new Filter();

        public RelayCommand _cmdaktualisieren { get; set; }
        public RelayCommand _cmdhinzufügen { get; set; }
        public RelayCommand _cmddelete { get; set; }
        public RelayCommand _cmdedit { get; set; }
        public RelayCommand _cmdsave { get; set; }
        public RelayCommand _cmdfilter { get; set; }
        public ObservableCollection<Client> cli { get; set; } = new ObservableCollection<Client>();
        public Task<ObservableCollection<Client>> _client;
        #endregion

        /// <summary>
        /// Konstruktor welcher Command Binding instanziiert.
        /// </summary>
        public AuftragVerwaltenViewModel()
        {
            //_cmdedit = new RelayCommand(param => Edit());
            _cmdsave = new RelayCommand(param => Save(), param => CantChange());
            _cmdhinzufügen = new RelayCommand(param => Insert());
            _cmdaktualisieren = new RelayCommand(param => Refresh());
            _cmddelete = new RelayCommand(param => Delete(), param => CantChange());
            _cmdfilter = new RelayCommand(param => Filter());
        }

        #region "Properties für Comand Binding"
        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand Aktualisieren
        {
            get { return _cmdaktualisieren; }
            set { _cmdaktualisieren = value; }
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand Hinzufügen
        {
            get { return _cmdhinzufügen; }
            set { _cmdhinzufügen = value; }
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand CmdDelete
        {
            get { return _cmddelete; }
            set { _cmddelete = value; }
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand CmdEdit
        {
            get { return _cmdedit; }
            set { _cmdedit = value; }
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand CmdSave
        {
            get { return _cmdsave; }
            set { _cmdsave = value; }
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand CmdFilter
        {
            get { return _cmdfilter; }
            set { _cmdfilter = value; }
        }
        #endregion


        /// <summary>
        /// ObservableCollection Client Property mit INotifyPropertyChanged
        /// </summary>
        public ObservableCollection<Client> ClientModel
        {
            get { return cli; }
            set
            {
                cli = value;
                OnPropertyChanged(nameof(cli));
            }
        }

        /// <summary>
        /// EditClient Property mit INotifyPropertyChanged
        /// </summary>
        public Client EditClient
        {
            get { return _editClent; }
            set
            {
                SetProperty<Client>(ref _editClent, value);
            }
        }

        /// <summary>
        /// CurrentClient Property mit INotifyPropertyChanged
        /// </summary>
        public Client CurentClient
        {

            get { return _curentClient; }
            set
            {
                SetProperty<Client>(ref _curentClient, value);
                EditClient = _curentClient;
            }
        }

        /// <summary>
        /// Filte Property mit INotifyPropertyChanged
        /// </summary>
        public Filter Filters
        {
            get { return _filter; }
            set
            {
                SetProperty<Filter>(ref _filter, value);
            }
        }

        #region "Methoden"
        /// <summary>
        /// Mothode um die Datagrid zu Akktualisieren und HTTP Get() macht.
        /// </summary>
        private void Refresh()
        {
            try
            {
                ObservableCollection<Client> NA = new ObservableCollection<Client>();
                var client = new RestClient("https://localhost:7113/Registration");
                var request = new RestRequest();
                request.AddHeader("apiKey", "hL4bA4nB4yI0vI0fC8fH7eT6");
                ObservableCollection<Client> collection = new ObservableCollection<Client>();
                var response = client.ExecuteGet<Client>(request);
                collection = JsonConvert.DeserializeObject<ObservableCollection<Client>>(response.Content.ToString());
                ClientModel = collection;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hola, da ist was schief gelaufen: ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Methode welche ein neues Dialogfenster aufmacht. (NewClientView)
        /// </summary>
        private async void Insert()
        {
            NewClientsView newClient = new NewClientsView();
            newClient.ShowDialog();
        }

        /// <summary>
        ///  Methode welche HTTP PUT Request ausführt
        /// </summary>
        private async void Save()
        {

            if (CurentClient.ClientID != 0)
            {
                if (MessageBox.Show($"Wollen sie den Auftrag mit der ID :{CurentClient.ClientID} wüglich ändern?", "Ändern?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string url = $"https://localhost:7113/Registration/{CurentClient.ClientID}";
                    var client = new RestClient(url);
                    var request = new RestRequest().AddBody(CurentClient);
                    request.AddHeader("apiKey", "hL4bA4nB4yI0vI0fC8fH7eT6");
                    var response = await client.PutAsync(request);
                    MessageBox.Show($"Eintrag mit der id {CurentClient.ClientID} wurde geändert", "Änderung", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
            }
        }


        /// <summary>
        ///  Methode welche HTTP DELETE Request ausführt
        /// </summary>
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
        }

        /// <summary>
        /// Methode welche man im Datagrit die Suche Filtrieren kann.
        /// </summary>
        private async void Filter()
        {
            ObservableCollection<Client> collection = new ObservableCollection<Client>();
            foreach (var i in ClientModel)
            {
                if (i.FacilityName == Filters.Filters || i.Name == Filters.Filters || i.EMail == Filters.Filters || i.StatusName == Filters.Filters
                    || i.ClientID.ToString() == Filters.Filters || i.PriorityName == Filters.Filters)
                    collection.Add(i);
            }

            ClientModel = collection;
        }


        private bool CantChange()
        {
            return CurentClient != null;
        }
        #endregion
    }
}
