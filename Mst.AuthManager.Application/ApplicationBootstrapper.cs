using Microsoft.Extensions.DependencyInjection;
using Mst.AuthManager.Application.UserAgg;
using Mst.AuthManager.Application.UserAgg.Create;
using Mst.AuthManager.Domain.UserAgg.Services;

namespace Mst.AuthManager.Application;

public static class ApplicationBootstrapper
{
    public static void InitApplication(this IServiceCollection services)
    {
        services.AddTransient<IUserDomainService, UserDomianService>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
        });
    }
}
