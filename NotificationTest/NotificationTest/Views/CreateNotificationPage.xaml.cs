using NotificationTest.Data;
using NotificationTest.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotificationTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNotificationPage : ContentPage
    {
        public CreateNotificationPage()
        {
            NotificationStore notificationStore = new NotificationStore(DependencyService.Get<ISQLiteDb>());
            PageService pageService = new PageService();

            ViewModel = new CreateNotViewModel(notificationStore, pageService);

            InitializeComponent();
        }

        public CreateNotViewModel ViewModel
        {
            get { return BindingContext as CreateNotViewModel; }
            set { BindingContext = value; }
        }
    }
}