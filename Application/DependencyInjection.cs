using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using Application.Dto.Adress;
using Application.Dto.Register;
using Application.Validators.AddressValidator;
using Application.Validators.UserValidator;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient<IValidator<RegisterDto>, UserValidations>();
            services.AddTransient<IValidator<AddressDto>, AddressValidations>();




            return services;
        }

    }
}
