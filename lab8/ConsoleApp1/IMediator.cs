namespace ConsoleApp1
{
    public interface IMediator
    {
        void Notify(Colleague sender, string ev, Document document = null);
    }

    public abstract class Colleague
    {
        protected IMediator _mediator;

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
