using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliver.Views;
using Deliver.Views.Order;
using Deliver.Views.User;
using Xamarin.Forms;

namespace Deliver.Services
{
    public class NavigationService
    {
        public async void Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {
                case "NewOrderPage":
                    await Navigate(new NewOrderPage());
                    break;
                //case "AlarmsPage":
                //    await Navigate(new AlarmsPage());
                //    break;
                case "ClientsPage":
                    await Navigate(new UserPage());
                    break;
                //case "SettingsPage":
                //    await Navigate(new SettingsPage());
                //    break;
                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
                default:
                    break;
            }
        }

        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, false);
            NavigationPage.SetBackButtonTitle(page, "Atrás"); //iOS

            await App.Navigator.PushAsync(page);
        }

        internal void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterPage":
                    App.Current.MainPage = new MyMasterPage();
                    break;
                default:
                    break;
            }
        }
    }
}
