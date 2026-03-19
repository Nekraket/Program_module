namespace ConsoleApp1
{
    public class HighResolutionImage : IImage
    {
        private string _filename;
        private int _width;
        private int _height;
        public HighResolutionImage(string filename)
        {
            _filename = filename;
            Console.Write($"Загрузка {_filename}... ");
            LoadFromDisk();
        }
        private void LoadFromDisk()
        {
            Thread.Sleep(1000);
            _width = 1920;
            _height = 1080;
            Console.WriteLine($"загружено ({_width}x{_height})");
        }
        public void Draw()
        {
            Console.WriteLine($"Отрисовка изображения {_filename}");
        }
        public int GetWidth()
        {
            return _width;
        }
        public int GetHeight()

        {
            return _height;
        }
    }
}
