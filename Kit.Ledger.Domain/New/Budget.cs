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
        /// Баланс счёта "НЗ" на начало месяца. Рассчитывается при составлении первой итерации бюджета.
        /// </summary>
        public decimal UntouchableMoneyAtTheStartOfTheMonth { get; }
        /// <summary>
        /// Баланс счёта "НЗ" на конец месяца. Отсутствует в первой итерации бюджета, заполняется во второй.
        /// </summary>
        public decimal? UntouchableMoneyAtTheEndOfTheMonth { get; }

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
        public Budget(Month month, Revision firstRevision, decimal untouchableMoneyAtTheStartOfTheMonth)
        {
            Month = month;
            FirstRevision = firstRevision;
            UntouchableMoneyAtTheStartOfTheMonth = untouchableMoneyAtTheStartOfTheMonth;
            UntouchableMoneyAtTheEndOfTheMonth = null;
        }

        /// <summary>
        /// Создаёт вторую итерацию бюджета.
        /// </summary>
        /// <param name="firstIteration">Первая итерация бюджета.</param>
        /// <param name="secondRevision">Вторая ревизия с динамическими тратами.</param>
        /// <param name="untouchableMoneyBalance">Баланс счёта "НЗ" на конец месяца.</param>
        public Budget(Budget firstIteration, Revision secondRevision, decimal untouchableMoneyBalance)
        {
            Month = firstIteration.Month;
            FirstRevision = firstIteration.FirstRevision;
            SecondRevision = secondRevision;
            UntouchableMoneyAtTheEndOfTheMonth = untouchableMoneyBalance;
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
                UntouchableMoneyAtTheStartOfTheMonth -
                (UntouchableMoneyAtTheStartOfTheMonth - UntouchableMoneyAtTheEndOfTheMonth);
        }
    }
}
