using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Deliver.Helpers;
using Deliver.Models;
using Deliver.Services;
using Xamarin.Forms;

namespace Deliver.ViewModels
{
    public class CardViewModel : BindableObject
    {
        private ObservableCollection<Card> _items;

        private Card _selectedItem;

        private Command _fetchItemsCommand;

        public ObservableCollection<Card> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public Card SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;

                // Utilizando mensajería
                MessagingCenter.Send(_selectedItem, GlobalSettings.DetailNavigation);

                // Creando un servicio de navegación
                // NavigationService.Instance.NavigateTo<XamagramItemDetailViewModel>(_selectedItem);
            }
        }

        public Command FetchItemsCommand
        {
            get { return _fetchItemsCommand ?? (_fetchItemsCommand = new Command(async () => await ExecuteFetchItemsCommand())); }
        }

        public async Task ExecuteFetchItemsCommand()
        {
            var items = await CardService.Instance.GetItems();

            Items = new ObservableCollection<Card>(items);
        }
    }
}
