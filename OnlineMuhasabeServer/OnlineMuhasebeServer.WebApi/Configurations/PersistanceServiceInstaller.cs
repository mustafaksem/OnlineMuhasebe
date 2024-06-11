
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Persistance;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString(SectionName)));
            services.AddIdentity<AppUser, AppRole>()
                        .AddEntityFrameworkStores<AppDbContext>();
            services.AddAutoMapper(typeof(AssemblyReferance).Assembly);
        }   
    }
}
