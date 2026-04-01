namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЭТАП 1. Паттерн «Наблюдатель» (Observer)\n");

            EventMonitor monitor = new();
            monitor.OnMetricExceeded += (e) =>
            {
                Console.WriteLine($"[ПОДПИСЧИК 1]: Получено событие!");
                Console.WriteLine($"[ПОДПИСЧИК 1]: Тип: {e.EventType}");
                Console.WriteLine($"[ПОДПИСЧИК 1]: {e.Data}");
                Console.WriteLine($"[ПОДПИСЧИК 1]: Время: {e.Data.Timestamp:HH:mm:ss}");
            };

            monitor.OnMetricExceeded += (e) =>
            {
                Console.WriteLine($"[ПОДПИСЧИК 2]: ВНИМАНИЕ! {e.EventType} на метрике {e.Data.MetricName}!");
            };

            Console.WriteLine("\n--- Проверка CPU (порог 80) ---");
            monitor.CheckMetric("CPU", 45, 80);   // Не превышает — событие НЕ генерируется

            Console.WriteLine("\n--- Проверка CPU (порог 80) ---");
            monitor.CheckMetric("CPU", 95, 80);   // Превышает — событие генерируется

            Console.WriteLine("\n--- Проверка Memory (порог 70) ---");
            monitor.CheckMetric("Memory", 85, 70); // Превышает — событие генерируется

            Console.WriteLine("\n--- Проверка Network (порог 100) ---");
            monitor.CheckMetric("Network", 50, 100); // Не превышает — событие НЕ генерируется
        }
    }
}
