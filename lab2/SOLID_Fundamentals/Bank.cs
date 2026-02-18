namespace SOLID_Fundamentals
{
    //LSP(Принцип подстановки Лисков)

    public abstract class Account
    {
        public decimal Balance { get; protected set; }

        public virtual void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount must be positive");
            }

            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            Balance -= amount;
        }

        public virtual decimal CalculateInterest()
        {
            return Balance * 0.01m;
        }
    }

    public class SavingsAccount : Account
    {
        public decimal MinimumBalance { get; } = 100m;

        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < MinimumBalance)
            {
                throw new InvalidOperationException("Cannot go below minimum balance");
            }
            base.Withdraw(amount);
        }
    }

    public class CheckingAccount : Account
    {
        public decimal OverdraftLimit { get; } = 500m;

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive");
            }

            if (Balance - amount < -OverdraftLimit)
            {
                throw new InvalidOperationException("Overdraft limit exceeded");
            }
            Balance -= amount;
        }
    }

    public class FixedDepositAccount : Account
    {
        public DateTime MaturityDate { get; }

        public FixedDepositAccount(DateTime maturityDate)
        {
            if (maturityDate <= DateTime.Now)
            {
                throw new ArgumentException("Maturity date must be in the future");
            }

            MaturityDate = maturityDate;
        }

        public override void Withdraw(decimal amount)
        {
            if (DateTime.Now < MaturityDate)
            {
                throw new InvalidOperationException("Cannot withdraw before maturity date");
            }

            base.Withdraw(amount);
        }

        public override decimal CalculateInterest()
        {
            return Balance * 0.05m;
        }
    }

    public class Bank
    {
        public void ProcessWithdrawal(Account account, decimal amount)
        {
            try
            {
                account.Withdraw(amount);
                Console.WriteLine($"Successfully withdrew {amount}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Withdrawal failed: {ex.Message}");
            }
        }

        public void Transfer(Account from, Account to, decimal amount)
        {
            from.Withdraw(amount);
            to.Deposit(amount);
        }
    }
}