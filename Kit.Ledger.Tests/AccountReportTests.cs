using FluentAssertions;
using Kit.Ledger.Domain;
using Kit.Ledger.Domain.Enums;
using System.Collections.Generic;
using Xunit;

namespace Kit.Ledger.Tests
{
    public class AccountReportTests
    {
        private static AccountReport CreateJuneReport()
        {
            return
                new AccountReport(
                    new Account(Bank.Alfa, AccountType.Salary, Person.Nikita),
                    Month.July,
                    default,
                    default,
                    new List<Expense>()
                    {
                        new Expense(104741 + 12000, ExpenseType.Food)
                    },
                    new List<decimal> { 164_500 });
        }

        [Fact]
        public void Расчет_откладываемых_денег_на_счет_нз()
        {
            var salaryAccountReport = CreateJuneReport();

            decimal result = salaryAccountReport.NzDeposit;

            result.Should().Be(16450);
        }

        [Fact]
        public void Расчет_откладываемых_денег_на_счет_карманных_расходов()
        {
            var salaryAccountReport = CreateJuneReport();

            decimal result = salaryAccountReport.PocketDeposit;

            result.Should().Be(31309);
        }
    }
}
