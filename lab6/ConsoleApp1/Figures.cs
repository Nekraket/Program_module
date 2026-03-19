namespace ConsoleApp1
{
    internal class Rectangle : GraphicObject
    {
        private float _x, _y, _width, _height;

        public Rectangle(IRenderingEngine engine, float x, float y, float width, float height) : base(engine)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public override void Draw()
        {
            _engine.RenderRectangle(_x, _y, _width, _height);
        }

        public override void Move(float dx, float dy)
        {
            _x += dx;
            _y += dy;
            Console.WriteLine($"[Rectangle] Перемещён на ({dx}, {dy}), новая позиция: ({_x}, {_y})");
        }
    }



    internal class Ellipse : GraphicObject
    {
        private float _x, _y, _radiusX, _radiusY;

        public Ellipse(IRenderingEngine engine, float x, float y, float radiusX, float radiusY) : base(engine)
        {
            _x = x;
            _y = y;
            _radiusX = radiusX;
            _radiusY = radiusY;
        }

        public override void Draw()
        {
            _engine.RenderEllipse(_x, _y, _radiusX, _radiusY);
        }

        public override void Move(float dx, float dy)
        {
            _x += dx;
            _y += dy;
            Console.WriteLine($"[Ellipse] Перемещён на ({dx}, {dy}), новая позиция: ({_x}, {_y})");
        }
    }



    internal class Line : GraphicObject
    {
        private float _x1, _y1, _x2, _y2;

        public Line(IRenderingEngine engine, float x1, float y1, float x2, float y2) : base(engine)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        public override void Draw()
        {
            _engine.RenderLine(_x1, _y1, _x2, _y2);
        }

        public override void Move(float dx, float dy)
        {
            _x1 += dx;
            _y1 += dy;
            _x2 += dx;
            _y2 += dy;
            Console.WriteLine($"[Line] Перемещена на ({dx}, {dy}), новые координаты: ({_x1},{_y1})-({_x2},{_y2})");
        }
    }
}
