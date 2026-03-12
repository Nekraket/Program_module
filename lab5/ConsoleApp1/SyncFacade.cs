namespace ConsoleApp1
{
    internal class SyncFacade
    {
        private IFileSystem _sourceFS;
        private IFileSystem _targetFS;
        public SyncFacade(IFileSystem source, IFileSystem target)
        {
            _sourceFS = source;
            _targetFS = target;
        }

        public void SyncFolder(string sourcePath, string targetPath)
        {
            var items = _sourceFS.ListItems(sourcePath);
            foreach (var item in items)
            {
                string itemName = item.Substring(item.IndexOf(']') + 2);
                string sourceItemPath = $"{sourcePath}/{itemName}";
                string targetItemPath = $"{targetPath}/{itemName}";

                if (item.StartsWith("[ФАЙЛ]"))
                {
                    Console.Write($"Копирование файла: {itemName}... ");
                    byte[] data = _sourceFS.ReadFile(sourceItemPath);
                    _targetFS.WriteFile(targetItemPath, data);
                    Console.WriteLine("OK");
                }
                else if (item.StartsWith("[ПАПКА]"))
                {
                    Console.WriteLine($"Обработка папки: {itemName}/");
                    SyncFolder(sourceItemPath, targetItemPath);
                }
            }
            Console.WriteLine("Синхронизация завершена.");
        }
        public void Backup(string sourcePath, string backupRootPath)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string backupPath = $"{backupRootPath}/backup_{timestamp}";

            SyncFolder(sourcePath, backupPath);

            Console.WriteLine($"резервное копирование завершено\n");
        }
    }
}
