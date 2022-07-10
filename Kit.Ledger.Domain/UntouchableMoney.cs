using KitBudget.Domain.Abstractions;

namespace KitBudget.Domain
{
    public class UntouchableMoney : ValueObject
    {
        public int Amount { get; }

        public UntouchableMoney(int amount)
        {
            Amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}
