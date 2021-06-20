using NotificationTest.Data;
using NotificationTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotificationTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedPage : ContentPage
    {
        public CompletedPage()
        {
            NotificationStore notificationStore = new NotificationStore(DependencyService.Get<ISQLiteDb>());
            PageService pageService = new PageService();
            ViewModel = new CompletedViewModel(notificationStore, pageService);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        public CompletedViewModel ViewModel
        {
            get { return BindingContext as CompletedViewModel; }
            set { BindingContext = value; }
        }
    }
}