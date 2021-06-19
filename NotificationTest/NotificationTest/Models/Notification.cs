using NotificationTest.ViewModels;
using SQLite;
using System;

namespace NotificationTest.Models
{
    public class Notification: BindableBase
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime Date { get; set; }
        TimeSpan time;
        public TimeSpan Time
        {
            get => time;
            set
            {
                time = value;
                Seconds = "";
                Minutes = "";
                Hours = "";
                OnPropertyChanged("Time");
            }
        }
        public string Hours { get { return Time.Hours.ToString("00"); } set => OnPropertyChanged(); }
        public string Minutes { get { return Time.Minutes.ToString("00"); } set => OnPropertyChanged(); }
        public string Seconds { get { return Time.Seconds.ToString("00"); } set => OnPropertyChanged(); }

    }
}
