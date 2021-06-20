using NotificationTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationTest.Data
{
    public interface IRestService
    {
        Task<List<Notification>> GetNotification();
    }
}