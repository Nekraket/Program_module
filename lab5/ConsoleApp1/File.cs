namespace ConsoleApp1
{
    internal class File : FileSystemItem
    {
        private long _size;

        public File(string name, long size) : base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            return _size;
        }

        public override void Add(FileSystemItem item)
        {
            throw new InvalidOperationException("Нельзя добавить элемент в файл");
        }

        public override void Remove(FileSystemItem item)
        {
            throw new InvalidOperationException("Нельзя удалить элемент из файла");
        }

        public override FileSystemItem? GetChild(int index)
        {
            throw new InvalidOperationException("У файла нет дочерних элементов");
        }
    }
}
