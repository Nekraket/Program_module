namespace ConsoleApp1
{

    public class ImageProxy : IImage
    {
        private string _filename;
        private HighResolutionImage _realImage;
        public ImageProxy(string filename)
        {
            _filename = filename;
            Console.WriteLine($"Создан proxy для {_filename}");
        }
        private void EnsureLoaded()
        {
            if (_realImage == null)
            {
                Console.WriteLine($"[ПРОКСИ] Обнаружен вызов метода, требуется загрузка {_filename}");
                _realImage = new HighResolutionImage(_filename);
            }
        }
        public void Draw()
        {
            EnsureLoaded();
            Console.Write($"[ПРОКСИ делегирует] ");
            _realImage.Draw();
        }
        public int GetWidth()
        {
            EnsureLoaded();
            Console.Write($"[ПРОКСИ делегирует] ");
            return _realImage.GetWidth();
        }
        public int GetHeight()
        {
            EnsureLoaded();
            Console.Write($"[ПРОКСИ делегирует] ");
            return _realImage.GetHeight();
        }
    }
}