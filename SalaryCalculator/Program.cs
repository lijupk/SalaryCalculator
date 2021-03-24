using SalaryCalculator.Log;
using SalaryCalculator.Validation;
using System;

namespace SalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();

            Console.Write("Enter your salary package amount: ");
            decimal grossPackageInDecimal = Validate.ValidateGrossInput(logger);

            Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
            ConsoleKeyInfo payFrequencyUserInput = Validate.ValidatePayFrequencyUserInput(logger);

            logger.Log("\n\nCalculating salary details...");

            var calculator = new Calculator(logger);
            calculator.Calculate(grossPackageInDecimal, payFrequencyUserInput.KeyChar);

            Console.Write("\nPress any key to end...");
            Console.ReadKey();
        }        
    }
}
