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
        public List<decimal> Incomes { get; }
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
        /// <exception cref="InvalidOperationException"></exception>
        public decimal NzDeposit
        {
            get
            {
                if (Account.Type != AccountType.Salary)
                    throw new InvalidOperationException("На счёт НЗ деньги откладываются с зарплатного счёта");

                return Incomes.Sum(x => x * Constants.NZ_PERCENTAGE);
            }
        }
        /// <summary>
        /// Депозит на счёт "Карманные расходы".
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public decimal PocketDeposit
        {
            get
            {
                if (Account.Type != AccountType.Salary)
                    throw new InvalidOperationException("На счёт КР деньги откладываются с зарплатного счёта");

                decimal availableIncome = Incomes.Sum() - NzDeposit;

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
            List<decimal> incomes)
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
