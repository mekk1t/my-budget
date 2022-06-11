﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBudget.Entities
{
    public class Calculator
    {
        private const decimal UNTOUCHABLE_MONEY_COEFFICIENT = 0.1M;
        private readonly IEnumerable<Income> _incomes;
        private readonly IEnumerable<Expense> _expenses;

        public Calculator(IEnumerable<Income> incomes, IEnumerable<Expense> expenses)
        {
            _incomes = incomes;
            _expenses = expenses;
        }

        public UntouchableMoney CalculateUntouchableMoney() =>
            new UntouchableMoney(
                currentBalance: default,
                amount: Convert.ToInt32(Math.Round(_incomes.Sum(i => i.Amount) / UNTOUCHABLE_MONEY_COEFFICIENT)));

        public FreeMoney CalculateFreeMoney() =>
            new FreeMoney
            {
                Amount = _incomes.Sum(i => i.Amount) - _expenses.Sum(e => e.Amount) - CalculateUntouchableMoney().Amount
            };
    }
}