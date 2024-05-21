using Microsoft.OpenApi.Models;

namespace Client.Persistence.API.Exension.SwaggerConfiguration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Client Persistence API (CPA)",
                    Description = "This is an application built to register users and your public areas.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Luiz Fernando Junior.",
                        Email = "luizfernandojr1998@gmail.com"
                    }
                });
            });
        }
    }
}
