using Microsoft.Extensions.DependencyInjection;
using Mst.AuthManager.Query.Mapping;
using Mst.AuthManager.Query.RoleAgg.GetById;

namespace Mst.AuthManager.Query;

public static class QueryBootstrapper
{
    public static void InitQuery(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetRoleByIdQuery).Assembly);
        });
    }
}
