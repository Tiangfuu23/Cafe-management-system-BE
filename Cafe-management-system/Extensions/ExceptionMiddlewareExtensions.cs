using Contracts;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Entities.ErrorModel;
using Entities.Exceptions;
namespace Cafe_management_system.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            UnauthorizedException => StatusCodes.Status401Unauthorized,
                            NotFoundException => StatusCodes.Status404NotFound,
                            ConflictException => StatusCodes.Status409Conflict,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            ForBiddenExpcetion => StatusCodes.Status403Forbidden,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message =   contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
