using NotificationTest.Interfaces;
using NotificationTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotificationTest.ViewModels
{
    public class NotDetailViewModel
    {
        private INotificationStore _notificationStore;
        private IPageService _pageService;

        public ICommand GoBackCommand => new Command(() => _pageService.PopAsync());
        public Notification Notification { get; }

        public NotDetailViewModel(Notification notification, INotificationStore notificationStore, IPageService pageService)
        {
            _notificationStore = notificationStore;
            _pageService = pageService;
            Notification = notification;
            System.Diagnostics.Debug.WriteLine($"{Notification} d: {notification}");
        }
    }
}
