using InetTech_SoapService.Middleware;
using InetTech_SoapService.Repositories;
using InetTech_SoapService.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();

builder.Services.AddSingleton<ITopicRepository, TopicRepository>();
builder.Services.AddSingleton<ITopicService, TopicService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<AuthHeaderValidationMiddleware>();

app.UseRouting();

app.UseSoapEndpoint<ITopicService>("/TopicService.asmx", new SoapEncoderOptions());

app.MapControllers();

app.Run();