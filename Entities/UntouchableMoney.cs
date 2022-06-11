namespace KitBudget.Entities
{
    public class UntouchableMoney
    {
        public int CurrentBalance { get; }

        public UntouchableMoney(int currentBalance)
        {
            CurrentBalance = currentBalance;
        }
    }
}
