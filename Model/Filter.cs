using SkiService_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SkiService_App.Model
{
    public class Filter : ViewModelBase
    {
        private string _filter;
        public string Filters
        {
            get { return _filter; }
            set
            {
                if (_filter != value)
                {
                    SetProperty(ref _filter, value);
                }
            }
        }
    }
}
