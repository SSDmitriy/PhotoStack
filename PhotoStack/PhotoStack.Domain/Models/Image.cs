namespace PhotoStack.Domain.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; } = string.Empty;
    }
}
