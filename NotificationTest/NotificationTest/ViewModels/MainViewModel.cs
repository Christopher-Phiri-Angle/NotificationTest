using NotificationTest.Data;
using NotificationTest.Interfaces;
using NotificationTest.Models;
using NotificationTest.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotificationTest.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private INotificationStore _notificationStore;
        private IPageService _pageService;
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
        public ICommand CreateNoteCommand => new Command(() => _pageService.PushAsync(new CreateNotificationPage()));
        public ICommand LoadDataCommand { get; private set; }

        public Notification SelectedNotification { get; set; }
        public ObservableCollection<Notification> Notifications { get; set; } = new ObservableCollection<Notification>();
        public MainViewModel(INotificationStore notificationStore, IPageService pageService)
        {
            _notificationStore = notificationStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                foreach (Notification not in Notifications.ToList())
                {
                    TimeSpan timespan = DateTime.Now - not.Date;

                    if (DateTime.Compare(not.Date, DateTime.Now) >= 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"This is the stuff {not.Date}, now: {DateTime.Now} way: {DateTime.Compare(not.Date, DateTime.Now)}, {DateTime.Compare(DateTime.Now, not.Date)}");
                        SendNotification(not);
                        _ = Notifications.Remove(not);
                    }
                    else
                    {
                        not.Time = timespan;
                    }
                };

                OnPropertyChanged(nameof(Notifications));

                return true;
            });
        }

        private async Task LoadData()
        {
            List<Notification> notifications = await _notificationStore.GetItemsByStatusAsync(false);
            System.Diagnostics.Debug.WriteLine($"length {notifications.Count}");
            Notifications = new ObservableCollection<Notification>(notifications);
            OnPropertyChanged(nameof(Notifications));
        }

        public async void SendNotification(Notification notification)
        {
            try
            {
                notification.Completed = true;
                await _notificationStore.SaveItemAsync(notification);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"we have errors {e}");
            }
        }
    }
}
