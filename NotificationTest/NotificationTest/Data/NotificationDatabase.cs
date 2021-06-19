using NotificationTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace NotificationTest.Data
{
    class NotificationDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<NotificationDatabase> Instance = new AsyncLazy<NotificationDatabase>(async () =>
        {
            var instance = new NotificationDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Notification>();
            return instance;
        });

        public NotificationDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Notification>> GetItemsAsync()
        {
            return Database.Table<Notification>().ToListAsync();
        }

        public Task<List<Notification>> GetItemsByStatusAsync(bool completed)
        {
            return Database.Table<Notification>().Where(i => i.Completed == completed).ToListAsync();
        }

        public Task<Notification> GetItemAsync(int id)
        {
            return Database.Table<Notification>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Notification item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Notification item)
        {
            return Database.DeleteAsync(item);
        }

    }
}
