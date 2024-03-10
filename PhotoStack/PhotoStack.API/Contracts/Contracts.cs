namespace PhotoStack.API.Contracts
{
    public record CreatePhotoRequest(
        string Title,
        decimal Price,
        string Description,
        IFormFile Image);

    public record GetPhotoCards(
        int pageNumber,
        int pageSize
        );

}
