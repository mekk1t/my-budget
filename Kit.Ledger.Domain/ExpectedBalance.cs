namespace Kit.Ledger.Domain
{
    public class ExpectedBalance
    {
        private readonly Calculator _calculator;

        public DateOnly CreatedAt { get; }
        public int Amount { get => _calculator.CalculateFreeMoney().Amount; }

        public ExpectedBalance(CurrentTime currentTime, Calculator calculator)
        {
            DateTime now = currentTime.Now;
            CreatedAt = new DateOnly(now.Year, now.Month, now.Day);
            _calculator = calculator;
        }
    }
}
