namespace Kit.Ledger.Domain
{
    /// <summary>
    /// Ежемесячный отчёт по счету.
    /// </summary>
    public class AccountReport
    {
        /// <summary>
        /// Счёт, по которому делается отчёт.
        /// </summary>
        public Account Account { get; }
        /// <summary>
        /// Месяц, за который делается отчёт.
        /// </summary>
        public Month Month { get; }
        /// <summary>
        /// Год, за который делается отчёт.
        /// </summary>
        public int Year { get; }
        /// <summary>
        /// Баланс в начале месяца.
        /// </summary>
        public decimal InitialBalance { get; }
        /// <summary>
        /// Список доходов.
        /// </summary>
        public List<Income> Incomes { get; }
        /// <summary>
        /// Список трат.
        /// </summary>
        public List<Expense> Expenses { get; }
        /// <summary>
        /// Баланс в конце месяца.
        /// </summary>
        public decimal FinalBalance { get; }
        /// <summary>
        /// Депозит на счёт "НЗ".
        /// </summary>
        public decimal NzDeposit
        {
            get
            {
                if (Account.Type != AccountType.Salary)
                    return 0;

                return Incomes.Sum(x => x.Amount * Constants.NZ_PERCENTAGE);
            }
        }
        /// <summary>
        /// Депозит на счёт "Карманные расходы".
        /// </summary>
        public decimal PocketDeposit
        {
            get
            {
                if (Account.Type != AccountType.Salary)
                    return 0;

                decimal availableIncome = Incomes.Sum(i => i.Amount) - NzDeposit;

                return availableIncome - Expenses.Sum(x => x.Amount);
            }
        }

        /// <summary>
        /// Создает отчёт за месяц.
        /// </summary>
        /// <param name="account">Счёт, по которому делается отчёт.</param>
        /// <param name="month">Месяц, за который делается отчёт.</param>
        /// <param name="initialBalance">Баланс в начале месяца.</param>
        /// <param name="finalBalance">Баланс в конце месяца.</param>
        /// <param name="expenses">Список трат за месяц.</param>
        /// <param name="incomes">Список доходов за месяц.</param>
        public AccountReport(
            Account account,
            Month month,
            decimal initialBalance,
            decimal finalBalance,
            List<Expense> expenses,
            List<Income> incomes)
        {
            Account = account;
            Month = month;
            InitialBalance = initialBalance;
            FinalBalance = finalBalance;
            Expenses = expenses;
            Year = DateTime.Now.Year;
            Incomes = incomes;
        }
    }
}
