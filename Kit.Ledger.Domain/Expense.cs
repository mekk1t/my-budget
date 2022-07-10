using KitBudget.Domain.Abstractions;
using KitBudget.Domain.Enums;

namespace KitBudget.Domain
{
    public class Expense : Entity
    {
        public Person Person { get; set; }
        public string Target { get; set; }
        public Bank Bank { get; set; }
        public DateTime? EndsAt { get; set; }
        public int Amount { get; set; }
        public bool IsNecessary { get; }
        public bool IsDesired { get; set; }

        /// <summary>
        /// Создает новый объект трат.
        /// </summary>
        public Expense(int amount, string target, bool isNecessary = true) : base()
        {
            Amount = amount;
            Target = target;
            IsNecessary = isNecessary;
        }

        /// <summary>
        /// Создает существующий объект трат.
        /// </summary>
        /// <param name="id"></param>
        public Expense(int amount, string target, long id, bool isNecessary = true) : base(id)
        {
            Amount = amount;
            Target = target;
            IsNecessary = isNecessary;
        }
    }
}
