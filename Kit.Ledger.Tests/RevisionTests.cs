using FluentAssertions;
using Kit.Ledger.Domain.New;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kit.Ledger.Tests
{
    public class RevisionTests
    {
        private static List<Expense> JuneFixedExpenses() => new List<Expense>()
        {
            new Expense(23021, ExpenseType.Mortgage, Person.Nikita),
            new Expense(5000, ExpenseType.HousingServices, Person.Tonya),
            new Expense(9000, ExpenseType.VKA, Person.Nikita),
            new Expense(350, ExpenseType.PhoneNikita, Person.Nikita),
            new Expense(350, ExpenseType.PhoneTonya, Person.Tonya),
            new Expense(850, ExpenseType.Internet, Person.Nikita),
            new Expense(200, ExpenseType.OnlineMusic, Person.Nikita),
            new Expense(4000, ExpenseType.Dance, Person.Tonya)
        };

        [Fact]
        public void Расчёт_откладываемых_денег_на_счёт_нз()
        {
            Revision sut = new Revision(new List<decimal> { 10000 }, new List<Expense>(0), default);

            var deposit = sut.UntouchableMoneyDeposit();

            deposit.Should().Be(1000);
        }

        [Fact]
        public void Расчёт_баланса_на_счету_нз_в_начале_месяца()
        {
            Budget firstBudget = CreateBudgetWithUntouchableMoneyBalance(16450);

            decimal balance = Calculator.GetUntouchableMoneyBalance(firstBudget, new Revision(new List<decimal> { 162_000 }, new List<Expense>(), 22057));

            balance.Should().Be(32650);
        }

        private static Budget CreateBudgetWithUntouchableMoneyBalance(decimal balance)
        {
            Budget firstBudget = new Budget(
                Month.June,
                new Revision(new List<decimal> { 162_000 }, new List<Expense>(), default),
                balance);

            return new Budget(firstBudget, new Revision(new List<decimal> { 2500 }, new List<Expense>(), default), balance);
        }
    }
}
