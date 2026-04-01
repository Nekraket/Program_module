namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nЭТАП 1. Паттерн «Наблюдатель» (Observer)");
            EventMonitor monitor = new();

            Console.WriteLine("\nЭТАП 2. Паттерн «Стратегия» (Strategy)");

            IFormatStrategy textStrategy = new TextFormatStrategy();
            IFormatStrategy jsonStrategy = new JsonFormatStrategy();
            IFormatStrategy htmlStrategy = new HtmlFormatStrategy();

            Console.WriteLine("\nЭТАП 3. Паттерн «Шаблонный метод» (Template Method)");

            ConsoleHandler consoleHandler = new ConsoleHandler(textStrategy);
            FileHandler fileHandler = new FileHandler(jsonStrategy, "events.log");

            Console.WriteLine("Созданы обработчики событий:");
            Console.WriteLine("  - ConsoleHandler (вывод в консоль, текстовая стратегия)");
            Console.WriteLine("  - FileHandler    (запись в файл events.log, JSON-стратегия)");

            monitor.OnMetricExceeded += (e) => consoleHandler.ProcessEvent(e);
            monitor.OnMetricExceeded += (e) => fileHandler.ProcessEvent(e);

            Console.WriteLine("Обработчики подписаны на событие OnMetricExceeded\n");

            Console.WriteLine("\n--- Проверка CPU (порог 80) ---");
            monitor.CheckMetric("CPU", 45, 80);

            Console.WriteLine("\n--- Проверка CPU (порог 80) ---");
            monitor.CheckMetric("CPU", 95, 80);

            Console.WriteLine("\n--- Проверка Memory (порог 70) ---");
            monitor.CheckMetric("Memory", 85, 70);

            Console.WriteLine("\n--- Проверка Network (порог 100) ---");
            monitor.CheckMetric("Network", 50, 100);

            Console.WriteLine("\nДИНАМИЧЕСКАЯ СМЕНА СТРАТЕГИИ");

            Console.WriteLine("Меняем стратегию ConsoleHandler с Text на HTML...");
            consoleHandler.SetStrategy(htmlStrategy);

            Console.WriteLine("\n--- Проверка CPU (порог 80) после смены стратегии ---");
            monitor.CheckMetric("CPU", 99, 80);

            Console.WriteLine($"Проверьте файл events.log для просмотра записей в JSON-формате");
        }
    }
}