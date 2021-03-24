using Newtonsoft.Json;
using System.Collections.Generic;

namespace SalaryCalculator.Models
{
    public class TaxFile
    {
        [JsonProperty("taxRates")]
        public List<TaxRate> TaxRates { get; set; }
    }
}
