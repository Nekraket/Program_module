namespace ConsoleApp1
{
    public abstract class GraphicObject : IDrawable
    {
        protected IRenderingEngine _engine;
        public GraphicObject(IRenderingEngine engine)
        {
            _engine = engine;
        }
        public abstract void Draw();
        public abstract void Move(float dx, float dy);
    }
}
