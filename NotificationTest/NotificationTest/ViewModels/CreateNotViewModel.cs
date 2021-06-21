using NotificationTest.Data;
using NotificationTest.Interfaces;
using NotificationTest.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotificationTest.ViewModels
{
    public class CreateNotViewModel : BindableBase
    {
        private INotificationStore _notificationStore;
        private IPageService _pageService;
        public string Title { get; set; }
        public string Description { get; set; }
        private DateTime selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get;
            set;
        } = DateTime.Today;

        public TimeSpan SelectedTime
        {
            get;
            set;
        }

        public ICommand CreateNoteCommand => new Command(async () =>
        {

            try
            {
                SelectedTime = TimeSpan.FromTicks(new DateTime(selectedDate.Date.Ticks).AddTicks(SelectedTime.Ticks).Ticks);
                selectedDate = new DateTime(SelectedDate.TimeOfDay.Ticks).AddTicks(SelectedTime.Ticks);
                // validate
                System.Diagnostics.Debug.WriteLine($"Time: {SelectedTime}, Date: {selectedDate}");
                Notification notification = new Notification()
                {
                    Title = Title,
                    Description = Description,
                    Date = selectedDate,
                    Time = SelectedTime,
                    Completed = false,
                };

                _ = await _notificationStore.SaveItemAsync(notification);
                _ = await _pageService.PopAsync();

            }
            catch (Exception)
            {
                // Show error message
                Console.WriteLine("Failed");
            }

        });

        public CreateNotViewModel(INotificationStore notificationStore, IPageService pageService)
        {
            _notificationStore = notificationStore;
            _pageService = pageService;
        }
    }
}
