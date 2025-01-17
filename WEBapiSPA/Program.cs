using WEBapiSPA.DAL;
using WEBapiSPA.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//настраиваем DI
builder.Services.AddScoped<IMessageMemory, MessageMemory>();
// Configure the HTTP request pipeline.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();
//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
