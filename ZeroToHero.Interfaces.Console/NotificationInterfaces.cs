namespace ZeroToHero.Interfaces.Console
{
    using System;
    public class NotificationInterfaces
    {
        public interface INotification
        {
            void SendNotification(string message);
        }
        public class EmailNotification : INotification
        {
            public void SendNotification(string message)
            {
                // Implement logic to send an email
                Console.WriteLine($"Sending email notification: {message}");
            }
        }
        public class SmsNotification : INotification
        {
            public void SendNotification(string message)
            {
                // Implement logic to send an SMS
                Console.WriteLine($"Sending SMS notification: {message}");
            }
        }

        public class PushNotification : INotification
        {
            public void SendNotification(string message)
            {
                // Implement logic to send a push notification
                Console.WriteLine($"Sending push notification: {message}");
            }
        }

        public static void BuildNotificationExample()
        {
            INotification notification = new EmailNotification();
            notification.SendNotification("This is a notification.");

            notification = new SmsNotification();
            notification.SendNotification("This is a notification.");

            notification = new PushNotification();
            notification.SendNotification("This is a notification.");
        }
    }
}
