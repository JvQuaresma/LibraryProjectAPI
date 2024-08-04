using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Library.Infra.Repositories;
using Library.Service.Services;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Api.Extensions {
    static class RepositoryExtensions {

        public static IServiceCollection AddRepository(this IServiceCollection services) {

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }

    }
}
