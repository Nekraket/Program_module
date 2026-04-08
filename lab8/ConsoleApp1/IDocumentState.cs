namespace ConsoleApp1
{
    public interface IDocumentState
    {
        void Print(Document document);
        void OnPrintSuccess(Document document);
        void OnPrintFailure(Document document);
        void Reset(Document document);
    }
}
