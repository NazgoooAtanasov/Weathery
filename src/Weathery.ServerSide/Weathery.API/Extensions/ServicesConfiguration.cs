namespace Weathery.API.Extensions
{
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using Microsoft.Extensions.DependencyInjection;
    using Services.HashService;
    using Services.TokenService;
    using Services.UserService;
    using ViewModels;
    using ViewModels.Authentication;
    using ViewModels.Authentication.Validators;
    using ViewModels.Validators;

    /// <summary>Class used to configure the services for the application.</summary>
    public static class ServicesConfiguration
    {
        /// <summary>
        ///     Used to register every single service for the application.
        /// </summary>
        /// <param name="services">The current collection of <see cref="IServiceCollection" /> of the application.</param>
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHashService, HashService>();

            services.AddTransient<IValidator<CreateUserViewModel>, CrateUserViewModelValidator>();
            services.AddTransient<IValidator<LoginViewModel>, LoginViewModelValidator>();
            services.AddTransient<IValidator<SaveCityViewModel>, SaveCityViewModelValidator>();

            services.AddControllers().AddFluentValidation();
        }
    }
}