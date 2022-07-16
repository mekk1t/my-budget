namespace Kit.Ledger.Domain
{
    public static class Calculator
    {
        public static decimal CalculateNzDeposit(AccountReport salaryAccountReport, decimal percentage)
        {
            if (salaryAccountReport.Account.Type != AccountType.Salary)
                throw new InvalidOperationException("На счёт НЗ деньги откладываются с зарплатного счёта");

            return salaryAccountReport.Incomes.Sum(x => x * percentage);
        }

        public static decimal CalculatePocketDeposit(AccountReport salaryAccountReport, decimal nzPercentage)
        {
            if (salaryAccountReport.Account.Type != AccountType.Salary)
                throw new InvalidOperationException("На счёт КР деньги откладываются с зарплатного счёта");

            decimal income = salaryAccountReport.Incomes.Sum() - CalculateNzDeposit(salaryAccountReport, nzPercentage);

            return income - salaryAccountReport.Expenses.Sum(x => x.Amount);
        }
    }
}
