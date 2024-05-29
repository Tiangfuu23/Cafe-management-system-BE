using Cafe_management_system.Extensions;
using Contracts;
using Microsoft.Extensions.FileProviders;
using NLog;
var builder = WebApplication.CreateBuilder(args);

// load logger configure
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory, "nlog.config"));

// Add services to the container.

builder.Services.ConfigureCors();

builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService();

builder.Services.ConfigurePostgreSql(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddAuthentication();

builder.Services.ConfigureServiceManager();

builder.Services.ConfigRepositoryManager();

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.ConfigureEmailService(builder.Configuration);

builder.Services.ConfigureSwagger();

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
var _logger = app.Services.GetRequiredService<ILoggerManager>();

app.UseCors("cors");

app.ConfigureExceptionHandler(_logger);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
    RequestPath = "/StaticFiles"
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
