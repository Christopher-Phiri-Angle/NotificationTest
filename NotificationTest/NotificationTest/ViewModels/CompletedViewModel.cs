using NotificationTest.Interfaces;
using NotificationTest.Models;
using NotificationTest.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotificationTest.ViewModels
{
    public class CompletedViewModel: BindableBase
    {
        private INotificationStore _notificationStore;
        private IPageService _pageService;
        public ICommand LoadDataCommand { get; private set; }
        public Notification SelectedNotification { get; set; }
        public ICommand OpenCommand
        {
            get
            {
                return new Command(() =>
                {
                    var detailPage = new ViewNotificationPage(SelectedNotification);
                    _pageService.PushAsync(detailPage);
                });
            }
        }
        private ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();
        public ObservableCollection<Notification> Notifications { get { return notifications; } }

        public CompletedViewModel(INotificationStore notificationStore, IPageService pageService)
        {
            _notificationStore = notificationStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
        }

        private async Task LoadData()
        {
            notifications = new ObservableCollection<Notification>(await _notificationStore.GetItemsByStatusAsync(true));
            OnPropertyChanged(nameof(Notifications));
        }
    }
}
