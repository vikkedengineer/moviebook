using MovieBook.App.Api.BL.Interface;
using MovieBook.App.Api.BL.ServiceManager;
using MovieBook.App.Api.Core.Interface;
using MovieBook.App.Api.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IMovieManager, MovieManager>();
builder.Services.AddControllers();

builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAccountManager, AccountManager>();
builder.Services.AddTransient<IMovieManager, MovieManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
