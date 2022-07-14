using FluentAssertions;
using Kit.Ledger.Domain.New;
using System;
using System.Collections.Generic;
using Xunit;

namespace Kit.Ledger.Tests
{
    public class CalculatorTests
    {
        private static List<Expense> JuneDynamicExpenses() => new List<Expense>()
        {
            new Expense(8635, ExpenseType.Food),
            new Expense(3679, ExpenseType.Samokat, Person.Nikita),
            new Expense(4000, ExpenseType.Psychologist, Person.Tonya),
            new Expense(6000, ExpenseType.Dentist, Person.Nikita),
            new Expense(400, ExpenseType.TransportSocial, Person.Nikita),
            new Expense(709, ExpenseType.TransportTaxi, Person.Nikita),
            new Expense(2287, ExpenseType.FoodOnTheRun),
            new Expense(7106, ExpenseType.OZON, Person.Nikita),
            new Expense(6887, ExpenseType.MihailikKitchen, Person.Nikita)
        };

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
                Expenses = JuneFixedExpenses()
            };

            decimal sberbankTransferAmount = Calculator.FirstRevisionSberbankTransferAmount(firstRevision);

            sberbankTransferAmount.Should().Be(32021);
        }

        [Fact]
        public void Расчёт_первого_взноса_на_счет_нз()
        {
            Budget previousMonthBudget = new Budget
            {
                Month = Month.June,
                FirstRevision = new Revision
                {
                    CreatedAt = DateTime.Now,
                    PocketMoneyBalance = 58092,
                    UntouchableMoneyBalance = 16450,
                    Incomes = new List<decimal> { 162000},
                    Expenses = JuneFixedExpenses()
                },
                SecondRevision = new Revision
                {
                    CreatedAt = DateTime.Now,
                    PocketMoneyBalance = 22057,
                    UntouchableMoneyBalance = 16450,
                    Incomes = new List<decimal> { 2500},
                    Expenses = JuneDynamicExpenses()
                }
            };
            Revision firstRevision = new Revision
            {
                CreatedAt = DateTime.UtcNow,
                UntouchableMoneyBalance = 16450,
                PocketMoneyBalance = 22057,
                Incomes = new List<decimal>
                {
                    150_000,
                    12_000
                },
                Expenses = new List<Expense>
                {
                    new Expense(23021, ExpenseType.Mortgage, Person.Nikita),
                    new Expense(5000, ExpenseType.HousingServices, Person.Tonya),
                    new Expense(9000, ExpenseType.VKA, Person.Nikita),
                    new Expense(350, ExpenseType.PhoneNikita, Person.Nikita),
                    new Expense(350, ExpenseType.PhoneTonya, Person.Tonya),
                    new Expense(850, ExpenseType.Internet, Person.Nikita),
                    new Expense(200, ExpenseType.OnlineMusic, Person.Nikita),
                    new Expense(4000, ExpenseType.Dance, Person.Tonya)
                }
            };

            decimal untouchableMoneyStartBalance = Calculator.UntouchableMoneyBalanceAtTheStartOfTheMonth(previousMonthBudget, firstRevision);

            untouchableMoneyStartBalance.Should().Be(32650);
        }
    }
}
