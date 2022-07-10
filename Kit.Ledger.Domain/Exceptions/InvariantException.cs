namespace KitBudget.Domain.Exceptions
{
    public class InvariantException : Exception
    {
        public InvariantException(string message) : base(message)
        {
        }
    }
}
