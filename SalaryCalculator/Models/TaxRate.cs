using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Models
{
    public class TaxRate
    {
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("superRate")]
        public decimal SuperRate { get; set; }
        [JsonProperty("incomeTaxRange")]
        public List<IncomeTaxRange> IncomeTaxRange { get; set; }
        [JsonProperty("medicareLevyIncomeRange")]
        public List<MedicareLevyIncomeRange> MedicareLevyIncomeRange { get; set; }
        [JsonProperty("budgetRepairLevyIncomeRange")]
        public List<BudgetRepairLevyIncomeRange> BudgetRepairLevyIncomeRange { get; set; }
    }
}
