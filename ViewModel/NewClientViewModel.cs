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

namespace SkiService_App.ViewModel
{
    public class NewClientViewModel : ViewModelBase
    {
      
        //public NewClientsView txtB = new NewClientsView();
        private ObservableCollection<Client> _clientlist = new ObservableCollection<Client>();

        public Client _curentClient = new Client();
        private Client _editClent = new Client();
        Database db = new Database();

        private RelayCommand _cmdSave { get; set; }
        private RelayCommand _cmdBuild { get; set; }


        public NewClientViewModel()
        {
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
        public RelayCommand CmdBuild
        {
            get { return _cmdBuild; }
            set { _cmdBuild = value; }
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
    }
}
