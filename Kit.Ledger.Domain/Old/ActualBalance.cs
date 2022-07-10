namespace Kit.Ledger.Domain
{
    public class ActualBalance
    {
        private readonly ExpectedBalance _expectedBalance;
        private readonly IEnumerable<Expense> _actualExpenses;
        private readonly int _currentAmount;

        public int Delta => _expectedBalance.Amount - _actualExpenses.Sum(e => e.Amount);
        public int Amount => _currentAmount + Delta;

        public ActualBalance(int currentAmount, ExpectedBalance expectedBalance, IEnumerable<Expense> actualExpenses)
        {
            _currentAmount = currentAmount;
            _expectedBalance = expectedBalance;
            _actualExpenses = actualExpenses;
        }
    }
}
