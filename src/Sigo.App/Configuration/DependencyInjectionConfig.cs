using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Norma.Business.Intefaces;
using Norma.Business.Services;
using Norma.Data.Context;
using Norma.Data.Repository;
using Sigo.Business.Intefaces;
using Sigo.Business.Services;
using Sigo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigo.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();
            services.AddScoped<INormaInternaRepository, NormaInternaRepository>();
            services.AddScoped<IConsultoriaAcessoriaRepository, ConsultoriaAcessoriaRepository>();

            services.AddScoped<INormaInternaService, NormaInternaService>();
            services.AddScoped<IConsultoriaAcessoriaService, ConsultoriaAcessoriaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
