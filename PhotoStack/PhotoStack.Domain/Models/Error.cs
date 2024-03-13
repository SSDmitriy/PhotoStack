namespace PhotoStack.Domain.Models
{
    public record Error(string Message);

    public static class GeneralErrors
    {
        public static Error IsInvalid(string name)
        {
            return new Error($"{name} is invalid");
        }
    }
}
