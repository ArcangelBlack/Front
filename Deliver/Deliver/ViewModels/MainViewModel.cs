using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Deliver.Services;
using Deliver.ViewModels.User;
using GalaSoft.MvvmLight.Command;

namespace Deliver.ViewModels
{
    public class MainViewModel
    {
        NavigationService navigationService;

        ApiService apiService;

        private CardService cardService;

        public MainViewModel()
        {
            navigationService = new NavigationService();
            apiService = new ApiService();

            this.cardService = new CardService();

            Orders = new ObservableCollection<OrderViewModel>();

            LoadMenu();

            //LoadData();
        }

        #region Properties

        public OrderViewModel NewOrder { get; private set; }

        public ObservableCollection<OrderViewModel> Orders { get; set; }


        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        #endregion

        #region Commands
        public ICommand GoToCommand
        {
            get { return new RelayCommand<string>(GoTo); }
        }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewOrderPage":
                    NewOrder = new OrderViewModel();
                    break;
                default:
                    break;
            }
            navigationService.Navigate(pageName);
        }

        public ICommand StartCommand
        {
            get { return new RelayCommand(Start); }
        }


        private async void Start()
        {
            var list = await apiService.GetAllOrders();
            Orders.Clear();

            foreach (var item in list)
            {
                Orders.Add(new OrderViewModel()
                {
                    Title = item.Title,
                    DeliveryDate = item.DeliveryDate,
                    Description = item.Description
                });
            }

            navigationService.SetMainPage("MasterPage");
        }

        #endregion

        #region Methods
        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel()
                {
                    Icon = "ic_action_orders",
                    Title = "Pedidos",
                    PageName = "MainPage"
                },
                new MenuItemViewModel()
                {
                    Icon = "ic_action_clients",
                    Title = "Usuario",
                    PageName = "UserPage"
                },
                new MenuItemViewModel()
                {
                    Icon = "ic_action_alarm",
                    Title = "Tarjetas",
                    PageName = "CardsPage"
                },
                new MenuItemViewModel()
                {
                    Icon = "ic_action_settings",
                    Title = "Ajustes",
                    PageName = "SettingsPage"
                }
            };
        }

        #endregion

    }
}
