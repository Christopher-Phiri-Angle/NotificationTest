using NotificationTest.Data;
using NotificationTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotificationTest.ViewModels
{
    public class ApiViewModel : BindableBase
    {
        public ICommand LoadDataCommand { get; private set; }
        private RestService _restService;
        public ObservableCollection<Notification> Notifications { get; set; } = new ObservableCollection<Notification>();
        public ApiViewModel()
        {
            _restService = new RestService();
            LoadDataCommand = new Command(async () => await LoadData());
        }

        private async Task LoadData()
        {
            var notifications = await _restService.GetNotification();
            Notifications = new ObservableCollection<Notification>(notifications);
            OnPropertyChanged(nameof(Notifications));
        }
    }
}
