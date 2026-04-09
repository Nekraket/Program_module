namespace ConsoleApp1
{
    public class Logger : Colleague
    {
        public void WriteMessage(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"[{timestamp}] {message}");
        }
    }
}