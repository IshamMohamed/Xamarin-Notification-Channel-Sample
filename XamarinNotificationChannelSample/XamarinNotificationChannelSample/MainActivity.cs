using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace XamarinNotificationChannelSample
{
    [Activity(Label = "XamarinNotificationChannelSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private NotificationHelper myNoti;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button btnSendNotification = FindViewById<Button>(Resource.Id.buttonSendNotification);
            btnSendNotification.Click += BtnSendNotification_Click;
        }

        private void BtnSendNotification_Click(object sender, System.EventArgs e)
        {
            try
            {
                myNoti = new NotificationHelper();
                var myNotification = myNoti.notification("Test", "Hey! This is a test notification, did you notice the blue dot");
                myNoti.notify(1000, myNotification);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
    }
}

