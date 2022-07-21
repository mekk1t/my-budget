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
        public IReadOnlyList<Income> Incomes { get; }
        public IReadOnlyList<Expense> Expenses { get; }
        public Month Month { get; }
        /// <summary>
        /// Объем денежных средств, которые нужно перевести на карту Сбербанка.
        /// </summary>
        public decimal SberbankTransferAmount
        {
            get
            {
                if (AccountType == AccountType.Salary)
                    return Expenses.Where(e => SBERBANK_EXPENSE_TYPES.Contains(e.SpentOn)).Sum(e => e.Amount);

                return 0;
            }
        }

        public Revision(List<Income> incomes, List<Expense> expenses, AccountType accountType, Month month)
        {
            Month = month;
            Incomes = incomes;
            Expenses = expenses;
            AccountType = accountType;
        }
    }
}
