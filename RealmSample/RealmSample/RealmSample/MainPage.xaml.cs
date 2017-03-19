using RealmSample.ViewModels;
using Xamarin.Forms;

namespace RealmSample
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel Vm => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Initalize our view model as long as the binding context is not null
            if (Vm != null)
            {
                await Vm.Init();
            }
        }

        private void PeronTapped(object sender, ItemTappedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
