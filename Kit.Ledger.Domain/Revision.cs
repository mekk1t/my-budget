namespace Kit.Ledger.Domain
{
    public class Revision
    {
        public AccountType AccountType { get; }
        public DateTime CreatedAt { get; }
        public IReadOnlyList<decimal> Incomes { get; }
        public IReadOnlyList<Expense> Expenses { get; }

        public Revision(List<decimal> incomes, List<Expense> expenses, AccountType accountType)
        {
            CreatedAt = DateTime.UtcNow;
            Incomes = incomes;
            Expenses = expenses;
            AccountType = accountType;
        }
    }
}
