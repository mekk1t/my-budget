namespace Kit.Ledger.Domain.New
{
    public class Revision
    {
        public DateTime CreatedAt { get; set; }
        public List<decimal> Incomes { get; set; }
        public decimal UntouchableMoneyBalance { get; set; }
        public decimal PocketMoneyBalance { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
