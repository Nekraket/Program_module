namespace OOP_Fundamentals_Library
{
    public interface ISalaried
    {
        decimal Salary { get; set; }
        void ProcessSalary();
    }

    public interface IReportable
    {
        void GenerateReport();
    }

    public interface IBonusCalculable
    {
        decimal CalculateBonus(int years, bool hasCertification);
    }



    public interface ITeamManager
    {
        void AssignTask(string employeeName, string task);
        string Name { get; }
        string Department { get; }
        int TeamSize { get; }
    }

}