using System.ComponentModel.DataAnnotations;

namespace PhotoStack.API.Contracts
{
    public record CreatePhotoRequest(
        string? Title,
        decimal? Price,
        string? Description,
        IFormFile? Image);

    public record GetPhotoCardsRequest(
        int PageNumber,
        int PageSize);
}
