namespace PhotoStack.API.Contracts
{
    public record CreatePhotoRequest(
        string Title,
        decimal Price,
        string Description,
        IFormFile Image);

    public record GetPhotoCardsRequest(
        int pageNumber,
        int pageSize);


    public record GetPhotoCardByIdRequest(
        Guid id);
}
