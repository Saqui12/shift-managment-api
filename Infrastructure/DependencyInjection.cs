using Application.Services.Iterfaces;
using Dominio.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Services;
using Dominio.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Dominio.Interfaces.Authentication;
using Infrastructure.Repositories.Authentication;

namespace Infrastructure
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddInfrastructureDI( this IServiceCollection services, IConfiguration configuration)
        {




            //services.AddDbContext<PeloterosDbContext>(options =>
            //     options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString_DB")));

            services.AddDbContext<PeloterosDbContext>(options =>
                 options.UseNpgsql(configuration["ConnectionString_DB"]));





            //var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            //var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            //var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            //var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa; Password={dbPassword}; TrustServerCertificate=True;Encrypt=False";
            //services.AddDbContext<PeloterosDbContext>(options =>
            //     options.UseSqlServer(connectionString));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITurnosRepository, TurnoRepository>();
            services.AddScoped<IBloqueoRepository, BloqueoRepository>();
            services.AddScoped<IRecursoRepository, RecursoRepository>();
            services.AddScoped<IHorariosDisponibilidadRepository, HorariosDisponiblesRespository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IPagosRepository, PagosRepository>();


            services.AddScoped<IRoleMana, RoleMana>();
            services.AddScoped<ITokenMana, TokenMana>();
            services.AddScoped<IUserMana, UserMana>();
            

            services.AddScoped(typeof(IAppLogger<>), typeof(Serilogger<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));



            services.AddIdentityCore<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            }).AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<PeloterosDbContext>()
              .AddDefaultTokenProviders(); 

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
              {
                  options.SaveToken = true;
                  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = configuration["Jwt:Issuer"],
                      ValidAudience = configuration["Jwt:Audience"],
                      ClockSkew = TimeSpan.Zero,
                      IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                  };
                  //options.Events = new JwtBearerEvents
                  //{
                  //    OnMessageReceived = context =>
                  //    {
                  //        // Extraer token desde la cookie
                  //        if (context.Request.Cookies.ContainsKey("JWT"))
                  //        {
                  //            context.Token = context.Request.Cookies["JWT"];
                  //        }
                  //        return Task.CompletedTask;
                  //    }
                  //};
              });





                    return services;
        }
    }
    
    
}
