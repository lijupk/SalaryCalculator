using Newtonsoft.Json;
using SalaryCalculator.Interface;
using SalaryCalculator.Models;
using System;
using System.IO;

namespace SalaryCalculator.Data
{
    public static class GetTaxFile
    {
        public static TaxFile RetrieveTaxFile(ILogger logger)
        {
            TaxFile taxFile;
            try
            {
                taxFile = JsonConvert.DeserializeObject<TaxFile>(File.ReadAllText(@".\Data\TaxFile.json"));
                return taxFile;
            }
            catch (Exception ex)
            {
                logger.Log("Error loading tax file : {0}", ex.Message);
                return null;
            }
        }
    }
}
