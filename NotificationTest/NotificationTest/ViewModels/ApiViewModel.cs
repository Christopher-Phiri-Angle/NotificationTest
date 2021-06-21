using NotificationTest.Data;
using NotificationTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace NotificationTest.ViewModels
{
    public class ApiViewModel : BindableBase
    {
        private RestService _restService;
        public bool IsRefreshing { get; set; } = false;
        public ICommand LoadDataCommand { get; private set; }
        public ICommand RefreshCommand => new Command(async() => {
            IsRefreshing = true;
            OnPropertyChanged(nameof(IsRefreshing));
            await LoadData();
            IsRefreshing = false;
            OnPropertyChanged(nameof(IsRefreshing));
        });
        public LayoutState CurrentState { get; set; } = LayoutState.None;
        public ObservableCollection<Notification> Notifications { get; set; } = new ObservableCollection<Notification>();
        public ApiViewModel()
        {
            _restService = new RestService();
            LoadDataCommand = new Command(async () => await LoadData());
        }

        private async Task LoadData()
        {
            CurrentState = LayoutState.Loading;
            OnPropertyChanged(nameof(CurrentState));
            try
            {
                var notifications = await _restService.GetNotification();
                Notifications = new ObservableCollection<Notification>(notifications);
                CurrentState = LayoutState.Success;
                OnPropertyChanged(nameof(CurrentState));
                OnPropertyChanged(nameof(Notifications));

            }
            catch (Exception)
            {
                CurrentState = LayoutState.Error;
                OnPropertyChanged(nameof(CurrentState));
            }
        }
    }
}
