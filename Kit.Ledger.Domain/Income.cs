using Kit.Ledger.Domain.Enums;

namespace Kit.Ledger.Domain
{
    public class Income
    {
        public decimal Amount { get; }
        public IncomeType Type { get; }
        public Person Person { get; }

        public Income(decimal amount, IncomeType type, Person person)
        {
            Amount = amount;
            Type = type;
            Person = person;
        }
    }
}
