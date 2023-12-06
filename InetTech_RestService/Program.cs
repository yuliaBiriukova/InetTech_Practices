using InetTech_RestService.Extensions;
using InetTech_RestService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "InetTech RestApi";
});

builder.Services.AddSingleton<ITopicRepository, TopicRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCustomExceptionHandler();

app.Run();
