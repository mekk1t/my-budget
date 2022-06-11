using KitBudget.Entities.Abstractions;
using KitBudget.Entities.Enums;

namespace KitBudget.Entities
{
    public class Expense : Entity
    {
        public Person Person { get; set; }
        public string Target { get; set; }
        public Bank Bank { get; set; }
        public DateTime? EndsAt { get; set; }
        public int Amount { get; set; }
        public bool IsNecessary { get; set; }
        public bool IsDesired { get; set; }

        /// <summary>
        /// Создает новый объект трат.
        /// </summary>
        public Expense(int amount, string target) : base()
        {
            Amount = amount;
            Target = target;
        }

        /// <summary>
        /// Создает существующий объект трат.
        /// </summary>
        /// <param name="id"></param>
        public Expense(int amount, string target, long id) : base(id)
        {
            Amount = amount;
            Target = target;
        }
    }
}
