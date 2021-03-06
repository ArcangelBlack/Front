﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Deliver.Services;
using GalaSoft.MvvmLight.Command;

namespace Deliver.ViewModels
{
    public class MenuItemViewModel
    {
        NavigationService navigationService;

        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
        }

        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        public ICommand NavigateCommand
        {
            get { return new RelayCommand(() => navigationService.Navigate(PageName)); }
        }


    }
}
