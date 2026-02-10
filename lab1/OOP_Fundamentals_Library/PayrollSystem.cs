namespace OOP_Fundamentals_Library
{
    public class PayrollSystem
    {
        public void ProcessSalary(ISalaried employee)
        {
            employee.ProcessSalary();
        }

        public void ProcessPayroll(Employee employee)
        {
            Console.WriteLine($"Processing payroll for {employee.Name}: {employee.Salary}");
        }

        public decimal CalculateBonus(IBonusCalculable employee, int years, bool hasCertification)
        {
            return employee.CalculateBonus(years, hasCertification);
        }
    }
}