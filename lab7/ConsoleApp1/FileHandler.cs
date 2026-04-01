namespace ConsoleApp1
{
    public class FileHandler : EventHandlerBase
    {
        private string _filePath;

        public FileHandler(IFormatStrategy strategy, string filePath) : base(strategy)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public override string FormatMessage(string eventType, MetricData data)
        {
            string message = $"{eventType}: {data}";
            return _formatStrategy.Format(message, data.Timestamp);
        }

        public override void SendMessage(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }

        public override void LogResult()
        {
            // опционально - значит ненадо...
        }
    }
}