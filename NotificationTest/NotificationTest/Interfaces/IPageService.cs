using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotificationTest.Interfaces
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();
    }
}
