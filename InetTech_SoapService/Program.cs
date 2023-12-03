using InetTech_SoapService.Helpers;
using InetTech_SoapService.Repositories;
using InetTech_SoapService.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();

builder.Services.AddSingleton<ITopicRepository, TopicRepository>();

builder.Services.AddSingleton<IProfileService, ProfileService>();
builder.Services.AddSingleton<ITopicService, TopicService>();
builder.Services.AddSoapMessageInspector<SecurityTokenMessageInspector>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseSoapEndpoint<IProfileService>("/ProfileService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<ITopicService>("/TopicService.asmx", new SoapEncoderOptions());

app.MapControllers();

app.Run();