using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Logging;
using WEBapiSPA.DAL;
using WEBapiSPA.DI;
using WEBapiSPA.Filters;
using WEBapiSPA.Services;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers(c =>
{
    c.Filters.Add<LogActionFilter>();
});//добавляем фильтры тут*/


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("Sec-Fetch-Mode");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

//настраиваем DI
//builder.Services.AddSingleton<ILogger,LogService>();
builder.Services.AddSingleton<IMessageMemory,MessageMemory>();
builder.Services.AddScoped<IMessageFile,FileService>();
// Configure the HTTP request pipeline.

//разрешаем запрос сервака ангуляра к asp net core(CORS)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins(
                            "http://localhost:4200"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors("AllowAngularOrigins");

app.UseHttpLogging();
//app.UseAuthorization();
//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
