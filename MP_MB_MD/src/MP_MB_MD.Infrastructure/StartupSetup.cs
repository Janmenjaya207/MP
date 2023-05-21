using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MP_MB_MD.Infrastructure.Data;

namespace MP_MB_MD.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)); // will be created in web project root
    }
}
