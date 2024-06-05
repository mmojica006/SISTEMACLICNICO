using CLINICAL.Application.Interface;
using CLINICAL.Persistence.Context;
using CLINICAL.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        /// <summary>
        /// configuration de la injeccion de dependencia
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            //Se configure como ciclo de vida singleton. Se crea una sola instancia de nuestra BD, ciclo de vida singleton
            services.AddSingleton<ApplicationDbContext>();
            services.AddScoped<IAnalysisRepository, AnalysisRepository>();
            return services;
        }
    }
}
