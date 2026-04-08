namespace ConsoleApp1
{
    public class PrintingState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Printing] Документ '{document.Title}' уже печатается");
        }

        public void OnPrintSuccess(Document document)
        {
            Console.WriteLine($"[FSM: Printing → Done] Документ '{document.Title}' успешно напечатан");
            document.SetState(new DoneState());
        }

        public void OnPrintFailure(Document document)
        {
            Console.WriteLine($"[FSM: Printing → Error] Ошибка при печати документа '{document.Title}'");
            document.SetState(new ErrorState());
        }

        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: Printing] Нельзя сбросить документ во время печати");
        }
    }
}
