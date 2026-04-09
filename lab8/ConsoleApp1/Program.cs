namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("=== ЭТАП 1. Паттерн «Состояние» (State) ===\n");

            //Document doc = new Document("Отчёт по продажам");

            //Console.WriteLine("\n1. Начинаем печать (New → Printing):");
            //doc.Print();

            //Console.WriteLine("\n2. Пытаемся снова напечатать (запрещено):");
            //doc.Print();

            //Console.WriteLine("\n3. Успешное завершение печати (Printing → Done):");
            //doc.OnPrintSuccess();

            //Console.WriteLine("\n4. Пытаемся напечатать снова (запрещено):");
            //doc.Print();

            //Console.WriteLine("\n=== Демонстрация ошибки и восстановления ===\n");

            //Document errorDoc = new Document("Проблемный файл");

            //Console.WriteLine("\n1. Начинаем печать:");
            //errorDoc.Print();

            //Console.WriteLine("\n2. Ошибка при печати (Printing → Error):");
            //errorDoc.OnPrintFailure();

            //Console.WriteLine("\n3. Пытаемся напечатать (запрещено):");
            //errorDoc.Print();

            //Console.WriteLine("\n4. Сброс документа (Error → New):");
            //errorDoc.Reset();

            //Console.WriteLine("\n5. Повторная печать после сброса:");
            //errorDoc.Print();

            //Console.WriteLine("\n6. Успешное завершение:");
            //errorDoc.OnPrintSuccess();




            Console.WriteLine("=== ЭТАП 2. Паттерн «Посредник» (Mediator) ===\n");

            Printer printer = new Printer();
            PrintQueue queue = new PrintQueue();
            Logger logger = new Logger();

            PrintSystemMediator mediator = new PrintSystemMediator(printer, queue, logger);

            Dispatcher dispatcher = new Dispatcher();
            dispatcher.SetMediator(mediator);

            Document doc1 = new Document("Отчёт по продажам Q1", mediator);
            Document doc2 = new Document("Договор поставки", mediator);
            Document doc3 = new Document("Презентация проекта", mediator);

            Console.WriteLine("\n--- Добавление документов в очередь ---\n");
            doc1.AddToQueue();
            doc2.AddToQueue();
            doc3.AddToQueue();

            Console.WriteLine("\n--- Настройка: принтер сломается на втором документе ---\n");
            printer.SimulateFailure = true;

            Console.WriteLine("\n--- Запуск обработки очереди ---\n");
            dispatcher.CommandProcessQueue();
        }
    }
}
