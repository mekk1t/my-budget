namespace Kit.Ledger.Domain
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

        /// <summary>
        /// Рассчитывает, сколько можно отложить на счёт "Карманные расходы" в конце месяца.
        /// </summary>
        /// <returns>
        /// Размер денежных средств, которые можно перевести на карту Сбербанка.
        /// </returns>
        /// <exception cref="InvalidOperationException">Не заполнена вторая итерация бюджета.</exception>
        public decimal PocketMoneyDeposit()
        {
            if (SecondRevision == null)
                throw new InvalidOperationException("Не заполнена вторая итерация бюджета");

            return

                    (FirstRevision.Incomes.Sum() + SecondRevision.Incomes.Sum()) *
                    (1 - Constants.UNTOUCHABLE_MONEY_INCOME_PERCENTAGE)
                 -
                (
                    FirstRevision.Expenses.Select(e => e.Amount).Sum() + SecondRevision.Expenses.Select(e => e.Amount).Sum()
                );
        }
    }
}
