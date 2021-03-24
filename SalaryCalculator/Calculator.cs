using SalaryCalculator.Enum;
using System;
using SalaryCalculator.Repository;
using SalaryCalculator.Interface;
using System.Linq;
using SalaryCalculator.Data;

namespace SalaryCalculator
{
    public class Calculator
    {
        private readonly ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }
        
        public void Calculate(decimal grossPackage, char payFrequencyUserInput)
        {
            //1. Find the taxation year
            var taxYear = DateTime.Now.Year;

            // read file into a string and deserialize JSON to a type
            var taxFile = GetTaxFile.RetrieveTaxFile(_logger);           

            try
            {
                //Locate the tax data from tax file based on the current year and load the tax slabs

                if (taxFile == null)
                {
                    _logger.Log("no data in tax file.");
                    return;
                }

                var currentTaxRate = taxFile.TaxRates != null && taxFile.TaxRates.Any() ? taxFile.TaxRates.Find(x => x.Year == taxYear) : null;

                if (currentTaxRate == null)
                {
                    _logger.Log("no tax data found for the current year in tax file.");
                    return;
                }

                //2. find the percentage of Super
                var superPercentage = currentTaxRate.SuperRate;

                //3. Calculate Super component

                var taxableIncome = grossPackage / ((100 + superPercentage) / 100);

                var super = taxableIncome * (superPercentage / 100);

                //4. Do deductions

                //4.1. Tax

                decimal incomeTax = new IncomeTax().Calculate(currentTaxRate, taxableIncome);

                //4.2. Medicare Levy

                decimal medicareLevy = new MedicareLevy().Calculate(currentTaxRate, taxableIncome);

                //4.3. Budget Repair Levy

                decimal budgetRepairLevy = new BudgetRepairLevy().Calculate(currentTaxRate, taxableIncome);

                //5. Find Net Pay

                var netIncome = grossPackage - super - incomeTax - medicareLevy - budgetRepairLevy;

                //6. Net pay per passed frequency .i.e., Monthly, Weekly or fortnightly
                Frequency frequency;
                decimal netPay = 0;

                frequency = CalculateNetPayAndFrequency(payFrequencyUserInput, netIncome, ref netPay);

                //7. Build and return the result
                var salary = new Salary()
                {
                    Super = super,
                    TaxableIncome = taxableIncome,
                    NetIncome = netIncome,
                    BudgetRepairLevy = budgetRepairLevy,
                    MedicareLevy = medicareLevy,
                    IncomeTax = incomeTax,
                    Frequency = frequency,
                    NetPay = netPay,
                    Gross = grossPackage
                };
                DisplayOutput(grossPackage, salary);
            }
            catch (Exception ex)
            {
                _logger.Log("Error occurred during Calculate.. {0}", ex.Message);
            }
        }

        private static Frequency CalculateNetPayAndFrequency(char payFrequencyUserInput, decimal netIncome, ref decimal netPay)
        {
            Frequency frequency;
            switch (payFrequencyUserInput)
            {
                case 'W':
                case 'w':
                    netPay = Math.Round((netIncome / 48), 2);
                    frequency = Enum.Frequency.Weekly;
                    break;
                case 'F':
                case 'f':
                    netPay = Math.Round((netIncome / 24), 2);
                    frequency = Enum.Frequency.Fortnightly;
                    break;
                case 'M':
                case 'm':
                    netPay = Math.Round((netIncome / 12), 2);
                    frequency = Enum.Frequency.Monthly;
                    break;
                default:
                    frequency = Frequency.Monthly;
                    break;
            }

            return frequency;
        }

        private void DisplayOutput(decimal grossPackage, Salary salary)
        {
            _logger.Log("\nGross package : {0}", (String.Format("{0}", grossPackage)));

            _logger.Log("Superannuation : {0}", (String.Format("{0:C2}", salary.Super)));

            _logger.Log("\nTaxable Income : {0}", (String.Format("{0:C2}", salary.TaxableIncome)));

            _logger.Log("\nDeductions:");

            _logger.Log("Medicare Levy : {0}", (String.Format("{0:C2}", salary.MedicareLevy)));

            _logger.Log("Budget Repair Levy : {0}", (String.Format("{0:C2}", salary.BudgetRepairLevy)));

            _logger.Log("Income Tax : {0}", (String.Format("{0:C2}", salary.IncomeTax)));

            _logger.Log("\nNet Income : {0}", (String.Format("{0:C2}", salary.NetIncome)));

            _logger.Log("Pay packet: {0} per {1}", (String.Format("{0:C2}", salary.NetPay)), salary.Frequency);
        }
    }
}
