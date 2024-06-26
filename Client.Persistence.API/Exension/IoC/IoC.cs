﻿using Client.Persistence.API.Helper;
using Client.Persistence.Application.Auth.JwtHelper.Interface;
using Client.Persistence.Application.Client.Service;
using Client.Persistence.Application.Client.Service.Interface;
using Client.Persistence.Application.PublicArea.Service;
using Client.Persistence.Application.PublicArea.Service.Interface;
using Client.Persistence.Data.Client.Reposiroty;
using Client.Persistence.Data.DbConnection;
using Client.Persistence.Data.DbConnection.Interface;
using Client.Persistence.Data.PublicArea.Reposiroty;
using Client.Persistence.Data.UserAuth;
using Client.Persistence.Domain.Client.Reposiroty.Interface;
using Client.Persistence.Domain.Client.Service;
using Client.Persistence.Domain.Client.Service.Interface;
using Client.Persistence.Domain.PublicArea.Reposiroty.Interface;
using Client.Persistence.Domain.PublicArea.Service;
using Client.Persistence.Domain.PublicArea.Service.Interface;
using Client.Persistence.Domain.UserAuth.Repostory.Interface;
using Microsoft.AspNetCore.Identity;

namespace Client.Persistence.API.Exension.IoC
{
    public static class IoC
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            #region User Injection
            services.AddScoped<IUserAuthRegister, UserAuthRegister>();
            #endregion

            #region Auth Injection
            services.AddScoped<IJwtAuth, JwtAuth>();
            #endregion

            #region Client Injection
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientDomainService, ClientDomainService>();
            services.AddScoped<IClientApplicationService, ClientApplicationService>();
            #endregion

            #region PublicArea Injection
            services.AddScoped<IPublicAreaRepository, PublicAreaRepository>();
            services.AddScoped<IPublicAreaDomainService, PublicAreaDomainService>();
            services.AddScoped<IPublicAreaApplicationService, PublicAreaApplicationService>();
            #endregion

            #region Db Connection Injection
            services.AddSingleton<IDbClientPersistenceConnection, DbClientPersistenceConnection>();
            #endregion
        }
    }
}
