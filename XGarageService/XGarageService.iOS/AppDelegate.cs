using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Syncfusion.SfCalendar.XForms.iOS;
using UIKit;
using Xamarin.Forms;
//using Syncfusion.SfCalendar.XForms.iOS;

namespace XGarageService.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.SetFlags("Expander_Experimental");
            global::Xamarin.Forms.Forms.SetFlags("Shapes_Experimental");
            global::Xamarin.Forms.Forms.Init();
            SfCalendarRenderer.Init();

            //Syncfusion.XForms.iOS.Accordion.SfAccordionRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfCheckBoxRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfButtonRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfRadioButtonRenderer.Init();
            Syncfusion.XForms.iOS.Expander.SfExpanderRenderer.Init();

            LoadApplication(new App());

            Notification.iOSNotificationService.InitNotification(app, options);
            return base.FinishedLaunching(app, options);
        }
        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            Notification.iOSNotificationService.RegisteredForRemoteNotifications(application, deviceToken);
        }
       
        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            Notification.iOSNotificationService.ReceivedRemoteNotification(application, userInfo);
        }
        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            Notification.iOSNotificationService.FailedToRegisterForRemoteNotifications(application, error);
        }
        
    }
}
