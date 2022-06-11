namespace KitBudget.Entities
{
    public class Income
    {
        public Person Person { get; set; }
        public IncomeSource Source { get; set; }
        public int Amount { get; set; }
    }
}
