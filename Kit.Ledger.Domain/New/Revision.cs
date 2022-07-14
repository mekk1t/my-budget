namespace Kit.Ledger.Domain.New
{
    public class Revision
    {
        private const decimal PERCENTAGE = 0.1m;

        public DateTime CreatedAt { get; set; }
        public List<decimal> Incomes { get; set; }
        public decimal UntouchableMoneyBalance { get; set; }
        public decimal PocketMoneyBalance { get; set; }
        public List<Expense> Expenses { get; set; }

        public decimal UntouchableMoneyDeposit() => Incomes.Sum() * PERCENTAGE;
    }
}
