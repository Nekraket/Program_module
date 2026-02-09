namespace OOP_Fundamentals_Library
{
    public abstract class Person
    {
        private int _age;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }    
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be between 0 and 150");
                }
                _age = value;
            }
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Person: {Name}, {Age} years old");
        }
    }
}