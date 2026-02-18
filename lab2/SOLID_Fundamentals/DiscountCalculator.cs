namespace SOLID_Fundamentals
{
    //OCP (Принцип открытости/закрытости)
    public interface IDiscountStrategy
    {
        bool IsApplicable(string customerType);
        decimal CalculateDiscount(decimal orderAmount);
    }

    public class RegularDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(string customerType)
        {
            return customerType == "Regular";
        }

        public decimal CalculateDiscount(decimal orderAmount)
        {
            return orderAmount * 0.05m;
        }
    }

    public class PremiumDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(string customerType)
        {
            return customerType == "Premium";
        }

        public decimal CalculateDiscount(decimal orderAmount)
        {
            return orderAmount * 0.10m;
        }
    }

    public class VipDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(string customerType)
        {
            return customerType == "VIP";
        }

        public decimal CalculateDiscount(decimal orderAmount)
        {
            return orderAmount * 0.15m;
        }
    }

    public class StudentDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(string customerType)
        {
            return customerType == "Student";
        }

        public decimal CalculateDiscount(decimal orderAmount)
        {
            return orderAmount * 0.08m;
        }
    }

    public class SeniorDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(string customerType)
        {
            return customerType == "Senior";
        }

        public decimal CalculateDiscount(decimal orderAmount)
        {
            return orderAmount * 0.07m;
        }
    }

    public class DefaultDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(string customerType)
        {
            // Если ни одна другая не подошла
            return true;
        }

        public decimal CalculateDiscount(decimal orderAmount)
        {
            return 0;
        }
    }


    //--------------
    public interface IShippingStrategy
    {
        bool IsApplicable(string shippingMethod, string destination);
        decimal CalculateCost(decimal weight, string destination);
    }

    public class StandardShippingStrategy : IShippingStrategy
    {
        public bool IsApplicable(string shippingMethod, string destination)
        {
            return shippingMethod == "Standard";
        }

        public decimal CalculateCost(decimal weight, string destination)
        {
            return 5.00m + (weight * 0.5m);
        }
    }

    public class ExpressShippingStrategy : IShippingStrategy
    {
        public bool IsApplicable(string shippingMethod, string destination)
        {
            return shippingMethod == "Express";
        }

        public decimal CalculateCost(decimal weight, string destination)
        {
            return 15.00m + (weight * 1.0m);
        }
    }

    public class OvernightShippingStrategy : IShippingStrategy
    {
        public bool IsApplicable(string shippingMethod, string destination)
        {
            return shippingMethod == "Overnight";
        }

        public decimal CalculateCost(decimal weight, string destination)
        {
            return 25.00m + (weight * 2.0m);
        }
    }

    public class InternationalShippingStrategy : IShippingStrategy
    {
        public bool IsApplicable(string shippingMethod, string destination)
        {
            return shippingMethod == "International";
        }

        public decimal CalculateCost(decimal weight, string destination)
        {
            if (destination == "USA")
            {
                return 30.00m;
            }
            else if (destination == "Europe")
            {
                return 35.00m;
            }
            else if (destination == "Asia")
            {
                return 40.00m;
            }
            else
            {
                return 50.00m;
            }
        }
    }

    public class DefaultShippingStrategy : IShippingStrategy
    {
        public bool IsApplicable(string shippingMethod, string destination)
        {
            // Если ни одна другая не подошла
            return true;
        }

        public decimal CalculateCost(decimal weight, string destination)
        {
            return 0;
        }
    }

    public class DiscountCalculator
    {
        private readonly IEnumerable<IDiscountStrategy> _discountStrategies;
        private readonly IEnumerable<IShippingStrategy> _shippingStrategies;

        public DiscountCalculator(IEnumerable<IDiscountStrategy> discountStrategies, IEnumerable<IShippingStrategy> shippingStrategies)
        {
            _discountStrategies = discountStrategies;
            _shippingStrategies = shippingStrategies;
        }

        public decimal CalculateDiscount(string customerType, decimal orderAmount)
        {
            foreach (var strategy in _discountStrategies)
            {
                if (strategy.IsApplicable(customerType))
                {
                    return strategy.CalculateDiscount(orderAmount);
                }
            }

            return 0;
        }

        public decimal CalculateShippingCost(string shippingMethod, decimal weight, string destination)
        {
            foreach (var strategy in _shippingStrategies)
            {
                if (strategy.IsApplicable(shippingMethod, destination))
                {
                    return strategy.CalculateCost(weight, destination);
                }
            }

            return 0;
        }
    }
}