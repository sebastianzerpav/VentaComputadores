using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VentaComputadores.API.Data
{
    public static class DbContextConfiguration
    {
        public static void Configuration(IServiceCollection services, IConfiguration configuration) {
            String? dbConnectionStrings = configuration.GetConnectionString("DbConnectionStrings");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnectionStrings));

            if (String.IsNullOrWhiteSpace(dbConnectionStrings)) {
                throw new Exception("La cadena de conexión no está configurada correctamente");
            }
        }
    }
}
