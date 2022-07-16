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
        /// Тип счёта.
        /// </summary>
        public AccountType Type { get; }
        /// <summary>
        /// Владелец счёта.
        /// </summary>
        public Person Person { get; }

        /// <summary>
        /// Создает объект счёта в банке.
        /// </summary>
        /// <param name="bank">Банк, в котором открыт счёт.</param>
        /// <param name="name">Тип счёта.</param>
        /// <param name="person">Владелец счёта.</param>
        public Account(Bank bank, AccountType type, Person person)
        {
            Bank = bank;
            Type = type;
            Person = person;
        }
    }
}
