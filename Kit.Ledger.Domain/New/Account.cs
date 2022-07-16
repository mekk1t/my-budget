using Kit.Ledger.Domain.Enums;

namespace Kit.Ledger.Domain.New
{
    /// <summary>
    /// Счёт в банке.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Банк, в котором открыт счёт.
        /// </summary>
        public Bank Bank { get; }
        /// <summary>
        /// Название счёта.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Владелец счёта.
        /// </summary>
        public Person Person { get; }

        /// <summary>
        /// Создает объект счёта в банке.
        /// </summary>
        /// <param name="bank">Банк, в котором открыт счёт.</param>
        /// <param name="name">Название счёта.</param>
        /// <param name="person">Владелец счёта.</param>
        public Account(Bank bank, string name, Person person)
        {
            Bank = bank;
            Name = name;
            Person = person;
        }
    }
}
