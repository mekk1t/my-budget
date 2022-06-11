﻿namespace KitBudget.Entities
{
    public class ExpectedBalance
    {
        private readonly IEnumerable<Income> _incomes;
        private readonly IEnumerable<Expense> _expenses;
        private readonly int _untouchableMoneyAmount;

        public int Amount => _incomes.Sum(i => i.Amount) - _expenses.Sum(e => e.Amount) - _untouchableMoneyAmount;
        public DateOnly CreatedAt { get; }

        public ExpectedBalance(
            IEnumerable<Income> incomes,
            IEnumerable<Expense> expenses,
            int untouchableMoneyAmount,
            CurrentTime currentTime)
        {
            _incomes = incomes;
            _expenses = expenses;
            _untouchableMoneyAmount = untouchableMoneyAmount;
            DateTime now = currentTime.Now;
            CreatedAt = new DateOnly(now.Year, now.Month, now.Day);
        }
    }
}
