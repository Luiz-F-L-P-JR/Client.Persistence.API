using Client.Persistence.Application.Client.Service;
using Client.Persistence.Application.Client.Service.Interface;
using Client.Persistence.Application.PublicArea.Service;
using Client.Persistence.Application.PublicArea.Service.Interface;
using Client.Persistence.Data.Client.Reposiroty;
using Client.Persistence.Data.PublicArea.Reposiroty;
using Client.Persistence.Domain.Client.Reposiroty.Interface;
using Client.Persistence.Domain.Client.Service;
using Client.Persistence.Domain.Client.Service.Interface;
using Client.Persistence.Domain.PublicArea.Reposiroty.Interface;
using Client.Persistence.Domain.PublicArea.Service;
using Client.Persistence.Domain.PublicArea.Service.Interface;

namespace Client.Persistence.API.Exension.IoC
{
    public static class IoC
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<ClientRepository, IClientRepository>();
            services.AddScoped<ClientDomainService, IClientDomainService>();
            services.AddScoped<ClientApplicationService, IClientApplicationService>();

            services.AddScoped<PublicAreaRepository, IPublicAreaRepository>();
            services.AddScoped<PublicAreaDomainService, IPublicAreaDomainService>();
            services.AddScoped<PublicAreaApplicationService, IPublicAreaApplicationService>();
        }
    }
}
