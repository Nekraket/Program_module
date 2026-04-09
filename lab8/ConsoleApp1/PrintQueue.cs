namespace ConsoleApp1
{
    public class PrintQueue : Colleague
    {
        private Queue<Document> _documents = new Queue<Document>();

        public void EnqueueItem(Document document)
        {
            _documents.Enqueue(document);
            Console.WriteLine($"[Очередь] Документ '{document.Title}' добавлен в очередь (всего: {_documents.Count})");
            _mediator.Notify(this, "Enqueued", document);
        }

        public Document DequeueItem()
        {
            return _documents.Dequeue();
        }

        public bool IsEmpty => _documents.Count == 0;

        public int GetCount() => _documents.Count;
    }
}