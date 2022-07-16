namespace Kit.Ledger.Domain
{
    /// <summary>
    /// Тип счёта в банке.
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// Никакой. Значение перечисления по умолчанию.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Зарплатный.
        /// </summary>
        Salary = 1,
        /// <summary>
        /// НЗ - Неприкосновенный Запас.
        /// </summary>
        NZ = 2,
        /// <summary>
        /// Карманные расходы.
        /// </summary>
        Pocket = 3
    }
}
