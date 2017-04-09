using Deliver.Helpers;
using Deliver.ViewModels.User;
using Xamarin.Forms;

namespace Deliver.Views.Card
{
    public partial class CardsPage : ContentPage
    {
        public CardsPage()
        {
            InitializeComponent();
            this.BindingContext = new CardsViewModel();
        }


        private CardsViewModel ViewModel
        {
            get { return BindingContext as CardsViewModel; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SubscribeFromMessages();

            if (ViewModel == null || ViewModel.Items?.Count > 0)
            {
                return;
            }

            ViewModel.FetchItemsCommand.Execute(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            UnsubscribeFromMessages();
        }

        private void SubscribeFromMessages()
        {
            MessagingCenter.Subscribe<Models.Card>(
                this,
                GlobalSettings.DetailNavigation,
                async (parameter) =>
                {
                    //await Navigation.PushAsync(new XamagramItemDetailView(parameter), true);
                });
        }

        private void UnsubscribeFromMessages()
        {
            MessagingCenter.Unsubscribe<Models.Card>(this, GlobalSettings.DetailNavigation);
        }
    }
}
