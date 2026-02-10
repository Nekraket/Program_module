namespace OOP_Fundamentals_Library
{
    public class Customer : Person
    {
        public override void PrintInfo()
        {
            Console.WriteLine($"Customer: {Name}, {Age} years old");
        }
    }
}
