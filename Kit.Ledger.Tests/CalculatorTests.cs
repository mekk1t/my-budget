using FluentAssertions;
using Kit.Ledger.Domain;
using Xunit;

namespace Kit.Ledger.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Со_всех_доходов_в_нз_откладывается_10процентов()
        {
            var incomes = new[] { new Income(150_000), new Income(12_000) };
            var expenses = new[]
            {
                new Expense(23021, "Ипотека"),
                new Expense(5000, "ЖКХ"),
                new Expense(23350, "Паркинг: рассрочка"),
                new Expense(9000, "ВКА"),// надо делить траты на прогнозируемые и фактические. Либо на этой стадии насрать
                new Expense(350, "Связь: Теле2"),
                new Expense(350, "Связь: МТС"),
                new Expense(550, "Интернет"),
                new Expense(4000, "Танцы"),
                new Expense(30000, "Продукты"),
                new Expense(14000, "Садик"),
                new Expense(6555, "Штрафные"),
            };
            var sut = new Calculator(incomes, expenses);

            int result = sut.CalculateUntouchableMoney().Amount;

            result.Should().Be(16200);
        }

        [Fact]
        public void Расчет_свободных_денег()
        {
            var incomes = new[] { new Income(150_000), new Income(12_000) };
            var expenses = new[]
            {
                new Expense(23021, "Ипотека"),
                new Expense(5000, "ЖКХ"),
                new Expense(23350, "Паркинг: рассрочка"),
                new Expense(9000, "ВКА"),// надо делить траты на прогнозируемые и фактические. Либо на этой стадии насрать
                new Expense(350, "Связь: Теле2"),
                new Expense(350, "Связь: МТС"),
                new Expense(550, "Интернет"),
                new Expense(4000, "Танцы"),
                new Expense(30000, "Продукты"),
                new Expense(14000, "Садик"),
                new Expense(6555, "Штрафные"),
            };
            var sut = new Calculator(incomes, expenses);

            int result = sut.CalculateFreeMoney().Amount;

            result.Should().Be(29624);
        }
    }
}
