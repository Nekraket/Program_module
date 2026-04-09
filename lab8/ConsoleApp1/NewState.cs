namespace ConsoleApp1
{
    public class NewState : IDocumentState
    {
        public void Print(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: New → Printing] Документ '{document.Title}' начинает печать");
            document.SetState(new PrintingState());
            mediator.Notify(document, "RequestPrint", document);
        }

        public void AddToQueue(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: New] Документ '{document.Title}' добавлен в очередь");
            mediator.Notify(document, "AddToQueue", document);
        }

        public void OnPrintSuccess(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: New] Невозможно: документ ещё не печатается");
        }

        public void OnPrintFailure(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: New] Невозможно: документ ещё не печатается");
        }

        public void Reset(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: New] Документ уже в состоянии New");
        }
    }
}
