using Client.Persistence.API.Exension.ExceptionFilter;
using Client.Persistence.API.Exension.IoC;
using Client.Persistence.Application.AutoMapping;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    options => 
    {
        options.Filters.Add(typeof(ExceptionFilter));
    }
).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection();

builder.Services.AddAutoMapper(typeof(AutoMappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
