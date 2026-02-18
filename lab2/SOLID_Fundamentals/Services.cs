namespace SOLID_Fundamentals
{
    using System;

    //DIP (Принцип инверсии зависимостей)

    //Абстракция для уведомлений
    public interface INotificationChannel
    {
        void Send(string recipient, string subject, string body);
    }



    public class EmailService : INotificationChannel
    {
        public void Send(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to}: {subject}");
        }
    }

    public class SmsService : INotificationChannel
    {
        public void Send(string phoneNumber, string subject, string body)
        {
            Console.WriteLine($"Sending SMS to {phoneNumber}: {body}");
        }
    }

    public class OrderService
    {
        private readonly INotificationChannel _emailChannel;
        private readonly INotificationChannel _smsChannel;

        public OrderService(INotificationChannel emailChannel, INotificationChannel smsChannel)
        {
            _emailChannel = emailChannel;
            _smsChannel = smsChannel;
        }

        public void PlaceOrder(Order order)
        {
            _emailChannel.Send(order.CustomerEmail, "Order Confirmation", "Your order has been placed");
            _smsChannel.Send(order.CustomerPhone, "Order Confirmation", "Your order has been placed");
        }
    }

    public class NotificationService
    {
        private readonly INotificationChannel _notificationChannel;

        public NotificationService(INotificationChannel notificationChannel)
        {
            _notificationChannel = notificationChannel;
        }

        public void SendPromotion(string email, string promotion)
        {
            _notificationChannel.Send(email, "Special Promotion", promotion);
        }
    }
}
