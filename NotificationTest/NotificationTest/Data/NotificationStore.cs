using NotificationTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace NotificationTest.Data
{
    public class NotificationStore : INotificationStore
    {
        private SQLiteAsyncConnection _connection;
        public NotificationStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Notification>();
        }

        public Task<List<Notification>> GetItemsAsync()
        {
            return _connection.Table<Notification>().ToListAsync();
        }

        public Task<List<Notification>> GetItemsByStatusAsync(bool completed)
        {
            return _connection.Table<Notification>().Where(i => i.Completed == completed).ToListAsync();
        }

        public Task<Notification> GetItemAsync(int id)
        {
            return _connection.Table<Notification>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Notification item)
        {
            if (item.ID != 0)
            {
                return _connection.UpdateAsync(item);
            }
            else
            {
                return _connection.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Notification item)
        {
            return _connection.DeleteAsync(item);
        }

    }
}
