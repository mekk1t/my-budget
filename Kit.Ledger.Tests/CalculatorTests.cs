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
    public class CalculatorTests
    {
        [Fact]
        public void Заполнение_первой_ревизии()
        {
            Revision firstRevision = new Revision
            {
                CreatedAt = DateTime.UtcNow,
                UntouchableMoneyBalance = 32242.8m,
                PocketMoneyBalance = 22057,
                Incomes = new List<decimal>
                {
                    150_000,
                    12_000
                },
                Expenses = new List<decimal>
                {
                    23021, 5000, 9000, 350, 350, 850, 200, 4000
                }
            };

            decimal sberbankTransferAmount = Calculator.FirstRevisionSberbankTransferAmount(firstRevision);

            sberbankTransferAmount.Should().Be(32021);
        }
    }
}
