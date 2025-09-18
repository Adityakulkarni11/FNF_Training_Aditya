using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingLib
{
    public interface INotificationService
    {
        bool SendNotification(string deviceInfo, string message);
    }
    public class EmailService : INotificationService
    {
        public bool SendNotification(string deviceInfo, string message)
        {
            // Simulate sending an email notification
            Console.WriteLine($"Email sent to {deviceInfo} with message: {message}");
            return true;
        }
    }
    public class NotificationService
    {
        private readonly INotificationService _notificationService;
        public NotificationService(INotificationService notificationService)
        {
            this._notificationService = notificationService;
        }
        public bool NotifyUser(string deviceInfo, string message)
        {
            // Simulate sending a notification
            return _notificationService.SendNotification(deviceInfo, message);
        }
    }
}
