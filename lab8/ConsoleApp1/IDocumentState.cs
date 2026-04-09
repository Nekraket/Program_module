namespace ConsoleApp1
{
    public interface IDocumentState
    {
        void Print(Document document, IMediator mediator);
        void AddToQueue(Document document, IMediator mediator);
        void OnPrintSuccess(Document document, IMediator mediator);
        void OnPrintFailure(Document document, IMediator mediator);
        void Reset(Document document, IMediator mediator);
    }
}