using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Java.Lang;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinNotificationChannelSample
{
    class NotificationHelper
    {
        private NotificationManager nManager;
        const string CHANNEL = "MyNotificationChannel";

        public NotificationHelper()
        {
            NotificationChannel nChannel = new NotificationChannel(CHANNEL, "My First Channel", NotificationImportance.High);
            nChannel.EnableVibration(true);
            nChannel.SetShowBadge(true);

            AppnManager().CreateNotificationChannel(nChannel);
        }

        public Notification.Builder notification(string title, string text)
        {
            return new Notification.Builder(Application.Context, CHANNEL)
                .SetContentTitle(title)
                .SetContentText(text)
                .SetSmallIcon(Resource.Mipmap.ic_launcher)
                .SetAutoCancel(true);
        }

        public void notify(int id, Notification.Builder notification)
        {
            AppnManager().Notify(id, notification.Build());
        }

        private NotificationManager AppnManager()
        {
            return (nManager == null ? nManager = (NotificationManager)Application.Context.GetSystemService(Context.NotificationService) : nManager);
        }
    }
}