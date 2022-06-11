using FluentAssertions;
using KitBudget.Entities;
using Xunit;

namespace KitBudget.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Со_всех_доходов_в_нз_откладывается_10процентов()
        {
            var incomes = new[] { new Income(500), new Income(1000), new Income(500) };
            var expenses = new[] { new Expense(500, "Пирожки"), new Expense(1000, "ЖКХ") };
            var sut = new Calculator(incomes, expenses);

            int result = sut.CalculateUntouchableMoney().Amount;

            result.Should().Be(200);
        }
    }
}
