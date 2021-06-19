using NotificationTest.Data;
using NotificationTest.Models;
using NotificationTest.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotificationTest.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ICommand OpenCommand
        {
            get
            {
                return new Command(() =>
                {
                    var detailVM = new NotDetailViewModel(selectedNotification);
                    var detailPage = new ViewNotificationPage();
                    detailPage.BindingContext = detailVM;
                    Application.Current.MainPage.Navigation.PushAsync(detailPage);
                });
            }
        }
        public ICommand CreateNoteCommand => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new CreateNotificationPage()));
        public ICommand ViewCompletedCommand => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new CompletedPage()));


        public Notification selectedNotification;
        public Notification SelectedNotification { get; set; }
        private ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();
        public ObservableCollection<Notification> Notifications { get { return notifications; } }
        public MainViewModel()
        {
            GetNotifications();

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                foreach (Notification not in notifications.ToList())
                {
                    TimeSpan timespan = not.Date - DateTime.Now;
                    if (timespan.Seconds < 0)
                    {
                        SendNotification(not);
                        _ = notifications.Remove(not);
                    }
                    else
                    {
                        not.Time = timespan;
                    }
                };

                OnPropertyChanged(nameof(notifications));

                return true;
            });
        }

        private async void GetNotifications()
        {
            try
            {
                NotificationDatabase database = await NotificationDatabase.Instance;
                notifications = new ObservableCollection<Notification>(await database.GetItemsAsync());
                OnPropertyChanged(nameof(Notifications));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"we have errors {e}");
            }

        }
        public async void SendNotification(Notification notification)
        {
            try
            {
                NotificationDatabase database = await NotificationDatabase.Instance;
                notification.Completed = true;
                await database.SaveItemAsync(notification);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"we have errors {e}");
            }
        }
    }
}
