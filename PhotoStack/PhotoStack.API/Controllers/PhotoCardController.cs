using Microsoft.AspNetCore.Mvc;
using PhotoStack.Domain.Models;

namespace PhotoStack.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class GetPhotoCardController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var photoCard = new PhotoCard(
                Guid.NewGuid(),
                "",
                1.99m,
                "",
                new Image());

            return Ok(photoCard);
        }
    }

    [ApiController]
    [Route("v2/[controller]")]
    public class PutPhotoCardController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var photoCard = new PhotoCard(
                Guid.NewGuid(),
                "",
                99.77m,
                "",
                new Image());

            return Ok(photoCard);

        }
    }

}
