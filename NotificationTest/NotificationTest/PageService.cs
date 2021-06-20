using NotificationTest.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotificationTest
{
    class PageService : IPageService
    {
        async Task<Page> IPageService.PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        async Task IPageService.PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }
}
