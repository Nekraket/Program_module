namespace ConsoleApp1
{
    public class PrintSystemMediator : IMediator
    {
        private readonly Printer _printer;
        private readonly PrintQueue _queue;
        private readonly Logger _logger;

        public PrintSystemMediator(Printer printer, PrintQueue queue, Logger logger)
        {
            _printer = printer;
            _queue = queue;
            _logger = logger;

            _printer.SetMediator(this);
            _queue.SetMediator(this);
            _logger.SetMediator(this);
        }

        public void Notify(Colleague sender, string ev, Document document = null)
        {
            switch (ev)
            {
                case "AddToQueue":
                    _queue.EnqueueItem(document);
                    break;

                case "Enqueued":
                    _logger.WriteMessage($"Документ '{document.Title}' помещён в очередь печати");
                    break;

                case "RequestPrint":
                    _logger.WriteMessage($"Начинается печать документа '{document.Title}'");
                    _printer.StartPrint(document);
                    break;

                case "ProcessQueue":
                    ProcessQueue();
                    break;

                case "PrintSuccess":
                    document.OnPrintSuccess();
                    _logger.WriteMessage($"Документ '{document.Title}' успешно напечатан");
                    break;

                case "PrintFailure":
                    document.OnPrintFailure();
                    _logger.WriteMessage($"ОШИБКА при печати документа '{document.Title}'");
                    break;

                case "DocumentReset":
                    _logger.WriteMessage($"Документ '{document.Title}' сброшен и повторно добавлен в очередь");
                    document.AddToQueue();
                    break;

                default:
                    _logger.WriteMessage($"Неизвестное событие: {ev}");
                    break;
            }
        }

        private void ProcessQueue()
        {
            if (_queue.IsEmpty)
            {
                _logger.WriteMessage("Очередь пуста, нечего печатать");
                return;
            }

            var nextDoc = _queue.DequeueItem();
            _logger.WriteMessage($"Из очереди извлечён документ '{nextDoc.Title}'");
            nextDoc.Print();
        }
    }
}