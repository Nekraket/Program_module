namespace ConsoleApp1
{
    public class NewState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: New → Printing] Документ '{document.Title}' начинает печать");
            document.SetState(new PrintingState());
        }

        public void OnPrintSuccess(Document document)
        {
            Console.WriteLine($"[FSM: New] Невозможно: документ ещё не печатается");
        }

        public void OnPrintFailure(Document document)
        {
            Console.WriteLine($"[FSM: New] Невозможно: документ ещё не печатается");
        }

        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: New] Документ уже в состоянии New");
        }
    }
}
