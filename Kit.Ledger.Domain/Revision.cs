namespace Kit.Ledger.Domain
{
    public class Revision
    {
        public AccountType AccountType { get; }
        public IReadOnlyList<decimal> Incomes { get; }
        public IReadOnlyList<Expense> Expenses { get; }
        public Month Month { get; }

        public Revision(List<decimal> incomes, List<Expense> expenses, AccountType accountType, Month month)
        {
            Month = month;
            Incomes = incomes;
            Expenses = expenses;
            AccountType = accountType;
        }
    }
}
