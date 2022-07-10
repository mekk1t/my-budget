using Kit.Ledger.Domain.Abstractions;

namespace Kit.Ledger.Domain
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
