namespace ConsoleApp1
{
    public class DoneState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Done] Документ '{document.Title}' уже напечатан");
        }

        public void OnPrintSuccess(Document document)
        {
            Console.WriteLine($"[FSM: Done] Документ уже завершён");
        }

        public void OnPrintFailure(Document document)
        {
            Console.WriteLine($"[FSM: Done] Невозможно: документ уже напечатан");
        }

        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: Done] Нельзя сбросить напечатанный документ");
        }
    }
}
