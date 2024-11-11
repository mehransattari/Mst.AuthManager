using Microsoft.Extensions.DependencyInjection;
using Mst.AuthManager.Query.Mapping;

namespace Mst.AuthManager.Query;

public class QueryBootstrapper
{
    public static void Init(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
    }
}
