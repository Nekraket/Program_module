namespace ConsoleApp1
{
    public class ConsoleHandler : EventHandlerBase
    {
        public ConsoleHandler(IFormatStrategy strategy) : base(strategy)
        {
        }

        public override string FormatMessage(string eventType, MetricData data)
        {
            string message = $"{eventType}: {data}";
            return _formatStrategy.Format(message, data.Timestamp);
        }

        public override void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        public override void LogResult()
        {
            // опционально - значит ненадо...
        }
    }
}