using FluentAssertions;
using Kit.Ledger.Domain;
using Kit.Ledger.Domain.Enums;
using System.Collections.Generic;
using Xunit;

namespace Kit.Ledger.Tests
{
    public class RevisionsTests
    {
        [Fact]
        public void Расчёт_перевода_денег_на_сберкарту_в_начале_месяца()
        {
            Revision sut =
                new(
                    new List<decimal> { 162_000 },
                    new List<Expense>
                    {
                        new Expense(23021, ExpenseType.Mortgage, Person.Nikita),
                        new Expense(0, ExpenseType.Parking, Person.Nikita),
                        new Expense(9000, ExpenseType.VKA, Person.Nikita),
                        new Expense(4000, ExpenseType.Dance, Person.Tonya)
                    },
                    AccountType.Salary,
                    Month.July);

            decimal result = sut.SberbankTransferAmount;

            result.Should().Be(32021);
        }
    }
}
