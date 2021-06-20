using System;
using System.IO;
using NotificationTest.Data;
using NotificationTest.Droid.Data;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace NotificationTest.Droid.Data
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "Notification.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}