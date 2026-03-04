namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
