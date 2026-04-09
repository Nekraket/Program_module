namespace ConsoleApp1
{
    public class PrintingState : IDocumentState
    {
        public void Print(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Printing] Документ '{document.Title}' уже печатается");
        }

        public void AddToQueue(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Printing] Нельзя добавить в очередь: документ уже печатается");
        }

        public void OnPrintSuccess(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Printing → Done] Документ '{document.Title}' успешно напечатан");
            document.SetState(new DoneState());
        }

        public void OnPrintFailure(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Printing → Error] Ошибка при печати документа '{document.Title}'");
            document.SetState(new ErrorState());
        }

        public void Reset(Document document, IMediator mediator)
        {
            Console.WriteLine($"[FSM: Printing] Нельзя сбросить документ во время печати");
        }
    }
}
