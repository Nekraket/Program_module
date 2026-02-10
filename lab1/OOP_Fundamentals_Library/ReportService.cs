namespace OOP_Fundamentals_Library
{
    public class ReportService
    {
        // Один метод для всех, кто реализует IReportable
        public void GenerateReport(IReportable reportable)
        {
            reportable.GenerateReport();
        }

        // Дополнительный метод для менеджеров
        public void GenerateManagerReport(ITeamManager manager)
        {
            Console.WriteLine($"Manager Report:");
            Console.WriteLine($"  Name: {manager.Name}");
            Console.WriteLine($"  Department: {manager.Department}");
            Console.WriteLine($"  Team Size: {manager.TeamSize}");
        }
    }
}
