using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mst.AuthManager.Domain.RoleAgg.Repository;
using Mst.AuthManager.Domain.UserAgg.Repository;
using Mst.AuthManager.Infrastructure.Persistent.Dapper;
using Mst.AuthManager.Infrastructure.Persistent.Ef;
using Mst.AuthManager.Infrastructure.Persistent.Ef.RoleAgg;
using Mst.AuthManager.Infrastructure.Persistent.Ef.UserAgg;

namespace Mst.AuthManager.Infrastructure;

public static class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient(_ => new DapperContext(connectionString));

        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
    }
}
