using SalaryCalculator.Interface;
using SalaryCalculator.Models;
using System;

namespace SalaryCalculator.Repository
{
    public class BudgetRepairLevy : ICalculator
    {
        public decimal Calculate(TaxRate taxRate, decimal taxableIncome)
        {
            var currentBudgetRepairLevySlab = taxRate.BudgetRepairLevyIncomeRange.Find(x => x.Lower <= taxableIncome && (!x.Upper.HasValue || x.Upper >= taxableIncome));
            var budgetRepairLevy = Math.Round((((taxableIncome - (currentBudgetRepairLevySlab.Lower - 1)) * currentBudgetRepairLevySlab.Rate) / 100));
            return budgetRepairLevy;
        }
    }
}
