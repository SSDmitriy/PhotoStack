namespace PhotoStack.Domain.Models
{
    public class Image
    {
        public Guid PhotoCardId { get; set; }
        public string FilePath { get; set; } = string.Empty;
    }
}
