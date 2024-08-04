using Library.Domain.Interfaces;
using Library.Domain.Interfaces.Services;
using Library.Service.Rest;
using Library.Service.Services;

namespace Library.Api.Extensions {
    static class ServiceExtensions {

        public static IServiceCollection AddService(this IServiceCollection services) {

            services.AddScoped<IBookExternalRequestService, BookExternalRequestService>();
            services.AddScoped<IBookService, BookService>();          
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IBookExternalApi, BookApiRest>();

            

            return services;

        }

    }
}
