using NotificationTest.Data;
using NotificationTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NotificationTest.ViewModels
{
    class CompletedViewModel
    {
        private ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();
        public ObservableCollection<Notification> Notifications { get { return notifications; } }

        public CompletedViewModel()
        {
            GetNotifications();
        }
        private async void GetNotifications()
        {
            try
            {
                NotificationDatabase database = await NotificationDatabase.Instance;
                notifications = new ObservableCollection<Notification>(await database.GetItemsByStatusAsync(false));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"we have errors {e}");
            }

        }
    }
}
