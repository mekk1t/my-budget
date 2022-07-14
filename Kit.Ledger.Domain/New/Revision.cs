namespace Kit.Ledger.Domain.New
{
    public class Revision
    {
        private const decimal PERCENTAGE = 0.1m;

        public DateTime CreatedAt { get; }
        public IReadOnlyList<decimal> Incomes { get; }
        public IReadOnlyList<Expense> Expenses { get; }
        public decimal PocketMoneyBalance { get; }

        /// <summary>
        /// Баланс на счету "НЗ". Присутствует во второй итерации, отсутствует в первой - должно расчитываться отдельно.
        /// </summary>
        public decimal? UntouchableMoneyBalance { get; set; }

        public Revision(List<decimal> incomes, List<Expense> expenses, decimal pocketMoneyBalance)
        {
            CreatedAt = DateTime.UtcNow;
            Incomes = incomes;
            Expenses = expenses;
            PocketMoneyBalance = pocketMoneyBalance;
        }

        public decimal UntouchableMoneyDeposit() => Incomes.Sum() * PERCENTAGE;
    }
}
