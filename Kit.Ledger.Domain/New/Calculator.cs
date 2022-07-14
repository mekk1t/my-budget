namespace Kit.Ledger.Domain.New
{
    public static class Calculator
    {
        private static readonly IReadOnlyList<ExpenseType> SBERBANK_EXPENSE_TYPES = new List<ExpenseType>
        {
            ExpenseType.Mortgage,
            ExpenseType.Parking,
            ExpenseType.VKA
        };

        /// <summary>
        /// Получает баланс счёта "НЗ" на начало месяца.
        /// </summary>
        /// <param name="previousMonthBudget">Бюджет за предыдущий месяц.</param>
        /// <returns>
        /// Значение баланса на счету "НЗ", которое должно быть на начало месяца.
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static decimal GetUntouchableMoneyBalance(Budget previousMonthBudget, Revision revision)
        {
            decimal? currentBalance = previousMonthBudget.GetUntouchableMoneyBalance();
            if (currentBalance == null)
                throw new ArgumentException("В бюджете не заполнена вторая итерация");

            return currentBalance.Value + revision.UntouchableMoneyDeposit();
        }

        public static decimal PocketMoneyBalanceAtTheStartOfTheMonth(Budget previousMonthBudget)
        {
            return
                previousMonthBudget.FirstRevision.PocketMoneyBalance -
                previousMonthBudget.SecondRevision.PocketMoneyBalance;
        }

        public static decimal FirstRevisionSberbankTransferAmount(Revision firstRevision)
        {
            return firstRevision.Expenses
                .Where(e => SBERBANK_EXPENSE_TYPES.Contains(e.SpentOn))
                .Sum(e => e.Amount);
        }

        /// <summary>
        /// Сколько денег отложить на счёт "Карманные расходы".
        /// </summary>
        /// <param name="budget"></param>
        /// <returns></returns>
        public static decimal PocketMoneyDeposit(Budget budget)
        {
            return
                (
                    (budget.FirstRevision.Incomes.Sum() + budget.SecondRevision.Incomes.Sum()) *
                    (1 - PERCENTAGE)
                ) -
                (
                    budget.FirstRevision.Expenses.Select(e => e.Amount).Sum() + budget.SecondRevision.Expenses.Select(e => e.Amount).Sum()
                );
        }
    }
}
