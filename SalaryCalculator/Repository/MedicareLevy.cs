using SalaryCalculator.Interface;
using SalaryCalculator.Models;
using System;

namespace SalaryCalculator.Repository
{
    public class MedicareLevy : ICalculator
    {
        public decimal Calculate(TaxRate taxRate, decimal taxableIncome)
        {
            var currentMedicareLevyTaxSlab = taxRate.MedicareLevyIncomeRange.Find(x => x.Lower <= taxableIncome && (!x.Upper.HasValue || x.Upper >= taxableIncome));
            var medicareLevy = new decimal(0.00);
            if (!currentMedicareLevyTaxSlab.Upper.HasValue)
            {
                medicareLevy = Math.Round(((taxableIncome * currentMedicareLevyTaxSlab.Rate) / 100));
            }
            else
            {
                medicareLevy = Math.Round((((taxableIncome - (currentMedicareLevyTaxSlab.Lower - 1)) * currentMedicareLevyTaxSlab.Rate) / 100));
            }
            return medicareLevy;
        }
    }
}
