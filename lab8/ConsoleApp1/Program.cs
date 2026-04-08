namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЭТАП 1. Паттерн «Состояние» (State) ===\n");

            Document doc = new Document("Отчёт по продажам");

            Console.WriteLine("\n1. Начинаем печать (New → Printing):");
            doc.Print();

            Console.WriteLine("\n2. Пытаемся снова напечатать (запрещено):");
            doc.Print();

            Console.WriteLine("\n3. Успешное завершение печати (Printing → Done):");
            doc.OnPrintSuccess();

            Console.WriteLine("\n4. Пытаемся напечатать снова (запрещено):");
            doc.Print();

            Console.WriteLine("\n=== Демонстрация ошибки и восстановления ===\n");

            Document errorDoc = new Document("Проблемный файл");

            Console.WriteLine("\n1. Начинаем печать:");
            errorDoc.Print();

            Console.WriteLine("\n2. Ошибка при печати (Printing → Error):");
            errorDoc.OnPrintFailure();

            Console.WriteLine("\n3. Пытаемся напечатать (запрещено):");
            errorDoc.Print();

            Console.WriteLine("\n4. Сброс документа (Error → New):");
            errorDoc.Reset();

            Console.WriteLine("\n5. Повторная печать после сброса:");
            errorDoc.Print();

            Console.WriteLine("\n6. Успешное завершение:");
            errorDoc.OnPrintSuccess();
        }
    }
}
