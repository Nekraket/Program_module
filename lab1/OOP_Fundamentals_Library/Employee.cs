namespace OOP_Fundamentals_Library
{
    public class Employee : EmployeeBase, IReportable, IBonusCalculable
    {
        private string _position;

        public string Position
        {
            get => _position;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Position cannot be empty");
                }
                _position = value;
            }
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Employee: {Name}, {Age} years old");
        }


        // ISalaried.ProcessSalary - делегируем SalaryProcessor
        public override void ProcessSalary()
        {
            var processor = new SalaryProcessor();
            processor.ProcessEmployeeSalary(this);
        }

        // IReportable.GenerateReport - обязательная реализация
        public void GenerateReport()
        {
            Console.WriteLine($"Employee Report:");
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Age: {Age}");
            Console.WriteLine($"  Salary: {Salary}");
        }

        // IBonusCalculable.CalculateBonus - делегируем BonusCalculator
        public decimal CalculateBonus(int years, bool hasCertification)
        {
            var calculator = new BonusCalculator();
            return calculator.CalculateEmployeeBonus(this, years, hasCertification);
        }
    }
}
