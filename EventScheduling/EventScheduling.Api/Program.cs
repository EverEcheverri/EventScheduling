using System.Net.Mime;
using EventScheduling.Api.Middleware;
using EventScheduling.Application.DependencyInjection;
using EventScheduling.Infrastructure.DependencyInjection;
using EventScheduling.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
  options.InvalidModelStateResponseFactory = context =>
  {
    var problemDetails = CustomBadRequest.ConstructErrorMessages(context);

    var result = new BadRequestObjectResult(problemDetails);
    result.ContentTypes.Add(MediaTypeNames.Application.Json);

    return result;
  };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var locationServiceUrl = builder.Configuration.GetSection("LocationService:Url").Value;
builder.Services.AddHttpClient("Weatherstack", httpClient =>
{
  httpClient.BaseAddress = new Uri(locationServiceUrl);
  httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

builder.Services.AddDbContext<EventSchedulingDbContext>();
builder.Services.AddUseCases();
builder.Services.AddRepositories();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
  var dataContext = scope.ServiceProvider.GetRequiredService<EventSchedulingDbContext>();
  dataContext.Database.Migrate();
}

app.UseCustomMiddleware();
app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
