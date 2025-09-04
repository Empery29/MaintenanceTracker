using MaintenanceTracker.Api.Authetication;
using MaintenanceTracker.Api.Controllers.Data;
using MaintenanceTracker.Api.Repository.Implementation;
using MaintenanceTracker.Api.Repository.Interface;
using MaintenanceTracker.Api.Service.Implementation;
using MaintenanceTracker.Api.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceTracker.Api.Extension
{
    public static class ServiceExtension
    {
        public static void AddService( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMaintenenceRepository, MaintenanceRepository>();
            services.AddScoped<IServiceMaintenance, ServiceMaintenance>();
            services.AddScoped<IAutoManager, AutoManager>();

            var connectionString = configuration.GetConnectionString("connect");
            services.AddDbContext<MaintenanceDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
