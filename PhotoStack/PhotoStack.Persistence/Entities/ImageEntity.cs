

namespace PhotoStack.Persistence.Entities
{
    public class ImageEntity
    {
        public Guid PhotoCardId { get; set; }
        public string FilePath { get; set; } = string.Empty;
    }
}
