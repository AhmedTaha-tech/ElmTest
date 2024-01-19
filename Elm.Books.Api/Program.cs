using Elm.Books.Api.Extentions;
using Elm.Books.Domain.Contracts;
using Elm.Books.Infrastructure;
using Elm.Books.Infrastructure.Repository;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BooksDBContext>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatRService();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
