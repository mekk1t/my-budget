using KitBudget.Domain.Abstractions;
using KitBudget.Domain.Enums;

namespace KitBudget.Domain
{
    public class Income : Entity
    {
        public Person Person { get; set; }
        public IncomeSource Source { get; set; }
        public int Amount { get; set; }
        public Bank Bank { get; set; }

        /// <summary>
        /// Создает новый объект дохода.
        /// </summary>
        public Income(int amount) : base()
        {
            Amount = amount;
        }

        /// <summary>
        /// Создает существующий объект дохода.
        /// </summary>
        /// <param name="id">ID существующего объекта дохода.</param>
        public Income(int amount, long id) : base(id)
        {
            Amount = amount;
        }
    }
}
