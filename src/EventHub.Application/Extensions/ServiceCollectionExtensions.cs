using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using EventHub.Application.Profiles;

namespace EventHub.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(config =>
            {
                config.AddProfile<EventProfile>();
            });

            return services;
        }
    }
}
