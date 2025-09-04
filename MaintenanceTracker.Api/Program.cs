
using MaintenanceTracker.Api.Controllers.Data;
using MaintenanceTracker.Api.Extension;
using MaintenanceTracker.Api.Repository.Implementation;
using MaintenanceTracker.Api.Repository.Interface;
using MaintenanceTracker.Api.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace MaintenanceTracker.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddIdentityCore<APIUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            })
                             .AddRoles<IdentityRole>()
                             .AddEntityFrameworkStores<MaintenanceDbContext>();

            builder.Services.AddService(builder.Configuration);
           // builder.Services.AddScoped<IMaintenenceRepository, MaintenanceRepository>();
           // builder.Services.AddScoped<IServiceMaintenance, IServiceMaintenance>();

           //var connectionString = builder.Configuration.GetConnectionString("connect");
           // builder.Services.AddDbContext<MaintenanceDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
