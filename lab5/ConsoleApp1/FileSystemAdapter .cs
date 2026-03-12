namespace ConsoleApp1
{
    internal class FileSystemAdapter : IFileSystem
    {
        private FileSystemItem _root;

        public FileSystemAdapter(FileSystemItem root)
        {
            _root = root;
        }

        private FileSystemItem? FindItem(string path)
        {
            if (path == "/" || path == "\\" || string.IsNullOrEmpty(path))
            {
                return _root;
            }

            string[] parts = path.Trim('/').Split('/');
            FileSystemItem current = _root;

            for (int i = 0; i < parts.Length; i++)
            {
                if (string.IsNullOrEmpty(parts[i]))
                {
                    continue;
                }

                if (current is Folder folder)
                {
                    bool found = false;
                    int index = 0;

                    while (true)
                    {
                        var child = folder.GetChild(index);
                        if (child == null)
                        {
                            break;
                        }

                        if (child.Name == parts[i])
                        {
                            current = child;
                            found = true;
                            break;
                        }
                        index++;
                    }

                    if (!found)
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            return current;
        }

        public List<string> ListItems(string path)
        {
            List<string> result = new List<string>();
            var item = FindItem(path);

            if (item == null)
            {
                Console.WriteLine($"Элемент по пути {path} не найден");
                return result;
            }

            if (item is Folder folder)
            {
                int index = 0;
                while (true)
                {
                    var child = folder.GetChild(index);
                    if (child == null) break;

                    if (child is File)
                    {
                        result.Add($"[ФАЙЛ] {child.Name}");
                    }
                    else if (child is Folder)
                    {
                        result.Add($"[ПАПКА] {child.Name}");
                    }
                    index++;
                }
            }
            else
            {
                result.Add($"[ФАЙЛ] {item.Name}");
            }

            return result;
        }

        public byte[] ReadFile(string path)
        {
            var item = FindItem(path);

            if (item == null)
            {
                Console.WriteLine($"Файл по пути {path} не найден");
                return new byte[0];
            }

            if (item is File file)
            {
                long size = file.GetSize();
                Console.WriteLine($"Чтение файла {path} размером {size}");

                byte[] data = new byte[8];
                BitConverter.GetBytes(size).CopyTo(data, 0);
                return data;
            }
            else
            {
                Console.WriteLine($"Ошибка: {path} является папкой, а не файлом");
                return new byte[0];
            }
        }

        public void WriteFile(string path, byte[] data)
        {
            Console.WriteLine($"Запись файла {path} размером {data.Length}");
        }

        public void DeleteItem(string path)
        {
            var item = FindItem(path);

            if (item == null)
            {
                Console.WriteLine($"Элемент по пути {path} не найден");
                return;
            }

            Console.WriteLine($"Удаление элемента: {path}");
        }
    }
}