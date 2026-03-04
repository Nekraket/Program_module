namespace ConsoleApp1
{
    internal class Computer
    {
        public string? CPU;
        public int RAM;
        public string? GPU;
        public List<string> AdditionalComponents = new List<string>();

        public void Display()
        {
            Console.WriteLine("-------------КОНФИГУРАЦИЯ------------");
            Console.WriteLine($"CPU: {CPU ?? "Не указан"}");
            Console.WriteLine($"RAM: {RAM} ГБ");
            Console.WriteLine($"GPU: {GPU ?? "Не указана"}");
            Console.WriteLine($"Доп. комплектующие: {(AdditionalComponents.Count > 0 ? string.Join(", ", AdditionalComponents) : "Не указано")}");
            Console.WriteLine("-------------------------------------");
        }
    }
}