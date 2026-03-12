namespace ConsoleApp1
{
    internal class Folder : FileSystemItem
    {
        private List<FileSystemItem> _children = new List<FileSystemItem>();

        public Folder(string name) : base(name)
        {
        }

        public override long GetSize()
        {
            long totalSize = 0;
            foreach (var item in _children)
            {
                totalSize += item.GetSize();
            }
            return totalSize;
        }

        public override void Add(FileSystemItem item)
        {
            _children.Add(item);
        }

        public override void Remove(FileSystemItem item)
        {
            _children.Remove(item);
        }

        public override FileSystemItem? GetChild(int index)
        {
            if (index >= 0 && index < _children.Count)
            {
                return _children[index];
            }
            return null;
        }
    }
}
