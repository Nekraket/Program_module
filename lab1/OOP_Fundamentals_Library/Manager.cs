namespace OOP_Fundamentals_Library
{
    public class Manager : EmployeeBase, IReportable, IBonusCalculable, ITeamManager
    {
        private string _department;
        private List<Employee> _team = new();

        public string Department
        {
            get => _department;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Department cannot be empty");
                }
                _department = value;
            }
        }

        //интерфейс, представляющий Team только для чтения, без казёных методов удаления всеговся, чтобы извне нельзя было по приколу всё снести
        public IReadOnlyList<Employee> Team => _team.AsReadOnly();


        // Реализация ITeamManager
        public int TeamSize => _team.Count;
        public void AssignTask(string employeeName, string task)
        {
            var employee = _team.FirstOrDefault(e => e.Name == employeeName);
            if (employee == null)
            {
                throw new InvalidOperationException($"Employee {employeeName} is not in manager's team");
            }
            AssignTaskToEmployee(employee, task);
        }



        public void AddToTeam(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
                
            if (!_team.Contains(employee))
            {
                _team.Add(employee);
            }
        }

        public void RemoveFromTeam(Employee employee)
        {
            _team.Remove(employee);
        }


        public void AssignTaskToEmployee(Employee emp, string task)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            if (string.IsNullOrWhiteSpace(task))
            {
                throw new ArgumentException("Task cannot be empty");
            }
                
            if (!_team.Contains(emp))
            {
                throw new InvalidOperationException($"Employee {emp.Name} is not in manager's team");
            }

            Console.WriteLine($"Assigning task '{task}' to {emp.Name}");
        }


        public override void PrintInfo()
        {
            Console.WriteLine($"Manager: {Name}, {Age} years old, Department: {Department}");
        }


        // ISalaried.ProcessSalary - делегируем SalaryProcessor
        public override void ProcessSalary()
        {
            var processor = new SalaryProcessor();
            processor.ProcessManagerSalary(this);
        }

        // IReportable.GenerateReport - обязательная реализация
        public void GenerateReport()
        {
            Console.WriteLine($"Manager Report:");
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Department: {Department}");
            Console.WriteLine($"  Team Size: {TeamSize}");
        }

        // IBonusCalculable.CalculateBonus - делегируем BonusCalculator
        public decimal CalculateBonus(int years, bool hasCertification)
        {
            var calculator = new BonusCalculator();
            return calculator.CalculateManagerBonus(this, years, hasCertification);
        }
    }
}
