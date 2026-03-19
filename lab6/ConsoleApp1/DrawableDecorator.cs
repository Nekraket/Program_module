namespace ConsoleApp1
{
    public abstract class DrawableDecorator : IDrawable
    {
        protected IDrawable _wrappee;
        public DrawableDecorator(IDrawable wrappee)
        {
            _wrappee = wrappee;
        }

        public virtual void Draw()
        {
            _wrappee.Draw();
        }
    }
}
