namespace OOP_Fundamentals_Library
{
    public abstract class EmployeeBase : Person, ISalaried
    {
        private decimal _salary;

        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative");
                }
                _salary = value;
            }
        }

        public void IncreaseSalary(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Increase amount must be positive");
            }
            Salary += amount;
        }


        // абстрактный  метод ISalaried
        public abstract void ProcessSalary();
    }
}
