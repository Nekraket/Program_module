namespace ConsoleApp1
{
    public class ScreenRenderer : IRenderingEngine
    {
        public void BeginRender()
        {
            Console.WriteLine("[Screen] Начало рендеринга");
        }

        public void EndRender()
        {
            Console.WriteLine("[Screen] Конец рендеринга");
        }

        public void RenderRectangle(float x, float y, float width, float height)
        {
            Console.WriteLine($"[Screen] Прямоугольник ({x},{y}) размер {width} x{height}");
        }

        public void RenderEllipse(float x, float y, float radiusX, float radiusY)
        {
            Console.WriteLine($"[Screen] Эллипс ({x},{y}) радиусы {radiusX},{radiusY}");
        }

        public void RenderLine(float x1, float y1, float x2, float y2)
        {
            Console.WriteLine($"[Screen] Линия от ({x1},{y1}) до ({x2},{y2})");
        }
    }
}
