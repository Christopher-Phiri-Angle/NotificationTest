using Newtonsoft.Json;
using NotificationTest.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotificationTest.Data
{
    public class RestService: IRestService
    {
        HttpClient client;
        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<List<Notification>> GetNotification()
        {
            Uri uri = new Uri($"{Constants.RestUrl}/Notification");

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<List<Notification>>(content);
                System.Diagnostics.Debug.WriteLine(item.Count);

                return item;
            }
            throw new Exception();
        }
    }
}
