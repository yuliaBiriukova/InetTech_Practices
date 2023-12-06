using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace InetTech_RestService.Extensions;

public static class ExceptionHandlingExtensions
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(x =>
        {
            x.Run(async context =>
            {
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = errorFeature?.Error;

                if(exception is not null)
                {
                    var errorResponse = new ErrorResponse
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = exception.Message
                    };

                    var json = JsonConvert.SerializeObject(errorResponse);
                    await context.Response.WriteAsync(json);
                }
            });
        });
    }
}

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
}