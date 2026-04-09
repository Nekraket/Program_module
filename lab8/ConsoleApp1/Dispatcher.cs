namespace ConsoleApp1
{
    public class Dispatcher : Colleague
    {
        public void CommandProcessQueue()
        {
            Console.WriteLine("[Диспетчер] Отдана команда на обработку очереди");
            _mediator.Notify(this, "ProcessQueue");
        }
    }
}