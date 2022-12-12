using Newtonsoft.Json;
using RestSharp;
using SkiService_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkiService_App.Db
{
    public class Database
    {
        public async Task<ObservableCollection<Client>> ConGet()
        {
            ObservableCollection<Client> NA = new ObservableCollection<Client>();
            try
            {
                var client = new RestClient("https://localhost:7113/Registration");
                var request = new RestRequest();
                request.AddHeader("apiKey", "hL4bA4nB4yI0vI0fC8fH7eT6");
                var response = await client.ExecuteGetAsync<Client>(request);
                ObservableCollection<Client> collection = JsonConvert.DeserializeObject<ObservableCollection<Client>>(response.Content.ToString());
                return collection;
            }
            catch
            {
                MessageBox.Show("Leider ist die Datenbank nicht Verbunden");
                return NA;
            }
        }
    }
}
