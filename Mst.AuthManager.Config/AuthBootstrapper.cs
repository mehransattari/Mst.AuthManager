using Microsoft.Extensions.DependencyInjection;
using Mst.AuthManager.Infrastructure;
using Mst.AuthManager.Facade;
using Mst.AuthManager.Application;
using Mst.AuthManager.Query;

namespace Mst.AuthManager.Config;

public static class AuthBootstrapper
{
    public static void RegisterDependency(this IServiceCollection services, string connectionString)
    {
        services.InitInfrastructure(connectionString);

        services.InitApplication();

        services.InitQuery();

        services.InitFacadeDependency();
    }
}
