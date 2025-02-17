using WEBapiSPA.DAL;
using WEBapiSPA.DI;
using WEBapiSPA.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//настраиваем DI
//builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddSingleton<IMessageMemory,MessageMemory>();
builder.Services.AddTransient<LogService>();
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

//app.UseAuthorization();
//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
