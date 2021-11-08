using System;
using System.Collections.Generic;

namespace DomainModels
{
    public class Estimate
    {
        public DateTime Date { get; set; }
        public List<Income> Incomes { get; set; } = new List<Income>(0);
        public List<Expense> Expenses { get; set; } = new List<Expense>(0);
    }
}
