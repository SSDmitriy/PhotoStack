﻿using Microsoft.AspNetCore.Mvc;
using PhotoStack.API.Contracts;
using PhotoStack.Application;
using PhotoStack.Domain.Models;

namespace PhotoStack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoCardController : ControllerBase
    {
        // "StaticFile/Images" вынести в appSettings
        // Изучить как с помощью IConfiguration достать значение из appsettings
        // Изучить как работать с ILogger, с логгером в asp net core
        // Использовать логгер при выбрасывании ошибок, при неудоачной загрузки файла
        // создать класс ImageHelper и туда вынести логику по загрузке картинки

        // создать валидацию, проверить параметры на пустую строку, на пробелы, на отрицительную цену
        // в случае ошибки, выбрасывать exception

        // if (price < 0) 
        // {
        //     throw new Exception();
        // }

        // --написать метод в контроллере на получение всех картинок
        // [HttpGet] по анологии с Create

        // написать метод в контроллере на получение одной карточки по Id
        // [HttpGet] по анологии с Create

        // прочитать про FromRoute, FromBody, FromQuery, FromForm

        private readonly string _staticFilesPath =
            Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles/Images");

        private readonly IPhotoCardsService _photoCardsService;

        public PhotoCardController(IPhotoCardsService photoCardsService)
        {
            _photoCardsService = photoCardsService;
        }

        //POST: https://localhost:7098/PhotoCard
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CreatePhotoRequest request)
        {
            var filePath = await LoadImage(request.Image);

            if (filePath == null)
            {
                return BadRequest("Не удалось сохранить файл");
            }

            var image = new Image(filePath);

            PhotoCard photoCard = new(
                Guid.NewGuid(),
                request.Title,
                request.Price,
                request.Description,
                image);

            await _photoCardsService.Create(photoCard);

            return Created();
        }

        // GET https://localhost:7098/PhotoCards?page={num}&size={count}
        // Получение всех картинок
        [HttpGet]
        public async Task<ActionResult> Page([FromQuery] GetPhotoCardsRequest request)
        {
            int _pageNumber = request.pageNumber;
            int _pageSize = request.pageSize;

            if (_pageNumber < 0)
            {
                return BadRequest("Запрашиваемая страница не может быть меньше 0");
            }

            if (_pageSize < 1 || _pageSize > 20)
            {
                return BadRequest("Размер запрашиваемой страницы должен быть в пределах 1..20");
            }

            var result = await _photoCardsService.Get(_pageNumber, _pageSize);

            return Ok(result);
        }

        // GET https://localhost:7098/PhotoCard/{id}
        // Получение картинки по id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromQuery] GetPhotoCardByIdRequest request)
        {
            Guid _id = request.id;

            var result = await _photoCardsService.GetById(_id);
            return Ok(result);
        }


        // создать класс ImageHelper и туда вынести логику по загрузке картинки
        private async Task<string?> LoadImage(IFormFile image)
        {
            try
            {
                var fileExtension = Path.GetExtension(image.FileName);

                var filePath = GenerateFileName(fileExtension);

                using var stream = new FileStream(filePath, FileMode.Create);

                await image.CopyToAsync(stream);

                return filePath;
            }
            catch (Exception ex)
            {
                throw ex;
                // отлогировать
                return null;
            }
        }

        private string GenerateFileName(string extension)
        {
            return Path.Combine(_staticFilesPath, Guid.NewGuid() + extension);
        }
    }
}
