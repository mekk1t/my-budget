namespace KitBudget.Domain
{
    public class CurrentTime
    {
        private readonly int _timeZoneOffset;
        public DateTime Now => DateTime.UtcNow.AddHours(_timeZoneOffset);

        public CurrentTime(int timeZoneOffset)
        {
            _timeZoneOffset = timeZoneOffset;
        }
    }
}
