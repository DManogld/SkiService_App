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
      
        private ObservableCollection<Client> _clientlist = new ObservableCollection<Client>();

       
        private Client _editClent = new Client();
        Database db = new Database();
        private RelayCommand _cmdSave { get; set; }


        public NewClientViewModel()
        {              
            _cmdSave = new RelayCommand(param => Save());
        }


        public Client EditClient
        {
            get { return _editClent; }
            set
            {
                SetProperty<Client>(ref _editClent, value);
            }
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


        // Setzt das Datum je nach Prio
        private string _priority;
        public string Priority
        {
            get { return _priority; }
            set
            {
                if (value != _priority)
                {
                    SetProperty(ref _priority, value);
                }

                if (_priority == "Hoch")
                {
                    EditClient.PickupDate = EditClient.CreateDate.AddDays(5);
                }
                else if (_priority == "Niedrig")
                {
                    EditClient.PickupDate = EditClient.CreateDate.AddDays(12);
                }
                else
                {
                    EditClient.PickupDate = EditClient.CreateDate.AddDays(7);
                }
            }
        }


        private async void Save()
         
        {          
                string json = JsonSerializer.Serialize<Client>(EditClient);
                var client = new RestClient("https://localhost:7113/Registration");
                var request = new RestRequest().AddJsonBody(json);
                request.AddHeader("apiKey", "hL4bA4nB4yI0vI0fC8fH7eT6");
                var response = await client.ExecutePostAsync(request);           
        }
    }
}
