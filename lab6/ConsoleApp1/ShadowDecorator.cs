namespace ConsoleApp1
{
    internal class ShadowDecorator : DrawableDecorator
    {
        private int _shadowOffset;

        public ShadowDecorator(IDrawable wrappee, int shadowOffset) : base(wrappee)
        {
            _shadowOffset = shadowOffset;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Тень со смещением {_shadowOffset}px]");
        }
    }
}
