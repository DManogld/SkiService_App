﻿using Sample3.Utility;
using SkiService_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiService_App.ViewModel
{
    public class EditViewModel : ViewModelBase
    {
        public Client _curentClient = new Client();
        public Client _editClent = new Client();
        private RelayCommand _cmdSave { get; set; }
        private MainWindowViewModel mnvm = new MainWindowViewModel();
        public EditViewModel()
        {
            _cmdSave = new RelayCommand(param => Save());
        }

        public Client CurentClient
        {
            get { return _curentClient; }
            set
            {
                SetProperty<Client>(ref _curentClient, value);
                EditClient = _curentClient;
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

        private async void Save()
        {

        }
    }
}