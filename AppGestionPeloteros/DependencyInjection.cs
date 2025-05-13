using Application;
using Infrastructure;


namespace AppGestionPeloteros
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppGestionPeloterosDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureDI(configuration)
                    .AddApplicationDI();
            
            
         
            return services;
        }
    }
}
