namespace KitBudget.Entities
{
    public class ExpectedBalance
    {
        private readonly Calculator _calculator;

        public int Amount => _calculator.CalculateFreeMoney().Amount;
        public DateOnly CreatedAt { get; }

        public ExpectedBalance(CurrentTime currentTime, Calculator calculator)
        {
            DateTime now = currentTime.Now;
            CreatedAt = new DateOnly(now.Year, now.Month, now.Day);
            _calculator = calculator;
        }
    }
}
