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

        private void Save_Clicked(object sender, System.EventArgs e)
        {
            titleValidator.ForceValidateCommand.Execute(null);
            descValidator.ForceValidateCommand.Execute(null);
            if (titleValidator.IsValid && descValidator.IsValid)
            {
                ViewModel.CreateNoteCommand.Execute(null);
            }
        }
    }
}