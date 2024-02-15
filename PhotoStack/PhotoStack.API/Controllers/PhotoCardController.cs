using Microsoft.AspNetCore.Mvc;
using PhotoStack.API.Contracts;
using PhotoStack.Application;
using PhotoStack.Domain.Models;
namespace PhotoStack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoCardController : ControllerBase
    {
        private readonly PhotoCardsService _photoCardsService;
        public PhotoCardController(PhotoCardsService photoCardsService)
        {
           _photoCardsService = photoCardsService;
        }
        

        //POST: localhost:5000/photocard
        [HttpPost]
        public async Task<ActionResult> Create([FromForm]CreatePhotoRequest request)
        {

            PhotoCard photoCard = new(
                Guid.NewGuid(),
                request.Title,
                request.Price,
                request.Description,
                new Image());

            await _photoCardsService.Create(photoCard);

            return Created();
        }

    }
}
