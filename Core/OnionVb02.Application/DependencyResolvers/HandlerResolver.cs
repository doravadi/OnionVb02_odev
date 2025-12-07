using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.Behaviors;
using System.Reflection;

namespace OnionVb02.Application.DependencyResolvers
{
    public static class HandlerResolver
    {
        public static void AddHandlerService(this IServiceCollection services)
        {
            // MediatR - automatically registers all handlers in the assembly
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            // Validation Behavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Validators from ValidatorStructor project will be registered via ValidatorResolver
        }
    }
}
