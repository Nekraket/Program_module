namespace ConsoleApp1
{
    internal class Character
    {
        private char _symbol;
        private string _font;
        private int _fontSize;

        public Character(char symbol, string font, int fontSize)
        {
            _symbol = symbol;
            _font = font;
            _fontSize = fontSize;
            Console.WriteLine($"[СОЗДАНО] Символ '{_symbol}' ({_font}, {_fontSize}pt)");
        }

        public void Draw(int positionX, int positionY)
        {
            Console.WriteLine($"Отрисовка '{_symbol}' в ({positionX}, {positionY}) шрифтом {_font} {_fontSize}pt");
        }
    }
}
