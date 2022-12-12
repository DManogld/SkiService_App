using SkiService_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Controls;

namespace SkiService_App.Model
{
    public class Client: ViewModelBase
    {
        private int _clientID;
        public int ClientID
        {
            get { return _clientID; }
            set
            {
                if (_clientID != value)
                {
                    SetProperty(ref _clientID, value);
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    SetProperty(ref _name, value);
                }
            }
        }

        private string _email;
        public string EMail
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    SetProperty(ref _email, value);
                }
            }
        }

        public string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    SetProperty(ref _phone, value);
                }
            }
        }

        private DateTime _CreateDate = DateTime.Now;
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if (_CreateDate != value)
                {
                    SetProperty(ref _CreateDate, value);
                }
            }
        }

        private DateTime _PickupDate = DateTime.Now;
        public DateTime PickupDate
        {
            get { return _PickupDate; }
            set
            {
                if (_PickupDate != value)
                {
                    SetProperty(ref _PickupDate, value);
                }
            }
        }

        private string _facilityName;
        public string FacilityName
        {
            get { return _facilityName; }
            set
            {
                if(_facilityName != value)
                {
                    SetProperty(ref _facilityName, value);
                }
            }
        }

        private string _priorityName;
        public string PriorityName
        {
            get { return _priorityName; }
            set
            {
                if(_priorityName != value)
                {
                    SetProperty(ref _priorityName, value);
                }
            }
        }

        public string _statusName;
        public string StatusName
        {
            get { return _statusName; }
            set
            {
                if (_statusName != value)
                {
                    SetProperty(ref _statusName, value);
                }
            }
        }

        private string _komentar;
        public string Kommentar
        {
            get { return _komentar; }
            set
            {            
                    SetProperty(ref _komentar, value);
            }
        }
    }
}
