using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationTest.Models
{
    public interface INotificationStore
    {
        Task<List<Notification>> GetItemsAsync();
        Task<List<Notification>> GetItemsByStatusAsync(bool completed);
        Task<Notification> GetItemAsync(int id);
        Task<int> SaveItemAsync(Notification item);
        Task<int> DeleteItemAsync(Notification item);
    }
}
