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
    /// <summary>
    /// Client Model hier werden alle eigenschaften von einem Client aufgelistet
    /// </summary>
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

        private string _name = String.Empty;
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

        private string _email = String.Empty;
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

        public string _phone = String.Empty;
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

        private string _facilityName= String.Empty;
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

        private string _priorityName = String.Empty;
        public string PriorityName
        {
            get { return _priorityName; }
            set
            {
                if (value != _priorityName)
                {
                    SetProperty(ref _priorityName, value);
                }

                if (_priorityName == "Hoch")
                {
                    PickupDate = CreateDate.AddDays(5);
                }
                else if (_priorityName == "Niedrig")
                {
                    PickupDate = CreateDate.AddDays(12);
                }
                else
                {
                   PickupDate = CreateDate.AddDays(7);
                }
            }
        }

        public string _statusName = String.Empty;
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

        private string _komentar = string.Empty;
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
