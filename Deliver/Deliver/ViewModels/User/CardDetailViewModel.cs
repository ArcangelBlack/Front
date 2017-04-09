using Deliver.Models;
using Xamarin.Forms;

namespace Deliver.ViewModels.User
{
    public class CardDetailViewModel : BindableObject
    {
        private Card _item;

        public CardDetailViewModel(object parameter)
        {
            Item = parameter as Card;
        }

        public Card Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged("Item");
            }
        }
    }
}
