using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Models
{
    public class BudgetRepairLevyIncomeRange
    {
        public int Lower { get; set; }
        public int? Upper { get; set; }
        public decimal Rate { get; set; }
    }
}
