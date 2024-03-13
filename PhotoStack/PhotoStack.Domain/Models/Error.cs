
namespace PhotoStack.Domain.Models
{
    public record Error(string Message);

    public static class GeneralErrors
    {
        public static Error CannotBeEmpty(string name)
        {
            return new Error($"Parameter \'{name}\' can't be empty.");
        }

        public static Error LongerThan(string name, int maxLength)
        {
            return new Error($"Parameter \'{name}\' can't be longer than {maxLength}.");
        }

        internal static Error LessThan(string name, decimal minValue)
        {
            return new Error($"Parameter \'{name}\' can't be less than {minValue}.");
        }

        internal static Error GreaterThan(string name, decimal maxValue)
        {
            return new Error($"Parameter \'{name}\' can't be greater than {maxValue}.");
        }
    }
}
