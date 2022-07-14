namespace Kit.Ledger.Domain.New
{
    /// <summary>
    /// Месячный бюджет.
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// Месяц, за который составлена статистика.
        /// </summary>
        public Month Month { get; }
        /// <summary>
        /// Первая ревизия, формируется в начале месяца.
        /// </summary>
        public Revision FirstRevision { get; }
        /// <summary>
        /// Вторая ревизия, формируется в конце месяца.
        /// </summary>
        public Revision? SecondRevision { get; }

        /// <summary>
        /// Начало ведения месячного бюджета.
        /// </summary>
        public DateTime BeginsAt => FirstRevision.CreatedAt;
        /// <summary>
        /// Конец ведения месячного бюджета.
        /// </summary>
        public DateTime? EndsAt => SecondRevision?.CreatedAt;

        /// <summary>
        /// Создает первую итерацию бюджета.
        /// </summary>
        /// <param name="month">Месяц, за который ведётся бюджет.</param>
        /// <param name="firstRevision">Первая ревизия с фиксированными тратами.</param>
        public Budget(Month month, Revision firstRevision)
        {
            Month = month;
            FirstRevision = firstRevision;
        }

        /// <summary>
        /// Создаёт вторую итерацию бюджета.
        /// </summary>
        /// <param name="firstIteration">Первая итерация бюджета.</param>
        /// <param name="secondRevision">Вторая ревизия с динамическими тратами.</param>
        public Budget(Budget firstIteration, Revision secondRevision)
        {
            Month = firstIteration.Month;
            FirstRevision = firstIteration.FirstRevision;
            SecondRevision = secondRevision;
        }

        /// <summary>
        /// Получает баланс счёта "НЗ".
        /// </summary>
        /// <returns>
        /// <see langword="null"/>, если нет второй ревизии.
        /// Конкретное число иначе.
        /// </returns>
        public decimal? GetUntouchableMoneyBalance()
        {
            if (SecondRevision == null)
                return null;

            return
                FirstRevision.UntouchableMoneyBalance -
                (FirstRevision.UntouchableMoneyBalance - SecondRevision.UntouchableMoneyBalance);
        }
    }
}
