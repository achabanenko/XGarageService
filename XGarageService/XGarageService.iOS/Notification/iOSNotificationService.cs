using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using NetCoreNotification.Notification;
using Xamarin.Forms;

[assembly: Dependency(typeof(XGarageService.iOS.Notification.iOSNotificationService))]
namespace XGarageService.iOS.Notification
{
    
    public class iOSNotificationService : INotificationMessage
    {
        public static Message message = null;
        public Message GetStartNotification()
        {
            return message;
        }
        public static void InitNotification(UIApplication app, NSDictionary options)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                                               UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
                                           );
                app.RegisterUserNotificationSettings(notificationSettings);
                app.RegisterForRemoteNotifications();
            }
            else
            {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }
            if (options != null)
            {
                // check for a remote notification
                if (options.ContainsKey(UIApplication.LaunchOptionsRemoteNotificationKey))
                {
                    NSDictionary remoteNotification = options[UIApplication.LaunchOptionsRemoteNotificationKey] as NSDictionary;
                    if (remoteNotification != null)
                    {
                        var body = remoteNotification.Values[0].ValueForKey(new NSString("alert")).ValueForKey(new NSString("body")).ToString();
                        OnRemoteNotification(body);

                    }
                }
            }

        }
        public static void OnRemoteNotification(string body)
        {
            MessagingCenter.Send<NetCoreNotification.Notification.Message, string>(new NetCoreNotification.Notification.Message()
            {
                Body = body,
                sourceSystem = NetCoreNotification.Notification.enMessageSource.eniOs
            }, "OnNewNotification", body);

        }
        public static void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            var tokenStringBase64 = deviceToken.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
            var s = BitConverter.ToString(deviceToken.ToArray()).Replace("-", "");
            Console.WriteLine(s);
        }
        public static void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            var body = userInfo.Values[0].ValueForKey(new NSString("data")).ToString();
            OnRemoteNotification(body);
        }
        public static void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {

        }
    }
}