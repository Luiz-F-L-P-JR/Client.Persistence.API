using Client.Persistence.API.Exension.ExceptionFilter;
using Client.Persistence.API.Exension.IoC;
using Client.Persistence.API.Exension.JwtAuthConfiguration;
using Client.Persistence.API.Exension.SwaggerConfiguration;
using Client.Persistence.Application.AutoMapping;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    options => 
    {
        options.Filters.Add(typeof(ExceptionFilter));
    }
)
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();


builder.Services.AddDependencyInjection();
builder.AddJwtAuthConfiguration();

builder.Services.AddAutoMapper(typeof(AutoMappingProfile));

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI
(
    s => s.InjectStylesheet("/swagger-ui/SwaggerDark.css")
);

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
