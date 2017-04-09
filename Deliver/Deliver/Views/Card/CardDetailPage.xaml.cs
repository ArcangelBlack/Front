using Deliver.ViewModels.User;
using Xamarin.Forms;

namespace Deliver.Views.Card
{
    public partial class CardDetailPage : ContentPage
    {
        public CardDetailPage(object parameter)
        {
            InitializeComponent();
            Parameter = parameter;

            BindingContext = new CardDetailViewModel(Parameter);
        }

        public object Parameter { get; set; }
    }
}
