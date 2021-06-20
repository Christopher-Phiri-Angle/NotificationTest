using NotificationTest.Data;
using NotificationTest.Models;
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
    public partial class ViewNotificationPage : ContentPage
    {
        
        public ViewNotificationPage(Notification notification)
        {
            InitializeComponent();
            NotificationStore notificationStore = new NotificationStore(DependencyService.Get<ISQLiteDb>());
            PageService pageService = new PageService();
            BindingContext = new NotDetailViewModel(notification, notificationStore, pageService);
        }
    }
}