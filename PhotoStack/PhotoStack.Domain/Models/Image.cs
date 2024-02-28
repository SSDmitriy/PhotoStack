namespace PhotoStack.Domain.Models
{
    public class Image
    {
        //public Guid Id { get; set; }
        public string FilePath { get; } = string.Empty;

        public Image(string filePath)
        {
            FilePath = filePath;
        }
    }
}
