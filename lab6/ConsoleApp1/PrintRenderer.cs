namespace ConsoleApp1
{
    internal class PrintRenderer : IRenderingEngine
    {
        public void BeginRender()
        {
            Console.WriteLine("[Print] Начало рендеринга");
        }

        public void EndRender()
        {
            Console.WriteLine("[Print] Конец рендеринга");
        }

        public void RenderRectangle(float x, float y, float width, float height)
        {
            Console.WriteLine($"[Print] Прямоугольник ({x},{y}) размер {width}x{height}");
        }

        public void RenderEllipse(float x, float y, float radiusX, float radiusY)
        {
            Console.WriteLine($"[Print] Эллипс ({x},{y}) радиусы {radiusX},{radiusY}");
        }

        public void RenderLine(float x1, float y1, float x2, float y2)
        {
            Console.WriteLine($"[Print] Линия от ({x1},{y1}) до ({x2},{y2})");
        }
    }
}
