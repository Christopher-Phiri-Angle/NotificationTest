using NotificationTest.Data;
using NotificationTest.ViewModels;
using Xamarin.Forms;

namespace NotificationTest.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NotificationStore notificationStore = new NotificationStore(DependencyService.Get<ISQLiteDb>());
            PageService pageService = new PageService();
            ViewModel = new MainViewModel(notificationStore, pageService);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        public MainViewModel ViewModel
        {
            get { return BindingContext as MainViewModel; }
            set { BindingContext = value; }
        }
    }
}
