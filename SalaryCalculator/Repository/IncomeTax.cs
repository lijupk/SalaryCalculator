using SalaryCalculator.Interface;
using SalaryCalculator.Models;
using System;

namespace SalaryCalculator.Repository
{
    public class IncomeTax : ICalculator
    {
        public decimal Calculate(TaxRate taxRate, decimal taxableIncome)
        {
            var currentIncomeTaxSlab = taxRate.IncomeTaxRange.Find(x => x.Lower <= taxableIncome && (!x.Upper.HasValue || x.Upper >= taxableIncome));
            var incomeTax = Math.Round(currentIncomeTaxSlab.FixedTax + (((taxableIncome - (currentIncomeTaxSlab.Lower - 1)) * currentIncomeTaxSlab.Rate) / 100));
            return incomeTax;
        }
    }
}
