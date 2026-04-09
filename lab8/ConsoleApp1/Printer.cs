namespace ConsoleApp1
{
    public class Printer : Colleague
    {
        public bool SimulateFailure { get; set; } = false;

        public void StartPrint(Document document)
        {
            Console.WriteLine($"[Принтер] Физическая печать '{document.Title}'...");

            if (SimulateFailure)
            {
                SimulateFailure = false;
                Console.WriteLine($"[Принтер] ОШИБКА при печати!");
                _mediator.Notify(this, "PrintFailure", document);
            }
            else
            {
                Console.WriteLine($"[Принтер] Успешно напечатано!");
                _mediator.Notify(this, "PrintSuccess", document);
            }
        }
    }
}