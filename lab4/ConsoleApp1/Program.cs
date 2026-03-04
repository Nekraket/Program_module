namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nЭТАП 1\n");

            IComputerFactory officeFactory = new OfficeComputerFactory();
            Computer officeComp = officeFactory.CreateComputer();
            officeComp.Display();

            IComputerFactory proFactory = new GamingComputerFactory();
            Computer proComp = proFactory.CreateComputer();
            proComp.Display();

            IComputerFactory macFactory = new HomeComputerFactory();
            Computer macComp = macFactory.CreateComputer();
            macComp.Display();

            Computer customComputer = new ComputerBuilder()
            .WithCPU("AMD Ryzen 7 7800X3D")
            .WithRAM(32)
            .WithGPU("NVidia RTX 4070 SUPER 12GB")
            .WithComponent("MSI Motherboard")
            .WithComponent("10G Ethernet PCIe 3.0 x8 card")
            .Build();

            customComputer.Display();




            Console.WriteLine("\nЭТАП 2\n");

            Computer original = new ComputerBuilder()
                .WithCPU("AMD Ryzen 5")
                .WithRAM(8)
                .WithGPU("GTX 1660")
                .WithComponent("HDD")
                .Build();

            Console.WriteLine("Оригинал:");
            original.Display();

            Computer shallow = original.ShallowCopy();
            shallow.AdditionalComponents.Add("Добавлено в клон");

            Console.WriteLine("\nПосле поверхностного копирования:");
            Console.WriteLine("Оригинал:");
            original.Display();
            Console.WriteLine("Клон:");
            shallow.Display();

            Computer deep = original.DeepCopy();
            deep.AdditionalComponents.Add("Добавлено в глубокий клон");

            Console.WriteLine("\nПосле глубокого копирования:");
            Console.WriteLine("Оригинал:");
            original.Display();
            Console.WriteLine("Глубокий клон:");
            deep.Display();




            Console.WriteLine("\nЭТАП 3\n");

            Console.WriteLine("Получаем первый экземпляр реестра:");
            PrototypeRegistry registry1 = PrototypeRegistry.Instance;
            registry1.ShowAvailablePrototypes();

            Console.WriteLine("\nПолучаем второй экземпляр реестра:");
            PrototypeRegistry registry2 = PrototypeRegistry.Instance;

            Console.WriteLine($"\nregistry1 и registry2 - это один объект? {ReferenceEquals(registry1, registry2)}");

            Console.WriteLine("\nПолучаем прототип 'gaming' из реестра:");
            Computer gamingFromRegistry = registry1.GetPrototype("gaming");
            Console.WriteLine("Оригинальный прототип (из реестра):");
            gamingFromRegistry.Display();

            Console.WriteLine("Модифицируем полученную копию:");
            gamingFromRegistry.AdditionalComponents.Add("Модифицированный компонент (добавлен в копию)");
            gamingFromRegistry.RAM = 64;
            Console.WriteLine("Модифицированная копия:");
            gamingFromRegistry.Display();

            Console.WriteLine("\nПолучаем прототип 'gaming' из реестра еще раз:");
            Computer gamingAgain = registry1.GetPrototype("gaming");
            Console.WriteLine("Прототип из реестра (должен быть без изменений):");
            gamingAgain.Display();

            Console.WriteLine("\nПытаемся создать новый экземпляр реестра через конструктор - НЕВОЗМОЖНО!");
            Console.WriteLine("Конструктор приватный, можно получить только через Instance");

        }
    }
}