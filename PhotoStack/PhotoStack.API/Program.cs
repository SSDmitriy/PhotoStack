using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PhotoStack.Application;
using PhotoStack.Domain.Interfaces;
using PhotoStack.Persistence;
using PhotoStack.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AddDbContext<>() - метод расширения, который регистрируется в DI
builder.Services.AddDbContext<PhotoStackContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(PhotoStackContext)));
});

Console.WriteLine(builder.Configuration.GetSection("Key1").Value);
Console.WriteLine(builder.Configuration.GetSection("Key2").Value);

//регистрация репозиториев
builder.Services.AddScoped<IPhotoCardsRepository, PhotoCardsRepository>();

//регистрация сервисов
builder.Services.AddScoped<IPhotoCardsService, PhotoCardsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "StaticFiles"))
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();
