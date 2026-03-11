namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЭТАП 1. Паттерн «Компоновщик»\n");

            File file1 = new File("document.txt", 1024);
            File file2 = new File("photo.jpg", 5120);
            File file3 = new File("video.mp4", 204800);
            File file4 = new File("music.mp3", 8192);
            File file5 = new File("archive.zip", 40960);
            File file6 = new File("readme.txt", 512);

            Folder root = new Folder("Корневая папка");
            Folder documents = new Folder("Документы");
            Folder media = new Folder("Медиа");
            Folder photos = new Folder("Фото");
            Folder work = new Folder("Рабочее");


            documents.Add(file1);
            documents.Add(file5); 
            documents.Add(new File("report.docx", 3072));

            photos.Add(file2);
            photos.Add(new File("vacation.jpg", 3072));
            photos.Add(new File("family.png", 2048));

            work.Add(new File("presentation.pptx", 5120));
            work.Add(new File("budget.xlsx", 2048));

            media.Add(file3);
            media.Add(file4);
            media.Add(photos);

            root.Add(documents);
            root.Add(media);
            root.Add(work);
            root.Add(file6);


            Console.WriteLine("РАЗМЕРЫ ЭЛЕМЕНТОВ ФАЙЛОВОЙ СИСТЕМЫ:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Размер файла 'video.mp4': {file3.GetSize()} байт");
            Console.WriteLine($"Размер папки 'Фото': {photos.GetSize()} байт");
            Console.WriteLine($"Размер папки 'Медиа': {media.GetSize()} байт");
            Console.WriteLine($"Размер папки 'Документы': {documents.GetSize()} байт");
            Console.WriteLine($"Размер папки 'Рабочее': {work.GetSize()} байт");
            Console.WriteLine($"Размер КОРНЕВОЙ ПАПКИ: {root.GetSize()} байт");

        }
    }
}