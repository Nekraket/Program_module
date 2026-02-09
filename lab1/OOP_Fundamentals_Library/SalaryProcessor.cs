namespace OOP_Fundamentals_Library
{
    public class SalaryProcessor
    {
        public void ProcessEmployeeSalary(EmployeeBase employee)
        {
            Console.WriteLine($"Processing salary for employee {employee.Name}: {employee.Salary}");
            employee.Salary += 1000;
        }

        public void ProcessManagerSalary(Manager manager)
        {
            Console.WriteLine($"Processing salary for manager {manager.Name}: {manager.Salary}");
            manager.Salary += 2000;
        }
    }
}