using Microsoft.Extensions.DependencyInjection;
using Mst.AuthManager.Facade.UserAgg;

namespace Mst.AuthManager.Facade;

public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<IUserFacade, UserFacade>();
    }
}
