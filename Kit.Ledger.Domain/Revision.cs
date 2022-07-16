namespace Kit.Ledger.Domain
{
    public class Revision
    {
        private static readonly IReadOnlyList<ExpenseType> SBERBANK_EXPENSE_TYPES = new List<ExpenseType>
        {
            ExpenseType.Mortgage,
            ExpenseType.Parking,
            ExpenseType.VKA
        };

        public AccountType AccountType { get; }
        public IReadOnlyList<decimal> Incomes { get; }
        public IReadOnlyList<Expense> Expenses { get; }
        public Month Month { get; }
        /// <summary>
        /// Объем денежных средств, которые нужно перевести на карту Сбербанка.
        /// </summary>
        public decimal SberbankTransferAmount => Expenses.Where(e => SBERBANK_EXPENSE_TYPES.Contains(e.SpentOn)).Sum(e => e.Amount);

        public Revision(List<decimal> incomes, List<Expense> expenses, AccountType accountType, Month month)
        {
            Month = month;
            Incomes = incomes;
            Expenses = expenses;
            AccountType = accountType;
        }
    }
}
