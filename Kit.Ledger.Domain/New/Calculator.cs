namespace Kit.Ledger.Domain.New
{
    public static class Calculator
    {
        private const decimal PERCENTAGE = 0.1m;

        public static decimal UntouchableMoneyDeposit(Revision revision)
        {
            return revision.Incomes.Sum() * PERCENTAGE;
        }

        public static decimal UntouchableMoneyBalanceAtTheStartOfTheMonth(Budget previousMonthBudget, Revision firstRevision)
        {
            return
                previousMonthBudget.FirstRevision.UntouchableMoneyBalance -
                previousMonthBudget.SecondRevision.UntouchableMoneyBalance +
                UntouchableMoneyDeposit(firstRevision);
        }

        public static decimal PocketMoneyBalanceAtTheStartOfTheMonth(Budget previousMonthBudget)
        {
            return
                previousMonthBudget.FirstRevision.PocketMoneyBalance -
                previousMonthBudget.SecondRevision.PocketMoneyBalance;
        }

        public static decimal FirstRevisionSberbankTransferAmount(Revision firstRevision)
        {
            return firstRevision.Expenses.Sum();
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
                    budget.FirstRevision.Expenses.Sum() + budget.SecondRevision.Expenses.Sum()
                );
        }
    }
}
