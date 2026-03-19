namespace ConsoleApp1
{
    internal class TransparencyDecorator : DrawableDecorator
    {
        private int _transparencyLevel;

        public TransparencyDecorator(IDrawable wrappee, int transparencyLevel) : base(wrappee)
        {
            _transparencyLevel = transparencyLevel;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Прозрачность {_transparencyLevel}%]");
        }
    }
}
