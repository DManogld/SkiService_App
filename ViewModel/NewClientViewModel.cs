using Microsoft.Xaml.Behaviors.Media;
using RestSharp;
using Sample3.Utility;
using SkiService_App.Db;
using SkiService_App.Model;
using SkiService_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using ListBox = System.Windows.Controls.ListBox;

namespace SkiService_App.ViewModel
{
    public class NewClientViewModel : ViewModelBase
    {
        /// <summary>
        /// Initialisieren der Variablen und der RelayComand Buttons
        /// </summary>
        private ObservableCollection<Client> _clientlist = new ObservableCollection<Client>();
        public Client _curentClient = new Client();
        private Client _editClent = new Client();
        private Mitarbeiter _currentMitarbeiter = new Mitarbeiter();
        private RelayCommand _cmdSave { get; set; }
        private RelayCommand _cmdBuild { get; set; }
        private RelayCommand _cmdMitarbeiter { get; set; }


        /// <summary>
        ///  Konstruktor welcher Command Binding instanziiert.
        /// </summary>
        public NewClientViewModel()
        {
            _cmdMitarbeiter = new RelayCommand(param => ShowDetail());
            //_cmdBuild = new RelayCommand(param => Build());
            _cmdSave = new RelayCommand(param => Save());
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand CmdBuild
        {
            get { return _cmdBuild; }
            set { _cmdBuild = value; }
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand CmdMitarbeiter
        {
            get { return _cmdMitarbeiter; }
            set { _cmdMitarbeiter = value; }
        }

        /// <summary>
        /// Proprety für Command Binding
        /// </summary>
        public RelayCommand CmdSave
        {
            get { return _cmdSave; }
            set { _cmdSave = value; }
        }

        /// <summary>
        /// ObservableCollection Client Property mit INotifyPropertyChanged
        /// </summary>
        public ObservableCollection<Client> ClietList
        {
            get => _clientlist;
            set => _clientlist = value;
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
                CurentClient = _curentClient;
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
                EditClient = _editClent;
            }
        }

        /// <summary>
        /// CurentMitarbeiter Property mit INotifyPropertyChanged
        /// </summary>
        public Mitarbeiter CurentMitarbeiter
        {
            get { return _currentMitarbeiter; }
            set
            {
                SetProperty<Mitarbeiter>(ref _currentMitarbeiter, value);
                CurentMitarbeiter = _currentMitarbeiter;
            }
        }

        /// <summary>
        /// Methode welche HTTP POST Request ausführt
        /// </summary>
        private async void Save()       
        {
            string json = JsonSerializer.Serialize<Client>(EditClient);
            var client = new RestClient("https://localhost:7113/Registration");
            var request = new RestRequest().AddJsonBody(json);
            request.AddHeader("apiKey", "hL4bA4nB4yI0vI0fC8fH7eT6");
            var response = await client.ExecutePostAsync(request);
            MessageBox.Show(response.StatusCode.ToString());
        }

        /// <summary>
        /// Methoe welche die Details vom Mittarbeiter anzeigt
        /// </summary>
        private void ShowDetail()
        {
            Mitarbeiter mi = new Mitarbeiter();
            ListBox com = new ListBox();
            MessageBox.Show($"Name: {mi.Name = "David Mangold"} \rNummer: { mi.MitarbeiterNummer = 229} \rTitle: {mi.Title="Mitarbeiter"} \r ");
        }
    }
}
