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
      
        //public NewClientsView txtB = new NewClientsView();
        private ObservableCollection<Client> _clientlist = new ObservableCollection<Client>();
        public Client _curentClient = new Client();
        private Client _editClent = new Client();
        private Mitarbeiter _currentMitarbeiter = new Mitarbeiter();
        Database db = new Database();

        private RelayCommand _cmdSave { get; set; }
        private RelayCommand _cmdBuild { get; set; }
        private RelayCommand _cmdMitarbeiter { get; set; }

        public NewClientViewModel()
        {
            _cmdMitarbeiter = new RelayCommand(param => ShowDetail());
            _cmdBuild = new RelayCommand(param => Build());
            _cmdSave = new RelayCommand(param => Save());
        }

        public Client CurentClient
        {
            get { return _curentClient; }
            set
            {
                SetProperty<Client>(ref _curentClient, value);
                CurentClient = _curentClient;
            }
        }

        public Client EditClient
        {
            get { return _editClent; }
            set
            {
                SetProperty<Client>(ref _editClent, value);
                EditClient = _editClent;
            }
        }

        public Mitarbeiter CurentMitarbeiter
        {
            get { return _currentMitarbeiter; }
            set
            {
                SetProperty<Mitarbeiter>(ref _currentMitarbeiter, value);
                CurentMitarbeiter = _currentMitarbeiter;
            }
        }


        public RelayCommand CmdBuild
        {
            get { return _cmdBuild; }
            set { _cmdBuild = value; }
        }

        public RelayCommand CmdMitarbeiter
        {
            get { return _cmdMitarbeiter; }
            set { _cmdMitarbeiter = value; }
        }

        public RelayCommand CmdSave
        {
            get { return _cmdSave; }
            set { _cmdSave = value; }
        }


        public ObservableCollection<Client> ClietList
        {
            get => _clientlist;
            set => _clientlist = value;
        }


        private async void Save()
         
        {          
                string json = JsonSerializer.Serialize<Client>(EditClient);
                var client = new RestClient("https://localhost:7113/Registration");
                var request = new RestRequest().AddJsonBody(json);
                request.AddHeader("apiKey", "hL4bA4nB4yI0vI0fC8fH7eT6");
                var response = await client.ExecutePostAsync(request);
                MessageBox.Show(response.StatusCode.ToString());
        }

        private async void Build()
        {
            
        }

        private void ShowDetail()
        {
            Mitarbeiter mi = new Mitarbeiter();
            ListBox com = new ListBox();
            com.Items.Add(mi.Name = "DMA".ToString());
            com.Items.Add(mi.MitarbeiterNummer = 120);
            com.Items.Add(mi.Title = "Mitarbeiter".ToString());
            MessageBox.Show($"Name: {mi.Name = "David Mangold"} \rNummer: { mi.MitarbeiterNummer = 229} \rTitle: {mi.Title="Mitarbeiter"} \r ");
        }
    }
}
