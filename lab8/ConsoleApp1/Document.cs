namespace ConsoleApp1
{
    public class Document
    {
        public string Title { get; set; }
        public string DocumentId { get; private set; }
        private IDocumentState _state;

        public Document(string title)
        {
            Title = title;
            DocumentId = Guid.NewGuid().ToString().Substring(0, 8);
            _state = new NewState();
            Console.WriteLine($"[СОЗДАН] Документ '{Title}' (ID: {DocumentId}) в состоянии New");
        }

        public void SetState(IDocumentState state)
        {
            _state = state;
        }

        public IDocumentState GetCurrentState()
        {
            return _state;
        }

        public void Print()
        {
            _state.Print(this);
        }

        public void OnPrintSuccess()
        {
            _state.OnPrintSuccess(this);
        }

        public void OnPrintFailure()
        {
            _state.OnPrintFailure(this);
        }

        public void Reset()
        {
            _state.Reset(this);
        }

        public string GetStateName()
        {
            return _state.GetType().Name.Replace("State", "");
        }
    }
}
