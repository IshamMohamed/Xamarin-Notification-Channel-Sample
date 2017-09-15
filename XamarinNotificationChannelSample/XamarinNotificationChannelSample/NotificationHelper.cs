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

        public NotificationHelper(Context cntx)
        {
            NotificationChannel nChannel = new NotificationChannel(CHANNEL, "My First Channel", NotificationImportance.High);
            nChannel.Group = "XAPP_CHANNEL_GROUP";
            nChannel.EnableVibration(true);
            nChannel.SetShowBadge(true);

            AppnManager().CreateNotificationChannel(nChannel);
        }

        public Notification.Builder notification(string title, string text)
        {
            return new Notification.Builder(Application.Context, CHANNEL)
                .SetContentTitle(title)
                .SetContentText(text)
                .SetGroup("XAPP_CHANNEL_GROUP")
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