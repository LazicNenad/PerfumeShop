using PerfumeShop.API.Core;
using PerfumeShop.API.Extensions;
using PerfumeShop.Application.Emails;
using PerfumeShop.Application.Logging;
using PerfumeShop.Application.UseCases.Commands.BrandCommands;
using PerfumeShop.Application.UseCases.Commands.UserCommands;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using PerfumeShop.Implementation;
using PerfumeShop.Implementation.Emails;
using PerfumeShop.Implementation.Logging;
using PerfumeShop.Implementation.UseCases.Commands.EF.Brands;
using PerfumeShop.Implementation.UseCases.Commands.EF.Users;
using PerfumeShop.Implementation.UseCases.Queries.EF;
using PerfumeShop.Implementation.Validations.BrandValidations;
using PerfumeShop.Implementation.Validations.UserValidations;

var builder = WebApplication.CreateBuilder(args);
var settings = new AppSettings();

builder.Configuration.Bind(settings);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<PerfumeContext>();
builder.Services.AddSingleton<UseCaseHandler>();

builder.Services.AddTransient<IEmailSender>(x =>
{
    return new SmptEmailSender(settings.EmailOptions.FromEmail, settings.EmailOptions.Password, settings.EmailOptions.Port,
        settings.EmailOptions.Host);
});

builder.Services.AddUseCases();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(settings);
builder.Services.AddJwt(settings);
builder.Services.AddApplicationUser();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
