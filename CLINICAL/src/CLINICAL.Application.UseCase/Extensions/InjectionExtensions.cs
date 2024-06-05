using CLINICAL.Application.UseCase.Commons.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CLINICAL.Application.UseCase.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services) //Instancia a si mismo
        {
            //Inyectar servicios de mediaR
            services.AddMediatR(x=>x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Inyectar servicios de Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //Inyección fluent Validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //Inyectar validationBehavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviours<,>));

            return services;
        }
    }
}
