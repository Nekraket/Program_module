namespace ConsoleApp1
{
    public interface IFormatStrategy
    {
        string Format(string message, DateTime timestamp);
    }


    public class TextFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp) => $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {message}";
    }


    public class JsonFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp) => $"{{\"timestamp\":\"{timestamp:O}\",\"message\":\"{message}\"}}";
    }


    public class HtmlFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            return $"<div class='event'><span class='time'>[{timestamp:HH:mm:ss}]</span> <span class='message'>{message}</span></div>";
        }
    }
}
