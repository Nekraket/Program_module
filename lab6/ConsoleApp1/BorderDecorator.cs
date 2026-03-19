namespace ConsoleApp1
{
    internal class BorderDecorator : DrawableDecorator
    {
        private int _borderWidth;

        public BorderDecorator(IDrawable wrappee, int borderWidth) : base(wrappee)
        {
            _borderWidth = borderWidth;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Рамка толщиной {_borderWidth}]");
        }
    }
}
