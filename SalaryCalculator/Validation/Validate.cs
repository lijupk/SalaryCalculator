using SalaryCalculator.Log;
using System;

namespace SalaryCalculator.Validation
{
    public static class Validate
    {
        public static ConsoleKeyInfo ValidatePayFrequencyUserInput(ConsoleLogger logger)
        {
            var payFrequencyUserInput = Console.ReadKey();
            var frequencySuccess = false;
            if (!string.IsNullOrEmpty(payFrequencyUserInput.KeyChar.ToString()) && (payFrequencyUserInput.KeyChar.ToString().ToUpper() == "M"
                || payFrequencyUserInput.KeyChar.ToString().ToUpper() == "F" || payFrequencyUserInput.KeyChar.ToString().ToUpper() == "W"))
            {
                frequencySuccess = true;
            }
            while (!frequencySuccess)
            {
                logger.Log("\nInvalid Input. Try again...");
                Console.Write("Please enter a valid selection : ");
                payFrequencyUserInput = Console.ReadKey();
                if (payFrequencyUserInput.KeyChar.ToString().ToUpper() == "M"
                    || payFrequencyUserInput.KeyChar.ToString().ToUpper() == "F" || payFrequencyUserInput.KeyChar.ToString().ToUpper() == "W")
                {
                    frequencySuccess = true;
                }
            }

            return payFrequencyUserInput;
        }

        public static decimal ValidateGrossInput(ConsoleLogger logger)
        {
            var grossPackageUserInput = Console.ReadLine();
            bool success = decimal.TryParse(grossPackageUserInput, out decimal totalPackageInDecimal);
            while (!success)
            {
                logger.Log("Invalid Input. Try again...");
                Console.Write("Please enter a valid number: ");
                grossPackageUserInput = Console.ReadLine();
                success = decimal.TryParse(grossPackageUserInput, out totalPackageInDecimal);
            }

            return totalPackageInDecimal;
        }
    }
}
