using Application.Services.DTOs.Cliente;
using Application.Services.DTOs.Pago;
using Application.Services.DTOs.Turno;
using Application.Services.DTOs.User;
using Application.Services.Implementation;
using Application.Services.Iterfaces;
using Application.Services.Validators;
using Application.Services.Validators.Iterface;
using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System;



namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddScoped<IValidator<ClienteCreationDto>, ClienteCreation>();
            services.AddScoped<IValidator<TurnoCreationDto>, TurnoCreation>();
            services.AddScoped<IValidator<TurnoUpdateDto>,UpdateTurno >();
            services.AddScoped<IValidator<PagoCreationDto>, PagoCreation>();
            services.AddScoped<IValidator<CreateUser>, CreationUser>();
            services.AddScoped<IValidator<UpdateUser>, UpdateUserCreation>();
            services.AddScoped<IValidator<PagoDto>, PagoUpdate>();
            services.AddScoped<IValidationService, ValidationService>();

            services.AddScoped<ITurnoService, TurnoService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPagosService, PagoService>();
            services.AddScoped<IClientesService, ClienteService>();
            services.AddScoped<IRecursoServices, RecursoServices>();
            services.AddScoped<IBloqueoServices, BloqueoService>();
            services.AddScoped<IHorarioDisponibilidadService, HorarioDisponibilidadService>();
            services.AddScoped<IoauthService, oauthService>();
            services.AddHttpClient();

            return services;
        }
    }
}
