using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace NotificationTest
{
    class Constants
    {
        public static string RestUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? 
            "http://10.0.2.2:5001" :
            "http://localhost:5001";
    }
}
