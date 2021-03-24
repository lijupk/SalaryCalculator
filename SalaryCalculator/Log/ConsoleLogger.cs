using SalaryCalculator.Enum;
using SalaryCalculator.Interface;
using System;

namespace SalaryCalculator.Log
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Log(string message, string value )
        {
            Console.WriteLine(message, value);
        }

        public void Log(string message, string value, Frequency frequency)
        {
            Console.WriteLine(message, value, frequency);
        }
    }
}
