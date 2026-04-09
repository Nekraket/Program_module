namespace ConsoleApp1
{
    public class Document : Colleague
    {
        private IDocumentState _state;
        public string Title { get; set; }
        public string DocumentId { get; private set; }

        public Document(string title, IMediator mediator)
        {
            Title = title;
            DocumentId = Guid.NewGuid().ToString().Substring(0, 8);
            _state = new NewState();
            
            SetMediator(mediator);

            Console.WriteLine($"[СОЗДАН] Документ '{Title}' (ID: {DocumentId}) в состоянии New");
        }

        public void SetState(IDocumentState state) => _state = state;
        public IDocumentState GetCurrentState() => _state;
        public string GetStateName() => _state.GetType().Name.Replace("State", "");

        public void Print() => _state.Print(this, _mediator);
        public void AddToQueue() => _state.AddToQueue(this, _mediator);
        public void OnPrintSuccess() => _state.OnPrintSuccess(this, _mediator);
        public void OnPrintFailure() => _state.OnPrintFailure(this, _mediator);
        public void Reset() => _state.Reset(this, _mediator);
    }
}