using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreNotification.Notification
{
    public interface INotificationMessage
    {
        Message GetStartNotification();
    }
    public enum enMessageSource { enAndroid = 0, eniOs = 1 }
    public class Message
    {
        public enMessageSource sourceSystem { get; set; }
        public string Body { get; set; }
    }
}
