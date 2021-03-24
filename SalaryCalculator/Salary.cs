using System;
using System.Collections.Generic;
using System.Text;

using SalaryCalculator.Enum;

namespace SalaryCalculator
{
    public class Salary
    {
        public decimal Gross { get; set; }
        public decimal Super { get; set; }
        public Frequency Frequency { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal MedicareLevy { get; set; }
        public decimal BudgetRepairLevy { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal NetPay { get; set; }
    }
}
