using Kit.Ledger.Domain.Enums;

namespace Kit.Ledger.Domain
{
    public class Expense
    {
        public decimal Amount { get; }
        public Person SpentBy { get; }
        public ExpenseType SpentOn { get; }

        public Expense(decimal amount, ExpenseType spentOn, Person spentBy = Person.None)
        {
            Amount = amount;
            SpentOn = spentOn;
            SpentBy = spentBy;
        }
    }
}
