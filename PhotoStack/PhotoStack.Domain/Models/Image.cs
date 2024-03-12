namespace PhotoStack.Domain.Models
{
    public class Image
    {
        public string FilePath { get; } = string.Empty;

        public Image(string filePath)
        {
            FilePath = filePath;
        }
    }
}
