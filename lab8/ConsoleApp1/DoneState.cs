namespace ConsoleApp1
{
    public class DoneState : IDocumentState
    {
        public void Print(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Done] Документ '{document.Title}' уже напечатан");
        }

        public void AddToQueue(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Done] Нельзя добавить в очередь: документ уже напечатан");
        }

        public void OnPrintSuccess(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Done] Документ уже завершён");
        }

        public void OnPrintFailure(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Done] Невозможно: документ уже напечатан");
        }

        public void Reset(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Done] Нельзя сбросить напечатанный документ");
        }
    }
}
