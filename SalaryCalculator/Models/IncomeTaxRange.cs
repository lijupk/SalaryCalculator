namespace SalaryCalculator.Models
{
    public class IncomeTaxRange
    {
        public int Lower { get; set; }
        public int? Upper { get; set; }
        public decimal Rate { get; set; }
        public int FixedTax { get; set; }
    }
}
    