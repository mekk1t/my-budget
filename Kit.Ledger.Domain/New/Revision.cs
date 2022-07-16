namespace Kit.Ledger.Domain.New
{
    public class Revision
    {
        public DateTime CreatedAt { get; }
        public IReadOnlyList<decimal> Incomes { get; }
        public IReadOnlyList<Expense> Expenses { get; }

        public decimal PocketMoneyBalance { get; }

        public Revision(List<decimal> incomes, List<Expense> expenses, decimal pocketMoneyBalance)
        {
            CreatedAt = DateTime.UtcNow;
            Incomes = incomes;
            Expenses = expenses;
            PocketMoneyBalance = pocketMoneyBalance;
        }

        public decimal UntouchableMoneyDeposit() => Incomes.Sum() * Constants.UNTOUCHABLE_MONEY_INCOME_PERCENTAGE;
    }
}
