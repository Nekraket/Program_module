namespace ConsoleApp1
{
    public abstract class EventHandlerBase
    {
        public IFormatStrategy _formatStrategy;

        public EventHandlerBase(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }

        public void SetStrategy(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }


        public void ProcessEvent(MetricEventArgs e)
        {
            var message = FormatMessage(e.EventType, e.Data);
            SendMessage(message);
            LogResult();
        }

        public abstract string FormatMessage(string eventType, MetricData data);
        public abstract void SendMessage(string message);
        public abstract void LogResult();
    }
}
