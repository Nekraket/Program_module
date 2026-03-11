namespace ConsoleApp1
{
    internal abstract class FileSystemItem
    {
        public string Name { get; set; }

        public FileSystemItem(string name)
        {
            Name = name;
        }

        public abstract long GetSize();
        public abstract void Add(FileSystemItem item);
        public abstract void Remove(FileSystemItem item);
        public abstract FileSystemItem? GetChild(int index);
    }
}



