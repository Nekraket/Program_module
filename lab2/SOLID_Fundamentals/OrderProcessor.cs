using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Fundamentals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //SRP (Принцип единственной ответственности)

    //Хранение заказов
    public class OrderRepository
    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
            Console.WriteLine($"Order {order.Id} added");
        }

        public Order GetById(int orderId)
        {
            return orders.FirstOrDefault(o => o.Id == orderId);
        }

        public List<Order> GetAll()
        {
            return orders;
        }
    }

    //Валидация заказов
    public class OrderValidator
    {
        public void Validate(Order order)
        {
            if (order.TotalAmount <= 0)
                throw new Exception("Invalid order amount");
        }
    }

    //Обработка платежей
    public class PaymentProcessor
    {
        public void Process(string paymentMethod, decimal amount)
        {
            Console.WriteLine($"Processing payment: {paymentMethod}, Amount: {amount}");
        }
    }

    //Управление инвентарем
    public class InventoryManager
    {
        public void Update(List<string> items)
        {
            Console.WriteLine($"Updating inventory for {items.Count} items");
        }
    }

    //Отправка email
    public class SendEmailService
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Sending email to {to}: {message}");
        }
    }

    //Логирование
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }

    //Генерация квитанций
    public class ReceiptGenerator
    {
        public void Generate(Order order)
        {
            Console.WriteLine($"Generating receipt for order {order.Id}");
        }
    }

    //Генерация отчетов
    public class ReportGenerator
    {
        public void GenerateMonthlyReport(List<Order> orders)
        {
            decimal totalRevenue = orders.Sum(o => o.TotalAmount);
            int totalOrders = orders.Count;
            Console.WriteLine($"Monthly Report: {totalOrders} orders, Revenue: {totalRevenue:C}");
        }
    }

    //Экспорт в Excel
    public class ExcelExporter
    {
        public void Export(List<Order> orders, string filePath)
        {
            Console.WriteLine($"Exporting {orders.Count} orders to {filePath}");
        }
    }


    //Основной процессор заказов (координатор)
    public class OrderProcessor
    {
        private readonly OrderRepository _orderRepository;
        private readonly OrderValidator _validator;
        private readonly PaymentProcessor _paymentProcessor;
        private readonly InventoryManager _inventoryManager;
        private readonly SendEmailService _emailService;
        private readonly Logger _logger;
        private readonly ReceiptGenerator _receiptGenerator;
        private readonly ReportGenerator _reportGenerator;
        private readonly ExcelExporter _excelExporter;

        public OrderProcessor()
        {
            _orderRepository = new OrderRepository();
            _validator = new OrderValidator();
            _paymentProcessor = new PaymentProcessor();
            _inventoryManager = new InventoryManager();
            _emailService = new SendEmailService();
            _logger = new Logger();
            _receiptGenerator = new ReceiptGenerator();
            _reportGenerator = new ReportGenerator();
            _excelExporter = new ExcelExporter();
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
        }

        public void ProcessOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                Console.WriteLine($"Processing order {orderId}");

                // Валидация
                _validator.Validate(order);

                // Обработка платежа
                _paymentProcessor.Process(order.PaymentMethod, order.TotalAmount);

                // Обновление инвентаря
                _inventoryManager.Update(order.Items);

                // Отправка email
                _emailService.Send(order.CustomerEmail, $"Order {orderId} processed");

                // Логирование
                _logger.Log($"Order {orderId} processed at {DateTime.Now}");

                // Генерация квитанции
                _receiptGenerator.Generate(order);
            }
        }

        public void GenerateMonthlyReport()
        {
            var orders = _orderRepository.GetAll();
            _reportGenerator.GenerateMonthlyReport(orders);
        }

        public void ExportToExcel(string filePath)
        {
            var orders = _orderRepository.GetAll();
            _excelExporter.Export(orders, filePath);
        }
    }
}
