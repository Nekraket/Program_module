namespace SOLID_Fundamentals
{
    //ISP (Принцип разделения интерфейсов)

    //Операции с заказами
    public interface IOrderCrudOperations
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }

    //Операции с платежами
    public interface IPaymentOperations
    {
        void ProcessPayment(Order order);
    }

    //Операции с доставкой
    public interface IShippingOperations
    {
        void ShipOrder(Order order);
    }

    //Операции со счетами
    public interface IInvoiceOperations
    {
        void GenerateInvoice(Order order);
    }

    //Операции с уведомлениями
    public interface INotificationOperations
    {
        void SendNotification(Order order);
    }

    //Операции с отчетами
    public interface IReportOperations
    {
        void GenerateReport(DateTime from, DateTime to);
        void ExportToExcel(string filePath);
    }

    //Операции с базой данных
    public interface IDatabaseOperations
    {
        void BackupDatabase();
        void RestoreDatabase();
    }



    public class OrderManager : IOrderCrudOperations, IPaymentOperations, IShippingOperations, IInvoiceOperations, INotificationOperations, IReportOperations, IDatabaseOperations
    {
        public void CreateOrder(Order order)
        {
            Console.WriteLine("Order created");
        }

        public void UpdateOrder(Order order)
        {
            Console.WriteLine("Order updated");
        }

        public void DeleteOrder(int orderId)
        {
            Console.WriteLine("Order deleted");
        }

        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Payment processed");
        }

        public void ShipOrder(Order order)
        {
            Console.WriteLine("Order shipped");
        }

        public void GenerateInvoice(Order order)
        {
            Console.WriteLine("Invoice generated");
        }

        public void SendNotification(Order order)
        {
            Console.WriteLine("Notification sent");
        }

        public void GenerateReport(DateTime from, DateTime to)
        {
            Console.WriteLine("Report generated");
        }

        public void ExportToExcel(string filePath)
        {
            Console.WriteLine("Exported to Excel");
        }

        public void BackupDatabase()
        {
            Console.WriteLine("Database backed up");
        }

        public void RestoreDatabase()
        {
            Console.WriteLine("Database restored");
        }
    }

    public class CustomerPortal : IOrderCrudOperations
    {
        public void CreateOrder(Order order)
        {
            Console.WriteLine("Order created by customer");
        }

        public void UpdateOrder(Order order)
        {
            Console.WriteLine("Order updated by customer");
        }

        public void DeleteOrder(int orderId)
        {
            Console.WriteLine("Order deleted by customer");
        }
    }
}
