namespace OOP_Fundamentals_Library
{
    public class BonusCalculator
    {
        public decimal CalculateEmployeeBonus(EmployeeBase employee, int years, bool hasCertification)
        {
            decimal bonus = employee.Salary * 0.1m;

            if (years > 5)
            {
                bonus += 500;
            }
            if (hasCertification)
            {
                bonus += 300;
            }

            return bonus;
        }

        public decimal CalculateManagerBonus(Manager manager, int years, bool hasCertification)
        {
            decimal bonus = manager.Salary * 0.2m;

            if (years > 5)
            {
                bonus += 500;
            }

            if (hasCertification)
            {
                bonus += 300;
            }

            return bonus;
        }
    }
}