using SalaryCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Interface
{
    public interface ICalculator
    {
        public decimal Calculate(TaxRate taxRate, decimal taxableIncome);
    }
}
