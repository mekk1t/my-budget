namespace KitBudget.Entities
{
    public class UntouchableMoney
    {
        public int CurrentBalance { get; }
        public int Amount { get; }

        public UntouchableMoney(int currentBalance, int amount)
        {
            CurrentBalance = currentBalance;
            Amount = amount;
        }
    }
}
