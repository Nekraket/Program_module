namespace ConsoleApp1
{
    internal class PrototypeRegistry
    {
        private static volatile PrototypeRegistry _instance;

        private static readonly object _lock = new object();

        private Dictionary<string, Computer> _prototypes;

        private PrototypeRegistry()
        {
            Console.WriteLine("Инициализация реестра прототипов...");
            _prototypes = new Dictionary<string, Computer>();

            LoadPrototypes();
        }

        /// С потокобезопасной реализацией (double-checked locking)
        public static PrototypeRegistry Instance
        {
            get
            {
                // Первая проверка (без блокировки)
                if (_instance == null)
                {
                    // Блокируемся для потокобезопасности
                    lock (_lock)
                    {
                        // Вторая проверка (с блокировкой)
                        if (_instance == null)
                        {
                            _instance = new PrototypeRegistry();
                        }
                    }
                }
                return _instance;
            }
        }

        private void LoadPrototypes()
        {
            _prototypes["office"] = new OfficeComputerFactory().CreateComputer();
            _prototypes["gaming"] = new GamingComputerFactory().CreateComputer();
            _prototypes["home"] = new HomeComputerFactory().CreateComputer();

            // Можно добавить еще один прототип вручную
            _prototypes["workstation"] = new ComputerBuilder()
                .WithCPU("AMD Ryzen Threadripper 3970X")
                .WithRAM(128)
                .WithGPU("NVIDIA RTX A6000")
                .WithComponent("2TB NVMe SSD")
                .WithComponent("64GB ECC RAM")
                .WithComponent("Блок питания 1200W")
                .Build();

            Console.WriteLine($"Загружено {_prototypes.Count} прототипов");
        }

        public Computer GetPrototype(string key)
        {
            if (_prototypes.ContainsKey(key))
            {
                // Возвращаем ГЛУБОКУЮ копию, чтобы клиент мог изменять объект,
                // не влияя на прототип в реестре
                return _prototypes[key].DeepCopy();
            }

            Console.WriteLine($"Прототип с ключом '{key}' не найден");
            return null;
        }


        public void ShowAvailablePrototypes()
        {
            Console.WriteLine("\nДоступные прототипы в реестре:");
            Console.WriteLine("------------------------------");
            foreach (var key in _prototypes.Keys)
            {
                Console.WriteLine($"- {key}");
            }
        }
    }
}
