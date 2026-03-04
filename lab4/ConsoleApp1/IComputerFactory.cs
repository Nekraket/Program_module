namespace ConsoleApp1
{
    internal interface IComputerFactory
    {
        public Computer CreateComputer();
    }
    internal class OfficeComputerFactory : IComputerFactory
    {
        public Computer CreateComputer()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i3 12100")
                .WithRAM(8)
                .WithGPU("Intel UHD Graphics 730")
                .WithComponent("256GB SSD")
                .WithComponent("Клавиатура и мышь в комплекте")
                .Build();
        }
    }

    internal class GamingComputerFactory : IComputerFactory
    {
        public Computer CreateComputer()
        {
            return new ComputerBuilder()
                .WithCPU("AMD Ryzen 7 7800X3D")
                .WithRAM(32)
                .WithGPU("NVIDIA GeForce RTX 4080")
                .WithComponent("2TB NVMe SSD")
                .WithComponent("RGB подсветка корпуса")
                .WithComponent("Водяное охлаждение")
                .WithComponent("Звуковая карта Creative Sound Blaster")
                .Build();
        }
    }

    internal class HomeComputerFactory : IComputerFactory
    {
        public Computer CreateComputer()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i5 13400")
                .WithRAM(16)
                .WithGPU("NVIDIA GeForce GTX 1660")
                .WithComponent("512GB SSD")
                .WithComponent("1TB HDD")
                .WithComponent("Wi-Fi 6 модуль")
                .WithComponent("Bluetooth 5.2")
                .WithComponent("Картовод (SD/MMC)")
                .Build();
        }
    }
}
