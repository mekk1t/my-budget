using KitBudget.Entities.Enums;

namespace KitBudget.Entities
{
    public class Expense
    {
        public Person Person { get; set; }
        public string Target { get; set; }
        public Bank Bank { get; set; }
        public DateTime? EndsAt { get; set; }
        public int Amount { get; set; }
        public bool IsNecessary { get; set; }
        public bool IsDesired { get; set; }
    }
}
