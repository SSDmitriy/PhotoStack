namespace PhotoStack.API.Contracts
{
    public record CreatePhotoRequest(
        string Title,
        decimal Price,
        string Description,
        IFormFile Image);
}
