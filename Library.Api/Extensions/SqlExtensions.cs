using Library.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Api.Extensions {
    static class SqlExtensions {

        public static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConection")));

            return services;

        }

    }
}
