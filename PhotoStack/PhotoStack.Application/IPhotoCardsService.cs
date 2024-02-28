using PhotoStack.Domain.Models;

namespace PhotoStack.Application
{
    public interface IPhotoCardsService
    {
        Task Create(PhotoCard photoCard);
        //Task GetTask(PhotoCard photoCard);
    }
}