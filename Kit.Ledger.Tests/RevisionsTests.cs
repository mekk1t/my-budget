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

        [Theory]
        [InlineData(AccountType.Default)]
        [InlineData(AccountType.NZ)]
        [InlineData(AccountType.Pocket)]
        public void На_сберкарту_переводятся_деньги_только_со_счета_зп(AccountType nonSalaryAccountType)
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
                    nonSalaryAccountType,
                    Month.July);

            decimal result = sut.SberbankTransferAmount;

            result.Should().Be(0);
        }

        [Fact]
        public void На_сберкарту_не_нужно_переводить_деньги_на_обязательные_расходы_если_их_нет()
        {
            Revision sut =
                new(
                    new List<decimal> { 1 },
                    new List<Expense> { new Expense(5000, ExpenseType.Dentist, Person.Nikita) },
                    AccountType.Salary,
                    Month.August);

            decimal result = sut.SberbankTransferAmount;

            result.Should().Be(0);
        }
    }
}
