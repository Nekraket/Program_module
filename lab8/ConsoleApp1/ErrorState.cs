namespace ConsoleApp1
{
    public class ErrorState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Error] Печать невозможна. Сначала сбросьте документ (Reset)");
        }

        public void OnPrintSuccess(Document document)
        {
            Console.WriteLine($"[FSM: Error] Невозможно: документ в состоянии ошибки");
        }

        public void OnPrintFailure(Document document)
        {
            Console.WriteLine($"[FSM: Error] Документ уже в состоянии ошибки");
        }

        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: Error → New] Документ '{document.Title}' сброшен и готов к повторной печати");
            document.SetState(new NewState());
        }
    }
}
