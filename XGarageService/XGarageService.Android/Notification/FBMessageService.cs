using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Iid;
using Firebase.Messaging;
using Xamarin.Forms;

namespace XGarageService.Droid.Notification
{
    [Service(Name = "com.xproduct.xgarageservice.FBMessageService")]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FBMessageService: FirebaseMessagingService
    {
        public override void OnNewToken(string p0)
        {
            base.OnNewToken(p0);
        }
        public override void OnMessageReceived(RemoteMessage remoteMessage)
        {
            var msg = remoteMessage.GetNotification();

            var dataarray = remoteMessage.Data;
            var data1 = remoteMessage.Data.First();
            var body = data1.Value;
            OnRemoteNotification(body);
            base.OnMessageReceived(remoteMessage);
        }
        //--------------------------
        public static void InitNotifications(MainActivity ctx)
        {
            if (IsPlayServicesAvailable(ctx) == ebGoogleServiceStatus.enAvailable)
                CreateNotificationChannel(ctx);
            if (ctx.Intent.Extras != null)
            {
                if (ctx.Intent.Extras.KeySet().Contains("google.message_id"))
                {
                    var body = ctx.Intent.Extras.GetString("body");
                    OnRemoteNotification(body);
                }
            }
            var token = FirebaseInstanceId.Instance.Token;
        }
        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;
        public enum ebGoogleServiceStatus { enUnAvailable, enAvailable, enUnsupported }
        public static ebGoogleServiceStatus IsPlayServicesAvailable(Context ctx)
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(ctx);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    return ebGoogleServiceStatus.enUnAvailable;
                else
                    return ebGoogleServiceStatus.enUnsupported;
            }
            else
                return ebGoogleServiceStatus.enAvailable;
        }

        public static void CreateNotificationChannel(Context ctx)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)ctx.GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        public static void OnRemoteNotification(string body)
        {
            MessagingCenter.Send<NetCoreNotification.Notification.Message, string>(new NetCoreNotification.Notification.Message()
            {
                Body = body,
                sourceSystem = NetCoreNotification.Notification.enMessageSource.eniOs
            }, "OnNewNotification", body);

        }

    }
}