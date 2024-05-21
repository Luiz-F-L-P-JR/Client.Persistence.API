using Client.Persistence.Data.Client.Reposiroty;
using Client.Persistence.Data.PublicArea.Reposiroty;
using Client.Persistence.Domain.Client.Reposiroty.Interface;
using Client.Persistence.Domain.PublicArea.Reposiroty.Interface;

namespace Client.Persistence.API.Exension.IoC
{
    public static class IoC
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //services.AddScoped<ClientService, IClientService>();
            //services.AddScoped<ClientRepository, IClientRepository>();
            //services.AddScoped<PublicAreaService, IPublicAreaService>();
            //services.AddScoped<PublicAreaRepository, IPublicAreaRepository>();
        }
    }
}
