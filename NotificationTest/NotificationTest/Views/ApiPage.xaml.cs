using NotificationTest.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotificationTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        public ApiPage()
        {
            InitializeComponent();
            ViewModel = new ApiViewModel();
        }
        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
        public ApiViewModel ViewModel
        {
            get { return BindingContext as ApiViewModel; }
            set { BindingContext = value; }
        }
    }

}