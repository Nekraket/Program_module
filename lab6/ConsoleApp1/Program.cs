namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("ЭТАП 1. Паттерн «Приспособленец» (Flyweight)\n");

            //Console.WriteLine("Демонстрация разделения символов с одинаковым внутренним состоянием\n");

            //CharacterFactory factory = new CharacterFactory();

            //Console.WriteLine("--- Запрашиваем символы из фабрики ---\n");

            //Character char1 = factory.GetCharacter('A', "Arial", 12);
            //Character char2 = factory.GetCharacter('B', "Arial", 12);
            //Character char3 = factory.GetCharacter('A', "Times New Roman", 14);
            //Character char4 = factory.GetCharacter('A', "Arial", 12);
            //Character char5 = factory.GetCharacter('C', "Arial", 12);
            //Character char6 = factory.GetCharacter('B', "Arial", 12);

            //Console.WriteLine("\n--- Используем легковесы с разным внешним состоянием (координатами) ---\n");

            //char1.Draw(10, 20);
            //char1.Draw(30, 20);
            //char1.Draw(50, 20);
            //char2.Draw(10, 40);
            //char3.Draw(10, 60);
            //char4.Draw(70, 20);
            //char5.Draw(90, 40);
            //char6.Draw(110, 40);

            //Console.WriteLine("\n--- ИТОГ ---");
            //Console.WriteLine($"Всего создано уникальных легковесов: {factory.GetCount()}");



            //Console.WriteLine("\n=== ЭТАП 2. Паттерн «Заместитель» (Proxy) ===\n");

            //Console.WriteLine("Демонстрация ленивой инициализации изображений\n");

            //Console.WriteLine("1. Создаём прокси для изображений (без загрузки):");
            //ImageProxy img1 = new ImageProxy("photo1.jpg");
            //ImageProxy img2 = new ImageProxy("photo2.jpg");
            //ImageProxy img3 = new ImageProxy("photo3.jpg");

            //Console.WriteLine("\n2. Создаём список изображений (все прокси, загрузки нет):");
            //List<IImage> images = new List<IImage> { img1, img2, img3 };

            //Console.WriteLine("\n3. Запрашиваем размер первого изображения (произойдёт загрузка img1):");
            //Console.WriteLine($"   Ширина img1: {img1.GetWidth()}px");

            //Console.WriteLine("\n4. Отрисовываем второе изображение (произойдёт загрузка img2):");
            //img2.Draw();

            //Console.WriteLine("\n5. Снова запрашиваем размер первого изображения (БЕЗ загрузки, уже загружено):");
            //Console.WriteLine($"   Высота img1: {img1.GetHeight()}px");

            //Console.WriteLine("\n6. Третье изображение так и не было использовано - оно НЕ загрузится");
            //Console.WriteLine("   (память сэкономлена)");



            //Console.WriteLine("\n=== ЭТАП 3. Паттерн «Мост» (Bridge) ===\n");
            //Console.WriteLine("Демонстрация разделения абстракции (фигур) и реализации (способов рендеринга)\n");

            //Console.WriteLine("1. Создаём движки рендеринга:");
            //IRenderingEngine screenEngine = new ScreenRenderer();
            //IRenderingEngine printEngine = new PrintRenderer();

            //Console.WriteLine("\n2. Создаём фигуры для экранного рендеринга:");
            //Rectangle screenRect = new Rectangle(screenEngine, 10, 20, 100, 50);
            //Ellipse screenEllipse = new Ellipse(screenEngine, 50, 50, 30, 20);
            //Line screenLine = new Line(screenEngine, 5, 5, 15, 15);

            //Console.WriteLine("\n3. Создаём фигуры для печатного рендеринга:");
            //Rectangle printRect = new Rectangle(printEngine, 10, 20, 100, 50);
            //Ellipse printEllipse = new Ellipse(printEngine, 50, 50, 30, 20);
            //Line printLine = new Line(printEngine, 5, 5, 15, 15);

            //Console.WriteLine("\n4. Отрисовка всех фигур:");
            //Console.WriteLine("\n--- Экранный рендеринг ---");
            //screenEngine.BeginRender();
            //screenRect.Draw();
            //screenEllipse.Draw();
            //screenLine.Draw();
            //screenEngine.EndRender();

            //Console.WriteLine("\n--- Печатный рендеринг ---");
            //printEngine.BeginRender();
            //printRect.Draw();
            //printEllipse.Draw();
            //printLine.Draw();
            //printEngine.EndRender();

            //Console.WriteLine("\n5. Демонстрация независимости:");
            //Console.WriteLine("   Перемещаем экранный прямоугольник:");
            //screenRect.Move(5, 10);

            //Console.WriteLine("\n   Снова отрисовываем (уже на новой позиции):");
            //screenEngine.BeginRender();
            //screenRect.Draw();
            //screenEngine.EndRender();



            Console.WriteLine("=== ЭТАП 4. Паттерн «Декоратор» (Decorator) ===\n");
            Console.WriteLine("Демонстрация динамического добавления функциональности\n");

            IRenderingEngine screenEngine = new ScreenRenderer();

            Console.WriteLine("1. Создаём базовые фигуры:");
            Rectangle simpleRect = new Rectangle(screenEngine, 10, 20, 100, 50);
            Ellipse simpleEllipse = new Ellipse(screenEngine, 50, 50, 30, 20);
            Line simpleLine = new Line(screenEngine, 5, 5, 15, 15);

            Console.WriteLine("\n2. Отрисовка базовых фигур (без декораторов):");
            simpleRect.Draw();
            Console.WriteLine();
            simpleEllipse.Draw();
            Console.WriteLine();
            simpleLine.Draw();
            Console.WriteLine();

            Console.WriteLine("\n3. Создаём декорированные фигуры:");

            IDrawable borderedRect = new BorderDecorator(simpleRect, 3);

            IDrawable shadowedEllipse = new ShadowDecorator(simpleEllipse, 5);

            IDrawable transparentLine = new TransparencyDecorator(simpleLine, 50);

            Console.WriteLine("\n4. Отрисовка фигур с одним декоратором:");
            borderedRect.Draw();
            Console.WriteLine();
            shadowedEllipse.Draw();
            Console.WriteLine();
            transparentLine.Draw();
            Console.WriteLine();

            Console.WriteLine("\n5. Комбинирование нескольких декораторов:");

            IDrawable borderedAndShadowedRect = new ShadowDecorator(borderedRect, 5);

            IDrawable superEllipse = new TransparencyDecorator(
                                        new ShadowDecorator(
                                            new BorderDecorator(simpleEllipse, 2), 7), 30);

            IDrawable lineWithBorderAndShadow = new BorderDecorator(
                                                    new ShadowDecorator(simpleLine, 3), 1);

            Console.WriteLine("   Прямоугольник с рамкой и тенью:");
            borderedAndShadowedRect.Draw();
            Console.WriteLine();

            Console.WriteLine("   Эллипс с рамкой (2px), тенью (7px) и прозрачностью (30%):");
            superEllipse.Draw();
            Console.WriteLine();

            Console.WriteLine("   Линия с тенью (сначала тень, потом рамка):");
            lineWithBorderAndShadow.Draw();
            Console.WriteLine();

            Console.WriteLine("\n6. Демонстрация работы с документом:");

            Document doc = new Document(screenEngine);

            Page page1 = doc.CreatePage();

            page1.Add(simpleRect);
            page1.Add(borderedRect);
            page1.Add(shadowedEllipse);
            page1.Add(transparentLine);
            page1.Add(borderedAndShadowedRect);
            page1.Add(superEllipse);

            doc.RenderAll();
        }
    }
}
