namespace Kit.Ledger.Domain.New
{
    public class Calculator
    {
        private const decimal PERCENTAGE = 0.1m;

        public decimal CalculateUntouchableMoneyDeposit(Revision revision)
        {
            return revision.Incomes.Sum() * PERCENTAGE;
        }

        public decimal CalculatePocketMoneyDeposit(Budget budget)
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
