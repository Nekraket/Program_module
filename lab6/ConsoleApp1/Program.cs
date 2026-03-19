namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЭТАП 1. Паттерн «Приспособленец» (Flyweight)\n");

            Console.WriteLine("Демонстрация разделения символов с одинаковым внутренним состоянием\n");

            CharacterFactory factory = new CharacterFactory();

            Console.WriteLine("--- Запрашиваем символы из фабрики ---\n");

            Character char1 = factory.GetCharacter('A', "Arial", 12);
            Character char2 = factory.GetCharacter('B', "Arial", 12);
            Character char3 = factory.GetCharacter('A', "Times New Roman", 14);
            Character char4 = factory.GetCharacter('A', "Arial", 12);
            Character char5 = factory.GetCharacter('C', "Arial", 12);
            Character char6 = factory.GetCharacter('B', "Arial", 12);

            Console.WriteLine("\n--- Используем легковесы с разным внешним состоянием (координатами) ---\n");

            char1.Draw(10, 20);
            char1.Draw(30, 20);
            char1.Draw(50, 20);
            char2.Draw(10, 40);
            char3.Draw(10, 60);
            char4.Draw(70, 20);
            char5.Draw(90, 40);
            char6.Draw(110, 40);

            Console.WriteLine("\n--- ИТОГ ---");
            Console.WriteLine($"Всего создано уникальных легковесов: {factory.GetCount()}");
        }
    }
}
