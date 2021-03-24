using SalaryCalculator.Enum;

namespace SalaryCalculator.Interface
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string message, string value);
        void Log(string message, string value, Frequency frequency);
    }
}
