using NotificationTest.Data;
using NotificationTest.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotificationTest.ViewModels
{
    class CreateNotViewModel : BindableBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        private DateTime selectedDate = DateTime.Now;
        public DateTime SelectedDate { get { return selectedDate; } set { selectedDate = value; } }
        public TimeSpan selectedTime = new TimeSpan(DateTime.Now.Ticks);
        public TimeSpan SelectedTime { get; set; }
        public ICommand CreateNoteCommand => new Command(async () =>
        {

            try
            {
                NotificationDatabase database = await NotificationDatabase.Instance;
                // validate
                Notification notification = new Notification()
                {
                    Title = Title,
                    Description = Description,
                    Date = selectedDate,
                    Time = SelectedTime,
                    Completed = false,
                };

                _ = await database.SaveItemAsync(notification);
                _ = await Application.Current.MainPage.Navigation.PopAsync();
                // Save in db
                // Go to main

            }
            catch (Exception)
            {
                // Show error message
                Console.WriteLine("Failed");
            }

        });
    }
}
